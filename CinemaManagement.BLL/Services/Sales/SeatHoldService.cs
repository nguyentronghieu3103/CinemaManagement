using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Sales
{
    public class SeatHoldService : ISeatHoldService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatHoldService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        // ================= SƠ ĐỒ GHẾ =================
        public async Task<Result<SeatMapDto>> GetSeatMapAsync(int showtimeId, DateTime? myHeldAt, IReadOnlyCollection<int>? mySeatIds)
        {
            Showtime? showtime = await LoadShowtimeAsync(showtimeId);
            if (showtime == null)
                return Result<SeatMapDto>.Fail("Suất chiếu không tồn tại.");

            // Ghế hết hạn giữ → trả về Trong NGAY TRONG DATABASE (không chỉ ẩn trên giao diện)
            await ResetExpiredHoldsAsync(showtimeId);

            List<Seat> seats = await _unitOfWork.Seats.Query()
                .AsNoTracking()
                .Where(s => s.CinemaRoomId == showtime.CinemaRoomId)
                .OrderBy(s => s.Hang).ThenBy(s => s.Cot)
                .ToListAsync();

            Dictionary<int, SeatShowtimeStatus> statusBySeat = (await _unitOfWork.SeatShowtimeStatuses.Query()
                .AsNoTracking()
                .Where(x => x.ShowtimeId == showtimeId)
                .ToListAsync())
                .ToDictionary(x => x.SeatId);

            Dictionary<SeatType, decimal> surcharges = await GetSurchargesAsync();
            DateTime cutoff = HoldCutoff();
            IReadOnlyCollection<int> mine = mySeatIds ?? Array.Empty<int>();

            var dtos = new List<SeatDto>();
            foreach (Seat seat in seats)
            {
                SeatStatus status = SeatStatus.Trong;      // chưa có dòng trạng thái = Trống
                bool isMine = false;

                if (statusBySeat.TryGetValue(seat.Id, out SeatShowtimeStatus? row))
                {
                    if (row.TrangThai == SeatStatus.DaDat)
                    {
                        status = SeatStatus.DaDat;
                    }
                    else if (row.TrangThai == SeatStatus.DangGiu && row.ThoiGianGiu.HasValue && row.ThoiGianGiu.Value > cutoff)
                    {
                        status = SeatStatus.DangGiu;
                        isMine = myHeldAt.HasValue && row.ThoiGianGiu.Value == myHeldAt.Value && mine.Contains(seat.Id);
                    }
                }

                dtos.Add(ToSeatDto(seat, showtime.GiaVeCoSo, surcharges, status, isMine));
            }

            return Result<SeatMapDto>.Success(new SeatMapDto
            {
                ShowtimeId = showtimeId,
                TenPhong = showtime.CinemaRoom.TenPhong,
                SoHang = Math.Max(showtime.CinemaRoom.SoHang, seats.Select(s => s.Hang).DefaultIfEmpty(0).Max()),
                SoCot = Math.Max(showtime.CinemaRoom.SoCot, seats.Select(s => s.Cot).DefaultIfEmpty(0).Max()),
                Seats = dtos
            });
        }

        // ================= GIỮ GHẾ =================
        public async Task<Result<SeatHoldDto>> HoldSeatsAsync(int showtimeId, IReadOnlyCollection<int> seatIds)
        {
            List<int> ids = (seatIds ?? Array.Empty<int>()).Distinct().ToList();
            if (ids.Count == 0)
                return Result<SeatHoldDto>.Fail("Vui lòng chọn ít nhất một ghế.");

            Showtime? showtime = await LoadShowtimeAsync(showtimeId);
            if (showtime == null)
                return Result<SeatHoldDto>.Fail("Suất chiếu không tồn tại.");
            if (HasStarted(showtime))
                return Result<SeatHoldDto>.Fail("Suất chiếu đã bắt đầu, không thể giữ ghế.");

            List<Seat> seats = await _unitOfWork.Seats.Query()
                .AsNoTracking()
                .Where(s => ids.Contains(s.Id) && s.CinemaRoomId == showtime.CinemaRoomId)
                .ToListAsync();
            if (seats.Count != ids.Count)
                return Result<SeatHoldDto>.Fail("Có ghế không tồn tại trong phòng chiếu của suất này.");

            // Suất chưa có dòng trạng thái cho ghế → tạo dòng "Trống" trước (ngoài transaction giữ ghế)
            await EnsureStatusRowsAsync(showtimeId, ids);

            DateTime heldAt = TruncateToMicroseconds(DateTime.Now);     // Postgres lưu tới micro giây → cắt để so sánh bằng nhau được
            DateTime cutoff = heldAt.AddMinutes(-SeatHoldConstants.HoldMinutes);

            // Hai nhân viên giữ các tập ghế giao nhau có thể khiến PostgreSQL báo deadlock (40P01) hoặc
            // serialization failure (40001). Đây là lỗi tạm thời: hủy transaction rồi thử lại tối đa 3 lần.
            for (int attempt = 1; ; attempt++)
            {
                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    // CHỐT CHẶN CHỐNG TRÙNG GHẾ: 1 câu UPDATE có điều kiện, database tự khóa dòng.
                    // Chỉ cập nhật ghế đang Trống, hoặc đang DangGiu nhưng đã hết hạn.
                    // Nếu nhân viên khác vừa giữ trước, điều kiện không còn đúng → ghế đó KHÔNG được cập nhật.
                    int affected = await _unitOfWork.SeatShowtimeStatuses.Query()
                        .Where(x => x.ShowtimeId == showtimeId
                                 && ids.Contains(x.SeatId)
                                 && (x.TrangThai == SeatStatus.Trong
                                     || (x.TrangThai == SeatStatus.DangGiu && (x.ThoiGianGiu == null || x.ThoiGianGiu <= cutoff))))
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(x => x.TrangThai, SeatStatus.DangGiu)
                            .SetProperty(x => x.ThoiGianGiu, (DateTime?)heldAt));

                    if (affected != ids.Count)
                    {
                        // Tất cả hoặc không ghế nào: có ghế bị giành mất thì hủy hết
                        await _unitOfWork.RollbackTransactionAsync();
                        return Result<SeatHoldDto>.Fail(await BuildUnavailableMessageAsync(showtimeId, seats));
                    }

                    await _unitOfWork.CommitTransactionAsync();
                    break;
                }
                catch (Exception ex) when (IsTransientConflict(ex))
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    if (attempt >= 3)
                        return Result<SeatHoldDto>.Fail("Hệ thống đang bận do nhiều nhân viên cùng thao tác. Vui lòng thử lại.");
                    await Task.Delay(Random.Shared.Next(30, 120));
                }
                catch
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }
            }

            Dictionary<SeatType, decimal> surcharges = await GetSurchargesAsync();
            return Result<SeatHoldDto>.Success(BuildHoldDto(showtime, seats, surcharges, heldAt));
        }

        // ================= KIỂM TRA LẠI PHIÊN GIỮ =================
        public async Task<Result<SeatHoldDto>> ValidateHoldAsync(int showtimeId, IReadOnlyCollection<int> seatIds, DateTime heldAt)
        {
            List<int> ids = (seatIds ?? Array.Empty<int>()).Distinct().ToList();
            if (ids.Count == 0)
                return Result<SeatHoldDto>.Fail("Chưa có ghế nào được giữ.");

            Showtime? showtime = await LoadShowtimeAsync(showtimeId);
            if (showtime == null)
                return Result<SeatHoldDto>.Fail("Suất chiếu không tồn tại.");
            if (HasStarted(showtime))
                return Result<SeatHoldDto>.Fail("Suất chiếu đã bắt đầu.");

            if (heldAt.AddMinutes(SeatHoldConstants.HoldMinutes) <= DateTime.Now)
                return Result<SeatHoldDto>.Fail("Đã hết thời gian giữ ghế. Vui lòng chọn lại ghế.");

            // Đọc lại từ database: đúng ghế, đang DangGiu, đúng thời điểm giữ của phiên này
            List<SeatShowtimeStatus> rows = await _unitOfWork.SeatShowtimeStatuses.Query()
                .AsNoTracking()
                .Where(x => x.ShowtimeId == showtimeId && ids.Contains(x.SeatId))
                .ToListAsync();

            bool stillMine = rows.Count == ids.Count
                && rows.All(r => r.TrangThai == SeatStatus.DangGiu && r.ThoiGianGiu == heldAt);
            if (!stillMine)
                return Result<SeatHoldDto>.Fail("Ghế không còn được giữ cho đơn này (đã hết hạn hoặc bị nhân viên khác chiếm). Vui lòng chọn lại ghế.");

            List<Seat> seats = await _unitOfWork.Seats.Query()
                .AsNoTracking()
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();

            Dictionary<SeatType, decimal> surcharges = await GetSurchargesAsync();
            return Result<SeatHoldDto>.Success(BuildHoldDto(showtime, seats, surcharges, heldAt));
        }

        // ================= NHẢ GHẾ =================
        public async Task<Result> ReleaseSeatsAsync(int showtimeId, IReadOnlyCollection<int> seatIds, DateTime heldAt)
        {
            List<int> ids = (seatIds ?? Array.Empty<int>()).Distinct().ToList();
            if (ids.Count == 0) return Result.Success();

            // Chỉ nhả ghế do CHÍNH phiên này giữ (đúng ThoiGianGiu), không đụng ghế của người khác
            await _unitOfWork.SeatShowtimeStatuses.Query()
                .Where(x => x.ShowtimeId == showtimeId
                         && ids.Contains(x.SeatId)
                         && x.TrangThai == SeatStatus.DangGiu
                         && x.ThoiGianGiu == heldAt)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.TrangThai, SeatStatus.Trong)
                    .SetProperty(x => x.ThoiGianGiu, (DateTime?)null));

            return Result.Success();
        }

        // ================= HÀM PHỤ =================
        // PostgreSQL: 40P01 = deadlock_detected, 40001 = serialization_failure. Đọc SqlState bằng reflection
        // để BLL không phải tham chiếu trực tiếp Npgsql.
        private static bool IsTransientConflict(Exception? ex)
        {
            for (; ex != null; ex = ex.InnerException)
            {
                string? sqlState = ex.GetType().GetProperty("SqlState")?.GetValue(ex) as string;
                if (sqlState == "40P01" || sqlState == "40001") return true;
            }
            return false;
        }

        private static DateTime HoldCutoff() => DateTime.Now.AddMinutes(-SeatHoldConstants.HoldMinutes);

        private static DateTime TruncateToMicroseconds(DateTime value)
            => new DateTime(value.Ticks - value.Ticks % 10, value.Kind);

        private static bool HasStarted(Showtime showtime)
            => showtime.NgayChieu.Date + showtime.GioBatDau <= DateTime.Now;

        private async Task<Showtime?> LoadShowtimeAsync(int showtimeId)
            => await _unitOfWork.Showtimes.Query()
                .AsNoTracking()
                .Include(s => s.CinemaRoom)
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

        private async Task ResetExpiredHoldsAsync(int showtimeId)
        {
            DateTime cutoff = HoldCutoff();
            await _unitOfWork.SeatShowtimeStatuses.Query()
                .Where(x => x.ShowtimeId == showtimeId
                         && x.TrangThai == SeatStatus.DangGiu
                         && (x.ThoiGianGiu == null || x.ThoiGianGiu <= cutoff))
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.TrangThai, SeatStatus.Trong)
                    .SetProperty(x => x.ThoiGianGiu, (DateTime?)null));
        }

        // Phụ thu theo loại ghế lấy từ bảng LoaiGhePhuThu có sẵn (SeatTypeSurcharge)
        private async Task<Dictionary<SeatType, decimal>> GetSurchargesAsync()
        {
            var list = await _unitOfWork.SeatTypeSurcharges.Query().AsNoTracking().ToListAsync();
            return list.ToDictionary(x => x.LoaiGhe, x => x.SoTienPhuThu);
        }

        private static SeatDto ToSeatDto(Seat seat, decimal basePrice, Dictionary<SeatType, decimal> surcharges, SeatStatus status, bool isMine)
        {
            surcharges.TryGetValue(seat.LoaiGhe, out decimal surcharge);   // không có dòng phụ thu = 0
            return new SeatDto
            {
                SeatId = seat.Id,
                Hang = seat.Hang,
                Cot = seat.Cot,
                Label = SeatLabelHelper.Format(seat.Hang, seat.Cot),
                LoaiGhe = seat.LoaiGhe,
                Gia = basePrice + surcharge,
                Status = status,
                IsHeldByMe = isMine
            };
        }

        private static SeatHoldDto BuildHoldDto(Showtime showtime, List<Seat> seats, Dictionary<SeatType, decimal> surcharges, DateTime heldAt)
        {
            List<SeatDto> dtos = seats
                .OrderBy(s => s.Hang).ThenBy(s => s.Cot)
                .Select(s => ToSeatDto(s, showtime.GiaVeCoSo, surcharges, SeatStatus.DangGiu, true))
                .ToList();

            return new SeatHoldDto
            {
                ShowtimeId = showtime.Id,
                HeldAt = heldAt,
                ExpiresAt = heldAt.AddMinutes(SeatHoldConstants.HoldMinutes),
                Seats = dtos,
                TongTienVe = dtos.Sum(s => s.Gia)
            };
        }

        // Thêm dòng SeatShowtimeStatus(Trong) cho ghế chưa có dòng. Nếu 2 nhân viên cùng thêm một lúc
        // thì 1 bên bị trùng khóa chính → bỏ entity lỗi khỏi tracker rồi thử lại (dòng đã có rồi).
        private async Task EnsureStatusRowsAsync(int showtimeId, List<int> seatIds)
        {
            for (int attempt = 0; attempt < 3; attempt++)
            {
                List<int> existing = await _unitOfWork.SeatShowtimeStatuses.Query()
                    .AsNoTracking()
                    .Where(x => x.ShowtimeId == showtimeId && seatIds.Contains(x.SeatId))
                    .Select(x => x.SeatId)
                    .ToListAsync();

                List<int> missing = seatIds.Except(existing).ToList();
                if (missing.Count == 0) return;

                var added = new List<SeatShowtimeStatus>();
                foreach (int seatId in missing)
                {
                    var row = new SeatShowtimeStatus
                    {
                        ShowtimeId = showtimeId,
                        SeatId = seatId,
                        TrangThai = SeatStatus.Trong,
                        ThoiGianGiu = null
                    };
                    await _unitOfWork.SeatShowtimeStatuses.AddAsync(row);
                    added.Add(row);
                }

                try
                {
                    await _unitOfWork.SaveChangesAsync();
                    return;
                }
                catch (DbUpdateException)
                {
                    foreach (SeatShowtimeStatus row in added)
                        _unitOfWork.SeatShowtimeStatuses.Remove(row);   // Remove trên entity Added = bỏ khỏi tracker
                }
            }
        }

        private async Task<string> BuildUnavailableMessageAsync(int showtimeId, List<Seat> seats)
        {
            List<int> ids = seats.Select(s => s.Id).ToList();
            DateTime cutoff = HoldCutoff();

            List<int> unavailableSeatIds = await _unitOfWork.SeatShowtimeStatuses.Query()
                .AsNoTracking()
                .Where(x => x.ShowtimeId == showtimeId
                         && ids.Contains(x.SeatId)
                         && (x.TrangThai == SeatStatus.DaDat
                             || (x.TrangThai == SeatStatus.DangGiu && x.ThoiGianGiu != null && x.ThoiGianGiu > cutoff)))
                .Select(x => x.SeatId)
                .ToListAsync();

            if (unavailableSeatIds.Count == 0)
                return "Không thể giữ ghế vào lúc này. Vui lòng thử lại.";

            string labels = string.Join(", ", seats
                .Where(s => unavailableSeatIds.Contains(s.Id))
                .OrderBy(s => s.Hang).ThenBy(s => s.Cot)
                .Select(s => SeatLabelHelper.Format(s.Hang, s.Cot)));

            return $"Ghế {labels} đã được giữ hoặc đã được đặt bởi người khác.";
        }
    }
}

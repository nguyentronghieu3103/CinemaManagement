using CinemaManagement.BLL.BusinessRules;
using CinemaManagement.Common.DTOs.Tickets;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Tickets
{
    public class CheckInService : ICheckInService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketCodeService _codes;

        public CheckInService(IUnitOfWork unitOfWork, ITicketCodeService codes)
        {
            _unitOfWork = unitOfWork;
            _codes = codes;
        }

        public async Task<Result<CheckInTicketDto>> LookupAsync(string rawInput)
        {
            // Máy quét cầm tay thường thêm ký tự xuống dòng, Trim() xử lý luôn
            string input = (rawInput ?? string.Empty).Trim().ToUpperInvariant();
            if (input.Length == 0)
                return Result<CheckInTicketDto>.Fail("Vui lòng quét hoặc nhập mã vé.");

            Ticket? ticket;

            if (input.Contains('.'))                         // dạng QR: có chữ ký
            {
                if (!_codes.TryVerifyQrPayload(input))
                    return Result<CheckInTicketDto>.Fail("Mã QR không hợp lệ hoặc đã bị chỉnh sửa.");

                ticket = await BuildQuery().FirstOrDefaultAsync(t => t.MaQR == input);
            }
            else if (_codes.TryParseDisplayCode(input, out int id))   // dạng nhập tay: VE000325
            {
                ticket = await BuildQuery().FirstOrDefaultAsync(t => t.Id == id);
            }
            else
            {
                return Result<CheckInTicketDto>.Fail("Mã vé không đúng định dạng. Ví dụ: VE000325");
            }

            if (ticket is null)
                return Result<CheckInTicketDto>.Fail("Không tìm thấy vé trong hệ thống.");

            return Result<CheckInTicketDto>.Success(await ToDtoAsync(ticket));
        }

        public async Task<Result<CheckInTicketDto>> ConfirmCheckInAsync(int ticketId, int staffUserId)
        {
            var ticket = await BuildQuery().FirstOrDefaultAsync(t => t.Id == ticketId);
            if (ticket is null)
                return Result<CheckInTicketDto>.Fail("Không tìm thấy vé trong hệ thống.");

            var now = DateTime.Now;

            // Kiểm tra lại ở BLL, không tin dữ liệu UI đã hiện
            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, now);
            if (!canCheckIn)
                return Result<CheckInTicketDto>.Fail(reason!);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Cập nhật có điều kiện: nếu cổng khác vừa check-in xong thì affected = 0
                int affected = await _unitOfWork.Tickets.Query()
                    .Where(t => t.Id == ticketId && t.TrangThaiCheckIn == CheckInStatus.ChuaCheckIn)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(t => t.TrangThaiCheckIn, CheckInStatus.DaCheckIn)
                        .SetProperty(t => t.ThoiGianCheckIn, (DateTime?)now));

                if (affected == 0)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return Result<CheckInTicketDto>.Fail("Vé vừa được check-in ở cổng khác.");
                }

                await _unitOfWork.AuditLogs.AddAsync(new AuditLog
                {
                    UserId = staffUserId,
                    HanhDong = AuditAction.CheckIn,
                    ThoiGian = now,
                    ChiTiet = $"Check-in vé {_codes.ToDisplayCode(ticketId)}"
                });

                await _unitOfWork.CommitTransactionAsync();
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }

            var fresh = await BuildQuery().FirstAsync(t => t.Id == ticketId);
            return Result<CheckInTicketDto>.Success(await ToDtoAsync(fresh));
        }

        // AsNoTracking: lần nào cũng đọc trạng thái mới nhất từ DB
        private IQueryable<Ticket> BuildQuery() => _unitOfWork.Tickets.Query()
            .AsNoTracking()
            .Include(t => t.Invoice)
            .Include(t => t.Seat)
            .Include(t => t.Showtime).ThenInclude(s => s.Movie)
            .Include(t => t.Showtime).ThenInclude(s => s.CinemaRoom);

        private async Task<CheckInTicketDto> ToDtoAsync(Ticket t)
        {
            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(t, DateTime.Now);

            int total = await _unitOfWork.Tickets.Query().CountAsync(x => x.InvoiceId == t.InvoiceId);
            int done = await _unitOfWork.Tickets.Query()
                .CountAsync(x => x.InvoiceId == t.InvoiceId && x.TrangThaiCheckIn == CheckInStatus.DaCheckIn);

            return new CheckInTicketDto
            {
                TicketId = t.Id,
                MaVe = _codes.ToDisplayCode(t.Id),
                TenPhim = t.Showtime.Movie.TenPhim,
                TenPhong = t.Showtime.CinemaRoom.TenPhong,
                NgayChieu = t.Showtime.NgayChieu,
                GioBatDau = t.Showtime.GioBatDau,
                ViTriGhe = SeatLabelHelper.Format(t.Seat.Hang, t.Seat.Cot),
                TongVeCungHoaDon = total,
                SoVeDaCheckInCungHoaDon = done,
                CoTheCheckIn = canCheckIn,
                LyDoTuChoi = reason
            };
        }
    }
}
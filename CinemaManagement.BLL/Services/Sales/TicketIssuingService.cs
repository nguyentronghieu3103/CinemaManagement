using CinemaManagement.BLL.Services.Tickets;
using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Sales
{
    public class TicketIssuingService : ITicketIssuingService
    {
        public const string SeatUnavailableMessage = "Ghế đã hết thời gian giữ hoặc không còn khả dụng.";

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketCodeService _codes;

        public TicketIssuingService(IUnitOfWork unitOfWork, ITicketCodeService codes)
        {
            _unitOfWork = unitOfWork;
            _codes = codes;
        }

        public async Task<Result<List<IssuedTicketDto>>> IssueTicketsAsync(int invoiceId, CartDto cart)
        {
            List<int> seatIds = cart.Seats.Select(s => s.SeatId).Distinct().ToList();
            if (seatIds.Count == 0 || seatIds.Count != cart.Seats.Count)
                return Result<List<IssuedTicketDto>>.Fail("Danh sách ghế trong đơn không hợp lệ.");

            // ---- 1. Hóa đơn hợp lệ ----
            Invoice? invoice = await _unitOfWork.Invoices.Query().AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == invoiceId);
            if (invoice == null
                || invoice.TrangThaiThanhToan != InvoiceStatus.DaThanhToan
                || invoice.PhuongThuc != PaymentMethod.TienMat)
                return Result<List<IssuedTicketDto>>.Fail("Hóa đơn không hợp lệ hoặc chưa thanh toán.");

            // ---- 2. Thanh toán thành công và khớp tổng tiền hóa đơn ----
            bool paymentOk = await _unitOfWork.Payments.ExistsAsync(p =>
                p.InvoiceId == invoiceId && p.TrangThai == TransactionStatus.Success && p.SoTien == invoice.TongTien);
            if (!paymentOk)
                return Result<List<IssuedTicketDto>>.Fail("Chưa có giao dịch thanh toán thành công cho hóa đơn này.");

            // ---- 3. Hóa đơn chưa có vé, và các ghế này chưa từng có vé (tránh bán trùng) ----
            if (await _unitOfWork.Tickets.ExistsAsync(t => t.InvoiceId == invoiceId))
                return Result<List<IssuedTicketDto>>.Fail("Hóa đơn này đã được tạo vé.");
            if (await _unitOfWork.Tickets.ExistsAsync(t => t.ShowtimeId == cart.ShowtimeId && seatIds.Contains(t.SeatId)))
                return Result<List<IssuedTicketDto>>.Fail(SeatUnavailableMessage);

            // ---- 4. Đọc lại DATABASE: đúng suất, đang DangGiu, đúng phiên giữ, còn hạn (không tin trạng thái từ UI) ----
            if (cart.HeldAt.AddMinutes(SeatHoldConstants.HoldMinutes) <= DateTime.Now)
                return Result<List<IssuedTicketDto>>.Fail(SeatUnavailableMessage);

            int stillHeld = await _unitOfWork.SeatShowtimeStatuses.Query().AsNoTracking()
                .CountAsync(x => x.ShowtimeId == cart.ShowtimeId
                              && seatIds.Contains(x.SeatId)
                              && x.TrangThai == SeatStatus.DangGiu
                              && x.ThoiGianGiu == cart.HeldAt);
            if (stillHeld != seatIds.Count)
                return Result<List<IssuedTicketDto>>.Fail(SeatUnavailableMessage);

            // ---- 5. Tạo Ticket: MỖI GHẾ MỘT VÉ; giá vé là giá backend đã tính lại; MaQR do TicketCodeService (đúng cái Check-in verify) ----
            var tickets = new List<(Ticket Ticket, SeatDto Seat)>();
            foreach (SeatDto seat in cart.Seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot))
            {
                var ticket = new Ticket
                {
                    InvoiceId = invoiceId,
                    ShowtimeId = cart.ShowtimeId,
                    SeatId = seat.SeatId,
                    GiaVe = seat.Gia,
                    MaQR = _codes.GenerateQrPayload(),
                    TrangThaiCheckIn = CheckInStatus.ChuaCheckIn
                    // ThoiGianCheckIn = null (chưa check-in)
                };
                await _unitOfWork.Tickets.AddAsync(ticket);
                tickets.Add((ticket, seat));
            }

            // Ghi để lấy Id vé (dùng cho mã hiển thị "VE000325"). Vẫn nằm trong transaction của người gọi, chưa commit.
            // Chỉ mục duy nhất (ShowtimeId, SeatId) và MaQR ở database là chốt chặn cuối: nếu lỗi → DbUpdateException, người gọi rollback.
            await _unitOfWork.SaveChangesAsync();

            // ---- 6. Ghế DangGiu → DaDat: 1 câu UPDATE có điều kiện. Không đủ dòng = có ghế đã mất → người gọi rollback toàn bộ ----
            int updated = await _unitOfWork.SeatShowtimeStatuses.Query()
                .Where(x => x.ShowtimeId == cart.ShowtimeId
                         && seatIds.Contains(x.SeatId)
                         && x.TrangThai == SeatStatus.DangGiu
                         && x.ThoiGianGiu == cart.HeldAt)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.TrangThai, SeatStatus.DaDat)
                    .SetProperty(x => x.ThoiGianGiu, (DateTime?)null));

            if (updated != seatIds.Count)
                return Result<List<IssuedTicketDto>>.Fail(SeatUnavailableMessage);

            var result = tickets.Select(t => new IssuedTicketDto
            {
                TicketId = t.Ticket.Id,
                MaVe = _codes.ToDisplayCode(t.Ticket.Id),
                MaQR = t.Ticket.MaQR,
                SeatId = t.Seat.SeatId,
                ViTriGhe = t.Seat.Label,
                LoaiGhe = t.Seat.LoaiGhe switch { SeatType.Vip => "VIP", SeatType.Doi => "Đôi", _ => "Thường" },
                GiaVe = t.Ticket.GiaVe
            }).ToList();

            return Result<List<IssuedTicketDto>>.Success(result);
        }
    }
}

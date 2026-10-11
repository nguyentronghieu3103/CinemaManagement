using CinemaManagement.Common.Constants;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.BLL.BusinessRules
{
    public static class TicketRules
    {
        /// <summary>
        /// Kiểm tra tính hợp lệ của vé khi check-in tại quầy/cửa soát vé:
        /// 1. Vé phải thuộc hóa đơn đã thanh toán.
        /// 2. Vé chưa từng được check-in trước đó.
        /// 3. Khung giờ check-in hợp lệ: Từ 30 phút trước khi bắt đầu đến sau 15 phút khi bắt đầu.
        /// </summary>
        public static (bool CanCheckIn, string? Reason) EvaluateCheckIn(Ticket ticket, DateTime now)
        {
            ArgumentNullException.ThrowIfNull(ticket);

            if (ticket.Invoice is null)
                throw new InvalidOperationException("Ticket phải nạp cùng Invoice (Eager Loading) để kiểm tra check-in.");

            if (ticket.Showtime is null)
                throw new InvalidOperationException("Ticket phải nạp cùng Showtime (Eager Loading) để kiểm tra check-in.");

            if (ticket.Invoice.TrangThaiThanhToan != InvoiceStatus.DaThanhToan)
                return (false, "Vé chưa thanh toán hoặc đã bị hủy.");

            if (ticket.TrangThaiCheckIn == CheckInStatus.DaCheckIn)
                return (false, $"Vé đã check-in lúc {ticket.ThoiGianCheckIn:HH:mm dd/MM/yyyy}.");

            DateTime start = ticket.Showtime.NgayChieu.Date + ticket.Showtime.GioBatDau;
            DateTime opens = start.AddMinutes(-CheckInConstants.OpenMinutesBeforeStart);
            DateTime closes = start.AddMinutes(CheckInConstants.CloseMinutesAfterStart);

            if (now < opens)
            {
                string openTimeText = opens.Date == now.Date
                    ? opens.ToString("HH:mm")
                    : opens.ToString("HH:mm dd/MM/yyyy");
                return (false, $"Chưa tới giờ vào rạp. Mở check-in lúc {openTimeText}.");
            }

            if (now > closes)
            {
                string closeTimeText = closes.Date == now.Date
                    ? closes.ToString("HH:mm")
                    : closes.ToString("HH:mm dd/MM/yyyy");
                return (false, $"Suất chiếu đã bắt đầu quá lâu. Check-in đã đóng lúc {closeTimeText}.");
            }

            return (true, null);
        }
    }
}
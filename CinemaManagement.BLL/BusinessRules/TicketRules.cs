using CinemaManagement.Common.Constants;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.BLL.BusinessRules
{
    public static class TicketRules
    {
        // Ticket phải được Include sẵn Invoice và Showtime
        public static (bool CanCheckIn, string? Reason) EvaluateCheckIn(Ticket ticket, DateTime now)
        {
            if (ticket.Invoice.TrangThaiThanhToan != InvoiceStatus.DaThanhToan)
                return (false, "Vé chưa thanh toán hoặc đã bị hủy.");

            if (ticket.TrangThaiCheckIn == CheckInStatus.DaCheckIn)
                return (false, $"Vé đã check-in lúc {ticket.ThoiGianCheckIn:HH:mm dd/MM/yyyy}.");

            DateTime start = ticket.Showtime.NgayChieu.Date + ticket.Showtime.GioBatDau;
            DateTime opens = start.AddMinutes(-CheckInConstants.OpenMinutesBeforeStart);
            DateTime closes = start.AddMinutes(CheckInConstants.CloseMinutesAfterStart);

            if (now < opens)
                return (false, $"Chưa tới giờ vào rạp. Mở check-in lúc {opens:HH:mm}.");

            if (now > closes)
                return (false, "Suất chiếu đã bắt đầu quá lâu, vé không còn check-in được.");

            return (true, null);
        }
    }
}
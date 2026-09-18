using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; } = null!;

        public int SeatId { get; set; }
        public Seat Seat { get; set; } = null!;

        public decimal GiaVe { get; set; }           // snapshot giá tại thời điểm bán
        public string MaQR { get; set; } = string.Empty;

        public CheckInStatus TrangThaiCheckIn { get; set; } = CheckInStatus.ChuaCheckIn;
        public DateTime? ThoiGianCheckIn { get; set; }
    }
}
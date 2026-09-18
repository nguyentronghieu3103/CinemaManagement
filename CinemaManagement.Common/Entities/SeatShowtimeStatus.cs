using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class SeatShowtimeStatus
    {
        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; } = null!;

        public int SeatId { get; set; }
        public Seat Seat { get; set; } = null!;

        public SeatStatus TrangThai { get; set; } = SeatStatus.Trong;
        public DateTime? ThoiGianGiu { get; set; }    
    }
}
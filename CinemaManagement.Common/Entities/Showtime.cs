using CinemaManagement.Common.Entities;

namespace CinemaManagement.Common.Entities
{
    public class Showtime
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public int CinemaRoomId { get; set; }
        public CinemaRoom CinemaRoom { get; set; } = null!;

        public DateTime NgayChieu { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal GiaVeCoSo { get; set; }

        public ICollection<SeatShowtimeStatus> SeatStatuses { get; set; } = new List<SeatShowtimeStatus>();
    }
}
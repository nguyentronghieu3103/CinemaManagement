namespace CinemaManagement.Common.Entities
{
    public class CinemaRoom
    {
        public int Id { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public int SoHang { get; set; }
        public int SoCot { get; set; }

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
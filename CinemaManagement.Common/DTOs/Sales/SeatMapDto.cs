namespace CinemaManagement.Common.DTOs.Sales
{
    public class SeatMapDto
    {
        public int ShowtimeId { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public int SoHang { get; set; }
        public int SoCot { get; set; }
        public List<SeatDto> Seats { get; set; } = new();
    }
}

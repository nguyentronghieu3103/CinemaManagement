namespace CinemaManagement.Common.DTOs.Sales
{
    // Kết quả giữ ghế thành công. HeldAt cũng là "dấu" nhận diện phiên giữ trong database (cột ThoiGianGiu).
    public class SeatHoldDto
    {
        public int ShowtimeId { get; set; }
        public DateTime HeldAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public List<SeatDto> Seats { get; set; } = new();
        public decimal TongTienVe { get; set; }
    }
}

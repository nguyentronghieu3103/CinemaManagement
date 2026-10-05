namespace CinemaManagement.Common.DTOs.Sales
{
    // Giỏ hàng đã được BACKEND kiểm tra và tính tiền (ghế còn được giữ + giá lấy từ database).
    // Đây là dữ liệu bàn giao cho bước Thanh toán (Phase 5). HeldAt là "dấu" phiên giữ ghế trong database.
    public class CartDto
    {
        public int ShowtimeId { get; set; }
        public DateTime HeldAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public List<SeatDto> Seats { get; set; } = new();
        public List<CartComboItemDto> Combos { get; set; } = new();

        public decimal TongTienGhe { get; set; }
        public decimal TongTienCombo { get; set; }
        public decimal TongTien { get; set; }     // TongTienGhe + TongTienCombo
    }
}

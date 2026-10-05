namespace CinemaManagement.Common.DTOs.Sales
{
    // 1 combo bắp nước hiển thị ở bước "Combo / Giỏ hàng". Giá lấy từ bảng Combo trong database.
    public class ComboDto
    {
        public int ComboId { get; set; }
        public string TenCombo { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
    }
}

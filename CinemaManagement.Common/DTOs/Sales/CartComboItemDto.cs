namespace CinemaManagement.Common.DTOs.Sales
{
    // 1 dòng combo trong giỏ hàng (chỉ gồm combo có số lượng > 0)
    public class CartComboItemDto
    {
        public int ComboId { get; set; }
        public string TenCombo { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }       // đơn giá tại thời điểm chốt giỏ (Phase 5 lưu vào HoaDonCombo.DonGiaLucMua)
        public decimal ThanhTien { get; set; }    // DonGia * SoLuong
    }
}

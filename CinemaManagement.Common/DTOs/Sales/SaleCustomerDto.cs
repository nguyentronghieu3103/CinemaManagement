namespace CinemaManagement.Common.DTOs.Sales
{
    // 1 khách hàng hiển thị ở bước Thanh toán (tìm / chọn / vừa tạo). Đọc từ bảng KhachHang có sẵn.
    public class SaleCustomerDto
    {
        public int CustomerId { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int DiemTichLuy { get; set; }
    }
}

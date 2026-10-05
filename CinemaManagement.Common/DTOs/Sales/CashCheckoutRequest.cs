namespace CinemaManagement.Common.DTOs.Sales
{
    // Dữ liệu UI gửi cho backend khi bấm "Xác nhận thanh toán" (tiền mặt).
    // UI CHỈ gửi "định danh" (suất, ghế, phiên giữ, số lượng combo, khách, người bán) và số tiền khách đưa.
    // KHÔNG có giá vé / giá combo / tổng tiền / trạng thái ghế: backend tự đọc lại tất cả từ database.
    public class CashCheckoutRequest
    {
        public int ShowtimeId { get; set; }
        public List<int> SeatIds { get; set; } = new();
        public DateTime HeldAt { get; set; }                                   // "dấu" phiên giữ ghế (ThoiGianGiu)
        public Dictionary<int, int> ComboQuantities { get; set; } = new();     // ComboId -> SoLuong
        public int? CustomerId { get; set; }                                   // null = khách vãng lai
        public int UserId { get; set; }                                        // nhân viên đang đăng nhập
        public decimal TienKhachDua { get; set; }

        // Số tiền nhân viên ĐANG NHÌN THẤY. Chỉ dùng để phát hiện giá đã đổi và DỪNG lại,
        // không bao giờ dùng làm số tiền ghi vào hóa đơn (số tiền ghi luôn do backend tính lại).
        public decimal? TongTienDangHienThi { get; set; }
    }
}

namespace CinemaManagement.Common.DTOs.Sales
{
    // 1 vé vừa được tạo sau khi thanh toán thành công (Phase 6). 1 ghế = 1 vé.
    public class IssuedTicketDto
    {
        public int TicketId { get; set; }
        public string MaVe { get; set; } = string.Empty;    // mã hiển thị/nhập tay từ TicketCodeService.ToDisplayCode, vd. "VE000325"
        public string MaQR { get; set; } = string.Empty;    // đúng giá trị lưu ở Ve.MaQR (token.chữ ký) mà Check-in đọc
        public int SeatId { get; set; }
        public string ViTriGhe { get; set; } = string.Empty;
        public string LoaiGhe { get; set; } = string.Empty;
        public decimal GiaVe { get; set; }
    }
}

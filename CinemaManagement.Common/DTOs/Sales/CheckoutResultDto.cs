namespace CinemaManagement.Common.DTOs.Sales
{
    // Kết quả giao dịch tiền mặt hoàn tất: Hóa đơn + Thanh toán + Vé (+QR) đã được commit, ghế đã DaDat.
    public class CheckoutResultDto
    {
        public int InvoiceId { get; set; }
        public int PaymentId { get; set; }
        public DateTime NgayLap { get; set; }
        public int? CustomerId { get; set; }
        public decimal TongTien { get; set; }          // do backend tính lại
        public decimal TienKhachDua { get; set; }
        public decimal TienThua { get; set; }
        public string PhuongThuc { get; set; } = "Tiền mặt";
        public CartDto Cart { get; set; } = new();
        public List<IssuedTicketDto> Tickets { get; set; } = new();   // Phase 6: vé đã tạo (1 ghế = 1 vé)
    }
}

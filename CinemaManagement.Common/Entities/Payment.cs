using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public string? MaGiaoDichVNPay { get; set; }
        public decimal SoTien { get; set; }
        public string? MaPhanHoi { get; set; }         // vnp_ResponseCode trả về
        public string? NoiDungIPN { get; set; }         // lưu raw callback để tra soát khi có tranh chấp
        public TransactionStatus TrangThai { get; set; } = TransactionStatus.Pending;
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        public DateTime? ThoiGianCapNhat { get; set; }
    }
}
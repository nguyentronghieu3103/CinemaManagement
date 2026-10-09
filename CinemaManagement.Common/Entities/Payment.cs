using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public string? MaGiaoDichSeepay { get; set; }
        public decimal SoTien { get; set; }

        public string? MaPhanHoi { get; set; }        
        public string? NoiDungIPN { get; set; }        
        public TransactionStatus TrangThai { get; set; } = TransactionStatus.Pending;
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        public DateTime? ThoiGianCapNhat { get; set; }
    }
}
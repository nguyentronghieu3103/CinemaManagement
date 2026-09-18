using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class EmailLog
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public string DiaChiNhan { get; set; } = string.Empty;
        public DateTime ThoiGianGui { get; set; } = DateTime.Now;
        public EmailStatus TrangThai { get; set; }
        public string? LoiNeuCo { get; set; }
    }
}
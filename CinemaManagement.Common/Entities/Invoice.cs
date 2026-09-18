
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using System.Net.Sockets;

namespace CinemaManagement.Common.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public int UserId { get; set; }            
        public User User { get; set; } = null!;

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime NgayLap { get; set; } = DateTime.Now;
        public decimal TongTien { get; set; }
        public InvoiceStatus TrangThaiThanhToan { get; set; } = InvoiceStatus.ChoThanhToan;
        public PaymentMethod PhuongThuc { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<InvoiceCombo> InvoiceCombos { get; set; } = new List<InvoiceCombo>();
    }
}
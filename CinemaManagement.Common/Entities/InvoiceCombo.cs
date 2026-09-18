using CinemaManagement.Common.Entities;

namespace CinemaManagement.Common.Entities
{
    public class InvoiceCombo
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public int ComboId { get; set; }
        public Combo Combo { get; set; } = null!;

        public int SoLuong { get; set; }
        public decimal DonGiaLucMua { get; set; }    
    }
}
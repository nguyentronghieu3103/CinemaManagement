namespace CinemaManagement.Common.Entities
{
    public class Combo
    {
        public int Id { get; set; }
        public string TenCombo { get; set; } = string.Empty;
        public decimal Gia { get; set; }
        public string? MoTa { get; set; }
    }
}
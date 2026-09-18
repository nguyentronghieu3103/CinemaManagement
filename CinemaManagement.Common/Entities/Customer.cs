namespace CinemaManagement.Common.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int DiemTichLuy { get; set; } = 0;
    }
}
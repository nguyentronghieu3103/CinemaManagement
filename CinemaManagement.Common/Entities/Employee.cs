using CinemaManagement.Common.Enums;
namespace CinemaManagement.Common.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int UserId { get; set; }        
        public User User { get; set; } = null!;

        public string HoTen { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public DateTime NgayVaoLam { get; set; }
        public string ChucVu { get; set; } = string.Empty;
        public EmployeeStatus TrangThaiLamViec { get; set; } = EmployeeStatus.DangLamViec;
    }
}
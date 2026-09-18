using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }

        public int? UserId { get; set; }          
        public User? User { get; set; }

        public AuditAction HanhDong { get; set; }
        public DateTime ThoiGian { get; set; } = DateTime.Now;
        public string? ChiTiet { get; set; }       
    }
}
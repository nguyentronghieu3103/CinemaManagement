using CinemaApp.Common.Enums;
using CinemaManagement.Common.Entities;

namespace CinemaManagement.Common.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string MatKhauHash { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public UserStatus TrangThaiTaiKhoan { get; set; } = UserStatus.Active;
        public int SoLanSaiMatKhau { get; set; } = 0;
        public DateTime? ThoiGianKhoaDenLuc { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
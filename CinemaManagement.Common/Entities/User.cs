using CinemaManagement.Common.Enums;
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
        public DateTime? LanSaiCuoiCung { get; set; }
        public DateTime? ThoiGianKhoaDenLuc { get; set; }
        public int SoLanBiKhoa { get; set; } = 0;
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
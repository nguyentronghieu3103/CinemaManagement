using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.DTOs.Auth
{
    public class UserProfileDto
    {
        public int EmployeeId { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string ChucVu { get; set; } = string.Empty;
        public DateTime NgayVaoLam { get; set; }
        public EmployeeStatus TrangThaiLamViec { get; set; } = EmployeeStatus.DangLamViec;
        public string TrangThaiLamViecText { get; set; } = "Đang làm việc";

        /// <summary>
        /// Mã nhân viên hiển thị (NV000001), định dạng từ ID nhân viên, không lưu DB.
        /// </summary>
        public string FormattedEmployeeCode => $"NV{EmployeeId:D6}";
    }
}


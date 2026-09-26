namespace CinemaManagement.Common.DTOs.Dashboard
{
    public class StaffDashboardDto
    {
        public int VeDaBanHomNay { get; set; }
        public int SoSuatChieuHomNay { get; set; }
        public int SoLuotCheckInHomNay { get; set; }
        public decimal DoanhThuHomNay { get; set; }
        public List<UpcomingShowtimeDto> SuatChieuSapDienRa { get; set; } = new();
    }

    public class UpcomingShowtimeDto
    {
        public TimeSpan GioBatDau { get; set; }
        public string TenPhim { get; set; } = string.Empty;
        public string TenPhong { get; set; } = string.Empty;
        public int DaBan { get; set; }
        public int TongGhe { get; set; }
        public string TrangThai { get; set; } = string.Empty;  
    }
}
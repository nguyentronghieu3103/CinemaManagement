namespace CinemaManagement.Common.DTOs.Tickets
{
    public class CheckInTicketDto
    {
        public int TicketId { get; set; }
        public string MaVe { get; set; } = string.Empty;        
        public string TenPhim { get; set; } = string.Empty;
        public string TenPhong { get; set; } = string.Empty;
        public DateTime NgayChieu { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public string ViTriGhe { get; set; } = string.Empty;    
        public int TongVeCungHoaDon { get; set; }
        public int SoVeDaCheckInCungHoaDon { get; set; }
        public bool CoTheCheckIn { get; set; }
        public string? LyDoTuChoi { get; set; }                 
    }
}
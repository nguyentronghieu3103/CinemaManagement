namespace CinemaManagement.Common.DTOs.Tickets
{
    public class TicketDetailDto
    {
        public int InvoiceId { get; set; }
        public string InvoiceCode { get; set; } = string.Empty;
        public string RepresentativeTicketCode { get; set; } = string.Empty;
        public string MovieName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public DateTime NgayChieu { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public string Seats { get; set; } = string.Empty;
        public string SeatType { get; set; } = string.Empty;
        public decimal TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; } = string.Empty;
        public string TrangThaiThanhToan { get; set; } = string.Empty;
        public string TrangThaiCheckIn { get; set; } = string.Empty;
        public string CheckInTimeStr { get; set; } = string.Empty;
        
        public string KhachHangTen { get; set; } = string.Empty;
        public string KhachHangSdt { get; set; } = string.Empty;
        public int DiemTichLuy { get; set; }
        public string HangThanhVien { get; set; } = string.Empty;
        public string NvBanVe { get; set; } = string.Empty;
        
        public int ThoiLuong { get; set; }
        public string ManChieu { get; set; } = string.Empty;
        
        public List<string> Combos { get; set; } = new List<string>();
        public decimal ComboTotal { get; set; }
        public string TrangThaiFb { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
    }
}

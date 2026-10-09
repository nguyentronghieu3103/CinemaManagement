namespace CinemaManagement.Common.DTOs.Sales
{
    // Thông tin 1 suất chiếu hiển thị ở bước "Chọn suất chiếu"
    public class SaleShowtimeDto
    {
        public int ShowtimeId { get; set; }
        public int CinemaRoomId { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public DateTime NgayChieu { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal GiaVeCoSo { get; set; }
        public int TongGhe { get; set; }
        public int GheConTrong { get; set; }     // Trống + ghế DangGiu đã hết hạn giữ
    }
}

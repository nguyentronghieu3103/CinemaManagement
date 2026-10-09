namespace CinemaManagement.Common.DTOs.Sales
{
    // Thông tin 1 phim hiển thị ở bước "Chọn phim" của màn Bán vé
    public class SaleMovieDto
    {
        public int MovieId { get; set; }
        public string TenPhim { get; set; } = string.Empty;
        public int ThoiLuong { get; set; }                       // phút
        public string TheLoai { get; set; } = string.Empty;      // "Hành động, Hài"
        public string DoTuoi { get; set; } = string.Empty;       // "P", "K", "T13"...
        public string? Poster { get; set; }
        public int SoSuatConLai { get; set; }                    // số suất chưa bắt đầu trong ngày đã chọn
    }
}

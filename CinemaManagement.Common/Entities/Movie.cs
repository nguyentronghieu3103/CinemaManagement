using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string TenPhim { get; set; } = string.Empty;
        public int ThoiLuong { get; set; }           // phút
        public AgeRating DoTuoi { get; set; }
        public string DaoDien { get; set; } = string.Empty;
        public string DienVien { get; set; } = string.Empty;
        public DateTime NgayKhoiChieu { get; set; }
        public MovieStatus TrangThai { get; set; } = MovieStatus.SapChieu;
        public string? Poster { get; set; }           // đường dẫn file ảnh

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
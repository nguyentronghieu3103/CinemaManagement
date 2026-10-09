using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Sales
{
    public class SaleCatalogService : ISaleCatalogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleCatalogService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<List<SaleMovieDto>>> GetMoviesForSaleAsync(DateTime date, string? keyword)
        {
            DateTime day = date.Date;
            if (day < DateTime.Today)
                return Result<List<SaleMovieDto>>.Fail("Không thể bán vé cho ngày đã qua.");

            // Bước 1: các suất trong ngày của phim đang chiếu
            var showtimes = _unitOfWork.Showtimes.Query()
                .AsNoTracking()
                .Where(s => s.NgayChieu.Date == day && s.Movie.TrangThai == MovieStatus.DangChieu);

            // Nếu là hôm nay thì bỏ các suất đã bắt đầu
            if (day == DateTime.Today)
            {
                TimeSpan now = DateTime.Now.TimeOfDay;
                showtimes = showtimes.Where(s => s.GioBatDau > now);
            }

            var counts = await showtimes
                .GroupBy(s => s.MovieId)
                .Select(g => new { MovieId = g.Key, SoSuat = g.Count() })
                .ToListAsync();

            if (counts.Count == 0)
                return Result<List<SaleMovieDto>>.Success(new List<SaleMovieDto>());

            // Bước 2: lấy thông tin phim + thể loại
            List<int> movieIds = counts.Select(c => c.MovieId).ToList();

            var moviesQuery = _unitOfWork.Movies.Query()
                .AsNoTracking()
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Where(m => movieIds.Contains(m.Id));

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                moviesQuery = moviesQuery.Where(m => m.TenPhim.ToLower().Contains(kw));
            }

            List<Movie> movies = await moviesQuery.OrderBy(m => m.TenPhim).ToListAsync();

            var result = movies.Select(m => new SaleMovieDto
            {
                MovieId = m.Id,
                TenPhim = m.TenPhim,
                ThoiLuong = m.ThoiLuong,
                TheLoai = string.Join(", ", m.MovieGenres.Select(mg => mg.Genre.TenTheLoai)),
                DoTuoi = FormatAgeRating(m.DoTuoi),
                Poster = m.Poster,
                SoSuatConLai = counts.First(c => c.MovieId == m.Id).SoSuat
            }).ToList();

            return Result<List<SaleMovieDto>>.Success(result);
        }

        public async Task<Result<List<SaleShowtimeDto>>> GetShowtimesForSaleAsync(int movieId, DateTime date)
        {
            DateTime day = date.Date;
            if (day < DateTime.Today)
                return Result<List<SaleShowtimeDto>>.Fail("Không thể bán vé cho ngày đã qua.");

            bool movieOk = await _unitOfWork.Movies.ExistsAsync(m => m.Id == movieId && m.TrangThai == MovieStatus.DangChieu);
            if (!movieOk)
                return Result<List<SaleShowtimeDto>>.Fail("Phim không tồn tại hoặc đã ngừng chiếu.");

            var query = _unitOfWork.Showtimes.Query()
                .AsNoTracking()
                .Include(s => s.CinemaRoom)
                .Where(s => s.MovieId == movieId && s.NgayChieu.Date == day);

            // Hôm nay: bỏ các suất đã bắt đầu
            if (day == DateTime.Today)
            {
                TimeSpan now = DateTime.Now.TimeOfDay;
                query = query.Where(s => s.GioBatDau > now);
            }

            List<Showtime> showtimes = await query.OrderBy(s => s.GioBatDau).ToListAsync();
            if (showtimes.Count == 0)
                return Result<List<SaleShowtimeDto>>.Success(new List<SaleShowtimeDto>());

            List<int> showtimeIds = showtimes.Select(s => s.Id).ToList();
            List<int> roomIds = showtimes.Select(s => s.CinemaRoomId).Distinct().ToList();

            // Tổng ghế của từng phòng
            var seatTotals = await _unitOfWork.Seats.Query()
                .Where(s => roomIds.Contains(s.CinemaRoomId))
                .GroupBy(s => s.CinemaRoomId)
                .Select(g => new { RoomId = g.Key, Count = g.Count() })
                .ToListAsync();

            // Ghế không còn bán được: DaDat, hoặc DangGiu mà CHƯA hết hạn giữ.
            // Ghế chưa có dòng trong SeatShowtimeStatus = Trống nên không cần đếm.
            DateTime holdCutoff = DateTime.Now.AddMinutes(-SeatHoldConstants.HoldMinutes);
            var unavailable = await _unitOfWork.SeatShowtimeStatuses.Query()
                .Where(x => showtimeIds.Contains(x.ShowtimeId)
                         && (x.TrangThai == SeatStatus.DaDat
                             || (x.TrangThai == SeatStatus.DangGiu && x.ThoiGianGiu != null && x.ThoiGianGiu > holdCutoff)))
                .GroupBy(x => x.ShowtimeId)
                .Select(g => new { ShowtimeId = g.Key, Count = g.Count() })
                .ToListAsync();

            var result = showtimes.Select(s =>
            {
                int total = seatTotals.FirstOrDefault(x => x.RoomId == s.CinemaRoomId)?.Count ?? 0;
                int taken = unavailable.FirstOrDefault(x => x.ShowtimeId == s.Id)?.Count ?? 0;
                return new SaleShowtimeDto
                {
                    ShowtimeId = s.Id,
                    CinemaRoomId = s.CinemaRoomId,
                    TenPhong = s.CinemaRoom.TenPhong,
                    NgayChieu = s.NgayChieu,
                    GioBatDau = s.GioBatDau,
                    GioKetThuc = s.GioKetThuc,
                    GiaVeCoSo = s.GiaVeCoSo,
                    TongGhe = total,
                    GheConTrong = Math.Max(0, total - taken)
                };
            }).ToList();

            return Result<List<SaleShowtimeDto>>.Success(result);
        }

        // Enum AgeRating đặt tên p, k (chữ thường) nên đổi sang dạng hiển thị chuẩn
        private static string FormatAgeRating(AgeRating rating) => rating switch
        {
            AgeRating.p => "P",
            AgeRating.k => "K",
            _ => rating.ToString()
        };
    }
}

using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Sales
{
    public interface ISaleCatalogService
    {
        // Phim đang chiếu có ít nhất 1 suất CHƯA bắt đầu trong ngày `date`.
        // keyword: lọc theo tên phim (có thể null/rỗng).
        Task<Result<List<SaleMovieDto>>> GetMoviesForSaleAsync(DateTime date, string? keyword);

        // Các suất chưa bắt đầu của 1 phim trong ngày `date`, kèm số ghế còn trống.
        Task<Result<List<SaleShowtimeDto>>> GetShowtimesForSaleAsync(int movieId, DateTime date);
    }
}

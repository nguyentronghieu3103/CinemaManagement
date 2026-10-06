using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Sales
{
    public interface ICartService
    {
        // Danh sách combo đang bán, lấy từ database (rẻ nhất trước). Danh sách rỗng nếu chưa có combo nào.
        Task<Result<List<ComboDto>>> GetCombosAsync();

        // Dựng và CHỐT giỏ hàng: kiểm tra lại phiên giữ ghế trong database, tính lại giá ghế và giá combo
        // từ database. Không nhận bất kỳ số tiền nào từ UI.
        // comboQuantities: ComboId -> SoLuong (số lượng 0 được bỏ qua, số âm/quá trần bị từ chối).
        Task<Result<CartDto>> BuildCartAsync(
            int showtimeId,
            IReadOnlyCollection<int> seatIds,
            DateTime heldAt,
            IReadOnlyDictionary<int, int> comboQuantities);
    }
}

using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Sales
{
    public interface ISeatHoldService
    {
        // Sơ đồ ghế của suất chiếu, trạng thái lấy từ database. Đồng thời trả ghế hết hạn giữ về Trống.
        // myHeldAt/mySeatIds: phiên giữ hiện tại của màn hình (nếu có) để đánh dấu ghế "của mình".
        Task<Result<SeatMapDto>> GetSeatMapAsync(int showtimeId, DateTime? myHeldAt, IReadOnlyCollection<int>? mySeatIds);

        // Giữ TOÀN BỘ danh sách ghế trong 5 phút (all-or-nothing).
        Task<Result<SeatHoldDto>> HoldSeatsAsync(int showtimeId, IReadOnlyCollection<int> seatIds);

        // Kiểm tra lại phiên giữ còn hiệu lực trong database và tính lại giá.
        Task<Result<SeatHoldDto>> ValidateHoldAsync(int showtimeId, IReadOnlyCollection<int> seatIds, DateTime heldAt);

        // Nhả ghế do chính phiên này giữ (khớp ThoiGianGiu), không đụng ghế của người khác.
        Task<Result> ReleaseSeatsAsync(int showtimeId, IReadOnlyCollection<int> seatIds, DateTime heldAt);
    }
}

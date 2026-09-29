using CinemaManagement.Common.DTOs.Tickets;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Tickets
{
    public interface ICheckInService
    {
        // Fail: mã sai, QR giả, không tìm thấy vé.
        // Success: luôn trả thông tin vé, kể cả khi chưa check-in được (xem CoTheCheckIn / LyDoTuChoi).
        Task<Result<CheckInTicketDto>> LookupAsync(string rawInput);
        Task<Result<CheckInTicketDto>> ConfirmCheckInAsync(int ticketId, int staffUserId);
    }
}
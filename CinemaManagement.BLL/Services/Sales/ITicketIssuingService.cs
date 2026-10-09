using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Sales
{
    // PHASE 6: tạo Vé + QR và chuyển ghế DangGiu → DaDat.
    // QUAN TRỌNG: hàm này KHÔNG mở và KHÔNG commit transaction. Người gọi (CheckoutService) phải đang ở trong một
    // transaction đã ghi Invoice + Payment (chưa commit), để Hóa đơn/Thanh toán/Vé/Ghế cùng commit hoặc cùng rollback.
    public interface ITicketIssuingService
    {
        Task<Result<List<IssuedTicketDto>>> IssueTicketsAsync(int invoiceId, CartDto cart);
    }
}

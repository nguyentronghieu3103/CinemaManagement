using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Sales
{
    // Thanh toán (PHASE 5: chỉ TIỀN MẶT). VNPay/online làm ở phase sau.
    public interface ICheckoutService
    {
        // Thanh toán tiền mặt trong 1 transaction DUY NHẤT: kiểm tra lại phiên giữ ghế + tính lại toàn bộ tiền từ database
        // → Invoice (DaThanhToan, TienMat) + InvoiceCombo + Payment (Success) → (PHASE 6) Ticket + QR cho từng ghế
        // → ghế DangGiu → DaDat → commit. Lỗi ở bất kỳ bước nào = rollback tất cả, không có tiền thu mà thiếu vé.
        Task<Result<CheckoutResultDto>> CheckoutCashAsync(CashCheckoutRequest request);
    }
}

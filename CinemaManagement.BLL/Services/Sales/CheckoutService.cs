using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace CinemaManagement.BLL.Services.Sales
{
    public class CheckoutService : ICheckoutService
    {
        // Chặn bấm thanh toán 2 lần cùng lúc cho 1 phiên giữ (ShowtimeId + HeldAt) trong tiến trình này.
        // Chốt chặn thật ở database: sau khi thành công ghế là DaDat nên lần thanh toán thứ hai không còn khóa được ghế DangGiu,
        // và chỉ mục duy nhất (ShowtimeId, SeatId) của bảng Vé chặn bán trùng ghế.
        private static readonly ConcurrentDictionary<string, byte> HoldsInUseOrPaid = new();

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartService _cartService;
        private readonly ITicketIssuingService _ticketIssuing;

        public CheckoutService(IUnitOfWork unitOfWork, ICartService cartService, ITicketIssuingService ticketIssuing)
        {
            _unitOfWork = unitOfWork;
            _cartService = cartService;
            _ticketIssuing = ticketIssuing;
        }

        public async Task<Result<CheckoutResultDto>> CheckoutCashAsync(CashCheckoutRequest request)
        {
            // ---- 1. Kiểm tra đầu vào không cần chạm database ----
            if (request == null)
                return Result<CheckoutResultDto>.Fail("Yêu cầu thanh toán không hợp lệ.");

            List<int> seatIds = (request.SeatIds ?? new List<int>()).Distinct().ToList();
            if (seatIds.Count == 0)
                return Result<CheckoutResultDto>.Fail("Chưa có ghế nào trong đơn hàng. Vui lòng quay lại chọn ghế.");

            if (request.TienKhachDua < 0)
                return Result<CheckoutResultDto>.Fail("Tiền khách đưa không được âm.");
            if (request.TienKhachDua > PaymentConstants.MaxCashReceived)
                return Result<CheckoutResultDto>.Fail("Tiền khách đưa quá lớn, vui lòng kiểm tra lại số tiền đã nhập.");

            if (request.HeldAt.AddMinutes(SeatHoldConstants.HoldMinutes) <= DateTime.Now)
                return Result<CheckoutResultDto>.Fail("Đã hết thời gian giữ ghế. Vui lòng chọn lại ghế.");

            // ---- 2. Người bán + khách hàng phải tồn tại ----
            bool userOk = await _unitOfWork.Users.ExistsAsync(u => u.Id == request.UserId && u.TrangThaiTaiKhoan == UserStatus.Active);
            if (!userOk)
                return Result<CheckoutResultDto>.Fail("Tài khoản nhân viên không hợp lệ hoặc đã bị khóa. Vui lòng đăng nhập lại.");

            if (request.CustomerId.HasValue)
            {
                bool customerOk = await _unitOfWork.Customers.ExistsAsync(c => c.Id == request.CustomerId.Value);
                if (!customerOk)
                    return Result<CheckoutResultDto>.Fail("Khách hàng đã chọn không còn tồn tại. Vui lòng chọn lại khách hàng.");
            }

            // ---- 3. Chặn thanh toán trùng cho cùng 1 phiên giữ ----
            string holdKey = $"{request.ShowtimeId}:{request.HeldAt.Ticks}";
            if (!HoldsInUseOrPaid.TryAdd(holdKey, 0))
                return Result<CheckoutResultDto>.Fail("Đơn hàng này đang được xử lý hoặc đã được thanh toán.");

            bool paid = false;
            try
            {
                Result<CheckoutResultDto> result = await RunCheckoutTransactionAsync(request, seatIds);
                paid = result.IsSuccess;
                return result;
            }
            finally
            {
                // Thất bại (kể cả lỗi bất ngờ) → cho phép thử lại. Thành công → giữ khóa để không tạo hóa đơn thứ hai.
                if (!paid) HoldsInUseOrPaid.TryRemove(holdKey, out _);
            }
        }

        private async Task<Result<CheckoutResultDto>> RunCheckoutTransactionAsync(CashCheckoutRequest request, List<int> seatIds)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // ---- 4. Khóa dòng ghế + xác nhận phiên giữ còn hiệu lực NGAY TRONG transaction ----
                // 1 câu UPDATE có điều kiện (đặt lại đúng giá trị cũ) để PostgreSQL khóa các dòng ghế đến hết transaction.
                // Đúng ghế, đúng suất, còn DangGiu, đúng "dấu" ThoiGianGiu của phiên này; ít hơn số ghế = phiên giữ đã mất.
                int locked = await _unitOfWork.SeatShowtimeStatuses.Query()
                    .Where(x => x.ShowtimeId == request.ShowtimeId
                             && seatIds.Contains(x.SeatId)
                             && x.TrangThai == SeatStatus.DangGiu
                             && x.ThoiGianGiu == request.HeldAt)
                    .ExecuteUpdateAsync(s => s.SetProperty(x => x.ThoiGianGiu, (DateTime?)request.HeldAt));

                if (locked != seatIds.Count)
                    return await AbortAsync("Ghế không còn được giữ cho đơn này (đã hết hạn hoặc bị nhân viên khác chiếm). Vui lòng chọn lại ghế.");

                // ---- 5. Tính lại TOÀN BỘ từ database (không tin giá / tổng tiền / trạng thái từ UI) ----
                // BuildCartAsync: suất tồn tại + chưa bắt đầu, ghế thuộc đúng suất, hold chưa hết hạn, combo tồn tại,
                // số lượng combo hợp lệ, giá ghế (giá cơ sở + phụ thu) và giá combo đều đọc lại từ DB.
                Result<CartDto> built = await _cartService.BuildCartAsync(
                    request.ShowtimeId, seatIds, request.HeldAt, request.ComboQuantities ?? new Dictionary<int, int>());
                if (!built.IsSuccess)
                    return await AbortAsync(built.ErrorMessage ?? "Không thể xác nhận đơn hàng.");

                CartDto cart = built.Data!;
                if (cart.TongTien <= 0 || cart.TongTien > PaymentConstants.MaxInvoiceTotal)
                    return await AbortAsync("Tổng tiền đơn hàng không hợp lệ.");

                // Giá trong database đã đổi so với số nhân viên đang thấy → dừng để nhân viên báo lại khách (không thu theo số cũ)
                if (request.TongTienDangHienThi.HasValue && request.TongTienDangHienThi.Value != cart.TongTien)
                    return await AbortAsync(
                        $"Giá đã thay đổi: tổng tiền hiện tại là {cart.TongTien:N0} đ (trên màn hình là {request.TongTienDangHienThi.Value:N0} đ). " +
                        "Vui lòng quay lại bước Combo, bấm Tiếp tục để cập nhật giá rồi thanh toán lại.");

                // ---- 6. Tiền khách đưa so với tổng tiền do BACKEND tính ----
                if (!CashPaymentHelper.IsEnough(cart.TongTien, request.TienKhachDua))
                    return await AbortAsync(
                        $"Tiền khách đưa chưa đủ. Tổng tiền là {cart.TongTien:N0} đ, còn thiếu {(cart.TongTien - request.TienKhachDua):N0} đ.");

                decimal change = CashPaymentHelper.CalculateChange(cart.TongTien, request.TienKhachDua);
                DateTime now = DateTime.Now;

                // ---- 7. Invoice + InvoiceCombo + Payment: cùng 1 lần SaveChanges trong transaction ----
                var invoice = new Invoice
                {
                    UserId = request.UserId,
                    CustomerId = request.CustomerId,
                    NgayLap = now,
                    TongTien = cart.TongTien,
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan,   // tiền mặt: thu tiền trực tiếp nên vào thẳng DaThanhToan
                    PhuongThuc = PaymentMethod.TienMat
                };

                foreach (CartComboItemDto line in cart.Combos)
                {
                    invoice.InvoiceCombos.Add(new InvoiceCombo
                    {
                        ComboId = line.ComboId,
                        SoLuong = line.SoLuong,
                        DonGiaLucMua = line.DonGia          // đơn giá đọc từ database trong BuildCartAsync, không phải giá UI
                    });
                }

                var payment = new Payment
                {
                    Invoice = invoice,
                    SoTien = cart.TongTien,
                    TrangThai = TransactionStatus.Success,
                    ThoiGianTao = now,
                    ThoiGianCapNhat = now
                    // Tiền mặt: không có MaGiaoDichVNPay / MaPhanHoi / NoiDungIPN
                };

                await _unitOfWork.Invoices.AddAsync(invoice);
                await _unitOfWork.Payments.AddAsync(payment);

                // Ghi để có Id hóa đơn/thanh toán. Vẫn nằm trong transaction, CHƯA commit.
                await _unitOfWork.SaveChangesAsync();

                // ---- 8. PHASE 6: tạo Vé + QR, chuyển ghế DangGiu → DaDat, vẫn trong CÙNG transaction ----
                Result<List<IssuedTicketDto>> issued;
                try
                {
                    issued = await _ticketIssuing.IssueTicketsAsync(invoice.Id, cart);
                }
                catch (DbUpdateException)
                {
                    // Vi phạm chỉ mục duy nhất (ghế đã có vé / trùng QR) → rollback tất cả, chưa thu tiền
                    return await AbortAsync(TicketIssuingService.SeatUnavailableMessage);
                }
                if (!issued.IsSuccess)
                    return await AbortAsync(issued.ErrorMessage ?? TicketIssuingService.SeatUnavailableMessage);

                // Commit MỘT LẦN: Hóa đơn + Combo + Thanh toán + Vé + ghế DaDat cùng thành công hoặc cùng rollback
                await _unitOfWork.CommitTransactionAsync();

                return Result<CheckoutResultDto>.Success(new CheckoutResultDto
                {
                    InvoiceId = invoice.Id,
                    PaymentId = payment.Id,
                    NgayLap = invoice.NgayLap,
                    CustomerId = invoice.CustomerId,
                    TongTien = cart.TongTien,
                    TienKhachDua = request.TienKhachDua,
                    TienThua = change,
                    PhuongThuc = "Tiền mặt",
                    Cart = cart,
                    Tickets = issued.Data!
                });
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        private async Task<Result<CheckoutResultDto>> AbortAsync(string message)
        {
            await _unitOfWork.RollbackTransactionAsync();
            return Result<CheckoutResultDto>.Fail(message);
        }
    }
}

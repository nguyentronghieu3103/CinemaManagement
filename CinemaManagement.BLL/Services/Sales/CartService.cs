using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Sales
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeatHoldService _seatHoldService;

        public CartService(IUnitOfWork unitOfWork, ISeatHoldService seatHoldService)
        {
            _unitOfWork = unitOfWork;
            _seatHoldService = seatHoldService;
        }

        // ================= DANH SÁCH COMBO =================
        public async Task<Result<List<ComboDto>>> GetCombosAsync()
        {
            List<ComboDto> combos = await _unitOfWork.Combos.Query()
                .AsNoTracking()
                .OrderBy(c => c.Gia).ThenBy(c => c.TenCombo)
                .Select(c => new ComboDto
                {
                    ComboId = c.Id,
                    TenCombo = c.TenCombo,
                    MoTa = c.MoTa,
                    Gia = c.Gia
                })
                .ToListAsync();

            return Result<List<ComboDto>>.Success(combos);
        }

        // ================= CHỐT GIỎ HÀNG =================
        public async Task<Result<CartDto>> BuildCartAsync(
            int showtimeId,
            IReadOnlyCollection<int> seatIds,
            DateTime heldAt,
            IReadOnlyDictionary<int, int> comboQuantities)
        {
            // 1. Phải có ghế (không cho thanh toán khi chưa chọn ghế)
            List<int> ids = (seatIds ?? Array.Empty<int>()).Distinct().ToList();
            if (ids.Count == 0)
                return Result<CartDto>.Fail("Chưa có ghế nào trong giỏ hàng. Vui lòng quay lại chọn ghế.");

            // 2. Số lượng combo hợp lệ (kiểm tra trước, không cần chạm database)
            IReadOnlyDictionary<int, int> quantities = comboQuantities ?? new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> item in quantities)
            {
                if (item.Value < CartConstants.MinComboQuantity)
                    return Result<CartDto>.Fail("Số lượng combo không được âm.");
                if (item.Value > CartConstants.MaxComboQuantity)
                    return Result<CartDto>.Fail($"Mỗi loại combo chỉ được chọn tối đa {CartConstants.MaxComboQuantity}.");
            }

            // 3. Ghế: đọc lại phiên giữ trong database + giá ghế/phụ thu tính từ database (cơ chế Phase 3)
            Result<SeatHoldDto> holdResult = await _seatHoldService.ValidateHoldAsync(showtimeId, ids, heldAt);
            if (!holdResult.IsSuccess)
                return Result<CartDto>.Fail(holdResult.ErrorMessage ?? "Ghế không còn được giữ. Vui lòng chọn lại ghế.");
            SeatHoldDto hold = holdResult.Data!;

            // 4. Combo: lấy giá từ database, không dùng giá do UI gửi
            Dictionary<int, int> wanted = quantities
                .Where(q => q.Value > 0)
                .ToDictionary(q => q.Key, q => q.Value);

            List<ComboDto> comboDtos = new();
            if (wanted.Count > 0)
            {
                List<int> comboIds = wanted.Keys.ToList();
                comboDtos = await _unitOfWork.Combos.Query()
                    .AsNoTracking()
                    .Where(c => comboIds.Contains(c.Id))
                    .OrderBy(c => c.Gia).ThenBy(c => c.TenCombo)
                    .Select(c => new ComboDto
                    {
                        ComboId = c.Id,
                        TenCombo = c.TenCombo,
                        MoTa = c.MoTa,
                        Gia = c.Gia
                    })
                    .ToListAsync();

                if (comboDtos.Count != comboIds.Count)
                    return Result<CartDto>.Fail("Có combo không còn tồn tại trong hệ thống. Danh sách combo đã được làm mới, vui lòng kiểm tra lại giỏ hàng.");
            }

            List<CartComboItemDto> lines = CartPricingHelper.BuildComboLines(comboDtos, wanted);
            decimal tongCombo = CartPricingHelper.SumComboTotal(lines);

            return Result<CartDto>.Success(new CartDto
            {
                ShowtimeId = hold.ShowtimeId,
                HeldAt = hold.HeldAt,
                ExpiresAt = hold.ExpiresAt,
                Seats = hold.Seats,
                Combos = lines,
                TongTienGhe = hold.TongTienVe,
                TongTienCombo = tongCombo,
                TongTien = hold.TongTienVe + tongCombo
            });
        }
    }
}

using CinemaManagement.Common.DTOs.Sales;

namespace CinemaManagement.Common.Helpers
{
    // Phép tính tiền combo dùng CHUNG cho UI (hiển thị realtime) và BLL (chốt giỏ hàng),
    // để hai nơi không bao giờ tính khác nhau. Helper này chỉ nhân/cộng; GIÁ luôn do database cung cấp.
    public static class CartPricingHelper
    {
        // Tạo các dòng combo từ danh sách combo (đã có giá) và số lượng đã chọn (ComboId -> SoLuong).
        // Bỏ qua combo chưa chọn (số lượng <= 0). Thứ tự dòng theo thứ tự của `combos`.
        public static List<CartComboItemDto> BuildComboLines(
            IEnumerable<ComboDto> combos,
            IReadOnlyDictionary<int, int> quantities)
        {
            var lines = new List<CartComboItemDto>();
            foreach (ComboDto combo in combos)
            {
                if (!quantities.TryGetValue(combo.ComboId, out int qty) || qty <= 0)
                    continue;

                lines.Add(new CartComboItemDto
                {
                    ComboId = combo.ComboId,
                    TenCombo = combo.TenCombo,
                    SoLuong = qty,
                    DonGia = combo.Gia,
                    ThanhTien = combo.Gia * qty
                });
            }
            return lines;
        }

        public static decimal SumComboTotal(IEnumerable<CartComboItemDto> lines)
            => lines.Sum(l => l.ThanhTien);
    }
}

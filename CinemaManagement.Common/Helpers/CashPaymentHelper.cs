namespace CinemaManagement.Common.Helpers
{
    // Phép tính tiền mặt dùng CHUNG cho UI (hiển thị realtime) và BLL (chốt thanh toán),
    // để hai nơi không bao giờ tính khác nhau. TỔNG TIỀN luôn do backend tính; helper này chỉ trừ/so sánh.
    public static class CashPaymentHelper
    {
        // Đọc số tiền VND nhân viên gõ: chấp nhận "300000", "300.000", "300,000", "300 000".
        // Từ chối: rỗng, chữ, số âm, số thập phân, số quá dài. Trả false = giá trị không hợp lệ.
        public static bool TryParseAmount(string? text, out decimal amount)
        {
            amount = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;

            string cleaned = text.Trim().Replace(".", "").Replace(",", "").Replace(" ", "");
            if (cleaned.Length == 0 || cleaned.Length > 12) return false;
            if (!cleaned.All(c => c >= '0' && c <= '9')) return false;

            amount = decimal.Parse(cleaned, System.Globalization.CultureInfo.InvariantCulture);
            return true;
        }

        // Tiền thừa = Tiền khách đưa - Tổng tiền. Âm nghĩa là còn thiếu.
        public static decimal CalculateChange(decimal total, decimal received) => received - total;

        public static bool IsEnough(decimal total, decimal received) => received >= total;
    }
}

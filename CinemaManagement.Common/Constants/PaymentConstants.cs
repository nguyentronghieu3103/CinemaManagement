namespace CinemaManagement.Common.Constants
{
    public static class PaymentConstants
    {
        // Cột HoaDon.TongTien là decimal(10,2) → tối đa 99.999.999,99. Chặn sớm để không lỗi lúc ghi database.
        public const decimal MaxInvoiceTotal = 99_999_999m;

        // Trần cho "Tiền khách đưa": chỉ để chặn nhập nhầm thừa số 0 (vd. 3000000000). Đổi số này nếu nghiệp vụ cần.
        public const decimal MaxCashReceived = 500_000_000m;

        // Độ dài tối đa theo cấu hình cột KhachHang
        public const int MaxCustomerNameLength = 150;
        public const int MaxCustomerEmailLength = 254;
    }
}

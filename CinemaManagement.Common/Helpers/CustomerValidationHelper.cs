using CinemaManagement.Common.Constants;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CinemaManagement.Common.Helpers
{
    // Validate khách hàng dùng CHUNG cho UI (báo lỗi ngay khi gõ) và BLL (kiểm tra lại trước khi ghi database).
    // DOCX M8: SĐT đúng định dạng Việt Nam (10 số, đầu 0).
    public static class CustomerValidationHelper
    {
        private static readonly Regex PhoneRegex = new(@"^0\d{9}$", RegexOptions.Compiled);

        // Bỏ khoảng trắng, dấu chấm, gạch ngang; đổi đầu +84 thành 0.
        public static string NormalizePhone(string? phone)
        {
            string p = (phone ?? string.Empty).Trim().Replace(" ", "").Replace(".", "").Replace("-", "");
            if (p.StartsWith("+84")) p = "0" + p[3..];
            return p;
        }

        public static bool IsValidPhone(string? phone) => PhoneRegex.IsMatch(NormalizePhone(phone));

        // Email không bắt buộc: rỗng là hợp lệ.
        public static bool IsValidOptionalEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            string e = email.Trim();
            if (e.Length > PaymentConstants.MaxCustomerEmailLength) return false;
            if (e.Contains(' ')) return false;
            try
            {
                var addr = new MailAddress(e);
                return addr.Address == e && addr.Host.Contains('.');
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Gộp nhiều khoảng trắng liên tiếp thành 1
        public static string NormalizeName(string? name)
            => Regex.Replace((name ?? string.Empty).Trim(), @"\s+", " ");
    }
}

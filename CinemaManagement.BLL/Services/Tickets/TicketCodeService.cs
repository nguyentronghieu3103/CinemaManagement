using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CinemaManagement.BLL.Services.Tickets
{
    public class TicketCodeService : ITicketCodeService
    {
        private static readonly Regex QrPattern = new(@"^([0-9A-F]{16})\.([0-9A-F]{8})$", RegexOptions.Compiled);
        private static readonly Regex DisplayPattern = new(@"^VE(\d{1,9})$", RegexOptions.Compiled);

        private readonly byte[] _key;

        public TicketCodeService(string secret)
        {
            if (string.IsNullOrWhiteSpace(secret) || secret.Length < 16)
                throw new InvalidOperationException("Security:QrSecret trong appsettings.json phải dài tối thiểu 16 ký tự.");
            _key = Encoding.UTF8.GetBytes(secret);
        }

        public string GenerateQrPayload()
        {
            string token = Convert.ToHexString(RandomNumberGenerator.GetBytes(8));   // 16 ký tự hex, không đoán được
            return $"{token}.{Sign(token)}";
        }

        public bool TryVerifyQrPayload(string payload)
        {
            var match = QrPattern.Match(payload);
            if (!match.Success) return false;

            string expected = Sign(match.Groups[1].Value);
            return CryptographicOperations.FixedTimeEquals(
                Encoding.ASCII.GetBytes(expected),
                Encoding.ASCII.GetBytes(match.Groups[2].Value));
        }

        public string ToDisplayCode(int ticketId) => $"VE{ticketId:D6}";

        public bool TryParseDisplayCode(string input, out int ticketId)
        {
            ticketId = 0;
            var match = DisplayPattern.Match(input);
            return match.Success && int.TryParse(match.Groups[1].Value, out ticketId);
        }

        private string Sign(string token)
        {
            using var hmac = new HMACSHA256(_key);
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(token));
            return Convert.ToHexString(hash)[..8];
        }
    }
}
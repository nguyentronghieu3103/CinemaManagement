using System.Net.Http.Headers;
using System.Net.Http.Json;
using CinemaManagement.Common.Exceptions;

namespace CinemaManagement.Integrations.Payment
{
    public class SeepayService
    {
        private readonly string _endpoint;
        private readonly string _partnerCode; // Mã đơn vị
        private readonly string _accessKey;   // API Token
        private readonly string _secretKey;
        private readonly HttpClient _httpClient;

        public SeepayService(string endpoint, string partnerCode, string accessKey, string secretKey)
        {
            _endpoint = endpoint;
            _partnerCode = partnerCode;
            _accessKey = accessKey;
            _secretKey = secretKey;
            _httpClient = new HttpClient();
        }

        // Tạo link URL ảnh mã QR VietQR thông qua chuẩn cấu trúc (không cần gọi API tốn lượt)
        // Cấu trúc VietQR thường là: https://qr.sepay.vn/img?acc={STK}&bank={Bank}&amount={Tien}&des={NoiDung}
        // Nhưng SePay có API lấy danh sách giao dịch để check xem tiền vào chưa.
        
        public async Task<string> TestConnectionAsync()
        {
            // API lấy thông tin tài khoản hoặc danh sách giao dịch
            // Dùng AccessKey (API Token) ở Header: Authorization: Bearer {AccessKey}
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessKey);
            
            // Endpoint lấy danh sách giao dịch mới nhất
            var url = "https://my.sepay.vn/userapi/transactions/list?limit=1";
            
            var response = await _httpClient.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new IntegrationException($"Lỗi kết nối SePay: {response.StatusCode} - {error}");
            }

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}

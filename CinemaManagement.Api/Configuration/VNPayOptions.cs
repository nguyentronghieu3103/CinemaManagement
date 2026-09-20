namespace CinemaManagement.Api.Configuration
{
    public class VNPayOptions
    {
        public string TmnCode { get; set; } = "";
        public string HashSecret { get; set; } = "";
        public string BaseUrl { get; set; } = "";
        public string CallbackUrl { get; set; } = "";
        public string Version { get; set; } = "";
        public string OrderType { get; set; } = "";
    }
}
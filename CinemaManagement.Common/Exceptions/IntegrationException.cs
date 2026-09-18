namespace CinemaManagement.Common.Exceptions
{
    // Dùng khi gọi API bên ngoài thất bại (VNPay, Gemini, SMTP...)
    public class IntegrationException : Exception
    {
        public IntegrationException(string message, Exception? innerException = null)
            : base(message, innerException) { }
    }
}
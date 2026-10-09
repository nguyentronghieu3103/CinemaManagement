namespace CinemaManagement.Common.Exceptions
{
    // Dùng khi gọi API bên ngoài thất bại (Seepay, Gemini, SMTP...)
    public class IntegrationException : Exception
    {
        public IntegrationException(string message, Exception? innerException = null)
            : base(message, innerException) { }
    }
}
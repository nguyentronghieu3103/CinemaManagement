namespace CinemaManagement.Common.Exceptions
{
    // Dùng khi dữ liệu nhập vào sai định dạng, vd: "Email không đúng định dạng"
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
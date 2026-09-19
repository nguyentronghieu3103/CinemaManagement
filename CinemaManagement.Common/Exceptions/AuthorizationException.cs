namespace CinemaManagement.Common.Exceptions
{
    // Dùng khi User cố thực hiện hành động không đúng quyền hạn (RBAC)
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message = "Bạn không có quyền thực hiện thao tác này.")
            : base(message) { }
    }
}
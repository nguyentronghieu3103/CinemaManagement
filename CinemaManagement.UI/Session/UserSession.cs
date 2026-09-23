using CinemaManagement.Common.DTOs.Auth;

namespace CinemaManagement.UI.Session
{
    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static string Email { get; private set; } = string.Empty;
        public static int RoleId { get; private set; }
        public static string RoleName { get; private set; } = string.Empty;
        public static bool IsLoggedIn { get; private set; }

        public static void SignIn(LoginResultDto dto)
        {
            UserId = dto.UserId;
            Email = dto.Email;
            RoleId = dto.RoleId;
            RoleName = dto.RoleName;
            IsLoggedIn = true;
        }

        public static void SignOut()
        {
            UserId = 0;
            Email = string.Empty;
            RoleId = 0;
            RoleName = string.Empty;
            IsLoggedIn = false;
        }
    }
}
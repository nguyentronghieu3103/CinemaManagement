using CinemaManagement.Common.DTOs.Auth;

namespace CinemaManagement.UI.Session
{
    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static string Email { get; private set; } = string.Empty;
        public static int RoleId { get; private set; }
        public static string RoleName { get; private set; } = string.Empty;
        public static List<string> Permissions { get; private set; } = new();
        public static bool IsLoggedIn { get; private set; }

        public static void SignIn(LoginResultDto dto)
        {
            UserId = dto.UserId;
            Email = dto.Email;
            RoleId = dto.RoleId;
            RoleName = dto.RoleName;
            Permissions = dto.Permissions;
            IsLoggedIn = true;
        }
        public static bool HasPermission(string permissionCode)   
            => Permissions.Contains(permissionCode);
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
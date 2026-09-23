using CinemaManagement.Common.Exceptions;
using CinemaManagement.UI.Session;

namespace CinemaManagement.UI.Helpers
{
    public static class PermissionGuard
    {
        public static bool HasPermission(string permissionCode)
            => UserSession.HasPermission(permissionCode);

        // Gọi hàm này ngay đầu Constructor của MỌI Form cần giới hạn quyền
        public static void EnsurePermission(string permissionCode)
        {
            if (!UserSession.HasPermission(permissionCode))
            {
                throw new AuthorizationException(
                    $"Bạn không có quyền truy cập chức năng này (yêu cầu quyền: {permissionCode}).");
            }
        }
    }
}
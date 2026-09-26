using CinemaManagement.Common.Constants;
using CinemaManagement.UI.Helpers;

public class TestGuardForm : Form
{
    public TestGuardForm()
    {
        // Yêu cầu phải có quyền Quản lý phim mới được mở
        PermissionGuard.EnsurePermission(PermissionConstants.MOVIE_MANAGE);
        Text = "Nếu thấy Form này, quyền đã cho qua";
    }
}
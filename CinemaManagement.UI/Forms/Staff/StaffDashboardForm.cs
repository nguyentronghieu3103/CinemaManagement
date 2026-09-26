using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.Common.Constants;
using CinemaManagement.UI.Helpers;
using CinemaManagement.UI.Session;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.UI.Forms.Staff
{
    public partial class StaffDashboardForm : Form
    {
        public StaffDashboardForm()
        {
            InitializeComponent();
            BuildMenu();
        }

        private void BuildMenu()
        {
            var lblWelcome = new Label
            {
                Text = $"Xin chào, {UserSession.Email} ({UserSession.RoleName})",
                AutoSize = true,
                Top = 20,
                Left = 20
            };
            Controls.Add(lblWelcome);

            int top = 60;

            // Mỗi nút chỉ thêm vào menu NẾU user có đúng quyền — đây là phần "ẩn menu"
            if (PermissionGuard.HasPermission(PermissionConstants.TICKET_SELL))
                Controls.Add(CreateMenuButton("Bán vé", top += 40));

            if (PermissionGuard.HasPermission(PermissionConstants.CHECKIN))
                Controls.Add(CreateMenuButton("Check-in vé", top += 40));

            if (PermissionGuard.HasPermission(PermissionConstants.CUSTOMER_CREATE))
                Controls.Add(CreateMenuButton("Tra cứu khách hàng", top += 40));

            var btnLogout = new Button { Text = "Đăng xuất", Top = top += 60, Left = 20 };
            btnLogout.Click += async (s, e) =>
            {
                var authService = Program.Services.GetRequiredService<IAuthService>();
                await authService.LogoutAsync(UserSession.UserId);
                UserSession.SignOut();
                new Auth.LoginForm().Show();
                this.Close();
            };
            Controls.Add(btnLogout);
            var btnTest = new Button { Text = "[TEST] Mở Form cần quyền Quản lý phim", Top = top + 60, Left = 20, Width = 300 };
            btnTest.Click += (s, e) => new TestGuardForm().Show();
            Controls.Add(btnTest);
        }

        private Button CreateMenuButton(string text, int top)
            => new Button { Text = text, Top = top, Left = 20, Width = 200 };
    }
}
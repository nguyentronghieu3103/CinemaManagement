using CinemaManagement.UI.Forms.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.UI.Forms.Staff
{
    public partial class StaffDashboardForm : Form
    {
        public StaffDashboardForm()
        {
            InitializeComponent();
            var lbl = new Label { Text = $"Xin chào, {Session.UserSession.Email} ({Session.UserSession.RoleName})", AutoSize = true, Top = 20, Left = 20 };
            var btnLogout = new Button { Text = "Đăng xuất", Top = 60, Left = 20 };
            btnLogout.Click += async (s, e) =>
            {
                var authService = Program.Services.GetRequiredService<CinemaManagement.BLL.Services.Auth.IAuthService>();
                await authService.LogoutAsync(Session.UserSession.UserId);
                Session.UserSession.SignOut();
                new LoginForm().Show();
                this.Close();
            };
            Controls.Add(lbl);
            Controls.Add(btnLogout);
        }
    }
}
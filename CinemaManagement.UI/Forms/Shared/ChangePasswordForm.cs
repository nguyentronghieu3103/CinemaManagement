using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.UI.Forms.Shared
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            btnClose.Click += (s, e) => Close();
            btnCancel.Click += (s, e) => Close();
            btnConfirm.Click += async (s, e) => await HandleChangePasswordAsync();

            btnToggleCurrent.Click += (s, e) => TogglePasswordVisibility(txtCurrentPassword, btnToggleCurrent);
            btnToggleNew.Click += (s, e) => TogglePasswordVisibility(txtNewPassword, btnToggleNew);
            btnToggleConfirm.Click += (s, e) => TogglePasswordVisibility(txtConfirmPassword, btnToggleConfirm);

            AcceptButton = btnConfirm;
            CancelButton = btnCancel;
        }

        private static void TogglePasswordVisibility(TextBox tb, PillButton btn)
        {
            if (tb.PasswordChar == '●')
            {
                tb.PasswordChar = '\0';
                btn.Text = "👁️‍🗨️";
            }
            else
            {
                tb.PasswordChar = '●';
                btn.Text = "👁";
            }
        }

        private async Task HandleChangePasswordAsync()
        {
            string current = txtCurrentPassword.Text.Trim();
            string newPwd = txtNewPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            lblStatus.ForeColor = AppColors.StatusRed;

            if (string.IsNullOrEmpty(current))
            {
                lblStatus.Text = "⚠ Vui lòng nhập mật khẩu hiện tại.";
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPwd) || newPwd.Length < 6)
            {
                lblStatus.Text = "⚠ Mật khẩu mới phải có ít nhất 6 ký tự.";
                txtNewPassword.Focus();
                return;
            }

            if (current == newPwd)
            {
                lblStatus.Text = "⚠ Mật khẩu mới không được trùng mật khẩu cũ.";
                txtNewPassword.Focus();
                return;
            }

            if (newPwd != confirm)
            {
                lblStatus.Text = "⚠ Xác nhận mật khẩu mới không khớp.";
                txtConfirmPassword.Focus();
                return;
            }

            btnConfirm.Enabled = false;
            btnConfirm.Text = "Đang xử lý...";

            try
            {
                var authService = Program.Services.GetRequiredService<IAuthService>();
                var result = await authService.ChangePasswordAsync(UserSession.UserId, current, newPwd);

                if (!result.IsSuccess)
                {
                    lblStatus.ForeColor = AppColors.StatusRed;
                    lblStatus.Text = $"⚠ {result.ErrorMessage}";
                    btnConfirm.Enabled = true;
                    btnConfirm.Text = "XÁC NHẬN ĐỔI";
                    return;
                }

                lblStatus.ForeColor = AppColors.Success;
                lblStatus.Text = "✓ Đổi mật khẩu thành công!";
                await Task.Delay(800);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                lblStatus.ForeColor = AppColors.StatusRed;
                lblStatus.Text = "⚠ Không thể đổi mật khẩu. Vui lòng thử lại sau.";
                btnConfirm.Enabled = true;
                btnConfirm.Text = "XÁC NHẬN ĐỔI";
            }
        }
    }
}

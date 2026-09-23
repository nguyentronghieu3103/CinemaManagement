using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.UI.Forms.Admin;
using CinemaManagement.UI.Forms.Staff;
using CinemaManagement.UI.Session;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CinemaManagement.UI.Forms.Auth
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblBadgeText_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            btnLogin.Enabled = false;   
            lblStatus.Text = string.Empty;

            var authService = Program.Services.GetRequiredService<IAuthService>();
            var result = await authService.LoginAsync(txtEmail.Text.Trim(), txtPassword.Text);

            btnLogin.Enabled = true;

            if (!result.IsSuccess)
            {
                lblStatus.Text = result.ErrorMessage;
                lblStatus.ForeColor = Color.Red;
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            UserSession.SignIn(result.Data!);
            Log.Information("User {Email} đăng nhập thành công với vai trò {Role}", result.Data!.Email, result.Data.RoleName);

            this.Hide();
            NavigateToMainForm(result.Data.RoleName);
        }
        private void NavigateToMainForm(string roleName)
        {
            Form mainForm = roleName switch
            {
                "NhanVienBanVe" => new StaffDashboardForm(),
                "QuanTriVien" => new AdminDashboardForm(),
                _ => throw new NotImplementedException($"Chưa có Dashboard cho vai trò: {roleName}")
            };

            mainForm.FormClosed += (s, args) => this.Close(); // đóng luôn LoginForm khi Dashboard đóng
            mainForm.Show();
        }
        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regex.IsMatch(txtEmail.Text))
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng.");
            else
                errorProvider1.SetError(txtEmail, string.Empty);
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            bool hopLe = txtPassword.Text.Length >= 8
                       && txtPassword.Text.Any(char.IsUpper)
                       && txtPassword.Text.Any(char.IsDigit);

            txtPassword.BackColor = hopLe || txtPassword.Text.Length == 0
                ? SystemColors.Window
                : Color.MistyRose;
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email.");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu.");
                valid = false;
            }
            return valid;
        }
    }
}

namespace Cinema.WinForms.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActiveControl = txtUsername;
        }

        private void CredentialFrame_Enter(object? sender, EventArgs e)
        {
            if (sender is Panel frame)
            {
                frame.BackColor = btnLogin.BackColor;
            }
        }

        private void CredentialFrame_Leave(object? sender, EventArgs e)
        {
            if (sender is Panel frame)
            {
                frame.BackColor = Color.FromArgb(203, 213, 225);
            }
        }

        private void InputSurface_Click(object? sender, EventArgs e)
        {
            if (sender is Panel surface && surface.GetNextControl(null, true) is TextBox input)
            {
                input.Focus();
            }
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            bool missingUsername = username.Length == 0;
            bool missingPassword = password.Length == 0;

            string usernameError = missingUsername ? "Vui lòng nhập tên đăng nhập." : string.Empty;
            string passwordError = missingPassword ? "Vui lòng nhập mật khẩu." : string.Empty;
            loginErrors.SetError(pnlUsername, usernameError);
            loginErrors.SetError(pnlPassword, passwordError);

            if (missingUsername || missingPassword)
            {
                lblError.Text = missingUsername ? usernameError : passwordError;
                (missingUsername ? txtUsername : txtPassword).Focus();
                return;
            }

            // Call the authentication API here when it becomes available.
            lblError.Text = "Chức năng đăng nhập chưa được kết nối.";
        }

        private void Credentials_TextChanged(object? sender, EventArgs e)
        {
            if (sender is TextBox { Parent.Parent: Panel frame })
            {
                loginErrors.SetError(frame, string.Empty);
                lblError.Text = string.Empty;
            }
        }

        private void BtnTogglePassword_Click(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "Hiện" : "Ẩn";
            btnTogglePassword.AccessibleName = txtPassword.UseSystemPasswordChar ? "Hiện mật khẩu" : "Ẩn mật khẩu";
        }

        private void LnkForgotPassword_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open ForgotPasswordForm here when the recovery flow is available.
            lblError.Text = "Chức năng quên mật khẩu chưa được kết nối.";
        }

        private void BtnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}

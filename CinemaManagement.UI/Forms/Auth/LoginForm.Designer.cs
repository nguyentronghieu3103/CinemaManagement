using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Auth
{
    // Giao diện đăng nhập được dựng bằng code trong LoginForm.UI.cs (BuildUi).
    // File này chỉ khai báo các control và dọn dẹp tài nguyên.
    partial class LoginForm
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private PictureBox pictureBox1 = null!;
        private Label lblBadgeText = null!;
        private CardPanel panel1 = null!;
        private Label lblPasswordCaption = null!;
        private Label lblEmailCaption = null!;
        private Label lblTitle = null!;
        private TextBox txtPassword = null!;
        private TextBox txtEmail = null!;
        private PillButton btnTogglePassword = null!;
        private PillButton btnLogin = null!;
        private LinkLabel lnkForgotPassword = null!;
        private Label lblStatus = null!;
        private ErrorProvider errorProvider1 = null!;
    }
}

namespace Cinema.WinForms.Forms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                picLogo?.Image?.Dispose();
                pnlBrand?.BackgroundImage?.Dispose();
                BackgroundImage?.Dispose();
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlLogin = new Panel();
            pnlBrand = new Panel();
            picLogo = new PictureBox();
            lblTitle = new Label();
            lblUsername = new Label();
            pnlUsername = new Panel();
            pnlUsernameSurface = new Panel();
            txtUsername = new TextBox();
            lblPassword = new Label();
            pnlPassword = new Panel();
            pnlPasswordSurface = new Panel();
            txtPassword = new TextBox();
            btnTogglePassword = new Button();
            lnkForgotPassword = new LinkLabel();
            lblError = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            loginErrors = new ErrorProvider(components);
            pnlLogin.SuspendLayout();
            pnlBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlUsername.SuspendLayout();
            pnlUsernameSurface.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlPasswordSurface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loginErrors).BeginInit();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(pnlBrand);
            pnlLogin.Controls.Add(lblTitle);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(pnlUsername);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(pnlPassword);
            pnlLogin.Controls.Add(btnTogglePassword);
            pnlLogin.Controls.Add(lnkForgotPassword);
            pnlLogin.Controls.Add(lblError);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(btnExit);
            pnlLogin.Location = new Point(32, 22);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(416, 470);
            pnlLogin.TabIndex = 0;
            // 
            // pnlBrand
            // 
            pnlBrand.BackColor = Color.FromArgb(255, 247, 234);
            pnlBrand.BackgroundImage = (Image)resources.GetObject("pnlBrand.BackgroundImage");
            pnlBrand.BackgroundImageLayout = ImageLayout.Stretch;
            pnlBrand.Controls.Add(picLogo);
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(416, 146);
            pnlBrand.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.AccessibleName = "Logo STORYLINE";
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(126, 10);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(164, 116);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblTitle.Location = new Point(28, 149);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 49);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Đăng nhập hệ thống";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI Semibold", 10F);
            lblUsername.Location = new Point(28, 222);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(360, 20);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Tên đăng nhập";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlUsername
            // 
            pnlUsername.BackColor = Color.FromArgb(203, 213, 225);
            pnlUsername.Controls.Add(pnlUsernameSurface);
            loginErrors.SetIconAlignment(pnlUsername, ErrorIconAlignment.MiddleLeft);
            loginErrors.SetIconPadding(pnlUsername, 4);
            pnlUsername.Location = new Point(28, 244);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Padding = new Padding(1);
            pnlUsername.Size = new Size(360, 36);
            pnlUsername.TabIndex = 4;
            pnlUsername.Enter += CredentialFrame_Enter;
            pnlUsername.Leave += CredentialFrame_Leave;
            // 
            // pnlUsernameSurface
            // 
            pnlUsernameSurface.BackColor = Color.White;
            pnlUsernameSurface.Controls.Add(txtUsername);
            pnlUsernameSurface.Dock = DockStyle.Fill;
            pnlUsernameSurface.Location = new Point(1, 1);
            pnlUsernameSurface.Name = "pnlUsernameSurface";
            pnlUsernameSurface.Size = new Size(358, 34);
            pnlUsernameSurface.TabIndex = 0;
            pnlUsernameSurface.Click += InputSurface_Click;
            // 
            // txtUsername
            // 
            txtUsername.AccessibleName = "Tên đăng nhập";
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(9, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(340, 23);
            txtUsername.TabIndex = 0;
            txtUsername.TextChanged += Credentials_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI Semibold", 10F);
            lblPassword.Location = new Point(28, 290);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(360, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Mật khẩu";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.FromArgb(203, 213, 225);
            pnlPassword.Controls.Add(pnlPasswordSurface);
            loginErrors.SetIconAlignment(pnlPassword, ErrorIconAlignment.MiddleLeft);
            loginErrors.SetIconPadding(pnlPassword, 4);
            pnlPassword.Location = new Point(28, 312);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Padding = new Padding(1);
            pnlPassword.Size = new Size(288, 36);
            pnlPassword.TabIndex = 6;
            pnlPassword.Enter += CredentialFrame_Enter;
            pnlPassword.Leave += CredentialFrame_Leave;
            // 
            // pnlPasswordSurface
            // 
            pnlPasswordSurface.BackColor = Color.White;
            pnlPasswordSurface.Controls.Add(txtPassword);
            pnlPasswordSurface.Dock = DockStyle.Fill;
            pnlPasswordSurface.Location = new Point(1, 1);
            pnlPasswordSurface.Name = "pnlPasswordSurface";
            pnlPasswordSurface.Size = new Size(286, 34);
            pnlPasswordSurface.TabIndex = 0;
            pnlPasswordSurface.Click += InputSurface_Click;
            // 
            // txtPassword
            // 
            txtPassword.AccessibleName = "Mật khẩu";
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.Location = new Point(9, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(268, 23);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += Credentials_TextChanged;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.AccessibleName = "Hiện mật khẩu";
            btnTogglePassword.BackColor = Color.FromArgb(248, 250, 252);
            btnTogglePassword.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnTogglePassword.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Location = new Point(324, 312);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(64, 36);
            btnTogglePassword.TabIndex = 7;
            btnTogglePassword.Text = "Hiện";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += BtnTogglePassword_Click;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.ActiveLinkColor = Color.FromArgb(37, 99, 235);
            lnkForgotPassword.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkForgotPassword.LinkColor = Color.FromArgb(37, 99, 235);
            lnkForgotPassword.Location = new Point(228, 352);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(160, 22);
            lnkForgotPassword.TabIndex = 8;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Quên mật khẩu?";
            lnkForgotPassword.TextAlign = ContentAlignment.MiddleRight;
            lnkForgotPassword.LinkClicked += LnkForgotPassword_LinkClicked;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.FromArgb(185, 28, 28);
            lblError.Location = new Point(28, 376);
            lblError.Name = "lblError";
            lblError.Size = new Size(360, 26);
            lblError.TabIndex = 9;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 64, 175);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(28, 411);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(244, 40);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.White;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(284, 411);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(104, 40);
            btnExit.TabIndex = 11;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // loginErrors
            // 
            loginErrors.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            loginErrors.ContainerControl = this;
            // 
            // Form1
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnExit;
            ClientSize = new Size(487, 529);
            Controls.Add(pnlLogin);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(15, 23, 42);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - STORYLINE";
            pnlLogin.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlUsername.ResumeLayout(false);
            pnlUsernameSurface.ResumeLayout(false);
            pnlUsernameSurface.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPasswordSurface.ResumeLayout(false);
            pnlPasswordSurface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loginErrors).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Panel pnlBrand;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblUsername;
        private Panel pnlUsername;
        private Panel pnlUsernameSurface;
        private TextBox txtUsername;
        private Label lblPassword;
        private Panel pnlPassword;
        private Panel pnlPasswordSurface;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private LinkLabel lnkForgotPassword;
        private Label lblError;
        private Button btnLogin;
        private Button btnExit;
        private ErrorProvider loginErrors;
    }
}

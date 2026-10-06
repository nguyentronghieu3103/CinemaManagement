using CinemaManagement.UI.Theme;
using System.Drawing.Drawing2D;

namespace CinemaManagement.UI.Forms.Auth
{
    public partial class LoginForm
    {
        private void BuildUi()
        {
            components = new System.ComponentModel.Container();
            SuspendLayout();

            Text = "Storyline Cinema — Đăng nhập";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(this.S(440), this.S(716));
            BackColor = AppColors.PageBackground;
            Font = new Font("Segoe UI", 10F);
            DoubleBuffered = true;

            // khung gốc: nền đen/navy + glow điện ảnh (đỏ bên trái, xanh/tím bên phải), trôi cực chậm
            var stage = new CinemaBackdropPanel { Dock = DockStyle.Fill, Animate = true };
            stage.Overlay = (g, r) =>
            {
                float w = r.Width, h = r.Height;
                UiKit.FillGlow(g, new RectangleF(-w * 0.55f, h * 0.05f, w * 1.1f, h * 0.75f), AppColors.Primary, 96);
                UiKit.FillGlow(g, new RectangleF(w * 0.45f, h * 0.05f, w * 1.1f, h * 0.75f), AppColors.Blue, 84);
                UiKit.FillGlow(g, new RectangleF(w * 0.55f, h * 0.45f, w * 0.9f, h * 0.7f), AppColors.Purple, 70);
                UiKit.FillGlow(g, new RectangleF(w * 0.18f, h * 0.0f, w * 0.64f, h * 0.30f), AppColors.Primary, 60);
            };

            // ----- logo + tên thương hiệu (nằm trên nền gradient) -----
            int logoSize = this.S(98);
            pictureBox1 = new PictureBox
            {
                Image = UiKit.CreateLogoBitmap(logoSize),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Size = new Size(logoSize, logoSize),
                Left = (ClientSize.Width - logoSize) / 2,
                Top = this.S(34) + (this.S(128) - logoSize) / 2,
                TabStop = false
            };
            lblBadgeText = new Label
            {
                Text = "STORYLINE CINEMA",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                Left = 0,
                Top = this.S(176),
                Width = ClientSize.Width,
                Height = this.S(40)
            };
            var lblTagline = new Label
            {
                Text = "Hệ thống bán vé tại quầy",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 11F),
                Left = 0,
                Top = this.S(216),
                Width = ClientSize.Width,
                Height = this.S(28)
            };

            // ----- thẻ đăng nhập -----
            int cardW = this.S(360);
            panel1 = new CardPanel
            {
                Left = (ClientSize.Width - cardW) / 2,
                Top = this.S(262),
                Width = cardW,
                Height = this.S(396),
                Radius = 20,
                AccentColor = AppColors.Primary
            };

            lblTitle = new Label
            {
                Text = "Đăng nhập",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextDark,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Left = this.S(28),
                Top = this.S(22)
            };
            var lblHint = new Label
            {
                Text = "Dùng tài khoản được cấp để bắt đầu ca làm việc",
                AutoSize = false,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                Left = this.S(28),
                Top = this.S(64),
                Width = this.S(304),
                Height = this.S(24)
            };

            lblEmailCaption = MakeCaption("EMAIL", 102);
            txtEmail = new TextBox { PlaceholderText = "ten@storyline.vn" };
            var wrapEmail = MakeInput(txtEmail, 124);

            lblPasswordCaption = MakeCaption("MẬT KHẨU", 182);
            txtPassword = new TextBox { PasswordChar = '●', PlaceholderText = "Nhập mật khẩu" };
            var wrapPassword = MakeInput(txtPassword, 204, trailingSpace: this.S(44));

            btnTogglePassword = new PillButton
            {
                Text = "👁️",
                GhostStyle = true,
                Radius = 8,
                NormalColor = AppColors.InputBackground,
                HoverColor = AppColors.Surface2,
                ForeColor = AppColors.TextMuted,
                Bold = false,
                Font = new Font("Segoe UI Emoji", 11F),
                Size = new Size(this.S(36), this.S(34)),
                Left = wrapPassword.Width - this.S(44),
                Top = (wrapPassword.Height - this.S(34)) / 2,
                TabStop = false
            };
            wrapPassword.Controls.Add(btnTogglePassword);

            lblStatus = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                ForeColor = AppColors.StatusRed,
                Font = new Font("Segoe UI", 9.5F),
                Left = this.S(28),
                Top = this.S(260),
                Width = this.S(304),
                Height = this.S(22)
            };

            btnLogin = new PillButton
            {
                Text = "ĐĂNG NHẬP  →",
                NormalColor = AppColors.Primary,
                ForeColor = Color.White,
                Radius = 14,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Left = this.S(28),
                Top = this.S(288),
                Width = this.S(304),
                Height = this.S(52)
            };

            lnkForgotPassword = new LinkLabel
            {
                Text = "Quên mật khẩu?",
                AutoSize = true,
                BackColor = Color.Transparent,
                LinkColor = AppColors.PrimaryHover,
                ActiveLinkColor = AppColors.Primary,
                LinkBehavior = LinkBehavior.HoverUnderline,
                Font = new Font("Segoe UI", 10F),
                TabStop = true
            };
            lnkForgotPassword.Top = this.S(354);
            lnkForgotPassword.Left = (cardW - lnkForgotPassword.PreferredWidth) / 2;

            panel1.Controls.AddRange(new Control[]
            {
                lblTitle, lblHint, lblEmailCaption, wrapEmail, lblPasswordCaption, wrapPassword,
                lblStatus, btnLogin, lnkForgotPassword
            });

            var lblFooter = new Label
            {
                Text = "© Storyline Cinema",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9F),
                Left = 0,
                Top = this.S(676),
                Width = ClientSize.Width,
                Height = this.S(24)
            };

            errorProvider1 = new ErrorProvider(components)
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            stage.Controls.AddRange(new Control[] { lblFooter, panel1, lblTagline, lblBadgeText, pictureBox1 });
            Controls.Add(stage);

            // ----- sự kiện -----
            btnLogin.Click += btnLogin_Click;
            btnTogglePassword.Click += btnTogglePassword_Click;
            txtEmail.Validating += txtEmail_Validating;
            txtPassword.TextChanged += txtPassword_TextChanged;
            Load += LoginForm_Load;
            AcceptButton = btnLogin;      // Enter = đăng nhập

            ResumeLayout(false);
            PerformLayout();
        }

        private Label MakeCaption(string text, int top) => new()
        {
            Text = text,
            AutoSize = true,
            BackColor = Color.Transparent,
            ForeColor = AppColors.TextMuted,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            Left = this.S(30),
            Top = this.S(top)
        };

        // Ô nhập bo tròn: TextBox không viền nằm trong một thẻ, đổi viền đỏ khi đang gõ.
        private CardPanel MakeInput(TextBox tb, int top, int trailingSpace = 0)
        {
            var wrap = new CardPanel
            {
                Left = this.S(28),
                Top = this.S(top),
                Width = this.S(304),
                Height = this.S(48),
                Radius = 12,
                ShowShadow = false,
                FillColor = AppColors.InputBackground,
                BorderColor = AppColors.BorderStrong
            };

            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = AppColors.InputBackground;
            tb.ForeColor = AppColors.TextDark;
            tb.Font = new Font("Segoe UI", 11.5F);
            tb.Left = this.S(14);
            tb.Width = wrap.Width - this.S(28) - trailingSpace;
            tb.Top = (wrap.Height - tb.PreferredHeight) / 2;

            tb.Enter += (s, e) => { wrap.BorderColor = AppColors.Primary; wrap.Invalidate(); };
            tb.Leave += (s, e) => { wrap.BorderColor = AppColors.BorderStrong; wrap.Invalidate(); };
            wrap.Click += (s, e) => tb.Focus();

            wrap.Controls.Add(tb);
            return wrap;
        }
    }
}

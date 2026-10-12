using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Shared
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null!;
        private CardPanel cardMain = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private PillButton btnClose = null!;

        private Label lblCurrentCaption = null!;
        private CardPanel wrapCurrentPassword = null!;
        private TextBox txtCurrentPassword = null!;
        private PillButton btnToggleCurrent = null!;

        private Label lblNewCaption = null!;
        private CardPanel wrapNewPassword = null!;
        private TextBox txtNewPassword = null!;
        private PillButton btnToggleNew = null!;

        private Label lblConfirmCaption = null!;
        private CardPanel wrapConfirmPassword = null!;
        private TextBox txtConfirmPassword = null!;
        private PillButton btnToggleConfirm = null!;

        private Label lblStatus = null!;
        private PillButton btnCancel = null!;
        private PillButton btnConfirm = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(this.S(480), this.S(510));
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = AppColors.PageBackground;
            Padding = new Padding(this.S(2));
            ShowInTaskbar = false;
            DoubleBuffered = true;

            cardMain = new CardPanel
            {
                Dock = DockStyle.Fill,
                Radius = 16,
                ShowShadow = false,
                FillColor = AppColors.CardBackground,
                BorderColor = AppColors.Border,
                Padding = new Padding(this.S(28), this.S(20), this.S(28), this.S(20))
            };

            lblTitle = new Label
            {
                Text = "🔒  ĐỔI MẬT KHẨU",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(this.S(28), this.S(20))
            };

            lblSubtitle = new Label
            {
                Text = "Cập nhật mật khẩu định kỳ để bảo vệ tài khoản",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(this.S(28), this.S(50))
            };

            btnClose = new PillButton
            {
                Text = "✕",
                GhostStyle = true,
                Radius = 14,
                NormalColor = Color.Transparent,
                HoverColor = AppColors.Surface2,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Size = new Size(this.S(32), this.S(32)),
                Location = new Point(ClientSize.Width - this.S(48), this.S(18)),
                TabStop = false
            };

            int curY = this.S(86);
            int inputH = this.S(42);
            int inputW = ClientSize.Width - this.S(56);

            // 1. Mật khẩu hiện tại
            lblCurrentCaption = MakeCaption("MẬT KHẨU HIỆN TẠI *", curY);
            curY += this.S(22);
            (wrapCurrentPassword, txtCurrentPassword, btnToggleCurrent) = MakePasswordField(curY, inputW, inputH);
            curY += inputH + this.S(14);

            // 2. Mật khẩu mới
            lblNewCaption = MakeCaption("MẬT KHẨU MỚI *", curY);
            curY += this.S(22);
            (wrapNewPassword, txtNewPassword, btnToggleNew) = MakePasswordField(curY, inputW, inputH);
            curY += inputH + this.S(14);

            // 3. Xác nhận mật khẩu mới
            lblConfirmCaption = MakeCaption("XÁC NHẬN MẬT KHẨU MỚI *", curY);
            curY += this.S(22);
            (wrapConfirmPassword, txtConfirmPassword, btnToggleConfirm) = MakePasswordField(curY, inputW, inputH);
            curY += inputH + this.S(8);

            // Dòng thông báo trạng thái / lỗi
            lblStatus = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                ForeColor = AppColors.StatusRed,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(this.S(28), curY),
                Size = new Size(inputW, this.S(24)),
                TextAlign = ContentAlignment.MiddleLeft
            };
            curY += this.S(32);

            // Dãy nút thao tác
            btnCancel = new PillButton
            {
                Text = "HỦY",
                Radius = 10,
                NormalColor = ColorTranslator.FromHtml("#25202C"),
                HoverColor = UiKit.Blend(ColorTranslator.FromHtml("#25202C"), AppColors.Border, 0.3f),
                BorderColor = ColorTranslator.FromHtml("#44394A"),
                ForeColor = ColorTranslator.FromHtml("#D5CDD3"),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(100), this.S(42)),
                Location = new Point(ClientSize.Width - this.S(28) - this.S(160) - this.S(10) - this.S(100), curY)
            };

            btnConfirm = new PillButton
            {
                Text = "XÁC NHẬN ĐỔI",
                Radius = 10,
                NormalColor = AppColors.Primary,
                HoverColor = AppColors.PrimaryHover,
                PressedColor = AppColors.PrimaryPressed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(160), this.S(42)),
                Location = new Point(ClientSize.Width - this.S(28) - this.S(160), curY)
            };

            cardMain.Controls.AddRange(new Control[]
            {
                lblTitle, lblSubtitle, btnClose,
                lblCurrentCaption, wrapCurrentPassword,
                lblNewCaption, wrapNewPassword,
                lblConfirmCaption, wrapConfirmPassword,
                lblStatus, btnCancel, btnConfirm
            });

            Controls.Add(cardMain);
            ResumeLayout(false);
        }

        private Label MakeCaption(string text, int top) => new()
        {
            Text = text,
            AutoSize = true,
            BackColor = Color.Transparent,
            ForeColor = AppColors.TextSecondary,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            Location = new Point(this.S(28), top)
        };

        private (CardPanel wrap, TextBox tb, PillButton btnEye) MakePasswordField(int top, int width, int height)
        {
            var wrap = new CardPanel
            {
                Location = new Point(this.S(28), top),
                Size = new Size(width, height),
                Radius = 10,
                ShowShadow = false,
                FillColor = ColorTranslator.FromHtml("#211B27"),
                BorderColor = ColorTranslator.FromHtml("#453846"),
                Padding = Padding.Empty
            };

            var tb = new TextBox
            {
                PasswordChar = '●',
                BorderStyle = BorderStyle.None,
                BackColor = ColorTranslator.FromHtml("#211B27"),
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 10.5F),
                Location = new Point(this.S(12), (height - this.S(20)) / 2),
                Width = width - this.S(50)
            };

            var btnEye = new PillButton
            {
                Text = "👁",
                GhostStyle = true,
                Radius = 8,
                NormalColor = Color.Transparent,
                HoverColor = AppColors.Surface2,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI Emoji", 10F),
                Size = new Size(this.S(32), height - this.S(6)),
                Location = new Point(width - this.S(36), this.S(3)),
                TabStop = false
            };

            tb.Enter += (s, e) => { wrap.BorderColor = AppColors.Primary; wrap.Invalidate(); };
            tb.Leave += (s, e) => { wrap.BorderColor = ColorTranslator.FromHtml("#453846"); wrap.Invalidate(); };
            wrap.Click += (s, e) => tb.Focus();

            wrap.Controls.Add(tb);
            wrap.Controls.Add(btnEye);

            return (wrap, tb, btnEye);
        }
    }
}


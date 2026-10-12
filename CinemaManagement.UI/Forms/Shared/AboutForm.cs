using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Shared
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(this.S(420), this.S(280));
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = AppColors.PageBackground;
            Padding = new Padding(this.S(2));
            ShowInTaskbar = false;

            var card = new CardPanel
            {
                Dock = DockStyle.Fill,
                Radius = 16,
                ShowShadow = false,
                FillColor = AppColors.CardBackground,
                BorderColor = AppColors.Border,
                Padding = new Padding(this.S(24))
            };

            var lblTitle = new Label
            {
                Text = "🎬 STORYLINE CINEMA",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(this.S(24), this.S(24))
            };

            var lblSubtitle = new Label
            {
                Text = "Hệ thống quản lý cụm rạp chiếu phim hiện đại",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(this.S(24), this.S(58))
            };

            var lblVersion = new Label
            {
                Text = "Phiên bản: 1.0.0 (Release 2026)\nNền tảng: .NET 10 Windows Forms (x64)\nCơ sở dữ liệu: PostgreSQL\nThiết kế giao diện: Dark Cinema Premium (Noir & Champagne)",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(this.S(24), this.S(96))
            };

            var btnClose = new PillButton
            {
                Text = "ĐÓNG",
                Radius = 10,
                NormalColor = AppColors.Surface2,
                HoverColor = UiKit.Blend(AppColors.Surface2, AppColors.Primary, 0.3f),
                BorderColor = AppColors.Border,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Size = new Size(this.S(90), this.S(36)),
                Location = new Point(ClientSize.Width - this.S(24) - this.S(90), ClientSize.Height - this.S(24) - this.S(36))
            };
            btnClose.Click += (s, e) => Close();

            card.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, lblVersion, btnClose });
            Controls.Add(card);

            ResumeLayout(false);
        }
    }
}


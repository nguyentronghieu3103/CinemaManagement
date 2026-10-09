using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Admin
{
    // Trang quản trị mới chỉ là khung chờ: banner chào mừng + thông báo chức năng đang phát triển.
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
            Text = "Storyline Cinema — Quản trị";
            StartPosition = FormStartPosition.CenterScreen;
            var work = Screen.FromPoint(Cursor.Position).WorkingArea;
            ClientSize = new Size(Math.Min(this.S(1100), work.Width - this.S(60)),
                                  Math.Min(this.S(680), work.Height - this.S(100)));
            BackColor = AppColors.PageBackground;
            Font = new Font("Segoe UI", 10F);

            var body = new CinemaBackdropPanel
            {
                Dock = DockStyle.Fill,
                Animate = true,
                Padding = new Padding(this.S(32), this.S(28), this.S(32), this.S(28))
            };

            var hero = new GradientPanel { Dock = DockStyle.Top, Height = this.S(124), Radius = 20 };
            hero.Controls.Add(new Label
            {
                Text = $"Xin chào, {UserSession.HoTen} 👋",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 21F, FontStyle.Bold),
                Left = this.S(32),
                Top = this.S(22)
            });
            hero.Controls.Add(new Label
            {
                Text = "Khu vực dành cho Quản trị viên hệ thống",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 11.5F),
                Left = this.S(34),
                Top = this.S(72)
            });

            var card = new CardPanel
            {
                Dock = DockStyle.Fill,
                AccentColor = AppColors.Primary,
                Padding = new Padding(this.S(24), this.S(24), this.S(29), this.S(29))
            };
            card.Controls.Add(new Label
            {
                Text = "🛠  Các chức năng quản trị (phim, suất chiếu, nhân viên, báo cáo…) đang được phát triển.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 13F)
            });

            body.Controls.Add(card);
            body.Controls.Add(new Panel { Dock = DockStyle.Top, Height = this.S(18), BackColor = Color.Transparent });
            body.Controls.Add(hero);
            Controls.Add(body);
        }
    }
}

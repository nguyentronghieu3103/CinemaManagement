using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace CinemaManagement.UI.UserControls.Common
{
    // Thanh menu trên cùng dùng chung cho mọi màn của nhân viên.
    // Giữ nguyên API cũ: ActivePage, NavigateRequested, LogoutRequested.
    public class StaffHeaderControl : UserControl, IBackdropPainter
    {
        private readonly Dictionary<StaffPage, PillButton> _navButtons = new();
        private readonly PillButton _btnUser;
        private StaffPage _activePage = StaffPage.Home;
        private readonly Bitmap _logo;
        private readonly int _brandWidth;

        public event Action<StaffPage>? NavigateRequested;
        public event Action? LogoutRequested;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StaffPage ActivePage
        {
            get => _activePage;
            set { _activePage = value; HighlightActive(); }
        }

        public StaffHeaderControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Dock = DockStyle.Top;
            Height = this.S(72);
            BackColor = AppColors.HeaderBackground;

            _logo = UiKit.CreateLogoBitmap(this.S(44));
            using (var f = new Font("Segoe UI", 14F, FontStyle.Bold))
                _brandWidth = TextRenderer.MeasureText("CINEMA", f).Width;

            foreach (var (page, text) in new[]
            {
                (StaffPage.Home, "🏠  Trang chủ"),
                (StaffPage.Booking, "🎟  Bán vé"),
                (StaffPage.CheckIn, "✅  Check-in"),
                (StaffPage.Lookup, "🔍  Tra cứu vé")
            })
            {
                var btn = CreateNavButton(text);
                btn.Click += (s, e) => { if (page != _activePage) NavigateRequested?.Invoke(page); };
                _navButtons[page] = btn;
                Controls.Add(btn);
            }

            _btnUser = new PillButton
            {
                Text = $"{UserSession.HoTen}  ▾",
                GhostStyle = false,
                NormalColor = AppColors.Surface2,
                HoverColor = UiKit.Blend(AppColors.Surface2, AppColors.Primary, 0.28f),
                BorderColor = AppColors.Border,
                ForeColor = AppColors.TextPrimary,
                Radius = 22,
                Height = this.S(44),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Padding = new Padding(this.S(44), 0, 0, 0)     // chừa chỗ cho avatar tròn bên trái
            };
            _btnUser.Width = Math.Max(this.S(190),
                TextRenderer.MeasureText(_btnUser.Text, _btnUser.Font).Width + this.S(64));
            _btnUser.Click += ShowUserMenu;
            Controls.Add(_btnUser);

            HighlightActive();
            LayoutItems();
        }

        private PillButton CreateNavButton(string text)
        {
            var btn = new PillButton
            {
                Text = text,
                GhostStyle = true,
                Radius = 20,
                Height = this.S(42),
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                NormalColor = Color.FromArgb(0, 0, 0, 0),
                HoverColor = HoverTint,
                PressedColor = Color.FromArgb(110, AppColors.Primary)
            };
            btn.Width = TextRenderer.MeasureText(text, btn.Font).Width + this.S(40);
            return btn;
        }

        private void LayoutItems()
        {
            int x = this.S(20) + this.S(44) + this.S(12);
            // chừa chỗ cho logo + tên thương hiệu
            x += _brandWidth + this.S(30);
            int top = (Height - this.S(42)) / 2;
            foreach (var btn in _navButtons.Values)
            {
                btn.Left = x;
                btn.Top = top;
                x += btn.Width + this.S(6);
            }
            _btnUser.Top = (Height - _btnUser.Height) / 2;
            _btnUser.Left = Width - _btnUser.Width - this.S(20);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_btnUser != null) LayoutItems();
        }

        private void HighlightActive()
        {
            foreach (var (page, btn) in _navButtons)
            {
                bool active = page == _activePage;
                btn.GhostStyle = !active;
                btn.NormalColor = active ? AppColors.Primary : Color.FromArgb(0, 0, 0, 0);
                btn.HoverColor = active ? AppColors.PrimaryHover : HoverTint;
                btn.ForeColor = active ? Color.White : AppColors.TextSecondary;
                btn.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e) => PaintBackdrop(e.Graphics, Point.Empty);

        // Vẽ toàn bộ nền header (gradient, logo, tên, avatar). Các nút bên trong gọi lại hàm này
        // để lấy đúng phần nền phía sau mình. "origin" là góc trên-trái của vùng đang vẽ (toạ độ header).
        // Hình khối vẽ bằng Graphics nên dùng TranslateTransform; chữ vẽ bằng TextRenderer (GDI)
        // không theo transform nên phải tự trừ origin.
        public void PaintBackdrop(Graphics g, Point origin)
        {
            UiKit.HighQuality(g);

            int size = this.S(44);
            var logoRect = new Rectangle(this.S(20), (Height - size) / 2 - this.S(1), size, size);
            int av = this.S(34);
            var avRect = new Rectangle(_btnUser.Left + this.S(6), _btnUser.Top + (_btnUser.Height - av) / 2, av, av);

            var state = g.Save();
            g.TranslateTransform(-origin.X, -origin.Y);
            g.SetClip(ClientRectangle);

            // nền tối gần như trong suốt: navy → đen + glow đỏ/tím bên trái, xanh bên phải
            using (var lg = new LinearGradientBrush(ClientRectangle, AppColors.HeaderBackground, AppColors.HeaderDark, 0f))
                g.FillRectangle(lg, ClientRectangle);
            UiKit.FillGlow(g, new RectangleF(-this.S(160), -Height * 1.2f, this.S(520), Height * 3.2f), AppColors.Primary, 58);
            UiKit.FillGlow(g, new RectangleF(this.S(240), -Height * 1.4f, this.S(420), Height * 3.0f), AppColors.Purple, 30);
            UiKit.FillGlow(g, new RectangleF(Width - this.S(420), -Height * 1.4f, this.S(520), Height * 3.2f), AppColors.Blue, 48);

            // đường kẻ mảnh dưới header
            using (var line = new SolidBrush(AppColors.Border))
                g.FillRectangle(line, 0, Height - 1, Width, 1);

            // logo CINEMA (vẽ bằng code) + vầng sáng đỏ phía sau
            UiKit.FillGlow(g, RectangleF.Inflate(logoRect, this.S(16), this.S(16)), AppColors.Primary, 70);
            g.DrawImage(_logo, logoRect);

            // avatar tròn (phần hình): gradient đỏ → đỏ tối
            using (var lg = new LinearGradientBrush(avRect, AppColors.PrimaryHover, AppColors.DarkRed, 45f))
                g.FillEllipse(lg, avRect);

            g.Restore(state);

            // ----- chữ: TextRenderer không theo transform nên trừ origin thủ công -----
            using var brand = new Font("Segoe UI", 14F, FontStyle.Bold);
            TextRenderer.DrawText(g, "CINEMA", brand,
                new Point(logoRect.Right + this.S(12) - origin.X, (Height - brand.Height) / 2 - this.S(1) - origin.Y),
                AppColors.TextPrimary);

            using var avFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            var avText = new Rectangle(avRect.X - origin.X, avRect.Y - origin.Y, avRect.Width, avRect.Height);
            TextRenderer.DrawText(g, UiKit.Initials(UserSession.HoTen), avFont, avText, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }

        private void ShowUserMenu(object? sender, EventArgs e)
        {
            var menu = new ContextMenuStrip
            {
                Font = new Font("Segoe UI", 10.5F),
                ShowImageMargin = false
            };
            UiKit.StyleMenu(menu);
            menu.Items.Add("🔑  Đổi mật khẩu", null, (_, _) => MessageBox.Show("Chức năng này chưa được xây dựng.", "Thông báo"));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("🚪  Đăng xuất", null, (_, _) => LogoutRequested?.Invoke());
            menu.Show(_btnUser, new Point(0, _btnUser.Height + this.S(4)));
        }

        // hover của nút điều hướng: đỏ/tím nhẹ
        private static readonly Color HoverTint = Color.FromArgb(80, UiKit.Blend(AppColors.Primary, AppColors.Purple, 0.5f));

        protected override void Dispose(bool disposing)
        {
            if (disposing) _logo.Dispose();
            base.Dispose(disposing);
        }
    }
}

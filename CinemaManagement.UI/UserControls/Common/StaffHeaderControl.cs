using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using System.ComponentModel;

namespace CinemaManagement.UI.UserControls.Common
{
    public class StaffHeaderControl : UserControl
    {
        private readonly Dictionary<StaffPage, Button> _navButtons = new();
        private readonly Button _btnUser;
        private StaffPage _activePage = StaffPage.Home;

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
            Height = 60;
            Dock = DockStyle.Top;
            BackColor = AppColors.HeaderBackground;

            Controls.Add(new Label
            {
                Text = "STORYLINE CINEMA",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Left = 20,
                Top = 20
            });

            int left = 260;
            foreach (var (page, text) in new[]
            {
                (StaffPage.Home, "Trang chủ"),
                (StaffPage.Booking, "Bán vé"),
                (StaffPage.CheckIn, "Check-in"),
                (StaffPage.Lookup, "Tra cứu vé")
            })
            {
                var btn = CreateNavButton(text, left);
                btn.Click += (s, e) => { if (page != _activePage) NavigateRequested?.Invoke(page); };
                _navButtons[page] = btn;
                Controls.Add(btn);
                left += btn.Width + 8;
            }

            _btnUser = CreateNavButton($"{UserSession.HoTen} ▾", 0);
            _btnUser.Width = 180;
            _btnUser.Click += ShowUserMenu;
            Controls.Add(_btnUser);

            Resize += (s, e) => _btnUser.Left = Width - _btnUser.Width - 20;
            HighlightActive();
        }

        private static Button CreateNavButton(string text, int left) => new()
        {
            Text = text,
            Left = left,
            Top = 12,
            Width = 110,
            Height = 36,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
            BackColor = AppColors.HeaderBackground,
            Cursor = Cursors.Hand,
            FlatAppearance = { BorderSize = 0 }
        };

        private void HighlightActive()
        {
            foreach (var (page, btn) in _navButtons)
            {
                bool active = page == _activePage;
                btn.BackColor = active ? AppColors.Primary : AppColors.HeaderBackground;
                btn.Font = new Font(btn.Font, active ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void InitializeComponent()
        {

        }

        private void ShowUserMenu(object? sender, EventArgs e)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Đổi mật khẩu", null, (_, _) => MessageBox.Show("Chức năng này chưa được xây dựng.", "Thông báo"));
            menu.Items.Add("Đăng xuất", null, (_, _) => LogoutRequested?.Invoke());
            menu.Show(_btnUser, new Point(0, _btnUser.Height));
        }
    }
}
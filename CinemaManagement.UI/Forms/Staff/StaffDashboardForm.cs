using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.BLL.Services.Dashboard;
using CinemaManagement.UI.Session;
using Microsoft.Extensions.DependencyInjection;
using CinemaManagement.UI.Forms.Staff.CheckIn;
using CinemaManagement.UI.Navigation;

namespace CinemaManagement.UI.Forms.Staff
{
    public partial class StaffDashboardForm : Form
    {
        private System.Windows.Forms.Timer _clockTimer = null!;
        public StaffDashboardForm()
        {
            InitializeComponent();
            SetupClock();
            WireEvents();
            lblWelcome.Text = $"Xin chào, {UserSession.HoTen}";
            btnUserMenu.Text = $"{UserSession.HoTen} ▾";
        }

        private async void StaffDashboardForm_Load(object sender, EventArgs e)
        {
            await LoadDashboardAsync();
        }
        private void SetupClock()
        {
            UpdateClock();
            _clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => UpdateClock();
            _clockTimer.Start();
        }
        private void UpdateClock()
        {
            var culture = new System.Globalization.CultureInfo("vi-VN");
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy • HH:mm", culture);
        }
        private async Task LoadDashboardAsync()
        {
            var dashboardService = Program.Services.GetRequiredService<IDashboardService>();
            var data = await dashboardService.GetStaffDashboardAsync();

            lblVeDaBanValue.Text = data.VeDaBanHomNay.ToString();
            lblSuatHomNayValue.Text = data.SoSuatChieuHomNay.ToString();
            lblCheckInValue.Text = data.SoLuotCheckInHomNay.ToString();
            lblDoanhThuValue.Text = data.DoanhThuHomNay.ToString("N0") + " đ";

            dgvUpcoming.Rows.Clear();
            dgvUpcoming.Columns.Clear();
            dgvUpcoming.Columns.Add("Gio", "Giờ");
            dgvUpcoming.Columns.Add("Phim", "Phim");
            dgvUpcoming.Columns.Add("Phong", "Phòng");
            dgvUpcoming.Columns.Add("DaBan", "Đã bán");
            dgvUpcoming.Columns.Add("TrangThai", "Trạng thái");

            foreach (var s in data.SuatChieuSapDienRa)
            {
                int rowIndex = dgvUpcoming.Rows.Add(
                    s.GioBatDau.ToString(@"hh\:mm"),
                    s.TenPhim,
                    s.TenPhong,
                    $"{s.DaBan}/{s.TongGhe}",
                    s.TrangThai
                );

                // Tô màu badge trạng thái — Gần đầy/Đã đầy nổi bật màu đỏ
                var cell = dgvUpcoming.Rows[rowIndex].Cells["TrangThai"];
                cell.Style.ForeColor = s.TrangThai switch
                {
                    "Gần đầy" or "Đã đầy" => Theme.AppColors.StatusRed,
                    _ => Theme.AppColors.StatusOrange
                };
                cell.Style.Font = new Font(dgvUpcoming.Font, FontStyle.Bold);
            }
        }
        private void WireEvents()
        {
            btnNavHome.Click += (s, e) => { /* đã ở Trang chủ, không cần làm gì */ };
            btnNavBooking.Click += (s, e) => NavigateTo(StaffPage.Booking);
            btnBanVe.Click += (s, e) => NavigateTo(StaffPage.Booking);

            btnNavCheckIn.Click += (s, e) => NavigateTo(StaffPage.CheckIn);
            btnCheckIn.Click += (s, e) => NavigateTo(StaffPage.CheckIn);

            btnNavLookup.Click += (s, e) => NavigateTo(StaffPage.Lookup);
            btnTraCuu.Click += (s, e) => NavigateTo(StaffPage.Lookup);

            btnUserMenu.Click += (s, e) => ShowUserMenu();
        }
        private async void NavigateTo(StaffPage page)
        {
            Hide();
            try
            {
                while (page is not (StaffPage.Home or StaffPage.SignOut))
                {
                    using var next = CreatePage(page);
                    if (next is null)
                    {
                        MessageBox.Show("Chức năng này chưa được xây dựng.", "Thông báo");
                        break;
                    }
                    next.ShowDialog();
                    page = (next as IStaffPage)?.NextPage ?? StaffPage.Home;
                }
            }
            finally
            {
                Show();     // nếu trang con ném lỗi (vd. không đủ quyền) thì Dashboard vẫn hiện lại
            }

            if (page == StaffPage.SignOut) await LogoutAsync();
            else await LoadDashboardAsync();      // quay về thì làm mới số liệu
        }

        private static Form? CreatePage(StaffPage page) => page switch
        {
            StaffPage.CheckIn => new CheckInForm(),
            _ => null              // Booking, Lookup: bổ sung khi code tới
        };

        private void ShowUserMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Đổi mật khẩu", null, (s, e) => MessageBox.Show("Chưa code — module M15/Shared."));
            menu.Items.Add("Đăng xuất", null, async (s, e) => await LogoutAsync());
            menu.Show(btnUserMenu, new Point(0, btnUserMenu.Height));
        }

        private async Task LogoutAsync()
        {
            var authService = Program.Services.GetRequiredService<IAuthService>();
            await authService.LogoutAsync(UserSession.UserId);
            UserSession.SignOut();
            _clockTimer.Stop();
            new Auth.LoginForm().Show();
            this.Close();
        }
        private void btnNavHome_Click(object sender, EventArgs e)
        {

        }

        private void btnNavBooking_Click(object sender, EventArgs e)
        {

        }

        private void lblVeDaBanValue_Click(object sender, EventArgs e)
        {

        }
    }
}

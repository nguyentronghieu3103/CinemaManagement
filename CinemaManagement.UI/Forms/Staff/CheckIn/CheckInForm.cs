using System.Drawing.Drawing2D;
using System.Media;
using CinemaManagement.BLL.Services.Tickets;
using CinemaManagement.Common.Constants;
using CinemaManagement.UI.Helpers;
using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using CinemaManagement.UI.UserControls.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.UI.Forms.Staff.CheckIn
{
    public partial class CheckInForm : Form, IStaffPage
    {
        private readonly StaffHeaderControl _header = new() { ActivePage = StaffPage.CheckIn };
        private bool _busy;
        private readonly CinemaBackdropPanel _stage = new() { Dock = DockStyle.Fill };    // nền glow điện ảnh

        public StaffPage NextPage { get; private set; } = StaffPage.Home;

        public CheckInForm()
        {
            // Chặn bằng code TRƯỚC khi khởi tạo giao diện
            PermissionGuard.EnsurePermission(PermissionConstants.CHECKIN);

            InitializeComponent();
            BackColor = AppColors.PageBackground;
            pnlCenter.BackColor = Color.Transparent;
            _stage.Controls.Add(pnlCenter);       // nội dung nằm trên nền glow
            Controls.Add(_stage);

            _header.NavigateRequested += page => { NextPage = page; Close(); };
            _header.LogoutRequested += () => { NextPage = StaffPage.SignOut; Close(); };
            Controls.Add(_header);
            _header.SendToBack();            // để header luôn nằm trên cùng

            pnlScanZone.Paint += pnlScanZone_Paint;
            btnLookup.Click += async (s, e) => await HandleScannedCodeAsync(txtCode.Text);
            AcceptButton = btnLookup;         // Enter = tra cứu (máy quét cầm tay tự gõ Enter sau khi quét)

            Resize += (s, e) => CenterContent();
            Shown += (s, e) => { CenterContent(); txtCode.Focus(); };
        }

        // Điểm vào duy nhất cho mọi nguồn mã (nhập tay, máy quét cầm tay, sau này là webcam)
        private async Task HandleScannedCodeAsync(string raw)
        {
            if (_busy || string.IsNullOrWhiteSpace(raw)) return;
            _busy = true;
            lblMessage.Text = string.Empty;

            try
            {
                // Mỗi thao tác dùng 1 scope riêng để luôn đọc dữ liệu mới từ DB
                using var scope = Program.Services.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<ICheckInService>();

                var lookup = await service.LookupAsync(raw);
                if (!lookup.IsSuccess)
                {
                    ShowError(lookup.ErrorMessage!);
                    return;
                }

                var ticket = lookup.Data!;
                using var popup = new CheckInResultForm(ticket);
                if (ShowWithOverlay(popup) != DialogResult.OK) return;   // nhân viên đóng popup, không check-in

                var confirm = await service.ConfirmCheckInAsync(ticket.TicketId, UserSession.UserId);
                if (!confirm.IsSuccess)
                {
                    ShowError(confirm.ErrorMessage!);
                    return;
                }

                SystemSounds.Asterisk.Play();
                lblLast.Text = $"Vừa check-in: {ticket.MaVe} • Ghế {ticket.ViTriGhe} • {DateTime.Now:HH:mm}";
                lblLast.ForeColor = AppColors.Success;
            }
            finally
            {
                _busy = false;
                txtCode.Clear();
                txtCode.Focus();        // sẵn sàng cho lần quét kế tiếp
            }
        }

        // Popup nổi trên form quét, nền phía sau được làm tối
        private DialogResult ShowWithOverlay(Form popup)
        {
            using var dim = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                Bounds = this.Bounds,
                BackColor = Color.Black,
                Opacity = 0.45,
                ShowInTaskbar = false
            };
            dim.Show(this);
            var result = popup.ShowDialog(dim);
            dim.Close();
            return result;
        }

        private void ShowError(string message)
        {
            lblMessage.Text = message;
            SystemSounds.Hand.Play();
        }

        private void CenterContent()
        {
            pnlCenter.Left = Math.Max(0, (_stage.ClientSize.Width - pnlCenter.Width) / 2);
            pnlCenter.Top = 30;                  // _stage nằm ngay dưới header nên không cần cộng chiều cao header
        }

        // Vẽ 4 góc khung quét bằng GDI+
        private void pnlScanZone_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(AppColors.Primary, 4);
            var r = pnlScanZone.ClientRectangle;
            int len = 28, m = 12;

            e.Graphics.DrawLines(pen, new[] { new Point(m, m + len), new Point(m, m), new Point(m + len, m) });
            e.Graphics.DrawLines(pen, new[] { new Point(r.Right - m - len, m), new Point(r.Right - m, m), new Point(r.Right - m, m + len) });
            e.Graphics.DrawLines(pen, new[] { new Point(m, r.Bottom - m - len), new Point(m, r.Bottom - m), new Point(m + len, r.Bottom - m) });
            e.Graphics.DrawLines(pen, new[] { new Point(r.Right - m - len, r.Bottom - m), new Point(r.Right - m, r.Bottom - m), new Point(r.Right - m, r.Bottom - m - len) });
        }
    }
}
using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.BLL.Services.Dashboard;
using CinemaManagement.Common.DTOs.Dashboard;
using CinemaManagement.UI.Forms.Staff.Booking;
using CinemaManagement.UI.Forms.Staff.CheckIn;
using CinemaManagement.UI.Forms.Staff.Booking;
using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using CinemaManagement.UI.UserControls.Common;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Globalization;

namespace CinemaManagement.UI.Forms.Staff
{
    public partial class StaffDashboardForm : Form
    {
        private readonly StaffHeaderControl _header = new() { ActivePage = StaffPage.Home };

        private GradientPanel _hero = null!;
        private Label _lblWelcome = null!, _lblSub = null!, _lblTime = null!, _lblDate = null!;
        private StatCard _cardVe = null!, _cardSuat = null!, _cardCheckIn = null!, _cardDoanhThu = null!;
        private Label _lblUpdated = null!, _lblEmpty = null!;
        private DataGridView _grid = null!;
        private PillButton _btnBanVe = null!, _btnCheckIn = null!, _btnTraCuu = null!;

        private System.Windows.Forms.Timer _clockTimer = null!;
        private System.Windows.Forms.Timer _refreshTimer = null!;
        private bool _loading;
        private readonly CultureInfo _vi = new("vi-VN");

        public StaffDashboardForm()
        {
            BuildUi();
            WireEvents();
            SetupTimers();
        }

        // ================== DỰNG GIAO DIỆN ==================
        private void BuildUi()
        {
            SuspendLayout();
            Text = "Storyline Cinema — Trang chủ";
            StartPosition = FormStartPosition.CenterScreen;
            // Cỡ cửa sổ mặc định, nhưng không bao giờ vượt quá vùng làm việc của màn hình (tránh tràn khi DPI 150%)
            var work = Screen.FromPoint(Cursor.Position).WorkingArea;
            ClientSize = new Size(Math.Min(this.S(1280), work.Width - this.S(60)),
                                  Math.Min(this.S(800), work.Height - this.S(100)));
            MinimumSize = new Size(Math.Min(this.S(960), work.Width - this.S(60)),
                                   Math.Min(this.S(660), work.Height - this.S(100)));
            BackColor = AppColors.PageBackground;
            Font = new Font("Segoe UI", 10F);
            DoubleBuffered = true;

            var body = new CinemaBackdropPanel
            {
                Dock = DockStyle.Fill,
                Animate = true,      // glow đỏ/xanh/tím trôi cực chậm (tắt toàn cục: UiKit.AnimateBackground = false)
                Padding = new Padding(this.S(32), this.S(22), this.S(32), this.S(24))
            };

            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.Transparent
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(124) + this.S(18)));   // banner
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(118) + this.S(18)));   // 4 thẻ số liệu
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));                         // bảng suất chiếu
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(76) + this.S(8)));     // 3 nút nhanh

            table.Controls.Add(BuildHero(), 0, 0);
            table.Controls.Add(BuildStats(), 0, 1);
            table.Controls.Add(BuildShowtimeCard(), 0, 2);
            table.Controls.Add(BuildActions(), 0, 3);

            body.Controls.Add(table);
            Controls.Add(body);
            Controls.Add(_header);
            _header.SendToBack();                 // header luôn nằm trên cùng
            ResumeLayout(true);
        }

        private Control BuildHero()
        {
            _hero = new GradientPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, this.S(18)),
                Radius = 20
            };

            _lblWelcome = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 21F, FontStyle.Bold),
                Left = this.S(32),
                Top = this.S(22)
            };
            _lblSub = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 11.5F),
                Left = this.S(34),
                Top = this.S(70)
            };
            _lblTime = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                Top = this.S(14)
            };
            _lblDate = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 11F),
                Top = this.S(74)
            };

            _hero.Controls.AddRange(new Control[] { _lblWelcome, _lblSub, _lblTime, _lblDate });
            _hero.Resize += (s, e) => PositionClock();
            return _hero;
        }

        private Control BuildStats()
        {
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };
            for (int i = 0; i < 4; i++) row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            _cardVe = MakeStat("Vé đã bán", "🎟", AppColors.Primary, AppColors.PrimarySoft);
            _cardSuat = MakeStat("Suất hôm nay", "🎬", AppColors.SoftBlue, AppColors.InfoSoft);
            _cardCheckIn = MakeStat("Check-in", "✅", AppColors.Success, AppColors.SuccessSoft);
            _cardDoanhThu = MakeStat("Doanh thu hôm nay", "💰", AppColors.Purple, AppColors.PurpleSoft);
            _cardDoanhThu.Suffix = " đ";

            row.Controls.Add(_cardVe, 0, 0);
            row.Controls.Add(_cardSuat, 1, 0);
            row.Controls.Add(_cardCheckIn, 2, 0);
            row.Controls.Add(_cardDoanhThu, 3, 0);
            row.Margin = new Padding(0, 0, 0, this.S(18));
            return row;
        }

        private StatCard MakeStat(string caption, string icon, Color accent, Color soft) => new()
        {
            Caption = caption,
            Icon = icon,
            AccentColor = accent,
            IconBack = soft,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, this.S(16), this.S(8))
        };

        private Control BuildShowtimeCard()
        {
            var card = new CardPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, this.S(18)),
                Padding = new Padding(this.S(20), this.S(16), this.S(25), this.S(25))
            };

            // dòng tiêu đề của thẻ
            var titleRow = new Panel { Dock = DockStyle.Top, Height = this.S(46), BackColor = Color.Transparent };
            var lblTitle = new Label
            {
                Text = "🎞  Suất chiếu sắp diễn ra",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextDark,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Left = 0,
                Top = this.S(4)
            };
            _lblUpdated = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                Top = this.S(10)
            };
            titleRow.Controls.Add(lblTitle);
            titleRow.Controls.Add(_lblUpdated);
            titleRow.Resize += (s, e) => _lblUpdated.Left = titleRow.Width - _lblUpdated.Width;

            _grid = new DataGridView { Dock = DockStyle.Fill };
            UiKit.StyleGrid(_grid);
            _grid.Columns.Add(MakeColumn("Gio", "GIỜ", 11));
            _grid.Columns.Add(MakeColumn("Phim", "PHIM", 36));
            _grid.Columns.Add(MakeColumn("Phong", "PHÒNG", 11));
            _grid.Columns.Add(MakeColumn("DaBan", "ĐÃ BÁN", 24));
            _grid.Columns.Add(MakeColumn("TrangThai", "TRẠNG THÁI", 18));
            _grid.Columns["Phim"]!.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _grid.CellPainting += Grid_CellPainting;

            _lblEmpty = new Label
            {
                Text = "🎬  Hôm nay chưa có suất chiếu nào sắp diễn ra",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AppColors.TextMuted,
                BackColor = AppColors.CardBackground,
                Font = new Font("Segoe UI", 12F),
                Visible = false
            };

            card.Controls.Add(_lblEmpty);
            card.Controls.Add(_grid);
            card.Controls.Add(titleRow);
            titleRow.SendToBack();
            return card;
        }

        private static DataGridViewTextBoxColumn MakeColumn(string name, string header, float weight) => new()
        {
            Name = name,
            HeaderText = header,
            FillWeight = weight,
            SortMode = DataGridViewColumnSortMode.NotSortable
        };

        private Control BuildActions()
        {
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };
            for (int i = 0; i < 3; i++) row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 3));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            _btnBanVe = MakeAction("🎟   BÁN VÉ", AppColors.Primary, Color.White);
            _btnCheckIn = MakeAction("✅   CHECK-IN", AppColors.Surface2, AppColors.TextPrimary);
            _btnCheckIn.BorderColor = AppColors.BorderStrong;
            _btnCheckIn.HoverColor = UiKit.Blend(AppColors.Surface2, AppColors.Blue, 0.30f);
            _btnTraCuu = MakeAction("🔍   TRA CỨU VÉ", AppColors.PrimarySoft, AppColors.TextPrimary);
            _btnTraCuu.BorderColor = AppColors.Primary;
            _btnTraCuu.HoverColor = UiKit.Blend(AppColors.PrimarySoft, AppColors.Primary, 0.25f);

            row.Controls.Add(_btnBanVe, 0, 0);
            row.Controls.Add(_btnCheckIn, 1, 0);
            row.Controls.Add(_btnTraCuu, 2, 0);
            return row;
        }

        private PillButton MakeAction(string text, Color back, Color fore) => new()
        {
            Text = text,
            NormalColor = back,
            ForeColor = fore,
            Radius = 16,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, this.S(16), this.S(8)),
            Font = new Font("Segoe UI", 13F, FontStyle.Bold)
        };

        // ================== ĐỒNG HỒ + TIMER ==================
        private void SetupTimers()
        {
            _lblWelcome.Text = $"Xin chào, {UserSession.HoTen} 👋";
            UpdateClock();

            _clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => UpdateClock();
            _clockTimer.Start();

            // tự làm mới số liệu mỗi 60 giây khi đang ở Trang chủ
            _refreshTimer = new System.Windows.Forms.Timer { Interval = 60_000 };
            _refreshTimer.Tick += async (s, e) => { if (Visible) await LoadDashboardAsync(animate: false); };
            _refreshTimer.Start();

            FormClosed += (s, e) => { _clockTimer.Stop(); _refreshTimer.Stop(); };
            Load += async (s, e) => await LoadDashboardAsync(animate: true);
        }

        private void UpdateClock()
        {
            var now = DateTime.Now;
            _lblTime.Text = now.ToString("HH:mm:ss");
            _lblDate.Text = now.ToString("dddd, dd/MM/yyyy", _vi);

            string part = now.Hour switch
            {
                < 11 => "sáng",
                < 13 => "trưa",
                < 18 => "chiều",
                _ => "tối"
            };
            _lblSub.Text = $"Chúc bạn một buổi {part} làm việc thật hiệu quả ✨";
            PositionClock();
        }

        private void PositionClock()
        {
            if (_hero == null) return;
            int right = _hero.Width - this.S(36);
            _lblTime.Left = right - _lblTime.Width;
            _lblDate.Left = right - _lblDate.Width;
        }

        // ================== NẠP DỮ LIỆU ==================
        private async Task LoadDashboardAsync(bool animate = true)
        {
            if (_loading) return;
            _loading = true;
            try
            {
                var dashboardService = Program.Services.GetRequiredService<IDashboardService>();
                var data = await dashboardService.GetStaffDashboardAsync();

                _cardVe.SetValue(data.VeDaBanHomNay, animate);
                _cardSuat.SetValue(data.SoSuatChieuHomNay, animate);
                _cardCheckIn.SetValue(data.SoLuotCheckInHomNay, animate);
                _cardDoanhThu.SetValue(data.DoanhThuHomNay, animate);

                _grid.Rows.Clear();
                foreach (var s in data.SuatChieuSapDienRa)
                {
                    int i = _grid.Rows.Add(
                        s.GioBatDau.ToString(@"hh\:mm"),
                        s.TenPhim,
                        s.TenPhong,
                        $"{s.DaBan}/{s.TongGhe}",
                        s.TrangThai);
                    _grid.Rows[i].Tag = s;        // CellPainting cần số liệu gốc để vẽ thanh tiến độ
                }
                _grid.ClearSelection();
                _grid.CurrentCell = null;

                bool empty = data.SuatChieuSapDienRa.Count == 0;
                _lblEmpty.Visible = empty;
                _lblEmpty.BringToFront();
                _grid.Visible = !empty;

                _lblUpdated.ForeColor = AppColors.TextMuted;
                _lblUpdated.Text = $"Cập nhật lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tải được số liệu Trang chủ");
                _lblUpdated.ForeColor = AppColors.StatusRed;
                _lblUpdated.Text = "⚠ Không tải được dữ liệu";
            }
            finally
            {
                _loading = false;
                _lblUpdated.Left = _lblUpdated.Parent!.Width - _lblUpdated.Width;
            }
        }

        // Vẽ riêng 3 cột: giờ (to, đậm), đã bán (số + thanh tiến độ), trạng thái (huy hiệu bo tròn)
        private void Grid_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col is not ("Gio" or "DaBan" or "TrangThai")) return;
            if (_grid.Rows[e.RowIndex].Tag is not UpcomingShowtimeDto dto) return;

            e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border |
                                  DataGridViewPaintParts.SelectionBackground);
            var g = e.Graphics!;
            UiKit.HighQuality(g);
            var cell = e.CellBounds;
            int padX = this.S(12);

            double ratio = dto.TongGhe > 0 ? Math.Min(1.0, (double)dto.DaBan / dto.TongGhe) : 0;
            Color tone = ratio >= 1 ? AppColors.StatusRed
                       : ratio >= 0.85 ? AppColors.StatusOrange
                       : AppColors.Success;

            switch (col)
            {
                case "Gio":
                    using (var f = new Font("Segoe UI", 12F, FontStyle.Bold))
                        TextRenderer.DrawText(g, dto.GioBatDau.ToString(@"hh\:mm"), f,
                            new Rectangle(cell.X + padX, cell.Y, cell.Width - padX, cell.Height),
                            AppColors.TextPrimary,
                            TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
                    break;

                case "DaBan":
                    {
                        string txt = $"{dto.DaBan}/{dto.TongGhe}";
                        int textW = this.S(58);
                        using (var f = new Font("Segoe UI", 10.5F, FontStyle.Bold))
                            TextRenderer.DrawText(g, txt, f,
                                new Rectangle(cell.X + padX, cell.Y, textW, cell.Height), AppColors.TextDark,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);

                        int barX = cell.X + padX + textW;
                        int barW = Math.Max(this.S(20), cell.Width - padX - textW - this.S(18));
                        int barH = this.S(8);
                        var track = new Rectangle(barX, cell.Y + (cell.Height - barH) / 2, barW, barH);
                        using (var p = UiKit.RoundRect(track, barH / 2))
                        using (var br = new SolidBrush(AppColors.Border))
                            g.FillPath(br, p);
                        int fillW = (int)(barW * ratio);
                        if (fillW > 0)
                        {
                            var fill = new Rectangle(track.X, track.Y, Math.Max(fillW, barH), barH);
                            using var p = UiKit.RoundRect(fill, barH / 2);
                            using var br = new SolidBrush(tone);
                            g.FillPath(br, p);
                        }
                        break;
                    }

                case "TrangThai":
                    {
                        (Color fore, Color back) = dto.TrangThai switch
                        {
                            "Đang bán" => (AppColors.Success, AppColors.SuccessSoft),
                            "Gần đầy" => (AppColors.Warning, AppColors.WarnSoft),
                            "Đã đầy" => (AppColors.StatusRed, AppColors.DangerSoft),
                            _ => (AppColors.TextMuted, AppColors.InputBackground)
                        };
                        using var f = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        var size = TextRenderer.MeasureText(dto.TrangThai, f);
                        int w = size.Width + this.S(28), h = this.S(28);
                        var pill = new Rectangle(cell.X + padX, cell.Y + (cell.Height - h) / 2, w, h);
                        using (var p = UiKit.RoundRect(pill, h / 2))
                        using (var br = new SolidBrush(back))
                            g.FillPath(br, p);
                        TextRenderer.DrawText(g, dto.TrangThai, f, pill, fore,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                        break;
                    }
            }
            e.Handled = true;
        }

        // ================== ĐIỀU HƯỚNG ==================
        private void WireEvents()
        {
            _header.NavigateRequested += page => NavigateTo(page);
            _header.LogoutRequested += async () => await LogoutAsync();

            _btnBanVe.Click += (s, e) => NavigateTo(StaffPage.Booking);
            _btnCheckIn.Click += (s, e) => NavigateTo(StaffPage.CheckIn);
            _btnTraCuu.Click += (s, e) => NavigateTo(StaffPage.Lookup);
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
            StaffPage.Booking => new BookingForm(),
            StaffPage.CheckIn => new CheckInForm(),
            StaffPage.Lookup => new CinemaManagement.UI.Forms.Staff.Lookup.LookupForm(),
            _ => null
        };

        private async Task LogoutAsync()
        {
            var authService = Program.Services.GetRequiredService<IAuthService>();
            await authService.LogoutAsync(UserSession.UserId);
            UserSession.SignOut();
            _clockTimer.Stop();
            _refreshTimer.Stop();
            new Auth.LoginForm().Show();
            Close();
        }
    }
}

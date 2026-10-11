using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.BLL.Services.Dashboard;
using CinemaManagement.Common.DTOs.Dashboard;
using CinemaManagement.UI.Forms.Staff.Booking;
using CinemaManagement.UI.Forms.Staff.CheckIn;
using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using CinemaManagement.UI.UserControls.Common;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CinemaManagement.UI.Forms.Staff
{
    public partial class StaffDashboardForm : Form
    {
        private readonly StaffHeaderControl _header = new() { ActivePage = StaffPage.Home };

        private GradientPanel _hero = null!;
        private Label _lblWelcome = null!, _lblSub = null!, _lblTime = null!, _lblDate = null!;
        private StatCard _cardVe = null!, _cardSuat = null!, _cardCheckIn = null!, _cardDoanhThu = null!;
        private Label _lblUpdated = null!;
        private CardPanel _cardShowtimes = null!;
        private Panel _rowsPanel = null!;
        private List<UpcomingShowtimeDto> _showtimes = new();
        private int _showtimeScrollY;
        private bool _isDraggingScroll;
        private int _dragStartY, _dragStartScroll;
        private PillButton _btnBanVe = null!, _btnCheckIn = null!, _btnTraCuu = null!;

        private System.Windows.Forms.Timer _clockTimer = null!;
        private System.Windows.Forms.Timer _refreshTimer = null!;
        private bool _loading;
        private readonly CultureInfo _vi = new("vi-VN");

        // Cache font để tránh cấp phát và huỷ liên tục trong sự kiện OnPaint
        private static readonly Font FontHeader = new("Segoe UI", 9.5F, FontStyle.Bold);
        private static readonly Font FontTime = new("Segoe UI", 12F, FontStyle.Bold);
        private static readonly Font FontMovie = new("Segoe UI", 11F, FontStyle.Bold);
        private static readonly Font FontRoom = new("Segoe UI", 10F);
        private static readonly Font FontCount = new("Segoe UI", 10.5F, FontStyle.Bold);
        private static readonly Font FontBadge = new("Segoe UI", 9.5F, FontStyle.Bold);
        private static readonly Font FontEmpty = new("Segoe UI", 12F);

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
            WindowState = FormWindowState.Maximized;

            var work = Screen.FromPoint(Cursor.Position).WorkingArea;
            ClientSize = new Size(Math.Min(this.S(1366), work.Width - this.S(40)),
                                  Math.Min(this.S(820), work.Height - this.S(60)));
            MinimumSize = new Size(this.S(1024), this.S(680));
            BackColor = AppColors.PageBackground;
            Font = new Font("Segoe UI", 10F);
            DoubleBuffered = true;

            var body = new CinemaBackdropPanel
            {
                Dock = DockStyle.Fill,
                Animate = false,     // Tắt hoạt ảnh nền để triệt tiêu hoàn toàn Timer 100ms gây giật
                Padding = new Padding(this.S(28), this.S(14), this.S(28), this.S(14))
            };

            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.Transparent
            };
            UiKit.DoubleBuffer(table);
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(94) + this.S(10)));   // 1. Banner chào mừng
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(98) + this.S(10)));   // 2. 4 thẻ số liệu
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));                         // 3. Bảng suất chiếu (chiếm trọn không gian)
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(60) + this.S(6)));     // 4. 3 nút nhanh

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
                Margin = new Padding(0, 0, 0, this.S(10)),
                Radius = 18
            };

            _lblWelcome = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Left = this.S(28),
                Top = this.S(16)
            };
            _lblSub = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 10.5F),
                Left = this.S(30),
                Top = this.S(54)
            };
            _lblTime = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                Top = this.S(12)
            };
            _lblDate = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 10.5F),
                Top = this.S(54)
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
                Margin = new Padding(0, 0, 0, this.S(10))
            };
            UiKit.DoubleBuffer(row);
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
            return row;
        }

        private StatCard MakeStat(string caption, string icon, Color accent, Color soft) => new()
        {
            Caption = caption,
            Icon = icon,
            AccentColor = accent,
            IconBack = soft,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, this.S(12), 0)
        };

        private Control BuildShowtimeCard()
        {
            var card = new CardPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, this.S(10)),
                Padding = new Padding(this.S(24), this.S(14), this.S(24), this.S(14))
            };
            UiKit.DoubleBuffer(card);

            var cardTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            UiKit.DoubleBuffer(cardTable);
            cardTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            cardTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(38))); // Hàng 0: Tiêu đề
            cardTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(36))); // Hàng 1: Tiêu đề cột (Sticky Header riêng biệt)
            cardTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));        // Hàng 2: Vùng dữ liệu cuộn

            // 1. Dòng tiêu đề thẻ
            var titleRow = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(0) };
            var lblTitle = new Label
            {
                Text = "🎞  Suất chiếu sắp diễn ra",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextDark,
                Font = new Font("Segoe UI", 13.5F, FontStyle.Bold),
                Left = 0,
                Top = this.S(2)
            };
            _lblUpdated = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                Top = this.S(6)
            };
            titleRow.Controls.Add(lblTitle);
            titleRow.Controls.Add(_lblUpdated);
            titleRow.Resize += (s, e) => _lblUpdated.Left = Math.Max(lblTitle.Right + 20, titleRow.Width - _lblUpdated.Width);

            // 2. Tiêu đề cột cố định (Sticky Header) - nằm trên Panel độc lập, không bao giờ bị chữ hàng đè lên
            var headerPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(0) };
            UiKit.DoubleBuffer(headerPanel);
            headerPanel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                UiKit.HighQuality(g);
                var (cols, wCols) = CalcColumns(headerPanel.Width);
                string[] headers = { "GIỜ", "PHIM", "PHÒNG", "ĐÃ BÁN", "TRẠNG THÁI" };
                int padX = this.S(10);
                for (int i = 0; i < 5; i++)
                {
                    var rHeader = new Rectangle(cols[i] + padX, 0, wCols[i] - padX, headerPanel.Height);
                    TextRenderer.DrawText(g, headers[i], FontHeader, rHeader, AppColors.TextSecondary,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
                }
                using var pBorder = new Pen(AppColors.Border);
                g.DrawLine(pBorder, 0, headerPanel.Height - 1, headerPanel.Width, headerPanel.Height - 1);
            };
            headerPanel.Resize += (s, e) => headerPanel.Invalidate();

            // 3. Vùng danh sách các hàng có thể cuộn - được hệ điều hành giới hạn clip riêng, triệt tiêu lỗi tràn text
            _rowsPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(0) };
            UiKit.DoubleBuffer(_rowsPanel);
            _rowsPanel.Paint += (s, e) => DrawShowtimesRows(e.Graphics, _rowsPanel);

            // Xử lý lăn chuột đồng bộ cho toàn thẻ
            card.MouseWheel += (s, e) => ScrollShowtimes(e.Delta);
            cardTable.MouseWheel += (s, e) => ScrollShowtimes(e.Delta);
            titleRow.MouseWheel += (s, e) => ScrollShowtimes(e.Delta);
            headerPanel.MouseWheel += (s, e) => ScrollShowtimes(e.Delta);
            _rowsPanel.MouseWheel += (s, e) => ScrollShowtimes(e.Delta);

            _rowsPanel.MouseEnter += (s, e) => { if (!_rowsPanel.Focused) _rowsPanel.Focus(); };
            card.MouseEnter += (s, e) => { if (!_rowsPanel.Focused) _rowsPanel.Focus(); };

            // Kéo thanh cuộn bằng chuột
            _rowsPanel.MouseDown += (s, e) =>
            {
                int hRow = this.S(48);
                int totalHeight = _showtimes.Count * hRow;
                int maxScroll = Math.Max(0, totalHeight - _rowsPanel.Height);
                if (maxScroll <= 0) return;

                int trackW = this.S(6);
                int trackX = _rowsPanel.Width - trackW - this.S(2);
                int trackY = this.S(4);
                int trackH = Math.Max(this.S(20), _rowsPanel.Height - this.S(8));

                if (e.X >= trackX - this.S(10) && e.X <= _rowsPanel.Width && e.Y >= trackY && e.Y <= trackY + trackH)
                {
                    _isDraggingScroll = true;
                    _dragStartY = e.Y;
                    _dragStartScroll = _showtimeScrollY;
                    _rowsPanel.Capture = true;
                }
            };

            _rowsPanel.MouseMove += (s, e) =>
            {
                if (!_isDraggingScroll) return;
                int hRow = this.S(48);
                int totalHeight = _showtimes.Count * hRow;
                int maxScroll = Math.Max(0, totalHeight - _rowsPanel.Height);
                if (maxScroll <= 0) return;

                int trackH = Math.Max(this.S(20), _rowsPanel.Height - this.S(8));
                int thumbH = Math.Max(this.S(24), (int)((float)_rowsPanel.Height / totalHeight * trackH));
                int scrollRange = trackH - thumbH;
                if (scrollRange > 0)
                {
                    float ratio = (float)(e.Y - _dragStartY) / scrollRange;
                    _showtimeScrollY = Math.Clamp(_dragStartScroll + (int)(ratio * maxScroll), 0, maxScroll);
                    _rowsPanel.Invalidate();
                }
            };

            _rowsPanel.MouseUp += (s, e) =>
            {
                if (_isDraggingScroll)
                {
                    _isDraggingScroll = false;
                    _rowsPanel.Capture = false;
                }
            };

            _rowsPanel.Resize += (s, e) =>
            {
                int hRow = this.S(48);
                int totalHeight = _showtimes.Count * hRow;
                int maxScroll = Math.Max(0, totalHeight - _rowsPanel.Height);
                _showtimeScrollY = Math.Clamp(_showtimeScrollY, 0, maxScroll);
                _rowsPanel.Invalidate();
            };

            cardTable.Controls.Add(titleRow, 0, 0);
            cardTable.Controls.Add(headerPanel, 0, 1);
            cardTable.Controls.Add(_rowsPanel, 0, 2);

            card.Controls.Add(cardTable);
            _cardShowtimes = card;
            return card;
        }

        private void ScrollShowtimes(int delta)
        {
            if (_rowsPanel == null) return;
            int hRow = this.S(48);
            int totalHeight = _showtimes.Count * hRow;
            int maxScroll = Math.Max(0, totalHeight - _rowsPanel.Height);
            if (maxScroll <= 0) return;

            _showtimeScrollY = Math.Clamp(_showtimeScrollY - Math.Sign(delta) * (hRow * 2), 0, maxScroll);
            _rowsPanel.Invalidate();
        }

        private static (int[] cols, int[] wCols) CalcColumns(int width)
        {
            // Tỉ lệ phân bổ 5 cột: 11% - 37% - 13% - 22% - 17% (Tổng = 100%)
            int x1 = 0;
            int x2 = (int)(width * 0.11f);
            int x3 = x2 + (int)(width * 0.37f);
            int x4 = x3 + (int)(width * 0.13f);
            int x5 = x4 + (int)(width * 0.22f);

            int[] cols = { x1, x2, x3, x4, x5 };
            int[] wCols = { x2 - x1, x3 - x2, x4 - x3, x5 - x4, width - x5 };
            return (cols, wCols);
        }

        private void DrawShowtimesRows(Graphics g, Panel panel)
        {
            UiKit.HighQuality(g);
            int width = panel.Width;
            int height = panel.Height;

            if (_showtimes.Count == 0)
            {
                string text = "🎬  Hôm nay chưa có suất chiếu nào sắp diễn ra";
                var rectEmpty = new Rectangle(0, 0, width, height);
                TextRenderer.DrawText(g, text, FontEmpty, rectEmpty, AppColors.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                return;
            }

            int hRow = this.S(48);
            int totalHeight = _showtimes.Count * hRow;
            int maxScroll = Math.Max(0, totalHeight - height);
            _showtimeScrollY = Math.Clamp(_showtimeScrollY, 0, maxScroll);

            var (cols, wCols) = CalcColumns(width);
            int padX = this.S(10);
            using var pBorder = new Pen(AppColors.Border);

            for (int i = 0; i < _showtimes.Count; i++)
            {
                var dto = _showtimes[i];
                int y = (i * hRow) - _showtimeScrollY;

                // Bỏ qua dòng nằm ngoài khung nhìn
                if (y + hRow < 0 || y > height) continue;

                // Xen kẽ nền hàng lẻ nhẹ nhàng để dễ phân biệt
                if (i % 2 == 1)
                {
                    using var brAlt = new SolidBrush(Color.FromArgb(16, 255, 255, 255));
                    g.FillRectangle(brAlt, 0, y, width, hRow);
                }

                // 1. Giờ
                var rTime = new Rectangle(cols[0] + padX, y, wCols[0] - padX, hRow);
                TextRenderer.DrawText(g, dto.GioBatDau.ToString(@"hh\:mm"), FontTime, rTime, AppColors.TextPrimary,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);

                // 2. Phim
                var rMovie = new Rectangle(cols[1] + padX, y, wCols[1] - padX, hRow);
                TextRenderer.DrawText(g, dto.TenPhim, FontMovie, rMovie, AppColors.TextPrimary,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);

                // 3. Phòng
                var rRoom = new Rectangle(cols[2] + padX, y, wCols[2] - padX, hRow);
                TextRenderer.DrawText(g, dto.TenPhong, FontRoom, rRoom, AppColors.TextSecondary,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);

                // 4. Đã bán (Text + Thanh tiến độ)
                double ratio = dto.TongGhe > 0 ? Math.Min(1.0, (double)dto.DaBan / dto.TongGhe) : 0;
                Color tone = ratio >= 1 ? AppColors.StatusRed
                           : ratio >= 0.85 ? AppColors.StatusOrange
                           : AppColors.Success;

                string txtCount = $"{dto.DaBan}/{dto.TongGhe}";
                int textW = this.S(54);
                var rCount = new Rectangle(cols[3] + padX, y, textW, hRow);
                TextRenderer.DrawText(g, txtCount, FontCount, rCount, AppColors.TextPrimary,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);

                int barX = cols[3] + padX + textW;
                int barW = Math.Max(this.S(20), wCols[3] - padX - textW - this.S(16));
                int barH = this.S(6);
                var track = new Rectangle(barX, y + (hRow - barH) / 2, barW, barH);
                using (var pTrack = UiKit.RoundRect(track, barH / 2))
                using (var brTrack = new SolidBrush(AppColors.Surface2))
                    g.FillPath(brTrack, pTrack);

                int fillW = (int)(barW * ratio);
                if (fillW > 0)
                {
                    var fill = new Rectangle(track.X, track.Y, Math.Max(fillW, barH), barH);
                    using var pFill = UiKit.RoundRect(fill, barH / 2);
                    using var brFill = new SolidBrush(tone);
                    g.FillPath(brFill, pFill);
                }

                // 5. Trạng thái (Pill Badge)
                (Color fore, Color back) = dto.TrangThai switch
                {
                    "Đang bán" => (AppColors.Success, AppColors.SuccessSoft),
                    "Gần đầy" => (AppColors.Warning, AppColors.WarnSoft),
                    "Đã đầy" => (AppColors.StatusRed, AppColors.DangerSoft),
                    _ => (AppColors.TextMuted, AppColors.InputBackground)
                };

                var size = TextRenderer.MeasureText(dto.TrangThai, FontBadge);
                int pillW = size.Width + this.S(24), pillH = this.S(26);
                var pill = new Rectangle(cols[4] + padX, y + (hRow - pillH) / 2, pillW, pillH);
                using (var pPill = UiKit.RoundRect(pill, pillH / 2))
                using (var brPill = new SolidBrush(back))
                    g.FillPath(brPill, pPill);
                TextRenderer.DrawText(g, dto.TrangThai, FontBadge, pill, fore,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

                // Đường phân cách hàng
                g.DrawLine(pBorder, 0, y + hRow, width, y + hRow);
            }

            // Vẽ thanh cuộn nếu tổng số dòng dài hơn chiều cao hiển thị
            if (maxScroll > 0 && height > this.S(30))
            {
                int trackW = this.S(6);
                int trackX = width - trackW - this.S(2);
                int trackY = this.S(4);
                int trackH = height - this.S(8);

                using var pTrackBg = UiKit.RoundRect(new Rectangle(trackX, trackY, trackW, trackH), trackW / 2);
                using var brTrackBg = new SolidBrush(AppColors.Surface2);
                g.FillPath(brTrackBg, pTrackBg);

                int thumbH = Math.Max(this.S(24), (int)((float)height / totalHeight * trackH));
                int thumbY = trackY + (int)((float)_showtimeScrollY / maxScroll * (trackH - thumbH));
                using var pThumb = UiKit.RoundRect(new Rectangle(trackX, thumbY, trackW, thumbH), trackW / 2);
                using var brThumb = new SolidBrush(AppColors.BorderStrong);
                g.FillPath(brThumb, pThumb);
            }
        }

        private Control BuildActions()
        {
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0, this.S(4), 0, 0)
            };
            UiKit.DoubleBuffer(row);
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
            Radius = 14,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, this.S(12), 0),
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
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
            int right = _hero.Width - this.S(30);
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

                _showtimes = data.SuatChieuSapDienRa.ToList();
                _showtimeScrollY = 0;
                _rowsPanel?.Invalidate();

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
                if (_lblUpdated?.Parent != null)
                {
                    var lblTitle = _lblUpdated.Parent.Controls.Count > 0 ? _lblUpdated.Parent.Controls[0] : null;
                    int minLeft = (lblTitle != null) ? lblTitle.Right + 20 : 0;
                    _lblUpdated.Left = Math.Max(minLeft, _lblUpdated.Parent.Width - _lblUpdated.Width);
                }
            }
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

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
        private StatCard _cardVe = null!, _cardSuat = null!, _cardCheckIn = null!;
        private Label _lblUpdated = null!;
        private CardPanel _cardShowtimes = null!;
        private Panel _rowsPanel = null!;
        private Panel _paginationPanel = null!;
        private Label _lblPageInfo = null!;
        private FlowLayoutPanel _pnlPageButtons = null!;

        private List<UpcomingShowtimeDto> _showtimes = new();
        private int _currentPage = 1;
        private const int PageSize = 10;
        private int TotalPages => Math.Max(1, (int)Math.Ceiling((double)_showtimes.Count / PageSize));

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
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, this.S(10))
            };
            UiKit.DoubleBuffer(row);
            for (int i = 0; i < 3; i++) row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 3));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            _cardVe = MakeStat("Vé bán hôm nay", "🎟", AppColors.Primary, AppColors.PrimarySoft);
            _cardSuat = MakeStat("Suất chiếu hôm nay", "🎬", AppColors.SoftBlue, AppColors.InfoSoft);
            _cardCheckIn = MakeStat("Check-in hôm nay", "✅", AppColors.Success, AppColors.SuccessSoft);
            _cardCheckIn.Margin = Padding.Empty;

            row.Controls.Add(_cardVe, 0, 0);
            row.Controls.Add(_cardSuat, 1, 0);
            row.Controls.Add(_cardCheckIn, 2, 0);
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
                Padding = new Padding(this.S(24), this.S(14), this.S(24), this.S(12))
            };
            UiKit.DoubleBuffer(card);

            var cardTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            UiKit.DoubleBuffer(cardTable);
            cardTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            cardTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(38))); // Hàng 0: Tiêu đề
            cardTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(36))); // Hàng 1: Tiêu đề cột (Sticky Header riêng biệt)
            cardTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));        // Hàng 2: Vùng dữ liệu 10 suất chiếu
            cardTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(42))); // Hàng 3: Phân trang góc phải

            // 1. Dòng tiêu đề thẻ
            var titleRow = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(0) };
            var lblTitle = new Label
            {
                Text = "🎞  Suất chiếu hôm nay",
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

            // 3. Vùng danh sách các hàng (tối đa 10 hàng/trang)
            _rowsPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(0) };
            UiKit.DoubleBuffer(_rowsPanel);
            _rowsPanel.Paint += (s, e) => DrawShowtimesRows(e.Graphics, _rowsPanel);
            _rowsPanel.Resize += (s, e) => _rowsPanel.Invalidate();

            // 4. Thanh phân trang góc dưới
            _paginationPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(0) };
            UiKit.DoubleBuffer(_paginationPanel);
            _paginationPanel.Paint += (s, e) =>
            {
                using var pBorder = new Pen(AppColors.Border);
                e.Graphics.DrawLine(pBorder, 0, 0, _paginationPanel.Width, 0);
            };

            _lblPageInfo = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                Top = this.S(10),
                Left = this.S(6)
            };

            _pnlPageButtons = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            UiKit.DoubleBuffer(_pnlPageButtons);

            _paginationPanel.Controls.Add(_lblPageInfo);
            _paginationPanel.Controls.Add(_pnlPageButtons);
            _paginationPanel.Resize += (s, e) => PositionPagination();
            _pnlPageButtons.SizeChanged += (s, e) => PositionPagination();

            // Xử lý lăn chuột để lướt trang
            card.MouseWheel += (s, e) => HandleMouseWheelPagination(e.Delta);
            cardTable.MouseWheel += (s, e) => HandleMouseWheelPagination(e.Delta);
            titleRow.MouseWheel += (s, e) => HandleMouseWheelPagination(e.Delta);
            headerPanel.MouseWheel += (s, e) => HandleMouseWheelPagination(e.Delta);
            _rowsPanel.MouseWheel += (s, e) => HandleMouseWheelPagination(e.Delta);
            _paginationPanel.MouseWheel += (s, e) => HandleMouseWheelPagination(e.Delta);

            _rowsPanel.MouseEnter += (s, e) => { if (!_rowsPanel.Focused) _rowsPanel.Focus(); };
            card.MouseEnter += (s, e) => { if (!_rowsPanel.Focused) _rowsPanel.Focus(); };

            cardTable.Controls.Add(titleRow, 0, 0);
            cardTable.Controls.Add(headerPanel, 0, 1);
            cardTable.Controls.Add(_rowsPanel, 0, 2);
            cardTable.Controls.Add(_paginationPanel, 0, 3);

            card.Controls.Add(cardTable);
            _cardShowtimes = card;
            return card;
        }

        private void PositionPagination()
        {
            if (_paginationPanel == null || _lblPageInfo == null || _pnlPageButtons == null) return;
            int padX = this.S(6);
            _lblPageInfo.Location = new Point(padX, Math.Max(0, (_paginationPanel.Height - _lblPageInfo.Height) / 2));
            _pnlPageButtons.Location = new Point(
                Math.Max(_lblPageInfo.Right + padX, _paginationPanel.Width - _pnlPageButtons.Width - padX),
                Math.Max(0, (_paginationPanel.Height - _pnlPageButtons.Height) / 2));
        }

        private void RenderPagination()
        {
            if (_paginationPanel == null || _pnlPageButtons == null) return;

            int total = _showtimes.Count;
            int totalPages = TotalPages;
            if (_currentPage > totalPages) _currentPage = totalPages;
            if (_currentPage < 1) _currentPage = 1;

            if (total == 0)
            {
                _lblPageInfo.Text = "Hôm nay chưa có suất chiếu";
            }
            else
            {
                int start = (_currentPage - 1) * PageSize + 1;
                int end = Math.Min(_currentPage * PageSize, total);
                _lblPageInfo.Text = $"Hiển thị {start}–{end} / {total} suất chiếu (Trang {_currentPage}/{totalPages})";
            }

            _pnlPageButtons.SuspendLayout();
            _pnlPageButtons.Controls.Clear();

            // Nút lướt trang trước <
            var btnPrev = CreateNavButton("<", _currentPage > 1, () => ChangePage(_currentPage - 1));
            _pnlPageButtons.Controls.Add(btnPrev);

            // Các nút số trang
            var pageNumbers = GetPaginationList(_currentPage, totalPages);
            foreach (var item in pageNumbers)
            {
                if (item == -1)
                {
                    var lblEllipsis = new Label
                    {
                        Text = "...",
                        AutoSize = false,
                        Size = new Size(this.S(24), this.S(30)),
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = AppColors.TextMuted,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Margin = new Padding(this.S(2), 0, this.S(2), 0),
                        BackColor = Color.Transparent
                    };
                    _pnlPageButtons.Controls.Add(lblEllipsis);
                }
                else
                {
                    int p = item;
                    bool isActive = p == _currentPage;
                    var btnPage = CreatePageButton(p.ToString(), isActive, () => ChangePage(p));
                    _pnlPageButtons.Controls.Add(btnPage);
                }
            }

            // Nút lướt trang sau >
            var btnNext = CreateNavButton(">", _currentPage < totalPages, () => ChangePage(_currentPage + 1));
            _pnlPageButtons.Controls.Add(btnNext);

            _pnlPageButtons.ResumeLayout(true);
            PositionPagination();
        }

        private static List<int> GetPaginationList(int current, int total)
        {
            var list = new List<int>();
            if (total <= 7)
            {
                for (int i = 1; i <= total; i++) list.Add(i);
                return list;
            }

            if (current <= 4)
            {
                for (int i = 1; i <= 5; i++) list.Add(i);
                list.Add(-1);
                list.Add(total);
            }
            else if (current >= total - 3)
            {
                list.Add(1);
                list.Add(-1);
                for (int i = total - 4; i <= total; i++) list.Add(i);
            }
            else
            {
                list.Add(1);
                list.Add(-1);
                list.Add(current - 1);
                list.Add(current);
                list.Add(current + 1);
                list.Add(-1);
                list.Add(total);
            }
            return list;
        }

        private PillButton CreatePageButton(string text, bool isActive, Action onClick)
        {
            int btnW = Math.Max(this.S(32), text.Length * this.S(9) + this.S(16));
            var btn = new PillButton
            {
                Text = text,
                Size = new Size(btnW, this.S(30)),
                Radius = 8,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Margin = new Padding(this.S(2), 0, this.S(2), 0),
                Cursor = Cursors.Hand
            };

            if (isActive)
            {
                btn.NormalColor = AppColors.Primary;
                btn.HoverColor = AppColors.Primary;
                btn.PressedColor = AppColors.Primary;
                btn.BorderColor = AppColors.Primary;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.NormalColor = AppColors.Surface2;
                btn.HoverColor = UiKit.Blend(AppColors.Surface2, AppColors.Blue, 0.30f);
                btn.PressedColor = AppColors.InputBackground;
                btn.BorderColor = AppColors.Border;
                btn.ForeColor = AppColors.TextSecondary;
                btn.Click += (s, e) => onClick();
            }

            return btn;
        }

        private PillButton CreateNavButton(string text, bool enabled, Action onClick)
        {
            var btn = new PillButton
            {
                Text = text,
                Size = new Size(this.S(32), this.S(30)),
                Radius = 8,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Margin = new Padding(this.S(2), 0, this.S(2), 0),
                Enabled = enabled,
                Cursor = enabled ? Cursors.Hand : Cursors.Default
            };

            if (enabled)
            {
                btn.NormalColor = AppColors.Surface2;
                btn.HoverColor = UiKit.Blend(AppColors.Surface2, AppColors.Primary, 0.35f);
                btn.PressedColor = AppColors.InputBackground;
                btn.BorderColor = AppColors.Border;
                btn.ForeColor = AppColors.TextPrimary;
                btn.Click += (s, e) => onClick();
            }
            else
            {
                btn.NormalColor = ColorTranslator.FromHtml("#161C2A");
                btn.DisabledColor = ColorTranslator.FromHtml("#161C2A");
                btn.BorderColor = ColorTranslator.FromHtml("#263045");
                btn.ForeColor = ColorTranslator.FromHtml("#4E5D78");
            }

            return btn;
        }

        private void ChangePage(int newPage)
        {
            int totalPages = TotalPages;
            int clamped = Math.Clamp(newPage, 1, totalPages);
            if (clamped == _currentPage) return;
            _currentPage = clamped;
            RenderPagination();
            _rowsPanel?.Invalidate();
        }

        private void HandleMouseWheelPagination(int delta)
        {
            if (delta < 0 && _currentPage < TotalPages)
            {
                ChangePage(_currentPage + 1);
            }
            else if (delta > 0 && _currentPage > 1)
            {
                ChangePage(_currentPage - 1);
            }
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
                string text = "🎬  Hôm nay chưa có suất chiếu nào";
                var rectEmpty = new Rectangle(0, 0, width, height);
                TextRenderer.DrawText(g, text, FontEmpty, rectEmpty, AppColors.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                return;
            }

            int totalPages = TotalPages;
            if (_currentPage > totalPages) _currentPage = totalPages;
            if (_currentPage < 1) _currentPage = 1;

            int startIndex = (_currentPage - 1) * PageSize;
            var pageItems = _showtimes.Skip(startIndex).Take(PageSize).ToList();
            if (pageItems.Count == 0) return;

            int hRow = Math.Max(this.S(36), height / PageSize);

            var (cols, wCols) = CalcColumns(width);
            int padX = this.S(10);
            using var pBorder = new Pen(AppColors.Border);

            for (int i = 0; i < pageItems.Count; i++)
            {
                var dto = pageItems[i];
                int y = i * hRow;

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
                    "Đang chiếu" => (AppColors.SoftBlue, AppColors.InfoSoft),
                    "Đã chiếu" => (AppColors.TextMuted, AppColors.Surface2),
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

                _showtimes = data.SuatChieuSapDienRa.ToList();
                _currentPage = 1;
                RenderPagination();
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

            // Nghiệp vụ nhấn vào các Card thống kê
            _cardSuat.Click += (s, e) => ScrollToShowtimes();
            _cardCheckIn.Click += (s, e) => NavigateTo(StaffPage.CheckIn);
            _cardVe.Click += (s, e) => NavigateTo(StaffPage.Lookup, CinemaManagement.Common.Enums.TicketFilterMode.TodaySales);

            var tip = new ToolTip();
            tip.SetToolTip(_cardSuat, "Danh sách suất chiếu hôm nay • Nhấp để xem danh sách");
            tip.SetToolTip(_cardCheckIn, "Vé đã được check-in hôm nay • Nhấp để mở màn Check-in / xem danh sách vé hôm nay");
            tip.SetToolTip(_cardVe, "Số vé của nghiệp vụ bán vé hôm nay • Nhấp để mở Tra cứu vé hôm nay");
        }

        private void ScrollToShowtimes()
        {
            _currentPage = 1;
            RenderPagination();
            _rowsPanel?.Invalidate();
            _rowsPanel?.Focus();

            if (_cardShowtimes != null)
            {
                var originalBorder = _cardShowtimes.BorderColor;
                _cardShowtimes.BorderColor = AppColors.SoftBlue;
                _cardShowtimes.Invalidate();

                var highlightTimer = new System.Windows.Forms.Timer { Interval = 700 };
                highlightTimer.Tick += (s, e) =>
                {
                    highlightTimer.Stop();
                    highlightTimer.Dispose();
                    if (!_cardShowtimes.IsDisposed)
                    {
                        _cardShowtimes.BorderColor = originalBorder;
                        _cardShowtimes.Invalidate();
                    }
                };
                highlightTimer.Start();
            }
        }

        private async void NavigateTo(StaffPage page, object? param = null)
        {
            Hide();
            try
            {
                object? currentParam = param;
                while (page is not (StaffPage.Home or StaffPage.SignOut))
                {
                    using var next = CreatePage(page, currentParam);
                    if (next is null)
                    {
                        MessageBox.Show("Chức năng này chưa được xây dựng.", "Thông báo");
                        break;
                    }
                    next.ShowDialog();
                    var staffPage = next as IStaffPage;
                    page = staffPage?.NextPage ?? StaffPage.Home;
                    currentParam = staffPage?.NextParam;
                }
            }
            finally
            {
                Show();     // nếu trang con ném lỗi (vd. không đủ quyền) thì Dashboard vẫn hiện lại
            }

            if (page == StaffPage.SignOut) await LogoutAsync();
            else
            {
                _header.RefreshUserInfo();
                _lblWelcome.Text = $"Xin chào, {UserSession.HoTen} 👋";
                await LoadDashboardAsync();      // quay về thì làm mới số liệu
            }
        }

        private static Form? CreatePage(StaffPage page, object? param = null) => page switch
        {
            StaffPage.Booking => new BookingForm(),
            StaffPage.CheckIn => new CheckInForm(),
            StaffPage.Lookup => param is CinemaManagement.Common.Enums.TicketFilterMode mode
                ? new CinemaManagement.UI.Forms.Staff.Lookup.LookupForm(mode)
                : new CinemaManagement.UI.Forms.Staff.Lookup.LookupForm(),
            StaffPage.Profile => new CinemaManagement.UI.Forms.Shared.ProfileForm(),
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

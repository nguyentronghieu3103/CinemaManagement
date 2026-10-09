using CinemaManagement.BLL.Services.Sales;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.UI.Theme;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // BƯỚC 2 của màn Bán vé: chọn suất chiếu (PHASE 2). Dựng bằng code, nằm trong BookingForm.
    public class ShowtimeStepControl : UserControl
    {
        private readonly SaleMovieDto _movie;

        private readonly DateTimePicker _dtpDate = new();
        private readonly Label _lblStatus = new();
        private readonly FlowLayoutPanel _flowShowtimes = new();
        private readonly Label _lblSelected = new();
        private readonly Button _btnNext = new();
        private readonly Dictionary<int, Panel> _cards = new();

        private SaleShowtimeDto? _selectedShowtime;
        private int _loadVersion;

        public event Action? BackRequested;
        // (suất đã chọn) — BookingForm sẽ chuyển sang bước Chọn ghế ở PHASE 3
        public event Action<SaleShowtimeDto>? ShowtimeChosen;

        public ShowtimeStepControl(SaleMovieDto movie, DateTime date)
        {
            _movie = movie;
            Dock = DockStyle.Fill;
            BackColor = AppColors.PageBackground;

            BuildLayout(date);
            Load += async (s, e) => await LoadShowtimesAsync();
        }

        private void BuildLayout(DateTime date)
        {
            _flowShowtimes.Dock = DockStyle.Fill;
            _flowShowtimes.AutoScroll = true;
            _flowShowtimes.Padding = new Padding(24, 12, 24, 12);
            _flowShowtimes.BackColor = AppColors.PageBackground;
            Controls.Add(_flowShowtimes);

            Controls.Add(BuildBottomPanel());
            Controls.Add(BuildTopPanel(date));
        }

        private Panel BuildTopPanel(DateTime date)
        {
            var pnl = new Panel { Dock = DockStyle.Top, Height = 150, BackColor = AppColors.PageBackground };

            var btnBack = new Button
            {
                Text = "← Quay lại",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                BackColor = AppColors.InputBackground,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Left = 24,
                Top = 14,
                Size = new Size(120, 36)
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => BackRequested?.Invoke();
            pnl.Controls.Add(btnBack);

            pnl.Controls.Add(new Label
            {
                Text = "BƯỚC 02 — CHỌN SUẤT CHIẾU",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 170,
                Top = 18
            });

            pnl.Controls.Add(new Label
            {
                Text = _movie.TenPhim,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = AppColors.HeaderBackground,
                AutoSize = true,
                Left = 24,
                Top = 66
            });

            pnl.Controls.Add(new Label
            {
                Text = $"{(string.IsNullOrEmpty(_movie.TheLoai) ? "—" : _movie.TheLoai)}  •  {_movie.ThoiLuong} phút  •  {_movie.DoTuoi}",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = AppColors.TextMuted,
                AutoSize = true,
                Left = 24,
                Top = 98
            });

            pnl.Controls.Add(new Label
            {
                Text = "Ngày chiếu:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 24,
                Top = 124
            });

            _dtpDate.Format = DateTimePickerFormat.Custom;
            _dtpDate.CustomFormat = "dddd, dd/MM/yyyy";
            _dtpDate.MinDate = DateTime.Today;
            _dtpDate.Value = date.Date < DateTime.Today ? DateTime.Today : date.Date;
            _dtpDate.Font = new Font("Segoe UI", 11F);
            _dtpDate.Width = 240;
            _dtpDate.Left = 130;
            _dtpDate.Top = 120;
            _dtpDate.ValueChanged += async (s, e) => await LoadShowtimesAsync();
            pnl.Controls.Add(_dtpDate);

            _lblStatus.AutoSize = true;
            _lblStatus.Font = new Font("Segoe UI", 10F);
            _lblStatus.ForeColor = AppColors.TextMuted;
            _lblStatus.Left = 400;
            _lblStatus.Top = 126;
            pnl.Controls.Add(_lblStatus);

            return pnl;
        }

        private Panel BuildBottomPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 90, BackColor = AppColors.InputBackground };

            _lblSelected.AutoSize = true;
            _lblSelected.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblSelected.ForeColor = AppColors.TextDark;
            _lblSelected.Left = 24;
            _lblSelected.Top = 30;
            _lblSelected.Text = "Chưa chọn suất chiếu";
            pnl.Controls.Add(_lblSelected);

            _btnNext.Text = "TIẾP TỤC CHỌN GHẾ  →";
            _btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _btnNext.ForeColor = Color.White;
            _btnNext.BackColor = AppColors.Primary;
            _btnNext.FlatStyle = FlatStyle.Flat;
            _btnNext.FlatAppearance.BorderSize = 0;
            _btnNext.Cursor = Cursors.Hand;
            _btnNext.Size = new Size(280, 50);
            _btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnNext.Enabled = false;
            _btnNext.Click += (s, e) => { if (_selectedShowtime != null) ShowtimeChosen?.Invoke(_selectedShowtime); };
            pnl.Controls.Add(_btnNext);
            pnl.Resize += (s, e) => _btnNext.Location = new Point(pnl.Width - _btnNext.Width - 24, 20);
            _btnNext.Location = new Point(pnl.Width - _btnNext.Width - 24, 20);

            return pnl;
        }

        // ================= TẢI DỮ LIỆU =================
        // BookingForm gọi khi quay lại từ bước Chọn ghế để cập nhật số ghế còn trống
        public Task ReloadAsync() => LoadShowtimesAsync();

        private async Task LoadShowtimesAsync()
        {
            int version = ++_loadVersion;
            try
            {
                using var scope = Program.Services.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<ISaleCatalogService>();
                var result = await service.GetShowtimesForSaleAsync(_movie.MovieId, _dtpDate.Value.Date);

                if (version != _loadVersion || IsDisposed) return;

                if (!result.IsSuccess)
                {
                    ShowShowtimes(new List<SaleShowtimeDto>());
                    _lblStatus.Text = result.ErrorMessage;
                    return;
                }

                ShowShowtimes(result.Data!);
                _lblStatus.Text = result.Data!.Count == 0
                    ? "Không còn suất chiếu nào trong ngày này."
                    : $"Có {result.Data.Count} suất chiếu";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tải được danh sách suất chiếu");
                if (!IsDisposed) _lblStatus.Text = "Lỗi tải suất chiếu. Vui lòng thử lại.";
            }
        }

        private void ShowShowtimes(List<SaleShowtimeDto> showtimes)
        {
            _flowShowtimes.SuspendLayout();
            foreach (Control old in _flowShowtimes.Controls.OfType<Control>().ToList())
                old.Dispose();
            _flowShowtimes.Controls.Clear();
            _cards.Clear();

            foreach (var st in showtimes)
            {
                var card = CreateShowtimeCard(st);
                _cards[st.ShowtimeId] = card;
                _flowShowtimes.Controls.Add(card);
            }
            _flowShowtimes.ResumeLayout();

            // Giữ lại lựa chọn cũ nếu suất đó vẫn còn và còn ghế, ngược lại bỏ chọn
            var stillThere = showtimes.FirstOrDefault(s => s.ShowtimeId == _selectedShowtime?.ShowtimeId && s.GheConTrong > 0);
            SelectShowtime(stillThere);
        }

        private Panel CreateShowtimeCard(SaleShowtimeDto st)
        {
            bool soldOut = st.GheConTrong <= 0;

            var card = new Panel
            {
                Width = 300,
                Height = 150,
                Margin = new Padding(10),
                BackColor = Color.White,
                Cursor = soldOut ? Cursors.No : Cursors.Hand
            };

            card.Controls.Add(new Label
            {
                Text = st.GioBatDau.ToString(@"hh\:mm"),
                Left = 14,
                Top = 12,
                AutoSize = true,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = soldOut ? AppColors.TextMuted : AppColors.TextDark
            });

            card.Controls.Add(new Label
            {
                Text = st.TenPhong,
                Left = 180,
                Top = 18,
                Width = 106,
                Height = 24,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = AppColors.HeaderBackground,
                BackColor = AppColors.InputBackground,
                AutoEllipsis = true
            });

            card.Controls.Add(new Label
            {
                Text = $"Dự kiến kết thúc: {st.GioKetThuc:hh\\:mm}",
                Left = 14,
                Top = 66,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = AppColors.TextMuted
            });

            // Màu cảnh báo theo tỉ lệ ghế còn lại
            string seatText;
            Color seatColor;
            if (soldOut)
            {
                seatText = "Hết chỗ";
                seatColor = AppColors.StatusRed;
            }
            else if (st.TongGhe > 0 && st.GheConTrong <= st.TongGhe * 0.15)
            {
                seatText = $"Chỉ còn {st.GheConTrong}/{st.TongGhe} ghế!";
                seatColor = AppColors.StatusRed;
            }
            else
            {
                seatText = $"Còn {st.GheConTrong}/{st.TongGhe} ghế";
                seatColor = AppColors.TextDark;
            }

            card.Controls.Add(new Label
            {
                Text = seatText,
                Left = 14,
                Top = 92,
                AutoSize = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = seatColor
            });

            card.Controls.Add(new Label
            {
                Text = $"Giá cơ bản: {st.GiaVeCoSo:N0} đ",
                Left = 14,
                Top = 120,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = AppColors.TextMuted
            });

            if (soldOut)
            {
                card.BackColor = Color.FromArgb(238, 238, 238);   // suất hết chỗ: xám, không cho chọn
            }
            else
            {
                AttachClickRecursive(card, () => SelectShowtime(st));
                AttachDoubleClickRecursive(card, () => { SelectShowtime(st); _btnNext.PerformClick(); });
            }
            return card;
        }

        private static void AttachClickRecursive(Control control, Action onClick)
        {
            control.Click += (s, e) => onClick();
            foreach (Control child in control.Controls) AttachClickRecursive(child, onClick);
        }

        private static void AttachDoubleClickRecursive(Control control, Action onDoubleClick)
        {
            control.DoubleClick += (s, e) => onDoubleClick();
            foreach (Control child in control.Controls) AttachDoubleClickRecursive(child, onDoubleClick);
        }

        private void SelectShowtime(SaleShowtimeDto? st)
        {
            _selectedShowtime = st;

            foreach (var (id, card) in _cards)
            {
                bool isSelected = id == st?.ShowtimeId;
                // Chỉ đổi màu thẻ còn chỗ; thẻ hết chỗ giữ màu xám
                if (card.Cursor == Cursors.No) continue;
                card.BackColor = isSelected ? AppColors.InputBackground : Color.White;
            }

            _btnNext.Enabled = st != null;
            _lblSelected.Text = st == null
                ? "Chưa chọn suất chiếu"
                : $"Đã chọn: {_movie.TenPhim}  •  {st.GioBatDau:hh\\:mm}  •  {st.NgayChieu:dd/MM/yyyy}  •  {st.TenPhong}  •  Giá cơ bản {st.GiaVeCoSo:N0} đ";
        }
    }
}

using CinemaManagement.BLL.Services.Sales;
using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.UI.Helpers;
using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Theme;
using CinemaManagement.UI.UserControls.Common;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // Màn Bán vé: BƯỚC 1 Chọn phim (Phase 1) → BƯỚC 2 Chọn suất chiếu (Phase 2).
    // Các bước sau (ghế, combo, thanh toán) sẽ bổ sung ở các phase tiếp theo.
    // BƯỚC 3 Chọn ghế + giữ ghế 5 phút (Phase 3).
    // BƯỚC 4 Combo + Giỏ hàng + tính tiền (Phase 4).
    // BƯỚC 5 Khách hàng + Thanh toán tiền mặt + tạo Hóa đơn (Phase 5).
    // BƯỚC 6 Tạo Vé + QR, ghế DangGiu → DaDat, màn Thanh toán thành công, reset cho giao dịch mới (Phase 6).
    // Mỗi bước là 1 panel/UserControl nằm trong _stepHost, đổi bước bằng cách thay nội dung _stepHost.
    // Form dựng hoàn toàn bằng code (không có file Designer) để dễ đọc và không xung đột Git.
    public class BookingForm : Form, IStaffPage
    {
        private readonly StaffHeaderControl _header = new() { ActivePage = StaffPage.Booking };

        private readonly CinemaBackdropPanel _stepHost = new() { Dock = DockStyle.Fill };     // nền glow điện ảnh cho mọi bước
        private readonly Panel _pnlMovieStep = new() { Dock = DockStyle.Fill, BackColor = Color.Transparent };
        private ShowtimeStepControl? _showtimeStep;
        private SeatSelectionStepControl? _seatStep;
        private ComboCartStepControl? _comboStep;
        private PaymentStepControl? _paymentStep;
        private CheckoutSuccessStepControl? _successStep;
        // ComboId -> số lượng. Giữ ở đây để nhân viên quay lại bước ghế rồi vào lại vẫn còn combo đã chọn
        private readonly Dictionary<int, int> _comboQuantities = new();
        private CartDto? _confirmedCart;     // giỏ hàng đã được backend xác nhận, bàn giao cho bước Thanh toán (Phase 5)
        private SaleMovieDto? _currentMovie;         // phim + suất của đơn đang bán, để dựng bước Thanh toán
        private SaleShowtimeDto? _currentShowtime;
        private SaleCustomerDto? _selectedCustomer;  // khách đã chọn ở bước Thanh toán; giữ lại khi nhân viên quay lại Combo rồi vào lại
        private CheckoutResultDto? _checkoutResult;  // kết quả thanh toán tiền mặt thành công; Phase 6 (Tạo vé + QR) sẽ dùng

        private readonly DateTimePicker _dtpDate = new();
        private readonly TextBox _txtSearch = new();
        private readonly Label _lblCount = new();
        private readonly FlowLayoutPanel _flowMovies = new();
        private readonly Label _lblSelected = new();
        private readonly PillButton _btnChoose = new();
        private readonly System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };

        private readonly Dictionary<int, Panel> _cards = new();
        private SaleMovieDto? _selectedMovie;
        private int _loadVersion;      // chống kết quả cũ ghi đè kết quả mới khi gõ tìm kiếm nhanh

        public StaffPage NextPage { get; private set; } = StaffPage.Home;

        public BookingForm()
        {
            // Chặn bằng code TRƯỚC khi dựng giao diện (giống CheckInForm)
            PermissionGuard.EnsurePermission(PermissionConstants.TICKET_SELL);

            Text = "Bán vé — Chọn phim";
            BackColor = AppColors.PageBackground;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1000, 640);

            BuildLayout();
            WireEvents();
        }

        // ================= GIAO DIỆN =================
        private void BuildLayout()
        {
            // Thứ tự Add quan trọng: Fill trước, các cạnh sau, header cuối cùng rồi SendToBack.
            _flowMovies.Dock = DockStyle.Fill;
            _flowMovies.AutoScroll = true;
            _flowMovies.Padding = new Padding(24, 12, 24, 12);
            _flowMovies.BackColor = AppColors.PageBackground;
            _pnlMovieStep.Controls.Add(_flowMovies);
            _pnlMovieStep.Controls.Add(BuildBottomPanel());
            _pnlMovieStep.Controls.Add(BuildFilterPanel());
            _stepHost.Controls.Add(_pnlMovieStep);
            Controls.Add(_stepHost);

            _header.NavigateRequested += page => { NextPage = page; Close(); };
            _header.LogoutRequested += () => { NextPage = StaffPage.SignOut; Close(); };
            Controls.Add(_header);
            _header.SendToBack();      // header luôn nằm trên cùng
        }

        private Panel BuildFilterPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Top, Height = 110, BackColor = Color.Transparent, Padding = new Padding(24, 10, 24, 0) };

            pnl.Controls.Add(new Label
            {
                Text = "BƯỚC 01 — CHỌN PHIM TRÌNH CHIẾU",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 24,
                Top = 10
            });

            pnl.Controls.Add(new Label
            {
                Text = "Ngày:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 24,
                Top = 62
            });

            _dtpDate.Format = DateTimePickerFormat.Custom;
            _dtpDate.CustomFormat = "dd/MM/yyyy";
            _dtpDate.MinDate = DateTime.Today;             // không bán vé cho ngày đã qua
            _dtpDate.Font = new Font("Segoe UI", 11F);
            _dtpDate.CalendarMonthBackground = AppColors.CardBackground;
            _dtpDate.CalendarForeColor = AppColors.TextPrimary;
            _dtpDate.CalendarTitleBackColor = AppColors.Primary;
            _dtpDate.CalendarTitleForeColor = Color.White;
            _dtpDate.CalendarTrailingForeColor = AppColors.TextMuted;
            _dtpDate.Width = 140;
            _dtpDate.Left = 80;
            _dtpDate.Top = 58;
            pnl.Controls.Add(_dtpDate);

            pnl.Controls.Add(new Label
            {
                Text = "Tìm phim:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 260,
                Top = 62
            });

            _txtSearch.Font = new Font("Segoe UI", 11F);
            _txtSearch.Width = 280;
            _txtSearch.Left = 350;
            _txtSearch.Top = 58;
            _txtSearch.BackColor = AppColors.InputBackground;
            _txtSearch.ForeColor = AppColors.TextPrimary;
            _txtSearch.PlaceholderText = "Nhập tên phim...";
            pnl.Controls.Add(_txtSearch);

            _lblCount.AutoSize = true;
            _lblCount.Font = new Font("Segoe UI", 10F);
            _lblCount.ForeColor = AppColors.TextMuted;
            _lblCount.Left = 660;
            _lblCount.Top = 63;
            pnl.Controls.Add(_lblCount);

            return pnl;
        }

        private Panel BuildBottomPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 90, BackColor = AppColors.CardBackground };

            _lblSelected.AutoSize = true;
            _lblSelected.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblSelected.ForeColor = AppColors.TextDark;
            _lblSelected.Left = 24;
            _lblSelected.Top = 30;
            _lblSelected.Text = "Chưa chọn phim";
            pnl.Controls.Add(_lblSelected);

            _btnChoose.Text = "CHỌN PHIM  →";
            _btnChoose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _btnChoose.ForeColor = Color.White;
            _btnChoose.BackColor = AppColors.Primary;
            _btnChoose.FlatStyle = FlatStyle.Flat;
            _btnChoose.FlatAppearance.BorderSize = 0;
            _btnChoose.Cursor = Cursors.Hand;
            _btnChoose.Size = new Size(220, 50);
            _btnChoose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnChoose.Enabled = false;
            pnl.Controls.Add(_btnChoose);
            pnl.Resize += (s, e) => _btnChoose.Location = new Point(pnl.Width - _btnChoose.Width - 24, 20);
            _btnChoose.Location = new Point(pnl.Width - _btnChoose.Width - 24, 20);

            return pnl;
        }

        // ================= SỰ KIỆN =================
        private void WireEvents()
        {
            _dtpDate.ValueChanged += async (s, e) => await LoadMoviesAsync();

            // Debounce: đợi 300ms sau lần gõ cuối mới tìm, tránh truy vấn mỗi phím
            _txtSearch.TextChanged += (s, e) => { _searchTimer.Stop(); _searchTimer.Start(); };
            _searchTimer.Tick += async (s, e) => { _searchTimer.Stop(); await LoadMoviesAsync(); };

            _btnChoose.Click += (s, e) => ConfirmMovie();
            Shown += async (s, e) => await LoadMoviesAsync();
            // Đang gọi backend thanh toán thì không cho đóng form (tránh mất kết quả / nhả ghế giữa chừng khi hóa đơn đang được tạo)
            FormClosing += (s, e) =>
            {
                if (_paymentStep?.IsCheckingOut != true) return;
                e.Cancel = true;
                MessageBox.Show("Đang xử lý thanh toán, vui lòng đợi trong giây lát.", "Bán vé",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            FormClosed += (s, e) =>
            {
                RemoveSuccessStep();
                RemovePaymentStep();                    // dừng timer của bước thanh toán
                RemoveComboStep();                      // dừng timer của bước combo
                _seatStep?.ReleaseHoldInBackground();   // đóng form giữa chừng → nhả ghế đang giữ
                _searchTimer.Dispose();
            };
        }

        private async Task LoadMoviesAsync()
        {
            int version = ++_loadVersion;
            try
            {
                // Mỗi lần tải dùng 1 scope riêng để luôn đọc dữ liệu mới từ DB
                using var scope = Program.Services.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<ISaleCatalogService>();
                var result = await service.GetMoviesForSaleAsync(_dtpDate.Value.Date, _txtSearch.Text);

                if (version != _loadVersion || IsDisposed) return;   // đã có lần tải mới hơn

                if (!result.IsSuccess)
                {
                    ShowMovies(new List<SaleMovieDto>());
                    _lblCount.Text = result.ErrorMessage;
                    return;
                }

                ShowMovies(result.Data!);
                _lblCount.Text = $"Hiển thị {result.Data!.Count} phim có suất chiếu";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tải được danh sách phim để bán vé");
                if (!IsDisposed) _lblCount.Text = "Lỗi tải danh sách phim. Vui lòng thử lại.";
            }
        }

        private void ShowMovies(List<SaleMovieDto> movies)
        {
            _flowMovies.SuspendLayout();
            foreach (Control old in _flowMovies.Controls.OfType<Control>().ToList())
                old.Dispose();
            _flowMovies.Controls.Clear();
            _cards.Clear();

            foreach (var movie in movies)
            {
                var card = CreateMovieCard(movie);
                _cards[movie.MovieId] = card;
                _flowMovies.Controls.Add(card);
            }
            _flowMovies.ResumeLayout();

            // Giữ lại lựa chọn cũ nếu phim đó vẫn còn trong danh sách mới, ngược lại bỏ chọn
            var stillThere = movies.FirstOrDefault(m => m.MovieId == _selectedMovie?.MovieId);
            SelectMovie(stillThere);
        }

        private Panel CreateMovieCard(SaleMovieDto movie)
        {
            var card = new SurfacePanel
            {
                Width = 230,
                Height = 400,
                Margin = new Padding(10),
                BackColor = AppColors.CardBackground,
                Cursor = Cursors.Hand,
                Tag = movie
            };

            var pic = new PictureBox
            {
                Left = 10,
                Top = 10,
                Width = 210,
                Height = 280,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = AppColors.InputBackground
            };
            LoadPoster(pic, movie.Poster);
            card.Controls.Add(pic);

            card.Controls.Add(new Label
            {
                Text = movie.TenPhim,
                Left = 10,
                Top = 298,
                Width = 210,
                Height = 26,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoEllipsis = true
            });

            card.Controls.Add(new Label
            {
                Text = string.IsNullOrEmpty(movie.TheLoai) ? "—" : movie.TheLoai,
                Left = 10,
                Top = 326,
                Width = 210,
                Height = 22,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = AppColors.TextMuted,
                AutoEllipsis = true
            });

            card.Controls.Add(new Label
            {
                Text = $"{movie.ThoiLuong} phút  •  {movie.DoTuoi}  •  {movie.SoSuatConLai} suất",
                Left = 10,
                Top = 352,
                Width = 210,
                Height = 22,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = AppColors.TextDark
            });

            AttachClickRecursive(card, () => SelectMovie(movie));
            AttachDoubleClickRecursive(card, () => { SelectMovie(movie); ConfirmMovie(); });
            return card;
        }

        private static void LoadPoster(PictureBox pic, string? path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                try
                {
                    // Đọc rồi copy sang Bitmap để không khóa file poster trên đĩa
                    using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using var img = Image.FromStream(fs);
                    pic.Image = new Bitmap(img);
                    return;
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "Không đọc được poster {Path}", path);
                }
            }

            pic.Controls.Add(new Label
            {
                Text = "Chưa có poster",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AppColors.TextMuted
            });
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

        // ================= CHỌN PHIM =================
        private void SelectMovie(SaleMovieDto? movie)
        {
            _selectedMovie = movie;

            foreach (var (id, card) in _cards)
                card.BackColor = id == movie?.MovieId ? AppColors.RowSelected : AppColors.CardBackground;

            _btnChoose.Enabled = movie != null;
            _lblSelected.Text = movie == null
                ? "Chưa chọn phim"
                : $"Phim đã chọn: {movie.TenPhim} ({movie.TheLoai} • {movie.ThoiLuong} phút)";
        }

        private void ConfirmMovie()
        {
            if (_selectedMovie == null) return;

            ShowShowtimeStep(_selectedMovie, _dtpDate.Value.Date);
        }

        // ================= CHUYỂN BƯỚC =================
        private void ShowShowtimeStep(SaleMovieDto movie, DateTime date)
        {
            Text = "Bán vé — Chọn suất chiếu";

            _showtimeStep = new ShowtimeStepControl(movie, date);
            _showtimeStep.BackRequested += BackToMovieStep;
            _showtimeStep.ShowtimeChosen += showtime => ShowSeatStep(movie, showtime);

            _pnlMovieStep.Visible = false;
            _stepHost.Controls.Add(_showtimeStep);
            _showtimeStep.BringToFront();
        }

        private void ShowSeatStep(SaleMovieDto movie, SaleShowtimeDto showtime)
        {
            Text = "Bán vé — Chọn ghế";

            _currentMovie = movie;
            _currentShowtime = showtime;
            _seatStep = new SeatSelectionStepControl(movie, showtime);
            _seatStep.BackRequested += BackToShowtimeStep;
            _seatStep.SeatsConfirmed += hold => ShowComboStep(movie, showtime, hold);
            _seatStep.HoldExpired += HandleSeatStepHoldExpired;

            _showtimeStep!.Visible = false;
            _stepHost.Controls.Add(_seatStep);
            _seatStep.BringToFront();
        }

        // ================= BƯỚC 4: COMBO + GIỎ HÀNG (PHASE 4) =================
        private void ShowComboStep(SaleMovieDto movie, SaleShowtimeDto showtime, SeatHoldDto hold)
        {
            if (_comboStep != null || _seatStep == null) return;     // đã ở bước combo rồi thì bỏ qua

            Text = "Bán vé — Combo & Giỏ hàng";

            _comboStep = new ComboCartStepControl(movie, showtime, hold, _comboQuantities);
            _comboStep.BackRequested += BackToSeatStep;
            _comboStep.CartConfirmed += OnCartConfirmed;
            _comboStep.HoldLost += HandleComboStepHoldLost;

            // Bước ghế chỉ bị ẩn, KHÔNG dispose: phiên giữ ghế và timer của nó vẫn chạy trong lúc chọn combo
            _seatStep.Visible = false;
            _stepHost.Controls.Add(_comboStep);
            _comboStep.BringToFront();
        }

        private void RemoveComboStep()
        {
            if (_comboStep == null) return;
            _stepHost.Controls.Remove(_comboStep);
            _comboStep.Dispose();
            _comboStep = null;
        }

        // Nhân viên bấm "Quay lại" ở bước combo: về bước ghế, ghế vẫn đang được giữ và đếm ngược tiếp
        private void BackToSeatStep()
        {
            RemoveComboStep();
            _confirmedCart = null;
            Text = "Bán vé — Chọn ghế";
            if (_seatStep != null) _seatStep.Visible = true;
        }

        // Bước combo phát hiện phiên giữ ghế đã mất (hết hạn / không còn hợp lệ)
        private void HandleComboStepHoldLost(string message)
        {
            if (_comboStep == null) return;
            if (_paymentStep?.IsCheckingOut == true) return;    // đang thanh toán: backend sẽ quyết định ghế còn giữ hay không

            RemovePaymentStep();
            RemoveComboStep();
            _confirmedCart = null;
            Text = "Bán vé — Chọn ghế";
            if (_seatStep != null)
            {
                _seatStep.Visible = true;
                _ = _seatStep.NotifyHoldLostAsync(message);      // bước ghế reset phiên giữ + tải lại sơ đồ ghế từ database
            }

            MessageBox.Show($"{message}\n\nVui lòng chọn lại ghế.", "Bán vé",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Bước ghế (vẫn chạy ngầm) tự phát hiện hết hạn/mất phiên giữ trong lúc nhân viên đang ở bước combo
        private void HandleSeatStepHoldExpired()
        {
            _confirmedCart = null;
            if (_comboStep == null) return;      // đang ở bước ghế: chính bước ghế đã tự thông báo và làm mới sơ đồ
            if (_paymentStep?.IsCheckingOut == true) return;    // đang thanh toán: backend sẽ quyết định ghế còn giữ hay không

            RemovePaymentStep();
            RemoveComboStep();
            Text = "Bán vé — Chọn ghế";
            if (_seatStep != null) _seatStep.Visible = true;

            MessageBox.Show("Đã hết thời gian giữ ghế (hoặc ghế không còn được giữ).\n\nVui lòng chọn lại ghế.", "Bán vé",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Giỏ hàng đã được backend xác nhận (Phase 4) → sang bước Thanh toán (Phase 5)
        private void OnCartConfirmed(CartDto cart)
        {
            _confirmedCart = cart;
            ShowPaymentStep(cart);
        }

        // ================= BƯỚC 5: KHÁCH HÀNG + THANH TOÁN TIỀN MẶT (PHASE 5) =================
        private void ShowPaymentStep(CartDto cart)
        {
            if (_paymentStep != null || _comboStep == null || _currentMovie == null || _currentShowtime == null) return;

            Text = "Bán vé — Thanh toán";

            _paymentStep = new PaymentStepControl(_currentMovie, _currentShowtime, cart, _selectedCustomer);
            _paymentStep.BackRequested += BackToComboStep;
            _paymentStep.HoldLost += HandlePaymentStepHoldLost;
            _paymentStep.CheckoutCompleted += OnCheckoutCompleted;

            // Bước combo (và bước ghế) chỉ bị ẩn, KHÔNG dispose: giỏ hàng + phiên giữ ghế + timer của chúng vẫn nguyên
            _comboStep.Visible = false;
            _stepHost.Controls.Add(_paymentStep);
            _paymentStep.BringToFront();
        }

        private void RemovePaymentStep()
        {
            if (_paymentStep == null) return;
            _stepHost.Controls.Remove(_paymentStep);
            _paymentStep.Dispose();
            _paymentStep = null;
        }

        // Nhân viên bấm "Quay lại" ở bước thanh toán: về bước combo, giỏ hàng (combo đã chọn) và ghế đang giữ vẫn còn
        private void BackToComboStep()
        {
            if (_paymentStep == null) return;

            _selectedCustomer = _paymentStep.SelectedCustomer;   // nhớ khách đã chọn
            RemovePaymentStep();
            _confirmedCart = null;                               // bấm Tiếp tục ở bước combo để backend xác nhận lại giỏ hàng
            Text = "Bán vé — Combo & Giỏ hàng";
            if (_comboStep != null) _comboStep.Visible = true;
        }

        // Bước thanh toán phát hiện phiên giữ ghế đã mất → cùng cách xử lý như bước combo (về bước chọn ghế, tải lại sơ đồ)
        private void HandlePaymentStepHoldLost(string message) => HandleComboStepHoldLost(message);

        // Giao dịch đã commit trọn vẹn: Hóa đơn + Thanh toán + Vé + ghế DaDat (Phase 6)
        private void OnCheckoutCompleted(CheckoutResultDto result)
        {
            _checkoutResult = result;
            _selectedCustomer = _paymentStep?.SelectedCustomer;

            // Ghế đã là DaDat trong database. Bước ghế dừng timer (không còn phiên giữ để nhả);
            // bước combo bị dỡ để timer của nó không kéo nhân viên về bước chọn ghế sau khi đã thu tiền.
            _seatStep?.CompleteHold();
            RemoveComboStep();
            ShowSuccessStep(result);
        }

        private void ShowSuccessStep(CheckoutResultDto result)
        {
            if (_successStep != null || _currentMovie == null || _currentShowtime == null) return;

            Text = "Bán vé — Thanh toán thành công";

            string customerText = _selectedCustomer == null
                ? "Khách vãng lai"
                : $"{_selectedCustomer.HoTen} ({_selectedCustomer.SDT})";

            _successStep = new CheckoutSuccessStepControl(_currentMovie, _currentShowtime, result, customerText);
            _successStep.NewSaleRequested += StartNewSale;
            _successStep.CloseRequested += () => { NextPage = StaffPage.Home; Close(); };

            if (_paymentStep != null) _paymentStep.Visible = false;    // dỡ hẳn khi bắt đầu đơn mới
            _stepHost.Controls.Add(_successStep);
            _successStep.BringToFront();
        }

        private void RemoveSuccessStep()
        {
            if (_successStep == null) return;
            _stepHost.Controls.Remove(_successStep);
            _successStep.Dispose();
            _successStep = null;
        }

        // ================= RESET CHO GIAO DỊCH MỚI (PHASE 6) =================
        // Dỡ toàn bộ các bước và xóa mọi trạng thái của đơn cũ. Dữ liệu đã bán nằm trong database nên không bị mất.
        private void StartNewSale()
        {
            if (_paymentStep?.IsCheckingOut == true) return;

            RemoveSuccessStep();
            RemovePaymentStep();
            RemoveComboStep();

            if (_seatStep != null)
            {
                _seatStep.CompleteHold();       // đảm bảo timer đã dừng, không nhả ghế nào (ghế đã DaDat)
                _stepHost.Controls.Remove(_seatStep);
                _seatStep.Dispose();
                _seatStep = null;
            }
            if (_showtimeStep != null)
            {
                _stepHost.Controls.Remove(_showtimeStep);
                _showtimeStep.Dispose();
                _showtimeStep = null;
            }

            _comboQuantities.Clear();
            _confirmedCart = null;
            _selectedCustomer = null;
            _checkoutResult = null;
            _currentMovie = null;
            _currentShowtime = null;

            Text = "Bán vé — Chọn phim";
            _pnlMovieStep.Visible = true;
            _ = LoadMoviesAsync();              // số ghế còn trống/số suất đã thay đổi sau khi bán
        }

        private void BackToShowtimeStep()
        {
            // Đổi suất chiếu = bắt đầu đơn mới: bỏ combo đã chọn
            _comboQuantities.Clear();
            _confirmedCart = null;
            _selectedCustomer = null;

            if (_seatStep != null)
            {
                _stepHost.Controls.Remove(_seatStep);
                _seatStep.Dispose();
                _seatStep = null;
            }

            Text = "Bán vé — Chọn suất chiếu";
            if (_showtimeStep != null)
            {
                _showtimeStep.Visible = true;
                _ = _showtimeStep.ReloadAsync();     // số ghế còn trống có thể đã đổi
            }
        }

        private void BackToMovieStep()
        {
            _comboQuantities.Clear();
            _confirmedCart = null;
            _selectedCustomer = null;

            if (_showtimeStep != null)
            {
                _stepHost.Controls.Remove(_showtimeStep);
                _showtimeStep.Dispose();
                _showtimeStep = null;
            }
            Text = "Bán vé — Chọn phim";
            _pnlMovieStep.Visible = true;
        }
    }
}

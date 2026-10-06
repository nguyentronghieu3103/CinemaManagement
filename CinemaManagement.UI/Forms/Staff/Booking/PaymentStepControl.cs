using CinemaManagement.BLL.Services.Sales;
using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Results;
using CinemaManagement.UI.Helpers;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // BƯỚC 5 của màn Bán vé: Khách hàng + Thanh toán TIỀN MẶT + tạo Hóa đơn (PHASE 5).
    // - Nhận CartDto đã được backend xác nhận ở Phase 4. Số tiền hiển thị ở đây CHỈ để nhân viên xem;
    //   khi bấm "Xác nhận thanh toán", ICheckoutService kiểm tra lại phiên giữ ghế và TÍNH LẠI toàn bộ tiền từ database.
    // - PHASE 6: backend tạo Hóa đơn + Thanh toán + Vé + QR và chuyển ghế DangGiu → DaDat trong CÙNG 1 transaction;
    //   CheckoutCompleted chỉ phát ra sau khi tất cả đã commit.
    // - Không có VNPay / thanh toán online ở phase này.
    public class PaymentStepControl : UserControl
    {
        private static readonly decimal[] QuickAmounts = { 100_000m, 200_000m, 500_000m, 1_000_000m };

        private readonly SaleMovieDto _movie;
        private readonly SaleShowtimeDto _showtime;
        private readonly CartDto _cart;                       // giỏ đã được backend xác nhận (Phase 4)
        private readonly bool _canCreateCustomer;

        private SaleCustomerDto? _customer;

        // Header / điều hướng
        private readonly PillButton _btnBack = new();

        // Tóm tắt đơn (bên trái)
        private readonly ListView _lvItems = new();
        private readonly Label _lblTicketTotal = new();
        private readonly Label _lblComboTotal = new();
        private readonly Label _lblGrandTotal = new();

        // Khách hàng
        private readonly Label _lblCustomer = new();
        private readonly PillButton _btnClearCustomer = new();
        private readonly TextBox _txtSearch = new();
        private readonly PillButton _btnSearch = new();
        private readonly ListView _lvCustomers = new();
        private readonly Label _lblSearchStatus = new();
        private readonly PillButton _btnPick = new();
        private readonly TextBox _txtName = new();
        private readonly TextBox _txtPhone = new();
        private readonly TextBox _txtEmail = new();
        private readonly PillButton _btnCreate = new();
        private readonly Label _lblCreateStatus = new();
        private readonly ErrorProvider _errors = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        // Thanh toán tiền mặt
        private readonly RadioButton _rdoCash = new();
        private readonly TextBox _txtReceived = new();
        private readonly List<PillButton> _quickButtons = new();
        private readonly Label _lblChange = new();

        // Thanh dưới
        private readonly Label _lblMessage = new();
        private readonly Label _lblCountdown = new();
        private readonly PillButton _btnConfirm = new();

        private readonly System.Windows.Forms.Timer _countdownTimer = new() { Interval = 1000 };

        private bool _busy;
        private bool _expired;          // phiên giữ ghế đã hết hạn / mất → khóa toàn bộ thao tác
        private bool _paid;             // đã thanh toán thành công → khóa để không tạo hóa đơn thứ hai
        private bool _receivedOk;       // tiền khách đưa hợp lệ và đủ

        public event Action? BackRequested;
        // Phiên giữ ghế không còn hợp lệ → BookingForm đưa nhân viên về bước chọn ghế
        public event Action<string>? HoldLost;
        // Hóa đơn + Thanh toán + Vé đã commit → BookingForm hiện màn Thanh toán thành công
        public event Action<CheckoutResultDto>? CheckoutCompleted;

        // BookingForm dùng để KHÔNG dỡ bước này (và không nhả ghế) khi đang giữa lúc gọi backend thanh toán
        public bool IsCheckingOut { get; private set; }
        public SaleCustomerDto? SelectedCustomer => _customer;

        public PaymentStepControl(SaleMovieDto movie, SaleShowtimeDto showtime, CartDto cart, SaleCustomerDto? initialCustomer)
        {
            _movie = movie;
            _showtime = showtime;
            _cart = cart;
            _customer = initialCustomer;
            _canCreateCustomer = PermissionGuard.HasPermission(PermissionConstants.CUSTOMER_CREATE);

            Dock = DockStyle.Fill;
            BackColor = Color.Transparent;
            _errors.ContainerControl = this;

            BuildLayout();
            WireEvents();

            SetCustomer(_customer);
            FillOrderSummary();
            UpdateChange();
        }

        // ================= GIAO DIỆN =================
        private void BuildLayout()
        {
            // Thứ tự Add: Fill trước, rồi Left, Bottom, cuối cùng Top (giống các bước trước)
            Controls.Add(BuildCenterPanel());
            Controls.Add(BuildLeftPanel());
            Controls.Add(BuildBottomPanel());
            Controls.Add(BuildTopPanel());
        }

        private Panel BuildTopPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Top, Height = 96, BackColor = Color.Transparent };

            StyleButton(_btnBack, AppColors.Surface2, AppColors.TextPrimary);
            _btnBack.Text = "← Quay lại";
            _btnBack.Size = new Size(120, 36);
            _btnBack.Location = new Point(24, 14);
            pnl.Controls.Add(_btnBack);

            pnl.Controls.Add(new Label
            {
                Text = "BƯỚC 05 — THANH TOÁN",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 170,
                Top = 18
            });

            pnl.Controls.Add(new Label
            {
                Text = $"{_movie.TenPhim}   •   {_showtime.NgayChieu:dd/MM/yyyy}   •   {_showtime.GioBatDau:hh\\:mm} - {_showtime.GioKetThuc:hh\\:mm}   •   {_showtime.TenPhong}",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = AppColors.TextPrimary,
                AutoSize = true,
                Left = 24,
                Top = 62
            });

            return pnl;
        }

        // ---- Bên trái: thông tin vé + combo + tổng tiền ----
        private Panel BuildLeftPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Left, Width = 470, BackColor = AppColors.CardBackground };

            var listHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16, 6, 16, 6), BackColor = AppColors.CardBackground };
            ConfigureItemList();
            listHost.Controls.Add(_lvItems);
            pnl.Controls.Add(listHost);

            pnl.Controls.Add(BuildSummaryPanel());
            pnl.Controls.Add(BuildInfoPanel());
            return pnl;
        }

        private Panel BuildInfoPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Top, Height = 190, BackColor = AppColors.CardBackground };
            pnl.Controls.Add(MakeCaption("THÔNG TIN VÉ & DỊCH VỤ", 10, 10F, FontStyle.Bold));

            string seats = string.Join(", ", _cart.Seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot).Select(s => s.Label));
            string combos = _cart.Combos.Count == 0
                ? "Không có"
                : string.Join(", ", _cart.Combos.Select(c => $"{c.TenCombo} x{c.SoLuong}"));

            AddInfoRow(pnl, "Phim", _movie.TenPhim, 40, 24);
            AddInfoRow(pnl, "Suất chiếu", $"{_showtime.NgayChieu:dd/MM/yyyy}  {_showtime.GioBatDau:hh\\:mm} - {_showtime.GioKetThuc:hh\\:mm}", 68, 24);
            AddInfoRow(pnl, "Phòng", _showtime.TenPhong, 96, 24);
            AddInfoRow(pnl, "Ghế", seats, 124, 24);
            AddInfoRow(pnl, "Combo", combos, 152, 24);
            return pnl;
        }

        private static void AddInfoRow(Panel pnl, string caption, string value, int top, int height)
        {
            pnl.Controls.Add(new Label
            {
                Text = caption,
                Left = 16,
                Top = top + 2,
                Width = 90,
                Height = height,
                Font = new Font("Segoe UI", 10F),
                ForeColor = AppColors.TextMuted
            });
            pnl.Controls.Add(new Label
            {
                Text = value,
                Left = 110,
                Top = top + 2,
                Width = 340,
                Height = height,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                TextAlign = ContentAlignment.TopRight,
                AutoEllipsis = true
            });
        }

        private void ConfigureItemList()
        {
            ConfigureList(_lvItems);
            _lvItems.Columns.Add(new ColumnHeader { Text = "Mục", Width = 170 });
            _lvItems.Columns.Add(new ColumnHeader { Text = "SL", Width = 36, TextAlign = HorizontalAlignment.Center });
            _lvItems.Columns.Add(new ColumnHeader { Text = "Đơn giá", Width = 90, TextAlign = HorizontalAlignment.Right });
            _lvItems.Columns.Add(new ColumnHeader { Text = "Thành tiền", Width = 100, TextAlign = HorizontalAlignment.Right });
        }

        private Panel BuildSummaryPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 150, BackColor = AppColors.CardBackground };

            AddSummaryRow(pnl, "Tiền vé", _lblTicketTotal, 8, 12F, FontStyle.Regular, AppColors.TextDark);
            AddSummaryRow(pnl, "Tiền Combo", _lblComboTotal, 38, 12F, FontStyle.Regular, AppColors.TextDark);
            pnl.Controls.Add(new Panel { Left = 16, Top = 72, Width = 438, Height = 1, BackColor = AppColors.Border });
            AddSummaryRow(pnl, "TỔNG TIỀN", _lblGrandTotal, 82, 18F, FontStyle.Bold, AppColors.TextPrimary);
            return pnl;
        }

        private static void AddSummaryRow(Panel pnl, string caption, Label value, int top, float valueSize, FontStyle valueStyle, Color valueColor)
        {
            pnl.Controls.Add(new Label
            {
                Text = caption,
                Left = 16,
                Top = top + 4,
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F, valueStyle == FontStyle.Bold ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = AppColors.TextDark
            });

            value.Left = 200;
            value.Top = top;
            value.Width = 254;
            value.Height = valueSize > 14F ? 36 : 26;
            value.TextAlign = ContentAlignment.MiddleRight;
            value.Font = new Font("Segoe UI", valueSize, valueStyle);
            value.ForeColor = valueColor;
            pnl.Controls.Add(value);
        }

        // ---- Ở giữa: Khách hàng + Phương thức thanh toán ----
        private Panel BuildCenterPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = AppColors.PageBackground, AutoScroll = true };

            // ----- KHÁCH HÀNG -----
            pnl.Controls.Add(MakeCaption("KHÁCH HÀNG", 8, 13F, FontStyle.Bold, AppColors.TextDark, 24));
            pnl.Controls.Add(MakeCaption("Khách hàng đã chọn (không chọn = khách vãng lai)", 40, 9.5F, FontStyle.Regular, AppColors.TextMuted, 24));

            _lblCustomer.Left = 24; _lblCustomer.Top = 62; _lblCustomer.Width = 400; _lblCustomer.Height = 28;
            _lblCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblCustomer.AutoEllipsis = true;
            pnl.Controls.Add(_lblCustomer);

            StyleButton(_btnClearCustomer, AppColors.CardBackground, AppColors.StatusRed);
            _btnClearCustomer.Text = "Bỏ chọn";
            _btnClearCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnClearCustomer.Size = new Size(110, 30);
            _btnClearCustomer.Location = new Point(434, 60);
            pnl.Controls.Add(_btnClearCustomer);

            _txtSearch.Font = new Font("Segoe UI", 11F);
            _txtSearch.BackColor = AppColors.InputBackground;
            _txtSearch.ForeColor = AppColors.TextPrimary;
            _txtSearch.PlaceholderText = "Nhập SĐT hoặc tên khách hàng...";
            _txtSearch.MaxLength = 100;
            _txtSearch.Location = new Point(24, 100);
            _txtSearch.Width = 330;
            pnl.Controls.Add(_txtSearch);

            StyleButton(_btnSearch, AppColors.Primary, Color.White);
            _btnSearch.Text = "Tìm";
            _btnSearch.Size = new Size(90, 32);
            _btnSearch.Location = new Point(364, 98);
            pnl.Controls.Add(_btnSearch);

            ConfigureList(_lvCustomers);
            _lvCustomers.Columns.Add(new ColumnHeader { Text = "Họ tên", Width = 170 });
            _lvCustomers.Columns.Add(new ColumnHeader { Text = "SĐT", Width = 110 });
            _lvCustomers.Columns.Add(new ColumnHeader { Text = "Email", Width = 170 });
            _lvCustomers.Columns.Add(new ColumnHeader { Text = "Điểm", Width = 60, TextAlign = HorizontalAlignment.Right });
            _lvCustomers.Dock = DockStyle.None;
            _lvCustomers.Location = new Point(24, 140);
            _lvCustomers.Size = new Size(580, 130);
            pnl.Controls.Add(_lvCustomers);

            _lblSearchStatus.Left = 24; _lblSearchStatus.Top = 278; _lblSearchStatus.Width = 400; _lblSearchStatus.Height = 34;
            _lblSearchStatus.Font = new Font("Segoe UI", 9.5F);
            _lblSearchStatus.ForeColor = AppColors.TextMuted;
            pnl.Controls.Add(_lblSearchStatus);

            StyleButton(_btnPick, AppColors.SuccessStrong, Color.White);
            _btnPick.Text = "Chọn khách này";
            _btnPick.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnPick.Size = new Size(160, 32);
            _btnPick.Location = new Point(444, 276);
            pnl.Controls.Add(_btnPick);

            // ----- TẠO KHÁCH MỚI (không phải module CRUD, chỉ tạo nhanh trong flow bán vé) -----
            pnl.Controls.Add(MakeCaption("Chưa có khách hàng? Tạo nhanh", 322, 11F, FontStyle.Bold, AppColors.TextDark, 24));

            _txtName.Font = new Font("Segoe UI", 11F);
            _txtName.PlaceholderText = "Họ tên *";
            _txtName.MaxLength = PaymentConstants.MaxCustomerNameLength;
            _txtName.Location = new Point(24, 352);
            _txtName.Width = 200;

            _txtPhone.Font = new Font("Segoe UI", 11F);
            _txtPhone.PlaceholderText = "SĐT * (10 số)";
            _txtPhone.MaxLength = 15;
            _txtPhone.Location = new Point(234, 352);
            _txtPhone.Width = 140;

            _txtEmail.Font = new Font("Segoe UI", 11F);
            _txtEmail.PlaceholderText = "Email (tùy chọn)";
            _txtEmail.MaxLength = PaymentConstants.MaxCustomerEmailLength;
            _txtEmail.Location = new Point(384, 352);
            _txtEmail.Width = 220;

            foreach (TextBox t in new[] { _txtName, _txtPhone, _txtEmail })
            {
                t.BackColor = AppColors.InputBackground;
                t.ForeColor = AppColors.TextPrimary;
                pnl.Controls.Add(t);
            }

            StyleButton(_btnCreate, AppColors.Primary, Color.White);
            _btnCreate.Text = "＋ Tạo & chọn khách hàng";
            _btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnCreate.Size = new Size(230, 34);
            _btnCreate.Location = new Point(24, 392);
            pnl.Controls.Add(_btnCreate);

            _lblCreateStatus.Left = 264; _lblCreateStatus.Top = 388; _lblCreateStatus.Width = 340; _lblCreateStatus.Height = 44;
            _lblCreateStatus.Font = new Font("Segoe UI", 9.5F);
            _lblCreateStatus.ForeColor = AppColors.TextMuted;
            pnl.Controls.Add(_lblCreateStatus);

            if (!_canCreateCustomer)
            {
                _lblCreateStatus.Text = "Bạn không có quyền tạo khách hàng mới. Vẫn có thể tìm và chọn khách đã có.";
                _txtName.Enabled = _txtPhone.Enabled = _txtEmail.Enabled = false;
            }

            pnl.Controls.Add(new Panel { Left = 24, Top = 444, Width = 580, Height = 1, BackColor = AppColors.Border });

            // ----- PHƯƠNG THỨC THANH TOÁN -----
            pnl.Controls.Add(MakeCaption("PHƯƠNG THỨC THANH TOÁN", 458, 13F, FontStyle.Bold, AppColors.TextDark, 24));

            _rdoCash.Text = "Tiền mặt";
            _rdoCash.Checked = true;             // Phase 5 chỉ có Tiền mặt (chưa hiển thị VNPay)
            _rdoCash.AutoSize = true;
            _rdoCash.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _rdoCash.ForeColor = AppColors.TextDark;
            _rdoCash.Location = new Point(24, 494);
            pnl.Controls.Add(_rdoCash);

            pnl.Controls.Add(MakeCaption("Tiền khách đưa", 530, 10F, FontStyle.Regular, AppColors.TextMuted, 24));

            _txtReceived.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            _txtReceived.BackColor = AppColors.InputBackground;
            _txtReceived.ForeColor = AppColors.TextPrimary;
            _txtReceived.TextAlign = HorizontalAlignment.Right;
            _txtReceived.MaxLength = 15;
            _txtReceived.Location = new Point(24, 554);
            _txtReceived.Width = 300;
            pnl.Controls.Add(_txtReceived);

            pnl.Controls.Add(new Label
            {
                Text = "đ",
                Left = 332,
                Top = 558,
                AutoSize = true,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = AppColors.TextDark
            });

            int x = 24;
            AddQuickButton(pnl, "Đủ tiền", null, ref x, 96);
            foreach (decimal amount in QuickAmounts)
                AddQuickButton(pnl, $"{amount:N0}", amount, ref x, amount >= 1_000_000m ? 104 : 88);

            _lblChange.Left = 24; _lblChange.Top = 646; _lblChange.Width = 580; _lblChange.Height = 40;
            _lblChange.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            pnl.Controls.Add(_lblChange);

            pnl.AutoScrollMinSize = new Size(0, 710);
            return pnl;
        }

        // amount = null → nút "Đủ tiền" (điền đúng số tổng tiền đang hiển thị; backend vẫn tính lại khi xác nhận)
        private void AddQuickButton(Panel pnl, string text, decimal? amount, ref int x, int width)
        {
            var b = new PillButton
            {
                Text = text,
                Size = new Size(width, 32),
                Location = new Point(x, 602),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                BackColor = AppColors.CardBackground,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = AppColors.BorderStrong;
            decimal? value = amount;
            b.Click += (s, e) =>
            {
                if (_busy || _paid || _expired) return;
                decimal v = value ?? _cart.TongTien;
                _txtReceived.Text = v.ToString("N0");
                _txtReceived.SelectionStart = _txtReceived.Text.Length;
            };
            _quickButtons.Add(b);
            pnl.Controls.Add(b);
            x += width + 8;
        }

        // ---- Thanh dưới: thông báo + đếm ngược + nút xác nhận ----
        private Panel BuildBottomPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 88, BackColor = AppColors.CardBackground };

            _lblMessage.Left = 24; _lblMessage.Top = 10; _lblMessage.Width = 640; _lblMessage.Height = 68;
            _lblMessage.Font = new Font("Segoe UI", 10F);
            _lblMessage.ForeColor = AppColors.TextMuted;
            pnl.Controls.Add(_lblMessage);

            var lblCap = MakeCaption("Giữ ghế còn lại", 10, 9.5F, FontStyle.Regular, AppColors.TextMuted, 0);
            pnl.Controls.Add(lblCap);
            _lblCountdown.Width = 130; _lblCountdown.Height = 34;
            _lblCountdown.TextAlign = ContentAlignment.MiddleLeft;
            _lblCountdown.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            _lblCountdown.ForeColor = AppColors.TextMuted;
            _lblCountdown.Text = "--:--";
            pnl.Controls.Add(_lblCountdown);

            StyleButton(_btnConfirm, AppColors.SuccessStrong, Color.White);
            _btnConfirm.Text = "XÁC NHẬN THANH TOÁN  →";
            _btnConfirm.Size = new Size(320, 52);
            pnl.Controls.Add(_btnConfirm);

            void PlaceRight()
            {
                _btnConfirm.Location = new Point(pnl.Width - _btnConfirm.Width - 24, 18);
                _lblCountdown.Location = new Point(_btnConfirm.Left - _lblCountdown.Width - 20, 40);
                lblCap.Location = new Point(_lblCountdown.Left, 20);
                _lblMessage.Width = Math.Max(200, lblCap.Left - _lblMessage.Left - 20);
            }
            pnl.Resize += (s, e) => PlaceRight();
            PlaceRight();
            return pnl;
        }

        private static void ConfigureList(ListView lv)
        {
            lv.Dock = DockStyle.Fill;
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.HideSelection = false;
            lv.MultiSelect = false;
            lv.BorderStyle = BorderStyle.None;
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.Font = new Font("Segoe UI", 10F);
            lv.BackColor = AppColors.CardBackground;
            lv.ForeColor = AppColors.TextDark;
            UiKit.StyleListView(lv);
        }

        private static Label MakeCaption(string text, int top, float size, FontStyle style = FontStyle.Regular, Color? color = null, int left = 16) => new()
        {
            Text = text,
            Left = left,
            Top = top,
            AutoSize = true,
            Font = new Font("Segoe UI", size, style),
            ForeColor = color ?? AppColors.TextMuted
        };

        private static void StyleButton(PillButton b, Color back, Color fore)
        {
            b.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            b.BackColor = back;
            b.ForeColor = fore;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = (fore == AppColors.StatusRed || back == AppColors.Surface2) ? 1 : 0;
            b.FlatAppearance.BorderColor = fore == AppColors.StatusRed ? AppColors.StatusRed : AppColors.BorderStrong;
            b.Cursor = Cursors.Hand;
        }

        // ================= SỰ KIỆN =================
        private void WireEvents()
        {
            _btnBack.Click += (s, e) => { if (!_busy && !_paid) BackRequested?.Invoke(); };
            _btnConfirm.Click += async (s, e) => await ConfirmAsync();

            _btnSearch.Click += async (s, e) => await SearchCustomersAsync();
            _txtSearch.KeyDown += async (s, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;
                await SearchCustomersAsync();
            };
            _btnPick.Click += (s, e) => PickSelectedCustomer();
            _lvCustomers.DoubleClick += (s, e) => PickSelectedCustomer();
            _lvCustomers.SelectedIndexChanged += (s, e) => UpdateButtons();
            _btnClearCustomer.Click += (s, e) =>
            {
                if (_busy || _paid || _expired) return;
                SetCustomer(null);
            };
            _btnCreate.Click += async (s, e) => await CreateCustomerAsync();

            _txtName.TextChanged += (s, e) => _errors.SetError(_txtName, string.Empty);
            _txtPhone.TextChanged += (s, e) => _errors.SetError(_txtPhone, string.Empty);
            _txtEmail.TextChanged += (s, e) => _errors.SetError(_txtEmail, string.Empty);

            // Ô tiền khách đưa: chỉ cho gõ số (và dấu . , khoảng trắng phân cách nghìn). Số âm/chữ bị chặn ngay khi gõ;
            // nội dung dán vào vẫn được kiểm tra lại bởi CashPaymentHelper.TryParseAmount.
            _txtReceived.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != ' ')
                    e.Handled = true;
            };
            _txtReceived.TextChanged += (s, e) => UpdateChange();
            _txtReceived.KeyDown += (s, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;
                if (_btnConfirm.Enabled) _btnConfirm.PerformClick();
            };
            _txtReceived.Leave += (s, e) =>
            {
                if (CashPaymentHelper.TryParseAmount(_txtReceived.Text, out decimal v) && v <= PaymentConstants.MaxCashReceived)
                    _txtReceived.Text = v.ToString("N0");
            };

            _countdownTimer.Tick += (s, e) => OnCountdownTick();
            Load += (s, e) =>
            {
                UpdateCountdownLabel();
                _countdownTimer.Start();
                _txtSearch.Focus();
            };
        }

        // Gọi service với 1 scope riêng để luôn đọc dữ liệu mới nhất từ DB (giống các bước trước)
        private static async Task<TResult> CallAsync<TService, TResult>(Func<TService, Task<TResult>> action)
            where TService : notnull
        {
            using var scope = Program.Services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<TService>();
            return await action(service);
        }

        // ================= TÓM TẮT ĐƠN =================
        private void FillOrderSummary()
        {
            _lvItems.BeginUpdate();
            _lvItems.Items.Clear();

            _lvItems.Items.Add(MakeSectionRow("VÉ XEM PHIM"));
            foreach (SeatDto seat in _cart.Seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot))
            {
                var item = new ListViewItem($"Ghế {seat.Label} ({SeatTypeName(seat.LoaiGhe)})");
                item.SubItems.Add("1");
                item.SubItems.Add($"{seat.Gia:N0}");
                item.SubItems.Add($"{seat.Gia:N0}");
                _lvItems.Items.Add(item);
            }

            if (_cart.Combos.Count > 0)
                _lvItems.Items.Add(MakeSectionRow("COMBO BẮP NƯỚC"));
            foreach (CartComboItemDto line in _cart.Combos)
            {
                var item = new ListViewItem(line.TenCombo);
                item.SubItems.Add(line.SoLuong.ToString());
                item.SubItems.Add($"{line.DonGia:N0}");
                item.SubItems.Add($"{line.ThanhTien:N0}");
                _lvItems.Items.Add(item);
            }
            _lvItems.EndUpdate();

            _lblTicketTotal.Text = $"{_cart.TongTienGhe:N0} đ";
            _lblComboTotal.Text = $"{_cart.TongTienCombo:N0} đ";
            _lblGrandTotal.Text = $"{_cart.TongTien:N0} đ";
        }

        private static ListViewItem MakeSectionRow(string title)
        {
            var row = new ListViewItem(title)
            {
                BackColor = AppColors.InputBackground,
                ForeColor = AppColors.TextMuted,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                UseItemStyleForSubItems = true
            };
            row.SubItems.Add(string.Empty);
            row.SubItems.Add(string.Empty);
            row.SubItems.Add(string.Empty);
            return row;
        }

        private static string SeatTypeName(SeatType type) => type switch
        {
            SeatType.Vip => "VIP",
            SeatType.Doi => "Đôi",
            _ => "Thường"
        };

        // ================= KHÁCH HÀNG =================
        private void SetCustomer(SaleCustomerDto? customer)
        {
            _customer = customer;
            if (customer == null)
            {
                _lblCustomer.Text = "Khách vãng lai";
                _lblCustomer.ForeColor = AppColors.TextMuted;
            }
            else
            {
                string email = string.IsNullOrWhiteSpace(customer.Email) ? string.Empty : $"  •  {customer.Email}";
                _lblCustomer.Text = $"{customer.HoTen}  •  {customer.SDT}{email}";
                _lblCustomer.ForeColor = AppColors.Success;
            }
            UpdateButtons();
        }

        private async Task SearchCustomersAsync()
        {
            if (_busy || _paid || _expired) return;

            string keyword = _txtSearch.Text.Trim();
            if (keyword.Length == 0)
            {
                SetSearchStatus("Nhập số điện thoại hoặc tên khách hàng rồi bấm Tìm.", true);
                return;
            }

            SetBusy(true);
            try
            {
                var result = await CallAsync<ICustomerService, Result<List<SaleCustomerDto>>>(sv => sv.SearchAsync(keyword));
                if (IsDisposed) return;

                if (!result.IsSuccess)
                {
                    FillCustomers(new List<SaleCustomerDto>());
                    SetSearchStatus(result.ErrorMessage ?? "Không tìm được khách hàng.", true);
                    return;
                }

                List<SaleCustomerDto> list = result.Data!;
                FillCustomers(list);

                if (list.Count == 0)
                {
                    SetSearchStatus("Không tìm thấy khách hàng. Có thể tạo nhanh khách mới ở bên dưới.", false);
                    // Gõ đúng SĐT mà chưa có khách → điền sẵn vào ô tạo mới cho nhanh
                    if (_canCreateCustomer && CustomerValidationHelper.IsValidPhone(keyword))
                        _txtPhone.Text = CustomerValidationHelper.NormalizePhone(keyword);
                }
                else
                {
                    if (list.Count == 1) _lvCustomers.Items[0].Selected = true;
                    SetSearchStatus($"Tìm thấy {list.Count} khách hàng. Chọn 1 dòng rồi bấm \"Chọn khách này\" (hoặc nhấp đúp).", false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tìm được khách hàng khi thanh toán");
                if (!IsDisposed) SetSearchStatus("Lỗi tìm khách hàng. Vui lòng thử lại.", true);
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        private void FillCustomers(List<SaleCustomerDto> customers)
        {
            _lvCustomers.BeginUpdate();
            _lvCustomers.Items.Clear();
            foreach (SaleCustomerDto c in customers)
            {
                var item = new ListViewItem(c.HoTen) { Tag = c };
                item.SubItems.Add(c.SDT);
                item.SubItems.Add(c.Email ?? string.Empty);
                item.SubItems.Add(c.DiemTichLuy.ToString());
                _lvCustomers.Items.Add(item);
            }
            _lvCustomers.EndUpdate();
            UpdateButtons();
        }

        private void PickSelectedCustomer()
        {
            if (_busy || _paid || _expired) return;

            if (_lvCustomers.SelectedItems.Count == 0 || _lvCustomers.SelectedItems[0].Tag is not SaleCustomerDto customer)
            {
                SetSearchStatus("Hãy chọn một khách hàng trong danh sách.", true);
                return;
            }

            SetCustomer(customer);
            SetSearchStatus($"Đã chọn khách hàng {customer.HoTen}.", false);
            ShowMessage(string.Empty, false);
        }

        private async Task CreateCustomerAsync()
        {
            if (_busy || _paid || _expired || !_canCreateCustomer) return;

            // Kiểm tra nhanh trên UI để báo lỗi ngay; BLL kiểm tra lại toàn bộ trước khi ghi database
            _errors.Clear();
            bool valid = true;
            string name = CustomerValidationHelper.NormalizeName(_txtName.Text);
            if (name.Length == 0)
            {
                _errors.SetError(_txtName, "Vui lòng nhập họ tên");
                valid = false;
            }
            if (!CustomerValidationHelper.IsValidPhone(_txtPhone.Text))
            {
                _errors.SetError(_txtPhone, "SĐT gồm 10 chữ số, bắt đầu bằng 0");
                valid = false;
            }
            if (!CustomerValidationHelper.IsValidOptionalEmail(_txtEmail.Text))
            {
                _errors.SetError(_txtEmail, "Email không đúng định dạng");
                valid = false;
            }
            if (!valid)
            {
                SetCreateStatus("Vui lòng sửa các ô đang báo lỗi.", true);
                return;
            }

            SetBusy(true);
            try
            {
                var result = await CallAsync<ICustomerService, Result<SaleCustomerDto>>(
                    sv => sv.CreateAsync(_txtName.Text, _txtPhone.Text, _txtEmail.Text));
                if (IsDisposed) return;

                if (!result.IsSuccess)
                {
                    SetCreateStatus(result.ErrorMessage ?? "Không tạo được khách hàng.", true);
                    return;
                }

                SetCustomer(result.Data);
                _txtName.Clear();
                _txtPhone.Clear();
                _txtEmail.Clear();
                SetCreateStatus($"Đã tạo và chọn khách hàng {result.Data!.HoTen}.", false);
                ShowMessage(string.Empty, false);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tạo được khách hàng trong luồng bán vé");
                if (!IsDisposed) SetCreateStatus("Lỗi hệ thống khi tạo khách hàng. Vui lòng thử lại.", true);
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        // ================= TIỀN KHÁCH ĐƯA / TIỀN THỪA =================
        private bool TryGetReceived(out decimal received, out string error)
        {
            received = 0;
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(_txtReceived.Text))
            {
                error = "Vui lòng nhập tiền khách đưa.";
                return false;
            }
            if (!CashPaymentHelper.TryParseAmount(_txtReceived.Text, out received))
            {
                error = "Tiền khách đưa không hợp lệ (chỉ nhập số, không âm).";
                return false;
            }
            if (received > PaymentConstants.MaxCashReceived)
            {
                error = "Tiền khách đưa quá lớn, vui lòng kiểm tra lại.";
                return false;
            }
            return true;
        }

        // Tiền thừa = Tiền khách đưa - Tổng tiền. Đây chỉ là HIỂN THỊ; số chính thức do backend tính lại khi xác nhận.
        private void UpdateChange()
        {
            if (_paid) return;

            if (!TryGetReceived(out decimal received, out string error))
            {
                _receivedOk = false;
                bool empty = string.IsNullOrWhiteSpace(_txtReceived.Text);
                _lblChange.Text = empty ? "Nhập số tiền khách đưa" : error;
                _lblChange.ForeColor = empty ? AppColors.TextMuted : AppColors.StatusRed;
                UpdateButtons();
                return;
            }

            decimal change = CashPaymentHelper.CalculateChange(_cart.TongTien, received);
            if (change < 0)
            {
                _receivedOk = false;
                _lblChange.Text = $"Còn thiếu: {-change:N0} đ";
                _lblChange.ForeColor = AppColors.StatusRed;
            }
            else
            {
                _receivedOk = true;
                _lblChange.Text = $"Tiền thừa: {change:N0} đ";
                _lblChange.ForeColor = AppColors.Success;
            }
            UpdateButtons();
        }

        // ================= XÁC NHẬN THANH TOÁN =================
        private async Task ConfirmAsync()
        {
            if (_busy || _paid || _expired) return;

            if (!TryGetReceived(out decimal received, out string error))
            {
                ShowMessage(error, true);
                return;
            }
            if (!CashPaymentHelper.IsEnough(_cart.TongTien, received))
            {
                ShowMessage("Tiền khách đưa chưa đủ. Chưa thể thanh toán.", true);
                return;
            }

            // Chỉ gửi định danh + số tiền khách đưa. KHÔNG gửi giá vé / giá combo / tổng tiền / trạng thái ghế làm dữ liệu chính.
            var request = new CashCheckoutRequest
            {
                ShowtimeId = _cart.ShowtimeId,
                SeatIds = _cart.Seats.Select(s => s.SeatId).ToList(),
                HeldAt = _cart.HeldAt,
                ComboQuantities = _cart.Combos.ToDictionary(c => c.ComboId, c => c.SoLuong),
                CustomerId = _customer?.CustomerId,
                UserId = UserSession.UserId,
                TienKhachDua = received,
                TongTienDangHienThi = _cart.TongTien      // chỉ để backend phát hiện giá đã đổi và dừng
            };

            SetBusy(true);
            Result<CheckoutResultDto>? result = null;
            try
            {
                IsCheckingOut = true;
                try
                {
                    result = await CallAsync<ICheckoutService, Result<CheckoutResultDto>>(sv => sv.CheckoutCashAsync(request));
                }
                finally
                {
                    IsCheckingOut = false;
                }

                if (IsDisposed) return;

                if (!result.IsSuccess)
                {
                    await HandleCheckoutFailureAsync(result.ErrorMessage ?? "Không thể hoàn tất thanh toán.");
                    return;
                }

                CheckoutResultDto data = result.Data!;
                _paid = true;
                _countdownTimer.Stop();
                ShowPaidState(data);
                CheckoutCompleted?.Invoke(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thanh toán tiền mặt suất {ShowtimeId}", _cart.ShowtimeId);
                if (!IsDisposed)
                    ShowMessage("Không thể thanh toán do lỗi hệ thống. Vui lòng thử lại; nếu vẫn lỗi hãy báo quản lý trước khi thu tiền.", true);
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        // Thanh toán thất bại: hỏi lại database xem phiên giữ ghế còn không để biết lỗi thuộc trường hợp nào
        private async Task HandleCheckoutFailureAsync(string message)
        {
            List<int> seatIds = _cart.Seats.Select(s => s.SeatId).ToList();
            var check = await CallAsync<ISeatHoldService, Result<SeatHoldDto>>(
                sv => sv.ValidateHoldAsync(_cart.ShowtimeId, seatIds, _cart.HeldAt));
            if (IsDisposed) return;

            if (!check.IsSuccess)
            {
                LoseHold(check.ErrorMessage ?? message);
                return;
            }

            ShowMessage(message, true);
        }

        private void ShowPaidState(CheckoutResultDto data)
        {
            _lblChange.Text = $"Tiền thừa trả khách: {data.TienThua:N0} đ";
            _lblChange.ForeColor = AppColors.Success;
            _lblCountdown.Text = "--:--";
            _lblCountdown.ForeColor = AppColors.TextMuted;
            _btnConfirm.Text = "ĐÃ THANH TOÁN";
            ShowMessage(
                $"ĐÃ THANH TOÁN THÀNH CÔNG — Hóa đơn #{data.InvoiceId}.\nTổng tiền {data.TongTien:N0} đ • Khách đưa {data.TienKhachDua:N0} đ • Tiền thừa {data.TienThua:N0} đ.",
                false);
            UpdateButtons();
        }

        // ================= COUNTDOWN (chỉ để hiển thị; database mới quyết định ghế còn được giữ hay không) =================
        private void OnCountdownTick()
        {
            if (_expired || _paid || IsDisposed) return;

            if (_cart.ExpiresAt - DateTime.Now <= TimeSpan.Zero)
            {
                // Đang gọi backend thanh toán: để backend quyết định (nó kiểm tra lại phiên giữ ghế trong database)
                if (_busy) return;
                LoseHold("Đã hết thời gian giữ ghế. Ghế đã được trả về trạng thái Trống, vui lòng chọn lại ghế.");
                return;
            }
            UpdateCountdownLabel();
        }

        private void UpdateCountdownLabel()
        {
            TimeSpan remaining = _cart.ExpiresAt - DateTime.Now;
            if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;

            _lblCountdown.Text = $"{(int)remaining.TotalMinutes:00}:{remaining.Seconds:00}";
            _lblCountdown.ForeColor = remaining.TotalSeconds <= 60 ? AppColors.StatusRed : AppColors.Success;
        }

        // Hết hạn / mất phiên giữ: KHÔNG tạo Invoice/Payment, khóa thao tác, báo BookingForm đưa nhân viên về bước chọn ghế
        private void LoseHold(string message)
        {
            if (_expired || _paid) return;
            _expired = true;
            _countdownTimer.Stop();
            _lblCountdown.Text = "00:00";
            _lblCountdown.ForeColor = AppColors.StatusRed;
            ShowMessage(message, true);
            UpdateButtons();
            HoldLost?.Invoke(message);
        }

        // ================= HIỂN THỊ =================
        private void SetBusy(bool busy)
        {
            _busy = busy;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (IsDisposed) return;

            bool active = !_busy && !_expired && !_paid;
            _btnBack.Enabled = !_busy && !_paid;
            _btnConfirm.Enabled = active && _receivedOk;    // chưa nhập đủ tiền thì không cho xác nhận

            _txtSearch.Enabled = active;
            _btnSearch.Enabled = active;
            _lvCustomers.Enabled = active;
            _btnPick.Enabled = active && _lvCustomers.SelectedItems.Count > 0;
            _btnClearCustomer.Enabled = active && _customer != null;

            bool createActive = active && _canCreateCustomer;
            _txtName.Enabled = createActive;
            _txtPhone.Enabled = createActive;
            _txtEmail.Enabled = createActive;
            _btnCreate.Enabled = createActive;

            _rdoCash.Enabled = active;
            _txtReceived.Enabled = active;
            foreach (PillButton b in _quickButtons) b.Enabled = active;
        }

        private void ShowMessage(string text, bool isError)
        {
            _lblMessage.Text = text;
            _lblMessage.ForeColor = isError ? AppColors.StatusRed : AppColors.Success;
        }

        private void SetSearchStatus(string text, bool isError)
        {
            _lblSearchStatus.Text = text;
            _lblSearchStatus.ForeColor = isError ? AppColors.StatusRed : AppColors.TextMuted;
        }

        private void SetCreateStatus(string text, bool isError)
        {
            _lblCreateStatus.Text = text;
            _lblCreateStatus.ForeColor = isError ? AppColors.StatusRed : AppColors.TextMuted;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _countdownTimer.Dispose();
                _errors.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

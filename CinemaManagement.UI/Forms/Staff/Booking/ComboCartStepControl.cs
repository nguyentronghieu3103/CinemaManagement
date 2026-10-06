using CinemaManagement.BLL.Services.Sales;
using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Results;
using CinemaManagement.UI.Theme;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // BƯỚC 4 của màn Bán vé: chọn Combo + xem Giỏ hàng + tổng tiền realtime (PHASE 4).
    // - Ghế lấy từ phiên giữ ghế của bước 3 (SeatHoldDto, giá do backend tính) và VẪN đang ở trạng thái "Đang giữ".
    // - Giá combo lấy từ database qua ICartService. UI chỉ hiển thị; số tiền chính thức do BuildCartAsync tính lại lúc xác nhận.
    // - Bước này KHÔNG chuyển ghế sang DaDat (việc đó thuộc bước thanh toán ở Phase 5).
    public class ComboCartStepControl : UserControl
    {
        private readonly SaleMovieDto _movie;
        private readonly SaleShowtimeDto _showtime;
        private readonly SeatHoldDto _hold;                    // phiên giữ ghế từ bước 3 (HeldAt/ExpiresAt không đổi trong bước này)

        // ComboId -> số lượng. Dictionary này do BookingForm sở hữu và truyền vào,
        // nên khi nhân viên quay lại bước ghế rồi vào lại thì số lượng combo đã chọn vẫn còn.
        private readonly Dictionary<int, int> _quantities;

        private List<SeatDto> _seats;                          // ghế trong giỏ (giá do backend tính)
        private decimal _seatTotal;                            // = tổng giá ghế do backend tính
        private List<ComboDto> _combos = new();                // danh sách combo + giá từ database
        private readonly Dictionary<int, ComboCardRef> _cards = new();

        private readonly PillButton _btnBack = new();
        private readonly PillButton _btnReload = new();
        private readonly Label _lblComboStatus = new();
        private readonly FlowLayoutPanel _flowCombos = new();

        private readonly ListView _lvCart = new();
        private readonly PillButton _btnRemoveCombo = new();
        private readonly Label _lblTicketTotal = new();
        private readonly Label _lblComboTotal = new();
        private readonly Label _lblGrandTotal = new();
        private readonly Label _lblCountdown = new();
        private readonly Label _lblMessage = new();
        private readonly PillButton _btnNext = new();

        private readonly System.Windows.Forms.Timer _countdownTimer = new() { Interval = 1000 };

        private bool _busy;
        private bool _expired;          // phiên giữ ghế đã hết hạn / mất → không cho thao tác tiếp
        private bool _combosLoaded;     // chỉ cho xác nhận khi đã tải được combo (giỏ hiển thị = giỏ gửi đi)
        private int _loadVersion;

        public event Action? BackRequested;
        // Backend đã kiểm tra lại ghế + tính lại tiền → BookingForm chuyển sang bước Thanh toán (Phase 5)
        public event Action<CartDto>? CartConfirmed;
        // Phiên giữ ghế không còn hợp lệ (hết hạn / bị mất) → BookingForm đưa nhân viên về bước chọn ghế
        public event Action<string>? HoldLost;

        public ComboCartStepControl(SaleMovieDto movie, SaleShowtimeDto showtime, SeatHoldDto hold, Dictionary<int, int> quantities)
        {
            _movie = movie;
            _showtime = showtime;
            _hold = hold;
            _quantities = quantities;
            _seats = hold.Seats.ToList();
            _seatTotal = hold.TongTienVe;

            Dock = DockStyle.Fill;
            BackColor = Color.Transparent;

            BuildLayout();
            WireEvents();
            RefreshCart();
        }

        // ================= GIAO DIỆN =================
        private void BuildLayout()
        {
            // Thứ tự Add: Fill trước, rồi Right, rồi Top (giống các bước trước)
            Controls.Add(BuildCenterPanel());
            Controls.Add(BuildRightPanel());
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
                Text = "BƯỚC 04 — COMBO / GIỎ HÀNG",
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

        // Khu vực 1: danh sách Combo
        private Panel BuildCenterPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = AppColors.PageBackground };

            _flowCombos.Dock = DockStyle.Fill;
            _flowCombos.AutoScroll = true;
            _flowCombos.Padding = new Padding(24, 8, 24, 12);
            _flowCombos.BackColor = AppColors.PageBackground;
            pnl.Controls.Add(_flowCombos);

            var status = new Panel { Dock = DockStyle.Top, Height = 78, BackColor = Color.Transparent };

            status.Controls.Add(new Label
            {
                Text = "Chọn Combo bắp nước",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 24,
                Top = 12
            });

            _lblComboStatus.AutoSize = true;
            _lblComboStatus.Font = new Font("Segoe UI", 10F);
            _lblComboStatus.ForeColor = AppColors.TextMuted;
            _lblComboStatus.Left = 24;
            _lblComboStatus.Top = 46;
            status.Controls.Add(_lblComboStatus);

            StyleButton(_btnReload, AppColors.Surface2, AppColors.TextPrimary);
            _btnReload.Text = "↻ Tải lại";
            _btnReload.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnReload.Size = new Size(100, 30);
            _btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            status.Controls.Add(_btnReload);
            status.Resize += (s, e) => _btnReload.Location = new Point(status.Width - _btnReload.Width - 24, 10);
            _btnReload.Location = new Point(status.Width - _btnReload.Width - 24, 10);

            pnl.Controls.Add(status);
            return pnl;
        }

        // Khu vực 2 + 3: giỏ hàng và tóm tắt tiền
        private Panel BuildRightPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Right, Width = 470, BackColor = AppColors.CardBackground };

            // Danh sách giỏ hàng (Fill)
            var listHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16, 6, 16, 6), BackColor = AppColors.CardBackground };
            ConfigureCartList();
            listHost.Controls.Add(_lvCart);
            pnl.Controls.Add(listHost);

            pnl.Controls.Add(BuildSummaryPanel());

            var header = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = AppColors.CardBackground };
            header.Controls.Add(MakeCaption("Giỏ hàng", 12, 9.5F));
            pnl.Controls.Add(header);

            return pnl;
        }

        private void ConfigureCartList()
        {
            _lvCart.Dock = DockStyle.Fill;
            _lvCart.View = View.Details;
            _lvCart.FullRowSelect = true;
            _lvCart.HideSelection = false;
            _lvCart.MultiSelect = false;
            _lvCart.BorderStyle = BorderStyle.None;
            _lvCart.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            _lvCart.Font = new Font("Segoe UI", 10F);
            _lvCart.BackColor = AppColors.CardBackground;
            _lvCart.ForeColor = AppColors.TextDark;
            UiKit.StyleListView(_lvCart);

            _lvCart.Columns.Add(new ColumnHeader { Text = "Mục", Width = 170 });
            _lvCart.Columns.Add(new ColumnHeader { Text = "SL", Width = 36, TextAlign = HorizontalAlignment.Center });
            _lvCart.Columns.Add(new ColumnHeader { Text = "Đơn giá", Width = 90, TextAlign = HorizontalAlignment.Right });
            _lvCart.Columns.Add(new ColumnHeader { Text = "Thành tiền", Width = 100, TextAlign = HorizontalAlignment.Right });
        }

        private Panel BuildSummaryPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 330, BackColor = AppColors.CardBackground };

            StyleButton(_btnRemoveCombo, AppColors.CardBackground, AppColors.StatusRed);
            _btnRemoveCombo.Text = "Xóa combo đã chọn";
            _btnRemoveCombo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnRemoveCombo.Size = new Size(200, 32);
            _btnRemoveCombo.Location = new Point(16, 4);
            _btnRemoveCombo.Enabled = false;
            pnl.Controls.Add(_btnRemoveCombo);

            AddSummaryRow(pnl, "Tiền vé", _lblTicketTotal, 48, 12F, FontStyle.Regular, AppColors.TextDark);
            AddSummaryRow(pnl, "Tiền Combo", _lblComboTotal, 78, 12F, FontStyle.Regular, AppColors.TextDark);

            pnl.Controls.Add(new Panel { Left = 16, Top = 112, Width = 438, Height = 1, BackColor = AppColors.Border });

            AddSummaryRow(pnl, "TỔNG CỘNG", _lblGrandTotal, 122, 18F, FontStyle.Bold, AppColors.TextPrimary);

            pnl.Controls.Add(MakeCaption("Giữ ghế còn lại", 172, 10F));
            _lblCountdown.Left = 200; _lblCountdown.Top = 166; _lblCountdown.Width = 254; _lblCountdown.Height = 30;
            _lblCountdown.TextAlign = ContentAlignment.MiddleRight;
            _lblCountdown.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            _lblCountdown.ForeColor = AppColors.TextMuted;
            _lblCountdown.Text = "--:--";
            pnl.Controls.Add(_lblCountdown);

            _lblMessage.Left = 16; _lblMessage.Top = 202; _lblMessage.Width = 438; _lblMessage.Height = 50;
            _lblMessage.Font = new Font("Segoe UI", 10F);
            _lblMessage.ForeColor = AppColors.TextMuted;
            pnl.Controls.Add(_lblMessage);

            StyleButton(_btnNext, AppColors.Primary, Color.White);
            _btnNext.Text = "TIẾP TỤC THANH TOÁN  →";
            _btnNext.Size = new Size(438, 52);
            _btnNext.Location = new Point(16, 262);
            pnl.Controls.Add(_btnNext);

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

        private static Label MakeCaption(string text, int top, float size) => new()
        {
            Text = text,
            Left = 16,
            Top = top,
            AutoSize = true,
            Font = new Font("Segoe UI", size),
            ForeColor = AppColors.TextMuted
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
            _btnBack.Click += (s, e) => { if (!_busy) BackRequested?.Invoke(); };
            _btnReload.Click += async (s, e) => await LoadCombosAsync();
            _btnNext.Click += async (s, e) => await ConfirmAsync();
            _btnRemoveCombo.Click += (s, e) =>
            {
                int? comboId = SelectedComboId();
                if (comboId.HasValue) SetQuantity(comboId.Value, 0);
            };
            _lvCart.SelectedIndexChanged += (s, e) => UpdateButtons();

            _countdownTimer.Tick += (s, e) => OnCountdownTick();

            Load += async (s, e) =>
            {
                UpdateCountdownLabel();
                _countdownTimer.Start();
                await LoadCombosAsync();
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

        // ================= TẢI COMBO =================
        private async Task LoadCombosAsync()
        {
            int version = ++_loadVersion;
            _lblComboStatus.Text = "Đang tải danh sách combo...";
            try
            {
                var result = await CallAsync<ICartService, Result<List<ComboDto>>>(sv => sv.GetCombosAsync());
                if (version != _loadVersion || IsDisposed) return;

                if (!result.IsSuccess)
                {
                    _combosLoaded = false;
                    _lblComboStatus.Text = result.ErrorMessage;
                    UpdateButtons();
                    return;
                }

                _combos = result.Data!;
                _combosLoaded = true;

                // Combo đã chọn từ trước nhưng nay không còn trong database → bỏ khỏi giỏ
                List<int> gone = _quantities.Keys.Where(id => !_combos.Any(c => c.ComboId == id)).ToList();
                foreach (int id in gone) _quantities.Remove(id);

                RenderCombos();
                _lblComboStatus.Text = _combos.Count == 0
                    ? "Chưa có combo nào trong hệ thống. Bạn vẫn có thể tiếp tục chỉ với vé."
                    : $"Có {_combos.Count} combo. Dùng nút − / + để chọn số lượng.";

                RefreshCart();
                if (gone.Count > 0)
                    ShowMessage("Một số combo đã chọn không còn tồn tại nên đã được bỏ khỏi giỏ hàng.", true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tải được danh sách combo");
                if (version != _loadVersion || IsDisposed) return;
                _combosLoaded = false;
                _lblComboStatus.Text = "Lỗi tải danh sách combo. Bấm \"Tải lại\" để thử lại.";
                UpdateButtons();
            }
        }

        private void RenderCombos()
        {
            _flowCombos.SuspendLayout();
            foreach (Control old in _flowCombos.Controls.OfType<Control>().ToList())
                old.Dispose();
            _flowCombos.Controls.Clear();
            _cards.Clear();

            foreach (ComboDto combo in _combos)
            {
                Panel card = CreateComboCard(combo, out ComboCardRef refs);
                _cards[combo.ComboId] = refs;
                _flowCombos.Controls.Add(card);
                UpdateCardVisual(combo.ComboId);
            }
            _flowCombos.ResumeLayout();
        }

        private Panel CreateComboCard(ComboDto combo, out ComboCardRef refs)
        {
            var card = new SurfacePanel { Width = 300, Height = 150, Margin = new Padding(10), BackColor = AppColors.CardBackground };

            card.Controls.Add(new Label
            {
                Text = combo.TenCombo,
                Left = 14,
                Top = 10,
                Width = 272,
                Height = 26,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoEllipsis = true
            });

            card.Controls.Add(new Label
            {
                Text = string.IsNullOrWhiteSpace(combo.MoTa) ? "—" : combo.MoTa,
                Left = 14,
                Top = 38,
                Width = 272,
                Height = 40,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = AppColors.TextMuted,
                AutoEllipsis = true
            });

            card.Controls.Add(new Label
            {
                Text = $"{combo.Gia:N0} đ",
                Left = 14,
                Top = 106,
                AutoSize = true,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = AppColors.Accent
            });

            PillButton minus = MakeStepButton("−");
            minus.Location = new Point(168, 100);
            Label qty = new()
            {
                Text = "0",
                Left = 204,
                Top = 100,
                Width = 44,
                Height = 34,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = AppColors.TextDark
            };
            PillButton plus = MakeStepButton("+");
            plus.Location = new Point(250, 100);

            int comboId = combo.ComboId;
            minus.Click += (s, e) => ChangeQuantity(comboId, -1);
            plus.Click += (s, e) => ChangeQuantity(comboId, +1);

            card.Controls.Add(minus);
            card.Controls.Add(qty);
            card.Controls.Add(plus);

            refs = new ComboCardRef(card, qty, minus, plus);
            return card;
        }

        private static PillButton MakeStepButton(string text)
        {
            var b = new PillButton
            {
                Text = text,
                Size = new Size(34, 34),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                BackColor = AppColors.CardBackground,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = AppColors.BorderStrong;
            return b;
        }

        // ================= SỐ LƯỢNG COMBO =================
        private int GetQuantity(int comboId) => _quantities.TryGetValue(comboId, out int q) ? q : 0;

        private void ChangeQuantity(int comboId, int delta)
        {
            if (_busy || _expired) return;

            int next = GetQuantity(comboId) + delta;
            if (next < CartConstants.MinComboQuantity) return;      // không bao giờ để số lượng âm
            if (next > CartConstants.MaxComboQuantity)
            {
                ShowMessage($"Mỗi loại combo chỉ được chọn tối đa {CartConstants.MaxComboQuantity}.", true);
                return;
            }
            SetQuantity(comboId, next);
        }

        private void SetQuantity(int comboId, int quantity)
        {
            if (_busy || _expired) return;

            quantity = Math.Clamp(quantity, CartConstants.MinComboQuantity, CartConstants.MaxComboQuantity);
            if (quantity == 0) _quantities.Remove(comboId);
            else _quantities[comboId] = quantity;

            ShowMessage(string.Empty, false);
            UpdateCardVisual(comboId);
            RefreshCart();
        }

        private void UpdateCardVisual(int comboId)
        {
            if (!_cards.TryGetValue(comboId, out ComboCardRef? c)) return;

            int qty = GetQuantity(comboId);
            c.Qty.Text = qty.ToString();
            c.Card.BackColor = qty > 0 ? AppColors.RowSelected : AppColors.CardBackground;
            c.Minus.Enabled = !_busy && !_expired && qty > CartConstants.MinComboQuantity;
            c.Plus.Enabled = !_busy && !_expired && qty < CartConstants.MaxComboQuantity;
        }

        // ================= GIỎ HÀNG + TỔNG TIỀN =================
        private int? SelectedComboId()
            => _lvCart.SelectedItems.Count > 0 && _lvCart.SelectedItems[0].Tag is int id ? id : null;

        private void RefreshCart()
        {
            List<CartComboItemDto> lines = CartPricingHelper.BuildComboLines(_combos, _quantities);
            decimal comboTotal = CartPricingHelper.SumComboTotal(lines);
            decimal grandTotal = _seatTotal + comboTotal;

            int? keepSelected = SelectedComboId();

            _lvCart.BeginUpdate();
            _lvCart.Items.Clear();

            _lvCart.Items.Add(MakeSectionRow("VÉ XEM PHIM"));
            foreach (SeatDto seat in _seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot))
            {
                var item = new ListViewItem($"Ghế {seat.Label} ({SeatTypeName(seat.LoaiGhe)})");
                item.SubItems.Add("1");
                item.SubItems.Add($"{seat.Gia:N0}");
                item.SubItems.Add($"{seat.Gia:N0}");
                _lvCart.Items.Add(item);
            }

            if (lines.Count > 0)
                _lvCart.Items.Add(MakeSectionRow("COMBO BẮP NƯỚC"));
            foreach (CartComboItemDto line in lines)
            {
                var item = new ListViewItem(line.TenCombo) { Tag = line.ComboId };   // Tag = ComboId → nút "Xóa combo"
                item.SubItems.Add(line.SoLuong.ToString());
                item.SubItems.Add($"{line.DonGia:N0}");
                item.SubItems.Add($"{line.ThanhTien:N0}");
                item.Selected = keepSelected == line.ComboId;
                _lvCart.Items.Add(item);
            }
            _lvCart.EndUpdate();

            _lblTicketTotal.Text = $"{_seatTotal:N0} đ";
            _lblComboTotal.Text = $"{comboTotal:N0} đ";
            _lblGrandTotal.Text = $"{grandTotal:N0} đ";

            UpdateButtons();
        }

        // Dòng tiêu đề mục trong giỏ (Tag = null nên không bị coi là combo)
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

        // ================= XÁC NHẬN GIỎ HÀNG =================
        private async Task ConfirmAsync()
        {
            if (_busy || _expired) return;

            if (_seats.Count == 0)
            {
                ShowMessage("Chưa có ghế nào trong giỏ hàng. Vui lòng quay lại chọn ghế.", true);
                return;
            }
            if (!_combosLoaded)
            {
                ShowMessage("Chưa tải được danh sách combo. Bấm \"Tải lại\" rồi thử lại.", true);
                return;
            }

            SetBusy(true);
            try
            {
                List<int> seatIds = _seats.Select(s => s.SeatId).ToList();
                Dictionary<int, int> wanted = _quantities
                    .Where(q => q.Value > 0)
                    .ToDictionary(q => q.Key, q => q.Value);

                // Số tiền đang hiển thị, dùng để phát hiện giá đã đổi so với lúc chọn
                decimal displayedTotal = _seatTotal
                    + CartPricingHelper.SumComboTotal(CartPricingHelper.BuildComboLines(_combos, _quantities));

                // Backend kiểm tra lại phiên giữ ghế trong database và tính lại toàn bộ tiền; không tin số tiền trên UI
                var result = await CallAsync<ICartService, Result<CartDto>>(
                    sv => sv.BuildCartAsync(_hold.ShowtimeId, seatIds, _hold.HeldAt, wanted));
                if (IsDisposed) return;

                if (!result.IsSuccess)
                {
                    await HandleConfirmFailureAsync(result.ErrorMessage ?? "Không thể xác nhận giỏ hàng.");
                    return;
                }

                CartDto cart = result.Data!;
                if (cart.TongTien != displayedTotal)
                {
                    // Giá ghế/combo trong database đã đổi kể từ lúc chọn → cập nhật hiển thị, bắt nhân viên xem lại
                    _seats = cart.Seats.ToList();
                    _seatTotal = cart.TongTienGhe;
                    await LoadCombosAsync();
                    if (IsDisposed) return;
                    ShowMessage("Giá đã thay đổi so với lúc chọn. Vui lòng kiểm tra lại giỏ hàng rồi bấm Tiếp tục.", true);
                    return;
                }

                ShowMessage(string.Empty, false);
                CartConfirmed?.Invoke(cart);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xác nhận giỏ hàng suất {ShowtimeId}", _hold.ShowtimeId);
                if (!IsDisposed) ShowMessage("Không thể xác nhận giỏ hàng do lỗi hệ thống. Vui lòng thử lại.", true);
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        // BuildCartAsync thất bại: có thể do (a) mất phiên giữ ghế hoặc (b) combo không hợp lệ/đã bị xóa.
        // Hỏi lại database xem ghế còn được giữ không để biết lỗi thuộc trường hợp nào.
        private async Task HandleConfirmFailureAsync(string message)
        {
            List<int> seatIds = _seats.Select(s => s.SeatId).ToList();
            var check = await CallAsync<ISeatHoldService, Result<SeatHoldDto>>(
                sv => sv.ValidateHoldAsync(_hold.ShowtimeId, seatIds, _hold.HeldAt));
            if (IsDisposed) return;

            if (!check.IsSuccess)
            {
                LoseHold(check.ErrorMessage ?? message);
                return;
            }

            await LoadCombosAsync();          // combo có thể đã đổi/xóa → làm mới danh sách
            if (!IsDisposed) ShowMessage(message, true);
        }

        // ================= COUNTDOWN =================
        private void OnCountdownTick()
        {
            if (_expired || IsDisposed) return;

            if (_hold.ExpiresAt - DateTime.Now <= TimeSpan.Zero)
            {
                LoseHold("Đã hết thời gian giữ ghế. Ghế đã được trả về trạng thái Trống, vui lòng chọn lại ghế.");
                return;
            }
            UpdateCountdownLabel();
        }

        private void UpdateCountdownLabel()
        {
            TimeSpan remaining = _hold.ExpiresAt - DateTime.Now;
            if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;

            _lblCountdown.Text = $"{(int)remaining.TotalMinutes:00}:{remaining.Seconds:00}";
            _lblCountdown.ForeColor = remaining.TotalSeconds <= 60 ? AppColors.StatusRed : AppColors.Success;
        }

        // Phiên giữ ghế hết hạn/mất: khóa toàn bộ thao tác rồi báo BookingForm đưa nhân viên về bước chọn ghế
        private void LoseHold(string message)
        {
            if (_expired) return;
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

            bool active = !_busy && !_expired;
            _btnBack.Enabled = !_busy;
            _btnReload.Enabled = !_busy;
            _btnNext.Enabled = active && _combosLoaded && _seats.Count > 0;
            _btnRemoveCombo.Enabled = active && SelectedComboId().HasValue;

            foreach (int id in _cards.Keys)
                UpdateCardVisual(id);
        }

        private void ShowMessage(string text, bool isError)
        {
            _lblMessage.Text = text;
            _lblMessage.ForeColor = isError ? AppColors.StatusRed : AppColors.Success;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _countdownTimer.Dispose();
            base.Dispose(disposing);
        }

        // Các control của 1 thẻ combo, để cập nhật số lượng/nút mà không phải tìm lại control
        private sealed class ComboCardRef
        {
            public Panel Card { get; }
            public Label Qty { get; }
            public PillButton Minus { get; }
            public PillButton Plus { get; }

            public ComboCardRef(Panel card, Label qty, PillButton minus, PillButton plus)
            {
                Card = card;
                Qty = qty;
                Minus = minus;
                Plus = plus;
            }
        }
    }
}

using CinemaManagement.BLL.Services.Sales;
using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Enums;
using CinemaManagement.UI.Theme;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // BƯỚC 3 của màn Bán vé: chọn ghế + giữ ghế + đếm ngược (PHASE 3).
    // Timer ở đây CHỈ để hiển thị/nhắc; database mới là nơi quyết định ghế còn được giữ hay không.
    public class SeatSelectionStepControl : UserControl
    {
        private readonly SaleMovieDto _movie;
        private readonly SaleShowtimeDto _showtime;

        private readonly SeatMapPanel _mapPanel = new() { Dock = DockStyle.Fill };
        private readonly Button _btnBack = new();
        private readonly Label _lblSeats = new();
        private readonly Label _lblTotal = new();
        private readonly Label _lblCountdown = new();
        private readonly Label _lblMessage = new();
        private readonly Button _btnHold = new();
        private readonly Button _btnRelease = new();
        private readonly Button _btnNext = new();

        private readonly System.Windows.Forms.Timer _countdownTimer = new() { Interval = 1000 };
        private readonly System.Windows.Forms.Timer _refreshTimer = new() { Interval = 10000 };

        private SeatMapDto? _map;
        private readonly HashSet<int> _selected = new();   // ghế đang chọn, CHƯA giữ
        private SeatHoldDto? _hold;                        // phiên giữ hiện tại (sau khi giữ thành công)
        private bool _busy;
        private bool _expiring;
        private int _mapVersion;

        public event Action? BackRequested;
        // Nhân viên bấm "Tiếp tục" và backend xác nhận ghế vẫn được giữ → bước Combo (Phase 4) nhận dữ liệu này
        public event Action<SeatHoldDto>? SeatsConfirmed;
        // Phiên giữ bị mất (hết hạn / bị chiếm) → các bước sau phải bỏ ghế khỏi đơn
        public event Action? HoldExpired;

        public SeatHoldDto? CurrentHold => _hold;

        public SeatSelectionStepControl(SaleMovieDto movie, SaleShowtimeDto showtime)
        {
            _movie = movie;
            _showtime = showtime;
            Dock = DockStyle.Fill;
            BackColor = AppColors.PageBackground;

            BuildLayout();
            WireEvents();
        }

        // ================= GIAO DIỆN =================
        private void BuildLayout()
        {
            // Thứ tự Add: Fill trước, rồi Right, rồi Top (giống các bước trước)
            Controls.Add(_mapPanel);
            Controls.Add(BuildRightPanel());
            Controls.Add(BuildTopPanel());
        }

        private Panel BuildTopPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Top, Height = 96, BackColor = AppColors.PageBackground };

            StyleButton(_btnBack, AppColors.InputBackground, AppColors.TextDark);
            _btnBack.Text = "← Quay lại";
            _btnBack.Size = new Size(120, 36);
            _btnBack.Location = new Point(24, 14);
            pnl.Controls.Add(_btnBack);

            pnl.Controls.Add(new Label
            {
                Text = "BƯỚC 03 — CHỌN GHẾ",
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
                ForeColor = AppColors.HeaderBackground,
                AutoSize = true,
                Left = 24,
                Top = 62
            });

            return pnl;
        }

        private Panel BuildRightPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Right, Width = 340, BackColor = AppColors.InputBackground };

            pnl.Controls.Add(MakeCaption("Ghế đã chọn", 16));

            _lblSeats.Left = 20; _lblSeats.Top = 42; _lblSeats.Width = 300; _lblSeats.Height = 56;
            _lblSeats.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblSeats.ForeColor = AppColors.TextDark;
            pnl.Controls.Add(_lblSeats);

            pnl.Controls.Add(MakeCaption("Tổng tiền vé", 106));

            _lblTotal.Left = 20; _lblTotal.Top = 130; _lblTotal.Width = 300; _lblTotal.Height = 38;
            _lblTotal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            _lblTotal.ForeColor = AppColors.HeaderBackground;
            pnl.Controls.Add(_lblTotal);

            pnl.Controls.Add(MakeCaption("Thời gian giữ ghế còn lại", 184));

            _lblCountdown.Left = 20; _lblCountdown.Top = 208; _lblCountdown.Width = 300; _lblCountdown.Height = 46;
            _lblCountdown.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            _lblCountdown.ForeColor = AppColors.TextMuted;
            _lblCountdown.Text = "--:--";
            pnl.Controls.Add(_lblCountdown);

            StyleButton(_btnHold, AppColors.Primary, Color.White);
            _btnHold.Text = $"GIỮ GHẾ ({SeatHoldConstants.HoldMinutes} phút)";
            _btnHold.Size = new Size(300, 48);
            _btnHold.Location = new Point(20, 270);
            pnl.Controls.Add(_btnHold);

            StyleButton(_btnRelease, Color.White, AppColors.StatusRed);
            _btnRelease.Text = "HỦY GIỮ GHẾ / CHỌN LẠI";
            _btnRelease.Size = new Size(300, 48);
            _btnRelease.Location = new Point(20, 270);
            _btnRelease.Visible = false;
            pnl.Controls.Add(_btnRelease);

            StyleButton(_btnNext, AppColors.Success, Color.White);
            _btnNext.Text = "TIẾP TỤC  →";
            _btnNext.Size = new Size(300, 48);
            _btnNext.Location = new Point(20, 330);
            _btnNext.Enabled = false;
            pnl.Controls.Add(_btnNext);

            _lblMessage.Left = 20; _lblMessage.Top = 396; _lblMessage.Width = 300; _lblMessage.Height = 110;
            _lblMessage.Font = new Font("Segoe UI", 10F);
            _lblMessage.ForeColor = AppColors.TextMuted;
            pnl.Controls.Add(_lblMessage);

            return pnl;
        }

        private static Label MakeCaption(string text, int top) => new()
        {
            Text = text,
            Left = 20,
            Top = top,
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F),
            ForeColor = AppColors.TextMuted
        };

        private static void StyleButton(Button b, Color back, Color fore)
        {
            b.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            b.BackColor = back;
            b.ForeColor = fore;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = fore == AppColors.StatusRed ? 1 : 0;
            b.FlatAppearance.BorderColor = AppColors.StatusRed;
            b.Cursor = Cursors.Hand;
        }

        // ================= SỰ KIỆN =================
        private void WireEvents()
        {
            _mapPanel.SeatClicked += OnSeatClicked;
            _btnBack.Click += async (s, e) => await GoBackAsync();
            _btnHold.Click += async (s, e) => await HoldAsync();
            _btnRelease.Click += async (s, e) => await ReleaseAsync();
            _btnNext.Click += async (s, e) => await ContinueAsync();

            _countdownTimer.Tick += async (s, e) => await OnCountdownTickAsync();
            _refreshTimer.Tick += async (s, e) => await OnRefreshTickAsync();

            Load += async (s, e) =>
            {
                await ReloadMapAsync();
                _refreshTimer.Start();
            };
        }

        // Gọi service với 1 scope riêng để luôn đọc dữ liệu mới nhất từ DB
        private static async Task<T> CallServiceAsync<T>(Func<ISeatHoldService, Task<T>> action)
        {
            using var scope = Program.Services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISeatHoldService>();
            return await action(service);
        }

        // ================= TẢI SƠ ĐỒ GHẾ =================
        private async Task ReloadMapAsync()
        {
            int version = ++_mapVersion;
            try
            {
                DateTime? heldAt = _hold?.HeldAt;
                List<int>? holdIds = _hold?.Seats.Select(x => x.SeatId).ToList();

                var result = await CallServiceAsync(sv => sv.GetSeatMapAsync(_showtime.ShowtimeId, heldAt, holdIds));
                if (version != _mapVersion || IsDisposed) return;

                if (!result.IsSuccess)
                {
                    ShowMessage(result.ErrorMessage!, true);
                    return;
                }

                _map = result.Data!;

                // Ghế đang chọn mà vừa bị người khác giữ/đặt → bỏ chọn
                List<SeatDto> lost = _map.Seats
                    .Where(s => _selected.Contains(s.SeatId) && s.Status != SeatStatus.Trong)
                    .ToList();

                _selected.RemoveWhere(id => !_map.Seats.Any(s => s.SeatId == id && s.Status == SeatStatus.Trong));

                if (lost.Count > 0)
                    ShowMessage($"Ghế {string.Join(", ", lost.Select(x => x.Label))} vừa được người khác giữ hoặc đặt nên đã bị bỏ chọn.", true);

                _mapPanel.SetData(_map, _selected);
                UpdateSummary();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không tải được sơ đồ ghế của suất {ShowtimeId}", _showtime.ShowtimeId);
                if (!IsDisposed) ShowMessage("Lỗi tải sơ đồ ghế. Vui lòng thử lại.", true);
            }
        }

        private async Task OnRefreshTickAsync()
        {
            if (_busy || IsDisposed) return;
            await ReloadMapAsync();

            // Đang giữ mà database cho biết ghế không còn là của mình → coi như mất phiên giữ
            if (_hold != null && _map != null && !_busy
                && _hold.Seats.Any(h => !_map.Seats.Any(s => s.SeatId == h.SeatId && s.IsHeldByMe)))
            {
                await HandleHoldLostAsync("Ghế đang giữ không còn hợp lệ (đã hết hạn hoặc bị chiếm). Vui lòng chọn lại ghế.");
            }
        }

        // ================= CHỌN GHẾ =================
        private void OnSeatClicked(SeatDto seat)
        {
            if (_busy) return;

            if (_hold != null)
            {
                ShowMessage("Đang giữ ghế. Bấm \"Hủy giữ ghế / chọn lại\" nếu muốn đổi ghế.", false);
                return;
            }

            if (seat.Status == SeatStatus.DaDat)
            {
                ShowMessage($"Ghế {seat.Label} đã được đặt, không thể chọn.", true);
                return;
            }
            if (seat.Status == SeatStatus.DangGiu)
            {
                ShowMessage($"Ghế {seat.Label} đang được nhân viên khác giữ, không thể chọn.", true);
                return;
            }

            if (!_selected.Remove(seat.SeatId))     // bấm lần nữa = bỏ chọn
                _selected.Add(seat.SeatId);

            ShowMessage(string.Empty, false);
            _mapPanel.Invalidate();
            UpdateSummary();
        }

        // ================= GIỮ GHẾ =================
        private async Task HoldAsync()
        {
            if (_busy || _hold != null || _selected.Count == 0) return;
            SetBusy(true);
            try
            {
                List<int> ids = _selected.ToList();
                var result = await CallServiceAsync(sv => sv.HoldSeatsAsync(_showtime.ShowtimeId, ids));

                if (!result.IsSuccess)
                {
                    await ReloadMapAsync();                       // cập nhật lại màu ghế trước
                    ShowMessage(result.ErrorMessage!, true);      // rồi mới hiện lý do (không bị ghi đè)
                    return;
                }

                _hold = result.Data!;
                _selected.Clear();
                _expiring = false;
                StartCountdown();
                await ReloadMapAsync();
                ShowMessage($"Đã giữ ghế {string.Join(", ", _hold.Seats.Select(x => x.Label))}. Hoàn tất trước khi hết giờ.", false);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi giữ ghế suất {ShowtimeId}", _showtime.ShowtimeId);
                ShowMessage("Không thể giữ ghế do lỗi hệ thống. Vui lòng thử lại.", true);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // ================= HỦY GIỮ =================
        private async Task ReleaseAsync()
        {
            if (_busy || _hold == null) return;
            SetBusy(true);
            try
            {
                SeatHoldDto hold = _hold;
                List<int> ids = hold.Seats.Select(x => x.SeatId).ToList();
                await CallServiceAsync(sv => sv.ReleaseSeatsAsync(_showtime.ShowtimeId, ids, hold.HeldAt));

                _countdownTimer.Stop();
                _hold = null;
                _lblCountdown.Text = "--:--";
                _lblCountdown.ForeColor = AppColors.TextMuted;
                await ReloadMapAsync();
                ShowMessage("Đã hủy giữ ghế. Bạn có thể chọn lại.", false);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi hủy giữ ghế suất {ShowtimeId}", _showtime.ShowtimeId);
                ShowMessage("Không thể hủy giữ ghế do lỗi hệ thống. Ghế sẽ tự nhả khi hết giờ.", true);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // ================= TIẾP TỤC =================
        private async Task ContinueAsync()
        {
            if (_busy || _hold == null) return;
            SetBusy(true);
            try
            {
                SeatHoldDto hold = _hold;
                List<int> ids = hold.Seats.Select(x => x.SeatId).ToList();

                // Backend kiểm tra lại database + tính lại giá, không tin dữ liệu đang hiện trên UI
                var result = await CallServiceAsync(sv => sv.ValidateHoldAsync(_showtime.ShowtimeId, ids, hold.HeldAt));
                if (!result.IsSuccess)
                {
                    await HandleHoldLostAsync(result.ErrorMessage!);
                    return;
                }

                _hold = result.Data!;
                UpdateSummary();
                SeatsConfirmed?.Invoke(_hold);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xác nhận ghế suất {ShowtimeId}", _showtime.ShowtimeId);
                ShowMessage("Không thể xác nhận ghế do lỗi hệ thống. Vui lòng thử lại.", true);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // ================= COUNTDOWN =================
        private void StartCountdown()
        {
            UpdateCountdownLabel();
            _countdownTimer.Start();
        }

        private async Task OnCountdownTickAsync()
        {
            if (_hold == null || IsDisposed) return;

            if (_hold.ExpiresAt - DateTime.Now <= TimeSpan.Zero)
            {
                if (_expiring) return;
                _expiring = true;
                await HandleHoldLostAsync("Đã hết thời gian giữ ghế. Ghế đã được trả về trạng thái Trống, vui lòng chọn lại.");
                return;
            }

            UpdateCountdownLabel();
        }

        private void UpdateCountdownLabel()
        {
            if (_hold == null) return;
            TimeSpan remaining = _hold.ExpiresAt - DateTime.Now;
            if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;

            _lblCountdown.Text = $"{(int)remaining.TotalMinutes:00}:{remaining.Seconds:00}";
            _lblCountdown.ForeColor = remaining.TotalSeconds <= 60 ? AppColors.StatusRed : AppColors.Success;
        }

        // Hết hạn hoặc bị chiếm: dừng đếm ngược, bỏ ghế khỏi danh sách, tải lại trạng thái thật từ DB
        private async Task HandleHoldLostAsync(string message)
        {
            _countdownTimer.Stop();
            _hold = null;
            _selected.Clear();
            _lblCountdown.Text = "00:00";
            _lblCountdown.ForeColor = AppColors.StatusRed;

            await ReloadMapAsync();      // GetSeatMapAsync reset ghế hết hạn về Trong trong DB
            ShowMessage(message, true);
            UpdateSummary();
            _expiring = false;
            HoldExpired?.Invoke();
        }

        // ================= QUAY LẠI / ĐÓNG =================
        private async Task GoBackAsync()
        {
            if (_busy) return;
            SetBusy(true);
            try
            {
                if (_hold != null)
                {
                    SeatHoldDto hold = _hold;
                    List<int> ids = hold.Seats.Select(x => x.SeatId).ToList();
                    try
                    {
                        await CallServiceAsync(sv => sv.ReleaseSeatsAsync(_showtime.ShowtimeId, ids, hold.HeldAt));
                    }
                    catch (Exception ex)
                    {
                        // Không chặn việc quay lại; ghế sẽ tự hết hạn sau vài phút
                        Log.Warning(ex, "Không nhả được ghế khi quay lại");
                    }
                    _hold = null;
                }
            }
            finally
            {
                SetBusy(false);
            }

            StopTimers();
            BackRequested?.Invoke();
        }

        // PHASE 4: bước Combo phát hiện phiên giữ ghế không còn hợp lệ → yêu cầu bước ghế bỏ phiên giữ và tải lại sơ đồ từ database.
        // Không làm gì nếu bước ghế đã tự xử lý xong (tránh báo lỗi 2 lần).
        public async Task NotifyHoldLostAsync(string message)
        {
            if (_hold == null || IsDisposed) return;
            await HandleHoldLostAsync(message);
        }

        // Dùng khi form Bán vé bị đóng: nhả ghế ở luồng nền, không chặn giao diện
        public void ReleaseHoldInBackground()
        {
            StopTimers();
            SeatHoldDto? hold = _hold;
            if (hold == null) return;
            _hold = null;

            int showtimeId = _showtime.ShowtimeId;
            List<int> ids = hold.Seats.Select(x => x.SeatId).ToList();
            DateTime heldAt = hold.HeldAt;

            _ = Task.Run(async () =>
            {
                try
                {
                    await CallServiceAsync(sv => sv.ReleaseSeatsAsync(showtimeId, ids, heldAt));
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "Không nhả được ghế khi đóng form (ghế sẽ tự hết hạn)");
                }
            });
        }

        // PHASE 5: thanh toán tiền mặt thành công. Ghế VẪN ở trạng thái DangGiu trong database (Phase 6 tạo vé rồi mới chuyển DaDat),
        // nên bước ghế chỉ dừng timer và bỏ phiên giữ khỏi bộ nhớ để KHÔNG tự hết hạn/nhả ghế khi đóng form. Không ghi database.
        public void CompleteHold()
        {
            StopTimers();
            _hold = null;
        }

        private void StopTimers()
        {
            _countdownTimer.Stop();
            _refreshTimer.Stop();
        }

        // ================= HIỂN THỊ =================
        private void SetBusy(bool busy)
        {
            _busy = busy;
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            List<SeatDto> shown;
            decimal total;

            if (_hold != null)
            {
                shown = _hold.Seats;
                total = _hold.TongTienVe;                 // do backend tính
            }
            else
            {
                shown = _map == null
                    ? new List<SeatDto>()
                    : _map.Seats.Where(s => _selected.Contains(s.SeatId)).OrderBy(s => s.Hang).ThenBy(s => s.Cot).ToList();
                total = shown.Sum(s => s.Gia);            // chỉ để hiển thị; lúc giữ ghế backend sẽ tính lại từ DB
            }

            _lblSeats.Text = shown.Count == 0
                ? "Chưa chọn ghế"
                : $"{string.Join(", ", shown.Select(s => s.Label))}  ({shown.Count} ghế)";
            _lblTotal.Text = $"{total:N0} đ";

            bool holding = _hold != null;
            _btnHold.Visible = !holding;
            _btnHold.Enabled = !_busy && _selected.Count > 0;
            _btnRelease.Visible = holding;
            _btnRelease.Enabled = !_busy;
            _btnNext.Enabled = !_busy && holding;
            _btnBack.Enabled = !_busy;
        }

        private void ShowMessage(string text, bool isError)
        {
            _lblMessage.Text = text;
            _lblMessage.ForeColor = isError ? AppColors.StatusRed : AppColors.Success;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _countdownTimer.Dispose();
                _refreshTimer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

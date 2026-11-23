using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cinema.WinForms.Forms
{
    public partial class TicketCheckInForm : Form
    {
        // =====================================================================
        // BẢNG MÀU CHUẨN GIAO DIỆN THEO ĐẶC TẢ
        // =====================================================================
        private readonly Color COLOR_SIDEBAR = Color.FromArgb(30, 41, 59);       // #1E293B
        private readonly Color COLOR_MENU_ACTIVE = Color.FromArgb(51, 65, 85);    // #334155
        private readonly Color COLOR_ACTIVE_BAR = Color.FromArgb(59, 130, 246);   // #3B82F6
        private readonly Color COLOR_MAIN_BG = Color.FromArgb(241, 245, 249);     // #F1F5F9
        private readonly Color COLOR_CARD_BG = Color.FromArgb(255, 255, 255);     // #FFFFFF
        private readonly Color COLOR_BORDER = Color.FromArgb(226, 232, 240);      // #E2E8F0
        private readonly Color COLOR_PRIMARY = Color.FromArgb(37, 99, 235);       // #2563EB
        private readonly Color COLOR_PRIMARY_HOVER = Color.FromArgb(29, 78, 216); // #1D4ED8
        private readonly Color COLOR_ACCENT = Color.FromArgb(217, 119, 6);        // #D97706
        private readonly Color COLOR_TEXT_MAIN = Color.FromArgb(15, 23, 42);      // #0F172A
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(100, 116, 139);  // #64748B

        // Màu trạng thái kết quả
        private readonly Color COLOR_SUCCESS_BG = Color.FromArgb(236, 253, 245);  // #ECFDF5
        private readonly Color COLOR_SUCCESS = Color.FromArgb(5, 150, 105);        // #059669
        private readonly Color COLOR_WARNING_BG = Color.FromArgb(255, 251, 235);  // #FFFBEB
        private readonly Color COLOR_WARNING = Color.FromArgb(217, 119, 6);        // #D97706
        private readonly Color COLOR_DANGER_BG = Color.FromArgb(254, 242, 242);   // #FEF2F2
        private readonly Color COLOR_DANGER = Color.FromArgb(220, 38, 38);        // #DC2626

        // Enum chế độ màn hình
        public enum ViewMode
        {
            SelectShowtime,
            Scanner,
            Logs
        }

        // Thông tin suất chiếu đang chọn để soát vé
        public class ShowtimeItem
        {
            public string RoomCode { get; set; } = "";
            public string RoomName { get; set; } = "";
            public string MovieTitle { get; set; } = "";
            public string AgeRating { get; set; } = "";
            public string TimeRange { get; set; } = "";
            public int SoldTickets { get; set; }
            public int TotalCapacity { get; set; }
            public int CheckedInCount { get; set; }
            public int RejectedCount { get; set; }
            public bool IsActiveNow { get; set; }
        }

        // Mô hình nhật ký soát vé
        public class CheckInLogItem
        {
            public string Time { get; set; } = "";
            public string Barcode { get; set; } = "";
            public string Seat { get; set; } = "";
            public string SeatType { get; set; } = "";
            public string Staff { get; set; } = "";
            public string Status { get; set; } = "";
            public string Detail { get; set; } = "";
        }

        private readonly List<ShowtimeItem> _showtimeList = new List<ShowtimeItem>();
        private readonly List<CheckInLogItem> _allLogs = new List<CheckInLogItem>();
        private ShowtimeItem? _currentShowtime;
        private ViewMode _currentView = ViewMode.SelectShowtime;

        // Trạng thái kết quả quét vé hiện tại
        private enum ScanStatusResult
        {
            Valid,
            AlreadyUsed,
            WrongRoom,
            NotFound
        }
        private ScanStatusResult _currentScanResult = ScanStatusResult.Valid;

        public TicketCheckInForm()
        {
            InitializeComponent();
        }

        private void TicketCheckInForm_Load(object sender, EventArgs e)
        {
            // 1. Cập nhật giờ đồng hồ
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

            // 2. Khởi tạo danh sách suất chiếu mẫu (Màn hình 1)
            InitializeSampleShowtimes();

            // 3. Khởi tạo dữ liệu mẫu nhật ký (Màn hình 3)
            InitializeSampleLogs();

            // 4. Mặc định chọn phòng đầu tiên đang mở cổng (Phòng 03)
            _currentShowtime = _showtimeList.Find(s => s.RoomCode == "PHÒNG 03") ?? _showtimeList[0];

            // 5. Cấu hình DataGridView phẳng, đẹp
            SetupLogsGridStyle();

            // 6. Hiển thị màn hình 1 (Chọn suất chiếu)
            SwitchView(ViewMode.SelectShowtime);

            // 7. Cập nhật dữ liệu View 1
            RenderShowtimeCards("Tất cả", true, true);
        }

        // =====================================================================
        // CHUYỂN ĐỔI MƯỢT MÀ GIỮA 3 MÀN HÌNH (FRONTEND VIEW SWITCHER)
        // =====================================================================
        public void SwitchView(ViewMode mode)
        {
            _currentView = mode;
            pnlViewSelectShowtime.Visible = (mode == ViewMode.SelectShowtime);
            pnlViewScanner.Visible = (mode == ViewMode.Scanner);
            pnlViewLogs.Visible = (mode == ViewMode.Logs);

            switch (mode)
            {
                case ViewMode.SelectShowtime:
                    pnlViewSelectShowtime.BringToFront();
                    lblFooterText.Text = "Hệ thống Soát Vé Rạp Chiếu Phim v2.6.4 | Sẵn sàng mở cổng kiểm soát vé vào rạp";
                    break;

                case ViewMode.Scanner:
                    pnlViewScanner.BringToFront();
                    UpdateScannerScreenData();
                    lblFooterText.Text = "Chế độ quét trực tiếp | Nhấn Space để xác nhận khách qua cổng | F4: Xem lịch sử quét";
                    txtInputBarcode.Focus();
                    break;

                case ViewMode.Logs:
                    pnlViewLogs.BringToFront();
                    UpdateLogsScreenData();
                    lblFooterText.Text = "Nhật ký soát vé trực tiếp | Lọc theo trạng thái và tìm kiếm thời gian thực";
                    txtSearchLogs.Focus();
                    break;
            }
        }

        // =====================================================================
        // MÀN HÌNH 1: KHỞI TẠO VÀ RENDER CÁC CARD SUẤT CHIẾU (PHÒNG 01 - 06)
        // =====================================================================
        private void InitializeSampleShowtimes()
        {
            _showtimeList.Clear();

            _showtimeList.Add(new ShowtimeItem
            {
                RoomCode = "PHÒNG 01",
                RoomName = "Cinema 01 - Tiêu Chuẩn 2D",
                MovieTitle = "DUNE: HÀNH TINH CÁT 2",
                AgeRating = "C16",
                TimeRange = "19:30 - 22:15",
                SoldTickets = 112,
                TotalCapacity = 120,
                CheckedInCount = 98,
                RejectedCount = 2,
                IsActiveNow = true
            });

            _showtimeList.Add(new ShowtimeItem
            {
                RoomCode = "PHÒNG 02",
                RoomName = "Cinema 02 - Dolby Atmos",
                MovieTitle = "KUNG FU PANDA 4",
                AgeRating = "P",
                TimeRange = "19:45 - 21:20",
                SoldTickets = 85,
                TotalCapacity = 90,
                CheckedInCount = 76,
                RejectedCount = 1,
                IsActiveNow = true
            });

            _showtimeList.Add(new ShowtimeItem
            {
                RoomCode = "PHÒNG 03",
                RoomName = "Cinema 03 - IMAX Laser VIP",
                MovieTitle = "MAI",
                AgeRating = "C18",
                TimeRange = "20:00 - 22:15",
                SoldTickets = 110,
                TotalCapacity = 140,
                CheckedInCount = 85,
                RejectedCount = 3,
                IsActiveNow = true
            });

            _showtimeList.Add(new ShowtimeItem
            {
                RoomCode = "PHÒNG 04",
                RoomName = "Cinema 04 - Tiêu Chuẩn 2D",
                MovieTitle = "QUỶ CẨU",
                AgeRating = "C18",
                TimeRange = "20:15 - 22:00",
                SoldTickets = 64,
                TotalCapacity = 80,
                CheckedInCount = 0,
                RejectedCount = 0,
                IsActiveNow = false
            });

            _showtimeList.Add(new ShowtimeItem
            {
                RoomCode = "PHÒNG 05",
                RoomName = "Cinema 05 - VIP Lounge",
                MovieTitle = "GODZILLA X KONG: ĐẾ CHẾ MỚI",
                AgeRating = "C13",
                TimeRange = "20:30 - 22:30",
                SoldTickets = 95,
                TotalCapacity = 150,
                CheckedInCount = 0,
                RejectedCount = 0,
                IsActiveNow = false
            });

            _showtimeList.Add(new ShowtimeItem
            {
                RoomCode = "PHÒNG 06",
                RoomName = "Cinema 06 - 3D Atmos",
                MovieTitle = "EXHUMA: QUẬT MỘ TRÙNG MA",
                AgeRating = "C18",
                TimeRange = "21:00 - 23:14",
                SoldTickets = 130,
                TotalCapacity = 140,
                CheckedInCount = 0,
                RejectedCount = 0,
                IsActiveNow = false
            });
        }

        private void RenderShowtimeCards(string roomFilter, bool showActive, bool showUpcoming)
        {
            flowShowtimes.SuspendLayout();
            flowShowtimes.Controls.Clear();

            foreach (var item in _showtimeList)
            {
                // Bộ lọc
                if (roomFilter != "Tất cả các phòng" && roomFilter != "Tất cả" && !item.RoomCode.Contains(roomFilter))
                    continue;

                if (item.IsActiveNow && !showActive)
                    continue;

                if (!item.IsActiveNow && !showUpcoming)
                    continue;

                Panel card = CreateShowtimeCardControl(item);
                flowShowtimes.Controls.Add(card);
            }

            flowShowtimes.ResumeLayout(true);
        }

        private Panel CreateShowtimeCardControl(ShowtimeItem item)
        {
            var card = new Panel
            {
                Width = 310,
                Height = 220,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 16, 16),
                Cursor = Cursors.Default
            };
            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(COLOR_BORDER, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            // Dòng trên cùng: Phòng chiếu & Badge trạng thái
            var lblRoom = new Label
            {
                Text = item.RoomCode,
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                ForeColor = COLOR_TEXT_MAIN,
                Location = new Point(16, 14),
                AutoSize = true
            };
            card.Controls.Add(lblRoom);

            var lblBadge = new Label
            {
                Text = item.IsActiveNow ? "● ĐANG MỞ CỔNG" : "○ SẮP MỞ CỔNG",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = item.IsActiveNow ? COLOR_SUCCESS : COLOR_ACCENT,
                BackColor = item.IsActiveNow ? COLOR_SUCCESS_BG : COLOR_WARNING_BG,
                Location = new Point(175, 14),
                Size = new Size(120, 24),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblBadge);

            // Tên phim
            var lblMovie = new Label
            {
                Text = item.MovieTitle,
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                ForeColor = COLOR_PRIMARY,
                Location = new Point(16, 44),
                Size = new Size(220, 22),
                AutoEllipsis = true
            };
            card.Controls.Add(lblMovie);

            // Badge độ tuổi
            var lblAge = new Label
            {
                Text = item.AgeRating,
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = item.AgeRating == "C18" ? Color.FromArgb(220, 38, 38) :
                            item.AgeRating == "C16" ? Color.FromArgb(234, 88, 12) :
                            item.AgeRating == "C13" ? Color.FromArgb(217, 119, 6) : Color.FromArgb(16, 185, 129),
                Location = new Point(245, 44),
                Size = new Size(50, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblAge);

            // Suất chiếu thời gian
            var lblTime = new Label
            {
                Text = $"Suất: {item.TimeRange}",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = COLOR_TEXT_MUTED,
                Location = new Point(16, 72),
                AutoSize = true
            };
            card.Controls.Add(lblTime);

            // Progress vé đã bán / công suất
            int percent = (int)Math.Round((double)item.SoldTickets * 100 / item.TotalCapacity);
            var lblTickets = new Label
            {
                Text = $"Vé đã bán: {item.SoldTickets}/{item.TotalCapacity} ({percent}%)",
                Font = new Font("Segoe UI", 9f, FontStyle.Regular),
                ForeColor = COLOR_TEXT_MAIN,
                Location = new Point(16, 100),
                AutoSize = true
            };
            card.Controls.Add(lblTickets);

            // Thanh ProgressBar giả lập tùy chỉnh đẹp
            var pnlProgressBg = new Panel
            {
                Location = new Point(16, 122),
                Size = new Size(278, 8),
                BackColor = Color.FromArgb(241, 245, 249)
            };
            int fillWidth = (int)(278.0 * item.SoldTickets / item.TotalCapacity);
            var pnlProgressFill = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(fillWidth, 8),
                BackColor = item.IsActiveNow ? COLOR_PRIMARY : Color.FromArgb(148, 163, 184)
            };
            pnlProgressBg.Controls.Add(pnlProgressFill);
            card.Controls.Add(pnlProgressBg);

            // Nút Bắt đầu soát vé
            var btnEnter = new Button
            {
                Text = item.IsActiveNow ? "BẮT ĐẦU SOÁT VÉ SUẤT NÀY →" : "MỞ CỔNG SỚM SUẤT NÀY →",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location = new Point(16, 150),
                Size = new Size(278, 44),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnEnter.FlatAppearance.BorderSize = 0;

            if (item.IsActiveNow)
            {
                btnEnter.BackColor = COLOR_PRIMARY;
                btnEnter.ForeColor = Color.White;
            }
            else
            {
                btnEnter.BackColor = Color.FromArgb(241, 245, 249);
                btnEnter.ForeColor = COLOR_TEXT_MAIN;
                btnEnter.FlatAppearance.BorderColor = COLOR_BORDER;
                btnEnter.FlatAppearance.BorderSize = 1;
            }

            btnEnter.Click += (s, e) =>
            {
                _currentShowtime = item;
                SwitchView(ViewMode.Scanner);
            };
            card.Controls.Add(btnEnter);

            return card;
        }

        private void cboRoomFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyShowtimeFilter();
        }

        private void btnFilterActive_Click(object sender, EventArgs e)
        {
            btnFilterActive.BackColor = (btnFilterActive.BackColor == COLOR_PRIMARY) ? Color.White : COLOR_PRIMARY;
            btnFilterActive.ForeColor = (btnFilterActive.BackColor == COLOR_PRIMARY) ? Color.White : COLOR_TEXT_MAIN;
            ApplyShowtimeFilter();
        }

        private void btnFilterUpcoming_Click(object sender, EventArgs e)
        {
            btnFilterUpcoming.BackColor = (btnFilterUpcoming.BackColor == COLOR_PRIMARY) ? Color.White : COLOR_PRIMARY;
            btnFilterUpcoming.ForeColor = (btnFilterUpcoming.BackColor == COLOR_PRIMARY) ? Color.White : COLOR_TEXT_MAIN;
            ApplyShowtimeFilter();
        }

        private void ApplyShowtimeFilter()
        {
            string room = cboRoomFilter.SelectedItem?.ToString() ?? "Tất cả";
            bool active = btnFilterActive.BackColor == COLOR_PRIMARY;
            bool upcoming = btnFilterUpcoming.BackColor == COLOR_PRIMARY;

            // Nếu cả hai đều bỏ chọn thì hiển thị cả hai
            if (!active && !upcoming)
            {
                active = true;
                upcoming = true;
            }

            RenderShowtimeCards(room, active, upcoming);
        }

        // =====================================================================
        // MÀN HÌNH 2: SOÁT VÉ TRỰC TIẾP (QUÉT MÃ QR & HIỂN THỊ KẾT QUẢ)
        // =====================================================================
        private void UpdateScannerScreenData()
        {
            if (_currentShowtime == null) return;

            lblActiveShowtimeTitle.Text = $"{_currentShowtime.RoomCode} - {_currentShowtime.MovieTitle} ({_currentShowtime.AgeRating}) | {_currentShowtime.TimeRange} (Đang mở cổng)";
            lblCheckInCountBadge.Text = $"ĐÃ VÀO: {_currentShowtime.CheckedInCount} / {_currentShowtime.SoldTickets} KHÁCH";

            lblBoxRoomTitle.Text = _currentShowtime.RoomCode;
            lblBoxRoomSubtitle = lblBoxRoomSubtitle ?? new Label();
            lblBoxRoomSubtitle.Text = $"Tầng 2 - Cửa vào chính";

            // Áp dụng trạng thái mặc định: Vé Hợp Lệ
            ShowMockValid();
        }

        private void btnChangeShowtime_Click(object sender, EventArgs e)
        {
            SwitchView(ViewMode.SelectShowtime);
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            SwitchView(ViewMode.Logs);
        }

        private void btnCheckBarcode_Click(object sender, EventArgs e)
        {
            ProcessScan(txtInputBarcode.Text.Trim());
        }

        private void txtInputBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessScan(txtInputBarcode.Text.Trim());
            }
        }

        private void ProcessScan(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                ShowMockValid();
                return;
            }

            if (barcode.Contains("USED") || barcode.EndsWith("2"))
            {
                ShowMockAlreadyUsed(barcode);
            }
            else if (barcode.Contains("WRONG") || barcode.EndsWith("3"))
            {
                ShowMockWrongRoom(barcode);
            }
            else if (barcode.Contains("NOTFOUND") || barcode.EndsWith("4"))
            {
                ShowMockNotFound(barcode);
            }
            else
            {
                ShowMockValid(barcode);
            }

            txtInputBarcode.SelectAll();
        }

        // Mock 1: Vé hợp lệ
        private void btnMock1Valid_Click(object sender, EventArgs e)
        {
            ShowMockValid("TK20261123-0892");
        }

        // Mock 2: Vé đã sử dụng
        private void btnMock2Used_Click(object sender, EventArgs e)
        {
            ShowMockAlreadyUsed("TK20261123-0410");
        }

        // Mock 3: Sai phòng chiếu
        private void btnMock3Wrong_Click(object sender, EventArgs e)
        {
            ShowMockWrongRoom("TK20261123-0105");
        }

        // Mock 4: Vé không tồn tại
        private void btnMock4NotFound_Click(object sender, EventArgs e)
        {
            ShowMockNotFound("TK99999999-9999");
        }

        private void ShowMockValid(string barcode = "TK20261123-0892")
        {
            _currentScanResult = ScanStatusResult.Valid;

            picCheckmark.Invalidate();
            lblResultMain.Text = "Vé HỢP LỆ - MỜI KHÁCH VÀO RẠP";
            lblResultMain.ForeColor = COLOR_SUCCESS;
            lblResultSub.Text = $"Mã vé: {barcode} | Quét lúc {DateTime.Now:HH:mm:ss}";

            lblBoxSeatCodes.Text = "G07, G08";
            lblBoxSeatQty.Text = "02 vé VIP đôi";

            lblBoxRoomTitle.Text = _currentShowtime?.RoomCode ?? "PHÒNG 03";
            lblBoxRoomSubtitle.Text = "Tầng 2 - Cửa B";

            pnlAgeWarning.Visible = true;
            lblAgeWarning.Text = "LƯU Ý: Phim phân loại C16 – YÊU CẦU KIỂM TRA CCCD/GIẤY TỜ KHÁCH HÀNG!";

            btnConfirmPass.Text = "XÁC NHẬN QUA CỔNG (Space)";
            btnConfirmPass.BackColor = COLOR_PRIMARY;
            btnConfirmPass.Enabled = true;
        }

        private void ShowMockAlreadyUsed(string barcode)
        {
            _currentScanResult = ScanStatusResult.AlreadyUsed;

            picCheckmark.Invalidate();
            lblResultMain.Text = "CẢNH BÁO: VÉ ĐÃ ĐƯỢC SỬ DỤNG!";
            lblResultMain.ForeColor = COLOR_WARNING;
            lblResultSub.Text = $"Mã vé: {barcode} | Đã qua cổng lúc 19:42:10";

            lblBoxSeatCodes.Text = "E04";
            lblBoxSeatQty.Text = "01 vé Tiêu chuẩn";

            lblBoxRoomTitle.Text = _currentShowtime?.RoomCode ?? "PHÒNG 03";
            lblBoxRoomSubtitle.Text = "Đã qua cổng cách đây 12 phút";

            pnlAgeWarning.Visible = false;

            btnConfirmPass.Text = "VÉ ĐÃ DÙNG - KHÔNG THỂ QUA CỔNG";
            btnConfirmPass.BackColor = Color.FromArgb(148, 163, 184);
            btnConfirmPass.Enabled = false;
        }

        private void ShowMockWrongRoom(string barcode)
        {
            _currentScanResult = ScanStatusResult.WrongRoom;

            picCheckmark.Invalidate();
            lblResultMain.Text = "LỖI: VÉ THUỘC PHÒNG CHIẾU KHÁC!";
            lblResultMain.ForeColor = COLOR_DANGER;
            lblResultSub.Text = $"Mã vé: {barcode} | Vé thuộc: PHÒNG 01 (Dune 2 - 19:30)";

            lblBoxSeatCodes.Text = "A02";
            lblBoxSeatQty.Text = "01 vé Thường";

            lblBoxRoomTitle.Text = "PHÒNG 01";
            lblBoxRoomSubtitle.Text = "Khách đi nhầm vào Phòng 03";

            pnlAgeWarning.Visible = false;

            btnConfirmPass.Text = "SAI PHÒNG - TỪ CHỐI QUA CỔNG";
            btnConfirmPass.BackColor = Color.FromArgb(148, 163, 184);
            btnConfirmPass.Enabled = false;
        }

        private void ShowMockNotFound(string barcode)
        {
            _currentScanResult = ScanStatusResult.NotFound;

            picCheckmark.Invalidate();
            lblResultMain.Text = "LỖI: MÃ VÉ KHÔNG TỒN TẠI!";
            lblResultMain.ForeColor = COLOR_DANGER;
            lblResultSub.Text = $"Mã vé: {barcode} | Không tìm thấy trên hệ thống máy chủ";

            lblBoxSeatCodes.Text = "---";
            lblBoxSeatQty.Text = "Không xác định";

            lblBoxRoomTitle.Text = "---";
            lblBoxRoomSubtitle.Text = "Mã không hợp lệ";

            pnlAgeWarning.Visible = false;

            btnConfirmPass.Text = "MÃ KHÔNG TỒN TẠI";
            btnConfirmPass.BackColor = Color.FromArgb(148, 163, 184);
            btnConfirmPass.Enabled = false;
        }

        private void btnConfirmPass_Click(object sender, EventArgs e)
        {
            if (_currentScanResult != ScanStatusResult.Valid) return;

            // Tăng bộ đếm khách
            if (_currentShowtime != null && _currentShowtime.CheckedInCount < _currentShowtime.SoldTickets)
            {
                _currentShowtime.CheckedInCount++;
                lblCheckInCountBadge.Text = $"ĐÃ VÀO: {_currentShowtime.CheckedInCount} / {_currentShowtime.SoldTickets} KHÁCH";
            }

            // Ghi nhật ký vào danh sách
            _allLogs.Insert(0, new CheckInLogItem
            {
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Barcode = "TK" + DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(1000, 9999),
                Seat = lblBoxSeatCodes.Text,
                SeatType = "VIP",
                Staff = "Nguyễn Văn A (NV002)",
                Status = "HỢP LỆ",
                Detail = "Khách vào rạp thành công"
            });

            // Hiệu ứng flash nút bấm
            btnConfirmPass.Text = "✔ ĐÃ XÁC NHẬN CHO KHÁCH VÀO";
            btnConfirmPass.BackColor = COLOR_SUCCESS;

            var tmr = new System.Windows.Forms.Timer { Interval = 1200 };
            tmr.Tick += (s, ev) =>
            {
                tmr.Stop();
                tmr.Dispose();
                btnConfirmPass.Text = "XÁC NHẬN QUA CỔNG (Space)";
                btnConfirmPass.BackColor = COLOR_PRIMARY;
                txtInputBarcode.Clear();
                txtInputBarcode.Focus();
            };
            tmr.Start();
        }

        // =====================================================================
        // MÀN HÌNH 3: NHẬT KÝ SOÁT VÉ (BẢNG, BỘ LỌC, TÌM KIẾM, PHÂN TRANG)
        // =====================================================================
        private void InitializeSampleLogs()
        {
            _allLogs.Clear();
            _allLogs.Add(new CheckInLogItem { Time = "19:54:12", Barcode = "TK20261123-0892", Seat = "G07, G08", SeatType = "VIP Đôi", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
            _allLogs.Add(new CheckInLogItem { Time = "19:51:30", Barcode = "TK20261123-0781", Seat = "F04, F05", SeatType = "VIP", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
            _allLogs.Add(new CheckInLogItem { Time = "19:48:05", Barcode = "TK20261123-0410", Seat = "E04", SeatType = "Thường", Staff = "Nguyễn Văn A (NV002)", Status = "ĐÃ SỬ DỤNG", Detail = "Vé đã quét lúc 19:42:10" });
            _allLogs.Add(new CheckInLogItem { Time = "19:45:22", Barcode = "TK20261123-0105", Seat = "A02", SeatType = "Thường", Staff = "Nguyễn Văn A (NV002)", Status = "SAI PHÒNG", Detail = "Vé thuộc Phòng 01 (Dune 2)" });
            _allLogs.Add(new CheckInLogItem { Time = "19:40:18", Barcode = "TK20261123-0665", Seat = "H11, H12", SeatType = "VIP Đôi", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
            _allLogs.Add(new CheckInLogItem { Time = "19:38:40", Barcode = "TK20261123-0552", Seat = "D08", SeatType = "Thường", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
            _allLogs.Add(new CheckInLogItem { Time = "19:35:10", Barcode = "TK99999999-9999", Seat = "---", SeatType = "---", Staff = "Nguyễn Văn A (NV002)", Status = "KHÔNG TỒN TẠI", Detail = "Mã vé không tìm thấy" });
            _allLogs.Add(new CheckInLogItem { Time = "19:32:00", Barcode = "TK20261123-0312", Seat = "C05, C06", SeatType = "Thường", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
            _allLogs.Add(new CheckInLogItem { Time = "19:28:44", Barcode = "TK20261123-0210", Seat = "B01, B02", SeatType = "Thường", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
            _allLogs.Add(new CheckInLogItem { Time = "19:25:02", Barcode = "TK20261123-0199", Seat = "G01", SeatType = "VIP", Staff = "Nguyễn Văn A (NV002)", Status = "HỢP LỆ", Detail = "Khách vào rạp thành công" });
        }

        private void SetupLogsGridStyle()
        {
            dgvLogs.BorderStyle = BorderStyle.None;
            dgvLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLogs.GridColor = Color.FromArgb(241, 245, 249);
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.MultiSelect = false;
            dgvLogs.BackgroundColor = Color.White;
            dgvLogs.RowTemplate.Height = 38;
            dgvLogs.ColumnHeadersHeight = 38;
            dgvLogs.EnableHeadersVisualStyles = false;
        }

        private void UpdateLogsScreenData()
        {
            if (_currentShowtime != null)
            {
                lblLogsScreenTitle.Text = $"NHẬT KÝ SOÁT VÉ - {_currentShowtime.RoomCode} ({_currentShowtime.MovieTitle} - {_currentShowtime.TimeRange.Split('-')[0].Trim()})";
                lblKpiTotalVal.Text = _currentShowtime.SoldTickets.ToString();
                lblKpiScannedVal.Text = _currentShowtime.CheckedInCount.ToString();
                lblKpiRemainingVal.Text = (_currentShowtime.SoldTickets - _currentShowtime.CheckedInCount).ToString();
                lblKpiRejectedVal.Text = $"{_currentShowtime.RejectedCount} lượt";
            }

            ApplyLogsFilter();
        }

        private void btnBackToScanner_Click(object sender, EventArgs e)
        {
            SwitchView(ViewMode.Scanner);
        }

        private string _selectedLogTab = "ALL";

        private void btnFilterTabAll_Click(object sender, EventArgs e)
        {
            SetLogFilterTab("ALL");
        }

        private void btnFilterTabSuccess_Click(object sender, EventArgs e)
        {
            SetLogFilterTab("SUCCESS");
        }

        private void btnFilterTabRejected_Click(object sender, EventArgs e)
        {
            SetLogFilterTab("REJECTED");
        }

        private void SetLogFilterTab(string tab)
        {
            _selectedLogTab = tab;

            btnFilterTabAll.BackColor = (tab == "ALL") ? COLOR_PRIMARY : Color.White;
            btnFilterTabAll.ForeColor = (tab == "ALL") ? Color.White : COLOR_TEXT_MAIN;

            btnFilterTabSuccess.BackColor = (tab == "SUCCESS") ? COLOR_PRIMARY : Color.White;
            btnFilterTabSuccess.ForeColor = (tab == "SUCCESS") ? Color.White : COLOR_TEXT_MAIN;

            btnFilterTabRejected.BackColor = (tab == "REJECTED") ? COLOR_PRIMARY : Color.White;
            btnFilterTabRejected.ForeColor = (tab == "REJECTED") ? Color.White : COLOR_TEXT_MAIN;

            ApplyLogsFilter();
        }

        private void txtSearchLogs_TextChanged(object sender, EventArgs e)
        {
            ApplyLogsFilter();
        }

        private void ApplyLogsFilter()
        {
            string keyword = txtSearchLogs.Text.Trim().ToLower();

            dgvLogs.Rows.Clear();
            foreach (var log in _allLogs)
            {
                // Bộ lọc tab
                if (_selectedLogTab == "SUCCESS" && log.Status != "HỢP LỆ")
                    continue;
                if (_selectedLogTab == "REJECTED" && log.Status == "HỢP LỆ")
                    continue;

                // Bộ lọc tìm kiếm
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    if (!log.Barcode.ToLower().Contains(keyword) &&
                        !log.Seat.ToLower().Contains(keyword) &&
                        !log.Staff.ToLower().Contains(keyword) &&
                        !log.Detail.ToLower().Contains(keyword))
                    {
                        continue;
                    }
                }

                dgvLogs.Rows.Add(log.Time, log.Barcode, log.Seat, log.SeatType, log.Staff, log.Status, log.Detail);
            }

            lblShowingCount.Text = $"Hiển thị {dgvLogs.Rows.Count} trên tổng số {_allLogs.Count} lượt quét vé";
        }

        private void dgvLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == colLogStatus.Index && e.Value != null)
            {
                string status = e.Value.ToString() ?? "";
                if (status == "HỢP LỆ")
                {
                    e.CellStyle.ForeColor = COLOR_SUCCESS;
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (status == "ĐÃ SỬ DỤNG")
                {
                    e.CellStyle.ForeColor = COLOR_WARNING;
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = COLOR_DANGER;
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
        }

        // =====================================================================
        // PAINT EVENTS VẼ ICON, KHUNG BO TRÒN VÀ VIỀN
        // =====================================================================
        private void picLogoIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(COLOR_PRIMARY))
            {
                e.Graphics.FillEllipse(b, 2, 2, 32, 32);
            }
            using (var b = new SolidBrush(Color.White))
            {
                var font = new Font("Segoe UI", 12f, FontStyle.Bold);
                e.Graphics.DrawString("S", font, b, new PointF(10, 6));
            }
        }

        private void picStaffAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                e.Graphics.FillEllipse(b, 1, 1, 34, 34);
            }
            using (var b = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                var font = new Font("Segoe UI", 10f, FontStyle.Bold);
                e.Graphics.DrawString("NV", font, b, new PointF(8, 8));
            }
        }

        private void pnlBorderBottom_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            using (var pen = new Pen(COLOR_BORDER, 1))
            {
                e.Graphics.DrawLine(pen, 0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
            }
        }

        private void pnlBorderTop_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            using (var pen = new Pen(COLOR_BORDER, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnl.Width, 0);
            }
        }

        private void pnlBorderRight_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            using (var pen = new Pen(COLOR_BORDER, 1))
            {
                e.Graphics.DrawLine(pen, pnl.Width - 1, 0, pnl.Width - 1, pnl.Height);
            }
        }

        private void pnlCardBorder_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            using (var pen = new Pen(COLOR_BORDER, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }

        private void pnlCameraBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Vẽ 4 góc định vị camera màu xanh
            using (var pen = new Pen(Color.FromArgb(16, 185, 129), 3))
            {
                int len = 24;
                int pad = 20;
                int w = pnlCameraBox.Width - pad;
                int h = pnlCameraBox.Height - pad;

                // Top-left
                e.Graphics.DrawLine(pen, pad, pad, pad + len, pad);
                e.Graphics.DrawLine(pen, pad, pad, pad, pad + len);

                // Top-right
                e.Graphics.DrawLine(pen, w - len, pad, w, pad);
                e.Graphics.DrawLine(pen, w, pad, w, pad + len);

                // Bottom-left
                e.Graphics.DrawLine(pen, pad, h - len, pad, h);
                e.Graphics.DrawLine(pen, pad, h, pad + len, h);

                // Bottom-right
                e.Graphics.DrawLine(pen, w - len, h, w, h);
                e.Graphics.DrawLine(pen, w, h - len, w, h);
            }
        }

        private void picPhoneMockup_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Vẽ mô phỏng màn hình điện thoại có mã QR
            int w = picPhoneMockup.Width;
            int h = picPhoneMockup.Height;

            using (var pen = new Pen(Color.FromArgb(71, 85, 105), 2))
            {
                e.Graphics.DrawRectangle(pen, 20, 10, w - 40, h - 20);
            }

            // Vẽ khối QR mẫu ở giữa
            using (var b = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(b, 35, 30, w - 70, h - 60);
            }

            using (var pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, 45, 40, 24, 24);
                e.Graphics.DrawRectangle(pen, w - 69, 40, 24, 24);
                e.Graphics.DrawRectangle(pen, 45, h - 64, 24, 24);
            }
        }

        private void picCheckmark_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int size = 56;
            int x = (picCheckmark.Width - size) / 2;
            int y = (picCheckmark.Height - size) / 2;

            if (_currentScanResult == ScanStatusResult.Valid)
            {
                // Vòng tròn xanh lá + Dấu tick
                using (var b = new SolidBrush(COLOR_SUCCESS))
                {
                    e.Graphics.FillEllipse(b, x, y, size, size);
                }
                using (var pen = new Pen(Color.White, 4))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    e.Graphics.DrawLine(pen, x + 15, y + 29, x + 24, y + 38);
                    e.Graphics.DrawLine(pen, x + 24, y + 38, x + 41, y + 20);
                }
            }
            else if (_currentScanResult == ScanStatusResult.AlreadyUsed)
            {
                // Vòng tròn vàng + Dấu chấm than
                using (var b = new SolidBrush(COLOR_WARNING))
                {
                    e.Graphics.FillEllipse(b, x, y, size, size);
                }
                using (var b = new SolidBrush(Color.White))
                {
                    var font = new Font("Segoe UI", 26f, FontStyle.Bold);
                    e.Graphics.DrawString("!", font, b, new PointF(x + 19, y + 6));
                }
            }
            else
            {
                // Vòng tròn đỏ + Dấu X
                using (var b = new SolidBrush(COLOR_DANGER))
                {
                    e.Graphics.FillEllipse(b, x, y, size, size);
                }
                using (var pen = new Pen(Color.White, 4))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    e.Graphics.DrawLine(pen, x + 18, y + 18, x + 38, y + 38);
                    e.Graphics.DrawLine(pen, x + 38, y + 18, x + 18, y + 38);
                }
            }
        }

        private void pnlAgeWarning_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(253, 230, 138), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnlAgeWarning.Width - 1, pnlAgeWarning.Height - 1);
            }
        }

        private void picKpiTotal_Paint(object sender, PaintEventArgs e)
        {
            DrawKpiIcon(e.Graphics, COLOR_PRIMARY, "🎟");
        }

        private void picKpiScanned_Paint(object sender, PaintEventArgs e)
        {
            DrawKpiIcon(e.Graphics, COLOR_SUCCESS, "✔");
        }

        private void picKpiRemaining_Paint(object sender, PaintEventArgs e)
        {
            DrawKpiIcon(e.Graphics, COLOR_ACCENT, "⏳");
        }

        private void picKpiRejected_Paint(object sender, PaintEventArgs e)
        {
            DrawKpiIcon(e.Graphics, COLOR_DANGER, "✖");
        }

        private void DrawKpiIcon(Graphics g, Color bg, string symbol)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Color.FromArgb(30, bg.R, bg.G, bg.B)))
            {
                g.FillEllipse(b, 2, 2, 40, 40);
            }
            using (var b = new SolidBrush(bg))
            {
                var font = new Font("Segoe UI", 12f, FontStyle.Bold);
                g.DrawString(symbol, font, b, new PointF(10, 10));
            }
        }

        // =====================================================================
        // TIMER VÀ XỬ LÝ PHÍM TẮT TOÀN CỤC (HOTKEYS)
        // =====================================================================
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void TicketCheckInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                if (_currentView == ViewMode.Scanner)
                    SwitchView(ViewMode.Logs);
                else if (_currentView == ViewMode.Logs)
                    SwitchView(ViewMode.Scanner);
            }
            else if (e.KeyCode == Keys.Space && _currentView == ViewMode.Scanner && !txtInputBarcode.Focused)
            {
                e.SuppressKeyPress = true;
                btnConfirmPass.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape && _currentView == ViewMode.Logs)
            {
                e.SuppressKeyPress = true;
                SwitchView(ViewMode.Scanner);
            }
        }
    }
}

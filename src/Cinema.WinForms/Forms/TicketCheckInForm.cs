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
        private readonly Color COLOR_ACCENT = Color.FromArgb(217, 119, 6);        // #D97706
        private readonly Color COLOR_TEXT_MAIN = Color.FromArgb(15, 23, 42);      // #0F172A
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(100, 116, 139);  // #64748B

        // Màu ngữ cảnh kết quả soát vé
        private readonly Color COLOR_SUCCESS_BG = Color.FromArgb(236, 253, 245);
        private readonly Color COLOR_SUCCESS_TEXT = Color.FromArgb(5, 150, 105);
        private readonly Color COLOR_WARNING_BG = Color.FromArgb(255, 251, 235);
        private readonly Color COLOR_WARNING_TEXT = Color.FromArgb(217, 119, 6);
        private readonly Color COLOR_DANGER_BG = Color.FromArgb(254, 242, 242);
        private readonly Color COLOR_DANGER_TEXT = Color.FromArgb(220, 38, 38);
        private readonly Color COLOR_ORANGE_BG = Color.FromArgb(255, 247, 237);
        private readonly Color COLOR_ORANGE_TEXT = Color.FromArgb(234, 88, 12);

        // Biến đếm thống kê mẫu (Frontend Mock State)
        private int _totalTickets = 80;
        private int _scannedTickets = 54;
        private int _remainingTickets = 26;

        public TicketCheckInForm()
        {
            InitializeComponent();
        }

        private void TicketCheckInForm_Load(object sender, EventArgs e)
        {
            // 1. Nạp danh sách Phòng chiếu mẫu vào ComboBox
            cboAuditorium.Items.Clear();
            cboAuditorium.Items.Add("Cinema 01 - Tiêu Chuẩn (2D)");
            cboAuditorium.Items.Add("Cinema 02 - Dolby Atmos (3D)");
            cboAuditorium.Items.Add("Cinema 03 - IMAX Laser (VIP)");
            cboAuditorium.SelectedIndex = 0;

            // 2. Nạp Suất chiếu mẫu tương ứng
            LoadShowtimesForSelectedAuditorium();

            // 3. Khởi tạo dữ liệu mẫu cho Bảng Nhật ký soát vé
            InitializeSampleLogs();

            // 4. Cập nhật thẻ KPI
            UpdateKpiDisplay();

            // 5. Cập nhật giờ hiện tại
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

            // 6. Focus ô nhập mã vạch để sẵn sàng nhận tín hiệu máy quét
            txtBarcode.Focus();
        }

        private void LoadShowtimesForSelectedAuditorium()
        {
            cboShowtime.Items.Clear();
            int selectedAud = cboAuditorium.SelectedIndex;

            if (selectedAud == 0) // Cinema 01
            {
                cboShowtime.Items.Add("18:00 - 20:11 | Mai (T18) - Đang chiếu");
                cboShowtime.Items.Add("20:30 - 22:44 | Đất Rừng Phương Nam (K) - Sắp chiếu");
                cboShowtime.Items.Add("13:00 - 15:11 | Mai (T18) - Đã xong");
            }
            else if (selectedAud == 1) // Cinema 02
            {
                cboShowtime.Items.Add("19:00 - 20:34 | Kung Fu Panda 4 (P) - Đang chiếu");
                cboShowtime.Items.Add("21:00 - 22:55 | Godzilla x Kong (T13) - Sắp chiếu");
            }
            else // Cinema 03
            {
                cboShowtime.Items.Add("16:00 - 18:46 | Dune: Part Two (T16) - Đã xong");
                cboShowtime.Items.Add("20:00 - 22:46 | Dune: Part Two (T16) - Đang chiếu");
            }

            if (cboShowtime.Items.Count > 0)
                cboShowtime.SelectedIndex = 0;
        }

        private void InitializeSampleLogs()
        {
            dgvCheckInLogs.Rows.Clear();
            dgvCheckInLogs.Rows.Add("20:01:15", "TK20240410001D05", "Mai (T18)", "Cinema 01", "E05 (VIP)", "Trần M. Hoàng", "HỢP LỆ", "Khách vào cửa");
            dgvCheckInLogs.Rows.Add("19:58:40", "TK20240410001D06", "Mai (T18)", "Cinema 01", "E06 (VIP)", "Trần M. Hoàng", "HỢP LỆ", "Khách vào cửa");
            dgvCheckInLogs.Rows.Add("19:55:12", "TK20240410002B05", "Mai (T18)", "Cinema 01", "B05", "Khách vãng lai", "HỢP LỆ", "Khách vào cửa");
            dgvCheckInLogs.Rows.Add("19:51:02", "TK20240410002B06", "Mai (T18)", "Cinema 01", "B06", "Khách vãng lai", "ĐÃ QUÉT", "Đã quét lúc 19:40");
            dgvCheckInLogs.Rows.Add("19:48:33", "TK20240410003A01", "Dune 2 (T16)", "Cinema 03", "A01", "Lê Quốc Bảo", "SAI PHÒNG", "Vé thuộc Cinema 03");
            dgvCheckInLogs.Rows.Add("19:42:10", "TK9999999999", "---", "---", "---", "---", "KHÔNG CÓ", "Mã vé không tồn tại");
            dgvCheckInLogs.Rows.Add("19:35:18", "TK20240410001C03", "Mai (T18)", "Cinema 01", "C03", "Nguyễn Q. Như", "HỢP LỆ", "Khách vào cửa");
        }

        // =====================================================================
        // XỬ LÝ QUÉT & SOÁT VÉ (CHECK-IN LOGIC)
        // =====================================================================
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            ProcessBarcodeCheckIn(txtBarcode.Text.Trim());
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessBarcodeCheckIn(txtBarcode.Text.Trim());
            }
        }

        private void ProcessBarcodeCheckIn(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                MessageBox.Show("Vui lòng quét mã vạch hoặc nhập mã vé trước khi nhấn Xác nhận!", 
                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBarcode.Focus();
                return;
            }

            // Xử lý mô phỏng các kịch bản thực tế
            if (barcode.Equals("TK20240410001D05", StringComparison.OrdinalIgnoreCase) ||
                barcode.StartsWith("TK_VALID", StringComparison.OrdinalIgnoreCase) ||
                barcode.Length == 8 && barcode.StartsWith("TK"))
            {
                ShowValidResult(barcode, "Mai (T18)", "Cinema 01 - Tiêu Chuẩn", "E05", "GHẾ VIP", 
                               "Trần Minh Hoàng (⭐ Thành viên Vàng)", "105,000 VND");
            }
            else if (barcode.Equals("TK20240410002B05", StringComparison.OrdinalIgnoreCase) ||
                     barcode.Contains("USED"))
            {
                ShowAlreadyUsedResult(barcode, "Mai (T18)", "Cinema 01", "B05", "GHẾ THƯỜNG", 
                                     "Khách vãng lai", "90,000 VND", "19:40:15");
            }
            else if (barcode.Equals("TK20240410003A01", StringComparison.OrdinalIgnoreCase) ||
                     barcode.Contains("WRONG"))
            {
                ShowWrongRoomResult(barcode, "Dune: Hành Tinh Cát 2", "Cinema 03 - IMAX Laser", "A01", "GHẾ VIP", 
                                   "Lê Quốc Bảo (💎 Thành viên Platinum)", "150,000 VND");
            }
            else
            {
                ShowNotFoundResult(barcode);
            }

            // Tự động bôi đen toàn bộ ô nhập để lần quét máy scanner tiếp theo tự ghi đè
            txtBarcode.SelectAll();
            txtBarcode.Focus();
        }

        // =====================================================================
        // CÁC HÀM CẬP NHẬT GIAO DIỆN KẾT QUẢ SOÁT VÉ (UI RENDERERS)
        // =====================================================================
        private void ShowValidResult(string barcode, string movie, string room, string seat, string seatType, string customer, string price)
        {
            pnlStatusBanner.BackColor = COLOR_SUCCESS_BG;
            lblStatusTitle.ForeColor = COLOR_SUCCESS_TEXT;
            lblStatusTitle.Text = "✓  VÉ HỢP LỆ - MỜI VÀO PHÒNG";
            lblStatusDesc.ForeColor = Color.FromArgb(4, 120, 87);
            lblStatusDesc.Text = "Vé đúng phòng chiếu, đúng suất chiếu và chưa qua cửa. Chúc quý khách xem phim vui vẻ!";

            lblValMovie.Text = movie;
            lblValShowtimeRoom.Text = room + "  |  Suất: 18:00 - 20:11";
            lblSeatCode.Text = seat;
            lblSeatType.Text = seatType;
            lblValCustomer.Text = customer;
            lblValPrice.Text = price + " (Đã thanh toán)";
            lblValScanTime.Text = "Vừa xong lúc " + DateTime.Now.ToString("HH:mm:ss") + " hôm nay";

            // Cập nhật bộ đếm
            _scannedTickets++;
            _remainingTickets = Math.Max(0, _remainingTickets - 1);
            UpdateKpiDisplay();

            // Thêm vào bảng lịch sử
            dgvCheckInLogs.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), barcode, movie, room.Split('-')[0].Trim(), seat, customer.Split('(')[0].Trim(), "HỢP LỆ", "Khách vào cửa");
            if (dgvCheckInLogs.Rows.Count > 0)
                dgvCheckInLogs.Rows[0].Selected = true;
        }

        private void ShowAlreadyUsedResult(string barcode, string movie, string room, string seat, string seatType, string customer, string price, string firstScanTime)
        {
            pnlStatusBanner.BackColor = COLOR_WARNING_BG;
            lblStatusTitle.ForeColor = COLOR_WARNING_TEXT;
            lblStatusTitle.Text = "⚠️  VÉ ĐÃ QUA CỬA SOÁT LÚC " + firstScanTime;
            lblStatusDesc.ForeColor = Color.FromArgb(180, 83, 9);
            lblStatusDesc.Text = "CẢNH BÁO: Tấm vé này đã được quét qua cửa trước đó! Không cho phép khách vào lần hai.";

            lblValMovie.Text = movie;
            lblValShowtimeRoom.Text = room + "  |  Suất: 18:00 - 20:11";
            lblSeatCode.Text = seat;
            lblSeatType.Text = seatType;
            lblValCustomer.Text = customer;
            lblValPrice.Text = price;
            lblValScanTime.Text = "Quét lại lúc " + DateTime.Now.ToString("HH:mm:ss") + " (Đã dùng lúc " + firstScanTime + ")";

            dgvCheckInLogs.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), barcode, movie, room, seat, customer, "ĐÃ QUÉT", "Cảnh báo quét lại");
            if (dgvCheckInLogs.Rows.Count > 0)
                dgvCheckInLogs.Rows[0].Selected = true;
        }

        private void ShowWrongRoomResult(string barcode, string movie, string correctRoom, string seat, string seatType, string customer, string price)
        {
            pnlStatusBanner.BackColor = COLOR_ORANGE_BG;
            lblStatusTitle.ForeColor = COLOR_ORANGE_TEXT;
            lblStatusTitle.Text = "🚫  SAI PHÒNG CHIẾU (ĐÚNG: " + correctRoom.ToUpper() + ")";
            lblStatusDesc.ForeColor = Color.FromArgb(194, 65, 12);
            lblStatusDesc.Text = "Khách đi nhầm cửa! Suất chiếu của vé này phát sóng tại " + correctRoom + ".";

            lblValMovie.Text = movie;
            lblValShowtimeRoom.Text = correctRoom + " (Khác phòng hiện tại)";
            lblSeatCode.Text = seat;
            lblSeatType.Text = seatType;
            lblValCustomer.Text = customer;
            lblValPrice.Text = price;
            lblValScanTime.Text = "Từ chối soát lúc " + DateTime.Now.ToString("HH:mm:ss");

            dgvCheckInLogs.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), barcode, movie, correctRoom.Split('-')[0].Trim(), seat, customer, "SAI PHÒNG", "Vé thuộc " + correctRoom);
            if (dgvCheckInLogs.Rows.Count > 0)
                dgvCheckInLogs.Rows[0].Selected = true;
        }

        private void ShowNotFoundResult(string barcode)
        {
            pnlStatusBanner.BackColor = COLOR_DANGER_BG;
            lblStatusTitle.ForeColor = COLOR_DANGER_TEXT;
            lblStatusTitle.Text = "❌  MÃ VÉ KHÔNG TỒN TẠI TRÊN HỆ THỐNG";
            lblStatusDesc.ForeColor = Color.FromArgb(185, 28, 28);
            lblStatusDesc.Text = "Không tìm thấy dữ liệu vé tương ứng. Vui lòng hướng dẫn khách kiểm tra lại tại Quầy vé.";

            lblValMovie.Text = "--- (Không xác định) ---";
            lblValShowtimeRoom.Text = "---";
            lblSeatCode.Text = "--";
            lblSeatType.Text = "KHÔNG RÕ";
            lblValCustomer.Text = "---";
            lblValPrice.Text = "---";
            lblValScanTime.Text = "Thử quét lúc " + DateTime.Now.ToString("HH:mm:ss");

            dgvCheckInLogs.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), barcode, "---", "---", "--", "---", "KHÔNG CÓ", "Không tìm thấy mã");
            if (dgvCheckInLogs.Rows.Count > 0)
                dgvCheckInLogs.Rows[0].Selected = true;
        }

        private void UpdateKpiDisplay()
        {
            lblKpiTotalVal.Text = _totalTickets.ToString();
            lblKpiScannedVal.Text = _scannedTickets.ToString();
            lblKpiRemainingVal.Text = _remainingTickets.ToString();

            double rate = _totalTickets > 0 ? ((double)_scannedTickets / _totalTickets) * 100.0 : 0;
            lblKpiRateVal.Text = string.Format("{0:0.0}%", rate);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Clear();
            txtBarcode.Focus();
        }

        // =====================================================================
        // NÚT THỬ NGHIỆM NHANH (MOCK FRONTEND TESTERS)
        // =====================================================================
        private void btnMockValid_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "TK20240410001D05";
            ProcessBarcodeCheckIn(txtBarcode.Text);
        }

        private void btnMockUsed_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "TK20240410002B05";
            ProcessBarcodeCheckIn(txtBarcode.Text);
        }

        private void btnMockWrongRoom_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "TK20240410003A01";
            ProcessBarcodeCheckIn(txtBarcode.Text);
        }

        private void btnMockNotFound_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "TK9999999999";
            ProcessBarcodeCheckIn(txtBarcode.Text);
        }

        // =====================================================================
        // SỰ KIỆN LỌC & ĐỔI PHÒNG CHIẾU / SUẤT CHIẾU
        // =====================================================================
        private void cboAuditorium_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShowtimesForSelectedAuditorium();
        }

        private void cboShowtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset lại trạng thái mẫu
            _totalTickets = cboAuditorium.SelectedIndex == 2 ? 60 : 80;
            _scannedTickets = 30 + new Random().Next(10, 25);
            _remainingTickets = _totalTickets - _scannedTickets;
            UpdateKpiDisplay();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void txtSearchLog_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchLog.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvCheckInLogs.Rows)
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    row.Visible = true;
                }
                else
                {
                    string barcode = row.Cells[1].Value?.ToString()?.ToLower() ?? "";
                    string seat = row.Cells[4].Value?.ToString()?.ToLower() ?? "";
                    string customer = row.Cells[5].Value?.ToString()?.ToLower() ?? "";
                    string status = row.Cells[6].Value?.ToString()?.ToLower() ?? "";

                    row.Visible = barcode.Contains(keyword) || seat.Contains(keyword) || 
                                  customer.Contains(keyword) || status.Contains(keyword);
                }
            }
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dữ liệu nhật ký soát vé của suất chiếu đã được xuất thành công ra file Excel!", 
                            "Xuất Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        // ĐỊNH DẠNG MÀU SẮC DATAGRIDVIEW THEO KẾT QUẢ SOÁT VÉ
        // =====================================================================
        private void dgvCheckInLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null) // Cột colStatus
            {
                string status = e.Value.ToString() ?? "";
                if (status == "HỢP LỆ")
                {
                    e.CellStyle.ForeColor = COLOR_SUCCESS_TEXT;
                    e.CellStyle.BackColor = COLOR_SUCCESS_BG;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "ĐÃ QUÉT")
                {
                    e.CellStyle.ForeColor = COLOR_WARNING_TEXT;
                    e.CellStyle.BackColor = COLOR_WARNING_BG;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "SAI PHÒNG")
                {
                    e.CellStyle.ForeColor = COLOR_ORANGE_TEXT;
                    e.CellStyle.BackColor = COLOR_ORANGE_BG;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "KHÔNG CÓ")
                {
                    e.CellStyle.ForeColor = COLOR_DANGER_TEXT;
                    e.CellStyle.BackColor = COLOR_DANGER_BG;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        // =====================================================================
        // CUSTOM DRAWING: VẼ VIỀN & HUY HIỆU LOGO MONOGRAM
        // =====================================================================
        private void picLogoBadge_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Đĩa tròn màu vàng mật ong #D97706
            using (Brush b = new SolidBrush(COLOR_ACCENT))
            {
                g.FillEllipse(b, 2, 2, 42, 42);
            }

            // Vành tròn viền trắng
            using (Pen p = new Pen(Color.White, 2f))
            {
                g.DrawEllipse(p, 4, 4, 38, 38);
            }

            // Vẽ Monogram S và L lồng nhau
            using (Font fL = new Font("Segoe UI", 16F, FontStyle.Bold))
            using (Font fS = new Font("Segoe UI", 13F, FontStyle.Bold))
            using (Brush bWhite = new SolidBrush(Color.White))
            using (Brush bNavy = new SolidBrush(COLOR_SIDEBAR))
            {
                // Chữ L trắng
                g.DrawString("L", fL, bWhite, 17, 10);
                // Chữ S màu navy lồng phía trước
                g.DrawString("S", fS, bNavy, 9, 8);
            }
        }

        private void picStaffAvatar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush b = new SolidBrush(COLOR_PRIMARY))
            {
                g.FillEllipse(b, 0, 0, 40, 40);
            }

            using (Font f = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (Brush bWhite = new SolidBrush(Color.White))
            {
                g.DrawString("SV", f, bWhite, 8, 8);
            }
        }

        private void pnlCardBorder_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            using (Pen p = new Pen(COLOR_BORDER, 1f))
            {
                e.Graphics.DrawRectangle(p, 0, 0, c.Width - 1, c.Height - 1);
            }
        }

        private void pnlTopHeader_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            using (Pen p = new Pen(COLOR_BORDER, 1f))
            {
                e.Graphics.DrawLine(p, 0, c.Height - 1, c.Width, c.Height - 1);
            }
        }

        private void pnlStatusBanner_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            using (Pen p = new Pen(COLOR_BORDER, 1f))
            {
                e.Graphics.DrawRectangle(p, 0, 0, c.Width - 1, c.Height - 1);
            }
        }

        private void pnlSeatBadge_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            using (Pen p = new Pen(Color.FromArgb(254, 205, 211), 1.5f))
            {
                e.Graphics.DrawRectangle(p, 0, 0, c.Width - 1, c.Height - 1);
            }
        }

        private void pnlScanLaserTarget_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Control c = (Control)sender;

            using (Pen p = new Pen(Color.FromArgb(59, 130, 246), 2f)) // Góc định vị màu xanh
            {
                int len = 15;
                // Góc trên trái
                g.DrawLine(p, 8, 8, 8 + len, 8);
                g.DrawLine(p, 8, 8, 8, 8 + len);

                // Góc trên phải
                g.DrawLine(p, c.Width - 9, 8, c.Width - 9 - len, 8);
                g.DrawLine(p, c.Width - 9, 8, c.Width - 9, 8 + len);

                // Góc dưới trái
                g.DrawLine(p, 8, c.Height - 9, 8 + len, c.Height - 9);
                g.DrawLine(p, 8, c.Height - 9, 8, c.Height - 9 - len);

                // Góc dưới phải
                g.DrawLine(p, c.Width - 9, c.Height - 9, c.Width - 9 - len, c.Height - 9);
                g.DrawLine(p, c.Width - 9, c.Height - 9, c.Width - 9, c.Height - 9 - len);
            }
        }
    }
}

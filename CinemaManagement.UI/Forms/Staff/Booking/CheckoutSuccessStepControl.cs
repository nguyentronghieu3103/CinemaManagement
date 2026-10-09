using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.UI.Helpers;
using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // BƯỚC 6 của màn Bán vé: THANH TOÁN THÀNH CÔNG + danh sách vé/QR (PHASE 6).
    // Chỉ HIỂN THỊ kết quả đã commit trong database; không ghi gì. Không in/xuất PDF/email ở phase này.
    public class CheckoutSuccessStepControl : UserControl
    {
        private readonly CheckoutResultDto _result;
        private readonly List<Bitmap> _images = new();

        public event Action? NewSaleRequested;    // trở về bước chọn phim cho giao dịch mới
        public event Action? CloseRequested;      // đóng màn Bán vé

        public CheckoutSuccessStepControl(SaleMovieDto movie, SaleShowtimeDto showtime, CheckoutResultDto result, string customerText)
        {
            _result = result;
            Dock = DockStyle.Fill;
            BackColor = AppColors.PageBackground;

            // Thứ tự Add: Fill trước, rồi Left, Bottom, Top
            Controls.Add(BuildTicketsPanel());
            Controls.Add(BuildInfoPanel(movie, showtime, customerText));
            Controls.Add(BuildBottomPanel());
            Controls.Add(BuildTopPanel());
        }

        private Panel BuildTopPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Top, Height = 96, BackColor = AppColors.SuccessSoft };
            pnl.Controls.Add(new Label
            {
                Text = "✔  THANH TOÁN THÀNH CÔNG",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = AppColors.Success,
                AutoSize = true,
                Left = 24,
                Top = 16
            });
            pnl.Controls.Add(new Label
            {
                Text = $"Hóa đơn #{_result.InvoiceId}   •   {_result.Tickets.Count} vé   •   {_result.NgayLap:HH:mm dd/MM/yyyy}",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Left = 26,
                Top = 60
            });
            return pnl;
        }

        private Panel BuildInfoPanel(SaleMovieDto movie, SaleShowtimeDto showtime, string customerText)
        {
            var pnl = new Panel { Dock = DockStyle.Left, Width = 470, BackColor = AppColors.InputBackground, AutoScroll = true };

            string seats = string.Join(", ", _result.Tickets.Select(t => t.ViTriGhe));
            string combos = _result.Cart.Combos.Count == 0
                ? "Không có"
                : string.Join(", ", _result.Cart.Combos.Select(c => $"{c.TenCombo} x{c.SoLuong}"));

            pnl.Controls.Add(new Label
            {
                Text = "THÔNG TIN ĐƠN HÀNG",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = AppColors.TextMuted,
                AutoSize = true,
                Left = 16,
                Top = 12
            });

            int y = 44;
            void Row(string caption, string value, int height = 24, bool strong = false)
            {
                pnl.Controls.Add(new Label { Text = caption, Left = 16, Top = y + 2, Width = 120, Height = height, Font = new Font("Segoe UI", 10F), ForeColor = AppColors.TextMuted });
                pnl.Controls.Add(new Label
                {
                    Text = value,
                    Left = 140,
                    Top = y + 2,
                    Width = 310,
                    Height = height,
                    Font = new Font("Segoe UI", strong ? 13F : 10F, FontStyle.Bold),
                    ForeColor = strong ? AppColors.HeaderBackground : AppColors.TextDark,
                    TextAlign = ContentAlignment.TopRight,
                    AutoEllipsis = true
                });
                y += height + 6;
            }

            Row("Mã hóa đơn", $"#{_result.InvoiceId}");
            Row("Khách hàng", customerText);
            Row("Phim", movie.TenPhim);
            Row("Suất chiếu", $"{showtime.NgayChieu:dd/MM/yyyy}  {showtime.GioBatDau:hh\\:mm} - {showtime.GioKetThuc:hh\\:mm}");
            Row("Phòng", showtime.TenPhong);
            Row("Ghế", seats);
            Row("Combo", combos);
            Row("Phương thức", _result.PhuongThuc);
            Row("Khách đưa", $"{_result.TienKhachDua:N0} đ");
            Row("Tiền thừa", $"{_result.TienThua:N0} đ");
            Row("TỔNG TIỀN", $"{_result.TongTien:N0} đ", 30, true);
            pnl.AutoScrollMinSize = new Size(0, y + 10);
            return pnl;
        }

        private Panel BuildTicketsPanel()
        {
            var host = new Panel { Dock = DockStyle.Fill, BackColor = AppColors.PageBackground };

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(16, 8, 16, 12),
                BackColor = AppColors.PageBackground
            };
            host.Controls.Add(flow);

            host.Controls.Add(new Label
            {
                Text = "DANH SÁCH VÉ",
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(24, 10, 0, 0),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = AppColors.TextDark
            });

            int index = 1;
            foreach (IssuedTicketDto ticket in _result.Tickets)
                flow.Controls.Add(CreateTicketCard(index++, ticket));

            return host;
        }

        private Panel CreateTicketCard(int index, IssuedTicketDto ticket)
        {
            var card = new Panel { Width = 250, Height = 360, Margin = new Padding(10), BackColor = Color.White };

            card.Controls.Add(new Label { Text = $"Vé {index}", Left = 12, Top = 8, AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = AppColors.TextMuted });
            card.Controls.Add(new Label { Text = ticket.MaVe, Left = 12, Top = 30, Width = 226, Height = 30, Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = AppColors.HeaderBackground });
            card.Controls.Add(new Label { Text = $"Ghế {ticket.ViTriGhe} ({ticket.LoaiGhe})", Left = 12, Top = 64, Width = 226, Height = 24, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = AppColors.TextDark });
            card.Controls.Add(new Label { Text = $"Giá vé: {ticket.GiaVe:N0} đ", Left = 12, Top = 90, Width = 226, Height = 22, Font = new Font("Segoe UI", 10F), ForeColor = AppColors.TextDark });

            var pic = new PictureBox
            {
                Left = 25,
                Top = 120,
                Width = 200,
                Height = 200,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White
            };
            Bitmap? qr = QrImageHelper.TryRender(ticket.MaQR);
            if (qr != null)
            {
                _images.Add(qr);
                pic.Image = qr;
            }
            else
            {
                pic.Controls.Add(new Label
                {
                    Text = "Không vẽ được QR.\nNhập mã vé để check-in.",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = AppColors.StatusRed
                });
            }
            card.Controls.Add(pic);

            card.Controls.Add(new Label { Text = "Quét QR hoặc nhập mã vé để check-in", Left = 12, Top = 328, Width = 226, Height = 22, Font = new Font("Segoe UI", 8.5F), ForeColor = AppColors.TextMuted, TextAlign = ContentAlignment.MiddleCenter });
            return card;
        }

        private Panel BuildBottomPanel()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 88, BackColor = AppColors.InputBackground };

            var btnNew = MakeButton("BÁN ĐƠN MỚI", AppColors.Success, Color.White, 240);
            var btnClose = MakeButton("Đóng", Color.White, AppColors.TextDark, 140);
            btnNew.Click += (s, e) => NewSaleRequested?.Invoke();
            btnClose.Click += (s, e) => CloseRequested?.Invoke();
            pnl.Controls.Add(btnNew);
            pnl.Controls.Add(btnClose);

            pnl.Controls.Add(new Label
            {
                Text = "Giao dịch đã được lưu. Vé có thể check-in bằng mã QR hoặc mã vé ở màn Check-in.",
                Left = 24,
                Top = 30,
                Width = 600,
                Height = 30,
                Font = new Font("Segoe UI", 10F),
                ForeColor = AppColors.TextMuted
            });

            void PlaceRight()
            {
                btnNew.Location = new Point(pnl.Width - btnNew.Width - 24, 18);
                btnClose.Location = new Point(btnNew.Left - btnClose.Width - 12, 18);
            }
            pnl.Resize += (s, e) => PlaceRight();
            PlaceRight();
            return pnl;
        }

        private static Button MakeButton(string text, Color back, Color fore, int width)
        {
            var b = new Button
            {
                Text = text,
                Size = new Size(width, 52),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = back == Color.White ? 1 : 0;
            b.FlatAppearance.BorderColor = AppColors.TextMuted;
            return b;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (Bitmap bmp in _images) bmp.Dispose();
                _images.Clear();
            }
            base.Dispose(disposing);
        }
    }
}

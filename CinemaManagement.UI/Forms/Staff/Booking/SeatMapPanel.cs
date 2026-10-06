using System.Drawing.Drawing2D;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Enums;
using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Staff.Booking
{
    // Control vẽ sơ đồ ghế bằng GDI+. Chỉ VẼ và báo ghế nào được click; không chứa nghiệp vụ.
    // (Trong source hiện tại chưa có control sơ đồ ghế của M3 nên tạo riêng ở đây.)
    public class SeatMapPanel : Control
    {
        // Màu ghế lấy từ AppColors (không hard-code ở đây)
        private static readonly Color SeatHeldByOther = AppColors.SeatHoldOther;
        private static readonly Color SeatHeldByOtherBorder = AppColors.Purple;
        private static readonly Color VipBorder = AppColors.SeatVipBorder;
        private static readonly Color CoupleBorder = AppColors.SeatCoupleBorder;

        private readonly record struct GridLayout(int Cell, int Gap, int X, int Y, int GridWidth);

        private SeatMapDto? _map;
        private HashSet<int> _selected = new();
        private readonly ToolTip _toolTip = new();
        private int _hoverSeatId = -1;

        public event Action<SeatDto>? SeatClicked;

        public SeatMapPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = AppColors.PageBackground;
        }

        public void SetData(SeatMapDto map, HashSet<int> selected)
        {
            _map = map;
            _selected = selected;
            Invalidate();
        }

        // ================= BỐ CỤC =================
        private GridLayout GetLayout()
        {
            if (_map == null) return new GridLayout(0, 0, 0, 0, 0);

            const int gap = 6, top = 64, bottom = 56, side = 32;
            int cols = Math.Max(1, _map.SoCot);
            int rows = Math.Max(1, _map.SoHang);

            int byWidth = (Width - 2 * side - (cols - 1) * gap) / cols;
            int byHeight = (Height - top - bottom - (rows - 1) * gap) / rows;
            int cell = Math.Clamp(Math.Min(byWidth, byHeight), 24, 54);

            int gridWidth = cols * cell + (cols - 1) * gap;
            int x = Math.Max(0, (Width - gridWidth) / 2);
            return new GridLayout(cell, gap, x, top, gridWidth);
        }

        private static Rectangle SeatRect(GridLayout l, SeatDto s)
            => new Rectangle(l.X + (s.Cot - 1) * (l.Cell + l.Gap), l.Y + (s.Hang - 1) * (l.Cell + l.Gap), l.Cell, l.Cell);

        // ================= VẼ =================
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_map == null)
            {
                TextRenderer.DrawText(g, "Đang tải sơ đồ ghế...", Font, ClientRectangle, AppColors.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            GridLayout layout = GetLayout();

            // Thanh "MÀN HÌNH": dải sáng xanh → tím, có vầng sáng bên dưới như màn chiếu
            var screen = new Rectangle(layout.X, 16, layout.GridWidth, 28);
            UiKit.FillGlow(g, new RectangleF(screen.X - 20, screen.Y - 6, screen.Width + 40, screen.Height + 44),
                AppColors.Blue, 70);
            using (var path = UiKit.RoundRect(screen, 10))
            {
                if (screen.Width > 2 && screen.Height > 2)
                    using (var lg = new LinearGradientBrush(screen, AppColors.Blue, AppColors.Purple, 0f))
                        g.FillPath(lg, path);
            }
            using (var screenFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                TextRenderer.DrawText(g, "MÀN HÌNH", screenFont, screen, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Vầng sáng đỏ phía sau ghế đang chọn (vẽ trước để thân ghế đè lên)
            foreach (SeatDto seat in _map.Seats)
            {
                if (!_selected.Contains(seat.SeatId) || seat.Status == SeatStatus.DaDat) continue;
                var r = SeatRect(layout, seat);
                UiKit.FillGlow(g, new RectangleF(r.X - r.Width * 0.7f, r.Y - r.Height * 0.7f, r.Width * 2.4f, r.Height * 2.4f),
                    AppColors.Primary, 110);
            }

            float fontSize = Math.Max(7F, layout.Cell / 4.6F);
            using (var seatFont = new Font("Segoe UI", fontSize, FontStyle.Bold))
            {
                foreach (SeatDto seat in _map.Seats)
                    DrawSeat(g, seatFont, SeatRect(layout, seat), seat);
            }

            DrawLegend(g, layout);
        }

        private void DrawSeat(Graphics g, Font font, Rectangle rect, SeatDto seat)
        {
            bool selected = _selected.Contains(seat.SeatId);
            Color fill, border, text;
            float borderWidth = 1f;
            bool sold = false;
            bool mine = false;

            if (seat.Status == SeatStatus.DaDat)
            {
                // đã bán: xám đen, chìm hẳn
                fill = AppColors.SeatSold; border = AppColors.SeatSoldBorder; text = Color.FromArgb(75, 85, 99);
                sold = true;
            }
            else if (seat.IsHeldByMe)
            {
                // bạn đang giữ: tím sáng + viền sáng
                fill = AppColors.SeatHolding; border = Color.FromArgb(221, 214, 254); text = Color.White; borderWidth = 2f;
                mine = true;
            }
            else if (seat.Status == SeatStatus.DangGiu)
            {
                // người khác giữ: tím tối
                fill = SeatHeldByOther; border = SeatHeldByOtherBorder; text = AppColors.TextMuted;
            }
            else if (selected)
            {
                // đang chọn: đỏ cinema (có glow vẽ phía sau)
                fill = AppColors.Primary; border = AppColors.PrimaryHover; text = Color.White; borderWidth = 2f;
            }
            else
            {
                switch (seat.LoaiGhe)
                {
                    case SeatType.Vip:
                        fill = AppColors.SeatVipFill; border = AppColors.SeatVipBorder; borderWidth = 2f; break;
                    case SeatType.Doi:
                        fill = AppColors.SeatCoupleFill; border = AppColors.SeatCoupleBorder; borderWidth = 2f; break;
                    default:
                        fill = AppColors.SeatAvailable; border = AppColors.SeatAvailableBorder; break;
                }
                text = AppColors.TextSecondary;
            }

            var body = new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            int radius = Math.Max(3, rect.Width / 6);
            using (var path = UiKit.RoundRect(body, radius))
            {
                using (var brush = new SolidBrush(fill))
                    g.FillPath(brush, path);
                using (var pen = new Pen(border, borderWidth))
                    g.DrawPath(pen, path);
            }

            if (sold)
            {
                // dấu ✕ mờ để chắc chắn phân biệt với ghế trống
                int m = Math.Max(5, rect.Width / 4);
                using var xp = new Pen(Color.FromArgb(70, 85, 99), 1.5f);
                g.DrawLine(xp, body.X + m, body.Y + m, body.Right - m, body.Bottom - m);
                g.DrawLine(xp, body.Right - m, body.Y + m, body.X + m, body.Bottom - m);
                return;
            }
            if (mine)
            {
                using var glow = new Pen(Color.FromArgb(90, AppColors.SeatHolding), 3f);
                using var gp = UiKit.RoundRect(Rectangle.Inflate(body, 1, 1), radius);
                g.DrawPath(glow, gp);
            }

            TextRenderer.DrawText(g, seat.Label, font, rect, text,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }

        private void DrawLegend(Graphics g, GridLayout layout)
        {
            var items = new (Color Fill, Color Border, string Text)[]
            {
                (AppColors.SeatAvailable, AppColors.SeatAvailableBorder, "Thường"),
                (AppColors.SeatVipFill, AppColors.SeatVipBorder, "VIP"),
                (AppColors.SeatCoupleFill, AppColors.SeatCoupleBorder, "Đôi"),
                (AppColors.Primary, AppColors.PrimaryHover, "Đang chọn"),
                (AppColors.SeatHolding, Color.FromArgb(221, 214, 254), "Bạn đang giữ"),
                (SeatHeldByOther, SeatHeldByOtherBorder, "Người khác giữ"),
                (AppColors.SeatSold, AppColors.SeatSoldBorder, "Đã đặt")
            };

            using var font = new Font("Segoe UI", 9F);
            int x = Math.Max(10, layout.X);
            int y = Height - 34;

            foreach (var item in items)
            {
                var box = new Rectangle(x, y, 16, 16);
                using (var path = UiKit.RoundRect(box, 4))
                {
                    using (var brush = new SolidBrush(item.Fill))
                        g.FillPath(brush, path);
                    using (var pen = new Pen(item.Border, 1.5f))
                        g.DrawPath(pen, path);
                }

                int textWidth = TextRenderer.MeasureText(item.Text, font).Width;
                TextRenderer.DrawText(g, item.Text, font, new Point(x + 22, y), AppColors.TextSecondary);
                x += 22 + textWidth + 16;
            }
        }

        // ================= CHUỘT =================
        private SeatDto? HitTest(Point p)
        {
            if (_map == null) return null;
            GridLayout layout = GetLayout();
            foreach (SeatDto seat in _map.Seats)
                if (SeatRect(layout, seat).Contains(p)) return seat;
            return null;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            SeatDto? seat = HitTest(e.Location);
            if (seat != null) SeatClicked?.Invoke(seat);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SeatDto? seat = HitTest(e.Location);
            int id = seat?.SeatId ?? -1;
            if (id == _hoverSeatId) return;

            _hoverSeatId = id;
            Cursor = seat != null ? Cursors.Hand : Cursors.Default;
            _toolTip.SetToolTip(this, seat == null ? string.Empty : Describe(seat));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hoverSeatId = -1;
            Cursor = Cursors.Default;
        }

        private string Describe(SeatDto seat)
        {
            string type = seat.LoaiGhe switch { SeatType.Vip => "VIP", SeatType.Doi => "Ghế đôi", _ => "Thường" };
            string status = seat.Status == SeatStatus.DaDat ? "Đã đặt"
                : seat.IsHeldByMe ? "Bạn đang giữ"
                : seat.Status == SeatStatus.DangGiu ? "Đang được nhân viên khác giữ"
                : _selected.Contains(seat.SeatId) ? "Đang chọn"
                : "Còn trống";
            return $"{seat.Label} • {type} • {seat.Gia:N0} đ • {status}";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _toolTip.Dispose();
            base.Dispose(disposing);
        }
    }
}

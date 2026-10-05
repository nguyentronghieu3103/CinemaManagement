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
        private static readonly Color SeatBooked = Color.FromArgb(158, 158, 158);
        private static readonly Color SeatHeldByOther = Color.FromArgb(255, 204, 128);
        private static readonly Color SeatHeldByOtherBorder = Color.FromArgb(230, 126, 34);
        private static readonly Color VipBorder = Color.FromArgb(218, 165, 32);
        private static readonly Color CoupleBorder = Color.FromArgb(142, 68, 173);

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

            // Thanh "MÀN HÌNH"
            var screen = new Rectangle(layout.X, 16, layout.GridWidth, 28);
            using (var brush = new SolidBrush(AppColors.HeaderBackground))
                g.FillRectangle(brush, screen);
            using (var screenFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                TextRenderer.DrawText(g, "MÀN HÌNH", screenFont, screen, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

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
            int borderWidth = 1;

            if (seat.Status == SeatStatus.DaDat)
            {
                fill = SeatBooked; border = SeatBooked; text = Color.White;
            }
            else if (seat.IsHeldByMe)
            {
                fill = AppColors.Success; border = AppColors.Success; text = Color.White;
            }
            else if (seat.Status == SeatStatus.DangGiu)
            {
                fill = SeatHeldByOther; border = SeatHeldByOtherBorder; text = AppColors.TextDark;
            }
            else if (selected)
            {
                fill = AppColors.Primary; border = AppColors.HeaderBackground; text = Color.White; borderWidth = 2;
            }
            else
            {
                fill = Color.White;
                border = TypeBorderColor(seat.LoaiGhe);
                text = AppColors.TextDark;
                borderWidth = seat.LoaiGhe == SeatType.Thuong ? 1 : 2;
            }

            using (var brush = new SolidBrush(fill))
                g.FillRectangle(brush, rect);
            using (var pen = new Pen(border, borderWidth))
                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

            TextRenderer.DrawText(g, seat.Label, font, rect, text,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }

        private static Color TypeBorderColor(SeatType type) => type switch
        {
            SeatType.Vip => VipBorder,
            SeatType.Doi => CoupleBorder,
            _ => AppColors.TextMuted
        };

        private void DrawLegend(Graphics g, GridLayout layout)
        {
            var items = new (Color Fill, Color Border, string Text)[]
            {
                (Color.White, AppColors.TextMuted, "Thường"),
                (Color.White, VipBorder, "VIP"),
                (Color.White, CoupleBorder, "Đôi"),
                (AppColors.Primary, AppColors.HeaderBackground, "Đang chọn"),
                (AppColors.Success, AppColors.Success, "Bạn đang giữ"),
                (SeatHeldByOther, SeatHeldByOtherBorder, "Người khác giữ"),
                (SeatBooked, SeatBooked, "Đã đặt")
            };

            using var font = new Font("Segoe UI", 9F);
            int x = Math.Max(10, layout.X);
            int y = Height - 34;

            foreach (var item in items)
            {
                using (var brush = new SolidBrush(item.Fill))
                    g.FillRectangle(brush, x, y, 16, 16);
                using (var pen = new Pen(item.Border, 2))
                    g.DrawRectangle(pen, x, y, 15, 15);

                int textWidth = TextRenderer.MeasureText(item.Text, font).Width;
                TextRenderer.DrawText(g, item.Text, font, new Point(x + 22, y), AppColors.TextDark);
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

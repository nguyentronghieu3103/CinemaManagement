using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;

namespace CinemaManagement.UI.Theme
{
    /// <summary>Hàm tiện ích vẽ đồ họa + co giãn theo DPI cho giao diện dựng bằng code.</summary>
    public static class UiKit
    {
        /// <summary>Bật/tắt chuyển động cực chậm của vệt sáng nền (10–20s/vòng). Đặt false nếu máy yếu.</summary>
        public static bool AnimateBackground { get; set; } = true;

        /// <summary>Đổi kích thước "thiết kế ở 96 DPI" sang pixel thật của màn hình hiện tại.</summary>
        public static int S(this Control c, int v) => c.LogicalToDeviceUnits(v);

        public static GraphicsPath RoundRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0 || r.Width <= 0 || r.Height <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            int d = Math.Min(radius * 2, Math.Min(r.Width, r.Height));
            var arc = new Rectangle(r.Location, new Size(d, d));
            path.AddArc(arc, 180, 90);
            arc.X = r.Right - d; path.AddArc(arc, 270, 90);
            arc.Y = r.Bottom - d; path.AddArc(arc, 0, 90);
            arc.X = r.Left; path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void HighQuality(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        public static Color Blend(Color a, Color b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            return Color.FromArgb(
                (int)(a.A + (b.A - a.A) * t),
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        /// <summary>Bật double-buffer cho control (DataGridView, FlowLayoutPanel...) để cuộn mượt, không nháy.</summary>
        public static void DoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(c, true);
        }

        /// <summary>Lấy chữ cái viết tắt từ họ tên: "Nguyễn Thu Hà" → "NH".</summary>
        public static string Initials(string? fullName)
        {
            var parts = (fullName ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "?";
            if (parts.Length == 1) return parts[0][..1].ToUpperInvariant();
            return (parts[0][..1] + parts[^1][..1]).ToUpperInvariant();
        }

        /// <summary>Vệt sáng mềm hình elip: đậm ở tâm, tan dần ra mép (không có ranh giới).</summary>
        public static void FillGlow(Graphics g, RectangleF bounds, Color color, int alpha)
        {
            if (bounds.Width <= 2 || bounds.Height <= 2 || alpha <= 0) return;
            using var path = new GraphicsPath();
            path.AddEllipse(bounds);
            using var pgb = new PathGradientBrush(path)
            {
                CenterColor = Color.FromArgb(Math.Clamp(alpha, 0, 255), color),
                SurroundColors = new[] { Color.FromArgb(0, color) }
            };
            // đường cong "ease" để vệt sáng tan mượt, không lộ vòng tròn
            pgb.Blend = new Blend
            {
                Positions = new[] { 0f, 0.25f, 0.5f, 0.75f, 1f },
                Factors = new[] { 0f, 0.06f, 0.25f, 0.56f, 1f }
            };
            g.FillPath(pgb, path);
        }

        /// <summary>Logo CINEMA vẽ bằng code (khối đỏ bo góc + nút play), dùng cho header và đăng nhập.</summary>
        public static Bitmap CreateLogoBitmap(int size)
        {
            size = Math.Max(16, size);
            var bmp = new Bitmap(size, size);
            using var g = Graphics.FromImage(bmp);
            HighQuality(g);
            g.Clear(Color.Transparent);

            int pad = Math.Max(1, size / 14);
            var r = new Rectangle(pad, pad, size - 2 * pad - 1, size - 2 * pad - 1);
            using (var path = RoundRect(r, size / 4))
            {
                using (var lg = new LinearGradientBrush(r, AppColors.PrimaryHover, AppColors.DarkRed, 55f))
                    g.FillPath(lg, path);
                using var pen = new Pen(Color.FromArgb(90, 255, 255, 255), Math.Max(1f, size / 40f));
                g.DrawPath(pen, path);
            }

            float cx = size / 2f + size * 0.03f, cy = size / 2f, t = size * 0.22f;
            var tri = new[]
            {
                new PointF(cx - t * 0.8f, cy - t),
                new PointF(cx - t * 0.8f, cy + t),
                new PointF(cx + t * 1.1f, cy)
            };
            using var white = new SolidBrush(Color.White);
            g.FillPolygon(white, tri);
            return bmp;
        }

        /// <summary>Ô nhập kiểu tối: nền #0F172A, chữ trắng, không viền (viền do control bao ngoài vẽ).</summary>
        public static void StyleTextBox(TextBox tb)
        {
            tb.BackColor = AppColors.InputBackground;
            tb.ForeColor = AppColors.TextPrimary;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>ListView dạng Details kiểu tối (header vẽ lại bằng owner-draw, hàng/ô vẽ mặc định).</summary>
        public static void StyleListView(ListView lv)
        {
            DoubleBuffer(lv);          // owner-draw + double buffer: cuộn mượt, không nháy
            lv.BackColor = AppColors.CardBackground;
            lv.ForeColor = AppColors.TextPrimary;
            lv.BorderStyle = BorderStyle.None;
            lv.OwnerDraw = true;
            lv.DrawColumnHeader += (s, e) =>
            {
                var g = e.Graphics;
                using (var br = new SolidBrush(AppColors.Surface2)) g.FillRectangle(br, e.Bounds);
                using (var pen = new Pen(AppColors.Border))
                    g.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix |
                            (e.Header?.TextAlign == HorizontalAlignment.Right ? TextFormatFlags.Right
                             : e.Header?.TextAlign == HorizontalAlignment.Center ? TextFormatFlags.HorizontalCenter
                             : TextFormatFlags.Left);
                using var f = new Font("Segoe UI", 9F, FontStyle.Bold);
                var r = Rectangle.Inflate(e.Bounds, -6, 0);
                TextRenderer.DrawText(g, e.Header?.Text ?? string.Empty, f, r, AppColors.TextSecondary, flags);
            };
            lv.DrawItem += (s, e) =>
            {
                if (lv.View != View.Details) e.DrawDefault = true;
            };
            lv.DrawSubItem += (s, e) =>
            {
                var g = e.Graphics;
                bool selected = e.Item != null && e.Item.Selected;
                Color back = selected ? AppColors.RowSelected
                           : (e.Item != null && e.Item.BackColor != Color.Empty && e.Item.BackColor != SystemColors.Window
                                ? e.Item.BackColor : lv.BackColor);
                Color fore = selected ? Color.White
                           : (e.Item != null && e.Item.ForeColor != Color.Empty && e.Item.ForeColor != SystemColors.WindowText
                                ? e.Item.ForeColor : lv.ForeColor);
                using (var br = new SolidBrush(back)) g.FillRectangle(br, e.Bounds);
                var align = e.Header?.TextAlign ?? HorizontalAlignment.Left;
                var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix |
                            (align == HorizontalAlignment.Right ? TextFormatFlags.Right
                             : align == HorizontalAlignment.Center ? TextFormatFlags.HorizontalCenter
                             : TextFormatFlags.Left);
                var font = e.SubItem?.Font ?? lv.Font;
                TextRenderer.DrawText(g, e.SubItem?.Text ?? string.Empty, font, Rectangle.Inflate(e.Bounds, -6, 0), fore, flags);
            };
        }

        /// <summary>Menu chuột phải kiểu tối (đổi mật khẩu / đăng xuất...).</summary>
        public static void StyleMenu(ContextMenuStrip menu)
        {
            menu.Renderer = new ToolStripProfessionalRenderer(new DarkMenuColors()) { RoundedEdges = false };
            menu.BackColor = AppColors.CardBackground;
            menu.ForeColor = AppColors.TextPrimary;
        }

        /// <summary>Bảng dữ liệu tối: header tối, hàng tối xen kẽ, dòng chọn đỏ tối, viền #263044.</summary>
        public static void StyleGrid(DataGridView g)
        {
            DoubleBuffer(g);
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = AppColors.CardBackground;
            g.GridColor = AppColors.Border;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.EnableHeadersVisualStyles = false;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.AllowUserToResizeColumns = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = g.S(44);
            g.RowTemplate.Height = g.S(50);

            g.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AppColors.Surface2,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                SelectionBackColor = AppColors.Surface2,
                SelectionForeColor = AppColors.TextSecondary,
                Padding = new Padding(g.S(12), 0, 0, 0),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            g.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AppColors.CardBackground,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 10.5F),
                SelectionBackColor = AppColors.RowSelected,
                SelectionForeColor = Color.White,
                Padding = new Padding(g.S(12), 0, 0, 0)
            };
            g.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AppColors.RowAlt,
                SelectionBackColor = AppColors.RowSelected,
                SelectionForeColor = Color.White
            };
        }

        private sealed class DarkMenuColors : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground => AppColors.CardBackground;
            public override Color ImageMarginGradientBegin => AppColors.CardBackground;
            public override Color ImageMarginGradientMiddle => AppColors.CardBackground;
            public override Color ImageMarginGradientEnd => AppColors.CardBackground;
            public override Color MenuBorder => AppColors.Border;
            public override Color MenuItemBorder => AppColors.Primary;
            public override Color MenuItemSelected => AppColors.RowSelected;
            public override Color MenuItemSelectedGradientBegin => AppColors.RowSelected;
            public override Color MenuItemSelectedGradientEnd => AppColors.RowSelected;
            public override Color MenuItemPressedGradientBegin => AppColors.RowSelected;
            public override Color MenuItemPressedGradientEnd => AppColors.RowSelected;
            public override Color SeparatorDark => AppColors.Border;
            public override Color SeparatorLight => AppColors.Border;
        }
    }

    /// <summary>
    /// Nền "cinematic": đen/navy + vệt sáng mềm đỏ – tím (góc trái trên), xanh (phải trên),
    /// xanh – tím (trái dưới), đỏ – tím (phải dưới). phase (radian) làm các vệt sáng trôi nhẹ.
    /// </summary>
    public static class CinemaBackdrop
    {
        public static void Paint(Graphics g, Rectangle r, float phase = 0f)
        {
            if (r.Width <= 0 || r.Height <= 0) return;
            var state = g.Save();
            g.SetClip(r);

            using (var br = new LinearGradientBrush(r, AppColors.Background2, AppColors.PageBackground, 90f))
                g.FillRectangle(br, r);

            float w = r.Width, h = r.Height, m = Math.Max(w, h);
            float s1 = (float)Math.Sin(phase), c1 = (float)Math.Cos(phase);
            float s2 = (float)Math.Sin(phase + 2.1f), c2 = (float)Math.Cos(phase + 2.1f);
            float s3 = (float)Math.Sin(phase + 4.2f), c3 = (float)Math.Cos(phase + 4.2f);
            float d = m * 0.035f;       // biên độ trôi

            // trái trên: đỏ crimson + chút tím
            Glow(g, r, 0.02f * w + s1 * d, 0.04f * h + c1 * d, 0.62f * m, 0.46f * m, AppColors.Primary, 78);
            Glow(g, r, 0.16f * w + c2 * d, 0.02f * h + s2 * d, 0.40f * m, 0.30f * m, AppColors.Purple, 46);
            // phải trên: xanh + navy
            Glow(g, r, 0.98f * w + c1 * d, 0.02f * h + s3 * d, 0.60f * m, 0.46f * m, AppColors.Blue, 70);
            Glow(g, r, 0.84f * w + s2 * d, 0.00f * h + c3 * d, 0.40f * m, 0.28f * m, Color.FromArgb(30, 58, 138), 70);
            // trái dưới: xanh + tím
            Glow(g, r, 0.02f * w + c3 * d, 1.00f * h + s1 * d, 0.56f * m, 0.42f * m, AppColors.Blue, 50);
            Glow(g, r, 0.16f * w + s3 * d, 1.02f * h + c2 * d, 0.42f * m, 0.30f * m, AppColors.Purple, 52);
            // phải dưới: đỏ + tím (phần còn lại giữ đen)
            Glow(g, r, 0.98f * w + s2 * d, 1.00f * h + c1 * d, 0.58f * m, 0.42f * m, AppColors.Primary, 62);
            Glow(g, r, 0.86f * w + c3 * d, 1.04f * h + s1 * d, 0.40f * m, 0.30f * m, AppColors.Purple, 52);

            g.Restore(state);
        }

        private static void Glow(Graphics g, Rectangle r, float cx, float cy, float rx, float ry, Color color, int alpha)
        {
            var rect = new RectangleF(r.X + cx - rx, r.Y + cy - ry, rx * 2, ry * 2);
            UiKit.FillGlow(g, rect, color, alpha);
        }
    }

    /// <summary>
    /// Panel nền cinematic dùng làm "khung gốc" của mỗi màn hình. Vệt sáng được vẽ vào bitmap độ phân giải thấp
    /// (vì rất mềm nên không mất chi tiết) rồi phóng to → rẻ, không giật. Animate = true thì vệt sáng trôi cực chậm.
    /// </summary>
    public class CinemaBackdropPanel : Panel, IBackdropPainter
    {
        private const int Downscale = 4;
        private const double PeriodSeconds = 18.0;

        private Bitmap? _cache;
        private bool _dirty = true;
        private bool _animate;
        private float _phase;
        private readonly DateTime _t0 = DateTime.UtcNow;
        private readonly System.Windows.Forms.Timer _timer = new() { Interval = 100 };

        public bool Animate
        {
            get => _animate;
            set { _animate = value; UpdateTimer(); }
        }

        /// <summary>Vẽ thêm vệt sáng riêng cho màn hình (vd. đăng nhập). Chạy trên bitmap độ phân giải thấp,
        /// nên toạ độ là toạ độ của bitmap nhỏ (0..r.Width, 0..r.Height).</summary>
        public Action<Graphics, Rectangle>? Overlay { get; set; }

        public CinemaBackdropPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            BackColor = AppColors.PageBackground;
            _timer.Tick += (s, e) =>
            {
                var form = FindForm();
                if (!Visible || form == null || form.WindowState == FormWindowState.Minimized || !form.Visible) return;
                _phase = (float)((DateTime.UtcNow - _t0).TotalSeconds / PeriodSeconds * Math.PI * 2);
                _dirty = true;
                Invalidate(true);      // true: để các control trong suốt bên trong vẽ lại phần nền phía sau
            };
        }

        private void UpdateTimer()
        {
            _timer.Enabled = _animate && UiKit.AnimateBackground && !DesignMode;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            UpdateTimer();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _dirty = true;
        }

        private void EnsureCache()
        {
            int w = Math.Max(1, Width / Downscale), h = Math.Max(1, Height / Downscale);
            if (_cache == null || _cache.Width != w || _cache.Height != h)
            {
                _cache?.Dispose();
                _cache = new Bitmap(w, h);
                _dirty = true;
            }
            if (!_dirty) return;
            using var cg = Graphics.FromImage(_cache);
            var bounds = new Rectangle(0, 0, w, h);
            CinemaBackdrop.Paint(cg, bounds, _phase);
            Overlay?.Invoke(cg, bounds);
            _dirty = false;
        }

        private void DrawCached(Graphics g)
        {
            if (Width <= 0 || Height <= 0) return;
            EnsureCache();
            if (_cache == null) return;
            var oldI = g.InterpolationMode;
            var oldP = g.PixelOffsetMode;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.DrawImage(_cache, new Rectangle(0, 0, Width, Height), 0, 0, _cache.Width, _cache.Height, GraphicsUnit.Pixel);
            g.InterpolationMode = oldI;
            g.PixelOffsetMode = oldP;
        }

        protected override void OnPaintBackground(PaintEventArgs e) => DrawCached(e.Graphics);

        public void PaintBackdrop(Graphics g, Point origin)
        {
            var state = g.Save();
            g.TranslateTransform(-origin.X, -origin.Y);
            DrawCached(g);
            g.Restore(state);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer.Stop();
                _timer.Dispose();
                _cache?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>Panel phẳng dạng "thẻ" (dùng cho thẻ phim/suất/combo/vé): nền dark navy + viền mảnh.
    /// Khi BackColor = RowSelected (đang được chọn) viền chuyển sang đỏ cinema, dày hơn.</summary>
    public class SurfacePanel : Panel
    {
        public SurfacePanel()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            BackColor = AppColors.CardBackground;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            bool selected = BackColor.ToArgb() == AppColors.RowSelected.ToArgb();
            using var pen = new Pen(selected ? AppColors.Primary : AppColors.Border, selected ? 2f : 1f);
            if (selected) e.Graphics.DrawRectangle(pen, 1, 1, Width - 3, Height - 3);
            else e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }

    /// <summary>Thẻ dark navy bo góc có viền mảnh + đổ bóng mềm. Dùng thay cho Panel thường.</summary>
    public class CardPanel : Panel
    {
        [DefaultValue(16)] public int Radius { get; set; } = 16;
        public Color FillColor { get; set; } = AppColors.CardBackground;
        public Color BorderColor { get; set; } = AppColors.Border;
        public bool ShowShadow { get; set; } = true;

        // Code cũ (Designer) hay gán BackColor = màu nền thẻ: chuyển thành FillColor, còn nền control luôn trong suốt để bo góc đẹp.
        public override Color BackColor
        {
            get => base.BackColor;
            set { if (value.A == 255) FillColor = value; base.BackColor = Color.Transparent; Invalidate(); }
        }
        /// <summary>Dải màu mảnh ở mép trên thẻ (Color.Empty = không vẽ).</summary>
        public Color AccentColor { get; set; } = Color.Empty;

        public CardPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>Vùng thân thẻ (đã trừ phần bóng).</summary>
        protected Rectangle BodyRect
        {
            get
            {
                int sh = ShowShadow ? this.S(5) : 0;
                return new Rectangle(0, 0, Math.Max(1, Width - 1 - sh), Math.Max(1, Height - 1 - sh));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            UiKit.HighQuality(g);
            int r = this.S(Radius);
            int sh = ShowShadow ? this.S(5) : 0;
            var body = BodyRect;

            if (ShowShadow)
            {
                for (int i = 0; i < sh; i++)
                {
                    var rect = new Rectangle(body.X + i / 2, body.Y + sh - i / 2 + 1, body.Width, body.Height);
                    using var p = UiKit.RoundRect(rect, r);
                    using var br = new SolidBrush(Color.FromArgb(30, 0, 0, 0));
                    g.FillPath(br, p);
                }
            }

            using var path = UiKit.RoundRect(body, r);
            using (var fill = new SolidBrush(FillColor)) g.FillPath(fill, path);

            if (!AccentColor.IsEmpty)
            {
                var old = g.Clip;
                g.SetClip(path);
                using var br = new SolidBrush(AccentColor);
                g.FillRectangle(br, body.X, body.Y, body.Width + 1, this.S(3));
                g.Clip = old;
            }
            using var pen = new Pen(BorderColor);
            g.DrawPath(pen, path);
        }
    }

    /// <summary>Panel nền gradient bo góc (banner/hero): navy tối + glow đỏ, xanh, tím.</summary>
    public class GradientPanel : Panel
    {
        public Color Color1 { get; set; } = UiKit.Blend(AppColors.Background2, AppColors.Purple, 0.14f);
        public Color Color2 { get; set; } = AppColors.PageBackground;
        public int Radius { get; set; } = 20;

        public GradientPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            UiKit.HighQuality(g);
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            if (rect.Width <= 2 || rect.Height <= 2) return;
            using var path = UiKit.RoundRect(rect, this.S(Radius));
            using (var lg = new LinearGradientBrush(rect, Color1, Color2, 20f))
                g.FillPath(lg, path);

            // glow điện ảnh: đỏ bên trái, xanh phía trên phải, tím phía dưới phải
            var old = g.Clip;
            g.SetClip(path);
            float w = Width, h = Height;
            UiKit.FillGlow(g, new RectangleF(-w * 0.18f, -h * 1.1f, w * 0.62f, h * 2.6f), AppColors.Primary, 84);
            UiKit.FillGlow(g, new RectangleF(w * 0.62f, -h * 1.3f, w * 0.60f, h * 2.6f), AppColors.Blue, 70);
            UiKit.FillGlow(g, new RectangleF(w * 0.40f, h * 0.10f, w * 0.52f, h * 2.2f), AppColors.Purple, 54);
            g.Clip = old;

            using var pen = new Pen(Color.FromArgb(150, AppColors.Border));
            g.DrawPath(pen, path);
        }
    }

    /// <summary>Control cha tự vẽ nền, để các nút trong suốt (PillButton) lấy đúng phần nền phía sau mình.</summary>
    public interface IBackdropPainter
    {
        /// <param name="origin">Vị trí góc trên-trái của vùng cần vẽ, tính theo toạ độ của control cha.
        /// (TextRenderer không chạy theo TranslateTransform nên phải truyền offset để tự trừ.)</param>
        void PaintBackdrop(Graphics g, Point origin);
    }

    /// <summary>Nút bo tròn có hiệu ứng hover / nhấn. Dùng thay cho Button.
    /// Nút màu đặc được vẽ gradient nhẹ; hover sáng lên + viền glow.</summary>
    public class PillButton : Button
    {
        private bool _hover, _down;
        public int Radius { get; set; } = 12;
        /// <summary>Màu thường. Để trống thì lấy BackColor.</summary>
        public Color NormalColor { get; set; } = Color.Empty;
        public Color HoverColor { get; set; } = Color.Empty;
        public Color PressedColor { get; set; } = Color.Empty;
        public Color BorderColor { get; set; } = Color.Empty;
        public Color DisabledColor { get; set; } = ColorTranslator.FromHtml("#232C3F");
        /// <summary>Nền trong suốt khi không hover (dùng cho nút menu trên header).</summary>
        public bool GhostStyle { get; set; }
        public bool Bold { get; set; } = true;

        // Code cũ hay gán BackColor = màu nút: chuyển thành NormalColor, nền control luôn trong suốt để bo góc.
        public override Color BackColor
        {
            get => base.BackColor;
            set { if (value.A == 255) NormalColor = value; base.BackColor = Color.Transparent; Invalidate(); }
        }

        public PillButton()
        {
            // Không dùng OptimizedDoubleBuffer: bộ đệm dùng chung của WinForms đang giữ lại hình của
            // control vẽ trước đó (gây chữ chồng, góc đen). PillButton tự vẽ vào Bitmap riêng rồi mới đưa lên màn hình.
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; _down = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _down = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _down = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        // Tự vẽ nền thay cho cơ chế "trong suốt" mặc định của WinForms (cơ chế đó bị vẽ sai:
        // lộ góc đen, chữ của các nút chồng lên nhau). Nút tìm control cha biết tự vẽ nền
        // (IBackdropPainter); nếu không có thì tô bằng màu nền của control cha gần nhất.
        protected override void OnPaintBackground(PaintEventArgs e) { /* nền được vẽ trong OnPaint */ }

        private void PaintParentBackground(Graphics g)
        {
            for (Control? p = Parent; p != null; p = p.Parent)
            {
                if (p is IBackdropPainter painter)
                {
                    var origin = p.PointToClient(PointToScreen(Point.Empty));
                    var state = g.Save();
                    g.SetClip(ClientRectangle);
                    painter.PaintBackdrop(g, origin);
                    g.Restore(state);
                    return;
                }
                if (p is CardPanel card)
                {
                    using var cb = new SolidBrush(card.FillColor);
                    g.FillRectangle(cb, ClientRectangle);
                    return;
                }
                if (p is GradientPanel gp)
                {
                    using var gb = new SolidBrush(UiKit.Blend(gp.Color1, gp.Color2, 0.5f));
                    g.FillRectangle(gb, ClientRectangle);
                    return;
                }
                if (p.BackColor.A == 255)
                {
                    using var br = new SolidBrush(p.BackColor);
                    g.FillRectangle(br, ClientRectangle);
                    return;
                }
            }
            g.Clear(AppColors.PageBackground);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width <= 0 || Height <= 0) return;
            using var bmp = new Bitmap(Width, Height);
            using (var bg = Graphics.FromImage(bmp))
            {
                PaintParentBackground(bg);
                DrawPill(bg);
            }
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);
        }

        private void DrawPill(Graphics g)
        {
            UiKit.HighQuality(g);

            Color normal = !NormalColor.IsEmpty ? NormalColor
                         : (BackColor.A == 0 ? AppColors.Primary : BackColor);
            Color hover = HoverColor.IsEmpty ? UiKit.Blend(normal, Color.White, 0.16f) : HoverColor;
            Color pressed = PressedColor.IsEmpty ? UiKit.Blend(normal, Color.Black, 0.18f) : PressedColor;

            // nút đỏ chủ đạo: hover chuyển sang đỏ sáng #F43F5E
            if (HoverColor.IsEmpty && normal.ToArgb() == AppColors.Primary.ToArgb()) hover = AppColors.PrimaryHover;
            if (PressedColor.IsEmpty && normal.ToArgb() == AppColors.Primary.ToArgb()) pressed = AppColors.DarkRed;

            Color fill;
            bool paintFill = true;
            if (!Enabled) fill = DisabledColor;
            else if (_down) fill = pressed;
            else if (_hover) fill = hover;
            else { fill = normal; paintFill = !GhostStyle; }

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = UiKit.RoundRect(rect, this.S(Radius));
            if (paintFill)
            {
                if (fill.A == 255 && rect.Width > 2 && rect.Height > 2)
                {
                    // gradient dọc nhẹ: trên sáng hơn, dưới đậm hơn → nút có chiều sâu
                    using var lg = new LinearGradientBrush(rect,
                        UiKit.Blend(fill, Color.White, 0.10f), UiKit.Blend(fill, Color.Black, 0.22f), 90f);
                    g.FillPath(lg, path);
                }
                else
                {
                    using var br = new SolidBrush(fill);
                    g.FillPath(br, path);
                }
            }

            Color border = !BorderColor.IsEmpty ? BorderColor
                         : FlatAppearance.BorderSize > 0
                             ? (FlatAppearance.BorderColor.IsEmpty ? AppColors.Border : FlatAppearance.BorderColor)
                             : Color.Empty;
            if (!border.IsEmpty && Enabled)
            {
                using var pen = new Pen(border, 1.5f);
                g.DrawPath(pen, path);
            }

            // hover: viền phát sáng nhẹ cùng tông màu nút
            if (_hover && Enabled && !_down && paintFill && fill.A == 255)
            {
                using var glow = new Pen(Color.FromArgb(110, UiKit.Blend(fill, Color.White, 0.25f)), 2.5f);
                g.DrawPath(glow, path);
            }

            var font = Bold == (Font.Style.HasFlag(FontStyle.Bold)) ? Font : new Font(Font, Bold ? FontStyle.Bold : FontStyle.Regular);
            var textRect = new Rectangle(Padding.Left, Padding.Top,
                Math.Max(1, Width - Padding.Horizontal), Math.Max(1, Height - Padding.Vertical));
            TextRenderer.DrawText(g, Text, font, textRect, Enabled ? ForeColor : AppColors.TextMuted,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
            if (!ReferenceEquals(font, Font)) font.Dispose();
        }
    }
}

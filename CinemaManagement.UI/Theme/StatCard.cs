namespace CinemaManagement.UI.Theme
{
    /// <summary>Thẻ thống kê: icon tròn màu + tiêu đề + con số chạy từ 0 lên giá trị thật (hiệu ứng đếm).</summary>
    public class StatCard : CardPanel
    {
        public string Caption { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public Color IconBack { get; set; } = AppColors.PrimarySoft;
        public Color ValueColor { get; set; } = AppColors.TextPrimary;
        public string Suffix { get; set; } = string.Empty;

        private decimal _from, _target, _shown;
        private DateTime _start;
        private const int DurationMs = 800;
        private readonly System.Windows.Forms.Timer _timer = new() { Interval = 15 };

        public StatCard()
        {
            _timer.Tick += OnTick;
            MouseEnter += (s, e) => { if (!AccentColor.IsEmpty) { BorderColor = AccentColor; Invalidate(); } };
            MouseLeave += (s, e) => { BorderColor = AppColors.Border; Invalidate(); };
        }

        public void SetValue(decimal value, bool animate = true)
        {
            if (!animate || value == _target && !_timer.Enabled)
            {
                _from = _target = _shown = value;
                _timer.Stop();
                Invalidate();
                return;
            }
            _from = _shown;
            _target = value;
            _start = DateTime.Now;
            _timer.Start();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            double t = (DateTime.Now - _start).TotalMilliseconds / DurationMs;
            if (t >= 1)
            {
                _shown = _target;
                _timer.Stop();
            }
            else
            {
                double eased = 1 - Math.Pow(1 - t, 3);      // ease-out cubic: nhanh rồi chậm dần
                _shown = _from + (_target - _from) * (decimal)eased;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            UiKit.HighQuality(g);

            // glow mềm cùng màu nhấn ở góc phải-trên thẻ (đỏ / xanh / lục / tím tuỳ thẻ)
            if (!AccentColor.IsEmpty)
            {
                var body = BodyRect;
                using var clipPath = UiKit.RoundRect(body, this.S(Radius));
                var oldClip = g.Clip;
                g.SetClip(clipPath);
                UiKit.FillGlow(g, new RectangleF(body.Right - this.S(150), body.Y - this.S(90), this.S(260), this.S(190)),
                    AccentColor, 60);
                g.Clip = oldClip;
            }

            int pad = this.S(20);
            int contentH = Height - this.S(5);
            int d = this.S(54);
            var circle = new Rectangle(pad, (contentH - d) / 2 + this.S(3), d, d);

            using (var b = new SolidBrush(IconBack)) g.FillEllipse(b, circle);
            if (!AccentColor.IsEmpty)
                using (var ring = new Pen(Color.FromArgb(120, AccentColor), 1.5f)) g.DrawEllipse(ring, circle);
            using (var iconFont = new Font("Segoe UI Emoji", 17F))
                TextRenderer.DrawText(g, Icon, iconFont, circle,
                    AccentColor.IsEmpty ? AppColors.Primary : UiKit.Blend(AccentColor, Color.White, 0.2f),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            int x = circle.Right + this.S(16);
            int availW = Math.Max(this.S(40), Width - x - pad);

            string valueText = Math.Round(_shown).ToString("N0") + Suffix;
            float size = 26F;
            Font valueFont = new("Segoe UI", size, FontStyle.Bold);
            while (size > 14F && TextRenderer.MeasureText(valueText, valueFont).Width > availW)
            {
                valueFont.Dispose();
                size -= 2F;
                valueFont = new Font("Segoe UI", size, FontStyle.Bold);
            }

            using var capFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            int block = capFont.Height + valueFont.Height;
            int top = (contentH - block) / 2 + this.S(4);

            TextRenderer.DrawText(g, Caption.ToUpperInvariant(), capFont, new Point(x, top), AppColors.TextSecondary,
                TextFormatFlags.NoPadding);
            TextRenderer.DrawText(g, valueText, valueFont, new Point(x, top + capFont.Height), ValueColor,
                TextFormatFlags.NoPadding);
            valueFont.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _timer.Dispose();
            base.Dispose(disposing);
        }
    }
}

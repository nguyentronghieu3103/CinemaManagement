using Cinema.WinForms.Features.TicketSales;

namespace Cinema.WinForms.Controls;

public partial class MovieShowtimeCard : UserControl
{
    public MovieShowtimeCard()
    {
        InitializeComponent();
    }

    internal event EventHandler<ShowtimeSelectedEventArgs>? ShowtimeSelected;

    internal void SetMovie(ShowtimeMovie movie, IReadOnlyList<ShowtimeOption> showtimes, string? selectedId)
    {
        lblMovieTitle.Text = movie.Title;
        lblDetails.Text = $"{movie.Genre}  •  {movie.DurationMinutes} phút";
        lblRating.Text = movie.Rating;
        lblRating.BackColor = movie.Rating is "C16" or "C18"
            ? Color.FromArgb(254, 243, 199)
            : Color.FromArgb(241, 245, 249);
        lblRating.ForeColor = movie.Rating is "C16" or "C18"
            ? Color.FromArgb(146, 64, 14)
            : Color.FromArgb(51, 65, 85);
        AccessibleName = movie.Title;

        while (flowShowtimes.Controls.Count > 0)
        {
            flowShowtimes.Controls[0].Dispose();
        }

        foreach (ShowtimeOption showtime in showtimes)
        {
            var button = new ShowtimeButton(movie.Title, showtime, DeviceDpi)
            {
                TabIndex = flowShowtimes.Controls.Count
            };
            button.Click += (_, _) =>
                ShowtimeSelected?.Invoke(this, new ShowtimeSelectedEventArgs(movie.Id, movie.Title, showtime));
            flowShowtimes.Controls.Add(button);
        }

        HighlightShowtime(selectedId);
    }

    internal void HighlightShowtime(string? selectedId)
    {
        foreach (ShowtimeButton button in flowShowtimes.Controls.OfType<ShowtimeButton>())
        {
            button.SetSelected(button.Showtime.Id == selectedId);
        }
    }

    private sealed class ShowtimeButton : Button
    {
        private readonly Font timeFont;

        internal ShowtimeButton(string movieTitle, ShowtimeOption showtime, int dpi)
        {
            Showtime = showtime;
            timeFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            AccessibleName = $"{movieTitle}, {showtime.StartsAt:HH:mm}, {showtime.Room}, {showtime.Format}, "
                + $"{showtime.SeatsRemaining}/{showtime.TotalSeats} ghế";
            FlatStyle = FlatStyle.Flat;
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
            Size = new Size(Scale(102, dpi), Scale(68, dpi));
            Margin = new Padding(0, 0, Scale(8, dpi), Scale(6, dpi));
            FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(219, 234, 254);
        }

        internal ShowtimeOption Showtime { get; }

        internal void SetSelected(bool selected)
        {
            BackColor = selected ? Color.FromArgb(239, 246, 255) : Color.White;
            FlatAppearance.BorderColor = selected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(226, 232, 240);
            AccessibleDescription = selected ? "Suất đang chọn" : string.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLine(e.Graphics, $"{Showtime.StartsAt:HH:mm}", timeFont, Color.FromArgb(15, 23, 42), 5, 20);
            DrawLine(e.Graphics, $"{Showtime.Room} • {Showtime.Format}", Font, Color.FromArgb(51, 65, 85), 25, 18);
            DrawLine(e.Graphics, $"{Showtime.SeatsRemaining}/{Showtime.TotalSeats} ghế",
                Font, Color.FromArgb(71, 85, 105), 43, 18);
        }

        private void DrawLine(Graphics graphics, string text, Font font, Color color, int top, int height)
        {
            var bounds = new Rectangle(2, LogicalToDeviceUnits(top), Width - 4, LogicalToDeviceUnits(height));
            TextRenderer.DrawText(graphics, text, font, bounds, color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timeFont.Dispose();
            }

            base.Dispose(disposing);
        }

        private static int Scale(int value, int dpi) => (int)Math.Round(value * dpi / 96.0);
    }
}

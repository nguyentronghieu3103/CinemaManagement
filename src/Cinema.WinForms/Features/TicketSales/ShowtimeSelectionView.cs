using System.Globalization;
using System.Text;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

public partial class ShowtimeSelectionView : UserControl
{
    private readonly List<MovieShowtimeCard> cards = [];
    private IReadOnlyList<ShowtimeMovie> movies = [];
    private DateTime today;
    private int columnCount;
    private bool initialized;

    public ShowtimeSelectionView()
    {
        InitializeComponent();
    }

    public event EventHandler<ShowtimeSelectedEventArgs>? ShowtimeSelected;

    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public ShowtimeSelectedEventArgs? SelectedShowtime { get; private set; }

    internal void SetMovies(IReadOnlyList<ShowtimeMovie> availableMovies)
    {
        movies = availableMovies;
        if (initialized)
        {
            UpdateFilterOptions();
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (initialized || DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
        {
            return;
        }

        today = DateTime.Today;
        dateShowtime.Value = today;
        initialized = true;
        UpdateResponsiveLayout();
        UpdateFilterOptions();
    }

    private void UpdateFilterOptions()
    {
        ShowtimeOption[] showtimes = movies.SelectMany(movie => movie.Showtimes).ToArray();
        cboFormat.SelectedIndexChanged -= Filters_Changed;
        cboRoom.SelectedIndexChanged -= Filters_Changed;
        SetFilterOptions(cboFormat, showtimes.Select(showtime => showtime.Format));
        SetFilterOptions(cboRoom, showtimes.Select(showtime => showtime.Room));
        cboFormat.SelectedIndexChanged += Filters_Changed;
        cboRoom.SelectedIndexChanged += Filters_Changed;
        ApplyFilters();
    }

    private static void SetFilterOptions(ComboBox filter, IEnumerable<string> options)
    {
        object? selected = filter.SelectedItem;
        while (filter.Items.Count > 1)
        {
            filter.Items.RemoveAt(filter.Items.Count - 1);
        }

        filter.Items.AddRange(options.Distinct().Order().ToArray());
        filter.SelectedIndex = selected is null ? 0 : Math.Max(0, filter.Items.IndexOf(selected));
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (initialized)
        {
            UpdateResponsiveLayout();
        }
    }

    private void BtnToday_Click(object? sender, EventArgs e) => dateShowtime.Value = today;

    private void BtnTomorrow_Click(object? sender, EventArgs e) => dateShowtime.Value = today.AddDays(1);

    private void Filters_Changed(object? sender, EventArgs e)
    {
        if (initialized)
        {
            ApplyFilters();
        }
    }

    private void ApplyFilters()
    {
        DateTime selectedDate = dateShowtime.Value.Date;
        string search = NormalizeSearchText(txtSearch.Text.Trim());
        string? format = cboFormat.SelectedIndex > 0 ? (string?)cboFormat.SelectedItem : null;
        string? room = cboRoom.SelectedIndex > 0 ? (string?)cboRoom.SelectedItem : null;
        SetQuickDateAppearance(btnToday, selectedDate == today);
        SetQuickDateAppearance(btnTomorrow, selectedDate == today.AddDays(1));

        var matches = new List<(ShowtimeMovie Movie, ShowtimeOption[] Showtimes)>();
        foreach (ShowtimeMovie movie in movies)
        {
            if (!NormalizeSearchText(movie.Title).Contains(search, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            ShowtimeOption[] showtimes = movie.Showtimes.Where(showtime =>
                showtime.StartsAt.Date == selectedDate &&
                (format is null || showtime.Format == format) &&
                (room is null || showtime.Room == room)).ToArray();

            if (showtimes.Length > 0)
            {
                matches.Add((movie, showtimes));
            }
        }

        if (SelectedShowtime is { } selected &&
            !matches.Any(match => match.Showtimes.Any(showtime => showtime.Id == selected.Showtime.Id)))
        {
            SelectedShowtime = null;
        }

        gridMovies.SuspendLayout();
        try
        {
            while (gridMovies.Controls.Count > 0)
            {
                gridMovies.Controls[0].Dispose();
            }

            cards.Clear();
            foreach (var (movie, showtimes) in matches)
            {
                var card = new MovieShowtimeCard { Dock = DockStyle.Fill };
                card.SetMovie(movie, showtimes, SelectedShowtime?.Showtime.Id);
                card.ShowtimeSelected += Card_ShowtimeSelected;
                cards.Add(card);
            }

            LayoutCards();
        }
        finally
        {
            gridMovies.ResumeLayout(true);
        }

        pnlMovieScroll.AutoScrollPosition = Point.Empty;
        gridMovies.Visible = cards.Count > 0;
        lblEmpty.Visible = cards.Count == 0;
        lblInstruction.Visible = cards.Count > 0;
        lblEmpty.Text = movies.Count == 0 ? "Chưa có dữ liệu suất chiếu" : "Không tìm thấy suất chiếu phù hợp";
        UpdateSelectionLabel();
    }

    private void UpdateResponsiveLayout()
    {
        int filterWidth = flowFilters.Controls.Cast<Control>().Sum(control => control.Width + control.Margin.Horizontal)
            + flowFilters.Padding.Horizontal;
        int availableWidth = ClientSize.Width - layoutContent.Padding.Horizontal;
        layoutContent.RowStyles[2].Height = LogicalToDeviceUnits(availableWidth >= filterWidth ? 60 : 106);

        int nextColumnCount = availableWidth >= LogicalToDeviceUnits(1020) ? 2 : 1;
        if (columnCount != nextColumnCount)
        {
            columnCount = nextColumnCount;
            if (cards.Count > 0)
            {
                LayoutCards();
            }
        }
    }

    private void LayoutCards()
    {
        gridMovies.SuspendLayout();
        try
        {
            gridMovies.Controls.Clear();
            gridMovies.ColumnStyles.Clear();
            gridMovies.RowStyles.Clear();
            gridMovies.ColumnCount = columnCount;
            gridMovies.RowCount = (cards.Count + columnCount - 1) / columnCount;

            for (int column = 0; column < columnCount; column++)
            {
                gridMovies.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnCount));
            }

            for (int row = 0; row < gridMovies.RowCount; row++)
            {
                gridMovies.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            int gap = LogicalToDeviceUnits(12);
            for (int index = 0; index < cards.Count; index++)
            {
                MovieShowtimeCard card = cards[index];
                int column = index % columnCount;
                card.Margin = new Padding(0, 0, column == columnCount - 1 ? 0 : gap, gap);
                card.TabIndex = index;
                gridMovies.Controls.Add(card, column, index / columnCount);
            }
        }
        finally
        {
            gridMovies.ResumeLayout(true);
        }
    }

    private void Card_ShowtimeSelected(object? sender, ShowtimeSelectedEventArgs e)
    {
        SetSelection(e);
        ShowtimeSelected?.Invoke(this, e);
    }

    internal void ClearSelection() => SetSelection(null);

    private void SetSelection(ShowtimeSelectedEventArgs? selection)
    {
        SelectedShowtime = selection;
        foreach (MovieShowtimeCard card in cards)
        {
            card.HighlightShowtime(selection?.Showtime.Id);
        }

        UpdateSelectionLabel();
    }

    private void UpdateSelectionLabel()
    {
        lblSelected.Text = SelectedShowtime is { Showtime: var showtime }
            ? $"Đã chọn {showtime.StartsAt:HH:mm}  •  {showtime.Room}  •  {showtime.Format}"
            : string.Empty;
    }

    private static void SetQuickDateAppearance(Button button, bool selected)
    {
        button.BackColor = selected ? Color.FromArgb(239, 246, 255) : Color.White;
        button.ForeColor = selected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(15, 23, 42);
        button.FlatAppearance.BorderColor = selected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(226, 232, 240);
    }

    private static string NormalizeSearchText(string text)
    {
        string decomposed = text.Replace('đ', 'd').Replace('Đ', 'D').Normalize(NormalizationForm.FormD);
        return string.Concat(decomposed.Where(character =>
            char.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark));
    }
}

public sealed record ShowtimeOption(
    string Id,
    DateTime StartsAt,
    string Room,
    string Format,
    int SeatsRemaining,
    int TotalSeats);

public sealed class ShowtimeSelectedEventArgs(
    string movieId,
    string movieTitle,
    ShowtimeOption showtime) : EventArgs
{
    public string MovieId { get; } = movieId;
    public string MovieTitle { get; } = movieTitle;
    public ShowtimeOption Showtime { get; } = showtime;
}

internal sealed record ShowtimeMovie(
    string Id,
    string Title,
    string Genre,
    int DurationMinutes,
    string Rating,
    IReadOnlyList<ShowtimeOption> Showtimes);

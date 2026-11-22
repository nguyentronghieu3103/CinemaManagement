namespace Cinema.WinForms.Features.TicketSales;

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

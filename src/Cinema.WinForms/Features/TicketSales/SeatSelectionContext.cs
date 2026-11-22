using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

internal sealed record SeatSelectionContext(
    ShowtimeSelectedEventArgs Showtime,
    IReadOnlyList<AuditoriumSeat> Seats,
    Guid SelectionId)
{
    internal decimal TicketSubtotal => Seats.Sum(seat => seat.Price);

    internal int PlaceCount => Seats.Sum(seat => seat.Places);

    internal static string RoomCaption(string room) => room.StartsWith("P.", StringComparison.Ordinal)
        ? $"Phòng {room[2..]}"
        : room;
}

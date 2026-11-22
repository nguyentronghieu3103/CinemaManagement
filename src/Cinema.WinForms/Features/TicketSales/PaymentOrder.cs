namespace Cinema.WinForms.Features.TicketSales;

internal sealed record PaymentOrderLine(string Description, int Quantity, decimal UnitPrice)
{
    public decimal Amount => Quantity * UnitPrice;
}

internal sealed class PaymentOrder(SeatSelectionContext selection, IEnumerable<PaymentOrderLine> concessions)
{
    internal SeatSelectionContext Selection { get; } = selection;

    internal IReadOnlyList<PaymentOrderLine> Lines { get; } = selection.Seats
        .GroupBy(seat => (seat.TypeName, seat.Price))
        .Select(group => new PaymentOrderLine($"Vé {group.Key.TypeName}", group.Count(), group.Key.Price))
        .Concat(concessions)
        .ToArray();

    internal decimal Total => Lines.Sum(line => line.Amount);
}

using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

internal enum PaymentMethod
{
    Cash,
    BankQr
}

internal sealed record IssuedTicket(string Code, AuditoriumSeat Seat);

internal sealed class CompletedSale
{
    internal CompletedSale(PaymentOrder order, PaymentMethod method, decimal? cashTendered,
        string? operatorName, string? terminalName)
    {
        Order = order;
        Method = method;
        CashTendered = cashTendered;
        OperatorName = string.IsNullOrWhiteSpace(operatorName) ? "—" : operatorName;
        TerminalName = string.IsNullOrWhiteSpace(terminalName) ? "—" : terminalName;
        PaidAt = DateTimeOffset.Now;
        InvoiceCode = $"HD-{Guid.NewGuid().ToString("N")[..12].ToUpperInvariant()}";
        Tickets = order.Selection.Seats
            .OrderBy(seat => seat.Row)
            .ThenBy(seat => seat.Column)
            .Select(seat => new IssuedTicket($"VE-{InvoiceCode[3..]}-{seat.Code}", seat))
            .ToArray();
    }

    internal PaymentOrder Order { get; }
    internal PaymentMethod Method { get; }
    internal decimal? CashTendered { get; }
    internal decimal? CashChange => CashTendered - Order.Total;
    internal string OperatorName { get; }
    internal string TerminalName { get; }
    internal DateTimeOffset PaidAt { get; }
    internal string InvoiceCode { get; }
    internal IReadOnlyList<IssuedTicket> Tickets { get; }
    internal string PaymentCaption => Method == PaymentMethod.Cash ? "Tiền mặt" : "QR ngân hàng";

    internal IEnumerable<string> GetPaymentDetails()
    {
        yield return $"Phương thức: {PaymentCaption}";
        if (CashTendered is decimal tendered && CashChange is decimal change)
        {
            yield return $"Tiền khách đưa: {AuditoriumSeat.FormatPrice(tendered)}";
            yield return $"Tiền thừa: {AuditoriumSeat.FormatPrice(change)}";
        }
    }
}

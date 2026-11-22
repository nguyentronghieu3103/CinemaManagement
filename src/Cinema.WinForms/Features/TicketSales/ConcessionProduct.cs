namespace Cinema.WinForms.Features.TicketSales;

internal enum ConcessionCategory
{
    Combo,
    Popcorn,
    Drink,
    Snack
}

internal sealed record ConcessionProduct(string Name, string Description, decimal Price, ConcessionCategory Category);

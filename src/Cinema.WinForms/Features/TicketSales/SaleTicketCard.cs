using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

public partial class SaleTicketCard : UserControl
{
    public SaleTicketCard()
    {
        InitializeComponent();
    }

    internal event EventHandler? PrintRequested;

    internal void ShowTicket(ShowtimeSelectedEventArgs selection, IssuedTicket ticket)
    {
        ShowtimeOption showtime = selection.Showtime;
        lblFilm.Text = selection.MovieTitle;
        lblSession.Text = $"{showtime.StartsAt:dd/MM/yyyy  ·  HH:mm}";
        lblRoomAndType.Text = $"{SeatSelectionContext.RoomCaption(showtime.Room)} · {ticket.Seat.TypeName} · {AuditoriumSeat.FormatPrice(ticket.Seat.Price)}";
        lblSeat.Text = ticket.Seat.Code;
        lblTicketCode.Text = ticket.Code;
        lblQr.AccessibleName = "Ô minh họa QR soát vé";
        btnPrintTicket.AccessibleName = $"In vé ghế {ticket.Seat.Code}";
        AccessibleName = $"Vé xem phim ghế {ticket.Seat.Code}";
    }

    internal void ClearTicket()
    {
        lblFilm.Text = lblSession.Text = lblRoomAndType.Text = lblSeat.Text = lblTicketCode.Text = string.Empty;
        btnPrintTicket.AccessibleName = AccessibleName = string.Empty;
    }

    private void BtnPrintTicket_Click(object? sender, EventArgs e) => PrintRequested?.Invoke(this, EventArgs.Empty);
}

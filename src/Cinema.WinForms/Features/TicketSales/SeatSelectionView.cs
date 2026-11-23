using System.ComponentModel;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

public partial class SeatSelectionView : UserControl
{
    private readonly BindingList<AuditoriumSeat> selectedSeats = [];
    private ShowtimeSelectedEventArgs? currentShowtime;
    private Guid selectionId;

    public SeatSelectionView()
    {
        InitializeComponent();
        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            ticketsBindingSource.DataSource = selectedSeats;
            if (gridSelectedSeats.Columns["colPrice"] is { } priceColumn)
            {
                priceColumn.DefaultCellStyle.FormatProvider = AuditoriumSeat.MoneyCulture;
            }

            seatMap.SeatClicked += SeatMap_SeatClicked;
            layoutWorkArea.SizeChanged += LayoutWorkArea_SizeChanged;
            UpdateSummary();
        }
    }

    internal event EventHandler? BackRequested;
    internal event Action<SeatSelectionContext>? ContinueRequested;

    internal void ShowFor(ShowtimeSelectedEventArgs selection, IReadOnlyList<AuditoriumSeat> seats)
    {
        ResetSelection();
        currentShowtime = selection;
        SetNotice(seats.Count == 0 ? "Chưa có sơ đồ ghế cho suất chiếu này." : string.Empty);
        string room = SeatSelectionContext.RoomCaption(selection.Showtime.Room);
        lblShowtime.Text = $"{selection.MovieTitle}  ·  {room}  ·  {selection.Showtime.Format}";
        lblShowtimeDate.Text = $"{selection.Showtime.StartsAt:dd/MM/yyyy  ·  HH:mm}";
        seatMap.SetSeats(seats);
    }

    internal bool TryContinue()
    {
        if (!Visible || currentShowtime is not { } showtime || selectedSeats.Count == 0)
        {
            return false;
        }

        ContinueRequested?.Invoke(new SeatSelectionContext(showtime, selectedSeats.ToArray(), selectionId));
        return true;
    }

    private void SeatMap_SeatClicked(AuditoriumSeat seat)
    {
        if (selectedSeats.Contains(seat))
        {
            RemoveSeat(seat);
            return;
        }

        if (selectedSeats.Count == 0)
        {
            selectionId = Guid.NewGuid();
        }

        selectedSeats.Add(seat);
        seatMap.SetSelected(seat, true);
        UpdateSummary();
    }

    private void RemoveSeat(AuditoriumSeat seat)
    {
        selectedSeats.Remove(seat);
        seatMap.SetSelected(seat, false);
        UpdateSummary();
    }

    internal void ClearDraft()
    {
        if (currentShowtime is null)
        {
            return;
        }

        ResetSelection();
        currentShowtime = null;
        seatMap.SetSeats([]);
        lblShowtime.Text = lblShowtimeDate.Text = string.Empty;
        SetNotice(string.Empty);
    }

    private void ResetSelection()
    {
        foreach (AuditoriumSeat seat in selectedSeats)
        {
            seatMap.SetSelected(seat, false);
        }

        selectedSeats.Clear();
        UpdateSummary();
    }

    private void UpdateSummary()
    {
        lblSeatCount.Text = selectedSeats.Sum(seat => seat.Places).ToString();
        lblSubtotal.Text = AuditoriumSeat.FormatPrice(selectedSeats.Sum(seat => seat.Price));
        UpdateTicketPanel();
    }

    private void SetNotice(string message)
    {
        lblNotice.Text = message;
        lblNotice.Visible = message.Length > 0;
    }

    private void UpdateTicketPanel()
    {
        bool hasSelection = selectedSeats.Count > 0;
        layoutWorkArea.ColumnStyles[1].Width = hasSelection
            ? Math.Max(LogicalToDeviceUnits(280), (float)Math.Round(layoutWorkArea.ClientSize.Width * 0.30))
            : 0;
        pnlSelectedTickets.Visible = hasSelection;
    }

    private void LayoutWorkArea_SizeChanged(object? sender, EventArgs e)
    {
        bool compact = layoutWorkArea.ClientSize.Height < LogicalToDeviceUnits(340);
        layoutTickets.RowStyles[0].Height = LogicalToDeviceUnits(compact ? 28 : 36);
        layoutTickets.RowStyles[1].Height = LogicalToDeviceUnits(compact ? 32 : 40);
        layoutTickets.RowStyles[3].Height = LogicalToDeviceUnits(compact ? 25 : 36);
        layoutTickets.RowStyles[4].Height = LogicalToDeviceUnits(compact ? 40 : 50);
        layoutTickets.RowStyles[5].Height = LogicalToDeviceUnits(compact ? 38 : 50);
        UpdateTicketPanel();
    }

    private void GridSelectedSeats_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == colRemove.Index &&
            gridSelectedSeats.Rows[e.RowIndex].DataBoundItem is AuditoriumSeat seat)
        {
            RemoveSeat(seat);
        }
    }

    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    private void BtnContinue_Click(object? sender, EventArgs e) => TryContinue();
}

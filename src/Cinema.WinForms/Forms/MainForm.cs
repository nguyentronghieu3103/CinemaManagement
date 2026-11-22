using Cinema.WinForms.Features.TicketSales;

namespace Cinema.WinForms.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        showtimeSelectionView.SetMovies([]);
        showtimeSelectionView.ShowtimeSelected += ShowtimeSelectionView_ShowtimeSelected;
        seatSelectionView.BackRequested += (_, _) => ShowShowtimeSelection();
        seatSelectionView.ContinueRequested += ShowConcessionSelection;
        concessionSelectionView.BackRequested += (_, _) => ShowSeatSelection();
        concessionSelectionView.ContinueRequested += ShowPayment;
        paymentView.BackRequested += (_, _) => ReturnToConcessionSelection();
        paymentView.PaymentConfirmed += ShowSaleCompletion;
        saleCompletionView.NewSaleRequested += (_, _) => ShowShowtimeSelection();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode && System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
        {
            ClockTimer_Tick(this, EventArgs.Empty);
            clockTimer.Start();
        }
    }

    private void MenuNavigation_SizeChanged(object? sender, EventArgs e)
    {
        if (sender is ToolStrip menu && menu.ClientSize.Width > 0)
        {
            menu.SuspendLayout();
            foreach (ToolStripItem item in menu.Items)
            {
                item.Size = new Size(menu.ClientSize.Width, menu.LogicalToDeviceUnits(44));
            }

            menu.ResumeLayout();
        }
    }

    private void ClockTimer_Tick(object? sender, EventArgs e)
    {
        lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        return saleCompletionView.HandleShortcut(keyData) || paymentView.HandleShortcut(keyData) ||
            (keyData == Keys.F2 && seatSelectionView.TryContinue()) ||
            base.ProcessCmdKey(ref msg, keyData);
    }

    private void ShowtimeSelectionView_ShowtimeSelected(object? sender, ShowtimeSelectedEventArgs e)
    {
        seatSelectionView.ShowFor(e, []);
        ShowSeatSelection();
    }

    private void ShowSeatSelection()
    {
        paymentView.Hide();
        concessionSelectionView.Hide();
        showtimeSelectionView.Hide();
        seatSelectionView.Show();
        seatSelectionView.Select();
    }

    private void ShowConcessionSelection(SeatSelectionContext selection)
    {
        concessionSelectionView.ShowFor(selection, []);
        seatSelectionView.Hide();
        concessionSelectionView.Show();
        concessionSelectionView.Select();
    }

    private void ShowShowtimeSelection()
    {
        saleCompletionView.Hide();
        paymentView.Hide();
        concessionSelectionView.Hide();
        seatSelectionView.Hide();
        saleCompletionView.ClearSale();
        paymentView.ClearDraft();
        concessionSelectionView.ClearDraft();
        seatSelectionView.ClearDraft();
        showtimeSelectionView.ClearSelection();
        showtimeSelectionView.Show();
        showtimeSelectionView.Select();
    }

    private void ShowPayment(PaymentOrder order)
    {
        paymentView.ShowFor(order);
        concessionSelectionView.Hide();
        paymentView.Show();
        paymentView.Select();
    }

    private void ReturnToConcessionSelection()
    {
        paymentView.Hide();
        concessionSelectionView.Show();
        concessionSelectionView.Select();
    }

    private void ShowSaleCompletion(CompletedSale sale)
    {
        paymentView.Hide();
        saleCompletionView.ShowFor(sale);
        saleCompletionView.Show();
        saleCompletionView.FocusNewSale();
    }

    private void NavTicketSales_Click(object? sender, EventArgs e) => ShowShowtimeSelection();

    private void lblOperator_Click(object sender, EventArgs e)
    {

    }
}

internal sealed class PosNavigationRenderer : ToolStripSystemRenderer
{
    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        // The navigation and its rail share one continuous background.
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        if (!e.Item.Enabled)
        {
            TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle,
                Color.FromArgb(148, 163, 184), e.TextFormat);
            return;
        }

        base.OnRenderItemText(e);
    }
}

namespace Cinema.WinForms.Features.TicketCheckIn;

public partial class CheckInHistoryView : UserControl
{
    public CheckInHistoryView()
    {
        InitializeComponent();
        gridHistory.RowsAdded += (_, _) => UpdateVisibleRows();
        gridHistory.RowsRemoved += (_, _) => UpdateVisibleRows();
    }

    internal event EventHandler? BackRequested;

    internal void ShowFrom(bool fromResult)
    {
        btnBack.Text = fromResult ? "‹  Quay lại kết quả soát vé" : "‹  Quay lại màn hình quét vé";
        pnlViewport.AutoScrollPosition = Point.Empty;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateScrollSize();
        UpdateVisibleRows();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdateScrollSize();
        UpdateVisibleRows();
    }

    private void UpdateScrollSize()
    {
        Size minimumSize = LogicalToDeviceUnits(new Size(828, 544));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void UpdateVisibleRows()
    {
        int count = gridHistory.Rows.Count;
        lblEmptyState.Visible = count == 0;
        gridHistory.Dock = count == 0 ? DockStyle.Top : DockStyle.Fill;
        if (count == 0)
        {
            gridHistory.Height = gridHistory.ColumnHeadersHeight;
        }

        lblCount.Text = $"{count} lượt quét";
    }

    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);
}

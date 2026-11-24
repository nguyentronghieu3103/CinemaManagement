namespace Cinema.WinForms.Features.TicketCheckIn;

public partial class CheckInSessionView : UserControl
{
    public CheckInSessionView()
    {
        InitializeComponent();
        cmbRoomFilter.SelectedIndex = 0;
        btnStart1.Click += BtnStart_Click;
        btnStart2.Click += BtnStart_Click;
        btnStart3.Click += BtnStart_Click;
        btnStart4.Click += BtnStart_Click;
        btnStart5.Click += BtnStart_Click;
        btnStart6.Click += BtnStart_Click;
    }

    internal event EventHandler? ScannerRequested;

    private void BtnStart_Click(object? sender, EventArgs e) => ScannerRequested?.Invoke(this, EventArgs.Empty);

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateScrollSize();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdateScrollSize();
    }

    private void UpdateScrollSize()
    {
        Size minimumSize = LogicalToDeviceUnits(new Size(800, 496));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }
}

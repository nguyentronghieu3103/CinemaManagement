namespace Cinema.WinForms.Features.ShiftManagement;

public partial class ShiftManagementView : UserControl
{
    public ShiftManagementView()
    {
        InitializeComponent();
    }

    internal event EventHandler? CloseShiftRequested;

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
        Size minimumSize = LogicalToDeviceUnits(new Size(800, 435));
        layoutDashboard.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void BtnCloseShift_Click(object? sender, EventArgs e) =>
        CloseShiftRequested?.Invoke(this, EventArgs.Empty);
}

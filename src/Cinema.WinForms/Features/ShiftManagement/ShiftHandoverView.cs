namespace Cinema.WinForms.Features.ShiftManagement;

public partial class ShiftHandoverView : UserControl
{
    public ShiftHandoverView()
    {
        InitializeComponent();
    }

    internal event EventHandler? BackRequested;

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
        Size minimumSize = LogicalToDeviceUnits(new Size(800, 530));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void BtnBackToOverview_Click(object? sender, EventArgs e) =>
        BackRequested?.Invoke(this, EventArgs.Empty);
}

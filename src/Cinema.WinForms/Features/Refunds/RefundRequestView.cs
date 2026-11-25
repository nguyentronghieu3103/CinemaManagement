namespace Cinema.WinForms.Features.Refunds;

public partial class RefundRequestView : UserControl
{
    public RefundRequestView()
    {
        InitializeComponent();
        cmbReason.SelectedIndex = 0;
    }

    internal event EventHandler? BackRequested;

    internal void ShowFor(string orderCode, string expectedRefund, string paymentMethod)
    {
        lblOrderCode.Text = $"Hóa đơn #{orderCode}";
        lblExpectedRefund.Text = expectedRefund;
        lblRefundMethod.Text = paymentMethod;
        cmbReason.SelectedIndex = 0;
        txtNote.Clear();
        pnlViewport.AutoScrollPosition = Point.Empty;
    }

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
        Size minimumSize = LogicalToDeviceUnits(new Size(824, 549));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);
}

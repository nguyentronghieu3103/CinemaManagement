namespace Cinema.WinForms.Features.TicketCheckIn;

public partial class TicketScannerView : UserControl
{
    public TicketScannerView()
    {
        InitializeComponent();
        checkInHeader.ChangeSessionRequested += (_, _) => ChangeSessionRequested?.Invoke(this, EventArgs.Empty);
        checkInHeader.HistoryRequested += (_, _) => HistoryRequested?.Invoke(this, EventArgs.Empty);
    }

    internal event EventHandler? ChangeSessionRequested;
    internal event EventHandler? CheckRequested;
    internal event EventHandler? HistoryRequested;

    internal bool HandleHistoryShortcut(Keys keyData) => checkInHeader.HandleHistoryShortcut(keyData);

    internal void ResetInput()
    {
        txtTicketCode.Clear();
        lblCameraStatus.Text = "Camera đang tắt";
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
        Size minimumSize = LogicalToDeviceUnits(new Size(688, 504));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void BtnCamera_Click(object? sender, EventArgs e) => lblCameraStatus.Text = "Camera chưa được kết nối";

    private void BtnCheck_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTicketCode.Text))
        {
            txtTicketCode.Select();
            return;
        }

        CheckRequested?.Invoke(this, EventArgs.Empty);
    }

    private void TxtTicketCode_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnCheck.PerformClick();
        }
    }
}

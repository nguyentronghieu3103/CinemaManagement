namespace Cinema.WinForms.Features.TicketCheckIn;

public partial class TicketScanResultView : UserControl
{
    public TicketScanResultView()
    {
        InitializeComponent();
        checkInHeader.ChangeSessionRequested += (_, _) => ChangeSessionRequested?.Invoke(this, EventArgs.Empty);
        checkInHeader.HistoryRequested += (_, _) => HistoryRequested?.Invoke(this, EventArgs.Empty);
        ShowResult();
    }

    internal event EventHandler? ChangeSessionRequested;
    internal event EventHandler? BackRequested;
    internal event EventHandler? HistoryRequested;

    internal bool HandleHistoryShortcut(Keys keyData) => checkInHeader.HandleHistoryShortcut(keyData);

    internal void ShowResult(string? verifiedSeatCode = null, string? sessionCaption = null)
    {
        bool hasVerifiedSeat = !string.IsNullOrWhiteSpace(verifiedSeatCode);
        lblResultStatus.Text = hasVerifiedSeat ? "✓  Vé hợp lệ" : "Chưa có kết quả soát vé";
        lblResultStatus.BackColor = hasVerifiedSeat ? Color.FromArgb(220, 252, 231) : Color.FromArgb(241, 245, 249);
        lblResultStatus.ForeColor = hasVerifiedSeat ? Color.FromArgb(22, 101, 52) : Color.FromArgb(51, 65, 85);
        lblSeatCode.Text = hasVerifiedSeat ? verifiedSeatCode : "—";
        lblResultSession.Text = sessionCaption ?? "Phòng — · Suất —";
        btnConfirm.Enabled = hasVerifiedSeat;
        btnConfirm.BackColor = hasVerifiedSeat ? Color.FromArgb(37, 99, 235) : Color.FromArgb(226, 232, 240);
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
        Size minimumSize = LogicalToDeviceUnits(new Size(688, 512));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    private void btnConfirm_Click(object sender, EventArgs e)
    {

    }
}

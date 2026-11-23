namespace Cinema.WinForms.Features.TicketCheckIn;

public partial class CheckInScreenHeader : UserControl
{
    public CheckInScreenHeader()
    {
        InitializeComponent();
    }

    internal event EventHandler? ChangeSessionRequested;
    internal event EventHandler? HistoryRequested;

    internal bool HandleHistoryShortcut(Keys keyData)
    {
        if (!Visible || keyData != Keys.F4)
        {
            return false;
        }

        btnHistory.PerformClick();
        return true;
    }

    private void BtnChangeSession_Click(object? sender, EventArgs e) =>
        ChangeSessionRequested?.Invoke(this, EventArgs.Empty);

    private void BtnHistory_Click(object? sender, EventArgs e) =>
        HistoryRequested?.Invoke(this, EventArgs.Empty);
}

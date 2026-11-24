namespace Cinema.WinForms.Features.Members;

public partial class MemberEditView : UserControl
{
    public MemberEditView()
    {
        InitializeComponent();
    }

    internal event EventHandler? CancelRequested;

    internal void ShowFor(MemberListEntry member)
    {
        lblMemberCode.Text = member.Code;
        txtFullName.Text = member.FullName;
        lblPhoneValue.Text = member.Phone;
        lblEmailValue.Text = member.Email ?? "—";
        lblBirthDateValue.Text = member.BirthDate;
        lblTierValue.Text = member.Tier;
        lblTierValue.ForeColor = member.Tier == "Gold" ? Color.FromArgb(146, 64, 14) : ForeColor;
        lblPointsValue.Text = $"{member.Points} điểm";
        pnlViewport.AutoScrollPosition = Point.Empty;
    }

    internal void FocusName()
    {
        txtFullName.Select();
        txtFullName.Select(txtFullName.TextLength, 0);
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
        Size minimumSize = LogicalToDeviceUnits(new Size(740, 432));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void TxtFullName_Enter(object? sender, EventArgs e) => pnlNameFrame.BackColor = btnSave.BackColor;

    private void TxtFullName_Leave(object? sender, EventArgs e) => pnlNameFrame.BackColor = pnlEditCard.BackColor;

    private void BtnCancel_Click(object? sender, EventArgs e) => CancelRequested?.Invoke(this, EventArgs.Empty);
}

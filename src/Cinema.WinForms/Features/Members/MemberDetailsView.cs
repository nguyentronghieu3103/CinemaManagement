namespace Cinema.WinForms.Features.Members;

public partial class MemberDetailsView : UserControl
{
    private static readonly Color Primary = Color.FromArgb(37, 99, 235);
    private static readonly Color Ink = Color.FromArgb(15, 23, 42);

    private MemberListEntry? currentMember;

    public MemberDetailsView()
    {
        InitializeComponent();
    }

    internal event EventHandler? BackRequested;
    internal event Action<MemberListEntry>? EditRequested;

    internal void ShowFor(MemberListEntry member)
    {
        currentMember = member;
        bool hasSampleProfile = member.HasSampleProfile;
        lblTitle.Text = $"Hồ sơ thành viên: {member.FullName}";
        lblMemberCode.Text = member.Code;
        lblMemberName.Text = member.FullName;
        lblFullNameValue.Text = member.FullName;
        lblPhoneValue.Text = member.Phone;
        lblBirthDateValue.Text = member.BirthDate;
        lblPoints.Text = member.Points;
        lblTier.Text = member.Tier.ToUpperInvariant();
        (lblTier.BackColor, lblTier.ForeColor) = member.Tier switch
        {
            "Gold" => (Color.FromArgb(254, 243, 199), Color.FromArgb(146, 64, 14)),
            "Diamond" => (Color.FromArgb(237, 233, 254), Color.FromArgb(91, 33, 182)),
            _ => (Color.FromArgb(226, 232, 240), Color.FromArgb(51, 65, 85))
        };

        lblGenderValue.Text = hasSampleProfile ? "Nam" : "—";
        lblEmailValue.Text = member.Email ?? "—";
        lblJoinDateValue.Text = hasSampleProfile ? "10/05/2026" : "—";
        lblStatusValue.Text = hasSampleProfile ? "Đang hoạt động" : "Chưa có dữ liệu";
        lblStatusValue.BackColor = hasSampleProfile ? Color.FromArgb(220, 252, 231) : Color.FromArgb(241, 245, 249);
        lblStatusValue.ForeColor = hasSampleProfile ? Color.FromArgb(22, 101, 52) : Color.FromArgb(100, 116, 139);
        pnlProgressDivider.Visible = layoutProgress.Visible = lblProgressHint.Visible = hasSampleProfile;

        ShowHistory(showPoints: true);
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
        Size minimumSize = LogicalToDeviceUnits(new Size(828, 514));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void ShowHistory(bool showPoints)
    {
        bool hasSampleHistory = currentMember?.HasSampleProfile ?? true;
        SetTabStyle(btnPointHistory, showPoints);
        SetTabStyle(btnPurchaseHistory, !showPoints);
        pnlPointTable.Visible = hasSampleHistory && showPoints;
        pnlPurchaseTable.Visible = hasSampleHistory && !showPoints;
        lblEmptyHistory.Visible = !hasSampleHistory;

        TableLayoutPanel table = showPoints ? layoutPointTable : layoutPurchaseTable;
        int transactions = hasSampleHistory ? table.RowCount - 1 : 0;
        lblTransactionCount.Text = $"{transactions} giao dịch.";
        lblCurrentPage.Text = hasSampleHistory ? "1" : "—";
    }

    private static void SetTabStyle(Button tab, bool selected)
    {
        tab.BackColor = selected ? Primary : Color.White;
        tab.ForeColor = selected ? Color.White : Ink;
        tab.FlatAppearance.BorderSize = selected ? 0 : 1;
    }

    private void BtnPointHistory_Click(object? sender, EventArgs e) => ShowHistory(showPoints: true);

    private void BtnPurchaseHistory_Click(object? sender, EventArgs e) => ShowHistory(showPoints: false);

    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (currentMember is { } member)
        {
            EditRequested?.Invoke(member);
        }
    }
}

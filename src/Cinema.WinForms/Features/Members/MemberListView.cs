namespace Cinema.WinForms.Features.Members;

public partial class MemberListView : UserControl
{
    public MemberListView()
    {
        InitializeComponent();
        cmbTierFilter.SelectedIndex = 0;
        cmbStatusFilter.SelectedIndex = 0;
        cmbPageSize.SelectedIndex = 0;
        BindRowActions(btnDetails1, btnEdit1, lblCode1, lblName1, lblPhone1, lblBirthDate1, lblTier1, lblPoints1);
        BindRowActions(btnDetails2, btnEdit2, lblCode2, lblName2, lblPhone2, lblBirthDate2, lblTier2, lblPoints2);
        BindRowActions(btnDetails3, btnEdit3, lblCode3, lblName3, lblPhone3, lblBirthDate3, lblTier3, lblPoints3);
        BindRowActions(btnDetails4, btnEdit4, lblCode4, lblName4, lblPhone4, lblBirthDate4, lblTier4, lblPoints4);
        BindRowActions(btnDetails5, btnEdit5, lblCode5, lblName5, lblPhone5, lblBirthDate5, lblTier5, lblPoints5);
        BindRowActions(btnDetails6, btnEdit6, lblCode6, lblName6, lblPhone6, lblBirthDate6, lblTier6, lblPoints6);
        BindRowActions(btnDetails7, btnEdit7, lblCode7, lblName7, lblPhone7, lblBirthDate7, lblTier7, lblPoints7);
        BindRowActions(btnDetails8, btnEdit8, lblCode8, lblName8, lblPhone8, lblBirthDate8, lblTier8, lblPoints8);
    }

    internal event Action<MemberListEntry>? DetailsRequested;
    internal event Action<MemberListEntry>? EditRequested;
    internal event EventHandler? RegistrationRequested;

    internal bool HandleShortcut(Keys keyData)
    {
        if (!Visible || keyData != Keys.F2)
        {
            return false;
        }

        btnAddMember.PerformClick();
        return true;
    }

    private void BtnAddMember_Click(object? sender, EventArgs e) =>
        RegistrationRequested?.Invoke(this, EventArgs.Empty);

    private void BindRowActions(
        Button details, Button edit, Label code, Label name, Label phone, Label birthDate, Label tier, Label points)
    {
        MemberListEntry GetMember() => new(code.Text, name.Text, phone.Text, birthDate.Text, tier.Text, points.Text);

        details.Click += (_, _) => DetailsRequested?.Invoke(GetMember());
        edit.Click += (_, _) => EditRequested?.Invoke(GetMember());
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
        Size minimumSize = LogicalToDeviceUnits(new Size(808, 490));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }
}

internal sealed record MemberListEntry(
    string Code, string FullName, string Phone, string BirthDate, string Tier, string Points)
{
    internal bool HasSampleProfile => Code == "MEM-00124";

    internal string? Email => HasSampleProfile ? "nam@example.com" : null;
}

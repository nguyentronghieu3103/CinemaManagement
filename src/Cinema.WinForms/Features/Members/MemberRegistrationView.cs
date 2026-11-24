namespace Cinema.WinForms.Features.Members;

public partial class MemberRegistrationView : UserControl
{
    private const string EmptyBirthDateFormat = "'dd/mm/yyyy'";

    public MemberRegistrationView()
    {
        InitializeComponent();
    }

    internal event EventHandler? BackRequested;

    internal void ResetDraft()
    {
        txtFullName.Clear();
        txtPhone.Clear();
        txtEmail.Clear();
        dtpBirthDate.Value = DateTime.Today;
        dtpBirthDate.Checked = false;
        dtpBirthDate.CustomFormat = EmptyBirthDateFormat;
        cmbGender.SelectedIndex = 0;
        chkConsent.Checked = false;
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
        Size minimumSize = LogicalToDeviceUnits(new Size(680, 538));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void DtpBirthDate_ValueChanged(object? sender, EventArgs e) =>
        dtpBirthDate.CustomFormat = dtpBirthDate.Checked ? "dd/MM/yyyy" : EmptyBirthDateFormat;

    private void TextField_Enter(object? sender, EventArgs e)
    {
        if (sender is TextBox { Parent.Parent: Panel frame })
        {
            frame.BackColor = btnSave.BackColor;
        }
    }

    private void TextField_Leave(object? sender, EventArgs e)
    {
        if (sender is TextBox { Parent.Parent: Panel frame })
        {
            frame.BackColor = pnlRegistrationCard.BackColor;
        }
    }

    private void ReturnToList_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);
}

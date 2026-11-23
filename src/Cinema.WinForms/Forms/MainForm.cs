using Cinema.WinForms.Features.Members;
using Cinema.WinForms.Features.TicketSales;

namespace Cinema.WinForms.Forms;

public partial class MainForm : Form
{
    private const string PreviewOperator = "Nguyễn Văn A · POS-01";

    private Control? memberPageBeforeEdit;

    public MainForm()
    {
        InitializeComponent();
        menuNavigation.Renderer = new PosNavigationRenderer();
        showtimeSelectionView.SetMovies([]);
        showtimeSelectionView.ShowtimeSelected += ShowtimeSelectionView_ShowtimeSelected;
        seatSelectionView.BackRequested += (_, _) => ShowShowtimeSelection();
        seatSelectionView.ContinueRequested += ShowConcessionSelection;
        concessionSelectionView.BackRequested += (_, _) => ShowSeatSelection();
        concessionSelectionView.ContinueRequested += ShowPayment;
        paymentView.BackRequested += (_, _) => ReturnToConcessionSelection();
        paymentView.PaymentConfirmed += ShowSaleCompletion;
        saleCompletionView.NewSaleRequested += (_, _) => ShowShowtimeSelection();
        shiftManagementView.CloseShiftRequested += (_, _) => ShowShiftHandover();
        shiftHandoverView.BackRequested += (_, _) => ShowShiftOverview();
        memberListView.DetailsRequested += ShowMemberDetails;
        memberListView.EditRequested += member => ShowMemberEdit(member, memberListView);
        memberListView.RegistrationRequested += (_, _) => ShowMemberRegistration();
        memberDetailsView.BackRequested += (_, _) => ShowMemberList();
        memberDetailsView.EditRequested += member => ShowMemberEdit(member, memberDetailsView);
        memberEditView.CancelRequested += (_, _) => CloseMemberEdit();
        memberRegistrationView.BackRequested += (_, _) => ShowMemberList();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        MenuNavigation_SizeChanged(menuNavigation, EventArgs.Empty);
        if (!DesignMode && System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
        {
            ClockTimer_Tick(this, EventArgs.Empty);
            clockTimer.Start();
        }
    }

    private void MenuNavigation_SizeChanged(object? sender, EventArgs e)
    {
        if (sender is ToolStrip menu && menu.ClientSize.Width > 0 && menu.Items.Count > 0)
        {
            int itemHeight = menu.ClientSize.Height / menu.Items.Count;
            menu.SuspendLayout();
            foreach (ToolStripItem item in menu.Items)
            {
                item.Size = new Size(menu.ClientSize.Width, itemHeight);
            }

            menu.ResumeLayout();
            ToolStripButton selectedItem = memberListView.Visible || memberDetailsView.Visible
                || memberEditView.Visible || memberRegistrationView.Visible
                ? navMembers
                : shiftManagementView.Visible || shiftHandoverView.Visible ? navShifts
                : navTicketSales;
            pnlNavStripe.SetBounds(0, selectedItem.Bounds.Top, pnlRail.Width, itemHeight);
        }
    }

    private void ClockTimer_Tick(object? sender, EventArgs e)
    {
        lblClock.Text = DateTime.Now.ToString("HH:mm");
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        return saleCompletionView.HandleShortcut(keyData) || paymentView.HandleShortcut(keyData) ||
            (keyData == Keys.F2 && seatSelectionView.TryContinue()) ||
            memberListView.HandleShortcut(keyData) ||
            base.ProcessCmdKey(ref msg, keyData);
    }

    private void ShowtimeSelectionView_ShowtimeSelected(object? sender, ShowtimeSelectedEventArgs e)
    {
        seatSelectionView.ShowFor(e, []);
        ShowSeatSelection();
    }

    private void ShowSeatSelection()
    {
        paymentView.Hide();
        concessionSelectionView.Hide();
        showtimeSelectionView.Hide();
        seatSelectionView.Show();
        seatSelectionView.Select();
    }

    private void ShowConcessionSelection(SeatSelectionContext selection)
    {
        concessionSelectionView.ShowFor(selection, []);
        seatSelectionView.Hide();
        concessionSelectionView.Show();
        concessionSelectionView.Select();
    }

    private void ShowShowtimeSelection()
    {
        saleCompletionView.Hide();
        paymentView.Hide();
        concessionSelectionView.Hide();
        seatSelectionView.Hide();
        saleCompletionView.ClearSale();
        paymentView.ClearDraft();
        concessionSelectionView.ClearDraft();
        seatSelectionView.ClearDraft();
        showtimeSelectionView.ClearSelection();
        showtimeSelectionView.Show();
        showtimeSelectionView.Select();
    }

    private void ShowPayment(PaymentOrder order)
    {
        paymentView.ShowFor(order);
        concessionSelectionView.Hide();
        paymentView.Show();
        paymentView.Select();
    }

    private void ReturnToConcessionSelection()
    {
        paymentView.Hide();
        concessionSelectionView.Show();
        concessionSelectionView.Select();
    }

    private void ShowSaleCompletion(CompletedSale sale)
    {
        paymentView.Hide();
        saleCompletionView.ShowFor(sale);
        saleCompletionView.Show();
        saleCompletionView.FocusNewSale();
    }

    private void NavTicketSales_Click(object? sender, EventArgs e)
    {
        if (pnlTicketSales.Visible)
        {
            ShowShowtimeSelection();
            return;
        }

        memberRegistrationView.Hide();
        memberEditView.Hide();
        memberDetailsView.Hide();
        memberListView.Hide();
        shiftHandoverView.Hide();
        shiftManagementView.Hide();
        pnlTicketSales.Show();
        lblOperator.Text = string.Empty;
        SelectNavigationItem(navTicketSales);
    }

    private void NavMembers_Click(object? sender, EventArgs e) => ShowMemberList();

    private void ShowMemberList()
    {
        pnlTicketSales.Hide();
        shiftHandoverView.Hide();
        shiftManagementView.Hide();
        memberRegistrationView.Hide();
        memberEditView.Hide();
        memberDetailsView.Hide();
        memberListView.Show();
        lblOperator.Text = PreviewOperator;
        SelectNavigationItem(navMembers);
    }

    private void ShowMemberRegistration()
    {
        memberRegistrationView.ResetDraft();
        memberListView.Hide();
        memberRegistrationView.Show();
    }

    private void ShowMemberDetails(MemberListEntry member)
    {
        memberDetailsView.ShowFor(member);
        memberListView.Hide();
        memberDetailsView.Show();
    }

    private void ShowMemberEdit(MemberListEntry member, Control sourceView)
    {
        memberPageBeforeEdit = sourceView;
        memberEditView.ShowFor(member);
        sourceView.Hide();
        memberEditView.Show();
        memberEditView.FocusName();
    }

    private void CloseMemberEdit()
    {
        memberEditView.Hide();
        memberPageBeforeEdit?.Show();
        memberPageBeforeEdit = null;
    }

    private void NavShifts_Click(object? sender, EventArgs e) => ShowShiftOverview();

    private void ShowShiftOverview()
    {
        pnlTicketSales.Hide();
        memberRegistrationView.Hide();
        memberEditView.Hide();
        memberDetailsView.Hide();
        memberListView.Hide();
        shiftHandoverView.Hide();
        shiftManagementView.Show();
        lblOperator.Text = PreviewOperator;
        SelectNavigationItem(navShifts);
    }

    private void ShowShiftHandover()
    {
        shiftManagementView.Hide();
        shiftHandoverView.Show();
    }

    private void SelectNavigationItem(ToolStripButton selectedItem)
    {
        Color selectedColor = Color.FromArgb(51, 65, 85);
        navTicketSales.BackColor = selectedItem == navTicketSales ? selectedColor : Color.Empty;
        navMembers.BackColor = selectedItem == navMembers ? selectedColor : Color.Empty;
        navShifts.BackColor = selectedItem == navShifts ? selectedColor : Color.Empty;
        pnlNavStripe.SetBounds(0, selectedItem.Bounds.Top, pnlRail.Width, selectedItem.Bounds.Height);
    }

    private void lblOperator_Click(object sender, EventArgs e)
    {

    }
}

internal sealed class PosNavigationRenderer : ToolStripSystemRenderer
{
    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        // The navigation and its rail share one continuous background.
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        if (!e.Item.Enabled)
        {
            TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle,
                Color.FromArgb(148, 163, 184), e.TextFormat);
            return;
        }

        base.OnRenderItemText(e);
    }
}

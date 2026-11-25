using Cinema.WinForms.Features.Members;
using Cinema.WinForms.Features.Orders;
using Cinema.WinForms.Features.TicketSales;

namespace Cinema.WinForms.Forms;

public partial class MainForm : Form
{
    private const string PreviewOperator = "Nguyễn Văn A · POS-01";

    private Control? memberPageBeforeEdit;
    private Control? checkInPageBeforeHistory;
    private Control activeTicketSalesView;

    public MainForm()
    {
        InitializeComponent();
        activeTicketSalesView = showtimeSelectionView;
        menuNavigation.Renderer = new PosNavigationRenderer();
        showtimeSelectionView.SetMovies([]);
        showtimeSelectionView.ShowtimeSelected += ShowtimeSelectionView_ShowtimeSelected;
        seatSelectionView.BackRequested += (_, _) => ShowShowtimeSelection();
        seatSelectionView.ContinueRequested += ShowConcessionSelection;
        concessionSelectionView.BackRequested += (_, _) => ShowSeatSelection();
        concessionSelectionView.ContinueRequested += ShowPayment;
        paymentView.BackRequested += (_, _) => ShowTicketSalesView(concessionSelectionView);
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
        orderListView.DetailsRequested += ShowOrderDetails;
        orderDetailsView.BackRequested += (_, _) => ShowOrderList();
        orderDetailsView.RefundRequested += ShowRefundRequest;
        refundRequestView.BackRequested += (_, _) => ReturnToOrderDetails();
        checkInSessionView.ScannerRequested += (_, _) => ShowTicketScanner();
        ticketScannerView.ChangeSessionRequested += (_, _) => ShowCheckInSessions();
        ticketScannerView.CheckRequested += (_, _) => ShowTicketScanResult();
        ticketScannerView.HistoryRequested += (_, _) => ShowCheckInHistory(ticketScannerView);
        ticketScanResultView.ChangeSessionRequested += (_, _) => ShowCheckInSessions();
        ticketScanResultView.BackRequested += (_, _) => ShowTicketScanner();
        ticketScanResultView.HistoryRequested += (_, _) => ShowCheckInHistory(ticketScanResultView);
        checkInHistoryView.BackRequested += (_, _) => CloseCheckInHistory();
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
            ToolStripButton selectedItem = checkInSessionView.Visible || ticketScannerView.Visible
                || ticketScanResultView.Visible || checkInHistoryView.Visible
                ? navTicketCheck
                : orderListView.Visible || orderDetailsView.Visible || refundRequestView.Visible
                ? navInvoices
                : memberListView.Visible || memberDetailsView.Visible
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
            ticketScannerView.HandleHistoryShortcut(keyData) || ticketScanResultView.HandleHistoryShortcut(keyData) ||
            base.ProcessCmdKey(ref msg, keyData);
    }

    private void ShowtimeSelectionView_ShowtimeSelected(object? sender, ShowtimeSelectedEventArgs e)
    {
        seatSelectionView.ShowFor(e, []);
        ShowSeatSelection();
    }

    private void ShowSeatSelection() => ShowTicketSalesView(seatSelectionView);

    private void ShowConcessionSelection(SeatSelectionContext selection)
    {
        concessionSelectionView.ShowFor(selection, []);
        ShowTicketSalesView(concessionSelectionView);
    }

    private void ShowShowtimeSelection()
    {
        activeTicketSalesView.Hide();
        saleCompletionView.ClearSale();
        paymentView.ClearDraft();
        concessionSelectionView.ClearDraft();
        seatSelectionView.ClearDraft();
        showtimeSelectionView.ClearSelection();
        ShowTicketSalesView(showtimeSelectionView);
    }

    private void ShowPayment(PaymentOrder order)
    {
        paymentView.ShowFor(order);
        ShowTicketSalesView(paymentView);
    }

    private void ShowSaleCompletion(CompletedSale sale)
    {
        saleCompletionView.ShowFor(sale);
        ShowTicketSalesView(saleCompletionView);
        saleCompletionView.FocusNewSale();
    }

    private void ShowTicketSalesView(Control view)
    {
        if (activeTicketSalesView != view)
        {
            activeTicketSalesView.Hide();
            activeTicketSalesView = view;
        }

        view.Show();
        view.Select();
    }

    private void NavTicketSales_Click(object? sender, EventArgs e)
    {
        if (activeTicketSalesView.Visible)
        {
            ShowShowtimeSelection();
            return;
        }

        HideCheckInViews();
        HideOrderViews();
        HideMemberViews();
        shiftHandoverView.Hide();
        shiftManagementView.Hide();
        activeTicketSalesView.Show();
        lblOperator.Text = string.Empty;
        SelectNavigationItem(navTicketSales);
    }

    private void NavTicketCheck_Click(object? sender, EventArgs e) => ShowCheckInSessions();

    private void ShowCheckInSessions()
    {
        activeTicketSalesView.Hide();
        HideOrderViews();
        HideMemberViews();
        shiftHandoverView.Hide();
        shiftManagementView.Hide();
        ticketScannerView.Hide();
        ticketScanResultView.Hide();
        checkInHistoryView.Hide();
        checkInPageBeforeHistory = null;
        checkInSessionView.Show();
        lblOperator.Text = PreviewOperator;
        SelectNavigationItem(navTicketCheck);
    }

    private void ShowTicketScanner()
    {
        checkInSessionView.Hide();
        ticketScanResultView.Hide();
        ticketScannerView.ResetInput();
        ticketScannerView.Show();
    }

    private void ShowTicketScanResult()
    {
        ticketScannerView.Hide();
        ticketScanResultView.ShowResult();
        ticketScanResultView.Show();
    }

    private void ShowCheckInHistory(Control sourceView)
    {
        checkInPageBeforeHistory = sourceView;
        checkInHistoryView.ShowFrom(sourceView == ticketScanResultView);
        sourceView.Hide();
        checkInHistoryView.Show();
    }

    private void CloseCheckInHistory()
    {
        checkInHistoryView.Hide();
        checkInPageBeforeHistory?.Show();
        checkInPageBeforeHistory = null;
    }

    private void HideCheckInViews()
    {
        checkInSessionView.Hide();
        ticketScannerView.Hide();
        ticketScanResultView.Hide();
        checkInHistoryView.Hide();
        checkInPageBeforeHistory = null;
    }

    private void NavMembers_Click(object? sender, EventArgs e) => ShowMemberList();

    private void ShowMemberList()
    {
        activeTicketSalesView.Hide();
        HideCheckInViews();
        HideOrderViews();
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

    private void HideMemberViews()
    {
        memberRegistrationView.Hide();
        memberEditView.Hide();
        memberDetailsView.Hide();
        memberListView.Hide();
    }

    private void HideOrderViews()
    {
        refundRequestView.Hide();
        orderDetailsView.Hide();
        orderListView.Hide();
    }

    private void NavInvoices_Click(object? sender, EventArgs e) => ShowOrderList();

    private void ShowOrderList()
    {
        activeTicketSalesView.Hide();
        HideCheckInViews();
        shiftHandoverView.Hide();
        shiftManagementView.Hide();
        HideMemberViews();
        refundRequestView.Hide();
        orderDetailsView.Hide();
        orderListView.Show();
        lblOperator.Text = PreviewOperator;
        SelectNavigationItem(navInvoices);
    }

    private void ShowOrderDetails(OrderListEntry order)
    {
        orderDetailsView.ShowFor(order);
        orderListView.Hide();
        orderDetailsView.Show();
    }

    private void ShowRefundRequest(OrderListEntry order)
    {
        refundRequestView.ShowFor(order.Code, order.Amount, order.Payment);
        orderDetailsView.Hide();
        refundRequestView.Show();
    }

    private void ReturnToOrderDetails()
    {
        refundRequestView.Hide();
        orderDetailsView.Show();
    }

    private void NavShifts_Click(object? sender, EventArgs e) => ShowShiftOverview();

    private void ShowShiftOverview()
    {
        activeTicketSalesView.Hide();
        HideCheckInViews();
        HideOrderViews();
        HideMemberViews();
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
        navTicketCheck.BackColor = selectedItem == navTicketCheck ? selectedColor : Color.Empty;
        navMembers.BackColor = selectedItem == navMembers ? selectedColor : Color.Empty;
        navInvoices.BackColor = selectedItem == navInvoices ? selectedColor : Color.Empty;
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

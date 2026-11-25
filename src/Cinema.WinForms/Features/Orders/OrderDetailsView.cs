namespace Cinema.WinForms.Features.Orders;

public partial class OrderDetailsView : UserControl
{
    private OrderListEntry? currentOrder;

    public OrderDetailsView()
    {
        InitializeComponent();
    }

    internal event EventHandler? BackRequested;
    internal event Action<OrderListEntry>? RefundRequested;

    internal void ShowFor(OrderListEntry order)
    {
        currentOrder = order;
        bool hasSampleDetails = order.Code == "INV-20261118-042";
        bool cancelled = order.Status == "Đã hủy";
        lblTitle.Text = $"Chi tiết hóa đơn #{order.Code}";
        lblStatus.Text = order.Status;
        lblStatus.BackColor = cancelled ? Color.FromArgb(254, 226, 226) : Color.FromArgb(220, 252, 231);
        lblStatus.ForeColor = cancelled ? Color.FromArgb(185, 28, 28) : Color.FromArgb(22, 101, 52);

        pnlTicketGrid.Visible = pnlConcessionGrid.Visible = layoutShowtimeNote.Visible = hasSampleDetails;
        lblTicketSummary.Visible = lblConcessionSummary.Visible = !hasSampleDetails;
        lblTicketSummary.Text = $"Nội dung hóa đơn: {order.Summary.Replace('\n', ' ')}";
        lblStaffValue.Text = hasSampleDetails ? "Nguyễn Minh Anh" : "—";
        lblTerminalValue.Text = hasSampleDetails ? "POS-01" : "—";
        lblCreatedValue.Text = order.Created;
        lblCustomerValue.Text = order.Customer;
        lblCustomerCaption.Text = order.Customer.Contains('\n') ? "Thành viên" : "Khách hàng";

        lblSubtotalValue.Text = hasSampleDetails ? order.Amount : "—";
        lblDiscountValue.Text = hasSampleDetails ? "0 đ" : "—";
        lblTotalCaption.Text = cancelled ? "Tổng tiền hóa đơn" : "Tổng đã thanh toán";
        lblTotalValue.Text = order.Amount;
        layoutTotalInfo.BackColor = cancelled ? Color.FromArgb(241, 245, 249) : Color.FromArgb(220, 252, 231);
        lblTotalCaption.ForeColor = lblTotalValue.ForeColor = cancelled ? ForeColor : Color.FromArgb(22, 101, 52);
        lblMethodValue.Text = order.Payment;
        lblTenderedValue.Text = hasSampleDetails ? "350.000 đ" : "—";
        lblChangeValue.Text = hasSampleDetails ? "31.000 đ" : "—";
        btnPrintTickets.Enabled = btnRefund.Enabled = hasSampleDetails && !cancelled;
        btnPrintInvoice.Enabled = hasSampleDetails;
        Color primary = Color.FromArgb(37, 99, 235);
        Color border = Color.FromArgb(226, 232, 240);
        btnPrintTickets.FlatAppearance.BorderColor = btnPrintTickets.Enabled ? primary : border;
        btnPrintInvoice.FlatAppearance.BorderColor = btnPrintInvoice.Enabled ? primary : border;
        btnRefund.BackColor = btnRefund.Enabled ? Color.FromArgb(185, 28, 28) : border;
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
        Size minimumSize = LogicalToDeviceUnits(new Size(848, 536));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }

    private void LnkBack_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
        BackRequested?.Invoke(this, EventArgs.Empty);

    private void BtnRefund_Click(object? sender, EventArgs e)
    {
        if (currentOrder is { } order)
        {
            RefundRequested?.Invoke(order);
        }
    }
}

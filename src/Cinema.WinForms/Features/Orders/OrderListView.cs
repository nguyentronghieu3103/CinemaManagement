namespace Cinema.WinForms.Features.Orders;

public partial class OrderListView : UserControl
{
    public OrderListView()
    {
        InitializeComponent();
        cmbPaymentFilter.SelectedIndex = 0;
        cmbStatusFilter.SelectedIndex = 0;
        BindDetails(btnDetails1, lblCode1, lblCreated1, lblCustomer1, lblSummary1, lblAmount1, lblPayment1, lblStatus1);
        BindDetails(btnDetails2, lblCode2, lblCreated2, lblCustomer2, lblSummary2, lblAmount2, lblPayment2, lblStatus2);
        BindDetails(btnDetails3, lblCode3, lblCreated3, lblCustomer3, lblSummary3, lblAmount3, lblPayment3, lblStatus3);
        BindDetails(btnDetails4, lblCode4, lblCreated4, lblCustomer4, lblSummary4, lblAmount4, lblPayment4, lblStatus4);
        BindDetails(btnDetails5, lblCode5, lblCreated5, lblCustomer5, lblSummary5, lblAmount5, lblPayment5, lblStatus5);
        BindDetails(btnDetails6, lblCode6, lblCreated6, lblCustomer6, lblSummary6, lblAmount6, lblPayment6, lblStatus6);
    }

    internal event Action<OrderListEntry>? DetailsRequested;

    private void BindDetails(
        Button button, Label code, Label created, Label customer, Label summary, Label amount, Label payment, Label status)
    {
        button.Click += (_, _) => DetailsRequested?.Invoke(
            new OrderListEntry(code.Text, created.Text, customer.Text, summary.Text, amount.Text, payment.Text, status.Text));
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
        Size minimumSize = LogicalToDeviceUnits(new Size(836, 488));
        layoutPage.MinimumSize = minimumSize;
        pnlViewport.AutoScrollMinSize = minimumSize;
    }
}

internal sealed record OrderListEntry(
    string Code, string Created, string Customer, string Summary, string Amount, string Payment, string Status);

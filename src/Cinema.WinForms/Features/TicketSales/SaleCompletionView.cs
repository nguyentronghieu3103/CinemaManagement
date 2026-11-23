using System.ComponentModel;
using Cinema.WinForms.Controls;
using Cinema.WinForms.Reporting;

namespace Cinema.WinForms.Features.TicketSales;

public partial class SaleCompletionView : UserControl
{
    private const int TicketsPerPage = 2;
    private CompletedSale? sale;
    private int firstTicketIndex;

    public SaleCompletionView()
    {
        InitializeComponent();
        firstTicket.PrintRequested += (_, _) => PrintTicket(firstTicketIndex);
        secondTicket.PrintRequested += (_, _) => PrintTicket(firstTicketIndex + 1);
        pnlTicketScroll.ClientSizeChanged += PreviewSizeChanged;
        pnlReceiptScroll.ClientSizeChanged += PreviewSizeChanged;
        flowTickets.SizeChanged += PreviewSizeChanged;
        layoutReceiptPaper.SizeChanged += PreviewSizeChanged;
    }

    internal event EventHandler? NewSaleRequested;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (sale is null && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            ClearSale();
        }
    }

    internal void ShowFor(CompletedSale completedSale)
    {
        sale = completedSale;
        firstTicketIndex = 0;
        lblStatusTitle.Text = "THANH TOÁN THÀNH CÔNG";
        lblStatusTitle.ForeColor = Color.FromArgb(22, 101, 52);
        layoutStatus.BackColor = Color.FromArgb(240, 253, 244);
        lblDemo.Visible = lblStatusIcon.Visible = true;
        lblTicketCount.Text = $"VÉ XEM PHIM · {completedSale.Tickets.Count} vé";
        btnPrintAll.Text = $"In tất cả vé ({completedSale.Tickets.Count})";
        btnPrintAll.Enabled = completedSale.Tickets.Count > 0;
        btnPrintInvoice.Enabled = btnNewSale.Enabled = true;

        lblInvoiceInfo.Text = $"Mã hóa đơn: {completedSale.InvoiceCode}\n" +
            $"Thời gian: {completedSale.PaidAt:dd/MM/yyyy HH:mm}\n" +
            $"Nhân viên: {completedSale.OperatorName}\n" +
            $"Quầy: {completedSale.TerminalName}";
        lblTotal.Text = AuditoriumSeat.FormatPrice(completedSale.Order.Total);
        lblReceiptPayment.Text = string.Join("\n", completedSale.GetPaymentDetails());
        layoutReceiptPaper.Visible = true;
        lblNoReceipt.Visible = false;
        pnlReceiptScroll.AutoScrollPosition = Point.Empty;
        RenderReceiptLines(completedSale.Order.Lines);
        RenderTicketPage();
    }

    internal void ClearSale()
    {
        sale = null;
        firstTicketIndex = 0;
        lblStatusTitle.Text = "Chưa có giao dịch hoàn tất";
        lblStatusTitle.ForeColor = Color.FromArgb(100, 116, 139);
        layoutStatus.BackColor = Color.White;
        lblDemo.Visible = lblStatusIcon.Visible = false;
        lblTicketCount.Text = "VÉ XEM PHIM";
        btnPrintAll.Text = "In tất cả vé (Ctrl+P)";
        btnPrintAll.Enabled = btnPrintInvoice.Enabled = btnNewSale.Enabled = false;
        lblInvoiceInfo.Text = lblTotal.Text = lblReceiptPayment.Text = string.Empty;
        layoutReceiptPaper.Visible = false;
        lblNoReceipt.Visible = true;
        RenderReceiptLines([]);
        RenderTicketPage();
    }

    internal void FocusNewSale() => btnNewSale.Select();

    internal bool HandleShortcut(Keys keyData)
    {
        if (!Visible || sale is null)
        {
            return false;
        }

        switch (keyData)
        {
            case Keys.Control | Keys.P:
                PrintAll();
                return true;
            case Keys.Enter:
                NewSaleRequested?.Invoke(this, EventArgs.Empty);
                return true;
            default:
                return false;
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) =>
        HandleShortcut(keyData) || base.ProcessCmdKey(ref msg, keyData);

    private void RenderTicketPage()
    {
        int count = sale?.Tickets.Count ?? 0;
        ShowTicket(firstTicket, firstTicketIndex);
        ShowTicket(secondTicket, firstTicketIndex + 1);
        bool needsPaging = count > TicketsPerPage;
        layoutTicketFrame.RowStyles[3].Height = needsPaging || count == 0 ? LogicalToDeviceUnits(46) : 0;
        layoutPaging.Visible = needsPaging || count == 0;
        btnPrevious.Visible = btnNext.Visible = needsPaging;
        btnPrevious.Enabled = firstTicketIndex > 0;
        btnNext.Enabled = firstTicketIndex + TicketsPerPage < count;
        int first = firstTicketIndex + 1;
        int last = Math.Min(firstTicketIndex + TicketsPerPage, count);
        lblPage.Text = count <= TicketsPerPage
            ? count == 0 ? "Chưa có vé" : $"{count} vé"
            : $"Vé {(first == last ? first.ToString() : $"{first}–{last}")} / {count}";
        pnlTicketScroll.AutoScrollPosition = Point.Empty;
        flowTickets.PerformLayout();
        CenterPreview(pnlTicketScroll, flowTickets, 0);
    }

    private void ShowTicket(SaleTicketCard card, int index)
    {
        if (sale is { } current && index < current.Tickets.Count)
        {
            card.ShowTicket(current.Order.Selection.Showtime, current.Tickets[index]);
            card.Visible = true;
            return;
        }

        card.Visible = false;
        card.ClearTicket();
    }

    private void RenderReceiptLines(IReadOnlyList<PaymentOrderLine> lines)
    {
        layoutReceiptLines.SuspendLayout();
        try
        {
            while (layoutReceiptLines.Controls.Count > 0)
            {
                layoutReceiptLines.Controls[0].Dispose();
            }

            layoutReceiptLines.RowStyles.Clear();
            layoutReceiptLines.RowCount = lines.Count;
            for (int row = 0; row < lines.Count; row++)
            {
                PaymentOrderLine line = lines[row];
                layoutReceiptLines.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                layoutReceiptLines.Controls.Add(ReceiptLabel($"{line.Description} × {line.Quantity}", ContentAlignment.MiddleLeft), 0, row);
                layoutReceiptLines.Controls.Add(ReceiptLabel(AuditoriumSeat.FormatPrice(line.Amount), ContentAlignment.MiddleRight), 1, row);
            }
        }
        finally
        {
            layoutReceiptLines.ResumeLayout(true);
        }
    }

    private static Label ReceiptLabel(string text, ContentAlignment alignment) => new()
    {
        AutoSize = true,
        Dock = DockStyle.Fill,
        Margin = new Padding(2, 4, 2, 4),
        Text = text,
        TextAlign = alignment,
        UseMnemonic = false
    };

    private static void CenterPreview(Panel viewport, Control preview, int topMargin)
    {
        Point offset = viewport.AutoScrollPosition;
        int x = Math.Max(4, (viewport.ClientSize.Width - preview.Width) / 2);
        int y = Math.Max(topMargin, (viewport.ClientSize.Height - preview.Height) / 2);
        preview.Location = new Point(x + offset.X, y + offset.Y);
    }

    private void PreviewSizeChanged(object? sender, EventArgs e)
    {
        CenterPreview(pnlTicketScroll, flowTickets, 0);
        CenterPreview(pnlReceiptScroll, layoutReceiptPaper, LogicalToDeviceUnits(8));
    }

    private void PrintTicket(int index)
    {
        if (sale is { } current && index < current.Tickets.Count)
        {
            IssuedTicket ticket = current.Tickets[index];
            MessageBox.Show(this, $"Đã chọn vé {ticket.Code} (ghế {ticket.Seat.Code}) để in.",
                "In vé mô phỏng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void PrintAll()
    {
        if (sale is { Tickets.Count: > 0 } current)
        {
            SalePrintPreview.ShowTickets(this, current);
        }
    }

    private void BtnPrintInvoice_Click(object? sender, EventArgs e)
    {
        if (sale is { } current)
        {
            SalePrintPreview.ShowInvoice(this, current);
        }
    }

    private void BtnPrevious_Click(object? sender, EventArgs e)
    {
        if (firstTicketIndex >= TicketsPerPage)
        {
            firstTicketIndex -= TicketsPerPage;
            RenderTicketPage();
        }
    }

    private void BtnNext_Click(object? sender, EventArgs e)
    {
        if (sale is { } current && firstTicketIndex + TicketsPerPage < current.Tickets.Count)
        {
            firstTicketIndex += TicketsPerPage;
            RenderTicketPage();
        }
    }

    private void BtnPrintAll_Click(object? sender, EventArgs e) => PrintAll();
    private void BtnNewSale_Click(object? sender, EventArgs e) => NewSaleRequested?.Invoke(this, EventArgs.Empty);
}

internal enum PaymentMethod
{
    Cash,
    BankQr
}

internal sealed record IssuedTicket(string Code, AuditoriumSeat Seat);

internal sealed class CompletedSale
{
    internal CompletedSale(PaymentOrder order, PaymentMethod method, decimal? cashTendered,
        string? operatorName, string? terminalName)
    {
        Order = order;
        Method = method;
        CashTendered = cashTendered;
        OperatorName = string.IsNullOrWhiteSpace(operatorName) ? "—" : operatorName;
        TerminalName = string.IsNullOrWhiteSpace(terminalName) ? "—" : terminalName;
        PaidAt = DateTimeOffset.Now;
        InvoiceCode = $"HD-{Guid.NewGuid().ToString("N")[..12].ToUpperInvariant()}";
        Tickets = order.Selection.Seats
            .OrderBy(seat => seat.Row)
            .ThenBy(seat => seat.Column)
            .Select(seat => new IssuedTicket($"VE-{InvoiceCode[3..]}-{seat.Code}", seat))
            .ToArray();
    }

    internal PaymentOrder Order { get; }
    internal PaymentMethod Method { get; }
    internal decimal? CashTendered { get; }
    internal decimal? CashChange => CashTendered - Order.Total;
    internal string OperatorName { get; }
    internal string TerminalName { get; }
    internal DateTimeOffset PaidAt { get; }
    internal string InvoiceCode { get; }
    internal IReadOnlyList<IssuedTicket> Tickets { get; }
    internal string PaymentCaption => Method == PaymentMethod.Cash ? "Tiền mặt" : "QR ngân hàng";

    internal IEnumerable<string> GetPaymentDetails()
    {
        yield return $"Phương thức: {PaymentCaption}";
        if (CashTendered is decimal tendered && CashChange is decimal change)
        {
            yield return $"Tiền khách đưa: {AuditoriumSeat.FormatPrice(tendered)}";
            yield return $"Tiền thừa: {AuditoriumSeat.FormatPrice(change)}";
        }
    }
}

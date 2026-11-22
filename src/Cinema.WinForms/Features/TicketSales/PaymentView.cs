using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

public partial class PaymentView : UserControl
{
    private static readonly Color Accent = Color.FromArgb(37, 99, 235);
    private static readonly Color Ink = Color.FromArgb(15, 23, 42);
    private static readonly Color Muted = Color.FromArgb(100, 116, 139);
    private static readonly Color Warning = Color.FromArgb(146, 64, 14);
    private static readonly Color Success = Color.FromArgb(21, 128, 61);
    private static readonly Regex CashFormat = new(@"\A(?:[0-9]+|[0-9]{1,3}(?:\.[0-9]{3})+)\z");
    private PaymentOrder? order;
    private PaymentMethod method;
    private bool confirmed;
    private string? operatorName;
    private string? terminalName;

    public PaymentView()
    {
        InitializeComponent();
        gridOrder.DefaultCellStyle.FormatProvider = AuditoriumSeat.MoneyCulture;
    }

    internal event EventHandler? BackRequested;
    internal event Action<CompletedSale>? PaymentConfirmed;

    internal void ShowFor(PaymentOrder paymentOrder, string? operatorName = null, string? terminalName = null)
    {
        order = paymentOrder;
        this.operatorName = operatorName;
        this.terminalName = terminalName;
        confirmed = false;
        chkQrVerified.Checked = false;
        txtPhone.Clear();
        ClearMember();
        txtCash.Clear();

        SeatSelectionContext selection = paymentOrder.Selection;
        ShowtimeOption showtime = selection.Showtime.Showtime;
        lblMovie.Text = selection.Showtime.MovieTitle;
        lblShowtime.Text = $"{SeatSelectionContext.RoomCaption(showtime.Room)}  ·  {showtime.Format}  ·  {showtime.StartsAt:dd/MM/yyyy HH:mm}";
        lblSeats.Text = $"Ghế {string.Join(", ", selection.Seats.Select(seat => seat.Code))}";
        orderBindingSource.DataSource = paymentOrder.Lines;
        gridOrder.AutoGenerateColumns = false;
        gridOrder.DataSource = orderBindingSource;
        lblTotal.Text = lblQrAmount.Text = AuditoriumSeat.FormatPrice(paymentOrder.Total);

        SelectMethod(qr: false);
    }

    internal void ClearDraft()
    {
        if (order is null)
        {
            return;
        }

        order = null;
        operatorName = terminalName = null;
        confirmed = false;
        orderBindingSource.DataSource = null;
        txtPhone.Clear();
        ClearMember();
        txtCash.Clear();
        chkQrVerified.Checked = false;
        lblMovie.Text = lblShowtime.Text = lblSeats.Text = string.Empty;
        lblTotal.Text = lblCashBalance.Text = lblQrAmount.Text = "—";
        lblCashStatus.Text = "Chưa có đơn hàng";
        SelectMethod(qr: false);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) =>
        HandleShortcut(keyData) || base.ProcessCmdKey(ref msg, keyData);

    internal bool HandleShortcut(Keys keyData)
    {
        if (!Visible)
        {
            return false;
        }

        switch (keyData)
        {
            case Keys.F1:
                SelectMethod(qr: false);
                txtCash.Focus();
                return true;
            case Keys.F2:
                SelectMethod(qr: true);
                (chkQrVerified.Enabled ? (Control)chkQrVerified : btnQr).Focus();
                return true;
            case Keys.F12:
                ConfirmPayment();
                return true;
            default:
                return false;
        }
    }

    private void SelectMethod(bool qr)
    {
        method = qr ? PaymentMethod.BankQr : PaymentMethod.Cash;
        if (!qr)
        {
            chkQrVerified.Checked = false;
        }

        layoutCash.Visible = !qr;
        layoutQr.Visible = qr;
        StyleMethod(btnCash, !qr);
        StyleMethod(btnQr, qr);
        RefreshPayment();
    }

    private static void StyleMethod(Button button, bool selected)
    {
        button.BackColor = selected ? Accent : Color.White;
        button.ForeColor = selected ? Color.White : Ink;
        button.FlatAppearance.BorderColor = selected ? Accent : Color.FromArgb(203, 213, 225);
        button.FlatAppearance.MouseOverBackColor = selected ? Color.FromArgb(29, 78, 216) : Color.FromArgb(239, 246, 255);
    }

    private void RefreshPayment()
    {
        bool canPay = !confirmed && order is { Selection.Seats.Count: > 0 };
        chkQrVerified.Enabled = canPay;
        lblQrStatus.Text = chkQrVerified.Checked ? "Đã xác nhận chuyển khoản mô phỏng" : "Chờ nhân viên xác nhận";
        if (order is null)
        {
            btnConfirm.Enabled = false;
            return;
        }

        bool valid = TryReadCash(out decimal tendered);
        decimal balance = tendered - order.Total;
        bool enoughCash = valid && balance >= 0;
        lblCashStatus.Text = !valid ? "Tiền khách đưa phải là số nguyên VNĐ" :
            enoughCash ? "Tiền thừa trả khách" : "Còn thiếu";
        lblCashBalance.Text = valid ? AuditoriumSeat.FormatPrice(Math.Abs(balance)) : "—";
        lblCashBalance.ForeColor = enoughCash ? Success : Warning;
        layoutCashBalance.BackColor = enoughCash ? Color.FromArgb(240, 253, 244) : Color.FromArgb(255, 251, 235);
        btnConfirm.Enabled = canPay && (method == PaymentMethod.Cash ? enoughCash : chkQrVerified.Checked);
        btnConfirm.BackColor = btnConfirm.Enabled ? Accent : Color.FromArgb(226, 232, 240);
        btnConfirm.ForeColor = btnConfirm.Enabled ? Color.White : Muted;
        btnConfirm.FlatAppearance.BorderColor = btnConfirm.BackColor;
    }

    private void ConfirmPayment()
    {
        RefreshPayment();
        if (order is not { } paymentOrder || !btnConfirm.Enabled)
        {
            return;
        }

        TryReadCash(out decimal tendered);
        var sale = new CompletedSale(paymentOrder, method, method == PaymentMethod.Cash ? tendered : null,
            operatorName, terminalName);
        confirmed = true;
        RefreshPayment();
        PaymentConfirmed?.Invoke(sale);
    }

    private bool TryReadCash(out decimal value)
    {
        string input = txtCash.Text.Trim();
        value = 0;
        return input.Length == 0 || (CashFormat.IsMatch(input) &&
            decimal.TryParse(input, NumberStyles.AllowThousands, AuditoriumSeat.MoneyCulture, out value));
    }

    private void SetCash(decimal value) => txtCash.Text = value.ToString("N0", AuditoriumSeat.MoneyCulture);

    private void ClearMember()
    {
        memberErrors.SetError(txtPhone, string.Empty);
        layoutMemberResult.Visible = false;
        lblMemberStatus.Visible = true;
        lblMemberStatus.Text = "Khách lẻ";
        lblMemberStatus.ForeColor = Muted;
    }

    private string NormalizedPhone() => txtPhone.Text.Replace(" ", string.Empty, StringComparison.Ordinal).Trim();

    private void TxtPhone_Validating(object? sender, CancelEventArgs e)
    {
        string phone = NormalizedPhone();
        e.Cancel = phone.Length != 10 || phone[0] != '0' || !phone.All(char.IsAsciiDigit);
        memberErrors.SetError(txtPhone, e.Cancel ? "Nhập số điện thoại 10 chữ số, bắt đầu bằng 0." : string.Empty);
    }

    private void FindMember()
    {
        ClearMember();
        if (!ValidateChildren())
        {
            lblMemberStatus.Text = memberErrors.GetError(txtPhone);
            lblMemberStatus.ForeColor = Warning;
            return;
        }

        lblMemberStatus.Text = "Chức năng tra cứu thành viên chưa được kết nối.";
        lblMemberStatus.ForeColor = Warning;
    }

    private void TxtPhone_TextChanged(object? sender, EventArgs e) => ClearMember();

    private void TxtPhone_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            FindMember();
        }
    }

    private void BtnFindMember_Click(object? sender, EventArgs e) => FindMember();
    private void GridOrder_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => gridOrder.ClearSelection();
    private void BtnCash_Click(object? sender, EventArgs e) => SelectMethod(qr: false);
    private void BtnQr_Click(object? sender, EventArgs e) => SelectMethod(qr: true);
    private void TxtCash_TextChanged(object? sender, EventArgs e) => RefreshPayment();

    private void TxtCash_Leave(object? sender, EventArgs e)
    {
        if (txtCash.TextLength > 0 && TryReadCash(out decimal value))
        {
            SetCash(value);
        }
    }

    private void BtnCash100_Click(object? sender, EventArgs e) => SetCash(100_000m);
    private void BtnCash200_Click(object? sender, EventArgs e) => SetCash(200_000m);
    private void BtnCash500_Click(object? sender, EventArgs e) => SetCash(500_000m);
    private void BtnExactCash_Click(object? sender, EventArgs e) => SetCash(order?.Total ?? 0);
    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);
    private void BtnConfirm_Click(object? sender, EventArgs e) => ConfirmPayment();
    private void ChkQrVerified_CheckedChanged(object? sender, EventArgs e) => RefreshPayment();
}

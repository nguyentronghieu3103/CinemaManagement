namespace Cinema.WinForms.Features.TicketSales;

partial class SaleTicketCard
{
    private TableLayoutPanel layoutTicket;
    private Label lblBrand;
    private Label lblFilm;
    private Label lblSession;
    private Label lblRoomAndType;
    private Label lblSeat;
    private Label lblQr;
    private Label lblTicketCode;
    private Button btnPrintTicket;

    private void InitializeComponent()
    {
        layoutTicket = new TableLayoutPanel();
        layoutTicket.Name = "layoutTicket";
        lblBrand = new Label();
        lblBrand.Name = "lblBrand";
        lblFilm = new Label();
        lblFilm.Name = "lblFilm";
        lblSession = new Label();
        lblSession.Name = "lblSession";
        lblRoomAndType = new Label();
        lblRoomAndType.Name = "lblRoomAndType";
        lblSeat = new Label();
        lblSeat.Name = "lblSeat";
        lblQr = new Label();
        lblQr.Name = "lblQr";
        lblTicketCode = new Label();
        lblTicketCode.Name = "lblTicketCode";
        btnPrintTicket = new Button();
        btnPrintTicket.Name = "btnPrintTicket";
        layoutTicket.SuspendLayout();
        SuspendLayout();

        layoutTicket.Dock = DockStyle.Fill;
        layoutTicket.BackColor = Color.White;
        layoutTicket.Margin = Padding.Empty;
        layoutTicket.Padding = new Padding(8);
        layoutTicket.ColumnCount = 1;
        layoutTicket.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTicket.RowCount = 8;
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layoutTicket.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        layoutTicket.Controls.Add(lblBrand, 0, 0);
        layoutTicket.Controls.Add(lblFilm, 0, 1);
        layoutTicket.Controls.Add(lblSession, 0, 2);
        layoutTicket.Controls.Add(lblRoomAndType, 0, 3);
        layoutTicket.Controls.Add(lblSeat, 0, 4);
        layoutTicket.Controls.Add(lblQr, 0, 5);
        layoutTicket.Controls.Add(lblTicketCode, 0, 6);
        layoutTicket.Controls.Add(btnPrintTicket, 0, 7);

        lblBrand.Dock = DockStyle.Fill;
        lblBrand.Margin = Padding.Empty;
        lblBrand.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblBrand.ForeColor = Color.FromArgb(217, 119, 6);
        lblBrand.Text = "STORYLINE";
        lblBrand.TextAlign = ContentAlignment.MiddleCenter;
        lblBrand.UseMnemonic = false;

        lblFilm.Dock = DockStyle.Fill;
        lblFilm.Margin = Padding.Empty;
        lblFilm.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblFilm.ForeColor = Color.FromArgb(15, 23, 42);
        lblFilm.TextAlign = ContentAlignment.MiddleCenter;
        lblFilm.UseMnemonic = false;
        lblFilm.AutoEllipsis = true;

        lblSession.Dock = DockStyle.Fill;
        lblSession.Margin = Padding.Empty;
        lblSession.Font = new Font("Segoe UI", 9F);
        lblSession.ForeColor = Color.FromArgb(100, 116, 139);
        lblSession.TextAlign = ContentAlignment.MiddleCenter;
        lblSession.UseMnemonic = false;

        lblRoomAndType.Dock = DockStyle.Fill;
        lblRoomAndType.Margin = Padding.Empty;
        lblRoomAndType.Font = new Font("Segoe UI", 9F);
        lblRoomAndType.ForeColor = Color.FromArgb(100, 116, 139);
        lblRoomAndType.TextAlign = ContentAlignment.MiddleCenter;
        lblRoomAndType.UseMnemonic = false;
        lblRoomAndType.AutoEllipsis = true;

        lblSeat.Dock = DockStyle.Fill;
        lblSeat.Margin = Padding.Empty;
        lblSeat.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
        lblSeat.ForeColor = Color.FromArgb(15, 23, 42);
        lblSeat.TextAlign = ContentAlignment.MiddleCenter;
        lblSeat.UseMnemonic = false;
        lblSeat.BackColor = Color.FromArgb(241, 245, 249);

        lblQr.Dock = DockStyle.Fill;
        lblQr.Margin = new Padding(40, 4, 40, 4);
        lblQr.Font = new Font("Segoe UI", 10F);
        lblQr.ForeColor = Color.FromArgb(100, 116, 139);
        lblQr.Text = "▦\nQR minh họa";
        lblQr.TextAlign = ContentAlignment.MiddleCenter;
        lblQr.UseMnemonic = false;
        lblQr.BackColor = Color.FromArgb(241, 245, 249);
        lblQr.BorderStyle = BorderStyle.FixedSingle;

        lblTicketCode.Dock = DockStyle.Fill;
        lblTicketCode.Margin = Padding.Empty;
        lblTicketCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTicketCode.ForeColor = Color.FromArgb(15, 23, 42);
        lblTicketCode.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketCode.UseMnemonic = false;

        btnPrintTicket.Dock = DockStyle.Fill;
        btnPrintTicket.FlatStyle = FlatStyle.Flat;
        btnPrintTicket.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnPrintTicket.BackColor = Color.White;
        btnPrintTicket.ForeColor = Color.FromArgb(15, 23, 42);
        btnPrintTicket.UseVisualStyleBackColor = false;
        btnPrintTicket.CausesValidation = false;
        btnPrintTicket.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnPrintTicket.Text = "In vé này";
        btnPrintTicket.Height = 36;
        btnPrintTicket.Cursor = Cursors.Hand;
        btnPrintTicket.Click += BtnPrintTicket_Click;
        btnPrintTicket.Margin = Padding.Empty;

        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(226, 232, 240);
        Controls.Add(layoutTicket);
        Name = "SaleTicketCard";
        Padding = new Padding(1);
        Size = new Size(200, 277);
        TabStop = false;

        layoutTicket.ResumeLayout(false);
        ResumeLayout(false);
    }
}


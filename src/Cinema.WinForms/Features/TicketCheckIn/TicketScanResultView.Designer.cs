namespace Cinema.WinForms.Features.TicketCheckIn;

partial class TicketScanResultView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        checkInHeader = new CheckInScreenHeader();
        pnlResult = new Panel();
        layoutResult = new TableLayoutPanel();
        lblResultStatus = new Label();
        lblSeatCaption = new Label();
        lblSeatCode = new Label();
        lblResultSession = new Label();
        pnlActionDivider = new Panel();
        layoutFooter = new TableLayoutPanel();
        btnBack = new Button();
        btnConfirm = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        pnlResult.SuspendLayout();
        layoutResult.SuspendLayout();
        layoutFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(860, 640);
        pnlViewport.Controls.Add(layoutPage);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.Location = new Point(0, 0);
        pnlViewport.Margin = new Padding(0);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Size = new Size(1136, 730);
        pnlViewport.TabIndex = 0;
        // 
        // layoutPage
        // 
        layoutPage.ColumnCount = 3;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 828F));
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutPage.Controls.Add(checkInHeader, 0, 0);
        layoutPage.Controls.Add(pnlResult, 1, 1);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(860, 640);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16, 15, 16, 16);
        layoutPage.RowCount = 3;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 506F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1136, 730);
        layoutPage.TabIndex = 0;
        // 
        // checkInHeader
        // 
        checkInHeader.BackColor = Color.FromArgb(241, 245, 249);
        layoutPage.SetColumnSpan(checkInHeader, 3);
        checkInHeader.Dock = DockStyle.Fill;
        checkInHeader.Font = new Font("Segoe UI", 9.5F);
        checkInHeader.ForeColor = Color.FromArgb(15, 23, 42);
        checkInHeader.Location = new Point(16, 15);
        checkInHeader.Margin = new Padding(0);
        checkInHeader.Name = "checkInHeader";
        checkInHeader.Size = new Size(1104, 100);
        checkInHeader.TabIndex = 0;
        // 
        // pnlResult
        // 
        pnlResult.BackColor = Color.FromArgb(226, 232, 240);
        pnlResult.Controls.Add(layoutResult);
        pnlResult.Dock = DockStyle.Fill;
        pnlResult.Location = new Point(154, 115);
        pnlResult.Margin = new Padding(0);
        pnlResult.Name = "pnlResult";
        pnlResult.Padding = new Padding(1);
        pnlResult.Size = new Size(828, 506);
        pnlResult.TabIndex = 1;
        // 
        // layoutResult
        // 
        layoutResult.BackColor = Color.White;
        layoutResult.ColumnCount = 1;
        layoutResult.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutResult.Controls.Add(lblResultStatus, 0, 0);
        layoutResult.Controls.Add(lblSeatCaption, 0, 1);
        layoutResult.Controls.Add(lblSeatCode, 0, 2);
        layoutResult.Controls.Add(lblResultSession, 0, 3);
        layoutResult.Controls.Add(pnlActionDivider, 0, 5);
        layoutResult.Controls.Add(layoutFooter, 0, 6);
        layoutResult.Dock = DockStyle.Fill;
        layoutResult.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutResult.Location = new Point(1, 1);
        layoutResult.Margin = new Padding(0);
        layoutResult.Name = "layoutResult";
        layoutResult.Padding = new Padding(18);
        layoutResult.RowCount = 7;
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Absolute, 81F));
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutResult.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
        layoutResult.Size = new Size(826, 504);
        layoutResult.TabIndex = 0;
        // 
        // lblResultStatus
        // 
        lblResultStatus.BackColor = Color.FromArgb(220, 252, 231);
        lblResultStatus.Dock = DockStyle.Fill;
        lblResultStatus.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblResultStatus.ForeColor = Color.FromArgb(22, 101, 52);
        lblResultStatus.Location = new Point(18, 18);
        lblResultStatus.Margin = new Padding(0);
        lblResultStatus.Name = "lblResultStatus";
        lblResultStatus.Padding = new Padding(18, 0, 0, 0);
        lblResultStatus.Size = new Size(790, 81);
        lblResultStatus.TabIndex = 0;
        lblResultStatus.Text = "✓  Vé hợp lệ";
        lblResultStatus.TextAlign = ContentAlignment.MiddleLeft;
        lblResultStatus.UseMnemonic = false;
        // 
        // lblSeatCaption
        // 
        lblSeatCaption.Dock = DockStyle.Fill;
        lblSeatCaption.Font = new Font("Segoe UI", 17F);
        lblSeatCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblSeatCaption.Location = new Point(18, 99);
        lblSeatCaption.Margin = new Padding(0);
        lblSeatCaption.Name = "lblSeatCaption";
        lblSeatCaption.Padding = new Padding(0, 0, 0, 3);
        lblSeatCaption.Size = new Size(790, 60);
        lblSeatCaption.TabIndex = 1;
        lblSeatCaption.Text = "Ghế";
        lblSeatCaption.TextAlign = ContentAlignment.BottomCenter;
        lblSeatCaption.UseMnemonic = false;
        // 
        // lblSeatCode
        // 
        lblSeatCode.Dock = DockStyle.Fill;
        lblSeatCode.Font = new Font("Segoe UI", 62F, FontStyle.Bold);
        lblSeatCode.Location = new Point(18, 159);
        lblSeatCode.Margin = new Padding(0);
        lblSeatCode.Name = "lblSeatCode";
        lblSeatCode.Size = new Size(790, 122);
        lblSeatCode.TabIndex = 2;
        lblSeatCode.Text = "—";
        lblSeatCode.TextAlign = ContentAlignment.MiddleCenter;
        lblSeatCode.UseMnemonic = false;
        // 
        // lblResultSession
        // 
        lblResultSession.Dock = DockStyle.Fill;
        lblResultSession.Font = new Font("Segoe UI", 15F);
        lblResultSession.ForeColor = Color.FromArgb(100, 116, 139);
        lblResultSession.Location = new Point(18, 281);
        lblResultSession.Margin = new Padding(0);
        lblResultSession.Name = "lblResultSession";
        lblResultSession.Size = new Size(790, 46);
        lblResultSession.TabIndex = 3;
        lblResultSession.Text = "Phòng — · Suất —";
        lblResultSession.TextAlign = ContentAlignment.MiddleCenter;
        lblResultSession.UseMnemonic = false;
        // 
        // pnlActionDivider
        // 
        pnlActionDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlActionDivider.Dock = DockStyle.Fill;
        pnlActionDivider.Location = new Point(18, 409);
        pnlActionDivider.Margin = new Padding(0);
        pnlActionDivider.Name = "pnlActionDivider";
        pnlActionDivider.Size = new Size(790, 1);
        pnlActionDivider.TabIndex = 4;
        // 
        // layoutFooter
        // 
        layoutFooter.ColumnCount = 2;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        layoutFooter.Controls.Add(btnBack, 0, 0);
        layoutFooter.Controls.Add(btnConfirm, 1, 0);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Location = new Point(18, 410);
        layoutFooter.Margin = new Padding(0);
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Padding = new Padding(0, 17, 0, 0);
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFooter.Size = new Size(790, 76);
        layoutFooter.TabIndex = 5;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.White;
        btnBack.Dock = DockStyle.Fill;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnBack.ForeColor = Color.FromArgb(37, 99, 235);
        btnBack.Location = new Point(0, 17);
        btnBack.Margin = new Padding(0, 0, 15, 0);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(301, 59);
        btnBack.TabIndex = 0;
        btnBack.Text = "Quay lại quét";
        btnBack.UseMnemonic = false;
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += BtnBack_Click;
        // 
        // btnConfirm
        // 
        btnConfirm.BackColor = Color.FromArgb(37, 99, 235);
        btnConfirm.Dock = DockStyle.Fill;
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.FlatStyle = FlatStyle.Flat;
        btnConfirm.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnConfirm.ForeColor = Color.White;
        btnConfirm.Location = new Point(316, 17);
        btnConfirm.Margin = new Padding(0);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Size = new Size(474, 59);
        btnConfirm.TabIndex = 1;
        btnConfirm.Text = "Xác nhận qua cổng ";
        btnConfirm.UseMnemonic = false;
        btnConfirm.UseVisualStyleBackColor = false;
        btnConfirm.Click += btnConfirm_Click;
        // 
        // TicketScanResultView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "TicketScanResultView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        pnlResult.ResumeLayout(false);
        layoutResult.ResumeLayout(false);
        layoutFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private CheckInScreenHeader checkInHeader;
    private Panel pnlResult;
    private TableLayoutPanel layoutResult;
    private Label lblResultStatus;
    private Label lblSeatCaption;
    private Label lblSeatCode;
    private Label lblResultSession;
    private Panel pnlActionDivider;
    private TableLayoutPanel layoutFooter;
    private Button btnBack;
    private Button btnConfirm;
}

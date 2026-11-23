namespace Cinema.WinForms.Features.TicketCheckIn;

partial class TicketScannerView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        checkInHeader = new CheckInScreenHeader();
        pnlScanner = new Panel();
        layoutScanner = new TableLayoutPanel();
        layoutScannerHeading = new TableLayoutPanel();
        lblScannerTitle = new Label();
        btnCamera = new Button();
        layoutCamera = new TableLayoutPanel();
        lblCameraIcon = new Label();
        lblCameraStatus = new Label();
        layoutScanActions = new TableLayoutPanel();
        pnlTicketCode = new Panel();
        layoutTicketCode = new TableLayoutPanel();
        txtTicketCode = new TextBox();
        btnCheck = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        pnlScanner.SuspendLayout();
        layoutScanner.SuspendLayout();
        layoutScannerHeading.SuspendLayout();
        layoutCamera.SuspendLayout();
        layoutScanActions.SuspendLayout();
        pnlTicketCode.SuspendLayout();
        layoutTicketCode.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(860, 630);
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
        layoutPage.Controls.Add(pnlScanner, 1, 1);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(860, 630);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16, 15, 16, 16);
        layoutPage.RowCount = 3;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 494F));
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
        // pnlScanner
        // 
        pnlScanner.BackColor = Color.FromArgb(226, 232, 240);
        pnlScanner.Controls.Add(layoutScanner);
        pnlScanner.Dock = DockStyle.Fill;
        pnlScanner.Location = new Point(154, 115);
        pnlScanner.Margin = new Padding(0);
        pnlScanner.Name = "pnlScanner";
        pnlScanner.Padding = new Padding(1);
        pnlScanner.Size = new Size(828, 494);
        pnlScanner.TabIndex = 1;
        // 
        // layoutScanner
        // 
        layoutScanner.BackColor = Color.White;
        layoutScanner.ColumnCount = 1;
        layoutScanner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutScanner.Controls.Add(layoutScannerHeading, 0, 0);
        layoutScanner.Controls.Add(layoutCamera, 0, 2);
        layoutScanner.Controls.Add(layoutScanActions, 0, 4);
        layoutScanner.Dock = DockStyle.Fill;
        layoutScanner.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutScanner.Location = new Point(1, 1);
        layoutScanner.Margin = new Padding(0);
        layoutScanner.Name = "layoutScanner";
        layoutScanner.Padding = new Padding(18, 17, 18, 18);
        layoutScanner.RowCount = 5;
        layoutScanner.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layoutScanner.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
        layoutScanner.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutScanner.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
        layoutScanner.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutScanner.Size = new Size(826, 492);
        layoutScanner.TabIndex = 0;
        // 
        // layoutScannerHeading
        // 
        layoutScannerHeading.ColumnCount = 2;
        layoutScannerHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutScannerHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 183F));
        layoutScannerHeading.Controls.Add(lblScannerTitle, 0, 0);
        layoutScannerHeading.Controls.Add(btnCamera, 1, 0);
        layoutScannerHeading.Dock = DockStyle.Fill;
        layoutScannerHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutScannerHeading.Location = new Point(18, 17);
        layoutScannerHeading.Margin = new Padding(0);
        layoutScannerHeading.Name = "layoutScannerHeading";
        layoutScannerHeading.RowCount = 1;
        layoutScannerHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutScannerHeading.Size = new Size(790, 50);
        layoutScannerHeading.TabIndex = 0;
        // 
        // lblScannerTitle
        // 
        lblScannerTitle.Dock = DockStyle.Fill;
        lblScannerTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblScannerTitle.Location = new Point(0, 0);
        lblScannerTitle.Margin = new Padding(0);
        lblScannerTitle.Name = "lblScannerTitle";
        lblScannerTitle.Size = new Size(607, 50);
        lblScannerTitle.TabIndex = 0;
        lblScannerTitle.Text = "Quét mã vé";
        lblScannerTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblScannerTitle.UseMnemonic = false;
        // 
        // btnCamera
        // 
        btnCamera.AccessibleName = "Bật camera";
        btnCamera.BackColor = Color.FromArgb(37, 99, 235);
        btnCamera.Dock = DockStyle.Fill;
        btnCamera.FlatAppearance.BorderSize = 0;
        btnCamera.FlatStyle = FlatStyle.Flat;
        btnCamera.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnCamera.ForeColor = Color.White;
        btnCamera.Location = new Point(607, 0);
        btnCamera.Margin = new Padding(0);
        btnCamera.Name = "btnCamera";
        btnCamera.Size = new Size(183, 50);
        btnCamera.TabIndex = 1;
        btnCamera.Text = "Bật camera";
        btnCamera.UseMnemonic = false;
        btnCamera.UseVisualStyleBackColor = false;
        btnCamera.Click += BtnCamera_Click;
        // 
        // layoutCamera
        // 
        layoutCamera.BackColor = Color.FromArgb(30, 41, 59);
        layoutCamera.ColumnCount = 1;
        layoutCamera.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutCamera.Controls.Add(lblCameraIcon, 0, 1);
        layoutCamera.Controls.Add(lblCameraStatus, 0, 2);
        layoutCamera.Dock = DockStyle.Fill;
        layoutCamera.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCamera.Location = new Point(18, 82);
        layoutCamera.Margin = new Padding(0);
        layoutCamera.Name = "layoutCamera";
        layoutCamera.RowCount = 4;
        layoutCamera.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        layoutCamera.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
        layoutCamera.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutCamera.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        layoutCamera.Size = new Size(790, 323);
        layoutCamera.TabIndex = 1;
        // 
        // lblCameraIcon
        // 
        lblCameraIcon.AccessibleRole = AccessibleRole.Graphic;
        lblCameraIcon.Dock = DockStyle.Fill;
        lblCameraIcon.Font = new Font("Segoe MDL2 Assets", 38F);
        lblCameraIcon.ForeColor = Color.White;
        lblCameraIcon.Location = new Point(0, 100);
        lblCameraIcon.Margin = new Padding(0);
        lblCameraIcon.Name = "lblCameraIcon";
        lblCameraIcon.Size = new Size(790, 79);
        lblCameraIcon.TabIndex = 0;
        lblCameraIcon.Text = "";
        lblCameraIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblCameraIcon.UseMnemonic = false;
        // 
        // lblCameraStatus
        // 
        lblCameraStatus.Dock = DockStyle.Fill;
        lblCameraStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblCameraStatus.ForeColor = Color.White;
        lblCameraStatus.Location = new Point(0, 179);
        lblCameraStatus.Margin = new Padding(0);
        lblCameraStatus.Name = "lblCameraStatus";
        lblCameraStatus.Size = new Size(790, 43);
        lblCameraStatus.TabIndex = 1;
        lblCameraStatus.Text = "Camera đang tắt";
        lblCameraStatus.TextAlign = ContentAlignment.MiddleCenter;
        lblCameraStatus.UseMnemonic = false;
        // 
        // layoutScanActions
        // 
        layoutScanActions.ColumnCount = 2;
        layoutScanActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutScanActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
        layoutScanActions.Controls.Add(pnlTicketCode, 0, 0);
        layoutScanActions.Controls.Add(btnCheck, 1, 0);
        layoutScanActions.Dock = DockStyle.Fill;
        layoutScanActions.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutScanActions.Location = new Point(18, 426);
        layoutScanActions.Margin = new Padding(0);
        layoutScanActions.Name = "layoutScanActions";
        layoutScanActions.RowCount = 1;
        layoutScanActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutScanActions.Size = new Size(790, 48);
        layoutScanActions.TabIndex = 2;
        // 
        // pnlTicketCode
        // 
        pnlTicketCode.BackColor = Color.FromArgb(226, 232, 240);
        pnlTicketCode.Controls.Add(layoutTicketCode);
        pnlTicketCode.Dock = DockStyle.Fill;
        pnlTicketCode.Location = new Point(0, 0);
        pnlTicketCode.Margin = new Padding(0, 0, 15, 0);
        pnlTicketCode.Name = "pnlTicketCode";
        pnlTicketCode.Padding = new Padding(1);
        pnlTicketCode.Size = new Size(585, 48);
        pnlTicketCode.TabIndex = 0;
        // 
        // layoutTicketCode
        // 
        layoutTicketCode.BackColor = Color.White;
        layoutTicketCode.ColumnCount = 1;
        layoutTicketCode.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTicketCode.Controls.Add(txtTicketCode, 0, 0);
        layoutTicketCode.Dock = DockStyle.Fill;
        layoutTicketCode.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTicketCode.Location = new Point(1, 1);
        layoutTicketCode.Margin = new Padding(0);
        layoutTicketCode.Name = "layoutTicketCode";
        layoutTicketCode.Padding = new Padding(10, 0, 9, 0);
        layoutTicketCode.RowCount = 1;
        layoutTicketCode.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTicketCode.Size = new Size(583, 46);
        layoutTicketCode.TabIndex = 0;
        // 
        // txtTicketCode
        // 
        txtTicketCode.AccessibleName = "Mã vé";
        txtTicketCode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtTicketCode.BackColor = Color.White;
        txtTicketCode.BorderStyle = BorderStyle.None;
        txtTicketCode.Font = new Font("Segoe UI", 11F);
        txtTicketCode.Location = new Point(10, 7);
        txtTicketCode.Margin = new Padding(0);
        txtTicketCode.Name = "txtTicketCode";
        txtTicketCode.PlaceholderText = "Nhập mã vé";
        txtTicketCode.Size = new Size(564, 25);
        txtTicketCode.TabIndex = 0;
        txtTicketCode.KeyDown += TxtTicketCode_KeyDown;
        // 
        // btnCheck
        // 
        btnCheck.BackColor = Color.FromArgb(37, 99, 235);
        btnCheck.Dock = DockStyle.Fill;
        btnCheck.FlatAppearance.BorderSize = 0;
        btnCheck.FlatStyle = FlatStyle.Flat;
        btnCheck.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnCheck.ForeColor = Color.White;
        btnCheck.Location = new Point(600, 0);
        btnCheck.Margin = new Padding(0);
        btnCheck.Name = "btnCheck";
        btnCheck.Size = new Size(190, 48);
        btnCheck.TabIndex = 1;
        btnCheck.Text = "Kiểm tra";
        btnCheck.UseMnemonic = false;
        btnCheck.UseVisualStyleBackColor = false;
        btnCheck.Click += BtnCheck_Click;
        // 
        // TicketScannerView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "TicketScannerView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        pnlScanner.ResumeLayout(false);
        layoutScanner.ResumeLayout(false);
        layoutScannerHeading.ResumeLayout(false);
        layoutCamera.ResumeLayout(false);
        layoutScanActions.ResumeLayout(false);
        pnlTicketCode.ResumeLayout(false);
        layoutTicketCode.ResumeLayout(false);
        layoutTicketCode.PerformLayout();
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private CheckInScreenHeader checkInHeader;
    private Panel pnlScanner;
    private TableLayoutPanel layoutScanner;
    private TableLayoutPanel layoutScannerHeading;
    private Label lblScannerTitle;
    private Button btnCamera;
    private TableLayoutPanel layoutCamera;
    private Label lblCameraIcon;
    private Label lblCameraStatus;
    private TableLayoutPanel layoutScanActions;
    private Panel pnlTicketCode;
    private TableLayoutPanel layoutTicketCode;
    private TextBox txtTicketCode;
    private Button btnCheck;
}

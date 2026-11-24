namespace Cinema.WinForms.Features.TicketCheckIn;

partial class CheckInHistoryView
{
    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        layoutHeading = new TableLayoutPanel();
        layoutTitle = new TableLayoutPanel();
        lblTitle = new Label();
        lblSession = new Label();
        btnBack = new Button();
        layoutMetrics = new TableLayoutPanel();
        pnlSold = new Panel();
        layoutSold = new TableLayoutPanel();
        lblSoldIcon = new Label();
        layoutSoldMetric = new TableLayoutPanel();
        lblSoldCaption = new Label();
        lblSoldValue = new Label();
        pnlAdmitted = new Panel();
        layoutAdmitted = new TableLayoutPanel();
        lblAdmittedIcon = new Label();
        layoutAdmittedMetric = new TableLayoutPanel();
        lblAdmittedCaption = new Label();
        lblAdmittedValue = new Label();
        pnlRemaining = new Panel();
        layoutRemaining = new TableLayoutPanel();
        lblRemainingIcon = new Label();
        layoutRemainingMetric = new TableLayoutPanel();
        lblRemainingCaption = new Label();
        lblRemainingValue = new Label();
        pnlRejected = new Panel();
        layoutRejected = new TableLayoutPanel();
        lblRejectedIcon = new Label();
        layoutRejectedMetric = new TableLayoutPanel();
        lblRejectedCaption = new Label();
        lblRejectedValue = new Label();
        layoutFilters = new TableLayoutPanel();
        pnlSearch = new Panel();
        layoutSearch = new TableLayoutPanel();
        lblSearchIcon = new Label();
        txtSearch = new TextBox();
        btnAll = new Button();
        btnSuccess = new Button();
        btnRejectedFilter = new Button();
        pnlGrid = new Panel();
        lblEmptyState = new Label();
        gridHistory = new DataGridView();
        colScanTime = new DataGridViewTextBoxColumn();
        colTicketCode = new DataGridViewTextBoxColumn();
        colSeat = new DataGridViewTextBoxColumn();
        colTicketType = new DataGridViewTextBoxColumn();
        colOperator = new DataGridViewTextBoxColumn();
        colStatus = new DataGridViewTextBoxColumn();
        colNote = new DataGridViewTextBoxColumn();
        pnlPagination = new Panel();
        layoutPagination = new TableLayoutPanel();
        lblCount = new Label();
        btnPrevious = new Button();
        lblPageNumber = new Label();
        btnNext = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        layoutHeading.SuspendLayout();
        layoutTitle.SuspendLayout();
        layoutMetrics.SuspendLayout();
        pnlSold.SuspendLayout();
        layoutSold.SuspendLayout();
        layoutSoldMetric.SuspendLayout();
        pnlAdmitted.SuspendLayout();
        layoutAdmitted.SuspendLayout();
        layoutAdmittedMetric.SuspendLayout();
        pnlRemaining.SuspendLayout();
        layoutRemaining.SuspendLayout();
        layoutRemainingMetric.SuspendLayout();
        pnlRejected.SuspendLayout();
        layoutRejected.SuspendLayout();
        layoutRejectedMetric.SuspendLayout();
        layoutFilters.SuspendLayout();
        pnlSearch.SuspendLayout();
        layoutSearch.SuspendLayout();
        pnlGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
        pnlPagination.SuspendLayout();
        layoutPagination.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1035, 680);
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
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.Controls.Add(layoutHeading, 0, 0);
        layoutPage.Controls.Add(layoutMetrics, 0, 1);
        layoutPage.Controls.Add(layoutFilters, 0, 2);
        layoutPage.Controls.Add(pnlGrid, 0, 3);
        layoutPage.Controls.Add(pnlPagination, 0, 4);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(1035, 680);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16);
        layoutPage.RowCount = 6;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 113F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 338F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1136, 730);
        layoutPage.TabIndex = 0;
        // 
        // layoutHeading
        // 
        layoutHeading.ColumnCount = 2;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 259F));
        layoutHeading.Controls.Add(layoutTitle, 0, 0);
        layoutHeading.Controls.Add(btnBack, 1, 0);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeading.Location = new Point(16, 16);
        layoutHeading.Margin = new Padding(0, 0, 0, 12);
        layoutHeading.Name = "layoutHeading";
        layoutHeading.RowCount = 1;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeading.Size = new Size(1104, 63);
        layoutHeading.TabIndex = 0;
        // 
        // layoutTitle
        // 
        layoutTitle.ColumnCount = 1;
        layoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTitle.Controls.Add(lblTitle, 0, 0);
        layoutTitle.Controls.Add(lblSession, 0, 1);
        layoutTitle.Dock = DockStyle.Fill;
        layoutTitle.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTitle.Location = new Point(0, 0);
        layoutTitle.Margin = new Padding(0);
        layoutTitle.Name = "layoutTitle";
        layoutTitle.Padding = new Padding(3, 0, 0, 0);
        layoutTitle.RowCount = 2;
        layoutTitle.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutTitle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTitle.Size = new Size(845, 63);
        layoutTitle.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 19.5F, FontStyle.Bold);
        lblTitle.Location = new Point(3, 0);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(842, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Nhật ký soát vé";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // lblSession
        // 
        lblSession.Dock = DockStyle.Fill;
        lblSession.Font = new Font("Segoe UI", 9.5F);
        lblSession.ForeColor = Color.FromArgb(100, 116, 139);
        lblSession.Location = new Point(3, 40);
        lblSession.Margin = new Padding(0);
        lblSession.Name = "lblSession";
        lblSession.Size = new Size(842, 23);
        lblSession.TabIndex = 1;
        lblSession.Text = "Phòng — · Suất —";
        lblSession.TextAlign = ContentAlignment.MiddleLeft;
        lblSession.UseMnemonic = false;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.White;
        btnBack.Dock = DockStyle.Fill;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Font = new Font("Segoe UI", 9.5F);
        btnBack.ForeColor = Color.FromArgb(15, 23, 42);
        btnBack.Location = new Point(845, 8);
        btnBack.Margin = new Padding(0, 8, 0, 13);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(259, 42);
        btnBack.TabIndex = 1;
        btnBack.Text = "‹  Quay lại màn hình quét vé";
        btnBack.UseMnemonic = false;
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += BtnBack_Click;
        // 
        // layoutMetrics
        // 
        layoutMetrics.ColumnCount = 7;
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
        layoutMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutMetrics.Controls.Add(pnlSold, 0, 0);
        layoutMetrics.Controls.Add(pnlAdmitted, 2, 0);
        layoutMetrics.Controls.Add(pnlRemaining, 4, 0);
        layoutMetrics.Controls.Add(pnlRejected, 6, 0);
        layoutMetrics.Dock = DockStyle.Fill;
        layoutMetrics.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutMetrics.Location = new Point(16, 91);
        layoutMetrics.Margin = new Padding(0, 0, 0, 12);
        layoutMetrics.Name = "layoutMetrics";
        layoutMetrics.RowCount = 1;
        layoutMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMetrics.Size = new Size(1104, 101);
        layoutMetrics.TabIndex = 1;
        // 
        // pnlSold
        // 
        pnlSold.BackColor = Color.FromArgb(226, 232, 240);
        pnlSold.Controls.Add(layoutSold);
        pnlSold.Dock = DockStyle.Fill;
        pnlSold.Location = new Point(0, 0);
        pnlSold.Margin = new Padding(0);
        pnlSold.Name = "pnlSold";
        pnlSold.Padding = new Padding(1);
        pnlSold.Size = new Size(267, 101);
        pnlSold.TabIndex = 0;
        // 
        // layoutSold
        // 
        layoutSold.BackColor = Color.White;
        layoutSold.ColumnCount = 2;
        layoutSold.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
        layoutSold.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutSold.Controls.Add(lblSoldIcon, 0, 0);
        layoutSold.Controls.Add(layoutSoldMetric, 1, 0);
        layoutSold.Dock = DockStyle.Fill;
        layoutSold.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSold.Location = new Point(1, 1);
        layoutSold.Margin = new Padding(0);
        layoutSold.Name = "layoutSold";
        layoutSold.Padding = new Padding(8, 9, 8, 9);
        layoutSold.RowCount = 1;
        layoutSold.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSold.Size = new Size(265, 99);
        layoutSold.TabIndex = 0;
        // 
        // lblSoldIcon
        // 
        lblSoldIcon.AccessibleRole = AccessibleRole.Graphic;
        lblSoldIcon.Dock = DockStyle.Fill;
        lblSoldIcon.Font = new Font("Segoe MDL2 Assets", 17F);
        lblSoldIcon.ForeColor = Color.FromArgb(51, 65, 85);
        lblSoldIcon.Location = new Point(8, 9);
        lblSoldIcon.Margin = new Padding(0);
        lblSoldIcon.Name = "lblSoldIcon";
        lblSoldIcon.Size = new Size(52, 81);
        lblSoldIcon.TabIndex = 0;
        lblSoldIcon.Text = "";
        lblSoldIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblSoldIcon.UseMnemonic = false;
        // 
        // layoutSoldMetric
        // 
        layoutSoldMetric.ColumnCount = 1;
        layoutSoldMetric.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutSoldMetric.Controls.Add(lblSoldCaption, 0, 0);
        layoutSoldMetric.Controls.Add(lblSoldValue, 0, 1);
        layoutSoldMetric.Dock = DockStyle.Fill;
        layoutSoldMetric.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSoldMetric.Location = new Point(60, 9);
        layoutSoldMetric.Margin = new Padding(0);
        layoutSoldMetric.Name = "layoutSoldMetric";
        layoutSoldMetric.Padding = new Padding(3, 0, 0, 0);
        layoutSoldMetric.RowCount = 2;
        layoutSoldMetric.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutSoldMetric.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSoldMetric.Size = new Size(197, 81);
        layoutSoldMetric.TabIndex = 1;
        // 
        // lblSoldCaption
        // 
        lblSoldCaption.Dock = DockStyle.Fill;
        lblSoldCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSoldCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblSoldCaption.Location = new Point(3, 0);
        lblSoldCaption.Margin = new Padding(0);
        lblSoldCaption.Name = "lblSoldCaption";
        lblSoldCaption.Size = new Size(194, 30);
        lblSoldCaption.TabIndex = 0;
        lblSoldCaption.Text = "Tổng vé đã bán";
        lblSoldCaption.TextAlign = ContentAlignment.BottomLeft;
        lblSoldCaption.UseMnemonic = false;
        // 
        // lblSoldValue
        // 
        lblSoldValue.Dock = DockStyle.Fill;
        lblSoldValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSoldValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblSoldValue.Location = new Point(3, 30);
        lblSoldValue.Margin = new Padding(0);
        lblSoldValue.Name = "lblSoldValue";
        lblSoldValue.Size = new Size(194, 51);
        lblSoldValue.TabIndex = 1;
        lblSoldValue.Text = "— vé";
        lblSoldValue.UseMnemonic = false;
        // 
        // pnlAdmitted
        // 
        pnlAdmitted.BackColor = Color.FromArgb(187, 247, 208);
        pnlAdmitted.Controls.Add(layoutAdmitted);
        pnlAdmitted.Dock = DockStyle.Fill;
        pnlAdmitted.Location = new Point(278, 0);
        pnlAdmitted.Margin = new Padding(0);
        pnlAdmitted.Name = "pnlAdmitted";
        pnlAdmitted.Padding = new Padding(1);
        pnlAdmitted.Size = new Size(267, 101);
        pnlAdmitted.TabIndex = 1;
        // 
        // layoutAdmitted
        // 
        layoutAdmitted.BackColor = Color.FromArgb(240, 253, 244);
        layoutAdmitted.ColumnCount = 2;
        layoutAdmitted.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
        layoutAdmitted.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutAdmitted.Controls.Add(lblAdmittedIcon, 0, 0);
        layoutAdmitted.Controls.Add(layoutAdmittedMetric, 1, 0);
        layoutAdmitted.Dock = DockStyle.Fill;
        layoutAdmitted.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutAdmitted.Location = new Point(1, 1);
        layoutAdmitted.Margin = new Padding(0);
        layoutAdmitted.Name = "layoutAdmitted";
        layoutAdmitted.Padding = new Padding(8, 9, 8, 9);
        layoutAdmitted.RowCount = 1;
        layoutAdmitted.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutAdmitted.Size = new Size(265, 99);
        layoutAdmitted.TabIndex = 0;
        // 
        // lblAdmittedIcon
        // 
        lblAdmittedIcon.AccessibleRole = AccessibleRole.Graphic;
        lblAdmittedIcon.Dock = DockStyle.Fill;
        lblAdmittedIcon.Font = new Font("Segoe MDL2 Assets", 17F);
        lblAdmittedIcon.ForeColor = Color.FromArgb(22, 101, 52);
        lblAdmittedIcon.Location = new Point(8, 9);
        lblAdmittedIcon.Margin = new Padding(0);
        lblAdmittedIcon.Name = "lblAdmittedIcon";
        lblAdmittedIcon.Size = new Size(52, 81);
        lblAdmittedIcon.TabIndex = 0;
        lblAdmittedIcon.Text = "";
        lblAdmittedIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblAdmittedIcon.UseMnemonic = false;
        // 
        // layoutAdmittedMetric
        // 
        layoutAdmittedMetric.ColumnCount = 1;
        layoutAdmittedMetric.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutAdmittedMetric.Controls.Add(lblAdmittedCaption, 0, 0);
        layoutAdmittedMetric.Controls.Add(lblAdmittedValue, 0, 1);
        layoutAdmittedMetric.Dock = DockStyle.Fill;
        layoutAdmittedMetric.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutAdmittedMetric.Location = new Point(60, 9);
        layoutAdmittedMetric.Margin = new Padding(0);
        layoutAdmittedMetric.Name = "layoutAdmittedMetric";
        layoutAdmittedMetric.Padding = new Padding(3, 0, 0, 0);
        layoutAdmittedMetric.RowCount = 2;
        layoutAdmittedMetric.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutAdmittedMetric.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutAdmittedMetric.Size = new Size(197, 81);
        layoutAdmittedMetric.TabIndex = 1;
        // 
        // lblAdmittedCaption
        // 
        lblAdmittedCaption.Dock = DockStyle.Fill;
        lblAdmittedCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblAdmittedCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblAdmittedCaption.Location = new Point(3, 0);
        lblAdmittedCaption.Margin = new Padding(0);
        lblAdmittedCaption.Name = "lblAdmittedCaption";
        lblAdmittedCaption.Size = new Size(194, 30);
        lblAdmittedCaption.TabIndex = 0;
        lblAdmittedCaption.Text = "Đã vào rạp (Hợp lệ)";
        lblAdmittedCaption.TextAlign = ContentAlignment.BottomLeft;
        lblAdmittedCaption.UseMnemonic = false;
        // 
        // lblAdmittedValue
        // 
        lblAdmittedValue.Dock = DockStyle.Fill;
        lblAdmittedValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblAdmittedValue.ForeColor = Color.FromArgb(22, 101, 52);
        lblAdmittedValue.Location = new Point(3, 30);
        lblAdmittedValue.Margin = new Padding(0);
        lblAdmittedValue.Name = "lblAdmittedValue";
        lblAdmittedValue.Size = new Size(194, 51);
        lblAdmittedValue.TabIndex = 1;
        lblAdmittedValue.Text = "— vé";
        lblAdmittedValue.UseMnemonic = false;
        // 
        // pnlRemaining
        // 
        pnlRemaining.BackColor = Color.FromArgb(253, 230, 138);
        pnlRemaining.Controls.Add(layoutRemaining);
        pnlRemaining.Dock = DockStyle.Fill;
        pnlRemaining.Location = new Point(556, 0);
        pnlRemaining.Margin = new Padding(0);
        pnlRemaining.Name = "pnlRemaining";
        pnlRemaining.Padding = new Padding(1);
        pnlRemaining.Size = new Size(267, 101);
        pnlRemaining.TabIndex = 2;
        // 
        // layoutRemaining
        // 
        layoutRemaining.BackColor = Color.FromArgb(255, 251, 235);
        layoutRemaining.ColumnCount = 2;
        layoutRemaining.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
        layoutRemaining.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRemaining.Controls.Add(lblRemainingIcon, 0, 0);
        layoutRemaining.Controls.Add(layoutRemainingMetric, 1, 0);
        layoutRemaining.Dock = DockStyle.Fill;
        layoutRemaining.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRemaining.Location = new Point(1, 1);
        layoutRemaining.Margin = new Padding(0);
        layoutRemaining.Name = "layoutRemaining";
        layoutRemaining.Padding = new Padding(8, 9, 8, 9);
        layoutRemaining.RowCount = 1;
        layoutRemaining.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRemaining.Size = new Size(265, 99);
        layoutRemaining.TabIndex = 0;
        // 
        // lblRemainingIcon
        // 
        lblRemainingIcon.AccessibleRole = AccessibleRole.Graphic;
        lblRemainingIcon.Dock = DockStyle.Fill;
        lblRemainingIcon.Font = new Font("Segoe MDL2 Assets", 17F);
        lblRemainingIcon.ForeColor = Color.FromArgb(217, 119, 6);
        lblRemainingIcon.Location = new Point(8, 9);
        lblRemainingIcon.Margin = new Padding(0);
        lblRemainingIcon.Name = "lblRemainingIcon";
        lblRemainingIcon.Size = new Size(52, 81);
        lblRemainingIcon.TabIndex = 0;
        lblRemainingIcon.Text = "";
        lblRemainingIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblRemainingIcon.UseMnemonic = false;
        // 
        // layoutRemainingMetric
        // 
        layoutRemainingMetric.ColumnCount = 1;
        layoutRemainingMetric.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRemainingMetric.Controls.Add(lblRemainingCaption, 0, 0);
        layoutRemainingMetric.Controls.Add(lblRemainingValue, 0, 1);
        layoutRemainingMetric.Dock = DockStyle.Fill;
        layoutRemainingMetric.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRemainingMetric.Location = new Point(60, 9);
        layoutRemainingMetric.Margin = new Padding(0);
        layoutRemainingMetric.Name = "layoutRemainingMetric";
        layoutRemainingMetric.Padding = new Padding(3, 0, 0, 0);
        layoutRemainingMetric.RowCount = 2;
        layoutRemainingMetric.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutRemainingMetric.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRemainingMetric.Size = new Size(197, 81);
        layoutRemainingMetric.TabIndex = 1;
        // 
        // lblRemainingCaption
        // 
        lblRemainingCaption.Dock = DockStyle.Fill;
        lblRemainingCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRemainingCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblRemainingCaption.Location = new Point(3, 0);
        lblRemainingCaption.Margin = new Padding(0);
        lblRemainingCaption.Name = "lblRemainingCaption";
        lblRemainingCaption.Size = new Size(194, 30);
        lblRemainingCaption.TabIndex = 0;
        lblRemainingCaption.Text = "Chưa vào rạp";
        lblRemainingCaption.TextAlign = ContentAlignment.BottomLeft;
        lblRemainingCaption.UseMnemonic = false;
        // 
        // lblRemainingValue
        // 
        lblRemainingValue.Dock = DockStyle.Fill;
        lblRemainingValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblRemainingValue.ForeColor = Color.FromArgb(146, 64, 14);
        lblRemainingValue.Location = new Point(3, 30);
        lblRemainingValue.Margin = new Padding(0);
        lblRemainingValue.Name = "lblRemainingValue";
        lblRemainingValue.Size = new Size(194, 51);
        lblRemainingValue.TabIndex = 1;
        lblRemainingValue.Text = "— vé";
        lblRemainingValue.UseMnemonic = false;
        // 
        // pnlRejected
        // 
        pnlRejected.BackColor = Color.FromArgb(254, 202, 202);
        pnlRejected.Controls.Add(layoutRejected);
        pnlRejected.Dock = DockStyle.Fill;
        pnlRejected.Location = new Point(834, 0);
        pnlRejected.Margin = new Padding(0);
        pnlRejected.Name = "pnlRejected";
        pnlRejected.Padding = new Padding(1);
        pnlRejected.Size = new Size(270, 101);
        pnlRejected.TabIndex = 3;
        // 
        // layoutRejected
        // 
        layoutRejected.BackColor = Color.FromArgb(254, 242, 242);
        layoutRejected.ColumnCount = 2;
        layoutRejected.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
        layoutRejected.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRejected.Controls.Add(lblRejectedIcon, 0, 0);
        layoutRejected.Controls.Add(layoutRejectedMetric, 1, 0);
        layoutRejected.Dock = DockStyle.Fill;
        layoutRejected.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRejected.Location = new Point(1, 1);
        layoutRejected.Margin = new Padding(0);
        layoutRejected.Name = "layoutRejected";
        layoutRejected.Padding = new Padding(8, 9, 8, 9);
        layoutRejected.RowCount = 1;
        layoutRejected.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRejected.Size = new Size(268, 99);
        layoutRejected.TabIndex = 0;
        // 
        // lblRejectedIcon
        // 
        lblRejectedIcon.AccessibleRole = AccessibleRole.Graphic;
        lblRejectedIcon.Dock = DockStyle.Fill;
        lblRejectedIcon.Font = new Font("Segoe MDL2 Assets", 17F);
        lblRejectedIcon.ForeColor = Color.FromArgb(185, 28, 28);
        lblRejectedIcon.Location = new Point(8, 9);
        lblRejectedIcon.Margin = new Padding(0);
        lblRejectedIcon.Name = "lblRejectedIcon";
        lblRejectedIcon.Size = new Size(52, 81);
        lblRejectedIcon.TabIndex = 0;
        lblRejectedIcon.Text = "";
        lblRejectedIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblRejectedIcon.UseMnemonic = false;
        // 
        // layoutRejectedMetric
        // 
        layoutRejectedMetric.ColumnCount = 1;
        layoutRejectedMetric.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRejectedMetric.Controls.Add(lblRejectedCaption, 0, 0);
        layoutRejectedMetric.Controls.Add(lblRejectedValue, 0, 1);
        layoutRejectedMetric.Dock = DockStyle.Fill;
        layoutRejectedMetric.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRejectedMetric.Location = new Point(60, 9);
        layoutRejectedMetric.Margin = new Padding(0);
        layoutRejectedMetric.Name = "layoutRejectedMetric";
        layoutRejectedMetric.Padding = new Padding(3, 0, 0, 0);
        layoutRejectedMetric.RowCount = 2;
        layoutRejectedMetric.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutRejectedMetric.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRejectedMetric.Size = new Size(200, 81);
        layoutRejectedMetric.TabIndex = 1;
        // 
        // lblRejectedCaption
        // 
        lblRejectedCaption.Dock = DockStyle.Fill;
        lblRejectedCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRejectedCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblRejectedCaption.Location = new Point(3, 0);
        lblRejectedCaption.Margin = new Padding(0);
        lblRejectedCaption.Name = "lblRejectedCaption";
        lblRejectedCaption.Size = new Size(197, 30);
        lblRejectedCaption.TabIndex = 0;
        lblRejectedCaption.Text = "Lượt quét bị từ chối";
        lblRejectedCaption.TextAlign = ContentAlignment.BottomLeft;
        lblRejectedCaption.UseMnemonic = false;
        // 
        // lblRejectedValue
        // 
        lblRejectedValue.Dock = DockStyle.Fill;
        lblRejectedValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblRejectedValue.ForeColor = Color.FromArgb(185, 28, 28);
        lblRejectedValue.Location = new Point(3, 30);
        lblRejectedValue.Margin = new Padding(0);
        lblRejectedValue.Name = "lblRejectedValue";
        lblRejectedValue.Size = new Size(197, 51);
        lblRejectedValue.TabIndex = 1;
        lblRejectedValue.Text = "— lượt";
        lblRejectedValue.UseMnemonic = false;
        // 
        // layoutFilters
        // 
        layoutFilters.ColumnCount = 4;
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 181F));
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 171F));
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 252F));
        layoutFilters.Controls.Add(pnlSearch, 0, 0);
        layoutFilters.Controls.Add(btnAll, 1, 0);
        layoutFilters.Controls.Add(btnSuccess, 2, 0);
        layoutFilters.Controls.Add(btnRejectedFilter, 3, 0);
        layoutFilters.Dock = DockStyle.Fill;
        layoutFilters.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFilters.Location = new Point(16, 204);
        layoutFilters.Margin = new Padding(0, 0, 0, 13);
        layoutFilters.Name = "layoutFilters";
        layoutFilters.RowCount = 1;
        layoutFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFilters.Size = new Size(1104, 42);
        layoutFilters.TabIndex = 2;
        // 
        // pnlSearch
        // 
        pnlSearch.BackColor = Color.FromArgb(226, 232, 240);
        pnlSearch.Controls.Add(layoutSearch);
        pnlSearch.Dock = DockStyle.Fill;
        pnlSearch.Location = new Point(0, 0);
        pnlSearch.Margin = new Padding(0, 0, 10, 0);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Padding = new Padding(1);
        pnlSearch.Size = new Size(490, 42);
        pnlSearch.TabIndex = 0;
        // 
        // layoutSearch
        // 
        layoutSearch.BackColor = Color.White;
        layoutSearch.ColumnCount = 2;
        layoutSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
        layoutSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutSearch.Controls.Add(lblSearchIcon, 0, 0);
        layoutSearch.Controls.Add(txtSearch, 1, 0);
        layoutSearch.Dock = DockStyle.Fill;
        layoutSearch.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSearch.Location = new Point(1, 1);
        layoutSearch.Margin = new Padding(0);
        layoutSearch.Name = "layoutSearch";
        layoutSearch.Padding = new Padding(4, 0, 9, 0);
        layoutSearch.RowCount = 1;
        layoutSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSearch.Size = new Size(488, 40);
        layoutSearch.TabIndex = 0;
        // 
        // lblSearchIcon
        // 
        lblSearchIcon.AccessibleRole = AccessibleRole.Graphic;
        lblSearchIcon.Dock = DockStyle.Fill;
        lblSearchIcon.Font = new Font("Segoe MDL2 Assets", 11F);
        lblSearchIcon.ForeColor = Color.FromArgb(100, 116, 139);
        lblSearchIcon.Location = new Point(4, 0);
        lblSearchIcon.Margin = new Padding(0);
        lblSearchIcon.Name = "lblSearchIcon";
        lblSearchIcon.Size = new Size(33, 40);
        lblSearchIcon.TabIndex = 0;
        lblSearchIcon.Text = "";
        lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblSearchIcon.UseMnemonic = false;
        // 
        // txtSearch
        // 
        txtSearch.AccessibleName = "Tìm theo mã vé hoặc số ghế";
        txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.BackColor = Color.White;
        txtSearch.BorderStyle = BorderStyle.None;
        txtSearch.Location = new Point(37, 6);
        txtSearch.Margin = new Padding(0);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Tìm theo mã vé hoặc số ghế…";
        txtSearch.Size = new Size(442, 20);
        txtSearch.TabIndex = 1;
        // 
        // btnAll
        // 
        btnAll.BackColor = Color.FromArgb(37, 99, 235);
        btnAll.Dock = DockStyle.Fill;
        btnAll.FlatAppearance.BorderSize = 0;
        btnAll.FlatStyle = FlatStyle.Flat;
        btnAll.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnAll.ForeColor = Color.White;
        btnAll.Location = new Point(500, 0);
        btnAll.Margin = new Padding(0, 0, 9, 0);
        btnAll.Name = "btnAll";
        btnAll.Size = new Size(172, 42);
        btnAll.TabIndex = 1;
        btnAll.Text = "Tất cả lượt quét";
        btnAll.UseMnemonic = false;
        btnAll.UseVisualStyleBackColor = false;
        // 
        // btnSuccess
        // 
        btnSuccess.BackColor = Color.White;
        btnSuccess.Dock = DockStyle.Fill;
        btnSuccess.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnSuccess.FlatStyle = FlatStyle.Flat;
        btnSuccess.Font = new Font("Segoe UI", 9.5F);
        btnSuccess.ForeColor = Color.FromArgb(15, 23, 42);
        btnSuccess.Location = new Point(681, 0);
        btnSuccess.Margin = new Padding(0, 0, 9, 0);
        btnSuccess.Name = "btnSuccess";
        btnSuccess.Size = new Size(162, 42);
        btnSuccess.TabIndex = 2;
        btnSuccess.Text = "Hợp lệ (Đã vào)";
        btnSuccess.UseMnemonic = false;
        btnSuccess.UseVisualStyleBackColor = false;
        // 
        // btnRejectedFilter
        // 
        btnRejectedFilter.BackColor = Color.White;
        btnRejectedFilter.Dock = DockStyle.Fill;
        btnRejectedFilter.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnRejectedFilter.FlatStyle = FlatStyle.Flat;
        btnRejectedFilter.Font = new Font("Segoe UI", 9F);
        btnRejectedFilter.ForeColor = Color.FromArgb(15, 23, 42);
        btnRejectedFilter.Location = new Point(852, 0);
        btnRejectedFilter.Margin = new Padding(0);
        btnRejectedFilter.Name = "btnRejectedFilter";
        btnRejectedFilter.Size = new Size(252, 42);
        btnRejectedFilter.TabIndex = 3;
        btnRejectedFilter.Text = "Bị từ chối (Dùng lại / Sai suất)";
        btnRejectedFilter.UseMnemonic = false;
        btnRejectedFilter.UseVisualStyleBackColor = false;
        // 
        // pnlGrid
        // 
        pnlGrid.BackColor = Color.FromArgb(226, 232, 240);
        pnlGrid.Controls.Add(lblEmptyState);
        pnlGrid.Controls.Add(gridHistory);
        pnlGrid.Dock = DockStyle.Fill;
        pnlGrid.Location = new Point(16, 259);
        pnlGrid.Margin = new Padding(0);
        pnlGrid.Name = "pnlGrid";
        pnlGrid.Padding = new Padding(1);
        pnlGrid.Size = new Size(1104, 338);
        pnlGrid.TabIndex = 3;
        // 
        // lblEmptyState
        // 
        lblEmptyState.BackColor = Color.White;
        lblEmptyState.Dock = DockStyle.Fill;
        lblEmptyState.Font = new Font("Segoe UI", 11F);
        lblEmptyState.ForeColor = Color.FromArgb(100, 116, 139);
        lblEmptyState.Location = new Point(1, 41);
        lblEmptyState.Margin = new Padding(0);
        lblEmptyState.Name = "lblEmptyState";
        lblEmptyState.Size = new Size(1102, 296);
        lblEmptyState.TabIndex = 0;
        lblEmptyState.Text = "Chưa có lượt quét";
        lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
        lblEmptyState.UseMnemonic = false;
        // 
        // gridHistory
        // 
        gridHistory.AccessibleName = "Nhật ký lượt quét vé";
        gridHistory.AllowUserToAddRows = false;
        gridHistory.AllowUserToDeleteRows = false;
        gridHistory.AllowUserToResizeRows = false;
        gridHistory.AutoGenerateColumns = false;
        gridHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        gridHistory.BackgroundColor = Color.White;
        gridHistory.BorderStyle = BorderStyle.None;
        gridHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
        dataGridViewCellStyle1.Padding = new Padding(6, 0, 2, 0);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(51, 65, 85);
        gridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        gridHistory.ColumnHeadersHeight = 40;
        gridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridHistory.Columns.AddRange(new DataGridViewColumn[] { colScanTime, colTicketCode, colSeat, colTicketType, colOperator, colStatus, colNote });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle2.Padding = new Padding(6, 0, 2, 0);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(219, 234, 254);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        gridHistory.DefaultCellStyle = dataGridViewCellStyle2;
        gridHistory.Dock = DockStyle.Top;
        gridHistory.EnableHeadersVisualStyles = false;
        gridHistory.GridColor = Color.FromArgb(226, 232, 240);
        gridHistory.Location = new Point(1, 1);
        gridHistory.Margin = new Padding(0);
        gridHistory.MultiSelect = false;
        gridHistory.Name = "gridHistory";
        gridHistory.ReadOnly = true;
        gridHistory.RowHeadersVisible = false;
        gridHistory.RowHeadersWidth = 51;
        gridHistory.RowTemplate.Height = 39;
        gridHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridHistory.Size = new Size(1102, 40);
        gridHistory.TabIndex = 1;
        //
        // colScanTime
        //
        colScanTime.DataPropertyName = "ScannedAt";
        colScanTime.FillWeight = 13F;
        colScanTime.HeaderText = "Thời gian quét";
        colScanTime.Name = "colScanTime";
        colScanTime.ReadOnly = true;
        colScanTime.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colTicketCode
        //
        colTicketCode.DataPropertyName = "TicketCode";
        colTicketCode.FillWeight = 13F;
        colTicketCode.HeaderText = "Mã vé";
        colTicketCode.Name = "colTicketCode";
        colTicketCode.ReadOnly = true;
        colTicketCode.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colSeat
        //
        colSeat.DataPropertyName = "SeatCode";
        colSeat.FillWeight = 10F;
        colSeat.HeaderText = "Vị trí ghế";
        colSeat.Name = "colSeat";
        colSeat.ReadOnly = true;
        colSeat.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colTicketType
        //
        colTicketType.DataPropertyName = "TicketType";
        colTicketType.FillWeight = 10F;
        colTicketType.HeaderText = "Loại vé";
        colTicketType.Name = "colTicketType";
        colTicketType.ReadOnly = true;
        colTicketType.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colOperator
        //
        colOperator.DataPropertyName = "OperatorName";
        colOperator.FillWeight = 16F;
        colOperator.HeaderText = "Nhân viên soát";
        colOperator.Name = "colOperator";
        colOperator.ReadOnly = true;
        colOperator.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colStatus
        //
        colStatus.DataPropertyName = "Status";
        colStatus.FillWeight = 17F;
        colStatus.HeaderText = "Trạng thái";
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colNote
        //
        colNote.DataPropertyName = "Note";
        colNote.FillWeight = 21F;
        colNote.HeaderText = "Ghi chú chi tiết";
        colNote.Name = "colNote";
        colNote.ReadOnly = true;
        colNote.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // pnlPagination
        // 
        pnlPagination.BackColor = Color.FromArgb(226, 232, 240);
        pnlPagination.Controls.Add(layoutPagination);
        pnlPagination.Dock = DockStyle.Fill;
        pnlPagination.Location = new Point(16, 609);
        pnlPagination.Margin = new Padding(0, 12, 0, 0);
        pnlPagination.Name = "pnlPagination";
        pnlPagination.Padding = new Padding(1);
        pnlPagination.Size = new Size(1104, 53);
        pnlPagination.TabIndex = 4;
        // 
        // layoutPagination
        // 
        layoutPagination.BackColor = Color.White;
        layoutPagination.ColumnCount = 4;
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
        layoutPagination.Controls.Add(lblCount, 0, 0);
        layoutPagination.Controls.Add(btnPrevious, 1, 0);
        layoutPagination.Controls.Add(lblPageNumber, 2, 0);
        layoutPagination.Controls.Add(btnNext, 3, 0);
        layoutPagination.Dock = DockStyle.Fill;
        layoutPagination.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPagination.Location = new Point(1, 1);
        layoutPagination.Margin = new Padding(0);
        layoutPagination.Name = "layoutPagination";
        layoutPagination.Padding = new Padding(12, 9, 10, 9);
        layoutPagination.RowCount = 1;
        layoutPagination.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPagination.Size = new Size(1102, 51);
        layoutPagination.TabIndex = 0;
        // 
        // lblCount
        // 
        lblCount.Dock = DockStyle.Fill;
        lblCount.Font = new Font("Segoe UI", 9F);
        lblCount.ForeColor = Color.FromArgb(100, 116, 139);
        lblCount.Location = new Point(12, 9);
        lblCount.Margin = new Padding(0);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(955, 33);
        lblCount.TabIndex = 0;
        lblCount.Text = "0 lượt quét";
        lblCount.TextAlign = ContentAlignment.MiddleLeft;
        lblCount.UseMnemonic = false;
        // 
        // btnPrevious
        // 
        btnPrevious.AccessibleName = "Trang trước";
        btnPrevious.BackColor = Color.White;
        btnPrevious.Dock = DockStyle.Fill;
        btnPrevious.Enabled = false;
        btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnPrevious.FlatStyle = FlatStyle.Flat;
        btnPrevious.Font = new Font("Segoe UI", 9.5F);
        btnPrevious.ForeColor = Color.FromArgb(15, 23, 42);
        btnPrevious.Location = new Point(967, 9);
        btnPrevious.Margin = new Padding(0, 0, 5, 0);
        btnPrevious.Name = "btnPrevious";
        btnPrevious.Size = new Size(35, 33);
        btnPrevious.TabIndex = 1;
        btnPrevious.Text = "‹";
        btnPrevious.UseMnemonic = false;
        btnPrevious.UseVisualStyleBackColor = false;
        // 
        // lblPageNumber
        // 
        lblPageNumber.BackColor = Color.FromArgb(241, 245, 249);
        lblPageNumber.Dock = DockStyle.Fill;
        lblPageNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPageNumber.ForeColor = Color.FromArgb(100, 116, 139);
        lblPageNumber.Location = new Point(1007, 9);
        lblPageNumber.Margin = new Padding(0, 0, 5, 0);
        lblPageNumber.Name = "lblPageNumber";
        lblPageNumber.Size = new Size(40, 33);
        lblPageNumber.TabIndex = 2;
        lblPageNumber.Text = "—";
        lblPageNumber.TextAlign = ContentAlignment.MiddleCenter;
        lblPageNumber.UseMnemonic = false;
        // 
        // btnNext
        // 
        btnNext.AccessibleName = "Trang sau";
        btnNext.BackColor = Color.White;
        btnNext.Dock = DockStyle.Fill;
        btnNext.Enabled = false;
        btnNext.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnNext.FlatStyle = FlatStyle.Flat;
        btnNext.Font = new Font("Segoe UI", 9.5F);
        btnNext.ForeColor = Color.FromArgb(15, 23, 42);
        btnNext.Location = new Point(1052, 9);
        btnNext.Margin = new Padding(0);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(40, 33);
        btnNext.TabIndex = 3;
        btnNext.Text = "›";
        btnNext.UseMnemonic = false;
        btnNext.UseVisualStyleBackColor = false;
        // 
        // CheckInHistoryView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "CheckInHistoryView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        layoutHeading.ResumeLayout(false);
        layoutTitle.ResumeLayout(false);
        layoutMetrics.ResumeLayout(false);
        pnlSold.ResumeLayout(false);
        layoutSold.ResumeLayout(false);
        layoutSoldMetric.ResumeLayout(false);
        pnlAdmitted.ResumeLayout(false);
        layoutAdmitted.ResumeLayout(false);
        layoutAdmittedMetric.ResumeLayout(false);
        pnlRemaining.ResumeLayout(false);
        layoutRemaining.ResumeLayout(false);
        layoutRemainingMetric.ResumeLayout(false);
        pnlRejected.ResumeLayout(false);
        layoutRejected.ResumeLayout(false);
        layoutRejectedMetric.ResumeLayout(false);
        layoutFilters.ResumeLayout(false);
        pnlSearch.ResumeLayout(false);
        layoutSearch.ResumeLayout(false);
        layoutSearch.PerformLayout();
        pnlGrid.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
        pnlPagination.ResumeLayout(false);
        layoutPagination.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private TableLayoutPanel layoutHeading;
    private TableLayoutPanel layoutTitle;
    private Label lblTitle;
    private Label lblSession;
    private Button btnBack;
    private TableLayoutPanel layoutMetrics;
    private Panel pnlSold;
    private TableLayoutPanel layoutSold;
    private Label lblSoldIcon;
    private TableLayoutPanel layoutSoldMetric;
    private Label lblSoldCaption;
    private Label lblSoldValue;
    private Panel pnlAdmitted;
    private TableLayoutPanel layoutAdmitted;
    private Label lblAdmittedIcon;
    private TableLayoutPanel layoutAdmittedMetric;
    private Label lblAdmittedCaption;
    private Label lblAdmittedValue;
    private Panel pnlRemaining;
    private TableLayoutPanel layoutRemaining;
    private Label lblRemainingIcon;
    private TableLayoutPanel layoutRemainingMetric;
    private Label lblRemainingCaption;
    private Label lblRemainingValue;
    private Panel pnlRejected;
    private TableLayoutPanel layoutRejected;
    private Label lblRejectedIcon;
    private TableLayoutPanel layoutRejectedMetric;
    private Label lblRejectedCaption;
    private Label lblRejectedValue;
    private TableLayoutPanel layoutFilters;
    private Panel pnlSearch;
    private TableLayoutPanel layoutSearch;
    private Label lblSearchIcon;
    private TextBox txtSearch;
    private Button btnAll;
    private Button btnSuccess;
    private Button btnRejectedFilter;
    private Panel pnlGrid;
    private DataGridView gridHistory;
    private Label lblEmptyState;
    private Panel pnlPagination;
    private TableLayoutPanel layoutPagination;
    private Label lblCount;
    private Button btnPrevious;
    private Label lblPageNumber;
    private Button btnNext;
    private DataGridViewTextBoxColumn colScanTime;
    private DataGridViewTextBoxColumn colTicketCode;
    private DataGridViewTextBoxColumn colSeat;
    private DataGridViewTextBoxColumn colTicketType;
    private DataGridViewTextBoxColumn colOperator;
    private DataGridViewTextBoxColumn colStatus;
    private DataGridViewTextBoxColumn colNote;
}

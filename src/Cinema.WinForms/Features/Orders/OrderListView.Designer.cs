namespace Cinema.WinForms.Features.Orders;

partial class OrderListView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        lblTitle = new Label();
        layoutSearchBar = new TableLayoutPanel();
        pnlSearch = new Panel();
        layoutSearch = new TableLayoutPanel();
        lblSearchIcon = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        layoutFilters = new TableLayoutPanel();
        pnlDateFilter = new Panel();
        layoutDateFilter = new TableLayoutPanel();
        lblDateFilter = new Label();
        dtpTransactionDate = new DateTimePicker();
        pnlPaymentFilter = new Panel();
        layoutPaymentFilter = new TableLayoutPanel();
        cmbPaymentFilter = new ComboBox();
        pnlStatusFilter = new Panel();
        layoutStatusFilter = new TableLayoutPanel();
        cmbStatusFilter = new ComboBox();
        pnlOrders = new Panel();
        layoutOrders = new TableLayoutPanel();
        lblCodeHeader = new Label();
        lblCreatedHeader = new Label();
        lblCustomerHeader = new Label();
        lblSummaryHeader = new Label();
        lblAmountHeader = new Label();
        lblPaymentHeader = new Label();
        lblStatusHeader = new Label();
        lblActionsHeader = new Label();
        lblCode1 = new Label();
        lblCreated1 = new Label();
        lblCustomer1 = new Label();
        lblSummary1 = new Label();
        lblAmount1 = new Label();
        lblPayment1 = new Label();
        layoutStatus1 = new TableLayoutPanel();
        lblStatus1 = new Label();
        layoutActions1 = new TableLayoutPanel();
        btnDetails1 = new Button();
        lblCode2 = new Label();
        lblCreated2 = new Label();
        lblCustomer2 = new Label();
        lblSummary2 = new Label();
        lblAmount2 = new Label();
        lblPayment2 = new Label();
        layoutStatus2 = new TableLayoutPanel();
        lblStatus2 = new Label();
        layoutActions2 = new TableLayoutPanel();
        btnDetails2 = new Button();
        lblCode3 = new Label();
        lblCreated3 = new Label();
        lblCustomer3 = new Label();
        lblSummary3 = new Label();
        lblAmount3 = new Label();
        lblPayment3 = new Label();
        layoutStatus3 = new TableLayoutPanel();
        lblStatus3 = new Label();
        layoutActions3 = new TableLayoutPanel();
        btnDetails3 = new Button();
        lblCode4 = new Label();
        lblCreated4 = new Label();
        lblCustomer4 = new Label();
        lblSummary4 = new Label();
        lblAmount4 = new Label();
        lblPayment4 = new Label();
        layoutStatus4 = new TableLayoutPanel();
        lblStatus4 = new Label();
        layoutActions4 = new TableLayoutPanel();
        btnDetails4 = new Button();
        lblCode5 = new Label();
        lblCreated5 = new Label();
        lblCustomer5 = new Label();
        lblSummary5 = new Label();
        lblAmount5 = new Label();
        lblPayment5 = new Label();
        layoutStatus5 = new TableLayoutPanel();
        lblStatus5 = new Label();
        layoutActions5 = new TableLayoutPanel();
        btnDetails5 = new Button();
        lblCode6 = new Label();
        lblCreated6 = new Label();
        lblCustomer6 = new Label();
        lblSummary6 = new Label();
        lblAmount6 = new Label();
        lblPayment6 = new Label();
        layoutStatus6 = new TableLayoutPanel();
        lblStatus6 = new Label();
        layoutActions6 = new TableLayoutPanel();
        btnDetails6 = new Button();
        pnlPagination = new Panel();
        layoutPagination = new TableLayoutPanel();
        lblInvoiceCount = new Label();
        btnPreviousPage = new Button();
        btnPage1 = new Button();
        btnPage2 = new Button();
        lblPageGap = new Label();
        btnPage7 = new Button();
        btnNextPage = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        layoutSearchBar.SuspendLayout();
        pnlSearch.SuspendLayout();
        layoutSearch.SuspendLayout();
        layoutFilters.SuspendLayout();
        pnlDateFilter.SuspendLayout();
        layoutDateFilter.SuspendLayout();
        pnlPaymentFilter.SuspendLayout();
        layoutPaymentFilter.SuspendLayout();
        pnlStatusFilter.SuspendLayout();
        layoutStatusFilter.SuspendLayout();
        pnlOrders.SuspendLayout();
        layoutOrders.SuspendLayout();
        layoutStatus1.SuspendLayout();
        layoutActions1.SuspendLayout();
        layoutStatus2.SuspendLayout();
        layoutActions2.SuspendLayout();
        layoutStatus3.SuspendLayout();
        layoutActions3.SuspendLayout();
        layoutStatus4.SuspendLayout();
        layoutActions4.SuspendLayout();
        layoutStatus5.SuspendLayout();
        layoutActions5.SuspendLayout();
        layoutStatus6.SuspendLayout();
        layoutActions6.SuspendLayout();
        pnlPagination.SuspendLayout();
        layoutPagination.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1045, 610);
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
        layoutPage.Controls.Add(lblTitle, 0, 0);
        layoutPage.Controls.Add(layoutSearchBar, 0, 1);
        layoutPage.Controls.Add(layoutFilters, 0, 2);
        layoutPage.Controls.Add(pnlOrders, 0, 3);
        layoutPage.Controls.Add(pnlPagination, 0, 4);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(1045, 610);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16);
        layoutPage.RowCount = 6;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1136, 730);
        layoutPage.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 19.5F, FontStyle.Bold);
        lblTitle.Location = new Point(16, 16);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Padding = new Padding(3, 0, 0, 7);
        lblTitle.Size = new Size(1104, 57);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Danh sách & tra cứu hóa đơn";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // layoutSearchBar
        // 
        layoutSearchBar.ColumnCount = 3;
        layoutSearchBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47F));
        layoutSearchBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195F));
        layoutSearchBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53F));
        layoutSearchBar.Controls.Add(pnlSearch, 0, 0);
        layoutSearchBar.Controls.Add(btnSearch, 1, 0);
        layoutSearchBar.Dock = DockStyle.Fill;
        layoutSearchBar.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSearchBar.Location = new Point(16, 73);
        layoutSearchBar.Margin = new Padding(0, 0, 0, 11);
        layoutSearchBar.Name = "layoutSearchBar";
        layoutSearchBar.RowCount = 1;
        layoutSearchBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSearchBar.Size = new Size(1104, 42);
        layoutSearchBar.TabIndex = 1;
        // 
        // pnlSearch
        // 
        pnlSearch.BackColor = Color.FromArgb(226, 232, 240);
        pnlSearch.Controls.Add(layoutSearch);
        pnlSearch.Dock = DockStyle.Fill;
        pnlSearch.Location = new Point(0, 0);
        pnlSearch.Margin = new Padding(0, 0, 9, 0);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Padding = new Padding(1);
        pnlSearch.Size = new Size(418, 42);
        pnlSearch.TabIndex = 0;
        // 
        // layoutSearch
        // 
        layoutSearch.BackColor = Color.White;
        layoutSearch.ColumnCount = 2;
        layoutSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
        layoutSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutSearch.Controls.Add(lblSearchIcon, 0, 0);
        layoutSearch.Controls.Add(txtSearch, 1, 0);
        layoutSearch.Dock = DockStyle.Fill;
        layoutSearch.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSearch.Location = new Point(1, 1);
        layoutSearch.Margin = new Padding(0);
        layoutSearch.Name = "layoutSearch";
        layoutSearch.Padding = new Padding(3, 0, 8, 0);
        layoutSearch.RowCount = 1;
        layoutSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSearch.Size = new Size(416, 40);
        layoutSearch.TabIndex = 0;
        // 
        // lblSearchIcon
        // 
        lblSearchIcon.AccessibleRole = AccessibleRole.Graphic;
        lblSearchIcon.Dock = DockStyle.Fill;
        lblSearchIcon.Font = new Font("Segoe MDL2 Assets", 12F);
        lblSearchIcon.ForeColor = Color.FromArgb(100, 116, 139);
        lblSearchIcon.Location = new Point(3, 0);
        lblSearchIcon.Margin = new Padding(0);
        lblSearchIcon.Name = "lblSearchIcon";
        lblSearchIcon.Size = new Size(34, 40);
        lblSearchIcon.TabIndex = 0;
        lblSearchIcon.Text = "";
        lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblSearchIcon.UseMnemonic = false;
        // 
        // txtSearch
        // 
        txtSearch.AccessibleName = "Mã vé hoặc số điện thoại khách hàng";
        txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.BackColor = Color.White;
        txtSearch.BorderStyle = BorderStyle.None;
        txtSearch.Location = new Point(37, 9);
        txtSearch.Margin = new Padding(0);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Nhập mã vé hoặc SĐT khách hàng…";
        txtSearch.Size = new Size(371, 22);
        txtSearch.TabIndex = 1;
        // 
        // btnSearch
        // 
        btnSearch.BackColor = Color.FromArgb(37, 99, 235);
        btnSearch.Dock = DockStyle.Fill;
        btnSearch.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnSearch.FlatAppearance.BorderSize = 0;
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSearch.ForeColor = Color.White;
        btnSearch.Location = new Point(427, 0);
        btnSearch.Margin = new Padding(0);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(195, 42);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Tìm kiếm";
        btnSearch.UseMnemonic = false;
        btnSearch.UseVisualStyleBackColor = false;
        // 
        // layoutFilters
        // 
        layoutFilters.ColumnCount = 3;
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
        layoutFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        layoutFilters.Controls.Add(pnlDateFilter, 0, 0);
        layoutFilters.Controls.Add(pnlPaymentFilter, 1, 0);
        layoutFilters.Controls.Add(pnlStatusFilter, 2, 0);
        layoutFilters.Dock = DockStyle.Fill;
        layoutFilters.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFilters.Location = new Point(16, 126);
        layoutFilters.Margin = new Padding(0, 0, 0, 12);
        layoutFilters.Name = "layoutFilters";
        layoutFilters.RowCount = 1;
        layoutFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFilters.Size = new Size(1104, 40);
        layoutFilters.TabIndex = 2;
        // 
        // pnlDateFilter
        // 
        pnlDateFilter.BackColor = Color.FromArgb(226, 232, 240);
        pnlDateFilter.Controls.Add(layoutDateFilter);
        pnlDateFilter.Dock = DockStyle.Fill;
        pnlDateFilter.Location = new Point(0, 0);
        pnlDateFilter.Margin = new Padding(0, 0, 10, 0);
        pnlDateFilter.Name = "pnlDateFilter";
        pnlDateFilter.Padding = new Padding(1);
        pnlDateFilter.Size = new Size(365, 40);
        pnlDateFilter.TabIndex = 0;
        // 
        // layoutDateFilter
        // 
        layoutDateFilter.BackColor = Color.White;
        layoutDateFilter.ColumnCount = 2;
        layoutDateFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
        layoutDateFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutDateFilter.Controls.Add(lblDateFilter, 0, 0);
        layoutDateFilter.Controls.Add(dtpTransactionDate, 1, 0);
        layoutDateFilter.Dock = DockStyle.Fill;
        layoutDateFilter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutDateFilter.Location = new Point(1, 1);
        layoutDateFilter.Margin = new Padding(0);
        layoutDateFilter.Name = "layoutDateFilter";
        layoutDateFilter.Padding = new Padding(9, 0, 6, 0);
        layoutDateFilter.RowCount = 1;
        layoutDateFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDateFilter.Size = new Size(363, 38);
        layoutDateFilter.TabIndex = 0;
        // 
        // lblDateFilter
        // 
        lblDateFilter.Dock = DockStyle.Fill;
        lblDateFilter.Font = new Font("Segoe UI", 9.5F);
        lblDateFilter.Location = new Point(9, 0);
        lblDateFilter.Margin = new Padding(0);
        lblDateFilter.Name = "lblDateFilter";
        lblDateFilter.Size = new Size(135, 38);
        lblDateFilter.TabIndex = 0;
        lblDateFilter.Text = "Ngày giao dịch";
        lblDateFilter.TextAlign = ContentAlignment.MiddleLeft;
        lblDateFilter.UseMnemonic = false;
        // 
        // dtpTransactionDate
        // 
        dtpTransactionDate.AccessibleName = "Ngày giao dịch";
        dtpTransactionDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        dtpTransactionDate.CustomFormat = "dd/MM/yyyy";
        dtpTransactionDate.Font = new Font("Segoe UI", 9.5F);
        dtpTransactionDate.Format = DateTimePickerFormat.Custom;
        dtpTransactionDate.Location = new Point(144, 4);
        dtpTransactionDate.Margin = new Padding(0);
        dtpTransactionDate.Name = "dtpTransactionDate";
        dtpTransactionDate.Size = new Size(213, 29);
        dtpTransactionDate.TabIndex = 1;
        dtpTransactionDate.Value = new DateTime(2026, 11, 18, 0, 0, 0, 0);
        // 
        // pnlPaymentFilter
        // 
        pnlPaymentFilter.BackColor = Color.FromArgb(226, 232, 240);
        pnlPaymentFilter.Controls.Add(layoutPaymentFilter);
        pnlPaymentFilter.Dock = DockStyle.Fill;
        pnlPaymentFilter.Location = new Point(375, 0);
        pnlPaymentFilter.Margin = new Padding(0, 0, 10, 0);
        pnlPaymentFilter.Name = "pnlPaymentFilter";
        pnlPaymentFilter.Padding = new Padding(1);
        pnlPaymentFilter.Size = new Size(343, 40);
        pnlPaymentFilter.TabIndex = 1;
        // 
        // layoutPaymentFilter
        // 
        layoutPaymentFilter.BackColor = Color.White;
        layoutPaymentFilter.ColumnCount = 1;
        layoutPaymentFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPaymentFilter.Controls.Add(cmbPaymentFilter, 0, 0);
        layoutPaymentFilter.Dock = DockStyle.Fill;
        layoutPaymentFilter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPaymentFilter.Location = new Point(1, 1);
        layoutPaymentFilter.Margin = new Padding(0);
        layoutPaymentFilter.Name = "layoutPaymentFilter";
        layoutPaymentFilter.Padding = new Padding(7, 0, 5, 0);
        layoutPaymentFilter.RowCount = 1;
        layoutPaymentFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPaymentFilter.Size = new Size(341, 38);
        layoutPaymentFilter.TabIndex = 0;
        // 
        // cmbPaymentFilter
        // 
        cmbPaymentFilter.AccessibleName = "Phương thức thanh toán";
        cmbPaymentFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cmbPaymentFilter.BackColor = Color.White;
        cmbPaymentFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPaymentFilter.FlatStyle = FlatStyle.Flat;
        cmbPaymentFilter.Font = new Font("Segoe UI", 9.5F);
        cmbPaymentFilter.ForeColor = Color.FromArgb(15, 23, 42);
        cmbPaymentFilter.FormattingEnabled = true;
        cmbPaymentFilter.Items.AddRange(new object[] { "Phương thức: Tất cả", "Tiền mặt", "VietQR" });
        cmbPaymentFilter.Location = new Point(7, 4);
        cmbPaymentFilter.Margin = new Padding(0);
        cmbPaymentFilter.Name = "cmbPaymentFilter";
        cmbPaymentFilter.Size = new Size(329, 29);
        cmbPaymentFilter.TabIndex = 0;
        // 
        // pnlStatusFilter
        // 
        pnlStatusFilter.BackColor = Color.FromArgb(226, 232, 240);
        pnlStatusFilter.Controls.Add(layoutStatusFilter);
        pnlStatusFilter.Dock = DockStyle.Fill;
        pnlStatusFilter.Location = new Point(728, 0);
        pnlStatusFilter.Margin = new Padding(0);
        pnlStatusFilter.Name = "pnlStatusFilter";
        pnlStatusFilter.Padding = new Padding(1);
        pnlStatusFilter.Size = new Size(376, 40);
        pnlStatusFilter.TabIndex = 2;
        // 
        // layoutStatusFilter
        // 
        layoutStatusFilter.BackColor = Color.White;
        layoutStatusFilter.ColumnCount = 1;
        layoutStatusFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatusFilter.Controls.Add(cmbStatusFilter, 0, 0);
        layoutStatusFilter.Dock = DockStyle.Fill;
        layoutStatusFilter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatusFilter.Location = new Point(1, 1);
        layoutStatusFilter.Margin = new Padding(0);
        layoutStatusFilter.Name = "layoutStatusFilter";
        layoutStatusFilter.Padding = new Padding(7, 0, 5, 0);
        layoutStatusFilter.RowCount = 1;
        layoutStatusFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatusFilter.Size = new Size(374, 38);
        layoutStatusFilter.TabIndex = 0;
        // 
        // cmbStatusFilter
        // 
        cmbStatusFilter.AccessibleName = "Trạng thái hóa đơn";
        cmbStatusFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cmbStatusFilter.BackColor = Color.White;
        cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStatusFilter.FlatStyle = FlatStyle.Flat;
        cmbStatusFilter.Font = new Font("Segoe UI", 9.5F);
        cmbStatusFilter.ForeColor = Color.FromArgb(15, 23, 42);
        cmbStatusFilter.FormattingEnabled = true;
        cmbStatusFilter.Items.AddRange(new object[] { "Trạng thái: Tất cả", "Đã thanh toán", "Đã hủy" });
        cmbStatusFilter.Location = new Point(7, 4);
        cmbStatusFilter.Margin = new Padding(0);
        cmbStatusFilter.Name = "cmbStatusFilter";
        cmbStatusFilter.Size = new Size(362, 29);
        cmbStatusFilter.TabIndex = 0;
        // 
        // pnlOrders
        // 
        pnlOrders.BackColor = Color.FromArgb(226, 232, 240);
        pnlOrders.Controls.Add(layoutOrders);
        pnlOrders.Dock = DockStyle.Fill;
        pnlOrders.Location = new Point(16, 178);
        pnlOrders.Margin = new Padding(0);
        pnlOrders.Name = "pnlOrders";
        pnlOrders.Padding = new Padding(1);
        pnlOrders.Size = new Size(1104, 350);
        pnlOrders.TabIndex = 3;
        // 
        // layoutOrders
        // 
        layoutOrders.BackColor = Color.FromArgb(226, 232, 240);
        layoutOrders.ColumnCount = 8;
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.5F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.75F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.75F));
        layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.5F));
        layoutOrders.Controls.Add(lblCodeHeader, 0, 0);
        layoutOrders.Controls.Add(lblCreatedHeader, 1, 0);
        layoutOrders.Controls.Add(lblCustomerHeader, 2, 0);
        layoutOrders.Controls.Add(lblSummaryHeader, 3, 0);
        layoutOrders.Controls.Add(lblAmountHeader, 4, 0);
        layoutOrders.Controls.Add(lblPaymentHeader, 5, 0);
        layoutOrders.Controls.Add(lblStatusHeader, 6, 0);
        layoutOrders.Controls.Add(lblActionsHeader, 7, 0);
        layoutOrders.Controls.Add(lblCode1, 0, 1);
        layoutOrders.Controls.Add(lblCreated1, 1, 1);
        layoutOrders.Controls.Add(lblCustomer1, 2, 1);
        layoutOrders.Controls.Add(lblSummary1, 3, 1);
        layoutOrders.Controls.Add(lblAmount1, 4, 1);
        layoutOrders.Controls.Add(lblPayment1, 5, 1);
        layoutOrders.Controls.Add(layoutStatus1, 6, 1);
        layoutOrders.Controls.Add(layoutActions1, 7, 1);
        layoutOrders.Controls.Add(lblCode2, 0, 2);
        layoutOrders.Controls.Add(lblCreated2, 1, 2);
        layoutOrders.Controls.Add(lblCustomer2, 2, 2);
        layoutOrders.Controls.Add(lblSummary2, 3, 2);
        layoutOrders.Controls.Add(lblAmount2, 4, 2);
        layoutOrders.Controls.Add(lblPayment2, 5, 2);
        layoutOrders.Controls.Add(layoutStatus2, 6, 2);
        layoutOrders.Controls.Add(layoutActions2, 7, 2);
        layoutOrders.Controls.Add(lblCode3, 0, 3);
        layoutOrders.Controls.Add(lblCreated3, 1, 3);
        layoutOrders.Controls.Add(lblCustomer3, 2, 3);
        layoutOrders.Controls.Add(lblSummary3, 3, 3);
        layoutOrders.Controls.Add(lblAmount3, 4, 3);
        layoutOrders.Controls.Add(lblPayment3, 5, 3);
        layoutOrders.Controls.Add(layoutStatus3, 6, 3);
        layoutOrders.Controls.Add(layoutActions3, 7, 3);
        layoutOrders.Controls.Add(lblCode4, 0, 4);
        layoutOrders.Controls.Add(lblCreated4, 1, 4);
        layoutOrders.Controls.Add(lblCustomer4, 2, 4);
        layoutOrders.Controls.Add(lblSummary4, 3, 4);
        layoutOrders.Controls.Add(lblAmount4, 4, 4);
        layoutOrders.Controls.Add(lblPayment4, 5, 4);
        layoutOrders.Controls.Add(layoutStatus4, 6, 4);
        layoutOrders.Controls.Add(layoutActions4, 7, 4);
        layoutOrders.Controls.Add(lblCode5, 0, 5);
        layoutOrders.Controls.Add(lblCreated5, 1, 5);
        layoutOrders.Controls.Add(lblCustomer5, 2, 5);
        layoutOrders.Controls.Add(lblSummary5, 3, 5);
        layoutOrders.Controls.Add(lblAmount5, 4, 5);
        layoutOrders.Controls.Add(lblPayment5, 5, 5);
        layoutOrders.Controls.Add(layoutStatus5, 6, 5);
        layoutOrders.Controls.Add(layoutActions5, 7, 5);
        layoutOrders.Controls.Add(lblCode6, 0, 6);
        layoutOrders.Controls.Add(lblCreated6, 1, 6);
        layoutOrders.Controls.Add(lblCustomer6, 2, 6);
        layoutOrders.Controls.Add(lblSummary6, 3, 6);
        layoutOrders.Controls.Add(lblAmount6, 4, 6);
        layoutOrders.Controls.Add(lblPayment6, 5, 6);
        layoutOrders.Controls.Add(layoutStatus6, 6, 6);
        layoutOrders.Controls.Add(layoutActions6, 7, 6);
        layoutOrders.Dock = DockStyle.Fill;
        layoutOrders.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutOrders.Location = new Point(1, 1);
        layoutOrders.Margin = new Padding(0);
        layoutOrders.Name = "layoutOrders";
        layoutOrders.RowCount = 7;
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutOrders.Size = new Size(1102, 348);
        layoutOrders.TabIndex = 0;
        // 
        // lblCodeHeader
        // 
        lblCodeHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblCodeHeader.Dock = DockStyle.Fill;
        lblCodeHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblCodeHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblCodeHeader.Location = new Point(0, 0);
        lblCodeHeader.Margin = new Padding(0, 0, 0, 1);
        lblCodeHeader.Name = "lblCodeHeader";
        lblCodeHeader.Padding = new Padding(8, 0, 0, 0);
        lblCodeHeader.Size = new Size(170, 41);
        lblCodeHeader.TabIndex = 0;
        lblCodeHeader.Text = "Mã hóa đơn";
        lblCodeHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblCodeHeader.UseMnemonic = false;
        // 
        // lblCreatedHeader
        // 
        lblCreatedHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblCreatedHeader.Dock = DockStyle.Fill;
        lblCreatedHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblCreatedHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblCreatedHeader.Location = new Point(170, 0);
        lblCreatedHeader.Margin = new Padding(0, 0, 0, 1);
        lblCreatedHeader.Name = "lblCreatedHeader";
        lblCreatedHeader.Size = new Size(154, 41);
        lblCreatedHeader.TabIndex = 1;
        lblCreatedHeader.Text = "Thời gian tạo";
        lblCreatedHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblCreatedHeader.UseMnemonic = false;
        // 
        // lblCustomerHeader
        // 
        lblCustomerHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblCustomerHeader.Dock = DockStyle.Fill;
        lblCustomerHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblCustomerHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblCustomerHeader.Location = new Point(324, 0);
        lblCustomerHeader.Margin = new Padding(0, 0, 0, 1);
        lblCustomerHeader.Name = "lblCustomerHeader";
        lblCustomerHeader.Padding = new Padding(4, 0, 0, 0);
        lblCustomerHeader.Size = new Size(165, 41);
        lblCustomerHeader.TabIndex = 2;
        lblCustomerHeader.Text = "Khách hàng / SĐT";
        lblCustomerHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomerHeader.UseMnemonic = false;
        // 
        // lblSummaryHeader
        // 
        lblSummaryHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblSummaryHeader.Dock = DockStyle.Fill;
        lblSummaryHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblSummaryHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblSummaryHeader.Location = new Point(489, 0);
        lblSummaryHeader.Margin = new Padding(0, 0, 0, 1);
        lblSummaryHeader.Name = "lblSummaryHeader";
        lblSummaryHeader.Padding = new Padding(6, 0, 0, 0);
        lblSummaryHeader.Size = new Size(159, 41);
        lblSummaryHeader.TabIndex = 3;
        lblSummaryHeader.Text = "Nội dung tóm tắt";
        lblSummaryHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblSummaryHeader.UseMnemonic = false;
        // 
        // lblAmountHeader
        // 
        lblAmountHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblAmountHeader.Dock = DockStyle.Fill;
        lblAmountHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblAmountHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblAmountHeader.Location = new Point(648, 0);
        lblAmountHeader.Margin = new Padding(0, 0, 0, 1);
        lblAmountHeader.Name = "lblAmountHeader";
        lblAmountHeader.Padding = new Padding(0, 0, 6, 0);
        lblAmountHeader.Size = new Size(96, 41);
        lblAmountHeader.TabIndex = 4;
        lblAmountHeader.Text = "Tổng tiền";
        lblAmountHeader.TextAlign = ContentAlignment.MiddleRight;
        lblAmountHeader.UseMnemonic = false;
        // 
        // lblPaymentHeader
        // 
        lblPaymentHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblPaymentHeader.Dock = DockStyle.Fill;
        lblPaymentHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblPaymentHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblPaymentHeader.Location = new Point(744, 0);
        lblPaymentHeader.Margin = new Padding(0, 0, 0, 1);
        lblPaymentHeader.Name = "lblPaymentHeader";
        lblPaymentHeader.Size = new Size(110, 41);
        lblPaymentHeader.TabIndex = 5;
        lblPaymentHeader.Text = "Phương thức";
        lblPaymentHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblPaymentHeader.UseMnemonic = false;
        // 
        // lblStatusHeader
        // 
        lblStatusHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblStatusHeader.Dock = DockStyle.Fill;
        lblStatusHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblStatusHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblStatusHeader.Location = new Point(854, 0);
        lblStatusHeader.Margin = new Padding(0, 0, 0, 1);
        lblStatusHeader.Name = "lblStatusHeader";
        lblStatusHeader.Size = new Size(118, 41);
        lblStatusHeader.TabIndex = 6;
        lblStatusHeader.Text = "Trạng thái";
        lblStatusHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblStatusHeader.UseMnemonic = false;
        // 
        // lblActionsHeader
        // 
        lblActionsHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblActionsHeader.Dock = DockStyle.Fill;
        lblActionsHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblActionsHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblActionsHeader.Location = new Point(972, 0);
        lblActionsHeader.Margin = new Padding(0, 0, 0, 1);
        lblActionsHeader.Name = "lblActionsHeader";
        lblActionsHeader.Size = new Size(130, 41);
        lblActionsHeader.TabIndex = 7;
        lblActionsHeader.Text = "Thao tác";
        lblActionsHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblActionsHeader.UseMnemonic = false;
        // 
        // lblCode1
        // 
        lblCode1.BackColor = Color.FromArgb(219, 234, 254);
        lblCode1.Dock = DockStyle.Fill;
        lblCode1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCode1.Location = new Point(0, 42);
        lblCode1.Margin = new Padding(0, 0, 0, 1);
        lblCode1.Name = "lblCode1";
        lblCode1.Padding = new Padding(8, 0, 0, 0);
        lblCode1.Size = new Size(170, 50);
        lblCode1.TabIndex = 8;
        lblCode1.Text = "INV-20261118-042";
        lblCode1.TextAlign = ContentAlignment.MiddleLeft;
        lblCode1.UseMnemonic = false;
        // 
        // lblCreated1
        // 
        lblCreated1.BackColor = Color.FromArgb(219, 234, 254);
        lblCreated1.Dock = DockStyle.Fill;
        lblCreated1.Font = new Font("Segoe UI", 8.5F);
        lblCreated1.Location = new Point(170, 42);
        lblCreated1.Margin = new Padding(0, 0, 0, 1);
        lblCreated1.Name = "lblCreated1";
        lblCreated1.Size = new Size(154, 50);
        lblCreated1.TabIndex = 9;
        lblCreated1.Text = "18:45 · 18/11/2026";
        lblCreated1.TextAlign = ContentAlignment.MiddleCenter;
        lblCreated1.UseMnemonic = false;
        // 
        // lblCustomer1
        // 
        lblCustomer1.BackColor = Color.FromArgb(219, 234, 254);
        lblCustomer1.Dock = DockStyle.Fill;
        lblCustomer1.Font = new Font("Segoe UI", 8.5F);
        lblCustomer1.Location = new Point(324, 42);
        lblCustomer1.Margin = new Padding(0, 0, 0, 1);
        lblCustomer1.Name = "lblCustomer1";
        lblCustomer1.Padding = new Padding(4, 0, 0, 0);
        lblCustomer1.Size = new Size(165, 50);
        lblCustomer1.TabIndex = 10;
        lblCustomer1.Text = "Nguyễn Hoàng Nam\n0901234567";
        lblCustomer1.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomer1.UseMnemonic = false;
        // 
        // lblSummary1
        // 
        lblSummary1.BackColor = Color.FromArgb(219, 234, 254);
        lblSummary1.Dock = DockStyle.Fill;
        lblSummary1.Font = new Font("Segoe UI", 8.5F);
        lblSummary1.Location = new Point(489, 42);
        lblSummary1.Margin = new Padding(0, 0, 0, 1);
        lblSummary1.Name = "lblSummary1";
        lblSummary1.Padding = new Padding(6, 0, 0, 0);
        lblSummary1.Size = new Size(159, 50);
        lblSummary1.TabIndex = 11;
        lblSummary1.Text = "2 vé Lật Mặt 7 +\n1 combo";
        lblSummary1.TextAlign = ContentAlignment.MiddleLeft;
        lblSummary1.UseMnemonic = false;
        // 
        // lblAmount1
        // 
        lblAmount1.BackColor = Color.FromArgb(219, 234, 254);
        lblAmount1.Dock = DockStyle.Fill;
        lblAmount1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAmount1.Location = new Point(648, 42);
        lblAmount1.Margin = new Padding(0, 0, 0, 1);
        lblAmount1.Name = "lblAmount1";
        lblAmount1.Padding = new Padding(0, 0, 6, 0);
        lblAmount1.Size = new Size(96, 50);
        lblAmount1.TabIndex = 12;
        lblAmount1.Text = "319.000 đ";
        lblAmount1.TextAlign = ContentAlignment.MiddleRight;
        lblAmount1.UseMnemonic = false;
        // 
        // lblPayment1
        // 
        lblPayment1.BackColor = Color.FromArgb(219, 234, 254);
        lblPayment1.Dock = DockStyle.Fill;
        lblPayment1.Font = new Font("Segoe UI", 8.5F);
        lblPayment1.Location = new Point(744, 42);
        lblPayment1.Margin = new Padding(0, 0, 0, 1);
        lblPayment1.Name = "lblPayment1";
        lblPayment1.Size = new Size(110, 50);
        lblPayment1.TabIndex = 13;
        lblPayment1.Text = "Tiền mặt";
        lblPayment1.TextAlign = ContentAlignment.MiddleCenter;
        lblPayment1.UseMnemonic = false;
        // 
        // layoutStatus1
        // 
        layoutStatus1.BackColor = Color.FromArgb(219, 234, 254);
        layoutStatus1.ColumnCount = 1;
        layoutStatus1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus1.Controls.Add(lblStatus1, 0, 0);
        layoutStatus1.Dock = DockStyle.Fill;
        layoutStatus1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus1.Location = new Point(854, 42);
        layoutStatus1.Margin = new Padding(0, 0, 0, 1);
        layoutStatus1.Name = "layoutStatus1";
        layoutStatus1.RowCount = 1;
        layoutStatus1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus1.Size = new Size(118, 50);
        layoutStatus1.TabIndex = 14;
        // 
        // lblStatus1
        // 
        lblStatus1.Anchor = AnchorStyles.None;
        lblStatus1.BackColor = Color.FromArgb(220, 252, 231);
        lblStatus1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStatus1.ForeColor = Color.FromArgb(22, 101, 52);
        lblStatus1.Location = new Point(6, 12);
        lblStatus1.Margin = new Padding(0);
        lblStatus1.Name = "lblStatus1";
        lblStatus1.Size = new Size(106, 25);
        lblStatus1.TabIndex = 0;
        lblStatus1.Text = "Đã thanh toán";
        lblStatus1.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus1.UseMnemonic = false;
        // 
        // layoutActions1
        // 
        layoutActions1.BackColor = Color.FromArgb(219, 234, 254);
        layoutActions1.ColumnCount = 1;
        layoutActions1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutActions1.Controls.Add(btnDetails1, 0, 0);
        layoutActions1.Dock = DockStyle.Fill;
        layoutActions1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutActions1.Location = new Point(972, 42);
        layoutActions1.Margin = new Padding(0, 0, 0, 1);
        layoutActions1.Name = "layoutActions1";
        layoutActions1.Padding = new Padding(6, 9, 7, 9);
        layoutActions1.RowCount = 1;
        layoutActions1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions1.Size = new Size(130, 50);
        layoutActions1.TabIndex = 15;
        // 
        // btnDetails1
        // 
        btnDetails1.AccessibleName = "Xem chi tiết hóa đơn INV-20261118-042";
        btnDetails1.BackColor = Color.White;
        btnDetails1.Dock = DockStyle.Fill;
        btnDetails1.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnDetails1.FlatStyle = FlatStyle.Flat;
        btnDetails1.Font = new Font("Segoe UI", 8.25F);
        btnDetails1.ForeColor = Color.FromArgb(37, 99, 235);
        btnDetails1.Location = new Point(6, 9);
        btnDetails1.Margin = new Padding(0);
        btnDetails1.Name = "btnDetails1";
        btnDetails1.Size = new Size(117, 32);
        btnDetails1.TabIndex = 0;
        btnDetails1.Text = "Xem chi tiết ›";
        btnDetails1.UseMnemonic = false;
        btnDetails1.UseVisualStyleBackColor = false;
        // 
        // lblCode2
        // 
        lblCode2.BackColor = Color.White;
        lblCode2.Dock = DockStyle.Fill;
        lblCode2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCode2.Location = new Point(0, 93);
        lblCode2.Margin = new Padding(0, 0, 0, 1);
        lblCode2.Name = "lblCode2";
        lblCode2.Padding = new Padding(8, 0, 0, 0);
        lblCode2.Size = new Size(170, 50);
        lblCode2.TabIndex = 16;
        lblCode2.Text = "INV-20261118-041";
        lblCode2.TextAlign = ContentAlignment.MiddleLeft;
        lblCode2.UseMnemonic = false;
        // 
        // lblCreated2
        // 
        lblCreated2.BackColor = Color.White;
        lblCreated2.Dock = DockStyle.Fill;
        lblCreated2.Font = new Font("Segoe UI", 8.5F);
        lblCreated2.Location = new Point(170, 93);
        lblCreated2.Margin = new Padding(0, 0, 0, 1);
        lblCreated2.Name = "lblCreated2";
        lblCreated2.Size = new Size(154, 50);
        lblCreated2.TabIndex = 17;
        lblCreated2.Text = "17:30 · 18/11/2026";
        lblCreated2.TextAlign = ContentAlignment.MiddleCenter;
        lblCreated2.UseMnemonic = false;
        // 
        // lblCustomer2
        // 
        lblCustomer2.BackColor = Color.White;
        lblCustomer2.Dock = DockStyle.Fill;
        lblCustomer2.Font = new Font("Segoe UI", 8.5F);
        lblCustomer2.Location = new Point(324, 93);
        lblCustomer2.Margin = new Padding(0, 0, 0, 1);
        lblCustomer2.Name = "lblCustomer2";
        lblCustomer2.Padding = new Padding(4, 0, 0, 0);
        lblCustomer2.Size = new Size(165, 50);
        lblCustomer2.TabIndex = 18;
        lblCustomer2.Text = "Trần Ngọc Mai\n0902345678";
        lblCustomer2.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomer2.UseMnemonic = false;
        // 
        // lblSummary2
        // 
        lblSummary2.BackColor = Color.White;
        lblSummary2.Dock = DockStyle.Fill;
        lblSummary2.Font = new Font("Segoe UI", 8.5F);
        lblSummary2.Location = new Point(489, 93);
        lblSummary2.Margin = new Padding(0, 0, 0, 1);
        lblSummary2.Name = "lblSummary2";
        lblSummary2.Padding = new Padding(6, 0, 0, 0);
        lblSummary2.Size = new Size(159, 50);
        lblSummary2.TabIndex = 19;
        lblSummary2.Text = "3 vé Lật Mặt 7";
        lblSummary2.TextAlign = ContentAlignment.MiddleLeft;
        lblSummary2.UseMnemonic = false;
        // 
        // lblAmount2
        // 
        lblAmount2.BackColor = Color.White;
        lblAmount2.Dock = DockStyle.Fill;
        lblAmount2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAmount2.Location = new Point(648, 93);
        lblAmount2.Margin = new Padding(0, 0, 0, 1);
        lblAmount2.Name = "lblAmount2";
        lblAmount2.Padding = new Padding(0, 0, 6, 0);
        lblAmount2.Size = new Size(96, 50);
        lblAmount2.TabIndex = 20;
        lblAmount2.Text = "330.000 đ";
        lblAmount2.TextAlign = ContentAlignment.MiddleRight;
        lblAmount2.UseMnemonic = false;
        // 
        // lblPayment2
        // 
        lblPayment2.BackColor = Color.White;
        lblPayment2.Dock = DockStyle.Fill;
        lblPayment2.Font = new Font("Segoe UI", 8.5F);
        lblPayment2.Location = new Point(744, 93);
        lblPayment2.Margin = new Padding(0, 0, 0, 1);
        lblPayment2.Name = "lblPayment2";
        lblPayment2.Size = new Size(110, 50);
        lblPayment2.TabIndex = 21;
        lblPayment2.Text = "VietQR";
        lblPayment2.TextAlign = ContentAlignment.MiddleCenter;
        lblPayment2.UseMnemonic = false;
        // 
        // layoutStatus2
        // 
        layoutStatus2.BackColor = Color.White;
        layoutStatus2.ColumnCount = 1;
        layoutStatus2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus2.Controls.Add(lblStatus2, 0, 0);
        layoutStatus2.Dock = DockStyle.Fill;
        layoutStatus2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus2.Location = new Point(854, 93);
        layoutStatus2.Margin = new Padding(0, 0, 0, 1);
        layoutStatus2.Name = "layoutStatus2";
        layoutStatus2.RowCount = 1;
        layoutStatus2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus2.Size = new Size(118, 50);
        layoutStatus2.TabIndex = 22;
        // 
        // lblStatus2
        // 
        lblStatus2.Anchor = AnchorStyles.None;
        lblStatus2.BackColor = Color.FromArgb(220, 252, 231);
        lblStatus2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStatus2.ForeColor = Color.FromArgb(22, 101, 52);
        lblStatus2.Location = new Point(6, 12);
        lblStatus2.Margin = new Padding(0);
        lblStatus2.Name = "lblStatus2";
        lblStatus2.Size = new Size(106, 25);
        lblStatus2.TabIndex = 0;
        lblStatus2.Text = "Đã thanh toán";
        lblStatus2.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus2.UseMnemonic = false;
        // 
        // layoutActions2
        // 
        layoutActions2.BackColor = Color.White;
        layoutActions2.ColumnCount = 1;
        layoutActions2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutActions2.Controls.Add(btnDetails2, 0, 0);
        layoutActions2.Dock = DockStyle.Fill;
        layoutActions2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutActions2.Location = new Point(972, 93);
        layoutActions2.Margin = new Padding(0, 0, 0, 1);
        layoutActions2.Name = "layoutActions2";
        layoutActions2.Padding = new Padding(6, 9, 7, 9);
        layoutActions2.RowCount = 1;
        layoutActions2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions2.Size = new Size(130, 50);
        layoutActions2.TabIndex = 23;
        // 
        // btnDetails2
        // 
        btnDetails2.AccessibleName = "Xem chi tiết hóa đơn INV-20261118-041";
        btnDetails2.BackColor = Color.White;
        btnDetails2.Dock = DockStyle.Fill;
        btnDetails2.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnDetails2.FlatStyle = FlatStyle.Flat;
        btnDetails2.Font = new Font("Segoe UI", 8.25F);
        btnDetails2.ForeColor = Color.FromArgb(37, 99, 235);
        btnDetails2.Location = new Point(6, 9);
        btnDetails2.Margin = new Padding(0);
        btnDetails2.Name = "btnDetails2";
        btnDetails2.Size = new Size(117, 32);
        btnDetails2.TabIndex = 0;
        btnDetails2.Text = "Xem chi tiết ›";
        btnDetails2.UseMnemonic = false;
        btnDetails2.UseVisualStyleBackColor = false;
        // 
        // lblCode3
        // 
        lblCode3.BackColor = Color.White;
        lblCode3.Dock = DockStyle.Fill;
        lblCode3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCode3.Location = new Point(0, 144);
        lblCode3.Margin = new Padding(0, 0, 0, 1);
        lblCode3.Name = "lblCode3";
        lblCode3.Padding = new Padding(8, 0, 0, 0);
        lblCode3.Size = new Size(170, 50);
        lblCode3.TabIndex = 24;
        lblCode3.Text = "INV-20261118-040";
        lblCode3.TextAlign = ContentAlignment.MiddleLeft;
        lblCode3.UseMnemonic = false;
        // 
        // lblCreated3
        // 
        lblCreated3.BackColor = Color.White;
        lblCreated3.Dock = DockStyle.Fill;
        lblCreated3.Font = new Font("Segoe UI", 8.5F);
        lblCreated3.Location = new Point(170, 144);
        lblCreated3.Margin = new Padding(0, 0, 0, 1);
        lblCreated3.Name = "lblCreated3";
        lblCreated3.Size = new Size(154, 50);
        lblCreated3.TabIndex = 25;
        lblCreated3.Text = "16:50 · 18/11/2026";
        lblCreated3.TextAlign = ContentAlignment.MiddleCenter;
        lblCreated3.UseMnemonic = false;
        // 
        // lblCustomer3
        // 
        lblCustomer3.BackColor = Color.White;
        lblCustomer3.Dock = DockStyle.Fill;
        lblCustomer3.Font = new Font("Segoe UI", 8.5F);
        lblCustomer3.Location = new Point(324, 144);
        lblCustomer3.Margin = new Padding(0, 0, 0, 1);
        lblCustomer3.Name = "lblCustomer3";
        lblCustomer3.Padding = new Padding(4, 0, 0, 0);
        lblCustomer3.Size = new Size(165, 50);
        lblCustomer3.TabIndex = 26;
        lblCustomer3.Text = "Khách vãng lai";
        lblCustomer3.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomer3.UseMnemonic = false;
        // 
        // lblSummary3
        // 
        lblSummary3.BackColor = Color.White;
        lblSummary3.Dock = DockStyle.Fill;
        lblSummary3.Font = new Font("Segoe UI", 8.5F);
        lblSummary3.Location = new Point(489, 144);
        lblSummary3.Margin = new Padding(0, 0, 0, 1);
        lblSummary3.Name = "lblSummary3";
        lblSummary3.Padding = new Padding(6, 0, 0, 0);
        lblSummary3.Size = new Size(159, 50);
        lblSummary3.TabIndex = 27;
        lblSummary3.Text = "1 vé Lật Mặt 7 +\n1 combo đơn";
        lblSummary3.TextAlign = ContentAlignment.MiddleLeft;
        lblSummary3.UseMnemonic = false;
        // 
        // lblAmount3
        // 
        lblAmount3.BackColor = Color.White;
        lblAmount3.Dock = DockStyle.Fill;
        lblAmount3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAmount3.Location = new Point(648, 144);
        lblAmount3.Margin = new Padding(0, 0, 0, 1);
        lblAmount3.Name = "lblAmount3";
        lblAmount3.Padding = new Padding(0, 0, 6, 0);
        lblAmount3.Size = new Size(96, 50);
        lblAmount3.TabIndex = 28;
        lblAmount3.Text = "189.000 đ";
        lblAmount3.TextAlign = ContentAlignment.MiddleRight;
        lblAmount3.UseMnemonic = false;
        // 
        // lblPayment3
        // 
        lblPayment3.BackColor = Color.White;
        lblPayment3.Dock = DockStyle.Fill;
        lblPayment3.Font = new Font("Segoe UI", 8.5F);
        lblPayment3.Location = new Point(744, 144);
        lblPayment3.Margin = new Padding(0, 0, 0, 1);
        lblPayment3.Name = "lblPayment3";
        lblPayment3.Size = new Size(110, 50);
        lblPayment3.TabIndex = 29;
        lblPayment3.Text = "Tiền mặt";
        lblPayment3.TextAlign = ContentAlignment.MiddleCenter;
        lblPayment3.UseMnemonic = false;
        // 
        // layoutStatus3
        // 
        layoutStatus3.BackColor = Color.White;
        layoutStatus3.ColumnCount = 1;
        layoutStatus3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus3.Controls.Add(lblStatus3, 0, 0);
        layoutStatus3.Dock = DockStyle.Fill;
        layoutStatus3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus3.Location = new Point(854, 144);
        layoutStatus3.Margin = new Padding(0, 0, 0, 1);
        layoutStatus3.Name = "layoutStatus3";
        layoutStatus3.RowCount = 1;
        layoutStatus3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus3.Size = new Size(118, 50);
        layoutStatus3.TabIndex = 30;
        // 
        // lblStatus3
        // 
        lblStatus3.Anchor = AnchorStyles.None;
        lblStatus3.BackColor = Color.FromArgb(220, 252, 231);
        lblStatus3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStatus3.ForeColor = Color.FromArgb(22, 101, 52);
        lblStatus3.Location = new Point(6, 12);
        lblStatus3.Margin = new Padding(0);
        lblStatus3.Name = "lblStatus3";
        lblStatus3.Size = new Size(106, 25);
        lblStatus3.TabIndex = 0;
        lblStatus3.Text = "Đã thanh toán";
        lblStatus3.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus3.UseMnemonic = false;
        // 
        // layoutActions3
        // 
        layoutActions3.BackColor = Color.White;
        layoutActions3.ColumnCount = 1;
        layoutActions3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutActions3.Controls.Add(btnDetails3, 0, 0);
        layoutActions3.Dock = DockStyle.Fill;
        layoutActions3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutActions3.Location = new Point(972, 144);
        layoutActions3.Margin = new Padding(0, 0, 0, 1);
        layoutActions3.Name = "layoutActions3";
        layoutActions3.Padding = new Padding(6, 9, 7, 9);
        layoutActions3.RowCount = 1;
        layoutActions3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions3.Size = new Size(130, 50);
        layoutActions3.TabIndex = 31;
        // 
        // btnDetails3
        // 
        btnDetails3.AccessibleName = "Xem chi tiết hóa đơn INV-20261118-040";
        btnDetails3.BackColor = Color.White;
        btnDetails3.Dock = DockStyle.Fill;
        btnDetails3.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnDetails3.FlatStyle = FlatStyle.Flat;
        btnDetails3.Font = new Font("Segoe UI", 8.25F);
        btnDetails3.ForeColor = Color.FromArgb(37, 99, 235);
        btnDetails3.Location = new Point(6, 9);
        btnDetails3.Margin = new Padding(0);
        btnDetails3.Name = "btnDetails3";
        btnDetails3.Size = new Size(117, 32);
        btnDetails3.TabIndex = 0;
        btnDetails3.Text = "Xem chi tiết ›";
        btnDetails3.UseMnemonic = false;
        btnDetails3.UseVisualStyleBackColor = false;
        // 
        // lblCode4
        // 
        lblCode4.BackColor = Color.White;
        lblCode4.Dock = DockStyle.Fill;
        lblCode4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCode4.Location = new Point(0, 195);
        lblCode4.Margin = new Padding(0, 0, 0, 1);
        lblCode4.Name = "lblCode4";
        lblCode4.Padding = new Padding(8, 0, 0, 0);
        lblCode4.Size = new Size(170, 50);
        lblCode4.TabIndex = 32;
        lblCode4.Text = "INV-20261118-039";
        lblCode4.TextAlign = ContentAlignment.MiddleLeft;
        lblCode4.UseMnemonic = false;
        // 
        // lblCreated4
        // 
        lblCreated4.BackColor = Color.White;
        lblCreated4.Dock = DockStyle.Fill;
        lblCreated4.Font = new Font("Segoe UI", 8.5F);
        lblCreated4.Location = new Point(170, 195);
        lblCreated4.Margin = new Padding(0, 0, 0, 1);
        lblCreated4.Name = "lblCreated4";
        lblCreated4.Size = new Size(154, 50);
        lblCreated4.TabIndex = 33;
        lblCreated4.Text = "16:05 · 18/11/2026";
        lblCreated4.TextAlign = ContentAlignment.MiddleCenter;
        lblCreated4.UseMnemonic = false;
        // 
        // lblCustomer4
        // 
        lblCustomer4.BackColor = Color.White;
        lblCustomer4.Dock = DockStyle.Fill;
        lblCustomer4.Font = new Font("Segoe UI", 8.5F);
        lblCustomer4.Location = new Point(324, 195);
        lblCustomer4.Margin = new Padding(0, 0, 0, 1);
        lblCustomer4.Name = "lblCustomer4";
        lblCustomer4.Padding = new Padding(4, 0, 0, 0);
        lblCustomer4.Size = new Size(165, 50);
        lblCustomer4.TabIndex = 34;
        lblCustomer4.Text = "Lê Minh Quân\n0903456789";
        lblCustomer4.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomer4.UseMnemonic = false;
        // 
        // lblSummary4
        // 
        lblSummary4.BackColor = Color.White;
        lblSummary4.Dock = DockStyle.Fill;
        lblSummary4.Font = new Font("Segoe UI", 8.5F);
        lblSummary4.Location = new Point(489, 195);
        lblSummary4.Margin = new Padding(0, 0, 0, 1);
        lblSummary4.Name = "lblSummary4";
        lblSummary4.Padding = new Padding(6, 0, 0, 0);
        lblSummary4.Size = new Size(159, 50);
        lblSummary4.TabIndex = 35;
        lblSummary4.Text = "2 vé Siêu Nhân";
        lblSummary4.TextAlign = ContentAlignment.MiddleLeft;
        lblSummary4.UseMnemonic = false;
        // 
        // lblAmount4
        // 
        lblAmount4.BackColor = Color.White;
        lblAmount4.Dock = DockStyle.Fill;
        lblAmount4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAmount4.Location = new Point(648, 195);
        lblAmount4.Margin = new Padding(0, 0, 0, 1);
        lblAmount4.Name = "lblAmount4";
        lblAmount4.Padding = new Padding(0, 0, 6, 0);
        lblAmount4.Size = new Size(96, 50);
        lblAmount4.TabIndex = 36;
        lblAmount4.Text = "220.000 đ";
        lblAmount4.TextAlign = ContentAlignment.MiddleRight;
        lblAmount4.UseMnemonic = false;
        // 
        // lblPayment4
        // 
        lblPayment4.BackColor = Color.White;
        lblPayment4.Dock = DockStyle.Fill;
        lblPayment4.Font = new Font("Segoe UI", 8.5F);
        lblPayment4.Location = new Point(744, 195);
        lblPayment4.Margin = new Padding(0, 0, 0, 1);
        lblPayment4.Name = "lblPayment4";
        lblPayment4.Size = new Size(110, 50);
        lblPayment4.TabIndex = 37;
        lblPayment4.Text = "VietQR";
        lblPayment4.TextAlign = ContentAlignment.MiddleCenter;
        lblPayment4.UseMnemonic = false;
        // 
        // layoutStatus4
        // 
        layoutStatus4.BackColor = Color.White;
        layoutStatus4.ColumnCount = 1;
        layoutStatus4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus4.Controls.Add(lblStatus4, 0, 0);
        layoutStatus4.Dock = DockStyle.Fill;
        layoutStatus4.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus4.Location = new Point(854, 195);
        layoutStatus4.Margin = new Padding(0, 0, 0, 1);
        layoutStatus4.Name = "layoutStatus4";
        layoutStatus4.RowCount = 1;
        layoutStatus4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus4.Size = new Size(118, 50);
        layoutStatus4.TabIndex = 38;
        // 
        // lblStatus4
        // 
        lblStatus4.Anchor = AnchorStyles.None;
        lblStatus4.BackColor = Color.FromArgb(220, 252, 231);
        lblStatus4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStatus4.ForeColor = Color.FromArgb(22, 101, 52);
        lblStatus4.Location = new Point(6, 12);
        lblStatus4.Margin = new Padding(0);
        lblStatus4.Name = "lblStatus4";
        lblStatus4.Size = new Size(106, 25);
        lblStatus4.TabIndex = 0;
        lblStatus4.Text = "Đã thanh toán";
        lblStatus4.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus4.UseMnemonic = false;
        // 
        // layoutActions4
        // 
        layoutActions4.BackColor = Color.White;
        layoutActions4.ColumnCount = 1;
        layoutActions4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutActions4.Controls.Add(btnDetails4, 0, 0);
        layoutActions4.Dock = DockStyle.Fill;
        layoutActions4.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutActions4.Location = new Point(972, 195);
        layoutActions4.Margin = new Padding(0, 0, 0, 1);
        layoutActions4.Name = "layoutActions4";
        layoutActions4.Padding = new Padding(6, 9, 7, 9);
        layoutActions4.RowCount = 1;
        layoutActions4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions4.Size = new Size(130, 50);
        layoutActions4.TabIndex = 39;
        // 
        // btnDetails4
        // 
        btnDetails4.AccessibleName = "Xem chi tiết hóa đơn INV-20261118-039";
        btnDetails4.BackColor = Color.White;
        btnDetails4.Dock = DockStyle.Fill;
        btnDetails4.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnDetails4.FlatStyle = FlatStyle.Flat;
        btnDetails4.Font = new Font("Segoe UI", 8.25F);
        btnDetails4.ForeColor = Color.FromArgb(37, 99, 235);
        btnDetails4.Location = new Point(6, 9);
        btnDetails4.Margin = new Padding(0);
        btnDetails4.Name = "btnDetails4";
        btnDetails4.Size = new Size(117, 32);
        btnDetails4.TabIndex = 0;
        btnDetails4.Text = "Xem chi tiết ›";
        btnDetails4.UseMnemonic = false;
        btnDetails4.UseVisualStyleBackColor = false;
        // 
        // lblCode5
        // 
        lblCode5.BackColor = Color.White;
        lblCode5.Dock = DockStyle.Fill;
        lblCode5.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCode5.Location = new Point(0, 246);
        lblCode5.Margin = new Padding(0, 0, 0, 1);
        lblCode5.Name = "lblCode5";
        lblCode5.Padding = new Padding(8, 0, 0, 0);
        lblCode5.Size = new Size(170, 50);
        lblCode5.TabIndex = 40;
        lblCode5.Text = "INV-20261118-038";
        lblCode5.TextAlign = ContentAlignment.MiddleLeft;
        lblCode5.UseMnemonic = false;
        // 
        // lblCreated5
        // 
        lblCreated5.BackColor = Color.White;
        lblCreated5.Dock = DockStyle.Fill;
        lblCreated5.Font = new Font("Segoe UI", 8.5F);
        lblCreated5.Location = new Point(170, 246);
        lblCreated5.Margin = new Padding(0, 0, 0, 1);
        lblCreated5.Name = "lblCreated5";
        lblCreated5.Size = new Size(154, 50);
        lblCreated5.TabIndex = 41;
        lblCreated5.Text = "15:20 · 18/11/2026";
        lblCreated5.TextAlign = ContentAlignment.MiddleCenter;
        lblCreated5.UseMnemonic = false;
        // 
        // lblCustomer5
        // 
        lblCustomer5.BackColor = Color.White;
        lblCustomer5.Dock = DockStyle.Fill;
        lblCustomer5.Font = new Font("Segoe UI", 8.5F);
        lblCustomer5.Location = new Point(324, 246);
        lblCustomer5.Margin = new Padding(0, 0, 0, 1);
        lblCustomer5.Name = "lblCustomer5";
        lblCustomer5.Padding = new Padding(4, 0, 0, 0);
        lblCustomer5.Size = new Size(165, 50);
        lblCustomer5.TabIndex = 42;
        lblCustomer5.Text = "Khách vãng lai";
        lblCustomer5.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomer5.UseMnemonic = false;
        // 
        // lblSummary5
        // 
        lblSummary5.BackColor = Color.White;
        lblSummary5.Dock = DockStyle.Fill;
        lblSummary5.Font = new Font("Segoe UI", 8.5F);
        lblSummary5.Location = new Point(489, 246);
        lblSummary5.Margin = new Padding(0, 0, 0, 1);
        lblSummary5.Name = "lblSummary5";
        lblSummary5.Padding = new Padding(6, 0, 0, 0);
        lblSummary5.Size = new Size(159, 50);
        lblSummary5.TabIndex = 43;
        lblSummary5.Text = "1 vé Lật Mặt 7";
        lblSummary5.TextAlign = ContentAlignment.MiddleLeft;
        lblSummary5.UseMnemonic = false;
        // 
        // lblAmount5
        // 
        lblAmount5.BackColor = Color.White;
        lblAmount5.Dock = DockStyle.Fill;
        lblAmount5.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAmount5.Location = new Point(648, 246);
        lblAmount5.Margin = new Padding(0, 0, 0, 1);
        lblAmount5.Name = "lblAmount5";
        lblAmount5.Padding = new Padding(0, 0, 6, 0);
        lblAmount5.Size = new Size(96, 50);
        lblAmount5.TabIndex = 44;
        lblAmount5.Text = "110.000 đ";
        lblAmount5.TextAlign = ContentAlignment.MiddleRight;
        lblAmount5.UseMnemonic = false;
        // 
        // lblPayment5
        // 
        lblPayment5.BackColor = Color.White;
        lblPayment5.Dock = DockStyle.Fill;
        lblPayment5.Font = new Font("Segoe UI", 8.5F);
        lblPayment5.Location = new Point(744, 246);
        lblPayment5.Margin = new Padding(0, 0, 0, 1);
        lblPayment5.Name = "lblPayment5";
        lblPayment5.Size = new Size(110, 50);
        lblPayment5.TabIndex = 45;
        lblPayment5.Text = "Tiền mặt";
        lblPayment5.TextAlign = ContentAlignment.MiddleCenter;
        lblPayment5.UseMnemonic = false;
        // 
        // layoutStatus5
        // 
        layoutStatus5.BackColor = Color.White;
        layoutStatus5.ColumnCount = 1;
        layoutStatus5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus5.Controls.Add(lblStatus5, 0, 0);
        layoutStatus5.Dock = DockStyle.Fill;
        layoutStatus5.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus5.Location = new Point(854, 246);
        layoutStatus5.Margin = new Padding(0, 0, 0, 1);
        layoutStatus5.Name = "layoutStatus5";
        layoutStatus5.RowCount = 1;
        layoutStatus5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus5.Size = new Size(118, 50);
        layoutStatus5.TabIndex = 46;
        // 
        // lblStatus5
        // 
        lblStatus5.Anchor = AnchorStyles.None;
        lblStatus5.BackColor = Color.FromArgb(254, 226, 226);
        lblStatus5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStatus5.ForeColor = Color.FromArgb(185, 28, 28);
        lblStatus5.Location = new Point(6, 12);
        lblStatus5.Margin = new Padding(0);
        lblStatus5.Name = "lblStatus5";
        lblStatus5.Size = new Size(106, 25);
        lblStatus5.TabIndex = 0;
        lblStatus5.Text = "Đã hủy";
        lblStatus5.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus5.UseMnemonic = false;
        // 
        // layoutActions5
        // 
        layoutActions5.BackColor = Color.White;
        layoutActions5.ColumnCount = 1;
        layoutActions5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutActions5.Controls.Add(btnDetails5, 0, 0);
        layoutActions5.Dock = DockStyle.Fill;
        layoutActions5.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutActions5.Location = new Point(972, 246);
        layoutActions5.Margin = new Padding(0, 0, 0, 1);
        layoutActions5.Name = "layoutActions5";
        layoutActions5.Padding = new Padding(6, 9, 7, 9);
        layoutActions5.RowCount = 1;
        layoutActions5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions5.Size = new Size(130, 50);
        layoutActions5.TabIndex = 47;
        // 
        // btnDetails5
        // 
        btnDetails5.AccessibleName = "Xem chi tiết hóa đơn INV-20261118-038";
        btnDetails5.BackColor = Color.White;
        btnDetails5.Dock = DockStyle.Fill;
        btnDetails5.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnDetails5.FlatStyle = FlatStyle.Flat;
        btnDetails5.Font = new Font("Segoe UI", 8.25F);
        btnDetails5.ForeColor = Color.FromArgb(37, 99, 235);
        btnDetails5.Location = new Point(6, 9);
        btnDetails5.Margin = new Padding(0);
        btnDetails5.Name = "btnDetails5";
        btnDetails5.Size = new Size(117, 32);
        btnDetails5.TabIndex = 0;
        btnDetails5.Text = "Xem chi tiết ›";
        btnDetails5.UseMnemonic = false;
        btnDetails5.UseVisualStyleBackColor = false;
        // 
        // lblCode6
        // 
        lblCode6.BackColor = Color.White;
        lblCode6.Dock = DockStyle.Fill;
        lblCode6.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCode6.Location = new Point(0, 297);
        lblCode6.Margin = new Padding(0);
        lblCode6.Name = "lblCode6";
        lblCode6.Padding = new Padding(8, 0, 0, 0);
        lblCode6.Size = new Size(170, 51);
        lblCode6.TabIndex = 48;
        lblCode6.Text = "INV-20261118-037";
        lblCode6.TextAlign = ContentAlignment.MiddleLeft;
        lblCode6.UseMnemonic = false;
        // 
        // lblCreated6
        // 
        lblCreated6.BackColor = Color.White;
        lblCreated6.Dock = DockStyle.Fill;
        lblCreated6.Font = new Font("Segoe UI", 8.5F);
        lblCreated6.Location = new Point(170, 297);
        lblCreated6.Margin = new Padding(0);
        lblCreated6.Name = "lblCreated6";
        lblCreated6.Size = new Size(154, 51);
        lblCreated6.TabIndex = 49;
        lblCreated6.Text = "14:55 · 18/11/2026";
        lblCreated6.TextAlign = ContentAlignment.MiddleCenter;
        lblCreated6.UseMnemonic = false;
        // 
        // lblCustomer6
        // 
        lblCustomer6.BackColor = Color.White;
        lblCustomer6.Dock = DockStyle.Fill;
        lblCustomer6.Font = new Font("Segoe UI", 8.5F);
        lblCustomer6.Location = new Point(324, 297);
        lblCustomer6.Margin = new Padding(0);
        lblCustomer6.Name = "lblCustomer6";
        lblCustomer6.Padding = new Padding(4, 0, 0, 0);
        lblCustomer6.Size = new Size(165, 51);
        lblCustomer6.TabIndex = 50;
        lblCustomer6.Text = "Vũ Đức Anh\n0905678901";
        lblCustomer6.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomer6.UseMnemonic = false;
        // 
        // lblSummary6
        // 
        lblSummary6.BackColor = Color.White;
        lblSummary6.Dock = DockStyle.Fill;
        lblSummary6.Font = new Font("Segoe UI", 8.5F);
        lblSummary6.Location = new Point(489, 297);
        lblSummary6.Margin = new Padding(0);
        lblSummary6.Name = "lblSummary6";
        lblSummary6.Padding = new Padding(6, 0, 0, 0);
        lblSummary6.Size = new Size(159, 51);
        lblSummary6.TabIndex = 51;
        lblSummary6.Text = "2 vé Hoàng Tử Bé\n+ 1 combo đôi";
        lblSummary6.TextAlign = ContentAlignment.MiddleLeft;
        lblSummary6.UseMnemonic = false;
        // 
        // lblAmount6
        // 
        lblAmount6.BackColor = Color.White;
        lblAmount6.Dock = DockStyle.Fill;
        lblAmount6.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAmount6.Location = new Point(648, 297);
        lblAmount6.Margin = new Padding(0);
        lblAmount6.Name = "lblAmount6";
        lblAmount6.Padding = new Padding(0, 0, 6, 0);
        lblAmount6.Size = new Size(96, 51);
        lblAmount6.TabIndex = 52;
        lblAmount6.Text = "319.000 đ";
        lblAmount6.TextAlign = ContentAlignment.MiddleRight;
        lblAmount6.UseMnemonic = false;
        // 
        // lblPayment6
        // 
        lblPayment6.BackColor = Color.White;
        lblPayment6.Dock = DockStyle.Fill;
        lblPayment6.Font = new Font("Segoe UI", 8.5F);
        lblPayment6.Location = new Point(744, 297);
        lblPayment6.Margin = new Padding(0);
        lblPayment6.Name = "lblPayment6";
        lblPayment6.Size = new Size(110, 51);
        lblPayment6.TabIndex = 53;
        lblPayment6.Text = "VietQR";
        lblPayment6.TextAlign = ContentAlignment.MiddleCenter;
        lblPayment6.UseMnemonic = false;
        // 
        // layoutStatus6
        // 
        layoutStatus6.BackColor = Color.White;
        layoutStatus6.ColumnCount = 1;
        layoutStatus6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus6.Controls.Add(lblStatus6, 0, 0);
        layoutStatus6.Dock = DockStyle.Fill;
        layoutStatus6.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus6.Location = new Point(854, 297);
        layoutStatus6.Margin = new Padding(0);
        layoutStatus6.Name = "layoutStatus6";
        layoutStatus6.RowCount = 1;
        layoutStatus6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus6.Size = new Size(118, 51);
        layoutStatus6.TabIndex = 54;
        // 
        // lblStatus6
        // 
        lblStatus6.Anchor = AnchorStyles.None;
        lblStatus6.BackColor = Color.FromArgb(220, 252, 231);
        lblStatus6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStatus6.ForeColor = Color.FromArgb(22, 101, 52);
        lblStatus6.Location = new Point(6, 13);
        lblStatus6.Margin = new Padding(0);
        lblStatus6.Name = "lblStatus6";
        lblStatus6.Size = new Size(106, 25);
        lblStatus6.TabIndex = 0;
        lblStatus6.Text = "Đã thanh toán";
        lblStatus6.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus6.UseMnemonic = false;
        // 
        // layoutActions6
        // 
        layoutActions6.BackColor = Color.White;
        layoutActions6.ColumnCount = 1;
        layoutActions6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutActions6.Controls.Add(btnDetails6, 0, 0);
        layoutActions6.Dock = DockStyle.Fill;
        layoutActions6.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutActions6.Location = new Point(972, 297);
        layoutActions6.Margin = new Padding(0);
        layoutActions6.Name = "layoutActions6";
        layoutActions6.Padding = new Padding(6, 9, 7, 9);
        layoutActions6.RowCount = 1;
        layoutActions6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions6.Size = new Size(130, 51);
        layoutActions6.TabIndex = 55;
        // 
        // btnDetails6
        // 
        btnDetails6.AccessibleName = "Xem chi tiết hóa đơn INV-20261118-037";
        btnDetails6.BackColor = Color.White;
        btnDetails6.Dock = DockStyle.Fill;
        btnDetails6.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnDetails6.FlatStyle = FlatStyle.Flat;
        btnDetails6.Font = new Font("Segoe UI", 8.25F);
        btnDetails6.ForeColor = Color.FromArgb(37, 99, 235);
        btnDetails6.Location = new Point(6, 9);
        btnDetails6.Margin = new Padding(0);
        btnDetails6.Name = "btnDetails6";
        btnDetails6.Size = new Size(117, 33);
        btnDetails6.TabIndex = 0;
        btnDetails6.Text = "Xem chi tiết ›";
        btnDetails6.UseMnemonic = false;
        btnDetails6.UseVisualStyleBackColor = false;
        // 
        // pnlPagination
        // 
        pnlPagination.BackColor = Color.FromArgb(226, 232, 240);
        pnlPagination.Controls.Add(layoutPagination);
        pnlPagination.Dock = DockStyle.Fill;
        pnlPagination.Location = new Point(16, 540);
        pnlPagination.Margin = new Padding(0, 12, 0, 0);
        pnlPagination.Name = "pnlPagination";
        pnlPagination.Padding = new Padding(1);
        pnlPagination.Size = new Size(1104, 51);
        pnlPagination.TabIndex = 4;
        // 
        // layoutPagination
        // 
        layoutPagination.BackColor = Color.White;
        layoutPagination.ColumnCount = 7;
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
        layoutPagination.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
        layoutPagination.Controls.Add(lblInvoiceCount, 0, 0);
        layoutPagination.Controls.Add(btnPreviousPage, 1, 0);
        layoutPagination.Controls.Add(btnPage1, 2, 0);
        layoutPagination.Controls.Add(btnPage2, 3, 0);
        layoutPagination.Controls.Add(lblPageGap, 4, 0);
        layoutPagination.Controls.Add(btnPage7, 5, 0);
        layoutPagination.Controls.Add(btnNextPage, 6, 0);
        layoutPagination.Dock = DockStyle.Fill;
        layoutPagination.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPagination.Location = new Point(1, 1);
        layoutPagination.Margin = new Padding(0);
        layoutPagination.Name = "layoutPagination";
        layoutPagination.Padding = new Padding(12, 9, 9, 9);
        layoutPagination.RowCount = 1;
        layoutPagination.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPagination.Size = new Size(1102, 49);
        layoutPagination.TabIndex = 0;
        // 
        // lblInvoiceCount
        // 
        lblInvoiceCount.Dock = DockStyle.Fill;
        lblInvoiceCount.Font = new Font("Segoe UI", 9F);
        lblInvoiceCount.ForeColor = Color.FromArgb(100, 116, 139);
        lblInvoiceCount.Location = new Point(12, 9);
        lblInvoiceCount.Margin = new Padding(0);
        lblInvoiceCount.Name = "lblInvoiceCount";
        lblInvoiceCount.Size = new Size(854, 31);
        lblInvoiceCount.TabIndex = 0;
        lblInvoiceCount.Text = "Hiển thị 1–6 / 42 hóa đơn";
        lblInvoiceCount.TextAlign = ContentAlignment.MiddleLeft;
        lblInvoiceCount.UseMnemonic = false;
        // 
        // btnPreviousPage
        // 
        btnPreviousPage.AccessibleName = "Trang trước";
        btnPreviousPage.BackColor = Color.White;
        btnPreviousPage.Dock = DockStyle.Fill;
        btnPreviousPage.Enabled = false;
        btnPreviousPage.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnPreviousPage.FlatStyle = FlatStyle.Flat;
        btnPreviousPage.Font = new Font("Segoe UI", 9F);
        btnPreviousPage.ForeColor = Color.FromArgb(15, 23, 42);
        btnPreviousPage.Location = new Point(866, 9);
        btnPreviousPage.Margin = new Padding(0, 0, 5, 0);
        btnPreviousPage.Name = "btnPreviousPage";
        btnPreviousPage.Size = new Size(34, 31);
        btnPreviousPage.TabIndex = 1;
        btnPreviousPage.Text = "‹";
        btnPreviousPage.UseMnemonic = false;
        btnPreviousPage.UseVisualStyleBackColor = false;
        // 
        // btnPage1
        // 
        btnPage1.AccessibleName = "Trang 1";
        btnPage1.BackColor = Color.FromArgb(37, 99, 235);
        btnPage1.Dock = DockStyle.Fill;
        btnPage1.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnPage1.FlatAppearance.BorderSize = 0;
        btnPage1.FlatStyle = FlatStyle.Flat;
        btnPage1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnPage1.ForeColor = Color.White;
        btnPage1.Location = new Point(905, 9);
        btnPage1.Margin = new Padding(0, 0, 5, 0);
        btnPage1.Name = "btnPage1";
        btnPage1.Size = new Size(34, 31);
        btnPage1.TabIndex = 2;
        btnPage1.Text = "1";
        btnPage1.UseMnemonic = false;
        btnPage1.UseVisualStyleBackColor = false;
        // 
        // btnPage2
        // 
        btnPage2.AccessibleName = "Trang 2";
        btnPage2.BackColor = Color.White;
        btnPage2.Dock = DockStyle.Fill;
        btnPage2.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnPage2.FlatStyle = FlatStyle.Flat;
        btnPage2.Font = new Font("Segoe UI", 9F);
        btnPage2.ForeColor = Color.FromArgb(15, 23, 42);
        btnPage2.Location = new Point(944, 9);
        btnPage2.Margin = new Padding(0, 0, 5, 0);
        btnPage2.Name = "btnPage2";
        btnPage2.Size = new Size(34, 31);
        btnPage2.TabIndex = 3;
        btnPage2.Text = "2";
        btnPage2.UseMnemonic = false;
        btnPage2.UseVisualStyleBackColor = false;
        // 
        // lblPageGap
        // 
        lblPageGap.Dock = DockStyle.Fill;
        lblPageGap.ForeColor = Color.FromArgb(100, 116, 139);
        lblPageGap.Location = new Point(983, 9);
        lblPageGap.Margin = new Padding(0);
        lblPageGap.Name = "lblPageGap";
        lblPageGap.Size = new Size(32, 31);
        lblPageGap.TabIndex = 4;
        lblPageGap.Text = "…";
        lblPageGap.TextAlign = ContentAlignment.MiddleCenter;
        lblPageGap.UseMnemonic = false;
        // 
        // btnPage7
        // 
        btnPage7.AccessibleName = "Trang 7";
        btnPage7.BackColor = Color.White;
        btnPage7.Dock = DockStyle.Fill;
        btnPage7.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnPage7.FlatStyle = FlatStyle.Flat;
        btnPage7.Font = new Font("Segoe UI", 9F);
        btnPage7.ForeColor = Color.FromArgb(15, 23, 42);
        btnPage7.Location = new Point(1015, 9);
        btnPage7.Margin = new Padding(0, 0, 5, 0);
        btnPage7.Name = "btnPage7";
        btnPage7.Size = new Size(34, 31);
        btnPage7.TabIndex = 5;
        btnPage7.Text = "7";
        btnPage7.UseMnemonic = false;
        btnPage7.UseVisualStyleBackColor = false;
        // 
        // btnNextPage
        // 
        btnNextPage.AccessibleName = "Trang sau";
        btnNextPage.BackColor = Color.White;
        btnNextPage.Dock = DockStyle.Fill;
        btnNextPage.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnNextPage.FlatStyle = FlatStyle.Flat;
        btnNextPage.Font = new Font("Segoe UI", 9F);
        btnNextPage.ForeColor = Color.FromArgb(15, 23, 42);
        btnNextPage.Location = new Point(1054, 9);
        btnNextPage.Margin = new Padding(0);
        btnNextPage.Name = "btnNextPage";
        btnNextPage.Size = new Size(39, 31);
        btnNextPage.TabIndex = 6;
        btnNextPage.Text = "›";
        btnNextPage.UseMnemonic = false;
        btnNextPage.UseVisualStyleBackColor = false;
        // 
        // OrderListView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "OrderListView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        layoutSearchBar.ResumeLayout(false);
        pnlSearch.ResumeLayout(false);
        layoutSearch.ResumeLayout(false);
        layoutSearch.PerformLayout();
        layoutFilters.ResumeLayout(false);
        pnlDateFilter.ResumeLayout(false);
        layoutDateFilter.ResumeLayout(false);
        pnlPaymentFilter.ResumeLayout(false);
        layoutPaymentFilter.ResumeLayout(false);
        pnlStatusFilter.ResumeLayout(false);
        layoutStatusFilter.ResumeLayout(false);
        pnlOrders.ResumeLayout(false);
        layoutOrders.ResumeLayout(false);
        layoutStatus1.ResumeLayout(false);
        layoutActions1.ResumeLayout(false);
        layoutStatus2.ResumeLayout(false);
        layoutActions2.ResumeLayout(false);
        layoutStatus3.ResumeLayout(false);
        layoutActions3.ResumeLayout(false);
        layoutStatus4.ResumeLayout(false);
        layoutActions4.ResumeLayout(false);
        layoutStatus5.ResumeLayout(false);
        layoutActions5.ResumeLayout(false);
        layoutStatus6.ResumeLayout(false);
        layoutActions6.ResumeLayout(false);
        pnlPagination.ResumeLayout(false);
        layoutPagination.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private Label lblTitle;
    private TableLayoutPanel layoutSearchBar;
    private Panel pnlSearch;
    private TableLayoutPanel layoutSearch;
    private Label lblSearchIcon;
    private TextBox txtSearch;
    private Button btnSearch;
    private TableLayoutPanel layoutFilters;
    private Panel pnlDateFilter;
    private TableLayoutPanel layoutDateFilter;
    private Label lblDateFilter;
    private DateTimePicker dtpTransactionDate;
    private Panel pnlPaymentFilter;
    private TableLayoutPanel layoutPaymentFilter;
    private ComboBox cmbPaymentFilter;
    private Panel pnlStatusFilter;
    private TableLayoutPanel layoutStatusFilter;
    private ComboBox cmbStatusFilter;
    private Panel pnlOrders;
    private TableLayoutPanel layoutOrders;
    private Label lblCodeHeader;
    private Label lblCreatedHeader;
    private Label lblCustomerHeader;
    private Label lblSummaryHeader;
    private Label lblAmountHeader;
    private Label lblPaymentHeader;
    private Label lblStatusHeader;
    private Label lblActionsHeader;
    private Label lblCode1;
    private Label lblCreated1;
    private Label lblCustomer1;
    private Label lblSummary1;
    private Label lblAmount1;
    private Label lblPayment1;
    private TableLayoutPanel layoutStatus1;
    private Label lblStatus1;
    private TableLayoutPanel layoutActions1;
    private Button btnDetails1;
    private Label lblCode2;
    private Label lblCreated2;
    private Label lblCustomer2;
    private Label lblSummary2;
    private Label lblAmount2;
    private Label lblPayment2;
    private TableLayoutPanel layoutStatus2;
    private Label lblStatus2;
    private TableLayoutPanel layoutActions2;
    private Button btnDetails2;
    private Label lblCode3;
    private Label lblCreated3;
    private Label lblCustomer3;
    private Label lblSummary3;
    private Label lblAmount3;
    private Label lblPayment3;
    private TableLayoutPanel layoutStatus3;
    private Label lblStatus3;
    private TableLayoutPanel layoutActions3;
    private Button btnDetails3;
    private Label lblCode4;
    private Label lblCreated4;
    private Label lblCustomer4;
    private Label lblSummary4;
    private Label lblAmount4;
    private Label lblPayment4;
    private TableLayoutPanel layoutStatus4;
    private Label lblStatus4;
    private TableLayoutPanel layoutActions4;
    private Button btnDetails4;
    private Label lblCode5;
    private Label lblCreated5;
    private Label lblCustomer5;
    private Label lblSummary5;
    private Label lblAmount5;
    private Label lblPayment5;
    private TableLayoutPanel layoutStatus5;
    private Label lblStatus5;
    private TableLayoutPanel layoutActions5;
    private Button btnDetails5;
    private Label lblCode6;
    private Label lblCreated6;
    private Label lblCustomer6;
    private Label lblSummary6;
    private Label lblAmount6;
    private Label lblPayment6;
    private TableLayoutPanel layoutStatus6;
    private Label lblStatus6;
    private TableLayoutPanel layoutActions6;
    private Button btnDetails6;
    private Panel pnlPagination;
    private TableLayoutPanel layoutPagination;
    private Label lblInvoiceCount;
    private Button btnPreviousPage;
    private Button btnPage1;
    private Button btnPage2;
    private Label lblPageGap;
    private Button btnPage7;
    private Button btnNextPage;
}

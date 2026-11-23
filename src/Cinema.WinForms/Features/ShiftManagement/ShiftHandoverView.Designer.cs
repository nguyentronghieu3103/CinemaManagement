namespace Cinema.WinForms.Features.ShiftManagement;

partial class ShiftHandoverView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        layoutHeading = new TableLayoutPanel();
        lblTitle = new Label();
        lblShiftDetails = new Label();
        layoutCards = new TableLayoutPanel();
        pnlSystemCash = new Panel();
        layoutSystemCash = new TableLayoutPanel();
        lblSystemCashTitle = new Label();
        pnlSystemTitleDivider = new Panel();
        lblOpeningCashCaption = new Label();
        lblOpeningCashValue = new Label();
        pnlOpeningCashDivider = new Panel();
        lblCashReceivedCaption = new Label();
        lblCashReceivedValue = new Label();
        pnlCashReceivedDivider = new Panel();
        lblCashRefundCaption = new Label();
        lblCashRefundValue = new Label();
        pnlCashRefundDivider = new Panel();
        layoutExpectedCash = new TableLayoutPanel();
        lblExpectedCashCaption = new Label();
        lblExpectedCashValue = new Label();
        pnlCashCount = new Panel();
        layoutCashCount = new TableLayoutPanel();
        lblCashCountTitle = new Label();
        pnlDenominations = new Panel();
        layoutDenominations = new TableLayoutPanel();
        lblDenominationHeader = new Label();
        lblBillCountHeader = new Label();
        lblAmountHeader = new Label();
        lblDenomination500000 = new Label();
        layoutBills500000 = new TableLayoutPanel();
        txtBills500000 = new TextBox();
        lblAmount500000 = new Label();
        lblDenomination200000 = new Label();
        layoutBills200000 = new TableLayoutPanel();
        txtBills200000 = new TextBox();
        lblAmount200000 = new Label();
        lblDenomination100000 = new Label();
        layoutBills100000 = new TableLayoutPanel();
        txtBills100000 = new TextBox();
        lblAmount100000 = new Label();
        lblDenomination50000 = new Label();
        layoutBills50000 = new TableLayoutPanel();
        txtBills50000 = new TextBox();
        lblAmount50000 = new Label();
        lblDenomination20000 = new Label();
        layoutBills20000 = new TableLayoutPanel();
        txtBills20000 = new TextBox();
        lblAmount20000 = new Label();
        lblDenomination10000 = new Label();
        layoutBills10000 = new TableLayoutPanel();
        txtBills10000 = new TextBox();
        lblAmount10000 = new Label();
        lblDenomination5000 = new Label();
        layoutBills5000 = new TableLayoutPanel();
        txtBills5000 = new TextBox();
        lblAmount5000 = new Label();
        lblDenomination2000 = new Label();
        layoutBills2000 = new TableLayoutPanel();
        txtBills2000 = new TextBox();
        lblAmount2000 = new Label();
        lblDenomination1000 = new Label();
        layoutBills1000 = new TableLayoutPanel();
        txtBills1000 = new TextBox();
        lblAmount1000 = new Label();
        layoutCountedCash = new TableLayoutPanel();
        lblCountedCashCaption = new Label();
        lblCountedCashValue = new Label();
        lblVariance = new Label();
        layoutHandoverNote = new TableLayoutPanel();
        lblHandoverNote = new Label();
        txtHandoverNote = new TextBox();
        pnlFooter = new Panel();
        layoutFooter = new TableLayoutPanel();
        btnBackToOverview = new Button();
        btnSubmitHandover = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        layoutHeading.SuspendLayout();
        layoutCards.SuspendLayout();
        pnlSystemCash.SuspendLayout();
        layoutSystemCash.SuspendLayout();
        layoutExpectedCash.SuspendLayout();
        pnlCashCount.SuspendLayout();
        layoutCashCount.SuspendLayout();
        pnlDenominations.SuspendLayout();
        layoutDenominations.SuspendLayout();
        layoutBills500000.SuspendLayout();
        layoutBills200000.SuspendLayout();
        layoutBills100000.SuspendLayout();
        layoutBills50000.SuspendLayout();
        layoutBills20000.SuspendLayout();
        layoutBills10000.SuspendLayout();
        layoutBills5000.SuspendLayout();
        layoutBills2000.SuspendLayout();
        layoutBills1000.SuspendLayout();
        layoutCountedCash.SuspendLayout();
        layoutHandoverNote.SuspendLayout();
        pnlFooter.SuspendLayout();
        layoutFooter.SuspendLayout();
        SuspendLayout();
        //
        // pnlViewport
        //
        pnlViewport.Margin = new Padding(0);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1000, 662);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Controls.Add(layoutPage);
        //
        // layoutPage
        //
        layoutPage.Margin = new Padding(0);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.RowCount = 3;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.MinimumSize = new Size(1000, 662);
        layoutPage.Name = "layoutPage";
        layoutPage.Controls.Add(layoutHeading, 0, 0);
        layoutPage.Controls.Add(layoutCards, 0, 1);
        layoutPage.Controls.Add(pnlFooter, 0, 2);
        //
        // layoutHeading
        //
        layoutHeading.Margin = new Padding(19, 10, 16, 0);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.ColumnCount = 1;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.RowCount = 2;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layoutHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeading.Name = "layoutHeading";
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblShiftDetails, 0, 1);
        //
        // lblTitle
        //
        lblTitle.Margin = new Padding(0);
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 19.5F, FontStyle.Bold);
        lblTitle.Text = "Kết ca & bàn giao";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        lblTitle.Name = "lblTitle";
        //
        // lblShiftDetails
        //
        lblShiftDetails.Margin = new Padding(0);
        lblShiftDetails.Dock = DockStyle.Fill;
        lblShiftDetails.ForeColor = Color.FromArgb(100, 116, 139);
        lblShiftDetails.Font = new Font("Segoe UI", 10.5F);
        lblShiftDetails.Text = "CA-CHIEU-01 · Mở ca lúc 13:55";
        lblShiftDetails.TextAlign = ContentAlignment.MiddleLeft;
        lblShiftDetails.UseMnemonic = false;
        lblShiftDetails.Name = "lblShiftDetails";
        //
        // layoutCards
        //
        layoutCards.Margin = new Padding(16, 0, 16, 16);
        layoutCards.Dock = DockStyle.Fill;
        layoutCards.ColumnCount = 2;
        layoutCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39F));
        layoutCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61F));
        layoutCards.RowCount = 1;
        layoutCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCards.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCards.Name = "layoutCards";
        layoutCards.Controls.Add(pnlSystemCash, 0, 0);
        layoutCards.Controls.Add(pnlCashCount, 1, 0);
        //
        // pnlSystemCash
        //
        pnlSystemCash.Margin = new Padding(0, 0, 12, 0);
        pnlSystemCash.Dock = DockStyle.Fill;
        pnlSystemCash.BackColor = Color.FromArgb(226, 232, 240);
        pnlSystemCash.Padding = new Padding(1);
        pnlSystemCash.Name = "pnlSystemCash";
        pnlSystemCash.Controls.Add(layoutSystemCash);
        //
        // layoutSystemCash
        //
        layoutSystemCash.Margin = new Padding(0);
        layoutSystemCash.Dock = DockStyle.Fill;
        layoutSystemCash.BackColor = Color.White;
        layoutSystemCash.Padding = new Padding(13, 8, 13, 12);
        layoutSystemCash.ColumnCount = 2;
        layoutSystemCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54F));
        layoutSystemCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46F));
        layoutSystemCash.RowCount = 11;
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutSystemCash.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSystemCash.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSystemCash.Name = "layoutSystemCash";
        layoutSystemCash.Controls.Add(lblSystemCashTitle, 0, 0);
        layoutSystemCash.SetColumnSpan(lblSystemCashTitle, 2);
        layoutSystemCash.Controls.Add(pnlSystemTitleDivider, 0, 1);
        layoutSystemCash.SetColumnSpan(pnlSystemTitleDivider, 2);
        layoutSystemCash.Controls.Add(lblOpeningCashCaption, 0, 2);
        layoutSystemCash.Controls.Add(lblOpeningCashValue, 1, 2);
        layoutSystemCash.Controls.Add(pnlOpeningCashDivider, 0, 3);
        layoutSystemCash.SetColumnSpan(pnlOpeningCashDivider, 2);
        layoutSystemCash.Controls.Add(lblCashReceivedCaption, 0, 4);
        layoutSystemCash.Controls.Add(lblCashReceivedValue, 1, 4);
        layoutSystemCash.Controls.Add(pnlCashReceivedDivider, 0, 5);
        layoutSystemCash.SetColumnSpan(pnlCashReceivedDivider, 2);
        layoutSystemCash.Controls.Add(lblCashRefundCaption, 0, 6);
        layoutSystemCash.Controls.Add(lblCashRefundValue, 1, 6);
        layoutSystemCash.Controls.Add(pnlCashRefundDivider, 0, 7);
        layoutSystemCash.SetColumnSpan(pnlCashRefundDivider, 2);
        layoutSystemCash.Controls.Add(layoutExpectedCash, 0, 9);
        layoutSystemCash.SetColumnSpan(layoutExpectedCash, 2);
        //
        // lblSystemCashTitle
        //
        lblSystemCashTitle.Margin = new Padding(0);
        lblSystemCashTitle.Dock = DockStyle.Fill;
        lblSystemCashTitle.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
        lblSystemCashTitle.Text = "Tiền mặt theo hệ thống";
        lblSystemCashTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblSystemCashTitle.UseMnemonic = false;
        lblSystemCashTitle.Name = "lblSystemCashTitle";
        //
        // pnlSystemTitleDivider
        //
        pnlSystemTitleDivider.Margin = new Padding(0);
        pnlSystemTitleDivider.Dock = DockStyle.Fill;
        pnlSystemTitleDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlSystemTitleDivider.Name = "pnlSystemTitleDivider";
        //
        // lblOpeningCashCaption
        //
        lblOpeningCashCaption.Margin = new Padding(0);
        lblOpeningCashCaption.Dock = DockStyle.Fill;
        lblOpeningCashCaption.Padding = new Padding(6, 0, 0, 0);
        lblOpeningCashCaption.Text = "Quỹ đầu ca";
        lblOpeningCashCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblOpeningCashCaption.UseMnemonic = false;
        lblOpeningCashCaption.Name = "lblOpeningCashCaption";
        //
        // lblOpeningCashValue
        //
        lblOpeningCashValue.Margin = new Padding(0);
        lblOpeningCashValue.Dock = DockStyle.Fill;
        lblOpeningCashValue.Padding = new Padding(0, 0, 6, 0);
        lblOpeningCashValue.Text = "2.000.000 đ";
        lblOpeningCashValue.TextAlign = ContentAlignment.MiddleRight;
        lblOpeningCashValue.UseMnemonic = false;
        lblOpeningCashValue.Name = "lblOpeningCashValue";
        //
        // pnlOpeningCashDivider
        //
        pnlOpeningCashDivider.Margin = new Padding(0);
        pnlOpeningCashDivider.Dock = DockStyle.Fill;
        pnlOpeningCashDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlOpeningCashDivider.Name = "pnlOpeningCashDivider";
        //
        // lblCashReceivedCaption
        //
        lblCashReceivedCaption.Margin = new Padding(0);
        lblCashReceivedCaption.Dock = DockStyle.Fill;
        lblCashReceivedCaption.Padding = new Padding(6, 0, 0, 0);
        lblCashReceivedCaption.Text = "Tiền mặt đã thu";
        lblCashReceivedCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblCashReceivedCaption.UseMnemonic = false;
        lblCashReceivedCaption.Name = "lblCashReceivedCaption";
        //
        // lblCashReceivedValue
        //
        lblCashReceivedValue.Margin = new Padding(0);
        lblCashReceivedValue.Dock = DockStyle.Fill;
        lblCashReceivedValue.Padding = new Padding(0, 0, 6, 0);
        lblCashReceivedValue.Text = "8.500.000 đ";
        lblCashReceivedValue.TextAlign = ContentAlignment.MiddleRight;
        lblCashReceivedValue.UseMnemonic = false;
        lblCashReceivedValue.Name = "lblCashReceivedValue";
        //
        // pnlCashReceivedDivider
        //
        pnlCashReceivedDivider.Margin = new Padding(0);
        pnlCashReceivedDivider.Dock = DockStyle.Fill;
        pnlCashReceivedDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlCashReceivedDivider.Name = "pnlCashReceivedDivider";
        //
        // lblCashRefundCaption
        //
        lblCashRefundCaption.Margin = new Padding(0);
        lblCashRefundCaption.Dock = DockStyle.Fill;
        lblCashRefundCaption.Padding = new Padding(6, 0, 0, 0);
        lblCashRefundCaption.Text = "Hoàn tiền mặt";
        lblCashRefundCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblCashRefundCaption.UseMnemonic = false;
        lblCashRefundCaption.Name = "lblCashRefundCaption";
        //
        // lblCashRefundValue
        //
        lblCashRefundValue.Margin = new Padding(0);
        lblCashRefundValue.Dock = DockStyle.Fill;
        lblCashRefundValue.Padding = new Padding(0, 0, 6, 0);
        lblCashRefundValue.Text = "−180.000 đ";
        lblCashRefundValue.TextAlign = ContentAlignment.MiddleRight;
        lblCashRefundValue.UseMnemonic = false;
        lblCashRefundValue.Name = "lblCashRefundValue";
        //
        // pnlCashRefundDivider
        //
        pnlCashRefundDivider.Margin = new Padding(0);
        pnlCashRefundDivider.Dock = DockStyle.Fill;
        pnlCashRefundDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlCashRefundDivider.Name = "pnlCashRefundDivider";
        //
        // layoutExpectedCash
        //
        layoutExpectedCash.Margin = new Padding(0);
        layoutExpectedCash.Dock = DockStyle.Fill;
        layoutExpectedCash.BackColor = Color.FromArgb(219, 234, 254);
        layoutExpectedCash.Padding = new Padding(8, 0, 8, 0);
        layoutExpectedCash.ColumnCount = 2;
        layoutExpectedCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutExpectedCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutExpectedCash.RowCount = 1;
        layoutExpectedCash.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutExpectedCash.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutExpectedCash.Name = "layoutExpectedCash";
        layoutExpectedCash.Controls.Add(lblExpectedCashCaption, 0, 0);
        layoutExpectedCash.Controls.Add(lblExpectedCashValue, 1, 0);
        //
        // lblExpectedCashCaption
        //
        lblExpectedCashCaption.Margin = new Padding(0);
        lblExpectedCashCaption.Dock = DockStyle.Fill;
        lblExpectedCashCaption.ForeColor = Color.FromArgb(37, 99, 235);
        lblExpectedCashCaption.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblExpectedCashCaption.Text = "Tiền mặt dự kiến";
        lblExpectedCashCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblExpectedCashCaption.UseMnemonic = false;
        lblExpectedCashCaption.Name = "lblExpectedCashCaption";
        //
        // lblExpectedCashValue
        //
        lblExpectedCashValue.Margin = new Padding(0);
        lblExpectedCashValue.Dock = DockStyle.Fill;
        lblExpectedCashValue.ForeColor = Color.FromArgb(37, 99, 235);
        lblExpectedCashValue.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
        lblExpectedCashValue.Text = "10.320.000 đ";
        lblExpectedCashValue.TextAlign = ContentAlignment.MiddleRight;
        lblExpectedCashValue.UseMnemonic = false;
        lblExpectedCashValue.Name = "lblExpectedCashValue";
        //
        // pnlCashCount
        //
        pnlCashCount.Margin = new Padding(0);
        pnlCashCount.Dock = DockStyle.Fill;
        pnlCashCount.BackColor = Color.FromArgb(226, 232, 240);
        pnlCashCount.Padding = new Padding(1);
        pnlCashCount.Name = "pnlCashCount";
        pnlCashCount.Controls.Add(layoutCashCount);
        //
        // layoutCashCount
        //
        layoutCashCount.Margin = new Padding(0);
        layoutCashCount.Dock = DockStyle.Fill;
        layoutCashCount.BackColor = Color.White;
        layoutCashCount.Padding = new Padding(12, 8, 12, 10);
        layoutCashCount.ColumnCount = 1;
        layoutCashCount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutCashCount.RowCount = 4;
        layoutCashCount.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutCashCount.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCashCount.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        layoutCashCount.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutCashCount.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCashCount.Name = "layoutCashCount";
        layoutCashCount.Controls.Add(lblCashCountTitle, 0, 0);
        layoutCashCount.Controls.Add(pnlDenominations, 0, 1);
        layoutCashCount.Controls.Add(lblVariance, 0, 2);
        layoutCashCount.Controls.Add(layoutHandoverNote, 0, 3);
        //
        // lblCashCountTitle
        //
        lblCashCountTitle.Margin = new Padding(0);
        lblCashCountTitle.Dock = DockStyle.Fill;
        lblCashCountTitle.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
        lblCashCountTitle.Text = "Kiểm đếm tiền mặt";
        lblCashCountTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblCashCountTitle.UseMnemonic = false;
        lblCashCountTitle.Name = "lblCashCountTitle";
        //
        // pnlDenominations
        //
        pnlDenominations.Margin = new Padding(0);
        pnlDenominations.Dock = DockStyle.Fill;
        pnlDenominations.BackColor = Color.FromArgb(226, 232, 240);
        pnlDenominations.Padding = new Padding(1);
        pnlDenominations.Name = "pnlDenominations";
        pnlDenominations.Controls.Add(layoutDenominations);
        //
        // layoutDenominations
        //
        layoutDenominations.Margin = new Padding(0);
        layoutDenominations.Dock = DockStyle.Fill;
        layoutDenominations.BackColor = Color.FromArgb(226, 232, 240);
        layoutDenominations.ColumnCount = 3;
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39F));
        layoutDenominations.RowCount = 11;
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutDenominations.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutDenominations.Name = "layoutDenominations";
        layoutDenominations.Controls.Add(lblDenominationHeader, 0, 0);
        layoutDenominations.Controls.Add(lblBillCountHeader, 1, 0);
        layoutDenominations.Controls.Add(lblAmountHeader, 2, 0);
        layoutDenominations.Controls.Add(lblDenomination500000, 0, 1);
        layoutDenominations.Controls.Add(layoutBills500000, 1, 1);
        layoutDenominations.Controls.Add(lblAmount500000, 2, 1);
        layoutDenominations.Controls.Add(lblDenomination200000, 0, 2);
        layoutDenominations.Controls.Add(layoutBills200000, 1, 2);
        layoutDenominations.Controls.Add(lblAmount200000, 2, 2);
        layoutDenominations.Controls.Add(lblDenomination100000, 0, 3);
        layoutDenominations.Controls.Add(layoutBills100000, 1, 3);
        layoutDenominations.Controls.Add(lblAmount100000, 2, 3);
        layoutDenominations.Controls.Add(lblDenomination50000, 0, 4);
        layoutDenominations.Controls.Add(layoutBills50000, 1, 4);
        layoutDenominations.Controls.Add(lblAmount50000, 2, 4);
        layoutDenominations.Controls.Add(lblDenomination20000, 0, 5);
        layoutDenominations.Controls.Add(layoutBills20000, 1, 5);
        layoutDenominations.Controls.Add(lblAmount20000, 2, 5);
        layoutDenominations.Controls.Add(lblDenomination10000, 0, 6);
        layoutDenominations.Controls.Add(layoutBills10000, 1, 6);
        layoutDenominations.Controls.Add(lblAmount10000, 2, 6);
        layoutDenominations.Controls.Add(lblDenomination5000, 0, 7);
        layoutDenominations.Controls.Add(layoutBills5000, 1, 7);
        layoutDenominations.Controls.Add(lblAmount5000, 2, 7);
        layoutDenominations.Controls.Add(lblDenomination2000, 0, 8);
        layoutDenominations.Controls.Add(layoutBills2000, 1, 8);
        layoutDenominations.Controls.Add(lblAmount2000, 2, 8);
        layoutDenominations.Controls.Add(lblDenomination1000, 0, 9);
        layoutDenominations.Controls.Add(layoutBills1000, 1, 9);
        layoutDenominations.Controls.Add(lblAmount1000, 2, 9);
        layoutDenominations.Controls.Add(layoutCountedCash, 0, 10);
        layoutDenominations.SetColumnSpan(layoutCountedCash, 3);
        //
        // lblDenominationHeader
        //
        lblDenominationHeader.Margin = new Padding(0, 0, 1, 1);
        lblDenominationHeader.Dock = DockStyle.Fill;
        lblDenominationHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblDenominationHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblDenominationHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblDenominationHeader.Text = "Mệnh giá";
        lblDenominationHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblDenominationHeader.UseMnemonic = false;
        lblDenominationHeader.Name = "lblDenominationHeader";
        //
        // lblBillCountHeader
        //
        lblBillCountHeader.Margin = new Padding(0, 0, 1, 1);
        lblBillCountHeader.Dock = DockStyle.Fill;
        lblBillCountHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblBillCountHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblBillCountHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblBillCountHeader.Text = "Số tờ";
        lblBillCountHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblBillCountHeader.UseMnemonic = false;
        lblBillCountHeader.Name = "lblBillCountHeader";
        //
        // lblAmountHeader
        //
        lblAmountHeader.Margin = new Padding(0, 0, 0, 1);
        lblAmountHeader.Dock = DockStyle.Fill;
        lblAmountHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblAmountHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblAmountHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblAmountHeader.Text = "Thành tiền";
        lblAmountHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblAmountHeader.UseMnemonic = false;
        lblAmountHeader.Name = "lblAmountHeader";
        //
        // lblDenomination500000
        //
        lblDenomination500000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination500000.Dock = DockStyle.Fill;
        lblDenomination500000.BackColor = Color.White;
        lblDenomination500000.Text = "500.000 đ";
        lblDenomination500000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination500000.UseMnemonic = false;
        lblDenomination500000.Name = "lblDenomination500000";
        //
        // layoutBills500000
        //
        layoutBills500000.Margin = new Padding(0, 0, 1, 1);
        layoutBills500000.Dock = DockStyle.Fill;
        layoutBills500000.BackColor = Color.White;
        layoutBills500000.ColumnCount = 1;
        layoutBills500000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills500000.RowCount = 1;
        layoutBills500000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills500000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills500000.Name = "layoutBills500000";
        layoutBills500000.Controls.Add(txtBills500000, 0, 0);
        //
        // txtBills500000
        //
        txtBills500000.Margin = new Padding(0);
        txtBills500000.BackColor = Color.White;
        txtBills500000.Font = new Font("Segoe UI", 9F);
        txtBills500000.AccessibleName = "Số tờ 500.000 đ";
        txtBills500000.Anchor = AnchorStyles.None;
        txtBills500000.BorderStyle = BorderStyle.FixedSingle;
        txtBills500000.ReadOnly = true;
        txtBills500000.Size = new Size(84, 24);
        txtBills500000.TabStop = false;
        txtBills500000.Text = "16";
        txtBills500000.TextAlign = HorizontalAlignment.Center;
        txtBills500000.Name = "txtBills500000";
        //
        // lblAmount500000
        //
        lblAmount500000.Margin = new Padding(0, 0, 0, 1);
        lblAmount500000.Dock = DockStyle.Fill;
        lblAmount500000.BackColor = Color.White;
        lblAmount500000.Padding = new Padding(0, 0, 14, 0);
        lblAmount500000.Text = "8.000.000 đ";
        lblAmount500000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount500000.UseMnemonic = false;
        lblAmount500000.Name = "lblAmount500000";
        //
        // lblDenomination200000
        //
        lblDenomination200000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination200000.Dock = DockStyle.Fill;
        lblDenomination200000.BackColor = Color.White;
        lblDenomination200000.Text = "200.000 đ";
        lblDenomination200000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination200000.UseMnemonic = false;
        lblDenomination200000.Name = "lblDenomination200000";
        //
        // layoutBills200000
        //
        layoutBills200000.Margin = new Padding(0, 0, 1, 1);
        layoutBills200000.Dock = DockStyle.Fill;
        layoutBills200000.BackColor = Color.White;
        layoutBills200000.ColumnCount = 1;
        layoutBills200000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills200000.RowCount = 1;
        layoutBills200000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills200000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills200000.Name = "layoutBills200000";
        layoutBills200000.Controls.Add(txtBills200000, 0, 0);
        //
        // txtBills200000
        //
        txtBills200000.Margin = new Padding(0);
        txtBills200000.BackColor = Color.White;
        txtBills200000.Font = new Font("Segoe UI", 9F);
        txtBills200000.AccessibleName = "Số tờ 200.000 đ";
        txtBills200000.Anchor = AnchorStyles.None;
        txtBills200000.BorderStyle = BorderStyle.FixedSingle;
        txtBills200000.ReadOnly = true;
        txtBills200000.Size = new Size(84, 24);
        txtBills200000.TabStop = false;
        txtBills200000.Text = "8";
        txtBills200000.TextAlign = HorizontalAlignment.Center;
        txtBills200000.Name = "txtBills200000";
        //
        // lblAmount200000
        //
        lblAmount200000.Margin = new Padding(0, 0, 0, 1);
        lblAmount200000.Dock = DockStyle.Fill;
        lblAmount200000.BackColor = Color.White;
        lblAmount200000.Padding = new Padding(0, 0, 14, 0);
        lblAmount200000.Text = "1.600.000 đ";
        lblAmount200000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount200000.UseMnemonic = false;
        lblAmount200000.Name = "lblAmount200000";
        //
        // lblDenomination100000
        //
        lblDenomination100000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination100000.Dock = DockStyle.Fill;
        lblDenomination100000.BackColor = Color.White;
        lblDenomination100000.Text = "100.000 đ";
        lblDenomination100000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination100000.UseMnemonic = false;
        lblDenomination100000.Name = "lblDenomination100000";
        //
        // layoutBills100000
        //
        layoutBills100000.Margin = new Padding(0, 0, 1, 1);
        layoutBills100000.Dock = DockStyle.Fill;
        layoutBills100000.BackColor = Color.White;
        layoutBills100000.ColumnCount = 1;
        layoutBills100000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills100000.RowCount = 1;
        layoutBills100000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills100000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills100000.Name = "layoutBills100000";
        layoutBills100000.Controls.Add(txtBills100000, 0, 0);
        //
        // txtBills100000
        //
        txtBills100000.Margin = new Padding(0);
        txtBills100000.BackColor = Color.White;
        txtBills100000.Font = new Font("Segoe UI", 9F);
        txtBills100000.AccessibleName = "Số tờ 100.000 đ";
        txtBills100000.Anchor = AnchorStyles.None;
        txtBills100000.BorderStyle = BorderStyle.FixedSingle;
        txtBills100000.ReadOnly = true;
        txtBills100000.Size = new Size(84, 24);
        txtBills100000.TabStop = false;
        txtBills100000.Text = "4";
        txtBills100000.TextAlign = HorizontalAlignment.Center;
        txtBills100000.Name = "txtBills100000";
        //
        // lblAmount100000
        //
        lblAmount100000.Margin = new Padding(0, 0, 0, 1);
        lblAmount100000.Dock = DockStyle.Fill;
        lblAmount100000.BackColor = Color.White;
        lblAmount100000.Padding = new Padding(0, 0, 14, 0);
        lblAmount100000.Text = "400.000 đ";
        lblAmount100000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount100000.UseMnemonic = false;
        lblAmount100000.Name = "lblAmount100000";
        //
        // lblDenomination50000
        //
        lblDenomination50000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination50000.Dock = DockStyle.Fill;
        lblDenomination50000.BackColor = Color.White;
        lblDenomination50000.Text = "50.000 đ";
        lblDenomination50000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination50000.UseMnemonic = false;
        lblDenomination50000.Name = "lblDenomination50000";
        //
        // layoutBills50000
        //
        layoutBills50000.Margin = new Padding(0, 0, 1, 1);
        layoutBills50000.Dock = DockStyle.Fill;
        layoutBills50000.BackColor = Color.White;
        layoutBills50000.ColumnCount = 1;
        layoutBills50000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills50000.RowCount = 1;
        layoutBills50000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills50000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills50000.Name = "layoutBills50000";
        layoutBills50000.Controls.Add(txtBills50000, 0, 0);
        //
        // txtBills50000
        //
        txtBills50000.Margin = new Padding(0);
        txtBills50000.BackColor = Color.White;
        txtBills50000.Font = new Font("Segoe UI", 9F);
        txtBills50000.AccessibleName = "Số tờ 50.000 đ";
        txtBills50000.Anchor = AnchorStyles.None;
        txtBills50000.BorderStyle = BorderStyle.FixedSingle;
        txtBills50000.ReadOnly = true;
        txtBills50000.Size = new Size(84, 24);
        txtBills50000.TabStop = false;
        txtBills50000.Text = "4";
        txtBills50000.TextAlign = HorizontalAlignment.Center;
        txtBills50000.Name = "txtBills50000";
        //
        // lblAmount50000
        //
        lblAmount50000.Margin = new Padding(0, 0, 0, 1);
        lblAmount50000.Dock = DockStyle.Fill;
        lblAmount50000.BackColor = Color.White;
        lblAmount50000.Padding = new Padding(0, 0, 14, 0);
        lblAmount50000.Text = "200.000 đ";
        lblAmount50000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount50000.UseMnemonic = false;
        lblAmount50000.Name = "lblAmount50000";
        //
        // lblDenomination20000
        //
        lblDenomination20000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination20000.Dock = DockStyle.Fill;
        lblDenomination20000.BackColor = Color.White;
        lblDenomination20000.Text = "20.000 đ";
        lblDenomination20000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination20000.UseMnemonic = false;
        lblDenomination20000.Name = "lblDenomination20000";
        //
        // layoutBills20000
        //
        layoutBills20000.Margin = new Padding(0, 0, 1, 1);
        layoutBills20000.Dock = DockStyle.Fill;
        layoutBills20000.BackColor = Color.White;
        layoutBills20000.ColumnCount = 1;
        layoutBills20000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills20000.RowCount = 1;
        layoutBills20000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills20000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills20000.Name = "layoutBills20000";
        layoutBills20000.Controls.Add(txtBills20000, 0, 0);
        //
        // txtBills20000
        //
        txtBills20000.Margin = new Padding(0);
        txtBills20000.BackColor = Color.White;
        txtBills20000.Font = new Font("Segoe UI", 9F);
        txtBills20000.AccessibleName = "Số tờ 20.000 đ";
        txtBills20000.Anchor = AnchorStyles.None;
        txtBills20000.BorderStyle = BorderStyle.FixedSingle;
        txtBills20000.ReadOnly = true;
        txtBills20000.Size = new Size(84, 24);
        txtBills20000.TabStop = false;
        txtBills20000.Text = "3";
        txtBills20000.TextAlign = HorizontalAlignment.Center;
        txtBills20000.Name = "txtBills20000";
        //
        // lblAmount20000
        //
        lblAmount20000.Margin = new Padding(0, 0, 0, 1);
        lblAmount20000.Dock = DockStyle.Fill;
        lblAmount20000.BackColor = Color.White;
        lblAmount20000.Padding = new Padding(0, 0, 14, 0);
        lblAmount20000.Text = "60.000 đ";
        lblAmount20000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount20000.UseMnemonic = false;
        lblAmount20000.Name = "lblAmount20000";
        //
        // lblDenomination10000
        //
        lblDenomination10000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination10000.Dock = DockStyle.Fill;
        lblDenomination10000.BackColor = Color.White;
        lblDenomination10000.Text = "10.000 đ";
        lblDenomination10000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination10000.UseMnemonic = false;
        lblDenomination10000.Name = "lblDenomination10000";
        //
        // layoutBills10000
        //
        layoutBills10000.Margin = new Padding(0, 0, 1, 1);
        layoutBills10000.Dock = DockStyle.Fill;
        layoutBills10000.BackColor = Color.White;
        layoutBills10000.ColumnCount = 1;
        layoutBills10000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills10000.RowCount = 1;
        layoutBills10000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills10000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills10000.Name = "layoutBills10000";
        layoutBills10000.Controls.Add(txtBills10000, 0, 0);
        //
        // txtBills10000
        //
        txtBills10000.Margin = new Padding(0);
        txtBills10000.BackColor = Color.White;
        txtBills10000.Font = new Font("Segoe UI", 9F);
        txtBills10000.AccessibleName = "Số tờ 10.000 đ";
        txtBills10000.Anchor = AnchorStyles.None;
        txtBills10000.BorderStyle = BorderStyle.FixedSingle;
        txtBills10000.ReadOnly = true;
        txtBills10000.Size = new Size(84, 24);
        txtBills10000.TabStop = false;
        txtBills10000.Text = "3";
        txtBills10000.TextAlign = HorizontalAlignment.Center;
        txtBills10000.Name = "txtBills10000";
        //
        // lblAmount10000
        //
        lblAmount10000.Margin = new Padding(0, 0, 0, 1);
        lblAmount10000.Dock = DockStyle.Fill;
        lblAmount10000.BackColor = Color.White;
        lblAmount10000.Padding = new Padding(0, 0, 14, 0);
        lblAmount10000.Text = "30.000 đ";
        lblAmount10000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount10000.UseMnemonic = false;
        lblAmount10000.Name = "lblAmount10000";
        //
        // lblDenomination5000
        //
        lblDenomination5000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination5000.Dock = DockStyle.Fill;
        lblDenomination5000.BackColor = Color.White;
        lblDenomination5000.Text = "5.000 đ";
        lblDenomination5000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination5000.UseMnemonic = false;
        lblDenomination5000.Name = "lblDenomination5000";
        //
        // layoutBills5000
        //
        layoutBills5000.Margin = new Padding(0, 0, 1, 1);
        layoutBills5000.Dock = DockStyle.Fill;
        layoutBills5000.BackColor = Color.White;
        layoutBills5000.ColumnCount = 1;
        layoutBills5000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills5000.RowCount = 1;
        layoutBills5000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills5000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills5000.Name = "layoutBills5000";
        layoutBills5000.Controls.Add(txtBills5000, 0, 0);
        //
        // txtBills5000
        //
        txtBills5000.Margin = new Padding(0);
        txtBills5000.BackColor = Color.White;
        txtBills5000.Font = new Font("Segoe UI", 9F);
        txtBills5000.AccessibleName = "Số tờ 5.000 đ";
        txtBills5000.Anchor = AnchorStyles.None;
        txtBills5000.BorderStyle = BorderStyle.FixedSingle;
        txtBills5000.ReadOnly = true;
        txtBills5000.Size = new Size(84, 24);
        txtBills5000.TabStop = false;
        txtBills5000.Text = "4";
        txtBills5000.TextAlign = HorizontalAlignment.Center;
        txtBills5000.Name = "txtBills5000";
        //
        // lblAmount5000
        //
        lblAmount5000.Margin = new Padding(0, 0, 0, 1);
        lblAmount5000.Dock = DockStyle.Fill;
        lblAmount5000.BackColor = Color.White;
        lblAmount5000.Padding = new Padding(0, 0, 14, 0);
        lblAmount5000.Text = "20.000 đ";
        lblAmount5000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount5000.UseMnemonic = false;
        lblAmount5000.Name = "lblAmount5000";
        //
        // lblDenomination2000
        //
        lblDenomination2000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination2000.Dock = DockStyle.Fill;
        lblDenomination2000.BackColor = Color.White;
        lblDenomination2000.Text = "2.000 đ";
        lblDenomination2000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination2000.UseMnemonic = false;
        lblDenomination2000.Name = "lblDenomination2000";
        //
        // layoutBills2000
        //
        layoutBills2000.Margin = new Padding(0, 0, 1, 1);
        layoutBills2000.Dock = DockStyle.Fill;
        layoutBills2000.BackColor = Color.White;
        layoutBills2000.ColumnCount = 1;
        layoutBills2000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills2000.RowCount = 1;
        layoutBills2000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills2000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills2000.Name = "layoutBills2000";
        layoutBills2000.Controls.Add(txtBills2000, 0, 0);
        //
        // txtBills2000
        //
        txtBills2000.Margin = new Padding(0);
        txtBills2000.BackColor = Color.White;
        txtBills2000.Font = new Font("Segoe UI", 9F);
        txtBills2000.AccessibleName = "Số tờ 2.000 đ";
        txtBills2000.Anchor = AnchorStyles.None;
        txtBills2000.BorderStyle = BorderStyle.FixedSingle;
        txtBills2000.ReadOnly = true;
        txtBills2000.Size = new Size(84, 24);
        txtBills2000.TabStop = false;
        txtBills2000.Text = "4";
        txtBills2000.TextAlign = HorizontalAlignment.Center;
        txtBills2000.Name = "txtBills2000";
        //
        // lblAmount2000
        //
        lblAmount2000.Margin = new Padding(0, 0, 0, 1);
        lblAmount2000.Dock = DockStyle.Fill;
        lblAmount2000.BackColor = Color.White;
        lblAmount2000.Padding = new Padding(0, 0, 14, 0);
        lblAmount2000.Text = "8.000 đ";
        lblAmount2000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount2000.UseMnemonic = false;
        lblAmount2000.Name = "lblAmount2000";
        //
        // lblDenomination1000
        //
        lblDenomination1000.Margin = new Padding(0, 0, 1, 1);
        lblDenomination1000.Dock = DockStyle.Fill;
        lblDenomination1000.BackColor = Color.White;
        lblDenomination1000.Text = "1.000 đ";
        lblDenomination1000.TextAlign = ContentAlignment.MiddleCenter;
        lblDenomination1000.UseMnemonic = false;
        lblDenomination1000.Name = "lblDenomination1000";
        //
        // layoutBills1000
        //
        layoutBills1000.Margin = new Padding(0, 0, 1, 1);
        layoutBills1000.Dock = DockStyle.Fill;
        layoutBills1000.BackColor = Color.White;
        layoutBills1000.ColumnCount = 1;
        layoutBills1000.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBills1000.RowCount = 1;
        layoutBills1000.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBills1000.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBills1000.Name = "layoutBills1000";
        layoutBills1000.Controls.Add(txtBills1000, 0, 0);
        //
        // txtBills1000
        //
        txtBills1000.Margin = new Padding(0);
        txtBills1000.BackColor = Color.White;
        txtBills1000.Font = new Font("Segoe UI", 9F);
        txtBills1000.AccessibleName = "Số tờ 1.000 đ";
        txtBills1000.Anchor = AnchorStyles.None;
        txtBills1000.BorderStyle = BorderStyle.FixedSingle;
        txtBills1000.ReadOnly = true;
        txtBills1000.Size = new Size(84, 24);
        txtBills1000.TabStop = false;
        txtBills1000.Text = "2";
        txtBills1000.TextAlign = HorizontalAlignment.Center;
        txtBills1000.Name = "txtBills1000";
        //
        // lblAmount1000
        //
        lblAmount1000.Margin = new Padding(0, 0, 0, 1);
        lblAmount1000.Dock = DockStyle.Fill;
        lblAmount1000.BackColor = Color.White;
        lblAmount1000.Padding = new Padding(0, 0, 14, 0);
        lblAmount1000.Text = "2.000 đ";
        lblAmount1000.TextAlign = ContentAlignment.MiddleRight;
        lblAmount1000.UseMnemonic = false;
        lblAmount1000.Name = "lblAmount1000";
        //
        // layoutCountedCash
        //
        layoutCountedCash.Margin = new Padding(0);
        layoutCountedCash.Dock = DockStyle.Fill;
        layoutCountedCash.BackColor = Color.FromArgb(241, 245, 249);
        layoutCountedCash.Padding = new Padding(14, 0, 14, 0);
        layoutCountedCash.ColumnCount = 2;
        layoutCountedCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
        layoutCountedCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        layoutCountedCash.RowCount = 1;
        layoutCountedCash.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCountedCash.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCountedCash.Name = "layoutCountedCash";
        layoutCountedCash.Controls.Add(lblCountedCashCaption, 0, 0);
        layoutCountedCash.Controls.Add(lblCountedCashValue, 1, 0);
        //
        // lblCountedCashCaption
        //
        lblCountedCashCaption.Margin = new Padding(0);
        lblCountedCashCaption.Dock = DockStyle.Fill;
        lblCountedCashCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblCountedCashCaption.Text = "Tiền mặt thực đếm";
        lblCountedCashCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblCountedCashCaption.UseMnemonic = false;
        lblCountedCashCaption.Name = "lblCountedCashCaption";
        //
        // lblCountedCashValue
        //
        lblCountedCashValue.Margin = new Padding(0);
        lblCountedCashValue.Dock = DockStyle.Fill;
        lblCountedCashValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblCountedCashValue.Text = "10.320.000 đ";
        lblCountedCashValue.TextAlign = ContentAlignment.MiddleRight;
        lblCountedCashValue.UseMnemonic = false;
        lblCountedCashValue.Name = "lblCountedCashValue";
        //
        // lblVariance
        //
        lblVariance.Margin = new Padding(0);
        lblVariance.BackColor = Color.FromArgb(220, 252, 231);
        lblVariance.ForeColor = Color.FromArgb(22, 101, 52);
        lblVariance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblVariance.Text = "✓  Chênh lệch 0 đ · Khớp quỹ";
        lblVariance.TextAlign = ContentAlignment.MiddleCenter;
        lblVariance.UseMnemonic = false;
        lblVariance.Anchor = AnchorStyles.Right;
        lblVariance.Size = new Size(280, 32);
        lblVariance.Name = "lblVariance";
        //
        // layoutHandoverNote
        //
        layoutHandoverNote.Margin = new Padding(6, 0, 0, 0);
        layoutHandoverNote.Dock = DockStyle.Fill;
        layoutHandoverNote.ColumnCount = 2;
        layoutHandoverNote.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 146F));
        layoutHandoverNote.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHandoverNote.RowCount = 1;
        layoutHandoverNote.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHandoverNote.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHandoverNote.Name = "layoutHandoverNote";
        layoutHandoverNote.Controls.Add(lblHandoverNote, 0, 0);
        layoutHandoverNote.Controls.Add(txtHandoverNote, 1, 0);
        //
        // lblHandoverNote
        //
        lblHandoverNote.Margin = new Padding(0);
        lblHandoverNote.Dock = DockStyle.Fill;
        lblHandoverNote.Text = "Ghi chú bàn giao";
        lblHandoverNote.TextAlign = ContentAlignment.MiddleLeft;
        lblHandoverNote.UseMnemonic = false;
        lblHandoverNote.Name = "lblHandoverNote";
        //
        // txtHandoverNote
        //
        txtHandoverNote.Margin = new Padding(0);
        txtHandoverNote.BackColor = Color.White;
        txtHandoverNote.AccessibleName = "Ghi chú bàn giao";
        txtHandoverNote.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtHandoverNote.BorderStyle = BorderStyle.FixedSingle;
        txtHandoverNote.PlaceholderText = "Không bắt buộc khi khớp quỹ";
        txtHandoverNote.Name = "txtHandoverNote";
        //
        // pnlFooter
        //
        pnlFooter.Margin = new Padding(0);
        pnlFooter.Dock = DockStyle.Fill;
        pnlFooter.BackColor = Color.FromArgb(226, 232, 240);
        pnlFooter.Padding = new Padding(0, 1, 0, 0);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Controls.Add(layoutFooter);
        //
        // layoutFooter
        //
        layoutFooter.Margin = new Padding(0);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.BackColor = Color.White;
        layoutFooter.Padding = new Padding(16, 12, 16, 12);
        layoutFooter.ColumnCount = 3;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 214F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 178F));
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Controls.Add(btnBackToOverview, 0, 0);
        layoutFooter.Controls.Add(btnSubmitHandover, 2, 0);
        //
        // btnBackToOverview
        //
        btnBackToOverview.Margin = new Padding(0);
        btnBackToOverview.Dock = DockStyle.Fill;
        btnBackToOverview.BackColor = Color.White;
        btnBackToOverview.ForeColor = Color.FromArgb(15, 23, 42);
        btnBackToOverview.Font = new Font("Segoe UI", 10F);
        btnBackToOverview.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnBackToOverview.FlatStyle = FlatStyle.Flat;
        btnBackToOverview.Text = "‹  Quay lại tổng quan";
        btnBackToOverview.UseMnemonic = false;
        btnBackToOverview.UseVisualStyleBackColor = false;
        btnBackToOverview.Name = "btnBackToOverview";
        btnBackToOverview.Click += BtnBackToOverview_Click;
        //
        // btnSubmitHandover
        //
        btnSubmitHandover.Margin = new Padding(0);
        btnSubmitHandover.Dock = DockStyle.Fill;
        btnSubmitHandover.BackColor = Color.FromArgb(37, 99, 235);
        btnSubmitHandover.ForeColor = Color.White;
        btnSubmitHandover.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSubmitHandover.FlatAppearance.BorderSize = 0;
        btnSubmitHandover.FlatStyle = FlatStyle.Flat;
        btnSubmitHandover.Text = "Gửi bàn giao";
        btnSubmitHandover.UseMnemonic = false;
        btnSubmitHandover.UseVisualStyleBackColor = false;
        btnSubmitHandover.Name = "btnSubmitHandover";
        //
        // ShiftHandoverView
        //
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "ShiftHandoverView";
        Size = new Size(1136, 730);
        layoutFooter.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        layoutHandoverNote.ResumeLayout(false);
        layoutHandoverNote.PerformLayout();
        layoutCountedCash.ResumeLayout(false);
        layoutBills1000.ResumeLayout(false);
        layoutBills2000.ResumeLayout(false);
        layoutBills5000.ResumeLayout(false);
        layoutBills10000.ResumeLayout(false);
        layoutBills20000.ResumeLayout(false);
        layoutBills50000.ResumeLayout(false);
        layoutBills100000.ResumeLayout(false);
        layoutBills200000.ResumeLayout(false);
        layoutBills500000.ResumeLayout(false);
        layoutDenominations.ResumeLayout(false);
        pnlDenominations.ResumeLayout(false);
        layoutCashCount.ResumeLayout(false);
        pnlCashCount.ResumeLayout(false);
        layoutExpectedCash.ResumeLayout(false);
        layoutSystemCash.ResumeLayout(false);
        pnlSystemCash.ResumeLayout(false);
        layoutCards.ResumeLayout(false);
        layoutHeading.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        pnlViewport.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private TableLayoutPanel layoutHeading;
    private Label lblTitle;
    private Label lblShiftDetails;
    private TableLayoutPanel layoutCards;
    private Panel pnlSystemCash;
    private TableLayoutPanel layoutSystemCash;
    private Label lblSystemCashTitle;
    private Panel pnlSystemTitleDivider;
    private Label lblOpeningCashCaption;
    private Label lblOpeningCashValue;
    private Panel pnlOpeningCashDivider;
    private Label lblCashReceivedCaption;
    private Label lblCashReceivedValue;
    private Panel pnlCashReceivedDivider;
    private Label lblCashRefundCaption;
    private Label lblCashRefundValue;
    private Panel pnlCashRefundDivider;
    private TableLayoutPanel layoutExpectedCash;
    private Label lblExpectedCashCaption;
    private Label lblExpectedCashValue;
    private Panel pnlCashCount;
    private TableLayoutPanel layoutCashCount;
    private Label lblCashCountTitle;
    private Panel pnlDenominations;
    private TableLayoutPanel layoutDenominations;
    private Label lblDenominationHeader;
    private Label lblBillCountHeader;
    private Label lblAmountHeader;
    private Label lblDenomination500000;
    private TableLayoutPanel layoutBills500000;
    private TextBox txtBills500000;
    private Label lblAmount500000;
    private Label lblDenomination200000;
    private TableLayoutPanel layoutBills200000;
    private TextBox txtBills200000;
    private Label lblAmount200000;
    private Label lblDenomination100000;
    private TableLayoutPanel layoutBills100000;
    private TextBox txtBills100000;
    private Label lblAmount100000;
    private Label lblDenomination50000;
    private TableLayoutPanel layoutBills50000;
    private TextBox txtBills50000;
    private Label lblAmount50000;
    private Label lblDenomination20000;
    private TableLayoutPanel layoutBills20000;
    private TextBox txtBills20000;
    private Label lblAmount20000;
    private Label lblDenomination10000;
    private TableLayoutPanel layoutBills10000;
    private TextBox txtBills10000;
    private Label lblAmount10000;
    private Label lblDenomination5000;
    private TableLayoutPanel layoutBills5000;
    private TextBox txtBills5000;
    private Label lblAmount5000;
    private Label lblDenomination2000;
    private TableLayoutPanel layoutBills2000;
    private TextBox txtBills2000;
    private Label lblAmount2000;
    private Label lblDenomination1000;
    private TableLayoutPanel layoutBills1000;
    private TextBox txtBills1000;
    private Label lblAmount1000;
    private TableLayoutPanel layoutCountedCash;
    private Label lblCountedCashCaption;
    private Label lblCountedCashValue;
    private Label lblVariance;
    private TableLayoutPanel layoutHandoverNote;
    private Label lblHandoverNote;
    private TextBox txtHandoverNote;
    private Panel pnlFooter;
    private TableLayoutPanel layoutFooter;
    private Button btnBackToOverview;
    private Button btnSubmitHandover;
}

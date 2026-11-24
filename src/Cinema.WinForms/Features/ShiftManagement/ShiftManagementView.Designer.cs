namespace Cinema.WinForms.Features.ShiftManagement;

partial class ShiftManagementView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutDashboard = new TableLayoutPanel();
        layoutHeading = new TableLayoutPanel();
        lblTitle = new Label();
        lblShiftStatus = new Label();
        layoutOverview = new TableLayoutPanel();
        pnlCurrentShift = new Panel();
        layoutCurrentShift = new TableLayoutPanel();
        lblCurrentShiftTitle = new Label();
        layoutEmployee = new TableLayoutPanel();
        lblEmployeeCaption = new Label();
        lblEmployeeValue = new Label();
        pnlEmployeeDivider = new Panel();
        layoutShiftCode = new TableLayoutPanel();
        lblShiftCodeCaption = new Label();
        lblShiftCodeValue = new Label();
        pnlShiftCodeDivider = new Panel();
        layoutTerminal = new TableLayoutPanel();
        lblTerminalCaption = new Label();
        lblTerminalValue = new Label();
        pnlTerminalDivider = new Panel();
        layoutOpenedAt = new TableLayoutPanel();
        lblOpenedAtCaption = new Label();
        lblOpenedAtValue = new Label();
        pnlOpenedAtDivider = new Panel();
        layoutStartingCash = new TableLayoutPanel();
        lblStartingCashCaption = new Label();
        lblStartingCashValue = new Label();
        pnlStartingCashDivider = new Panel();
        btnCloseShift = new Button();
        layoutReports = new TableLayoutPanel();
        layoutSummary = new TableLayoutPanel();
        pnlInvoices = new Panel();
        layoutInvoices = new TableLayoutPanel();
        lblInvoicesIcon = new Label();
        lblInvoicesCaption = new Label();
        lblInvoicesValue = new Label();
        pnlTickets = new Panel();
        layoutTickets = new TableLayoutPanel();
        lblTicketsIcon = new Label();
        lblTicketsCaption = new Label();
        lblTicketsValue = new Label();
        pnlTurnover = new Panel();
        layoutTurnover = new TableLayoutPanel();
        lblTurnoverIcon = new Label();
        lblTurnoverCaption = new Label();
        lblTurnoverValue = new Label();
        pnlHistory = new Panel();
        layoutHistory = new TableLayoutPanel();
        lblHistoryTitle = new Label();
        pnlHistoryTable = new Panel();
        layoutHistoryTable = new TableLayoutPanel();
        lblHistoryDateHeader = new Label();
        lblHistoryStationHeader = new Label();
        lblHistoryVarianceHeader = new Label();
        lblHistoryStatusHeader = new Label();
        pnlHistoryDivider1 = new Panel();
        lblHistoryDate1 = new Label();
        lblHistoryStation1 = new Label();
        lblHistoryVariance1 = new Label();
        lblHistoryStatus1 = new Label();
        pnlHistoryDivider2 = new Panel();
        lblHistoryDate2 = new Label();
        lblHistoryStation2 = new Label();
        lblHistoryVariance2 = new Label();
        lblHistoryStatus2 = new Label();
        pnlHistoryDivider3 = new Panel();
        lblHistoryDate3 = new Label();
        lblHistoryStation3 = new Label();
        lblHistoryVariance3 = new Label();
        lblHistoryStatus3 = new Label();
        pnlHistoryDivider4 = new Panel();
        lblHistoryDate4 = new Label();
        lblHistoryStation4 = new Label();
        lblHistoryVariance4 = new Label();
        lblHistoryStatus4 = new Label();
        pnlViewport.SuspendLayout();
        layoutDashboard.SuspendLayout();
        layoutHeading.SuspendLayout();
        layoutOverview.SuspendLayout();
        pnlCurrentShift.SuspendLayout();
        layoutCurrentShift.SuspendLayout();
        layoutEmployee.SuspendLayout();
        layoutShiftCode.SuspendLayout();
        layoutTerminal.SuspendLayout();
        layoutOpenedAt.SuspendLayout();
        layoutStartingCash.SuspendLayout();
        layoutReports.SuspendLayout();
        layoutSummary.SuspendLayout();
        pnlInvoices.SuspendLayout();
        layoutInvoices.SuspendLayout();
        pnlTickets.SuspendLayout();
        layoutTickets.SuspendLayout();
        pnlTurnover.SuspendLayout();
        layoutTurnover.SuspendLayout();
        pnlHistory.SuspendLayout();
        layoutHistory.SuspendLayout();
        pnlHistoryTable.SuspendLayout();
        layoutHistoryTable.SuspendLayout();
        SuspendLayout();
        //
        // pnlViewport
        //
        pnlViewport.Margin = new Padding(0);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1000, 544);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Controls.Add(layoutDashboard);
        //
        // layoutDashboard
        //
        layoutDashboard.Margin = new Padding(0);
        layoutDashboard.Dock = DockStyle.Fill;
        layoutDashboard.Padding = new Padding(16, 20, 16, 18);
        layoutDashboard.ColumnCount = 1;
        layoutDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutDashboard.RowCount = 3;
        layoutDashboard.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
        layoutDashboard.RowStyles.Add(new RowStyle(SizeType.Absolute, 430F));
        layoutDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDashboard.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutDashboard.MinimumSize = new Size(1000, 544);
        layoutDashboard.Name = "layoutDashboard";
        layoutDashboard.Controls.Add(layoutHeading, 0, 0);
        layoutDashboard.Controls.Add(layoutOverview, 0, 1);
        //
        // layoutHeading
        //
        layoutHeading.Margin = new Padding(3, 0, 0, 10);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.ColumnCount = 3;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.RowCount = 1;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeading.Name = "layoutHeading";
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblShiftStatus, 1, 0);
        //
        // lblTitle
        //
        lblTitle.Margin = new Padding(0, 0, 17, 0);
        lblTitle.Font = new Font("Segoe UI", 19.5F, FontStyle.Bold);
        lblTitle.Text = "Tổng quan ca làm việc";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        lblTitle.Anchor = AnchorStyles.Left;
        lblTitle.AutoSize = true;
        lblTitle.Name = "lblTitle";
        //
        // lblShiftStatus
        //
        lblShiftStatus.Margin = new Padding(0);
        lblShiftStatus.BackColor = Color.FromArgb(220, 252, 231);
        lblShiftStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblShiftStatus.ForeColor = Color.FromArgb(22, 101, 52);
        lblShiftStatus.Text = "Đang trong ca";
        lblShiftStatus.TextAlign = ContentAlignment.MiddleCenter;
        lblShiftStatus.UseMnemonic = false;
        lblShiftStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        lblShiftStatus.Size = new Size(120, 30);
        lblShiftStatus.Name = "lblShiftStatus";
        //
        // layoutOverview
        //
        layoutOverview.Margin = new Padding(0);
        layoutOverview.Dock = DockStyle.Fill;
        layoutOverview.ColumnCount = 2;
        layoutOverview.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 315F));
        layoutOverview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutOverview.RowCount = 1;
        layoutOverview.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutOverview.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutOverview.Name = "layoutOverview";
        layoutOverview.Controls.Add(pnlCurrentShift, 0, 0);
        layoutOverview.Controls.Add(layoutReports, 1, 0);
        //
        // pnlCurrentShift
        //
        pnlCurrentShift.Margin = new Padding(0, 0, 12, 0);
        pnlCurrentShift.Dock = DockStyle.Fill;
        pnlCurrentShift.BackColor = Color.FromArgb(226, 232, 240);
        pnlCurrentShift.Padding = new Padding(1);
        pnlCurrentShift.Name = "pnlCurrentShift";
        pnlCurrentShift.Controls.Add(layoutCurrentShift);
        //
        // layoutCurrentShift
        //
        layoutCurrentShift.Margin = new Padding(0);
        layoutCurrentShift.Dock = DockStyle.Fill;
        layoutCurrentShift.BackColor = Color.White;
        layoutCurrentShift.Padding = new Padding(17, 14, 17, 26);
        layoutCurrentShift.ColumnCount = 1;
        layoutCurrentShift.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutCurrentShift.RowCount = 13;
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCurrentShift.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        layoutCurrentShift.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCurrentShift.Name = "layoutCurrentShift";
        layoutCurrentShift.Controls.Add(lblCurrentShiftTitle, 0, 0);
        layoutCurrentShift.Controls.Add(layoutEmployee, 0, 1);
        layoutCurrentShift.Controls.Add(pnlEmployeeDivider, 0, 2);
        layoutCurrentShift.Controls.Add(layoutShiftCode, 0, 3);
        layoutCurrentShift.Controls.Add(pnlShiftCodeDivider, 0, 4);
        layoutCurrentShift.Controls.Add(layoutTerminal, 0, 5);
        layoutCurrentShift.Controls.Add(pnlTerminalDivider, 0, 6);
        layoutCurrentShift.Controls.Add(layoutOpenedAt, 0, 7);
        layoutCurrentShift.Controls.Add(pnlOpenedAtDivider, 0, 8);
        layoutCurrentShift.Controls.Add(layoutStartingCash, 0, 9);
        layoutCurrentShift.Controls.Add(pnlStartingCashDivider, 0, 10);
        layoutCurrentShift.Controls.Add(btnCloseShift, 0, 12);
        //
        // lblCurrentShiftTitle
        //
        lblCurrentShiftTitle.Margin = new Padding(0);
        lblCurrentShiftTitle.Dock = DockStyle.Fill;
        lblCurrentShiftTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblCurrentShiftTitle.Text = "Ca hiện tại";
        lblCurrentShiftTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblCurrentShiftTitle.UseMnemonic = false;
        lblCurrentShiftTitle.Name = "lblCurrentShiftTitle";
        //
        // layoutEmployee
        //
        layoutEmployee.Margin = new Padding(0);
        layoutEmployee.Dock = DockStyle.Fill;
        layoutEmployee.ColumnCount = 2;
        layoutEmployee.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        layoutEmployee.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        layoutEmployee.RowCount = 1;
        layoutEmployee.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutEmployee.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEmployee.Name = "layoutEmployee";
        layoutEmployee.Controls.Add(lblEmployeeCaption, 0, 0);
        layoutEmployee.Controls.Add(lblEmployeeValue, 1, 0);
        //
        // lblEmployeeCaption
        //
        lblEmployeeCaption.Margin = new Padding(0);
        lblEmployeeCaption.Dock = DockStyle.Fill;
        lblEmployeeCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblEmployeeCaption.Text = "Nhân viên";
        lblEmployeeCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblEmployeeCaption.UseMnemonic = false;
        lblEmployeeCaption.Name = "lblEmployeeCaption";
        //
        // lblEmployeeValue
        //
        lblEmployeeValue.Margin = new Padding(0);
        lblEmployeeValue.Dock = DockStyle.Fill;
        lblEmployeeValue.Padding = new Padding(0, 0, 1, 0);
        lblEmployeeValue.Text = "Nguyễn Văn A";
        lblEmployeeValue.TextAlign = ContentAlignment.MiddleRight;
        lblEmployeeValue.UseMnemonic = false;
        lblEmployeeValue.Name = "lblEmployeeValue";
        //
        // pnlEmployeeDivider
        //
        pnlEmployeeDivider.Margin = new Padding(0);
        pnlEmployeeDivider.Dock = DockStyle.Fill;
        pnlEmployeeDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlEmployeeDivider.Name = "pnlEmployeeDivider";
        //
        // layoutShiftCode
        //
        layoutShiftCode.Margin = new Padding(0);
        layoutShiftCode.Dock = DockStyle.Fill;
        layoutShiftCode.ColumnCount = 2;
        layoutShiftCode.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        layoutShiftCode.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        layoutShiftCode.RowCount = 1;
        layoutShiftCode.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutShiftCode.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutShiftCode.Name = "layoutShiftCode";
        layoutShiftCode.Controls.Add(lblShiftCodeCaption, 0, 0);
        layoutShiftCode.Controls.Add(lblShiftCodeValue, 1, 0);
        //
        // lblShiftCodeCaption
        //
        lblShiftCodeCaption.Margin = new Padding(0);
        lblShiftCodeCaption.Dock = DockStyle.Fill;
        lblShiftCodeCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblShiftCodeCaption.Text = "Mã ca";
        lblShiftCodeCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblShiftCodeCaption.UseMnemonic = false;
        lblShiftCodeCaption.Name = "lblShiftCodeCaption";
        //
        // lblShiftCodeValue
        //
        lblShiftCodeValue.Margin = new Padding(0);
        lblShiftCodeValue.Dock = DockStyle.Fill;
        lblShiftCodeValue.Padding = new Padding(0, 0, 1, 0);
        lblShiftCodeValue.Text = "CA-CHIEU-01";
        lblShiftCodeValue.TextAlign = ContentAlignment.MiddleRight;
        lblShiftCodeValue.UseMnemonic = false;
        lblShiftCodeValue.Name = "lblShiftCodeValue";
        //
        // pnlShiftCodeDivider
        //
        pnlShiftCodeDivider.Margin = new Padding(0);
        pnlShiftCodeDivider.Dock = DockStyle.Fill;
        pnlShiftCodeDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlShiftCodeDivider.Name = "pnlShiftCodeDivider";
        //
        // layoutTerminal
        //
        layoutTerminal.Margin = new Padding(0);
        layoutTerminal.Dock = DockStyle.Fill;
        layoutTerminal.ColumnCount = 2;
        layoutTerminal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        layoutTerminal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        layoutTerminal.RowCount = 1;
        layoutTerminal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTerminal.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTerminal.Name = "layoutTerminal";
        layoutTerminal.Controls.Add(lblTerminalCaption, 0, 0);
        layoutTerminal.Controls.Add(lblTerminalValue, 1, 0);
        //
        // lblTerminalCaption
        //
        lblTerminalCaption.Margin = new Padding(0);
        lblTerminalCaption.Dock = DockStyle.Fill;
        lblTerminalCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblTerminalCaption.Text = "Quầy";
        lblTerminalCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTerminalCaption.UseMnemonic = false;
        lblTerminalCaption.Name = "lblTerminalCaption";
        //
        // lblTerminalValue
        //
        lblTerminalValue.Margin = new Padding(0);
        lblTerminalValue.Dock = DockStyle.Fill;
        lblTerminalValue.Padding = new Padding(0, 0, 1, 0);
        lblTerminalValue.Text = "POS-01";
        lblTerminalValue.TextAlign = ContentAlignment.MiddleRight;
        lblTerminalValue.UseMnemonic = false;
        lblTerminalValue.Name = "lblTerminalValue";
        //
        // pnlTerminalDivider
        //
        pnlTerminalDivider.Margin = new Padding(0);
        pnlTerminalDivider.Dock = DockStyle.Fill;
        pnlTerminalDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlTerminalDivider.Name = "pnlTerminalDivider";
        //
        // layoutOpenedAt
        //
        layoutOpenedAt.Margin = new Padding(0);
        layoutOpenedAt.Dock = DockStyle.Fill;
        layoutOpenedAt.ColumnCount = 2;
        layoutOpenedAt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        layoutOpenedAt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        layoutOpenedAt.RowCount = 1;
        layoutOpenedAt.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutOpenedAt.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutOpenedAt.Name = "layoutOpenedAt";
        layoutOpenedAt.Controls.Add(lblOpenedAtCaption, 0, 0);
        layoutOpenedAt.Controls.Add(lblOpenedAtValue, 1, 0);
        //
        // lblOpenedAtCaption
        //
        lblOpenedAtCaption.Margin = new Padding(0);
        lblOpenedAtCaption.Dock = DockStyle.Fill;
        lblOpenedAtCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblOpenedAtCaption.Text = "Giờ mở ca";
        lblOpenedAtCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblOpenedAtCaption.UseMnemonic = false;
        lblOpenedAtCaption.Name = "lblOpenedAtCaption";
        //
        // lblOpenedAtValue
        //
        lblOpenedAtValue.Margin = new Padding(0);
        lblOpenedAtValue.Dock = DockStyle.Fill;
        lblOpenedAtValue.Padding = new Padding(0, 0, 1, 0);
        lblOpenedAtValue.Text = "13:55";
        lblOpenedAtValue.TextAlign = ContentAlignment.MiddleRight;
        lblOpenedAtValue.UseMnemonic = false;
        lblOpenedAtValue.Name = "lblOpenedAtValue";
        //
        // pnlOpenedAtDivider
        //
        pnlOpenedAtDivider.Margin = new Padding(0);
        pnlOpenedAtDivider.Dock = DockStyle.Fill;
        pnlOpenedAtDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlOpenedAtDivider.Name = "pnlOpenedAtDivider";
        //
        // layoutStartingCash
        //
        layoutStartingCash.Margin = new Padding(0);
        layoutStartingCash.Dock = DockStyle.Fill;
        layoutStartingCash.ColumnCount = 2;
        layoutStartingCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        layoutStartingCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        layoutStartingCash.RowCount = 1;
        layoutStartingCash.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStartingCash.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStartingCash.Name = "layoutStartingCash";
        layoutStartingCash.Controls.Add(lblStartingCashCaption, 0, 0);
        layoutStartingCash.Controls.Add(lblStartingCashValue, 1, 0);
        //
        // lblStartingCashCaption
        //
        lblStartingCashCaption.Margin = new Padding(0);
        lblStartingCashCaption.Dock = DockStyle.Fill;
        lblStartingCashCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblStartingCashCaption.Text = "Quỹ đầu ca";
        lblStartingCashCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblStartingCashCaption.UseMnemonic = false;
        lblStartingCashCaption.Name = "lblStartingCashCaption";
        //
        // lblStartingCashValue
        //
        lblStartingCashValue.Margin = new Padding(0);
        lblStartingCashValue.Dock = DockStyle.Fill;
        lblStartingCashValue.Padding = new Padding(0, 0, 1, 0);
        lblStartingCashValue.Text = "2.000.000 đ";
        lblStartingCashValue.TextAlign = ContentAlignment.MiddleRight;
        lblStartingCashValue.UseMnemonic = false;
        lblStartingCashValue.Name = "lblStartingCashValue";
        //
        // pnlStartingCashDivider
        //
        pnlStartingCashDivider.Margin = new Padding(0);
        pnlStartingCashDivider.Dock = DockStyle.Fill;
        pnlStartingCashDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlStartingCashDivider.Name = "pnlStartingCashDivider";
        //
        // btnCloseShift
        //
        btnCloseShift.Margin = new Padding(0);
        btnCloseShift.Dock = DockStyle.Fill;
        btnCloseShift.BackColor = Color.FromArgb(37, 99, 235);
        btnCloseShift.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnCloseShift.ForeColor = Color.White;
        btnCloseShift.FlatAppearance.BorderSize = 0;
        btnCloseShift.FlatStyle = FlatStyle.Flat;
        btnCloseShift.Text = "Kết ca & bàn giao  →";
        btnCloseShift.UseMnemonic = false;
        btnCloseShift.UseVisualStyleBackColor = false;
        btnCloseShift.Name = "btnCloseShift";
        btnCloseShift.Click += BtnCloseShift_Click;
        //
        // layoutReports
        //
        layoutReports.Margin = new Padding(0);
        layoutReports.Dock = DockStyle.Fill;
        layoutReports.ColumnCount = 1;
        layoutReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutReports.RowCount = 2;
        layoutReports.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
        layoutReports.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutReports.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutReports.Name = "layoutReports";
        layoutReports.Controls.Add(layoutSummary, 0, 0);
        layoutReports.Controls.Add(pnlHistory, 0, 1);
        //
        // layoutSummary
        //
        layoutSummary.Margin = new Padding(0);
        layoutSummary.Dock = DockStyle.Fill;
        layoutSummary.ColumnCount = 3;
        layoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
        layoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
        layoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
        layoutSummary.RowCount = 1;
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSummary.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSummary.Name = "layoutSummary";
        layoutSummary.Controls.Add(pnlInvoices, 0, 0);
        layoutSummary.Controls.Add(pnlTickets, 1, 0);
        layoutSummary.Controls.Add(pnlTurnover, 2, 0);
        //
        // pnlInvoices
        //
        pnlInvoices.Margin = new Padding(0, 0, 10, 0);
        pnlInvoices.Dock = DockStyle.Fill;
        pnlInvoices.BackColor = Color.FromArgb(226, 232, 240);
        pnlInvoices.Padding = new Padding(1);
        pnlInvoices.Name = "pnlInvoices";
        pnlInvoices.Controls.Add(layoutInvoices);
        //
        // layoutInvoices
        //
        layoutInvoices.Margin = new Padding(0);
        layoutInvoices.Dock = DockStyle.Fill;
        layoutInvoices.BackColor = Color.White;
        layoutInvoices.Padding = new Padding(13, 9, 12, 11);
        layoutInvoices.ColumnCount = 2;
        layoutInvoices.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        layoutInvoices.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutInvoices.RowCount = 2;
        layoutInvoices.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutInvoices.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutInvoices.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutInvoices.Name = "layoutInvoices";
        layoutInvoices.Controls.Add(lblInvoicesIcon, 0, 0);
        layoutInvoices.Controls.Add(lblInvoicesCaption, 1, 0);
        layoutInvoices.Controls.Add(lblInvoicesValue, 0, 1);
        layoutInvoices.SetColumnSpan(lblInvoicesValue, 2);
        //
        // lblInvoicesIcon
        //
        lblInvoicesIcon.Margin = new Padding(0);
        lblInvoicesIcon.Dock = DockStyle.Fill;
        lblInvoicesIcon.Font = new Font("Segoe MDL2 Assets", 15F);
        lblInvoicesIcon.ForeColor = Color.FromArgb(51, 65, 85);
        lblInvoicesIcon.Text = "\uE8A5";
        lblInvoicesIcon.TextAlign = ContentAlignment.MiddleLeft;
        lblInvoicesIcon.UseMnemonic = false;
        lblInvoicesIcon.AccessibleRole = AccessibleRole.Graphic;
        lblInvoicesIcon.Name = "lblInvoicesIcon";
        //
        // lblInvoicesCaption
        //
        lblInvoicesCaption.Margin = new Padding(0);
        lblInvoicesCaption.Dock = DockStyle.Fill;
        lblInvoicesCaption.Font = new Font("Segoe UI", 9.5F);
        lblInvoicesCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblInvoicesCaption.Text = "Hóa đơn đã lập";
        lblInvoicesCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblInvoicesCaption.UseMnemonic = false;
        lblInvoicesCaption.Name = "lblInvoicesCaption";
        //
        // lblInvoicesValue
        //
        lblInvoicesValue.Margin = new Padding(0);
        lblInvoicesValue.Dock = DockStyle.Fill;
        lblInvoicesValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblInvoicesValue.Text = "48";
        lblInvoicesValue.TextAlign = ContentAlignment.MiddleLeft;
        lblInvoicesValue.UseMnemonic = false;
        lblInvoicesValue.Name = "lblInvoicesValue";
        //
        // pnlTickets
        //
        pnlTickets.Margin = new Padding(0, 0, 10, 0);
        pnlTickets.Dock = DockStyle.Fill;
        pnlTickets.BackColor = Color.FromArgb(226, 232, 240);
        pnlTickets.Padding = new Padding(1);
        pnlTickets.Name = "pnlTickets";
        pnlTickets.Controls.Add(layoutTickets);
        //
        // layoutTickets
        //
        layoutTickets.Margin = new Padding(0);
        layoutTickets.Dock = DockStyle.Fill;
        layoutTickets.BackColor = Color.White;
        layoutTickets.Padding = new Padding(13, 9, 12, 11);
        layoutTickets.ColumnCount = 2;
        layoutTickets.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        layoutTickets.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTickets.RowCount = 2;
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTickets.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTickets.Name = "layoutTickets";
        layoutTickets.Controls.Add(lblTicketsIcon, 0, 0);
        layoutTickets.Controls.Add(lblTicketsCaption, 1, 0);
        layoutTickets.Controls.Add(lblTicketsValue, 0, 1);
        layoutTickets.SetColumnSpan(lblTicketsValue, 2);
        //
        // lblTicketsIcon
        //
        lblTicketsIcon.Margin = new Padding(0);
        lblTicketsIcon.Dock = DockStyle.Fill;
        lblTicketsIcon.Font = new Font("Segoe MDL2 Assets", 15F);
        lblTicketsIcon.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketsIcon.Text = "\uE8EC";
        lblTicketsIcon.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketsIcon.UseMnemonic = false;
        lblTicketsIcon.AccessibleRole = AccessibleRole.Graphic;
        lblTicketsIcon.Name = "lblTicketsIcon";
        //
        // lblTicketsCaption
        //
        lblTicketsCaption.Margin = new Padding(0);
        lblTicketsCaption.Dock = DockStyle.Fill;
        lblTicketsCaption.Font = new Font("Segoe UI", 9.5F);
        lblTicketsCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketsCaption.Text = "Vé bán / Vé hủy";
        lblTicketsCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketsCaption.UseMnemonic = false;
        lblTicketsCaption.Name = "lblTicketsCaption";
        //
        // lblTicketsValue
        //
        lblTicketsValue.Margin = new Padding(0);
        lblTicketsValue.Dock = DockStyle.Fill;
        lblTicketsValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTicketsValue.Text = "95 / 2";
        lblTicketsValue.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketsValue.UseMnemonic = false;
        lblTicketsValue.Name = "lblTicketsValue";
        //
        // pnlTurnover
        //
        pnlTurnover.Margin = new Padding(0, 0, 0, 0);
        pnlTurnover.Dock = DockStyle.Fill;
        pnlTurnover.BackColor = Color.FromArgb(226, 232, 240);
        pnlTurnover.Padding = new Padding(1);
        pnlTurnover.Name = "pnlTurnover";
        pnlTurnover.Controls.Add(layoutTurnover);
        //
        // layoutTurnover
        //
        layoutTurnover.Margin = new Padding(0);
        layoutTurnover.Dock = DockStyle.Fill;
        layoutTurnover.BackColor = Color.White;
        layoutTurnover.Padding = new Padding(13, 9, 8, 11);
        layoutTurnover.ColumnCount = 2;
        layoutTurnover.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        layoutTurnover.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTurnover.RowCount = 2;
        layoutTurnover.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutTurnover.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTurnover.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTurnover.Name = "layoutTurnover";
        layoutTurnover.Controls.Add(lblTurnoverIcon, 0, 0);
        layoutTurnover.Controls.Add(lblTurnoverCaption, 1, 0);
        layoutTurnover.Controls.Add(lblTurnoverValue, 0, 1);
        layoutTurnover.SetColumnSpan(lblTurnoverValue, 2);
        //
        // lblTurnoverIcon
        //
        lblTurnoverIcon.Margin = new Padding(0);
        lblTurnoverIcon.Dock = DockStyle.Fill;
        lblTurnoverIcon.Font = new Font("Segoe MDL2 Assets", 15F);
        lblTurnoverIcon.ForeColor = Color.FromArgb(51, 65, 85);
        lblTurnoverIcon.Text = "\uE825";
        lblTurnoverIcon.TextAlign = ContentAlignment.MiddleLeft;
        lblTurnoverIcon.UseMnemonic = false;
        lblTurnoverIcon.AccessibleRole = AccessibleRole.Graphic;
        lblTurnoverIcon.Name = "lblTurnoverIcon";
        //
        // lblTurnoverCaption
        //
        lblTurnoverCaption.Margin = new Padding(0);
        lblTurnoverCaption.Dock = DockStyle.Fill;
        lblTurnoverCaption.Font = new Font("Segoe UI", 9.5F);
        lblTurnoverCaption.ForeColor = Color.FromArgb(51, 65, 85);
        lblTurnoverCaption.Text = "Tổng thu trước hoàn tiền";
        lblTurnoverCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTurnoverCaption.UseMnemonic = false;
        lblTurnoverCaption.Name = "lblTurnoverCaption";
        //
        // lblTurnoverValue
        //
        lblTurnoverValue.Margin = new Padding(0);
        lblTurnoverValue.Dock = DockStyle.Fill;
        lblTurnoverValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTurnoverValue.Text = "12.250.000 đ";
        lblTurnoverValue.TextAlign = ContentAlignment.MiddleLeft;
        lblTurnoverValue.UseMnemonic = false;
        lblTurnoverValue.Name = "lblTurnoverValue";
        //
        // pnlHistory
        //
        pnlHistory.Margin = new Padding(0, 14, 0, 0);
        pnlHistory.Dock = DockStyle.Fill;
        pnlHistory.BackColor = Color.FromArgb(226, 232, 240);
        pnlHistory.Padding = new Padding(1);
        pnlHistory.Name = "pnlHistory";
        pnlHistory.Controls.Add(layoutHistory);
        //
        // layoutHistory
        //
        layoutHistory.Margin = new Padding(0);
        layoutHistory.Dock = DockStyle.Fill;
        layoutHistory.BackColor = Color.White;
        layoutHistory.Padding = new Padding(12, 10, 12, 20);
        layoutHistory.ColumnCount = 1;
        layoutHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHistory.RowCount = 2;
        layoutHistory.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHistory.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHistory.Name = "layoutHistory";
        layoutHistory.Controls.Add(lblHistoryTitle, 0, 0);
        layoutHistory.Controls.Add(pnlHistoryTable, 0, 1);
        //
        // lblHistoryTitle
        //
        lblHistoryTitle.Margin = new Padding(0);
        lblHistoryTitle.Dock = DockStyle.Fill;
        lblHistoryTitle.Padding = new Padding(3, 0, 0, 6);
        lblHistoryTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblHistoryTitle.Text = "Lịch sử ca của tôi";
        lblHistoryTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryTitle.UseMnemonic = false;
        lblHistoryTitle.Name = "lblHistoryTitle";
        //
        // pnlHistoryTable
        //
        pnlHistoryTable.Margin = new Padding(0);
        pnlHistoryTable.Dock = DockStyle.Fill;
        pnlHistoryTable.BackColor = Color.FromArgb(226, 232, 240);
        pnlHistoryTable.Padding = new Padding(1);
        pnlHistoryTable.Name = "pnlHistoryTable";
        pnlHistoryTable.Controls.Add(layoutHistoryTable);
        //
        // layoutHistoryTable
        //
        layoutHistoryTable.Margin = new Padding(0);
        layoutHistoryTable.Dock = DockStyle.Fill;
        layoutHistoryTable.BackColor = Color.White;
        layoutHistoryTable.ColumnCount = 4;
        layoutHistoryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutHistoryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        layoutHistoryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        layoutHistoryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
        layoutHistoryTable.RowCount = 9;
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutHistoryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        layoutHistoryTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHistoryTable.Name = "layoutHistoryTable";
        layoutHistoryTable.Controls.Add(lblHistoryDateHeader, 0, 0);
        layoutHistoryTable.Controls.Add(lblHistoryStationHeader, 1, 0);
        layoutHistoryTable.Controls.Add(lblHistoryVarianceHeader, 2, 0);
        layoutHistoryTable.Controls.Add(lblHistoryStatusHeader, 3, 0);
        layoutHistoryTable.Controls.Add(pnlHistoryDivider1, 0, 1);
        layoutHistoryTable.SetColumnSpan(pnlHistoryDivider1, 4);
        layoutHistoryTable.Controls.Add(lblHistoryDate1, 0, 2);
        layoutHistoryTable.Controls.Add(lblHistoryStation1, 1, 2);
        layoutHistoryTable.Controls.Add(lblHistoryVariance1, 2, 2);
        layoutHistoryTable.Controls.Add(lblHistoryStatus1, 3, 2);
        layoutHistoryTable.Controls.Add(pnlHistoryDivider2, 0, 3);
        layoutHistoryTable.SetColumnSpan(pnlHistoryDivider2, 4);
        layoutHistoryTable.Controls.Add(lblHistoryDate2, 0, 4);
        layoutHistoryTable.Controls.Add(lblHistoryStation2, 1, 4);
        layoutHistoryTable.Controls.Add(lblHistoryVariance2, 2, 4);
        layoutHistoryTable.Controls.Add(lblHistoryStatus2, 3, 4);
        layoutHistoryTable.Controls.Add(pnlHistoryDivider3, 0, 5);
        layoutHistoryTable.SetColumnSpan(pnlHistoryDivider3, 4);
        layoutHistoryTable.Controls.Add(lblHistoryDate3, 0, 6);
        layoutHistoryTable.Controls.Add(lblHistoryStation3, 1, 6);
        layoutHistoryTable.Controls.Add(lblHistoryVariance3, 2, 6);
        layoutHistoryTable.Controls.Add(lblHistoryStatus3, 3, 6);
        layoutHistoryTable.Controls.Add(pnlHistoryDivider4, 0, 7);
        layoutHistoryTable.SetColumnSpan(pnlHistoryDivider4, 4);
        layoutHistoryTable.Controls.Add(lblHistoryDate4, 0, 8);
        layoutHistoryTable.Controls.Add(lblHistoryStation4, 1, 8);
        layoutHistoryTable.Controls.Add(lblHistoryVariance4, 2, 8);
        layoutHistoryTable.Controls.Add(lblHistoryStatus4, 3, 8);
        //
        // lblHistoryDateHeader
        //
        lblHistoryDateHeader.Margin = new Padding(0);
        lblHistoryDateHeader.Dock = DockStyle.Fill;
        lblHistoryDateHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblHistoryDateHeader.Padding = new Padding(12, 0, 0, 0);
        lblHistoryDateHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblHistoryDateHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblHistoryDateHeader.Text = "Ngày";
        lblHistoryDateHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryDateHeader.UseMnemonic = false;
        lblHistoryDateHeader.Name = "lblHistoryDateHeader";
        //
        // lblHistoryStationHeader
        //
        lblHistoryStationHeader.Margin = new Padding(0);
        lblHistoryStationHeader.Dock = DockStyle.Fill;
        lblHistoryStationHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblHistoryStationHeader.Padding = new Padding(12, 0, 0, 0);
        lblHistoryStationHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblHistoryStationHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblHistoryStationHeader.Text = "Ca / Quầy";
        lblHistoryStationHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryStationHeader.UseMnemonic = false;
        lblHistoryStationHeader.Name = "lblHistoryStationHeader";
        //
        // lblHistoryVarianceHeader
        //
        lblHistoryVarianceHeader.Margin = new Padding(0);
        lblHistoryVarianceHeader.Dock = DockStyle.Fill;
        lblHistoryVarianceHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblHistoryVarianceHeader.Padding = new Padding(0, 0, 16, 0);
        lblHistoryVarianceHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblHistoryVarianceHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblHistoryVarianceHeader.Text = "Chênh lệch tiền mặt";
        lblHistoryVarianceHeader.TextAlign = ContentAlignment.MiddleRight;
        lblHistoryVarianceHeader.UseMnemonic = false;
        lblHistoryVarianceHeader.Name = "lblHistoryVarianceHeader";
        //
        // lblHistoryStatusHeader
        //
        lblHistoryStatusHeader.Margin = new Padding(0);
        lblHistoryStatusHeader.Dock = DockStyle.Fill;
        lblHistoryStatusHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblHistoryStatusHeader.Padding = new Padding(0);
        lblHistoryStatusHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblHistoryStatusHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblHistoryStatusHeader.Text = "Trạng thái";
        lblHistoryStatusHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblHistoryStatusHeader.UseMnemonic = false;
        lblHistoryStatusHeader.Name = "lblHistoryStatusHeader";
        //
        // pnlHistoryDivider1
        //
        pnlHistoryDivider1.Margin = new Padding(0);
        pnlHistoryDivider1.Dock = DockStyle.Fill;
        pnlHistoryDivider1.BackColor = Color.FromArgb(226, 232, 240);
        pnlHistoryDivider1.Name = "pnlHistoryDivider1";
        //
        // lblHistoryDate1
        //
        lblHistoryDate1.Margin = new Padding(0);
        lblHistoryDate1.Dock = DockStyle.Fill;
        lblHistoryDate1.Padding = new Padding(12, 0, 0, 0);
        lblHistoryDate1.Text = "22/11/2026";
        lblHistoryDate1.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryDate1.UseMnemonic = false;
        lblHistoryDate1.Name = "lblHistoryDate1";
        //
        // lblHistoryStation1
        //
        lblHistoryStation1.Margin = new Padding(0);
        lblHistoryStation1.Dock = DockStyle.Fill;
        lblHistoryStation1.Padding = new Padding(12, 0, 0, 0);
        lblHistoryStation1.Text = "Ca chiều · POS-01";
        lblHistoryStation1.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryStation1.UseMnemonic = false;
        lblHistoryStation1.Name = "lblHistoryStation1";
        //
        // lblHistoryVariance1
        //
        lblHistoryVariance1.Margin = new Padding(0);
        lblHistoryVariance1.Dock = DockStyle.Fill;
        lblHistoryVariance1.Padding = new Padding(0, 0, 16, 0);
        lblHistoryVariance1.Text = "0 đ";
        lblHistoryVariance1.TextAlign = ContentAlignment.MiddleRight;
        lblHistoryVariance1.UseMnemonic = false;
        lblHistoryVariance1.Name = "lblHistoryVariance1";
        //
        // lblHistoryStatus1
        //
        lblHistoryStatus1.Margin = new Padding(0);
        lblHistoryStatus1.BackColor = Color.FromArgb(220, 252, 231);
        lblHistoryStatus1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHistoryStatus1.ForeColor = Color.FromArgb(22, 101, 52);
        lblHistoryStatus1.Text = "Đã bàn giao";
        lblHistoryStatus1.TextAlign = ContentAlignment.MiddleCenter;
        lblHistoryStatus1.UseMnemonic = false;
        lblHistoryStatus1.Anchor = AnchorStyles.None;
        lblHistoryStatus1.Size = new Size(106, 25);
        lblHistoryStatus1.Name = "lblHistoryStatus1";
        //
        // pnlHistoryDivider2
        //
        pnlHistoryDivider2.Margin = new Padding(0);
        pnlHistoryDivider2.Dock = DockStyle.Fill;
        pnlHistoryDivider2.BackColor = Color.FromArgb(226, 232, 240);
        pnlHistoryDivider2.Name = "pnlHistoryDivider2";
        //
        // lblHistoryDate2
        //
        lblHistoryDate2.Margin = new Padding(0);
        lblHistoryDate2.Dock = DockStyle.Fill;
        lblHistoryDate2.Padding = new Padding(12, 0, 0, 0);
        lblHistoryDate2.Text = "21/11/2026";
        lblHistoryDate2.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryDate2.UseMnemonic = false;
        lblHistoryDate2.Name = "lblHistoryDate2";
        //
        // lblHistoryStation2
        //
        lblHistoryStation2.Margin = new Padding(0);
        lblHistoryStation2.Dock = DockStyle.Fill;
        lblHistoryStation2.Padding = new Padding(12, 0, 0, 0);
        lblHistoryStation2.Text = "Ca chiều · POS-01";
        lblHistoryStation2.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryStation2.UseMnemonic = false;
        lblHistoryStation2.Name = "lblHistoryStation2";
        //
        // lblHistoryVariance2
        //
        lblHistoryVariance2.Margin = new Padding(0);
        lblHistoryVariance2.Dock = DockStyle.Fill;
        lblHistoryVariance2.Padding = new Padding(0, 0, 16, 0);
        lblHistoryVariance2.ForeColor = Color.FromArgb(185, 28, 28);
        lblHistoryVariance2.Text = "−20.000 đ";
        lblHistoryVariance2.TextAlign = ContentAlignment.MiddleRight;
        lblHistoryVariance2.UseMnemonic = false;
        lblHistoryVariance2.Name = "lblHistoryVariance2";
        //
        // lblHistoryStatus2
        //
        lblHistoryStatus2.Margin = new Padding(0);
        lblHistoryStatus2.BackColor = Color.FromArgb(220, 252, 231);
        lblHistoryStatus2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHistoryStatus2.ForeColor = Color.FromArgb(22, 101, 52);
        lblHistoryStatus2.Text = "Đã bàn giao";
        lblHistoryStatus2.TextAlign = ContentAlignment.MiddleCenter;
        lblHistoryStatus2.UseMnemonic = false;
        lblHistoryStatus2.Anchor = AnchorStyles.None;
        lblHistoryStatus2.Size = new Size(106, 25);
        lblHistoryStatus2.Name = "lblHistoryStatus2";
        //
        // pnlHistoryDivider3
        //
        pnlHistoryDivider3.Margin = new Padding(0);
        pnlHistoryDivider3.Dock = DockStyle.Fill;
        pnlHistoryDivider3.BackColor = Color.FromArgb(226, 232, 240);
        pnlHistoryDivider3.Name = "pnlHistoryDivider3";
        //
        // lblHistoryDate3
        //
        lblHistoryDate3.Margin = new Padding(0);
        lblHistoryDate3.Dock = DockStyle.Fill;
        lblHistoryDate3.Padding = new Padding(12, 0, 0, 0);
        lblHistoryDate3.Text = "20/11/2026";
        lblHistoryDate3.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryDate3.UseMnemonic = false;
        lblHistoryDate3.Name = "lblHistoryDate3";
        //
        // lblHistoryStation3
        //
        lblHistoryStation3.Margin = new Padding(0);
        lblHistoryStation3.Dock = DockStyle.Fill;
        lblHistoryStation3.Padding = new Padding(12, 0, 0, 0);
        lblHistoryStation3.Text = "Ca chiều · POS-01";
        lblHistoryStation3.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryStation3.UseMnemonic = false;
        lblHistoryStation3.Name = "lblHistoryStation3";
        //
        // lblHistoryVariance3
        //
        lblHistoryVariance3.Margin = new Padding(0);
        lblHistoryVariance3.Dock = DockStyle.Fill;
        lblHistoryVariance3.Padding = new Padding(0, 0, 16, 0);
        lblHistoryVariance3.Text = "0 đ";
        lblHistoryVariance3.TextAlign = ContentAlignment.MiddleRight;
        lblHistoryVariance3.UseMnemonic = false;
        lblHistoryVariance3.Name = "lblHistoryVariance3";
        //
        // lblHistoryStatus3
        //
        lblHistoryStatus3.Margin = new Padding(0);
        lblHistoryStatus3.BackColor = Color.FromArgb(220, 252, 231);
        lblHistoryStatus3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHistoryStatus3.ForeColor = Color.FromArgb(22, 101, 52);
        lblHistoryStatus3.Text = "Đã bàn giao";
        lblHistoryStatus3.TextAlign = ContentAlignment.MiddleCenter;
        lblHistoryStatus3.UseMnemonic = false;
        lblHistoryStatus3.Anchor = AnchorStyles.None;
        lblHistoryStatus3.Size = new Size(106, 25);
        lblHistoryStatus3.Name = "lblHistoryStatus3";
        //
        // pnlHistoryDivider4
        //
        pnlHistoryDivider4.Margin = new Padding(0);
        pnlHistoryDivider4.Dock = DockStyle.Fill;
        pnlHistoryDivider4.BackColor = Color.FromArgb(226, 232, 240);
        pnlHistoryDivider4.Name = "pnlHistoryDivider4";
        //
        // lblHistoryDate4
        //
        lblHistoryDate4.Margin = new Padding(0);
        lblHistoryDate4.Dock = DockStyle.Fill;
        lblHistoryDate4.Padding = new Padding(12, 0, 0, 0);
        lblHistoryDate4.Text = "19/11/2026";
        lblHistoryDate4.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryDate4.UseMnemonic = false;
        lblHistoryDate4.Name = "lblHistoryDate4";
        //
        // lblHistoryStation4
        //
        lblHistoryStation4.Margin = new Padding(0);
        lblHistoryStation4.Dock = DockStyle.Fill;
        lblHistoryStation4.Padding = new Padding(12, 0, 0, 0);
        lblHistoryStation4.Text = "Ca chiều · POS-01";
        lblHistoryStation4.TextAlign = ContentAlignment.MiddleLeft;
        lblHistoryStation4.UseMnemonic = false;
        lblHistoryStation4.Name = "lblHistoryStation4";
        //
        // lblHistoryVariance4
        //
        lblHistoryVariance4.Margin = new Padding(0);
        lblHistoryVariance4.Dock = DockStyle.Fill;
        lblHistoryVariance4.Padding = new Padding(0, 0, 16, 0);
        lblHistoryVariance4.Text = "0 đ";
        lblHistoryVariance4.TextAlign = ContentAlignment.MiddleRight;
        lblHistoryVariance4.UseMnemonic = false;
        lblHistoryVariance4.Name = "lblHistoryVariance4";
        //
        // lblHistoryStatus4
        //
        lblHistoryStatus4.Margin = new Padding(0);
        lblHistoryStatus4.BackColor = Color.FromArgb(220, 252, 231);
        lblHistoryStatus4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHistoryStatus4.ForeColor = Color.FromArgb(22, 101, 52);
        lblHistoryStatus4.Text = "Đã bàn giao";
        lblHistoryStatus4.TextAlign = ContentAlignment.MiddleCenter;
        lblHistoryStatus4.UseMnemonic = false;
        lblHistoryStatus4.Anchor = AnchorStyles.None;
        lblHistoryStatus4.Size = new Size(106, 25);
        lblHistoryStatus4.Name = "lblHistoryStatus4";
        //
        // ShiftManagementView
        //
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "ShiftManagementView";
        Size = new Size(1136, 722);
        layoutHistoryTable.ResumeLayout(false);
        pnlHistoryTable.ResumeLayout(false);
        layoutHistory.ResumeLayout(false);
        pnlHistory.ResumeLayout(false);
        layoutTurnover.ResumeLayout(false);
        pnlTurnover.ResumeLayout(false);
        layoutTickets.ResumeLayout(false);
        pnlTickets.ResumeLayout(false);
        layoutInvoices.ResumeLayout(false);
        pnlInvoices.ResumeLayout(false);
        layoutSummary.ResumeLayout(false);
        layoutReports.ResumeLayout(false);
        layoutStartingCash.ResumeLayout(false);
        layoutOpenedAt.ResumeLayout(false);
        layoutTerminal.ResumeLayout(false);
        layoutShiftCode.ResumeLayout(false);
        layoutEmployee.ResumeLayout(false);
        layoutCurrentShift.ResumeLayout(false);
        pnlCurrentShift.ResumeLayout(false);
        layoutOverview.ResumeLayout(false);
        layoutHeading.ResumeLayout(false);
        layoutHeading.PerformLayout();
        layoutDashboard.ResumeLayout(false);
        pnlViewport.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutDashboard;
    private TableLayoutPanel layoutHeading;
    private Label lblTitle;
    private Label lblShiftStatus;
    private TableLayoutPanel layoutOverview;
    private Panel pnlCurrentShift;
    private TableLayoutPanel layoutCurrentShift;
    private Label lblCurrentShiftTitle;
    private TableLayoutPanel layoutEmployee;
    private Label lblEmployeeCaption;
    private Label lblEmployeeValue;
    private Panel pnlEmployeeDivider;
    private TableLayoutPanel layoutShiftCode;
    private Label lblShiftCodeCaption;
    private Label lblShiftCodeValue;
    private Panel pnlShiftCodeDivider;
    private TableLayoutPanel layoutTerminal;
    private Label lblTerminalCaption;
    private Label lblTerminalValue;
    private Panel pnlTerminalDivider;
    private TableLayoutPanel layoutOpenedAt;
    private Label lblOpenedAtCaption;
    private Label lblOpenedAtValue;
    private Panel pnlOpenedAtDivider;
    private TableLayoutPanel layoutStartingCash;
    private Label lblStartingCashCaption;
    private Label lblStartingCashValue;
    private Panel pnlStartingCashDivider;
    private Button btnCloseShift;
    private TableLayoutPanel layoutReports;
    private TableLayoutPanel layoutSummary;
    private Panel pnlInvoices;
    private TableLayoutPanel layoutInvoices;
    private Label lblInvoicesIcon;
    private Label lblInvoicesCaption;
    private Label lblInvoicesValue;
    private Panel pnlTickets;
    private TableLayoutPanel layoutTickets;
    private Label lblTicketsIcon;
    private Label lblTicketsCaption;
    private Label lblTicketsValue;
    private Panel pnlTurnover;
    private TableLayoutPanel layoutTurnover;
    private Label lblTurnoverIcon;
    private Label lblTurnoverCaption;
    private Label lblTurnoverValue;
    private Panel pnlHistory;
    private TableLayoutPanel layoutHistory;
    private Label lblHistoryTitle;
    private Panel pnlHistoryTable;
    private TableLayoutPanel layoutHistoryTable;
    private Label lblHistoryDateHeader;
    private Label lblHistoryStationHeader;
    private Label lblHistoryVarianceHeader;
    private Label lblHistoryStatusHeader;
    private Panel pnlHistoryDivider1;
    private Label lblHistoryDate1;
    private Label lblHistoryStation1;
    private Label lblHistoryVariance1;
    private Label lblHistoryStatus1;
    private Panel pnlHistoryDivider2;
    private Label lblHistoryDate2;
    private Label lblHistoryStation2;
    private Label lblHistoryVariance2;
    private Label lblHistoryStatus2;
    private Panel pnlHistoryDivider3;
    private Label lblHistoryDate3;
    private Label lblHistoryStation3;
    private Label lblHistoryVariance3;
    private Label lblHistoryStatus3;
    private Panel pnlHistoryDivider4;
    private Label lblHistoryDate4;
    private Label lblHistoryStation4;
    private Label lblHistoryVariance4;
    private Label lblHistoryStatus4;
}

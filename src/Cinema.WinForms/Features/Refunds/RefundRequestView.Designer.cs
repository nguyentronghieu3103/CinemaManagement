namespace Cinema.WinForms.Features.Refunds;

partial class RefundRequestView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        layoutHeading = new TableLayoutPanel();
        lblTitle = new Label();
        lblOrderCode = new Label();
        pnlEligibility = new Panel();
        layoutEligibility = new TableLayoutPanel();
        lblEligibleIcon = new Label();
        pnlEligibilityDivider = new Panel();
        layoutEligibilityMessage = new TableLayoutPanel();
        lblEligibilityTitle = new Label();
        lblEligibilityDetails = new Label();
        layoutBody = new TableLayoutPanel();
        pnlItems = new Panel();
        layoutItems = new TableLayoutPanel();
        lblItemsTitle = new Label();
        lblShowtime = new Label();
        pnlItemGrid = new Panel();
        layoutItemGrid = new TableLayoutPanel();
        lblItemHeader = new Label();
        lblStatusHeader = new Label();
        lblAmountHeader = new Label();
        lblItem1 = new Label();
        layoutStatus1 = new TableLayoutPanel();
        lblItemStatus1 = new Label();
        lblItemAmount1 = new Label();
        lblItem2 = new Label();
        layoutStatus2 = new TableLayoutPanel();
        lblItemStatus2 = new Label();
        lblItemAmount2 = new Label();
        pnlRequest = new Panel();
        layoutRequest = new TableLayoutPanel();
        lblRequestTitle = new Label();
        layoutExpectedRefund = new TableLayoutPanel();
        lblExpectedRefundCaption = new Label();
        lblExpectedRefund = new Label();
        layoutMethod = new TableLayoutPanel();
        lblMethodCaption = new Label();
        lblRefundMethod = new Label();
        pnlMethodDivider = new Panel();
        flowReasonCaption = new FlowLayoutPanel();
        lblReason = new Label();
        lblRequired = new Label();
        pnlReasonField = new Panel();
        layoutReasonField = new TableLayoutPanel();
        cmbReason = new ComboBox();
        lblNote = new Label();
        pnlNoteField = new Panel();
        layoutNoteField = new TableLayoutPanel();
        txtNote = new TextBox();
        pnlFooter = new Panel();
        layoutFooter = new TableLayoutPanel();
        btnBack = new Button();
        btnSubmit = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        layoutHeading.SuspendLayout();
        pnlEligibility.SuspendLayout();
        layoutEligibility.SuspendLayout();
        layoutEligibilityMessage.SuspendLayout();
        layoutBody.SuspendLayout();
        pnlItems.SuspendLayout();
        layoutItems.SuspendLayout();
        pnlItemGrid.SuspendLayout();
        layoutItemGrid.SuspendLayout();
        layoutStatus1.SuspendLayout();
        layoutStatus2.SuspendLayout();
        pnlRequest.SuspendLayout();
        layoutRequest.SuspendLayout();
        layoutExpectedRefund.SuspendLayout();
        layoutMethod.SuspendLayout();
        flowReasonCaption.SuspendLayout();
        pnlReasonField.SuspendLayout();
        layoutReasonField.SuspendLayout();
        pnlNoteField.SuspendLayout();
        layoutNoteField.SuspendLayout();
        pnlFooter.SuspendLayout();
        layoutFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1030, 686);
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
        layoutPage.Controls.Add(pnlEligibility, 0, 1);
        layoutPage.Controls.Add(layoutBody, 0, 2);
        layoutPage.Controls.Add(pnlFooter, 0, 3);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(1030, 686);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16);
        layoutPage.RowCount = 5;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 385F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1136, 730);
        layoutPage.TabIndex = 0;
        // 
        // layoutHeading
        // 
        layoutHeading.ColumnCount = 1;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblOrderCode, 0, 1);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeading.Location = new Point(16, 16);
        layoutHeading.Margin = new Padding(0);
        layoutHeading.Name = "layoutHeading";
        layoutHeading.RowCount = 3;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeading.Size = new Size(1104, 90);
        layoutHeading.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1104, 46);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Yêu cầu hủy toàn đơn";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // lblOrderCode
        // 
        lblOrderCode.Dock = DockStyle.Fill;
        lblOrderCode.Font = new Font("Segoe UI", 10.5F);
        lblOrderCode.ForeColor = Color.FromArgb(100, 116, 139);
        lblOrderCode.Location = new Point(0, 46);
        lblOrderCode.Margin = new Padding(0);
        lblOrderCode.Name = "lblOrderCode";
        lblOrderCode.Size = new Size(1104, 26);
        lblOrderCode.TabIndex = 1;
        lblOrderCode.Text = "Hóa đơn #INV-20261118-042";
        lblOrderCode.TextAlign = ContentAlignment.MiddleLeft;
        lblOrderCode.UseMnemonic = false;
        // 
        // pnlEligibility
        // 
        pnlEligibility.BackColor = Color.FromArgb(187, 247, 208);
        pnlEligibility.Controls.Add(layoutEligibility);
        pnlEligibility.Dock = DockStyle.Fill;
        pnlEligibility.Location = new Point(16, 106);
        pnlEligibility.Margin = new Padding(0, 0, 0, 16);
        pnlEligibility.Name = "pnlEligibility";
        pnlEligibility.Padding = new Padding(1);
        pnlEligibility.Size = new Size(1104, 79);
        pnlEligibility.TabIndex = 1;
        // 
        // layoutEligibility
        // 
        layoutEligibility.BackColor = Color.FromArgb(220, 252, 231);
        layoutEligibility.ColumnCount = 3;
        layoutEligibility.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
        layoutEligibility.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
        layoutEligibility.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEligibility.Controls.Add(lblEligibleIcon, 0, 0);
        layoutEligibility.Controls.Add(pnlEligibilityDivider, 1, 0);
        layoutEligibility.Controls.Add(layoutEligibilityMessage, 2, 0);
        layoutEligibility.Dock = DockStyle.Fill;
        layoutEligibility.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEligibility.Location = new Point(1, 1);
        layoutEligibility.Margin = new Padding(0);
        layoutEligibility.Name = "layoutEligibility";
        layoutEligibility.Padding = new Padding(11, 9, 12, 9);
        layoutEligibility.RowCount = 1;
        layoutEligibility.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutEligibility.Size = new Size(1102, 77);
        layoutEligibility.TabIndex = 0;
        // 
        // lblEligibleIcon
        // 
        lblEligibleIcon.AccessibleRole = AccessibleRole.Graphic;
        lblEligibleIcon.Dock = DockStyle.Fill;
        lblEligibleIcon.Font = new Font("Segoe MDL2 Assets", 18F);
        lblEligibleIcon.ForeColor = Color.FromArgb(22, 101, 52);
        lblEligibleIcon.Location = new Point(11, 9);
        lblEligibleIcon.Margin = new Padding(0);
        lblEligibleIcon.Name = "lblEligibleIcon";
        lblEligibleIcon.Size = new Size(56, 59);
        lblEligibleIcon.TabIndex = 0;
        lblEligibleIcon.Text = "";
        lblEligibleIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblEligibleIcon.UseMnemonic = false;
        // 
        // pnlEligibilityDivider
        // 
        pnlEligibilityDivider.BackColor = Color.FromArgb(187, 247, 208);
        pnlEligibilityDivider.Dock = DockStyle.Fill;
        pnlEligibilityDivider.Location = new Point(67, 13);
        pnlEligibilityDivider.Margin = new Padding(0, 4, 0, 4);
        pnlEligibilityDivider.Name = "pnlEligibilityDivider";
        pnlEligibilityDivider.Size = new Size(1, 51);
        pnlEligibilityDivider.TabIndex = 1;
        // 
        // layoutEligibilityMessage
        // 
        layoutEligibilityMessage.ColumnCount = 1;
        layoutEligibilityMessage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEligibilityMessage.Controls.Add(lblEligibilityTitle, 0, 0);
        layoutEligibilityMessage.Controls.Add(lblEligibilityDetails, 0, 1);
        layoutEligibilityMessage.Dock = DockStyle.Fill;
        layoutEligibilityMessage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEligibilityMessage.Location = new Point(68, 9);
        layoutEligibilityMessage.Margin = new Padding(0);
        layoutEligibilityMessage.Name = "layoutEligibilityMessage";
        layoutEligibilityMessage.Padding = new Padding(14, 0, 0, 0);
        layoutEligibilityMessage.RowCount = 2;
        layoutEligibilityMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
        layoutEligibilityMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
        layoutEligibilityMessage.Size = new Size(1022, 59);
        layoutEligibilityMessage.TabIndex = 2;
        // 
        // lblEligibilityTitle
        // 
        lblEligibilityTitle.Dock = DockStyle.Fill;
        lblEligibilityTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblEligibilityTitle.ForeColor = Color.FromArgb(22, 101, 52);
        lblEligibilityTitle.Location = new Point(14, 0);
        lblEligibilityTitle.Margin = new Padding(0);
        lblEligibilityTitle.Name = "lblEligibilityTitle";
        lblEligibilityTitle.Size = new Size(1008, 30);
        lblEligibilityTitle.TabIndex = 0;
        lblEligibilityTitle.Text = "Đủ điều kiện gửi yêu cầu";
        lblEligibilityTitle.TextAlign = ContentAlignment.BottomLeft;
        lblEligibilityTitle.UseMnemonic = false;
        // 
        // lblEligibilityDetails
        // 
        lblEligibilityDetails.Dock = DockStyle.Fill;
        lblEligibilityDetails.Font = new Font("Segoe UI", 9.5F);
        lblEligibilityDetails.ForeColor = Color.FromArgb(51, 65, 85);
        lblEligibilityDetails.Location = new Point(14, 30);
        lblEligibilityDetails.Margin = new Padding(0);
        lblEligibilityDetails.Name = "lblEligibilityDetails";
        lblEligibilityDetails.Size = new Size(1008, 29);
        lblEligibilityDetails.TabIndex = 1;
        lblEligibilityDetails.Text = "Suất 20:30 · Vé chưa soát · Bắp nước chưa giao";
        lblEligibilityDetails.UseMnemonic = false;
        // 
        // layoutBody
        // 
        layoutBody.ColumnCount = 2;
        layoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        layoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        layoutBody.Controls.Add(pnlItems, 0, 0);
        layoutBody.Controls.Add(pnlRequest, 1, 0);
        layoutBody.Dock = DockStyle.Fill;
        layoutBody.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBody.Location = new Point(16, 201);
        layoutBody.Margin = new Padding(0);
        layoutBody.Name = "layoutBody";
        layoutBody.RowCount = 1;
        layoutBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBody.Size = new Size(1104, 385);
        layoutBody.TabIndex = 2;
        // 
        // pnlItems
        // 
        pnlItems.BackColor = Color.FromArgb(226, 232, 240);
        pnlItems.Controls.Add(layoutItems);
        pnlItems.Dock = DockStyle.Fill;
        pnlItems.Location = new Point(0, 0);
        pnlItems.Margin = new Padding(0, 0, 14, 0);
        pnlItems.Name = "pnlItems";
        pnlItems.Padding = new Padding(1);
        pnlItems.Size = new Size(593, 385);
        pnlItems.TabIndex = 0;
        // 
        // layoutItems
        // 
        layoutItems.BackColor = Color.White;
        layoutItems.ColumnCount = 1;
        layoutItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutItems.Controls.Add(lblItemsTitle, 0, 0);
        layoutItems.Controls.Add(lblShowtime, 0, 1);
        layoutItems.Controls.Add(pnlItemGrid, 0, 2);
        layoutItems.Dock = DockStyle.Fill;
        layoutItems.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutItems.Location = new Point(1, 1);
        layoutItems.Margin = new Padding(0);
        layoutItems.Name = "layoutItems";
        layoutItems.Padding = new Padding(12, 10, 12, 12);
        layoutItems.RowCount = 4;
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutItems.Size = new Size(591, 383);
        layoutItems.TabIndex = 0;
        // 
        // lblItemsTitle
        // 
        lblItemsTitle.Dock = DockStyle.Fill;
        lblItemsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblItemsTitle.Location = new Point(12, 10);
        lblItemsTitle.Margin = new Padding(0);
        lblItemsTitle.Name = "lblItemsTitle";
        lblItemsTitle.Size = new Size(567, 34);
        lblItemsTitle.TabIndex = 0;
        lblItemsTitle.Text = "Hạng mục sẽ hủy";
        lblItemsTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblItemsTitle.UseMnemonic = false;
        // 
        // lblShowtime
        // 
        lblShowtime.Dock = DockStyle.Fill;
        lblShowtime.Font = new Font("Segoe UI", 9.5F);
        lblShowtime.ForeColor = Color.FromArgb(100, 116, 139);
        lblShowtime.Location = new Point(12, 44);
        lblShowtime.Margin = new Padding(0);
        lblShowtime.Name = "lblShowtime";
        lblShowtime.Size = new Size(567, 32);
        lblShowtime.TabIndex = 1;
        lblShowtime.Text = "Lật Mặt 7 · Phòng 03 · 20:30";
        lblShowtime.UseMnemonic = false;
        // 
        // pnlItemGrid
        // 
        pnlItemGrid.BackColor = Color.FromArgb(226, 232, 240);
        pnlItemGrid.Controls.Add(layoutItemGrid);
        pnlItemGrid.Dock = DockStyle.Fill;
        pnlItemGrid.Location = new Point(12, 76);
        pnlItemGrid.Margin = new Padding(0);
        pnlItemGrid.Name = "pnlItemGrid";
        pnlItemGrid.Padding = new Padding(1);
        pnlItemGrid.Size = new Size(567, 136);
        pnlItemGrid.TabIndex = 2;
        // 
        // layoutItemGrid
        // 
        layoutItemGrid.BackColor = Color.FromArgb(226, 232, 240);
        layoutItemGrid.ColumnCount = 3;
        layoutItemGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
        layoutItemGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        layoutItemGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
        layoutItemGrid.Controls.Add(lblItemHeader, 0, 0);
        layoutItemGrid.Controls.Add(lblStatusHeader, 1, 0);
        layoutItemGrid.Controls.Add(lblAmountHeader, 2, 0);
        layoutItemGrid.Controls.Add(lblItem1, 0, 1);
        layoutItemGrid.Controls.Add(layoutStatus1, 1, 1);
        layoutItemGrid.Controls.Add(lblItemAmount1, 2, 1);
        layoutItemGrid.Controls.Add(lblItem2, 0, 2);
        layoutItemGrid.Controls.Add(layoutStatus2, 1, 2);
        layoutItemGrid.Controls.Add(lblItemAmount2, 2, 2);
        layoutItemGrid.Dock = DockStyle.Fill;
        layoutItemGrid.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutItemGrid.Location = new Point(1, 1);
        layoutItemGrid.Margin = new Padding(0);
        layoutItemGrid.Name = "layoutItemGrid";
        layoutItemGrid.RowCount = 3;
        layoutItemGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutItemGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        layoutItemGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        layoutItemGrid.Size = new Size(565, 134);
        layoutItemGrid.TabIndex = 0;
        // 
        // lblItemHeader
        // 
        lblItemHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblItemHeader.Dock = DockStyle.Fill;
        lblItemHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblItemHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblItemHeader.Location = new Point(0, 0);
        lblItemHeader.Margin = new Padding(0, 0, 0, 1);
        lblItemHeader.Name = "lblItemHeader";
        lblItemHeader.Padding = new Padding(8, 0, 0, 0);
        lblItemHeader.Size = new Size(248, 39);
        lblItemHeader.TabIndex = 0;
        lblItemHeader.Text = "Hạng mục";
        lblItemHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblItemHeader.UseMnemonic = false;
        // 
        // lblStatusHeader
        // 
        lblStatusHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblStatusHeader.Dock = DockStyle.Fill;
        lblStatusHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStatusHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblStatusHeader.Location = new Point(248, 0);
        lblStatusHeader.Margin = new Padding(0, 0, 0, 1);
        lblStatusHeader.Name = "lblStatusHeader";
        lblStatusHeader.Padding = new Padding(8, 0, 0, 0);
        lblStatusHeader.Size = new Size(169, 39);
        lblStatusHeader.TabIndex = 1;
        lblStatusHeader.Text = "Trạng thái";
        lblStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblStatusHeader.UseMnemonic = false;
        // 
        // lblAmountHeader
        // 
        lblAmountHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblAmountHeader.Dock = DockStyle.Fill;
        lblAmountHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblAmountHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblAmountHeader.Location = new Point(417, 0);
        lblAmountHeader.Margin = new Padding(0, 0, 0, 1);
        lblAmountHeader.Name = "lblAmountHeader";
        lblAmountHeader.Padding = new Padding(0, 0, 9, 0);
        lblAmountHeader.Size = new Size(148, 39);
        lblAmountHeader.TabIndex = 2;
        lblAmountHeader.Text = "Thành tiền";
        lblAmountHeader.TextAlign = ContentAlignment.MiddleRight;
        lblAmountHeader.UseMnemonic = false;
        // 
        // lblItem1
        // 
        lblItem1.BackColor = Color.White;
        lblItem1.Dock = DockStyle.Fill;
        lblItem1.Location = new Point(0, 40);
        lblItem1.Margin = new Padding(0, 0, 0, 1);
        lblItem1.Name = "lblItem1";
        lblItem1.Padding = new Padding(8, 0, 0, 0);
        lblItem1.Size = new Size(248, 46);
        lblItem1.TabIndex = 3;
        lblItem1.Text = "2 vé VIP · G05, G06";
        lblItem1.TextAlign = ContentAlignment.MiddleLeft;
        lblItem1.UseMnemonic = false;
        // 
        // layoutStatus1
        // 
        layoutStatus1.BackColor = Color.White;
        layoutStatus1.ColumnCount = 1;
        layoutStatus1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus1.Controls.Add(lblItemStatus1, 0, 0);
        layoutStatus1.Dock = DockStyle.Fill;
        layoutStatus1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus1.Location = new Point(248, 40);
        layoutStatus1.Margin = new Padding(0, 0, 0, 1);
        layoutStatus1.Name = "layoutStatus1";
        layoutStatus1.Padding = new Padding(8, 0, 0, 0);
        layoutStatus1.RowCount = 1;
        layoutStatus1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus1.Size = new Size(169, 46);
        layoutStatus1.TabIndex = 4;
        // 
        // lblItemStatus1
        // 
        lblItemStatus1.Anchor = AnchorStyles.Left;
        lblItemStatus1.BackColor = Color.FromArgb(241, 245, 249);
        lblItemStatus1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblItemStatus1.ForeColor = Color.FromArgb(51, 65, 85);
        lblItemStatus1.Location = new Point(8, 10);
        lblItemStatus1.Margin = new Padding(0);
        lblItemStatus1.Name = "lblItemStatus1";
        lblItemStatus1.Size = new Size(117, 25);
        lblItemStatus1.TabIndex = 0;
        lblItemStatus1.Text = "Chưa sử dụng";
        lblItemStatus1.TextAlign = ContentAlignment.MiddleCenter;
        lblItemStatus1.UseMnemonic = false;
        // 
        // lblItemAmount1
        // 
        lblItemAmount1.BackColor = Color.White;
        lblItemAmount1.Dock = DockStyle.Fill;
        lblItemAmount1.Location = new Point(417, 40);
        lblItemAmount1.Margin = new Padding(0, 0, 0, 1);
        lblItemAmount1.Name = "lblItemAmount1";
        lblItemAmount1.Padding = new Padding(0, 0, 9, 0);
        lblItemAmount1.Size = new Size(148, 46);
        lblItemAmount1.TabIndex = 5;
        lblItemAmount1.Text = "220.000 đ";
        lblItemAmount1.TextAlign = ContentAlignment.MiddleRight;
        lblItemAmount1.UseMnemonic = false;
        // 
        // lblItem2
        // 
        lblItem2.BackColor = Color.White;
        lblItem2.Dock = DockStyle.Fill;
        lblItem2.Location = new Point(0, 87);
        lblItem2.Margin = new Padding(0);
        lblItem2.Name = "lblItem2";
        lblItem2.Padding = new Padding(8, 0, 0, 0);
        lblItem2.Size = new Size(248, 47);
        lblItem2.TabIndex = 6;
        lblItem2.Text = "1 Combo đôi";
        lblItem2.TextAlign = ContentAlignment.MiddleLeft;
        lblItem2.UseMnemonic = false;
        // 
        // layoutStatus2
        // 
        layoutStatus2.BackColor = Color.White;
        layoutStatus2.ColumnCount = 1;
        layoutStatus2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus2.Controls.Add(lblItemStatus2, 0, 0);
        layoutStatus2.Dock = DockStyle.Fill;
        layoutStatus2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus2.Location = new Point(248, 87);
        layoutStatus2.Margin = new Padding(0);
        layoutStatus2.Name = "layoutStatus2";
        layoutStatus2.Padding = new Padding(8, 0, 0, 0);
        layoutStatus2.RowCount = 1;
        layoutStatus2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus2.Size = new Size(169, 47);
        layoutStatus2.TabIndex = 7;
        // 
        // lblItemStatus2
        // 
        lblItemStatus2.Anchor = AnchorStyles.Left;
        lblItemStatus2.BackColor = Color.FromArgb(241, 245, 249);
        lblItemStatus2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblItemStatus2.ForeColor = Color.FromArgb(51, 65, 85);
        lblItemStatus2.Location = new Point(8, 11);
        lblItemStatus2.Margin = new Padding(0);
        lblItemStatus2.Name = "lblItemStatus2";
        lblItemStatus2.Size = new Size(117, 25);
        lblItemStatus2.TabIndex = 0;
        lblItemStatus2.Text = "Chưa giao";
        lblItemStatus2.TextAlign = ContentAlignment.MiddleCenter;
        lblItemStatus2.UseMnemonic = false;
        // 
        // lblItemAmount2
        // 
        lblItemAmount2.BackColor = Color.White;
        lblItemAmount2.Dock = DockStyle.Fill;
        lblItemAmount2.Location = new Point(417, 87);
        lblItemAmount2.Margin = new Padding(0);
        lblItemAmount2.Name = "lblItemAmount2";
        lblItemAmount2.Padding = new Padding(0, 0, 9, 0);
        lblItemAmount2.Size = new Size(148, 47);
        lblItemAmount2.TabIndex = 8;
        lblItemAmount2.Text = "99.000 đ";
        lblItemAmount2.TextAlign = ContentAlignment.MiddleRight;
        lblItemAmount2.UseMnemonic = false;
        // 
        // pnlRequest
        // 
        pnlRequest.BackColor = Color.FromArgb(226, 232, 240);
        pnlRequest.Controls.Add(layoutRequest);
        pnlRequest.Dock = DockStyle.Fill;
        pnlRequest.Location = new Point(607, 0);
        pnlRequest.Margin = new Padding(0);
        pnlRequest.Name = "pnlRequest";
        pnlRequest.Padding = new Padding(1);
        pnlRequest.Size = new Size(497, 385);
        pnlRequest.TabIndex = 1;
        // 
        // layoutRequest
        // 
        layoutRequest.BackColor = Color.White;
        layoutRequest.ColumnCount = 1;
        layoutRequest.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRequest.Controls.Add(lblRequestTitle, 0, 0);
        layoutRequest.Controls.Add(layoutExpectedRefund, 0, 1);
        layoutRequest.Controls.Add(layoutMethod, 0, 2);
        layoutRequest.Controls.Add(pnlMethodDivider, 0, 3);
        layoutRequest.Controls.Add(flowReasonCaption, 0, 4);
        layoutRequest.Controls.Add(pnlReasonField, 0, 5);
        layoutRequest.Controls.Add(lblNote, 0, 6);
        layoutRequest.Controls.Add(pnlNoteField, 0, 7);
        layoutRequest.Dock = DockStyle.Fill;
        layoutRequest.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRequest.Location = new Point(1, 1);
        layoutRequest.Margin = new Padding(0);
        layoutRequest.Name = "layoutRequest";
        layoutRequest.Padding = new Padding(13, 10, 13, 12);
        layoutRequest.RowCount = 8;
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRequest.Size = new Size(495, 383);
        layoutRequest.TabIndex = 0;
        // 
        // lblRequestTitle
        // 
        lblRequestTitle.Dock = DockStyle.Fill;
        lblRequestTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblRequestTitle.Location = new Point(13, 10);
        lblRequestTitle.Margin = new Padding(0);
        lblRequestTitle.Name = "lblRequestTitle";
        lblRequestTitle.Size = new Size(469, 39);
        lblRequestTitle.TabIndex = 0;
        lblRequestTitle.Text = "Thông tin yêu cầu";
        lblRequestTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblRequestTitle.UseMnemonic = false;
        // 
        // layoutExpectedRefund
        // 
        layoutExpectedRefund.BackColor = Color.FromArgb(219, 234, 254);
        layoutExpectedRefund.ColumnCount = 2;
        layoutExpectedRefund.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutExpectedRefund.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutExpectedRefund.Controls.Add(lblExpectedRefundCaption, 0, 0);
        layoutExpectedRefund.Controls.Add(lblExpectedRefund, 1, 0);
        layoutExpectedRefund.Dock = DockStyle.Fill;
        layoutExpectedRefund.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutExpectedRefund.Location = new Point(13, 49);
        layoutExpectedRefund.Margin = new Padding(0);
        layoutExpectedRefund.Name = "layoutExpectedRefund";
        layoutExpectedRefund.Padding = new Padding(8, 0, 8, 0);
        layoutExpectedRefund.RowCount = 1;
        layoutExpectedRefund.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutExpectedRefund.Size = new Size(469, 43);
        layoutExpectedRefund.TabIndex = 1;
        // 
        // lblExpectedRefundCaption
        // 
        lblExpectedRefundCaption.Dock = DockStyle.Fill;
        lblExpectedRefundCaption.Location = new Point(8, 0);
        lblExpectedRefundCaption.Margin = new Padding(0);
        lblExpectedRefundCaption.Name = "lblExpectedRefundCaption";
        lblExpectedRefundCaption.Size = new Size(217, 43);
        lblExpectedRefundCaption.TabIndex = 0;
        lblExpectedRefundCaption.Text = "Dự kiến hoàn";
        lblExpectedRefundCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblExpectedRefundCaption.UseMnemonic = false;
        // 
        // lblExpectedRefund
        // 
        lblExpectedRefund.Dock = DockStyle.Fill;
        lblExpectedRefund.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblExpectedRefund.ForeColor = Color.FromArgb(37, 99, 235);
        lblExpectedRefund.Location = new Point(225, 0);
        lblExpectedRefund.Margin = new Padding(0);
        lblExpectedRefund.Name = "lblExpectedRefund";
        lblExpectedRefund.Size = new Size(236, 43);
        lblExpectedRefund.TabIndex = 1;
        lblExpectedRefund.Text = "319.000 đ";
        lblExpectedRefund.TextAlign = ContentAlignment.MiddleRight;
        lblExpectedRefund.UseMnemonic = false;
        // 
        // layoutMethod
        // 
        layoutMethod.ColumnCount = 2;
        layoutMethod.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        layoutMethod.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        layoutMethod.Controls.Add(lblMethodCaption, 0, 0);
        layoutMethod.Controls.Add(lblRefundMethod, 1, 0);
        layoutMethod.Dock = DockStyle.Fill;
        layoutMethod.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutMethod.Location = new Point(13, 92);
        layoutMethod.Margin = new Padding(0);
        layoutMethod.Name = "layoutMethod";
        layoutMethod.Padding = new Padding(8, 0, 8, 0);
        layoutMethod.RowCount = 1;
        layoutMethod.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMethod.Size = new Size(469, 39);
        layoutMethod.TabIndex = 2;
        // 
        // lblMethodCaption
        // 
        lblMethodCaption.Dock = DockStyle.Fill;
        lblMethodCaption.Location = new Point(8, 0);
        lblMethodCaption.Margin = new Padding(0);
        lblMethodCaption.Name = "lblMethodCaption";
        lblMethodCaption.Size = new Size(249, 39);
        lblMethodCaption.TabIndex = 0;
        lblMethodCaption.Text = "Phương thức hoàn";
        lblMethodCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblMethodCaption.UseMnemonic = false;
        // 
        // lblRefundMethod
        // 
        lblRefundMethod.Dock = DockStyle.Fill;
        lblRefundMethod.Location = new Point(257, 0);
        lblRefundMethod.Margin = new Padding(0);
        lblRefundMethod.Name = "lblRefundMethod";
        lblRefundMethod.Size = new Size(204, 39);
        lblRefundMethod.TabIndex = 1;
        lblRefundMethod.Text = "Tiền mặt";
        lblRefundMethod.TextAlign = ContentAlignment.MiddleRight;
        lblRefundMethod.UseMnemonic = false;
        // 
        // pnlMethodDivider
        // 
        pnlMethodDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlMethodDivider.Dock = DockStyle.Fill;
        pnlMethodDivider.Location = new Point(13, 131);
        pnlMethodDivider.Margin = new Padding(0);
        pnlMethodDivider.Name = "pnlMethodDivider";
        pnlMethodDivider.Size = new Size(469, 1);
        pnlMethodDivider.TabIndex = 3;
        // 
        // flowReasonCaption
        // 
        flowReasonCaption.Controls.Add(lblReason);
        flowReasonCaption.Controls.Add(lblRequired);
        flowReasonCaption.Dock = DockStyle.Fill;
        flowReasonCaption.Location = new Point(13, 132);
        flowReasonCaption.Margin = new Padding(0);
        flowReasonCaption.Name = "flowReasonCaption";
        flowReasonCaption.Padding = new Padding(0, 5, 0, 0);
        flowReasonCaption.Size = new Size(469, 31);
        flowReasonCaption.TabIndex = 4;
        flowReasonCaption.WrapContents = false;
        // 
        // lblReason
        // 
        lblReason.AutoSize = true;
        lblReason.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblReason.Location = new Point(0, 5);
        lblReason.Margin = new Padding(0);
        lblReason.Name = "lblReason";
        lblReason.Size = new Size(84, 21);
        lblReason.TabIndex = 0;
        lblReason.Text = "Lý do hủy";
        lblReason.TextAlign = ContentAlignment.MiddleLeft;
        lblReason.UseMnemonic = false;
        // 
        // lblRequired
        // 
        lblRequired.AutoSize = true;
        lblRequired.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblRequired.ForeColor = Color.FromArgb(185, 28, 28);
        lblRequired.Location = new Point(87, 5);
        lblRequired.Margin = new Padding(3, 0, 0, 0);
        lblRequired.Name = "lblRequired";
        lblRequired.Size = new Size(17, 21);
        lblRequired.TabIndex = 1;
        lblRequired.Text = "*";
        lblRequired.TextAlign = ContentAlignment.MiddleLeft;
        lblRequired.UseMnemonic = false;
        // 
        // pnlReasonField
        // 
        pnlReasonField.BackColor = Color.FromArgb(226, 232, 240);
        pnlReasonField.Controls.Add(layoutReasonField);
        pnlReasonField.Dock = DockStyle.Fill;
        pnlReasonField.Location = new Point(13, 163);
        pnlReasonField.Margin = new Padding(0);
        pnlReasonField.Name = "pnlReasonField";
        pnlReasonField.Padding = new Padding(1);
        pnlReasonField.Size = new Size(469, 41);
        pnlReasonField.TabIndex = 5;
        // 
        // layoutReasonField
        // 
        layoutReasonField.BackColor = Color.White;
        layoutReasonField.ColumnCount = 1;
        layoutReasonField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutReasonField.Controls.Add(cmbReason, 0, 0);
        layoutReasonField.Dock = DockStyle.Fill;
        layoutReasonField.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutReasonField.Location = new Point(1, 1);
        layoutReasonField.Margin = new Padding(0);
        layoutReasonField.Name = "layoutReasonField";
        layoutReasonField.Padding = new Padding(7, 0, 5, 0);
        layoutReasonField.RowCount = 1;
        layoutReasonField.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutReasonField.Size = new Size(467, 39);
        layoutReasonField.TabIndex = 0;
        // 
        // cmbReason
        // 
        cmbReason.AccessibleName = "Lý do hủy, bắt buộc";
        cmbReason.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cmbReason.BackColor = Color.White;
        cmbReason.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbReason.FlatStyle = FlatStyle.Flat;
        cmbReason.FormattingEnabled = true;
        cmbReason.Items.AddRange(new object[] { "Bán nhầm suất", "Chọn nhầm ghế", "Khách yêu cầu hủy", "Khác" });
        cmbReason.Location = new Point(7, 5);
        cmbReason.Margin = new Padding(0);
        cmbReason.Name = "cmbReason";
        cmbReason.Size = new Size(455, 29);
        cmbReason.TabIndex = 0;
        // 
        // lblNote
        // 
        lblNote.Dock = DockStyle.Fill;
        lblNote.Font = new Font("Segoe UI", 9.5F);
        lblNote.Location = new Point(13, 204);
        lblNote.Margin = new Padding(0);
        lblNote.Name = "lblNote";
        lblNote.Padding = new Padding(0, 0, 0, 4);
        lblNote.Size = new Size(469, 35);
        lblNote.TabIndex = 6;
        lblNote.Text = "Ghi chú (tùy chọn)";
        lblNote.TextAlign = ContentAlignment.BottomLeft;
        lblNote.UseMnemonic = false;
        // 
        // pnlNoteField
        // 
        pnlNoteField.BackColor = Color.FromArgb(226, 232, 240);
        pnlNoteField.Controls.Add(layoutNoteField);
        pnlNoteField.Dock = DockStyle.Fill;
        pnlNoteField.Location = new Point(13, 239);
        pnlNoteField.Margin = new Padding(0);
        pnlNoteField.Name = "pnlNoteField";
        pnlNoteField.Padding = new Padding(1);
        pnlNoteField.Size = new Size(469, 132);
        pnlNoteField.TabIndex = 7;
        // 
        // layoutNoteField
        // 
        layoutNoteField.BackColor = Color.White;
        layoutNoteField.ColumnCount = 1;
        layoutNoteField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutNoteField.Controls.Add(txtNote, 0, 0);
        layoutNoteField.Dock = DockStyle.Fill;
        layoutNoteField.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutNoteField.Location = new Point(1, 1);
        layoutNoteField.Margin = new Padding(0);
        layoutNoteField.Name = "layoutNoteField";
        layoutNoteField.Padding = new Padding(8, 7, 8, 7);
        layoutNoteField.RowCount = 1;
        layoutNoteField.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutNoteField.Size = new Size(467, 130);
        layoutNoteField.TabIndex = 0;
        // 
        // txtNote
        // 
        txtNote.AccessibleName = "Ghi chú, tùy chọn";
        txtNote.BackColor = Color.White;
        txtNote.BorderStyle = BorderStyle.None;
        txtNote.Dock = DockStyle.Fill;
        txtNote.Location = new Point(8, 7);
        txtNote.Margin = new Padding(0);
        txtNote.Multiline = true;
        txtNote.Name = "txtNote";
        txtNote.PlaceholderText = "Nhập ghi chú";
        txtNote.Size = new Size(451, 116);
        txtNote.TabIndex = 0;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.FromArgb(226, 232, 240);
        pnlFooter.Controls.Add(layoutFooter);
        pnlFooter.Dock = DockStyle.Fill;
        pnlFooter.Location = new Point(16, 602);
        pnlFooter.Margin = new Padding(0, 16, 0, 0);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(1);
        pnlFooter.Size = new Size(1104, 66);
        pnlFooter.TabIndex = 3;
        // 
        // layoutFooter
        // 
        layoutFooter.BackColor = Color.White;
        layoutFooter.ColumnCount = 3;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 204F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 224F));
        layoutFooter.Controls.Add(btnBack, 0, 0);
        layoutFooter.Controls.Add(btnSubmit, 2, 0);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Location = new Point(1, 1);
        layoutFooter.Margin = new Padding(0);
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Padding = new Padding(10, 9, 10, 9);
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFooter.Size = new Size(1102, 64);
        layoutFooter.TabIndex = 0;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.White;
        btnBack.Dock = DockStyle.Fill;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Font = new Font("Segoe UI", 10F);
        btnBack.ForeColor = Color.FromArgb(15, 23, 42);
        btnBack.Location = new Point(10, 9);
        btnBack.Margin = new Padding(0);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(204, 46);
        btnBack.TabIndex = 0;
        btnBack.Text = "‹  Quay lại hóa đơn";
        btnBack.UseMnemonic = false;
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += BtnBack_Click;
        // 
        // btnSubmit
        // 
        btnSubmit.BackColor = Color.FromArgb(37, 99, 235);
        btnSubmit.Dock = DockStyle.Fill;
        btnSubmit.FlatAppearance.BorderSize = 0;
        btnSubmit.FlatStyle = FlatStyle.Flat;
        btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSubmit.ForeColor = Color.White;
        btnSubmit.Location = new Point(868, 9);
        btnSubmit.Margin = new Padding(0);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(224, 46);
        btnSubmit.TabIndex = 1;
        btnSubmit.Text = "Gửi yêu cầu hủy";
        btnSubmit.UseMnemonic = false;
        btnSubmit.UseVisualStyleBackColor = false;
        // 
        // RefundRequestView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "RefundRequestView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        layoutHeading.ResumeLayout(false);
        pnlEligibility.ResumeLayout(false);
        layoutEligibility.ResumeLayout(false);
        layoutEligibilityMessage.ResumeLayout(false);
        layoutBody.ResumeLayout(false);
        pnlItems.ResumeLayout(false);
        layoutItems.ResumeLayout(false);
        pnlItemGrid.ResumeLayout(false);
        layoutItemGrid.ResumeLayout(false);
        layoutStatus1.ResumeLayout(false);
        layoutStatus2.ResumeLayout(false);
        pnlRequest.ResumeLayout(false);
        layoutRequest.ResumeLayout(false);
        layoutExpectedRefund.ResumeLayout(false);
        layoutMethod.ResumeLayout(false);
        flowReasonCaption.ResumeLayout(false);
        flowReasonCaption.PerformLayout();
        pnlReasonField.ResumeLayout(false);
        layoutReasonField.ResumeLayout(false);
        pnlNoteField.ResumeLayout(false);
        layoutNoteField.ResumeLayout(false);
        layoutNoteField.PerformLayout();
        pnlFooter.ResumeLayout(false);
        layoutFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private TableLayoutPanel layoutHeading;
    private Label lblTitle;
    private Label lblOrderCode;
    private Panel pnlEligibility;
    private TableLayoutPanel layoutEligibility;
    private Label lblEligibleIcon;
    private Panel pnlEligibilityDivider;
    private TableLayoutPanel layoutEligibilityMessage;
    private Label lblEligibilityTitle;
    private Label lblEligibilityDetails;
    private TableLayoutPanel layoutBody;
    private Panel pnlItems;
    private TableLayoutPanel layoutItems;
    private Label lblItemsTitle;
    private Label lblShowtime;
    private Panel pnlItemGrid;
    private TableLayoutPanel layoutItemGrid;
    private Label lblItemHeader;
    private Label lblStatusHeader;
    private Label lblAmountHeader;
    private Label lblItem1;
    private TableLayoutPanel layoutStatus1;
    private Label lblItemStatus1;
    private Label lblItemAmount1;
    private Label lblItem2;
    private TableLayoutPanel layoutStatus2;
    private Label lblItemStatus2;
    private Label lblItemAmount2;
    private Panel pnlRequest;
    private TableLayoutPanel layoutRequest;
    private Label lblRequestTitle;
    private TableLayoutPanel layoutExpectedRefund;
    private Label lblExpectedRefundCaption;
    private Label lblExpectedRefund;
    private TableLayoutPanel layoutMethod;
    private Label lblMethodCaption;
    private Label lblRefundMethod;
    private Panel pnlMethodDivider;
    private FlowLayoutPanel flowReasonCaption;
    private Label lblReason;
    private Label lblRequired;
    private Panel pnlReasonField;
    private TableLayoutPanel layoutReasonField;
    private ComboBox cmbReason;
    private Label lblNote;
    private Panel pnlNoteField;
    private TableLayoutPanel layoutNoteField;
    private TextBox txtNote;
    private Panel pnlFooter;
    private TableLayoutPanel layoutFooter;
    private Button btnBack;
    private Button btnSubmit;
}

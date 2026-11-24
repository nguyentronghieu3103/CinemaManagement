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
        pnlViewport.Margin = new Padding(0);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1030, 686);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Controls.Add(layoutPage);
        //
        // layoutPage
        //
        layoutPage.Margin = new Padding(0);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.Padding = new Padding(16, 16, 16, 16);
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.RowCount = 5;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 385F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.MinimumSize = new Size(1030, 686);
        layoutPage.Name = "layoutPage";
        layoutPage.Controls.Add(layoutHeading, 0, 0);
        layoutPage.Controls.Add(pnlEligibility, 0, 1);
        layoutPage.Controls.Add(layoutBody, 0, 2);
        layoutPage.Controls.Add(pnlFooter, 0, 3);
        //
        // layoutHeading
        //
        layoutHeading.Margin = new Padding(0);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.ColumnCount = 1;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.RowCount = 3;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeading.Name = "layoutHeading";
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblOrderCode, 0, 1);
        //
        // lblTitle
        //
        lblTitle.Margin = new Padding(0);
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.Text = "Yêu cầu hủy toàn đơn";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        lblTitle.Name = "lblTitle";
        //
        // lblOrderCode
        //
        lblOrderCode.Margin = new Padding(0);
        lblOrderCode.Dock = DockStyle.Fill;
        lblOrderCode.ForeColor = Color.FromArgb(100, 116, 139);
        lblOrderCode.Font = new Font("Segoe UI", 10.5F);
        lblOrderCode.Text = "Hóa đơn #INV-20261118-042";
        lblOrderCode.TextAlign = ContentAlignment.MiddleLeft;
        lblOrderCode.UseMnemonic = false;
        lblOrderCode.Name = "lblOrderCode";
        //
        // pnlEligibility
        //
        pnlEligibility.Margin = new Padding(0, 0, 0, 16);
        pnlEligibility.Dock = DockStyle.Fill;
        pnlEligibility.Padding = new Padding(1);
        pnlEligibility.BackColor = Color.FromArgb(187, 247, 208);
        pnlEligibility.Name = "pnlEligibility";
        pnlEligibility.Controls.Add(layoutEligibility);
        //
        // layoutEligibility
        //
        layoutEligibility.Margin = new Padding(0);
        layoutEligibility.Dock = DockStyle.Fill;
        layoutEligibility.Padding = new Padding(11, 9, 12, 9);
        layoutEligibility.BackColor = Color.FromArgb(220, 252, 231);
        layoutEligibility.ColumnCount = 3;
        layoutEligibility.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
        layoutEligibility.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
        layoutEligibility.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEligibility.RowCount = 1;
        layoutEligibility.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutEligibility.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEligibility.Name = "layoutEligibility";
        layoutEligibility.Controls.Add(lblEligibleIcon, 0, 0);
        layoutEligibility.Controls.Add(pnlEligibilityDivider, 1, 0);
        layoutEligibility.Controls.Add(layoutEligibilityMessage, 2, 0);
        //
        // lblEligibleIcon
        //
        lblEligibleIcon.Margin = new Padding(0);
        lblEligibleIcon.Dock = DockStyle.Fill;
        lblEligibleIcon.ForeColor = Color.FromArgb(22, 101, 52);
        lblEligibleIcon.Text = "";
        lblEligibleIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblEligibleIcon.UseMnemonic = false;
        lblEligibleIcon.Font = new Font("Segoe MDL2 Assets", 18F);
        lblEligibleIcon.AccessibleRole = AccessibleRole.Graphic;
        lblEligibleIcon.Name = "lblEligibleIcon";
        //
        // pnlEligibilityDivider
        //
        pnlEligibilityDivider.Margin = new Padding(0, 4, 0, 4);
        pnlEligibilityDivider.Dock = DockStyle.Fill;
        pnlEligibilityDivider.BackColor = Color.FromArgb(187, 247, 208);
        pnlEligibilityDivider.Name = "pnlEligibilityDivider";
        //
        // layoutEligibilityMessage
        //
        layoutEligibilityMessage.Margin = new Padding(0);
        layoutEligibilityMessage.Dock = DockStyle.Fill;
        layoutEligibilityMessage.Padding = new Padding(14, 0, 0, 0);
        layoutEligibilityMessage.ColumnCount = 1;
        layoutEligibilityMessage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEligibilityMessage.RowCount = 2;
        layoutEligibilityMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
        layoutEligibilityMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
        layoutEligibilityMessage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEligibilityMessage.Name = "layoutEligibilityMessage";
        layoutEligibilityMessage.Controls.Add(lblEligibilityTitle, 0, 0);
        layoutEligibilityMessage.Controls.Add(lblEligibilityDetails, 0, 1);
        //
        // lblEligibilityTitle
        //
        lblEligibilityTitle.Margin = new Padding(0);
        lblEligibilityTitle.Dock = DockStyle.Fill;
        lblEligibilityTitle.ForeColor = Color.FromArgb(22, 101, 52);
        lblEligibilityTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblEligibilityTitle.Text = "Đủ điều kiện gửi yêu cầu";
        lblEligibilityTitle.TextAlign = ContentAlignment.BottomLeft;
        lblEligibilityTitle.UseMnemonic = false;
        lblEligibilityTitle.Name = "lblEligibilityTitle";
        //
        // lblEligibilityDetails
        //
        lblEligibilityDetails.Margin = new Padding(0);
        lblEligibilityDetails.Dock = DockStyle.Fill;
        lblEligibilityDetails.ForeColor = Color.FromArgb(51, 65, 85);
        lblEligibilityDetails.Font = new Font("Segoe UI", 9.5F);
        lblEligibilityDetails.Text = "Suất 20:30 · Vé chưa soát · Bắp nước chưa giao";
        lblEligibilityDetails.TextAlign = ContentAlignment.TopLeft;
        lblEligibilityDetails.UseMnemonic = false;
        lblEligibilityDetails.Name = "lblEligibilityDetails";
        //
        // layoutBody
        //
        layoutBody.Margin = new Padding(0);
        layoutBody.Dock = DockStyle.Fill;
        layoutBody.ColumnCount = 2;
        layoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        layoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        layoutBody.RowCount = 1;
        layoutBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBody.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBody.Name = "layoutBody";
        layoutBody.Controls.Add(pnlItems, 0, 0);
        layoutBody.Controls.Add(pnlRequest, 1, 0);
        //
        // pnlItems
        //
        pnlItems.Margin = new Padding(0, 0, 14, 0);
        pnlItems.Dock = DockStyle.Fill;
        pnlItems.Padding = new Padding(1);
        pnlItems.BackColor = Color.FromArgb(226, 232, 240);
        pnlItems.Name = "pnlItems";
        pnlItems.Controls.Add(layoutItems);
        //
        // layoutItems
        //
        layoutItems.Margin = new Padding(0);
        layoutItems.Dock = DockStyle.Fill;
        layoutItems.Padding = new Padding(12, 10, 12, 12);
        layoutItems.BackColor = Color.White;
        layoutItems.ColumnCount = 1;
        layoutItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutItems.RowCount = 4;
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutItems.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutItems.Name = "layoutItems";
        layoutItems.Controls.Add(lblItemsTitle, 0, 0);
        layoutItems.Controls.Add(lblShowtime, 0, 1);
        layoutItems.Controls.Add(pnlItemGrid, 0, 2);
        //
        // lblItemsTitle
        //
        lblItemsTitle.Margin = new Padding(0);
        lblItemsTitle.Dock = DockStyle.Fill;
        lblItemsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblItemsTitle.Text = "Hạng mục sẽ hủy";
        lblItemsTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblItemsTitle.UseMnemonic = false;
        lblItemsTitle.Name = "lblItemsTitle";
        //
        // lblShowtime
        //
        lblShowtime.Margin = new Padding(0);
        lblShowtime.Dock = DockStyle.Fill;
        lblShowtime.ForeColor = Color.FromArgb(100, 116, 139);
        lblShowtime.Font = new Font("Segoe UI", 9.5F);
        lblShowtime.Text = "Lật Mặt 7 · Phòng 03 · 20:30";
        lblShowtime.TextAlign = ContentAlignment.TopLeft;
        lblShowtime.UseMnemonic = false;
        lblShowtime.Name = "lblShowtime";
        //
        // pnlItemGrid
        //
        pnlItemGrid.Margin = new Padding(0);
        pnlItemGrid.Dock = DockStyle.Fill;
        pnlItemGrid.Padding = new Padding(1);
        pnlItemGrid.BackColor = Color.FromArgb(226, 232, 240);
        pnlItemGrid.Name = "pnlItemGrid";
        pnlItemGrid.Controls.Add(layoutItemGrid);
        //
        // layoutItemGrid
        //
        layoutItemGrid.Margin = new Padding(0);
        layoutItemGrid.Dock = DockStyle.Fill;
        layoutItemGrid.Padding = new Padding(0);
        layoutItemGrid.BackColor = Color.FromArgb(226, 232, 240);
        layoutItemGrid.ColumnCount = 3;
        layoutItemGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
        layoutItemGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        layoutItemGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
        layoutItemGrid.RowCount = 3;
        layoutItemGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutItemGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        layoutItemGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        layoutItemGrid.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutItemGrid.Name = "layoutItemGrid";
        layoutItemGrid.Controls.Add(lblItemHeader, 0, 0);
        layoutItemGrid.Controls.Add(lblStatusHeader, 1, 0);
        layoutItemGrid.Controls.Add(lblAmountHeader, 2, 0);
        layoutItemGrid.Controls.Add(lblItem1, 0, 1);
        layoutItemGrid.Controls.Add(layoutStatus1, 1, 1);
        layoutItemGrid.Controls.Add(lblItemAmount1, 2, 1);
        layoutItemGrid.Controls.Add(lblItem2, 0, 2);
        layoutItemGrid.Controls.Add(layoutStatus2, 1, 2);
        layoutItemGrid.Controls.Add(lblItemAmount2, 2, 2);
        //
        // lblItemHeader
        //
        lblItemHeader.Margin = new Padding(0, 0, 0, 1);
        lblItemHeader.Dock = DockStyle.Fill;
        lblItemHeader.Padding = new Padding(8, 0, 0, 0);
        lblItemHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblItemHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblItemHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblItemHeader.Text = "Hạng mục";
        lblItemHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblItemHeader.UseMnemonic = false;
        lblItemHeader.Name = "lblItemHeader";
        //
        // lblStatusHeader
        //
        lblStatusHeader.Margin = new Padding(0, 0, 0, 1);
        lblStatusHeader.Dock = DockStyle.Fill;
        lblStatusHeader.Padding = new Padding(8, 0, 0, 0);
        lblStatusHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblStatusHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblStatusHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStatusHeader.Text = "Trạng thái";
        lblStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblStatusHeader.UseMnemonic = false;
        lblStatusHeader.Name = "lblStatusHeader";
        //
        // lblAmountHeader
        //
        lblAmountHeader.Margin = new Padding(0, 0, 0, 1);
        lblAmountHeader.Dock = DockStyle.Fill;
        lblAmountHeader.Padding = new Padding(0, 0, 9, 0);
        lblAmountHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblAmountHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblAmountHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblAmountHeader.Text = "Thành tiền";
        lblAmountHeader.TextAlign = ContentAlignment.MiddleRight;
        lblAmountHeader.UseMnemonic = false;
        lblAmountHeader.Name = "lblAmountHeader";
        //
        // lblItem1
        //
        lblItem1.Margin = new Padding(0, 0, 0, 1);
        lblItem1.Dock = DockStyle.Fill;
        lblItem1.Padding = new Padding(8, 0, 0, 0);
        lblItem1.BackColor = Color.White;
        lblItem1.Text = "2 vé VIP · G05, G06";
        lblItem1.TextAlign = ContentAlignment.MiddleLeft;
        lblItem1.UseMnemonic = false;
        lblItem1.Name = "lblItem1";
        //
        // layoutStatus1
        //
        layoutStatus1.Margin = new Padding(0, 0, 0, 1);
        layoutStatus1.Dock = DockStyle.Fill;
        layoutStatus1.Padding = new Padding(8, 0, 0, 0);
        layoutStatus1.BackColor = Color.White;
        layoutStatus1.ColumnCount = 1;
        layoutStatus1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus1.RowCount = 1;
        layoutStatus1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus1.Name = "layoutStatus1";
        layoutStatus1.Controls.Add(lblItemStatus1, 0, 0);
        //
        // lblItemStatus1
        //
        lblItemStatus1.Margin = new Padding(0);
        lblItemStatus1.BackColor = Color.FromArgb(241, 245, 249);
        lblItemStatus1.ForeColor = Color.FromArgb(51, 65, 85);
        lblItemStatus1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblItemStatus1.Text = "Chưa sử dụng";
        lblItemStatus1.TextAlign = ContentAlignment.MiddleCenter;
        lblItemStatus1.UseMnemonic = false;
        lblItemStatus1.Anchor = AnchorStyles.Left;
        lblItemStatus1.Size = new Size(117, 25);
        lblItemStatus1.Name = "lblItemStatus1";
        //
        // lblItemAmount1
        //
        lblItemAmount1.Margin = new Padding(0, 0, 0, 1);
        lblItemAmount1.Dock = DockStyle.Fill;
        lblItemAmount1.Padding = new Padding(0, 0, 9, 0);
        lblItemAmount1.BackColor = Color.White;
        lblItemAmount1.Text = "220.000 đ";
        lblItemAmount1.TextAlign = ContentAlignment.MiddleRight;
        lblItemAmount1.UseMnemonic = false;
        lblItemAmount1.Name = "lblItemAmount1";
        //
        // lblItem2
        //
        lblItem2.Margin = new Padding(0, 0, 0, 0);
        lblItem2.Dock = DockStyle.Fill;
        lblItem2.Padding = new Padding(8, 0, 0, 0);
        lblItem2.BackColor = Color.White;
        lblItem2.Text = "1 Combo đôi";
        lblItem2.TextAlign = ContentAlignment.MiddleLeft;
        lblItem2.UseMnemonic = false;
        lblItem2.Name = "lblItem2";
        //
        // layoutStatus2
        //
        layoutStatus2.Margin = new Padding(0, 0, 0, 0);
        layoutStatus2.Dock = DockStyle.Fill;
        layoutStatus2.Padding = new Padding(8, 0, 0, 0);
        layoutStatus2.BackColor = Color.White;
        layoutStatus2.ColumnCount = 1;
        layoutStatus2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutStatus2.RowCount = 1;
        layoutStatus2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStatus2.Name = "layoutStatus2";
        layoutStatus2.Controls.Add(lblItemStatus2, 0, 0);
        //
        // lblItemStatus2
        //
        lblItemStatus2.Margin = new Padding(0);
        lblItemStatus2.BackColor = Color.FromArgb(241, 245, 249);
        lblItemStatus2.ForeColor = Color.FromArgb(51, 65, 85);
        lblItemStatus2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblItemStatus2.Text = "Chưa giao";
        lblItemStatus2.TextAlign = ContentAlignment.MiddleCenter;
        lblItemStatus2.UseMnemonic = false;
        lblItemStatus2.Anchor = AnchorStyles.Left;
        lblItemStatus2.Size = new Size(117, 25);
        lblItemStatus2.Name = "lblItemStatus2";
        //
        // lblItemAmount2
        //
        lblItemAmount2.Margin = new Padding(0, 0, 0, 0);
        lblItemAmount2.Dock = DockStyle.Fill;
        lblItemAmount2.Padding = new Padding(0, 0, 9, 0);
        lblItemAmount2.BackColor = Color.White;
        lblItemAmount2.Text = "99.000 đ";
        lblItemAmount2.TextAlign = ContentAlignment.MiddleRight;
        lblItemAmount2.UseMnemonic = false;
        lblItemAmount2.Name = "lblItemAmount2";
        //
        // pnlRequest
        //
        pnlRequest.Margin = new Padding(0);
        pnlRequest.Dock = DockStyle.Fill;
        pnlRequest.Padding = new Padding(1);
        pnlRequest.BackColor = Color.FromArgb(226, 232, 240);
        pnlRequest.Name = "pnlRequest";
        pnlRequest.Controls.Add(layoutRequest);
        //
        // layoutRequest
        //
        layoutRequest.Margin = new Padding(0);
        layoutRequest.Dock = DockStyle.Fill;
        layoutRequest.Padding = new Padding(13, 10, 13, 12);
        layoutRequest.BackColor = Color.White;
        layoutRequest.ColumnCount = 1;
        layoutRequest.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRequest.RowCount = 8;
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layoutRequest.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRequest.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRequest.Name = "layoutRequest";
        layoutRequest.Controls.Add(lblRequestTitle, 0, 0);
        layoutRequest.Controls.Add(layoutExpectedRefund, 0, 1);
        layoutRequest.Controls.Add(layoutMethod, 0, 2);
        layoutRequest.Controls.Add(pnlMethodDivider, 0, 3);
        layoutRequest.Controls.Add(flowReasonCaption, 0, 4);
        layoutRequest.Controls.Add(pnlReasonField, 0, 5);
        layoutRequest.Controls.Add(lblNote, 0, 6);
        layoutRequest.Controls.Add(pnlNoteField, 0, 7);
        //
        // lblRequestTitle
        //
        lblRequestTitle.Margin = new Padding(0);
        lblRequestTitle.Dock = DockStyle.Fill;
        lblRequestTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblRequestTitle.Text = "Thông tin yêu cầu";
        lblRequestTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblRequestTitle.UseMnemonic = false;
        lblRequestTitle.Name = "lblRequestTitle";
        //
        // layoutExpectedRefund
        //
        layoutExpectedRefund.Margin = new Padding(0);
        layoutExpectedRefund.Dock = DockStyle.Fill;
        layoutExpectedRefund.Padding = new Padding(8, 0, 8, 0);
        layoutExpectedRefund.BackColor = Color.FromArgb(219, 234, 254);
        layoutExpectedRefund.ColumnCount = 2;
        layoutExpectedRefund.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutExpectedRefund.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutExpectedRefund.RowCount = 1;
        layoutExpectedRefund.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutExpectedRefund.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutExpectedRefund.Name = "layoutExpectedRefund";
        layoutExpectedRefund.Controls.Add(lblExpectedRefundCaption, 0, 0);
        layoutExpectedRefund.Controls.Add(lblExpectedRefund, 1, 0);
        //
        // lblExpectedRefundCaption
        //
        lblExpectedRefundCaption.Margin = new Padding(0);
        lblExpectedRefundCaption.Dock = DockStyle.Fill;
        lblExpectedRefundCaption.Text = "Dự kiến hoàn";
        lblExpectedRefundCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblExpectedRefundCaption.UseMnemonic = false;
        lblExpectedRefundCaption.Name = "lblExpectedRefundCaption";
        //
        // lblExpectedRefund
        //
        lblExpectedRefund.Margin = new Padding(0);
        lblExpectedRefund.Dock = DockStyle.Fill;
        lblExpectedRefund.ForeColor = Color.FromArgb(37, 99, 235);
        lblExpectedRefund.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblExpectedRefund.Text = "319.000 đ";
        lblExpectedRefund.TextAlign = ContentAlignment.MiddleRight;
        lblExpectedRefund.UseMnemonic = false;
        lblExpectedRefund.Name = "lblExpectedRefund";
        //
        // layoutMethod
        //
        layoutMethod.Margin = new Padding(0);
        layoutMethod.Dock = DockStyle.Fill;
        layoutMethod.Padding = new Padding(8, 0, 8, 0);
        layoutMethod.ColumnCount = 2;
        layoutMethod.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        layoutMethod.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        layoutMethod.RowCount = 1;
        layoutMethod.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMethod.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutMethod.Name = "layoutMethod";
        layoutMethod.Controls.Add(lblMethodCaption, 0, 0);
        layoutMethod.Controls.Add(lblRefundMethod, 1, 0);
        //
        // lblMethodCaption
        //
        lblMethodCaption.Margin = new Padding(0);
        lblMethodCaption.Dock = DockStyle.Fill;
        lblMethodCaption.Text = "Phương thức hoàn";
        lblMethodCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblMethodCaption.UseMnemonic = false;
        lblMethodCaption.Name = "lblMethodCaption";
        //
        // lblRefundMethod
        //
        lblRefundMethod.Margin = new Padding(0);
        lblRefundMethod.Dock = DockStyle.Fill;
        lblRefundMethod.Text = "Tiền mặt";
        lblRefundMethod.TextAlign = ContentAlignment.MiddleRight;
        lblRefundMethod.UseMnemonic = false;
        lblRefundMethod.Name = "lblRefundMethod";
        //
        // pnlMethodDivider
        //
        pnlMethodDivider.Margin = new Padding(0);
        pnlMethodDivider.Dock = DockStyle.Fill;
        pnlMethodDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlMethodDivider.Name = "pnlMethodDivider";
        //
        // flowReasonCaption
        //
        flowReasonCaption.Margin = new Padding(0);
        flowReasonCaption.Dock = DockStyle.Fill;
        flowReasonCaption.Padding = new Padding(0, 5, 0, 0);
        flowReasonCaption.WrapContents = false;
        flowReasonCaption.Name = "flowReasonCaption";
        flowReasonCaption.Controls.Add(lblReason);
        flowReasonCaption.Controls.Add(lblRequired);
        //
        // lblReason
        //
        lblReason.Margin = new Padding(0);
        lblReason.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblReason.Text = "Lý do hủy";
        lblReason.TextAlign = ContentAlignment.MiddleLeft;
        lblReason.UseMnemonic = false;
        lblReason.AutoSize = true;
        lblReason.Name = "lblReason";
        //
        // lblRequired
        //
        lblRequired.Margin = new Padding(3, 0, 0, 0);
        lblRequired.ForeColor = Color.FromArgb(185, 28, 28);
        lblRequired.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblRequired.Text = "*";
        lblRequired.TextAlign = ContentAlignment.MiddleLeft;
        lblRequired.UseMnemonic = false;
        lblRequired.AutoSize = true;
        lblRequired.Name = "lblRequired";
        //
        // pnlReasonField
        //
        pnlReasonField.Margin = new Padding(0);
        pnlReasonField.Dock = DockStyle.Fill;
        pnlReasonField.Padding = new Padding(1);
        pnlReasonField.BackColor = Color.FromArgb(226, 232, 240);
        pnlReasonField.Name = "pnlReasonField";
        pnlReasonField.Controls.Add(layoutReasonField);
        //
        // layoutReasonField
        //
        layoutReasonField.Margin = new Padding(0);
        layoutReasonField.Dock = DockStyle.Fill;
        layoutReasonField.Padding = new Padding(7, 0, 5, 0);
        layoutReasonField.BackColor = Color.White;
        layoutReasonField.ColumnCount = 1;
        layoutReasonField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutReasonField.RowCount = 1;
        layoutReasonField.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutReasonField.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutReasonField.Name = "layoutReasonField";
        layoutReasonField.Controls.Add(cmbReason, 0, 0);
        //
        // cmbReason
        //
        cmbReason.Margin = new Padding(0);
        cmbReason.BackColor = Color.White;
        cmbReason.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cmbReason.AccessibleName = "Lý do hủy, bắt buộc";
        cmbReason.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbReason.FlatStyle = FlatStyle.Flat;
        cmbReason.FormattingEnabled = true;
        cmbReason.Items.AddRange(new object[] { "Bán nhầm suất", "Chọn nhầm ghế", "Khách yêu cầu hủy", "Khác" });
        cmbReason.Text = "Bán nhầm suất";
        cmbReason.Name = "cmbReason";
        //
        // lblNote
        //
        lblNote.Margin = new Padding(0);
        lblNote.Dock = DockStyle.Fill;
        lblNote.Padding = new Padding(0, 0, 0, 4);
        lblNote.Font = new Font("Segoe UI", 9.5F);
        lblNote.Text = "Ghi chú (tùy chọn)";
        lblNote.TextAlign = ContentAlignment.BottomLeft;
        lblNote.UseMnemonic = false;
        lblNote.Name = "lblNote";
        //
        // pnlNoteField
        //
        pnlNoteField.Margin = new Padding(0);
        pnlNoteField.Dock = DockStyle.Fill;
        pnlNoteField.Padding = new Padding(1);
        pnlNoteField.BackColor = Color.FromArgb(226, 232, 240);
        pnlNoteField.Name = "pnlNoteField";
        pnlNoteField.Controls.Add(layoutNoteField);
        //
        // layoutNoteField
        //
        layoutNoteField.Margin = new Padding(0);
        layoutNoteField.Dock = DockStyle.Fill;
        layoutNoteField.Padding = new Padding(8, 7, 8, 7);
        layoutNoteField.BackColor = Color.White;
        layoutNoteField.ColumnCount = 1;
        layoutNoteField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutNoteField.RowCount = 1;
        layoutNoteField.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutNoteField.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutNoteField.Name = "layoutNoteField";
        layoutNoteField.Controls.Add(txtNote, 0, 0);
        //
        // txtNote
        //
        txtNote.Margin = new Padding(0);
        txtNote.Dock = DockStyle.Fill;
        txtNote.BackColor = Color.White;
        txtNote.AccessibleName = "Ghi chú, tùy chọn";
        txtNote.BorderStyle = BorderStyle.None;
        txtNote.Multiline = true;
        txtNote.PlaceholderText = "Nhập ghi chú";
        txtNote.Name = "txtNote";
        //
        // pnlFooter
        //
        pnlFooter.Margin = new Padding(0, 16, 0, 0);
        pnlFooter.Dock = DockStyle.Fill;
        pnlFooter.Padding = new Padding(1);
        pnlFooter.BackColor = Color.FromArgb(226, 232, 240);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Controls.Add(layoutFooter);
        //
        // layoutFooter
        //
        layoutFooter.Margin = new Padding(0);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.Padding = new Padding(10, 9, 10, 9);
        layoutFooter.BackColor = Color.White;
        layoutFooter.ColumnCount = 3;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 204F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 224F));
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Controls.Add(btnBack, 0, 0);
        layoutFooter.Controls.Add(btnSubmit, 2, 0);
        //
        // btnBack
        //
        btnBack.Margin = new Padding(0);
        btnBack.Dock = DockStyle.Fill;
        btnBack.BackColor = Color.White;
        btnBack.ForeColor = Color.FromArgb(15, 23, 42);
        btnBack.Font = new Font("Segoe UI", 10F);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Text = "‹  Quay lại hóa đơn";
        btnBack.UseMnemonic = false;
        btnBack.UseVisualStyleBackColor = false;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnBack.Click += BtnBack_Click;
        btnBack.Name = "btnBack";
        //
        // btnSubmit
        //
        btnSubmit.Margin = new Padding(0);
        btnSubmit.Dock = DockStyle.Fill;
        btnSubmit.BackColor = Color.FromArgb(37, 99, 235);
        btnSubmit.ForeColor = Color.White;
        btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSubmit.FlatStyle = FlatStyle.Flat;
        btnSubmit.Text = "Gửi yêu cầu hủy";
        btnSubmit.UseMnemonic = false;
        btnSubmit.UseVisualStyleBackColor = false;
        btnSubmit.FlatAppearance.BorderSize = 0;
        btnSubmit.Name = "btnSubmit";
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
        layoutFooter.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        layoutNoteField.ResumeLayout(false);
        layoutNoteField.PerformLayout();
        pnlNoteField.ResumeLayout(false);
        layoutReasonField.ResumeLayout(false);
        layoutReasonField.PerformLayout();
        pnlReasonField.ResumeLayout(false);
        flowReasonCaption.ResumeLayout(false);
        flowReasonCaption.PerformLayout();
        layoutMethod.ResumeLayout(false);
        layoutExpectedRefund.ResumeLayout(false);
        layoutRequest.ResumeLayout(false);
        pnlRequest.ResumeLayout(false);
        layoutStatus2.ResumeLayout(false);
        layoutStatus1.ResumeLayout(false);
        layoutItemGrid.ResumeLayout(false);
        pnlItemGrid.ResumeLayout(false);
        layoutItems.ResumeLayout(false);
        pnlItems.ResumeLayout(false);
        layoutBody.ResumeLayout(false);
        layoutEligibilityMessage.ResumeLayout(false);
        layoutEligibility.ResumeLayout(false);
        pnlEligibility.ResumeLayout(false);
        layoutHeading.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        pnlViewport.ResumeLayout(false);
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

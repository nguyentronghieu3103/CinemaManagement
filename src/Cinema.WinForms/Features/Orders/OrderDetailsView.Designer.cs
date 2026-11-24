namespace Cinema.WinForms.Features.Orders;

partial class OrderDetailsView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        lnkBack = new LinkLabel();
        layoutTitle = new TableLayoutPanel();
        lblTitle = new Label();
        lblStatus = new Label();
        layoutBody = new TableLayoutPanel();
        layoutItems = new TableLayoutPanel();
        pnlTickets = new Panel();
        layoutTickets = new TableLayoutPanel();
        lblTicketsTitle = new Label();
        pnlTicketContent = new Panel();
        lblTicketSummary = new Label();
        pnlTicketGrid = new Panel();
        layoutTicketGrid = new TableLayoutPanel();
        lblTicketGridMovieHeader = new Label();
        lblTicketGridMovie1 = new Label();
        lblTicketGridMovie2 = new Label();
        lblTicketGridRoomHeader = new Label();
        lblTicketGridRoom1 = new Label();
        lblTicketGridRoom2 = new Label();
        lblTicketGridShowtimeHeader = new Label();
        lblTicketGridShowtime1 = new Label();
        lblTicketGridShowtime2 = new Label();
        lblTicketGridSeatHeader = new Label();
        lblTicketGridSeat1 = new Label();
        lblTicketGridSeat2 = new Label();
        lblTicketGridTypeHeader = new Label();
        lblTicketGridType1 = new Label();
        lblTicketGridType2 = new Label();
        lblTicketGridPriceHeader = new Label();
        lblTicketGridPrice1 = new Label();
        lblTicketGridPrice2 = new Label();
        lblTicketGridStateHeader = new Label();
        layoutTicketGridState1 = new TableLayoutPanel();
        lblTicketGridState1 = new Label();
        layoutTicketGridState2 = new TableLayoutPanel();
        lblTicketGridState2 = new Label();
        pnlConcessions = new Panel();
        layoutConcessions = new TableLayoutPanel();
        lblConcessionsTitle = new Label();
        pnlConcessionContent = new Panel();
        lblConcessionSummary = new Label();
        pnlConcessionGrid = new Panel();
        layoutConcessionGrid = new TableLayoutPanel();
        lblConcessionGridItemHeader = new Label();
        lblConcessionGridItem1 = new Label();
        lblConcessionGridQtyHeader = new Label();
        lblConcessionGridQty1 = new Label();
        lblConcessionGridPriceHeader = new Label();
        lblConcessionGridPrice1 = new Label();
        lblConcessionGridTotalHeader = new Label();
        lblConcessionGridTotal1 = new Label();
        lblConcessionGridStateHeader = new Label();
        layoutConcessionGridState1 = new TableLayoutPanel();
        lblConcessionGridState1 = new Label();
        layoutShowtimeNote = new TableLayoutPanel();
        lblClockIcon = new Label();
        lblShowtimeNote = new Label();
        lblTimeRemaining = new Label();
        layoutSummary = new TableLayoutPanel();
        pnlGeneral = new Panel();
        layoutGeneral = new TableLayoutPanel();
        lblGeneralTitle = new Label();
        layoutStaffInfo = new TableLayoutPanel();
        lblStaffCaption = new Label();
        lblStaffValue = new Label();
        layoutTerminalInfo = new TableLayoutPanel();
        lblTerminalCaption = new Label();
        lblTerminalValue = new Label();
        layoutCreatedInfo = new TableLayoutPanel();
        lblCreatedCaption = new Label();
        lblCreatedValue = new Label();
        layoutCustomerInfo = new TableLayoutPanel();
        lblCustomerCaption = new Label();
        lblCustomerValue = new Label();
        pnlPayment = new Panel();
        layoutPayment = new TableLayoutPanel();
        lblPaymentTitle = new Label();
        layoutSubtotalInfo = new TableLayoutPanel();
        lblSubtotalCaption = new Label();
        lblSubtotalValue = new Label();
        layoutDiscountInfo = new TableLayoutPanel();
        lblDiscountCaption = new Label();
        lblDiscountValue = new Label();
        layoutTotalInfo = new TableLayoutPanel();
        lblTotalCaption = new Label();
        lblTotalValue = new Label();
        layoutMethodInfo = new TableLayoutPanel();
        lblMethodCaption = new Label();
        lblMethodValue = new Label();
        layoutTenderedInfo = new TableLayoutPanel();
        lblTenderedCaption = new Label();
        lblTenderedValue = new Label();
        layoutChangeInfo = new TableLayoutPanel();
        lblChangeCaption = new Label();
        lblChangeValue = new Label();
        pnlFooter = new Panel();
        layoutFooter = new TableLayoutPanel();
        btnPrintTickets = new Button();
        btnPrintInvoice = new Button();
        btnRefund = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        layoutTitle.SuspendLayout();
        layoutBody.SuspendLayout();
        layoutItems.SuspendLayout();
        pnlTickets.SuspendLayout();
        layoutTickets.SuspendLayout();
        pnlTicketContent.SuspendLayout();
        pnlTicketGrid.SuspendLayout();
        layoutTicketGrid.SuspendLayout();
        layoutTicketGridState1.SuspendLayout();
        layoutTicketGridState2.SuspendLayout();
        pnlConcessions.SuspendLayout();
        layoutConcessions.SuspendLayout();
        pnlConcessionContent.SuspendLayout();
        pnlConcessionGrid.SuspendLayout();
        layoutConcessionGrid.SuspendLayout();
        layoutConcessionGridState1.SuspendLayout();
        layoutShowtimeNote.SuspendLayout();
        layoutSummary.SuspendLayout();
        pnlGeneral.SuspendLayout();
        layoutGeneral.SuspendLayout();
        layoutStaffInfo.SuspendLayout();
        layoutTerminalInfo.SuspendLayout();
        layoutCreatedInfo.SuspendLayout();
        layoutCustomerInfo.SuspendLayout();
        pnlPayment.SuspendLayout();
        layoutPayment.SuspendLayout();
        layoutSubtotalInfo.SuspendLayout();
        layoutDiscountInfo.SuspendLayout();
        layoutTotalInfo.SuspendLayout();
        layoutMethodInfo.SuspendLayout();
        layoutTenderedInfo.SuspendLayout();
        layoutChangeInfo.SuspendLayout();
        pnlFooter.SuspendLayout();
        layoutFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(1060, 670);
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
        layoutPage.Controls.Add(lnkBack, 0, 0);
        layoutPage.Controls.Add(layoutTitle, 0, 1);
        layoutPage.Controls.Add(layoutBody, 0, 2);
        layoutPage.Controls.Add(pnlFooter, 0, 3);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(1060, 670);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16);
        layoutPage.RowCount = 5;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 470F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1136, 730);
        layoutPage.TabIndex = 0;
        // 
        // lnkBack
        // 
        lnkBack.Anchor = AnchorStyles.Left;
        lnkBack.AutoSize = true;
        lnkBack.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lnkBack.ForeColor = Color.FromArgb(37, 99, 235);
        lnkBack.LinkBehavior = LinkBehavior.HoverUnderline;
        lnkBack.LinkColor = Color.FromArgb(37, 99, 235);
        lnkBack.Location = new Point(16, 21);
        lnkBack.Margin = new Padding(0);
        lnkBack.Name = "lnkBack";
        lnkBack.Size = new Size(235, 21);
        lnkBack.TabIndex = 0;
        lnkBack.TabStop = true;
        lnkBack.Text = "‹  Quay lại danh sách hóa đơn";
        lnkBack.LinkClicked += LnkBack_LinkClicked;
        // 
        // layoutTitle
        // 
        layoutTitle.ColumnCount = 3;
        layoutTitle.ColumnStyles.Add(new ColumnStyle());
        layoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 153F));
        layoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTitle.Controls.Add(lblTitle, 0, 0);
        layoutTitle.Controls.Add(lblStatus, 1, 0);
        layoutTitle.Dock = DockStyle.Fill;
        layoutTitle.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTitle.Location = new Point(16, 47);
        layoutTitle.Margin = new Padding(0, 0, 0, 7);
        layoutTitle.Name = "layoutTitle";
        layoutTitle.RowCount = 1;
        layoutTitle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTitle.Size = new Size(1104, 44);
        layoutTitle.TabIndex = 1;
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Left;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 2);
        lblTitle.Margin = new Padding(0, 0, 12, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(522, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Chi tiết hóa đơn #INV-20261118-042";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // lblStatus
        // 
        lblStatus.Anchor = AnchorStyles.Left;
        lblStatus.BackColor = Color.FromArgb(220, 252, 231);
        lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
        lblStatus.Location = new Point(534, 8);
        lblStatus.Margin = new Padding(0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(138, 27);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "Đã thanh toán";
        lblStatus.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus.UseMnemonic = false;
        // 
        // layoutBody
        // 
        layoutBody.ColumnCount = 2;
        layoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
        layoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
        layoutBody.Controls.Add(layoutItems, 0, 0);
        layoutBody.Controls.Add(layoutSummary, 1, 0);
        layoutBody.Dock = DockStyle.Fill;
        layoutBody.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBody.Location = new Point(16, 98);
        layoutBody.Margin = new Padding(0);
        layoutBody.Name = "layoutBody";
        layoutBody.RowCount = 1;
        layoutBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBody.Size = new Size(1104, 470);
        layoutBody.TabIndex = 2;
        // 
        // layoutItems
        // 
        layoutItems.ColumnCount = 1;
        layoutItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutItems.Controls.Add(pnlTickets, 0, 0);
        layoutItems.Controls.Add(pnlConcessions, 0, 1);
        layoutItems.Controls.Add(layoutShowtimeNote, 0, 2);
        layoutItems.Dock = DockStyle.Fill;
        layoutItems.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutItems.Location = new Point(0, 0);
        layoutItems.Margin = new Padding(0, 0, 12, 0);
        layoutItems.Name = "layoutItems";
        layoutItems.RowCount = 4;
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 181F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 208F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutItems.Size = new Size(694, 470);
        layoutItems.TabIndex = 0;
        // 
        // pnlTickets
        // 
        pnlTickets.BackColor = Color.FromArgb(226, 232, 240);
        pnlTickets.Controls.Add(layoutTickets);
        pnlTickets.Dock = DockStyle.Fill;
        pnlTickets.Location = new Point(0, 0);
        pnlTickets.Margin = new Padding(0, 0, 0, 12);
        pnlTickets.Name = "pnlTickets";
        pnlTickets.Padding = new Padding(1);
        pnlTickets.Size = new Size(694, 169);
        pnlTickets.TabIndex = 0;
        // 
        // layoutTickets
        // 
        layoutTickets.BackColor = Color.White;
        layoutTickets.ColumnCount = 1;
        layoutTickets.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTickets.Controls.Add(lblTicketsTitle, 0, 0);
        layoutTickets.Controls.Add(pnlTicketContent, 0, 1);
        layoutTickets.Dock = DockStyle.Fill;
        layoutTickets.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTickets.Location = new Point(1, 1);
        layoutTickets.Margin = new Padding(0);
        layoutTickets.Name = "layoutTickets";
        layoutTickets.Padding = new Padding(10, 7, 10, 8);
        layoutTickets.RowCount = 3;
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 116F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTickets.Size = new Size(692, 167);
        layoutTickets.TabIndex = 0;
        // 
        // lblTicketsTitle
        // 
        lblTicketsTitle.Dock = DockStyle.Fill;
        lblTicketsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTicketsTitle.Location = new Point(10, 7);
        lblTicketsTitle.Margin = new Padding(0);
        lblTicketsTitle.Name = "lblTicketsTitle";
        lblTicketsTitle.Size = new Size(672, 37);
        lblTicketsTitle.TabIndex = 0;
        lblTicketsTitle.Text = "Vé xem phim";
        lblTicketsTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketsTitle.UseMnemonic = false;
        // 
        // pnlTicketContent
        // 
        pnlTicketContent.Controls.Add(lblTicketSummary);
        pnlTicketContent.Controls.Add(pnlTicketGrid);
        pnlTicketContent.Dock = DockStyle.Fill;
        pnlTicketContent.Location = new Point(10, 44);
        pnlTicketContent.Margin = new Padding(0);
        pnlTicketContent.Name = "pnlTicketContent";
        pnlTicketContent.Size = new Size(672, 116);
        pnlTicketContent.TabIndex = 1;
        // 
        // lblTicketSummary
        // 
        lblTicketSummary.Dock = DockStyle.Fill;
        lblTicketSummary.Font = new Font("Segoe UI", 9F);
        lblTicketSummary.ForeColor = Color.FromArgb(100, 116, 139);
        lblTicketSummary.Location = new Point(0, 0);
        lblTicketSummary.Margin = new Padding(3, 4, 0, 0);
        lblTicketSummary.Name = "lblTicketSummary";
        lblTicketSummary.Size = new Size(672, 116);
        lblTicketSummary.TabIndex = 0;
        lblTicketSummary.Text = "2 vé Lật Mặt 7";
        lblTicketSummary.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketSummary.UseMnemonic = false;
        lblTicketSummary.Visible = false;
        // 
        // pnlTicketGrid
        // 
        pnlTicketGrid.BackColor = Color.FromArgb(226, 232, 240);
        pnlTicketGrid.Controls.Add(layoutTicketGrid);
        pnlTicketGrid.Dock = DockStyle.Fill;
        pnlTicketGrid.Location = new Point(0, 0);
        pnlTicketGrid.Margin = new Padding(0);
        pnlTicketGrid.Name = "pnlTicketGrid";
        pnlTicketGrid.Padding = new Padding(1);
        pnlTicketGrid.Size = new Size(672, 116);
        pnlTicketGrid.TabIndex = 1;
        // 
        // layoutTicketGrid
        // 
        layoutTicketGrid.BackColor = Color.FromArgb(226, 232, 240);
        layoutTicketGrid.ColumnCount = 7;
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
        layoutTicketGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        layoutTicketGrid.Controls.Add(lblTicketGridMovieHeader, 0, 0);
        layoutTicketGrid.Controls.Add(lblTicketGridMovie1, 0, 1);
        layoutTicketGrid.Controls.Add(lblTicketGridMovie2, 0, 2);
        layoutTicketGrid.Controls.Add(lblTicketGridRoomHeader, 1, 0);
        layoutTicketGrid.Controls.Add(lblTicketGridRoom1, 1, 1);
        layoutTicketGrid.Controls.Add(lblTicketGridRoom2, 1, 2);
        layoutTicketGrid.Controls.Add(lblTicketGridShowtimeHeader, 2, 0);
        layoutTicketGrid.Controls.Add(lblTicketGridShowtime1, 2, 1);
        layoutTicketGrid.Controls.Add(lblTicketGridShowtime2, 2, 2);
        layoutTicketGrid.Controls.Add(lblTicketGridSeatHeader, 3, 0);
        layoutTicketGrid.Controls.Add(lblTicketGridSeat1, 3, 1);
        layoutTicketGrid.Controls.Add(lblTicketGridSeat2, 3, 2);
        layoutTicketGrid.Controls.Add(lblTicketGridTypeHeader, 4, 0);
        layoutTicketGrid.Controls.Add(lblTicketGridType1, 4, 1);
        layoutTicketGrid.Controls.Add(lblTicketGridType2, 4, 2);
        layoutTicketGrid.Controls.Add(lblTicketGridPriceHeader, 5, 0);
        layoutTicketGrid.Controls.Add(lblTicketGridPrice1, 5, 1);
        layoutTicketGrid.Controls.Add(lblTicketGridPrice2, 5, 2);
        layoutTicketGrid.Controls.Add(lblTicketGridStateHeader, 6, 0);
        layoutTicketGrid.Controls.Add(layoutTicketGridState1, 6, 1);
        layoutTicketGrid.Controls.Add(layoutTicketGridState2, 6, 2);
        layoutTicketGrid.Dock = DockStyle.Fill;
        layoutTicketGrid.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTicketGrid.Location = new Point(1, 1);
        layoutTicketGrid.Margin = new Padding(0);
        layoutTicketGrid.Name = "layoutTicketGrid";
        layoutTicketGrid.RowCount = 3;
        layoutTicketGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutTicketGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutTicketGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutTicketGrid.Size = new Size(670, 114);
        layoutTicketGrid.TabIndex = 0;
        // 
        // lblTicketGridMovieHeader
        // 
        lblTicketGridMovieHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridMovieHeader.Dock = DockStyle.Fill;
        lblTicketGridMovieHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridMovieHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridMovieHeader.Location = new Point(0, 0);
        lblTicketGridMovieHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridMovieHeader.Name = "lblTicketGridMovieHeader";
        lblTicketGridMovieHeader.Padding = new Padding(7, 0, 0, 0);
        lblTicketGridMovieHeader.Size = new Size(93, 33);
        lblTicketGridMovieHeader.TabIndex = 0;
        lblTicketGridMovieHeader.Text = "Phim";
        lblTicketGridMovieHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketGridMovieHeader.UseMnemonic = false;
        // 
        // lblTicketGridMovie1
        // 
        lblTicketGridMovie1.BackColor = Color.White;
        lblTicketGridMovie1.Dock = DockStyle.Fill;
        lblTicketGridMovie1.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridMovie1.Location = new Point(0, 34);
        lblTicketGridMovie1.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridMovie1.Name = "lblTicketGridMovie1";
        lblTicketGridMovie1.Padding = new Padding(7, 0, 0, 0);
        lblTicketGridMovie1.Size = new Size(93, 39);
        lblTicketGridMovie1.TabIndex = 1;
        lblTicketGridMovie1.Text = "Lật Mặt 7";
        lblTicketGridMovie1.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketGridMovie1.UseMnemonic = false;
        // 
        // lblTicketGridMovie2
        // 
        lblTicketGridMovie2.BackColor = Color.White;
        lblTicketGridMovie2.Dock = DockStyle.Fill;
        lblTicketGridMovie2.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridMovie2.Location = new Point(0, 74);
        lblTicketGridMovie2.Margin = new Padding(0);
        lblTicketGridMovie2.Name = "lblTicketGridMovie2";
        lblTicketGridMovie2.Padding = new Padding(7, 0, 0, 0);
        lblTicketGridMovie2.Size = new Size(93, 40);
        lblTicketGridMovie2.TabIndex = 2;
        lblTicketGridMovie2.Text = "Lật Mặt 7";
        lblTicketGridMovie2.TextAlign = ContentAlignment.MiddleLeft;
        lblTicketGridMovie2.UseMnemonic = false;
        // 
        // lblTicketGridRoomHeader
        // 
        lblTicketGridRoomHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridRoomHeader.Dock = DockStyle.Fill;
        lblTicketGridRoomHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridRoomHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridRoomHeader.Location = new Point(93, 0);
        lblTicketGridRoomHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridRoomHeader.Name = "lblTicketGridRoomHeader";
        lblTicketGridRoomHeader.Size = new Size(60, 33);
        lblTicketGridRoomHeader.TabIndex = 3;
        lblTicketGridRoomHeader.Text = "Phòng";
        lblTicketGridRoomHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridRoomHeader.UseMnemonic = false;
        // 
        // lblTicketGridRoom1
        // 
        lblTicketGridRoom1.BackColor = Color.White;
        lblTicketGridRoom1.Dock = DockStyle.Fill;
        lblTicketGridRoom1.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridRoom1.Location = new Point(93, 34);
        lblTicketGridRoom1.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridRoom1.Name = "lblTicketGridRoom1";
        lblTicketGridRoom1.Size = new Size(60, 39);
        lblTicketGridRoom1.TabIndex = 4;
        lblTicketGridRoom1.Text = "03";
        lblTicketGridRoom1.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridRoom1.UseMnemonic = false;
        // 
        // lblTicketGridRoom2
        // 
        lblTicketGridRoom2.BackColor = Color.White;
        lblTicketGridRoom2.Dock = DockStyle.Fill;
        lblTicketGridRoom2.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridRoom2.Location = new Point(93, 74);
        lblTicketGridRoom2.Margin = new Padding(0);
        lblTicketGridRoom2.Name = "lblTicketGridRoom2";
        lblTicketGridRoom2.Size = new Size(60, 40);
        lblTicketGridRoom2.TabIndex = 5;
        lblTicketGridRoom2.Text = "03";
        lblTicketGridRoom2.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridRoom2.UseMnemonic = false;
        // 
        // lblTicketGridShowtimeHeader
        // 
        lblTicketGridShowtimeHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridShowtimeHeader.Dock = DockStyle.Fill;
        lblTicketGridShowtimeHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridShowtimeHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridShowtimeHeader.Location = new Point(153, 0);
        lblTicketGridShowtimeHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridShowtimeHeader.Name = "lblTicketGridShowtimeHeader";
        lblTicketGridShowtimeHeader.Size = new Size(167, 33);
        lblTicketGridShowtimeHeader.TabIndex = 6;
        lblTicketGridShowtimeHeader.Text = "Suất chiếu";
        lblTicketGridShowtimeHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridShowtimeHeader.UseMnemonic = false;
        // 
        // lblTicketGridShowtime1
        // 
        lblTicketGridShowtime1.BackColor = Color.White;
        lblTicketGridShowtime1.Dock = DockStyle.Fill;
        lblTicketGridShowtime1.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridShowtime1.Location = new Point(153, 34);
        lblTicketGridShowtime1.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridShowtime1.Name = "lblTicketGridShowtime1";
        lblTicketGridShowtime1.Size = new Size(167, 39);
        lblTicketGridShowtime1.TabIndex = 7;
        lblTicketGridShowtime1.Text = "20:30 · 18/11/2026";
        lblTicketGridShowtime1.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridShowtime1.UseMnemonic = false;
        // 
        // lblTicketGridShowtime2
        // 
        lblTicketGridShowtime2.BackColor = Color.White;
        lblTicketGridShowtime2.Dock = DockStyle.Fill;
        lblTicketGridShowtime2.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridShowtime2.Location = new Point(153, 74);
        lblTicketGridShowtime2.Margin = new Padding(0);
        lblTicketGridShowtime2.Name = "lblTicketGridShowtime2";
        lblTicketGridShowtime2.Size = new Size(167, 40);
        lblTicketGridShowtime2.TabIndex = 8;
        lblTicketGridShowtime2.Text = "20:30 · 18/11/2026";
        lblTicketGridShowtime2.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridShowtime2.UseMnemonic = false;
        // 
        // lblTicketGridSeatHeader
        // 
        lblTicketGridSeatHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridSeatHeader.Dock = DockStyle.Fill;
        lblTicketGridSeatHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridSeatHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridSeatHeader.Location = new Point(320, 0);
        lblTicketGridSeatHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridSeatHeader.Name = "lblTicketGridSeatHeader";
        lblTicketGridSeatHeader.Size = new Size(60, 33);
        lblTicketGridSeatHeader.TabIndex = 9;
        lblTicketGridSeatHeader.Text = "Ghế";
        lblTicketGridSeatHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridSeatHeader.UseMnemonic = false;
        // 
        // lblTicketGridSeat1
        // 
        lblTicketGridSeat1.BackColor = Color.White;
        lblTicketGridSeat1.Dock = DockStyle.Fill;
        lblTicketGridSeat1.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridSeat1.Location = new Point(320, 34);
        lblTicketGridSeat1.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridSeat1.Name = "lblTicketGridSeat1";
        lblTicketGridSeat1.Size = new Size(60, 39);
        lblTicketGridSeat1.TabIndex = 10;
        lblTicketGridSeat1.Text = "G05";
        lblTicketGridSeat1.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridSeat1.UseMnemonic = false;
        // 
        // lblTicketGridSeat2
        // 
        lblTicketGridSeat2.BackColor = Color.White;
        lblTicketGridSeat2.Dock = DockStyle.Fill;
        lblTicketGridSeat2.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridSeat2.Location = new Point(320, 74);
        lblTicketGridSeat2.Margin = new Padding(0);
        lblTicketGridSeat2.Name = "lblTicketGridSeat2";
        lblTicketGridSeat2.Size = new Size(60, 40);
        lblTicketGridSeat2.TabIndex = 11;
        lblTicketGridSeat2.Text = "G06";
        lblTicketGridSeat2.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridSeat2.UseMnemonic = false;
        // 
        // lblTicketGridTypeHeader
        // 
        lblTicketGridTypeHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridTypeHeader.Dock = DockStyle.Fill;
        lblTicketGridTypeHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridTypeHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridTypeHeader.Location = new Point(380, 0);
        lblTicketGridTypeHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridTypeHeader.Name = "lblTicketGridTypeHeader";
        lblTicketGridTypeHeader.Size = new Size(53, 33);
        lblTicketGridTypeHeader.TabIndex = 12;
        lblTicketGridTypeHeader.Text = "Loại";
        lblTicketGridTypeHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridTypeHeader.UseMnemonic = false;
        // 
        // lblTicketGridType1
        // 
        lblTicketGridType1.BackColor = Color.White;
        lblTicketGridType1.Dock = DockStyle.Fill;
        lblTicketGridType1.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridType1.Location = new Point(380, 34);
        lblTicketGridType1.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridType1.Name = "lblTicketGridType1";
        lblTicketGridType1.Size = new Size(53, 39);
        lblTicketGridType1.TabIndex = 13;
        lblTicketGridType1.Text = "VIP";
        lblTicketGridType1.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridType1.UseMnemonic = false;
        // 
        // lblTicketGridType2
        // 
        lblTicketGridType2.BackColor = Color.White;
        lblTicketGridType2.Dock = DockStyle.Fill;
        lblTicketGridType2.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridType2.Location = new Point(380, 74);
        lblTicketGridType2.Margin = new Padding(0);
        lblTicketGridType2.Name = "lblTicketGridType2";
        lblTicketGridType2.Size = new Size(53, 40);
        lblTicketGridType2.TabIndex = 14;
        lblTicketGridType2.Text = "VIP";
        lblTicketGridType2.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridType2.UseMnemonic = false;
        // 
        // lblTicketGridPriceHeader
        // 
        lblTicketGridPriceHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridPriceHeader.Dock = DockStyle.Fill;
        lblTicketGridPriceHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridPriceHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridPriceHeader.Location = new Point(433, 0);
        lblTicketGridPriceHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridPriceHeader.Name = "lblTicketGridPriceHeader";
        lblTicketGridPriceHeader.Padding = new Padding(0, 0, 7, 0);
        lblTicketGridPriceHeader.Size = new Size(100, 33);
        lblTicketGridPriceHeader.TabIndex = 15;
        lblTicketGridPriceHeader.Text = "Đơn giá";
        lblTicketGridPriceHeader.TextAlign = ContentAlignment.MiddleRight;
        lblTicketGridPriceHeader.UseMnemonic = false;
        // 
        // lblTicketGridPrice1
        // 
        lblTicketGridPrice1.BackColor = Color.White;
        lblTicketGridPrice1.Dock = DockStyle.Fill;
        lblTicketGridPrice1.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridPrice1.Location = new Point(433, 34);
        lblTicketGridPrice1.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridPrice1.Name = "lblTicketGridPrice1";
        lblTicketGridPrice1.Padding = new Padding(0, 0, 7, 0);
        lblTicketGridPrice1.Size = new Size(100, 39);
        lblTicketGridPrice1.TabIndex = 16;
        lblTicketGridPrice1.Text = "110.000 đ";
        lblTicketGridPrice1.TextAlign = ContentAlignment.MiddleRight;
        lblTicketGridPrice1.UseMnemonic = false;
        // 
        // lblTicketGridPrice2
        // 
        lblTicketGridPrice2.BackColor = Color.White;
        lblTicketGridPrice2.Dock = DockStyle.Fill;
        lblTicketGridPrice2.Font = new Font("Segoe UI", 8.5F);
        lblTicketGridPrice2.Location = new Point(433, 74);
        lblTicketGridPrice2.Margin = new Padding(0);
        lblTicketGridPrice2.Name = "lblTicketGridPrice2";
        lblTicketGridPrice2.Padding = new Padding(0, 0, 7, 0);
        lblTicketGridPrice2.Size = new Size(100, 40);
        lblTicketGridPrice2.TabIndex = 17;
        lblTicketGridPrice2.Text = "110.000 đ";
        lblTicketGridPrice2.TextAlign = ContentAlignment.MiddleRight;
        lblTicketGridPrice2.UseMnemonic = false;
        // 
        // lblTicketGridStateHeader
        // 
        lblTicketGridStateHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblTicketGridStateHeader.Dock = DockStyle.Fill;
        lblTicketGridStateHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblTicketGridStateHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblTicketGridStateHeader.Location = new Point(533, 0);
        lblTicketGridStateHeader.Margin = new Padding(0, 0, 0, 1);
        lblTicketGridStateHeader.Name = "lblTicketGridStateHeader";
        lblTicketGridStateHeader.Size = new Size(137, 33);
        lblTicketGridStateHeader.TabIndex = 18;
        lblTicketGridStateHeader.Text = "Trạng thái vé";
        lblTicketGridStateHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridStateHeader.UseMnemonic = false;
        // 
        // layoutTicketGridState1
        // 
        layoutTicketGridState1.BackColor = Color.White;
        layoutTicketGridState1.ColumnCount = 1;
        layoutTicketGridState1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTicketGridState1.Controls.Add(lblTicketGridState1, 0, 0);
        layoutTicketGridState1.Dock = DockStyle.Fill;
        layoutTicketGridState1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTicketGridState1.Location = new Point(533, 34);
        layoutTicketGridState1.Margin = new Padding(0, 0, 0, 1);
        layoutTicketGridState1.Name = "layoutTicketGridState1";
        layoutTicketGridState1.RowCount = 1;
        layoutTicketGridState1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTicketGridState1.Size = new Size(137, 39);
        layoutTicketGridState1.TabIndex = 19;
        // 
        // lblTicketGridState1
        // 
        lblTicketGridState1.Anchor = AnchorStyles.None;
        lblTicketGridState1.BackColor = Color.FromArgb(220, 252, 231);
        lblTicketGridState1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblTicketGridState1.ForeColor = Color.FromArgb(22, 101, 52);
        lblTicketGridState1.Location = new Point(15, 7);
        lblTicketGridState1.Margin = new Padding(0);
        lblTicketGridState1.Name = "lblTicketGridState1";
        lblTicketGridState1.Size = new Size(106, 24);
        lblTicketGridState1.TabIndex = 0;
        lblTicketGridState1.Text = "Chưa sử dụng";
        lblTicketGridState1.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridState1.UseMnemonic = false;
        // 
        // layoutTicketGridState2
        // 
        layoutTicketGridState2.BackColor = Color.White;
        layoutTicketGridState2.ColumnCount = 1;
        layoutTicketGridState2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTicketGridState2.Controls.Add(lblTicketGridState2, 0, 0);
        layoutTicketGridState2.Dock = DockStyle.Fill;
        layoutTicketGridState2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTicketGridState2.Location = new Point(533, 74);
        layoutTicketGridState2.Margin = new Padding(0);
        layoutTicketGridState2.Name = "layoutTicketGridState2";
        layoutTicketGridState2.RowCount = 1;
        layoutTicketGridState2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTicketGridState2.Size = new Size(137, 40);
        layoutTicketGridState2.TabIndex = 20;
        // 
        // lblTicketGridState2
        // 
        lblTicketGridState2.Anchor = AnchorStyles.None;
        lblTicketGridState2.BackColor = Color.FromArgb(220, 252, 231);
        lblTicketGridState2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblTicketGridState2.ForeColor = Color.FromArgb(22, 101, 52);
        lblTicketGridState2.Location = new Point(15, 8);
        lblTicketGridState2.Margin = new Padding(0);
        lblTicketGridState2.Name = "lblTicketGridState2";
        lblTicketGridState2.Size = new Size(106, 24);
        lblTicketGridState2.TabIndex = 0;
        lblTicketGridState2.Text = "Chưa sử dụng";
        lblTicketGridState2.TextAlign = ContentAlignment.MiddleCenter;
        lblTicketGridState2.UseMnemonic = false;
        // 
        // pnlConcessions
        // 
        pnlConcessions.BackColor = Color.FromArgb(226, 232, 240);
        pnlConcessions.Controls.Add(layoutConcessions);
        pnlConcessions.Dock = DockStyle.Fill;
        pnlConcessions.Location = new Point(0, 181);
        pnlConcessions.Margin = new Padding(0, 0, 0, 12);
        pnlConcessions.Name = "pnlConcessions";
        pnlConcessions.Padding = new Padding(1);
        pnlConcessions.Size = new Size(694, 196);
        pnlConcessions.TabIndex = 1;
        // 
        // layoutConcessions
        // 
        layoutConcessions.BackColor = Color.White;
        layoutConcessions.ColumnCount = 1;
        layoutConcessions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutConcessions.Controls.Add(lblConcessionsTitle, 0, 0);
        layoutConcessions.Controls.Add(pnlConcessionContent, 0, 1);
        layoutConcessions.Dock = DockStyle.Fill;
        layoutConcessions.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutConcessions.Location = new Point(1, 1);
        layoutConcessions.Margin = new Padding(0);
        layoutConcessions.Name = "layoutConcessions";
        layoutConcessions.Padding = new Padding(10, 7, 10, 8);
        layoutConcessions.RowCount = 3;
        layoutConcessions.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
        layoutConcessions.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
        layoutConcessions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutConcessions.Size = new Size(692, 194);
        layoutConcessions.TabIndex = 0;
        // 
        // lblConcessionsTitle
        // 
        lblConcessionsTitle.Dock = DockStyle.Fill;
        lblConcessionsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblConcessionsTitle.Location = new Point(10, 7);
        lblConcessionsTitle.Margin = new Padding(0);
        lblConcessionsTitle.Name = "lblConcessionsTitle";
        lblConcessionsTitle.Size = new Size(672, 37);
        lblConcessionsTitle.TabIndex = 0;
        lblConcessionsTitle.Text = "Bắp nước";
        lblConcessionsTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblConcessionsTitle.UseMnemonic = false;
        // 
        // pnlConcessionContent
        // 
        pnlConcessionContent.Controls.Add(lblConcessionSummary);
        pnlConcessionContent.Controls.Add(pnlConcessionGrid);
        pnlConcessionContent.Dock = DockStyle.Fill;
        pnlConcessionContent.Location = new Point(10, 44);
        pnlConcessionContent.Margin = new Padding(0);
        pnlConcessionContent.Name = "pnlConcessionContent";
        pnlConcessionContent.Size = new Size(672, 76);
        pnlConcessionContent.TabIndex = 1;
        // 
        // lblConcessionSummary
        // 
        lblConcessionSummary.Dock = DockStyle.Fill;
        lblConcessionSummary.Font = new Font("Segoe UI", 9F);
        lblConcessionSummary.ForeColor = Color.FromArgb(100, 116, 139);
        lblConcessionSummary.Location = new Point(0, 0);
        lblConcessionSummary.Margin = new Padding(0);
        lblConcessionSummary.Name = "lblConcessionSummary";
        lblConcessionSummary.Size = new Size(672, 76);
        lblConcessionSummary.TabIndex = 0;
        lblConcessionSummary.Text = "Chưa có chi tiết bắp nước mẫu.";
        lblConcessionSummary.TextAlign = ContentAlignment.MiddleLeft;
        lblConcessionSummary.UseMnemonic = false;
        lblConcessionSummary.Visible = false;
        // 
        // pnlConcessionGrid
        // 
        pnlConcessionGrid.BackColor = Color.FromArgb(226, 232, 240);
        pnlConcessionGrid.Controls.Add(layoutConcessionGrid);
        pnlConcessionGrid.Dock = DockStyle.Fill;
        pnlConcessionGrid.Location = new Point(0, 0);
        pnlConcessionGrid.Margin = new Padding(0);
        pnlConcessionGrid.Name = "pnlConcessionGrid";
        pnlConcessionGrid.Padding = new Padding(1);
        pnlConcessionGrid.Size = new Size(672, 76);
        pnlConcessionGrid.TabIndex = 1;
        // 
        // layoutConcessionGrid
        // 
        layoutConcessionGrid.BackColor = Color.FromArgb(226, 232, 240);
        layoutConcessionGrid.ColumnCount = 5;
        layoutConcessionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39F));
        layoutConcessionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
        layoutConcessionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
        layoutConcessionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
        layoutConcessionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
        layoutConcessionGrid.Controls.Add(lblConcessionGridItemHeader, 0, 0);
        layoutConcessionGrid.Controls.Add(lblConcessionGridItem1, 0, 1);
        layoutConcessionGrid.Controls.Add(lblConcessionGridQtyHeader, 1, 0);
        layoutConcessionGrid.Controls.Add(lblConcessionGridQty1, 1, 1);
        layoutConcessionGrid.Controls.Add(lblConcessionGridPriceHeader, 2, 0);
        layoutConcessionGrid.Controls.Add(lblConcessionGridPrice1, 2, 1);
        layoutConcessionGrid.Controls.Add(lblConcessionGridTotalHeader, 3, 0);
        layoutConcessionGrid.Controls.Add(lblConcessionGridTotal1, 3, 1);
        layoutConcessionGrid.Controls.Add(lblConcessionGridStateHeader, 4, 0);
        layoutConcessionGrid.Controls.Add(layoutConcessionGridState1, 4, 1);
        layoutConcessionGrid.Dock = DockStyle.Fill;
        layoutConcessionGrid.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutConcessionGrid.Location = new Point(1, 1);
        layoutConcessionGrid.Margin = new Padding(0);
        layoutConcessionGrid.Name = "layoutConcessionGrid";
        layoutConcessionGrid.RowCount = 2;
        layoutConcessionGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutConcessionGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutConcessionGrid.Size = new Size(670, 74);
        layoutConcessionGrid.TabIndex = 0;
        // 
        // lblConcessionGridItemHeader
        // 
        lblConcessionGridItemHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblConcessionGridItemHeader.Dock = DockStyle.Fill;
        lblConcessionGridItemHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblConcessionGridItemHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblConcessionGridItemHeader.Location = new Point(0, 0);
        lblConcessionGridItemHeader.Margin = new Padding(0, 0, 0, 1);
        lblConcessionGridItemHeader.Name = "lblConcessionGridItemHeader";
        lblConcessionGridItemHeader.Padding = new Padding(7, 0, 0, 0);
        lblConcessionGridItemHeader.Size = new Size(261, 33);
        lblConcessionGridItemHeader.TabIndex = 0;
        lblConcessionGridItemHeader.Text = "Tên món / Combo";
        lblConcessionGridItemHeader.TextAlign = ContentAlignment.MiddleLeft;
        lblConcessionGridItemHeader.UseMnemonic = false;
        // 
        // lblConcessionGridItem1
        // 
        lblConcessionGridItem1.BackColor = Color.White;
        lblConcessionGridItem1.Dock = DockStyle.Fill;
        lblConcessionGridItem1.Font = new Font("Segoe UI", 8.5F);
        lblConcessionGridItem1.Location = new Point(0, 34);
        lblConcessionGridItem1.Margin = new Padding(0);
        lblConcessionGridItem1.Name = "lblConcessionGridItem1";
        lblConcessionGridItem1.Padding = new Padding(7, 0, 0, 0);
        lblConcessionGridItem1.Size = new Size(261, 40);
        lblConcessionGridItem1.TabIndex = 1;
        lblConcessionGridItem1.Text = "Combo đôi – 1 Bắp lớn + 2 Nước";
        lblConcessionGridItem1.TextAlign = ContentAlignment.MiddleLeft;
        lblConcessionGridItem1.UseMnemonic = false;
        // 
        // lblConcessionGridQtyHeader
        // 
        lblConcessionGridQtyHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblConcessionGridQtyHeader.Dock = DockStyle.Fill;
        lblConcessionGridQtyHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblConcessionGridQtyHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblConcessionGridQtyHeader.Location = new Point(261, 0);
        lblConcessionGridQtyHeader.Margin = new Padding(0, 0, 0, 1);
        lblConcessionGridQtyHeader.Name = "lblConcessionGridQtyHeader";
        lblConcessionGridQtyHeader.Size = new Size(53, 33);
        lblConcessionGridQtyHeader.TabIndex = 2;
        lblConcessionGridQtyHeader.Text = "SL";
        lblConcessionGridQtyHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblConcessionGridQtyHeader.UseMnemonic = false;
        // 
        // lblConcessionGridQty1
        // 
        lblConcessionGridQty1.BackColor = Color.White;
        lblConcessionGridQty1.Dock = DockStyle.Fill;
        lblConcessionGridQty1.Font = new Font("Segoe UI", 8.5F);
        lblConcessionGridQty1.Location = new Point(261, 34);
        lblConcessionGridQty1.Margin = new Padding(0);
        lblConcessionGridQty1.Name = "lblConcessionGridQty1";
        lblConcessionGridQty1.Size = new Size(53, 40);
        lblConcessionGridQty1.TabIndex = 3;
        lblConcessionGridQty1.Text = "1";
        lblConcessionGridQty1.TextAlign = ContentAlignment.MiddleCenter;
        lblConcessionGridQty1.UseMnemonic = false;
        // 
        // lblConcessionGridPriceHeader
        // 
        lblConcessionGridPriceHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblConcessionGridPriceHeader.Dock = DockStyle.Fill;
        lblConcessionGridPriceHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblConcessionGridPriceHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblConcessionGridPriceHeader.Location = new Point(314, 0);
        lblConcessionGridPriceHeader.Margin = new Padding(0, 0, 0, 1);
        lblConcessionGridPriceHeader.Name = "lblConcessionGridPriceHeader";
        lblConcessionGridPriceHeader.Padding = new Padding(0, 0, 7, 0);
        lblConcessionGridPriceHeader.Size = new Size(100, 33);
        lblConcessionGridPriceHeader.TabIndex = 4;
        lblConcessionGridPriceHeader.Text = "Đơn giá";
        lblConcessionGridPriceHeader.TextAlign = ContentAlignment.MiddleRight;
        lblConcessionGridPriceHeader.UseMnemonic = false;
        // 
        // lblConcessionGridPrice1
        // 
        lblConcessionGridPrice1.BackColor = Color.White;
        lblConcessionGridPrice1.Dock = DockStyle.Fill;
        lblConcessionGridPrice1.Font = new Font("Segoe UI", 8.5F);
        lblConcessionGridPrice1.Location = new Point(314, 34);
        lblConcessionGridPrice1.Margin = new Padding(0);
        lblConcessionGridPrice1.Name = "lblConcessionGridPrice1";
        lblConcessionGridPrice1.Padding = new Padding(0, 0, 7, 0);
        lblConcessionGridPrice1.Size = new Size(100, 40);
        lblConcessionGridPrice1.TabIndex = 5;
        lblConcessionGridPrice1.Text = "99.000 đ";
        lblConcessionGridPrice1.TextAlign = ContentAlignment.MiddleRight;
        lblConcessionGridPrice1.UseMnemonic = false;
        // 
        // lblConcessionGridTotalHeader
        // 
        lblConcessionGridTotalHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblConcessionGridTotalHeader.Dock = DockStyle.Fill;
        lblConcessionGridTotalHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblConcessionGridTotalHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblConcessionGridTotalHeader.Location = new Point(414, 0);
        lblConcessionGridTotalHeader.Margin = new Padding(0, 0, 0, 1);
        lblConcessionGridTotalHeader.Name = "lblConcessionGridTotalHeader";
        lblConcessionGridTotalHeader.Padding = new Padding(0, 0, 7, 0);
        lblConcessionGridTotalHeader.Size = new Size(107, 33);
        lblConcessionGridTotalHeader.TabIndex = 6;
        lblConcessionGridTotalHeader.Text = "Thành tiền";
        lblConcessionGridTotalHeader.TextAlign = ContentAlignment.MiddleRight;
        lblConcessionGridTotalHeader.UseMnemonic = false;
        // 
        // lblConcessionGridTotal1
        // 
        lblConcessionGridTotal1.BackColor = Color.White;
        lblConcessionGridTotal1.Dock = DockStyle.Fill;
        lblConcessionGridTotal1.Font = new Font("Segoe UI", 8.5F);
        lblConcessionGridTotal1.Location = new Point(414, 34);
        lblConcessionGridTotal1.Margin = new Padding(0);
        lblConcessionGridTotal1.Name = "lblConcessionGridTotal1";
        lblConcessionGridTotal1.Padding = new Padding(0, 0, 7, 0);
        lblConcessionGridTotal1.Size = new Size(107, 40);
        lblConcessionGridTotal1.TabIndex = 7;
        lblConcessionGridTotal1.Text = "99.000 đ";
        lblConcessionGridTotal1.TextAlign = ContentAlignment.MiddleRight;
        lblConcessionGridTotal1.UseMnemonic = false;
        // 
        // lblConcessionGridStateHeader
        // 
        lblConcessionGridStateHeader.BackColor = Color.FromArgb(241, 245, 249);
        lblConcessionGridStateHeader.Dock = DockStyle.Fill;
        lblConcessionGridStateHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblConcessionGridStateHeader.ForeColor = Color.FromArgb(51, 65, 85);
        lblConcessionGridStateHeader.Location = new Point(521, 0);
        lblConcessionGridStateHeader.Margin = new Padding(0, 0, 0, 1);
        lblConcessionGridStateHeader.Name = "lblConcessionGridStateHeader";
        lblConcessionGridStateHeader.Size = new Size(149, 33);
        lblConcessionGridStateHeader.TabIndex = 8;
        lblConcessionGridStateHeader.Text = "Trạng thái";
        lblConcessionGridStateHeader.TextAlign = ContentAlignment.MiddleCenter;
        lblConcessionGridStateHeader.UseMnemonic = false;
        // 
        // layoutConcessionGridState1
        // 
        layoutConcessionGridState1.BackColor = Color.White;
        layoutConcessionGridState1.ColumnCount = 1;
        layoutConcessionGridState1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutConcessionGridState1.Controls.Add(lblConcessionGridState1, 0, 0);
        layoutConcessionGridState1.Dock = DockStyle.Fill;
        layoutConcessionGridState1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutConcessionGridState1.Location = new Point(521, 34);
        layoutConcessionGridState1.Margin = new Padding(0);
        layoutConcessionGridState1.Name = "layoutConcessionGridState1";
        layoutConcessionGridState1.RowCount = 1;
        layoutConcessionGridState1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutConcessionGridState1.Size = new Size(149, 40);
        layoutConcessionGridState1.TabIndex = 9;
        // 
        // lblConcessionGridState1
        // 
        lblConcessionGridState1.Anchor = AnchorStyles.None;
        lblConcessionGridState1.BackColor = Color.FromArgb(241, 245, 249);
        lblConcessionGridState1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblConcessionGridState1.ForeColor = Color.FromArgb(51, 65, 85);
        lblConcessionGridState1.Location = new Point(9, 8);
        lblConcessionGridState1.Margin = new Padding(0);
        lblConcessionGridState1.Name = "lblConcessionGridState1";
        lblConcessionGridState1.Size = new Size(130, 24);
        lblConcessionGridState1.TabIndex = 0;
        lblConcessionGridState1.Text = "Chưa nhận hàng";
        lblConcessionGridState1.TextAlign = ContentAlignment.MiddleCenter;
        lblConcessionGridState1.UseMnemonic = false;
        // 
        // layoutShowtimeNote
        // 
        layoutShowtimeNote.BackColor = Color.FromArgb(239, 246, 255);
        layoutShowtimeNote.ColumnCount = 3;
        layoutShowtimeNote.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 29F));
        layoutShowtimeNote.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
        layoutShowtimeNote.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
        layoutShowtimeNote.Controls.Add(lblClockIcon, 0, 0);
        layoutShowtimeNote.Controls.Add(lblShowtimeNote, 1, 0);
        layoutShowtimeNote.Controls.Add(lblTimeRemaining, 2, 0);
        layoutShowtimeNote.Dock = DockStyle.Fill;
        layoutShowtimeNote.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutShowtimeNote.Location = new Point(0, 389);
        layoutShowtimeNote.Margin = new Padding(0);
        layoutShowtimeNote.Name = "layoutShowtimeNote";
        layoutShowtimeNote.Padding = new Padding(8, 0, 8, 0);
        layoutShowtimeNote.RowCount = 1;
        layoutShowtimeNote.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutShowtimeNote.Size = new Size(694, 43);
        layoutShowtimeNote.TabIndex = 2;
        // 
        // lblClockIcon
        // 
        lblClockIcon.AccessibleRole = AccessibleRole.Graphic;
        lblClockIcon.Dock = DockStyle.Fill;
        lblClockIcon.Font = new Font("Segoe MDL2 Assets", 11F);
        lblClockIcon.ForeColor = Color.FromArgb(37, 99, 235);
        lblClockIcon.Location = new Point(8, 0);
        lblClockIcon.Margin = new Padding(0);
        lblClockIcon.Name = "lblClockIcon";
        lblClockIcon.Size = new Size(29, 43);
        lblClockIcon.TabIndex = 0;
        lblClockIcon.Text = "";
        lblClockIcon.TextAlign = ContentAlignment.MiddleCenter;
        lblClockIcon.UseMnemonic = false;
        // 
        // lblShowtimeNote
        // 
        lblShowtimeNote.Dock = DockStyle.Fill;
        lblShowtimeNote.Font = new Font("Segoe UI", 8.5F);
        lblShowtimeNote.Location = new Point(37, 0);
        lblShowtimeNote.Margin = new Padding(0);
        lblShowtimeNote.Name = "lblShowtimeNote";
        lblShowtimeNote.Size = new Size(402, 43);
        lblShowtimeNote.TabIndex = 1;
        lblShowtimeNote.Text = "Lật Mặt 7 · Phòng 03 · 20:30, 18/11/2026";
        lblShowtimeNote.TextAlign = ContentAlignment.MiddleLeft;
        lblShowtimeNote.UseMnemonic = false;
        // 
        // lblTimeRemaining
        // 
        lblTimeRemaining.Dock = DockStyle.Fill;
        lblTimeRemaining.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblTimeRemaining.ForeColor = Color.FromArgb(22, 101, 52);
        lblTimeRemaining.Location = new Point(439, 0);
        lblTimeRemaining.Margin = new Padding(0);
        lblTimeRemaining.Name = "lblTimeRemaining";
        lblTimeRemaining.Size = new Size(247, 43);
        lblTimeRemaining.TabIndex = 2;
        lblTimeRemaining.Text = "Còn 75 phút (tính đến 19:15)";
        lblTimeRemaining.TextAlign = ContentAlignment.MiddleRight;
        lblTimeRemaining.UseMnemonic = false;
        // 
        // layoutSummary
        // 
        layoutSummary.ColumnCount = 1;
        layoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutSummary.Controls.Add(pnlGeneral, 0, 0);
        layoutSummary.Controls.Add(pnlPayment, 0, 1);
        layoutSummary.Dock = DockStyle.Fill;
        layoutSummary.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSummary.Location = new Point(706, 0);
        layoutSummary.Margin = new Padding(0);
        layoutSummary.Name = "layoutSummary";
        layoutSummary.RowCount = 3;
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 208F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSummary.Size = new Size(398, 470);
        layoutSummary.TabIndex = 1;
        // 
        // pnlGeneral
        // 
        pnlGeneral.BackColor = Color.FromArgb(226, 232, 240);
        pnlGeneral.Controls.Add(layoutGeneral);
        pnlGeneral.Dock = DockStyle.Fill;
        pnlGeneral.Location = new Point(0, 0);
        pnlGeneral.Margin = new Padding(0, 0, 0, 10);
        pnlGeneral.Name = "pnlGeneral";
        pnlGeneral.Padding = new Padding(1);
        pnlGeneral.Size = new Size(398, 198);
        pnlGeneral.TabIndex = 0;
        // 
        // layoutGeneral
        // 
        layoutGeneral.BackColor = Color.White;
        layoutGeneral.ColumnCount = 1;
        layoutGeneral.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutGeneral.Controls.Add(lblGeneralTitle, 0, 0);
        layoutGeneral.Controls.Add(layoutStaffInfo, 0, 1);
        layoutGeneral.Controls.Add(layoutTerminalInfo, 0, 2);
        layoutGeneral.Controls.Add(layoutCreatedInfo, 0, 3);
        layoutGeneral.Controls.Add(layoutCustomerInfo, 0, 4);
        layoutGeneral.Dock = DockStyle.Fill;
        layoutGeneral.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutGeneral.Location = new Point(1, 1);
        layoutGeneral.Margin = new Padding(0);
        layoutGeneral.Name = "layoutGeneral";
        layoutGeneral.Padding = new Padding(10, 7, 10, 7);
        layoutGeneral.RowCount = 6;
        layoutGeneral.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
        layoutGeneral.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
        layoutGeneral.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
        layoutGeneral.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
        layoutGeneral.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutGeneral.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutGeneral.Size = new Size(396, 196);
        layoutGeneral.TabIndex = 0;
        // 
        // lblGeneralTitle
        // 
        lblGeneralTitle.Dock = DockStyle.Fill;
        lblGeneralTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblGeneralTitle.Location = new Point(10, 7);
        lblGeneralTitle.Margin = new Padding(0);
        lblGeneralTitle.Name = "lblGeneralTitle";
        lblGeneralTitle.Size = new Size(376, 37);
        lblGeneralTitle.TabIndex = 0;
        lblGeneralTitle.Text = "Thông tin chung";
        lblGeneralTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblGeneralTitle.UseMnemonic = false;
        // 
        // layoutStaffInfo
        // 
        layoutStaffInfo.BackColor = Color.White;
        layoutStaffInfo.ColumnCount = 2;
        layoutStaffInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutStaffInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutStaffInfo.Controls.Add(lblStaffCaption, 0, 0);
        layoutStaffInfo.Controls.Add(lblStaffValue, 1, 0);
        layoutStaffInfo.Dock = DockStyle.Fill;
        layoutStaffInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutStaffInfo.Location = new Point(10, 44);
        layoutStaffInfo.Margin = new Padding(0);
        layoutStaffInfo.Name = "layoutStaffInfo";
        layoutStaffInfo.Padding = new Padding(2, 0, 2, 0);
        layoutStaffInfo.RowCount = 1;
        layoutStaffInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStaffInfo.Size = new Size(376, 33);
        layoutStaffInfo.TabIndex = 1;
        // 
        // lblStaffCaption
        // 
        lblStaffCaption.Dock = DockStyle.Fill;
        lblStaffCaption.Font = new Font("Segoe UI", 8.5F);
        lblStaffCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblStaffCaption.Location = new Point(2, 0);
        lblStaffCaption.Margin = new Padding(0);
        lblStaffCaption.Name = "lblStaffCaption";
        lblStaffCaption.Size = new Size(178, 33);
        lblStaffCaption.TabIndex = 0;
        lblStaffCaption.Text = "Nhân viên";
        lblStaffCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblStaffCaption.UseMnemonic = false;
        // 
        // lblStaffValue
        // 
        lblStaffValue.Dock = DockStyle.Fill;
        lblStaffValue.Font = new Font("Segoe UI", 8.5F);
        lblStaffValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblStaffValue.Location = new Point(180, 0);
        lblStaffValue.Margin = new Padding(0);
        lblStaffValue.Name = "lblStaffValue";
        lblStaffValue.Size = new Size(194, 33);
        lblStaffValue.TabIndex = 1;
        lblStaffValue.Text = "Nguyễn Minh Anh";
        lblStaffValue.TextAlign = ContentAlignment.MiddleLeft;
        lblStaffValue.UseMnemonic = false;
        // 
        // layoutTerminalInfo
        // 
        layoutTerminalInfo.BackColor = Color.White;
        layoutTerminalInfo.ColumnCount = 2;
        layoutTerminalInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutTerminalInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutTerminalInfo.Controls.Add(lblTerminalCaption, 0, 0);
        layoutTerminalInfo.Controls.Add(lblTerminalValue, 1, 0);
        layoutTerminalInfo.Dock = DockStyle.Fill;
        layoutTerminalInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTerminalInfo.Location = new Point(10, 77);
        layoutTerminalInfo.Margin = new Padding(0);
        layoutTerminalInfo.Name = "layoutTerminalInfo";
        layoutTerminalInfo.Padding = new Padding(2, 0, 2, 0);
        layoutTerminalInfo.RowCount = 1;
        layoutTerminalInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTerminalInfo.Size = new Size(376, 33);
        layoutTerminalInfo.TabIndex = 2;
        // 
        // lblTerminalCaption
        // 
        lblTerminalCaption.Dock = DockStyle.Fill;
        lblTerminalCaption.Font = new Font("Segoe UI", 8.5F);
        lblTerminalCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblTerminalCaption.Location = new Point(2, 0);
        lblTerminalCaption.Margin = new Padding(0);
        lblTerminalCaption.Name = "lblTerminalCaption";
        lblTerminalCaption.Size = new Size(178, 33);
        lblTerminalCaption.TabIndex = 0;
        lblTerminalCaption.Text = "Quầy";
        lblTerminalCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTerminalCaption.UseMnemonic = false;
        // 
        // lblTerminalValue
        // 
        lblTerminalValue.Dock = DockStyle.Fill;
        lblTerminalValue.Font = new Font("Segoe UI", 8.5F);
        lblTerminalValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblTerminalValue.Location = new Point(180, 0);
        lblTerminalValue.Margin = new Padding(0);
        lblTerminalValue.Name = "lblTerminalValue";
        lblTerminalValue.Size = new Size(194, 33);
        lblTerminalValue.TabIndex = 1;
        lblTerminalValue.Text = "POS-01";
        lblTerminalValue.TextAlign = ContentAlignment.MiddleLeft;
        lblTerminalValue.UseMnemonic = false;
        // 
        // layoutCreatedInfo
        // 
        layoutCreatedInfo.BackColor = Color.White;
        layoutCreatedInfo.ColumnCount = 2;
        layoutCreatedInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutCreatedInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutCreatedInfo.Controls.Add(lblCreatedCaption, 0, 0);
        layoutCreatedInfo.Controls.Add(lblCreatedValue, 1, 0);
        layoutCreatedInfo.Dock = DockStyle.Fill;
        layoutCreatedInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCreatedInfo.Location = new Point(10, 110);
        layoutCreatedInfo.Margin = new Padding(0);
        layoutCreatedInfo.Name = "layoutCreatedInfo";
        layoutCreatedInfo.Padding = new Padding(2, 0, 2, 0);
        layoutCreatedInfo.RowCount = 1;
        layoutCreatedInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCreatedInfo.Size = new Size(376, 33);
        layoutCreatedInfo.TabIndex = 3;
        // 
        // lblCreatedCaption
        // 
        lblCreatedCaption.Dock = DockStyle.Fill;
        lblCreatedCaption.Font = new Font("Segoe UI", 8.5F);
        lblCreatedCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblCreatedCaption.Location = new Point(2, 0);
        lblCreatedCaption.Margin = new Padding(0);
        lblCreatedCaption.Name = "lblCreatedCaption";
        lblCreatedCaption.Size = new Size(178, 33);
        lblCreatedCaption.TabIndex = 0;
        lblCreatedCaption.Text = "Thời gian lập";
        lblCreatedCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblCreatedCaption.UseMnemonic = false;
        // 
        // lblCreatedValue
        // 
        lblCreatedValue.Dock = DockStyle.Fill;
        lblCreatedValue.Font = new Font("Segoe UI", 8.5F);
        lblCreatedValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblCreatedValue.Location = new Point(180, 0);
        lblCreatedValue.Margin = new Padding(0);
        lblCreatedValue.Name = "lblCreatedValue";
        lblCreatedValue.Size = new Size(194, 33);
        lblCreatedValue.TabIndex = 1;
        lblCreatedValue.Text = "18:45 · 18/11/2026";
        lblCreatedValue.TextAlign = ContentAlignment.MiddleLeft;
        lblCreatedValue.UseMnemonic = false;
        // 
        // layoutCustomerInfo
        // 
        layoutCustomerInfo.BackColor = Color.White;
        layoutCustomerInfo.ColumnCount = 2;
        layoutCustomerInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutCustomerInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutCustomerInfo.Controls.Add(lblCustomerCaption, 0, 0);
        layoutCustomerInfo.Controls.Add(lblCustomerValue, 1, 0);
        layoutCustomerInfo.Dock = DockStyle.Fill;
        layoutCustomerInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutCustomerInfo.Location = new Point(10, 143);
        layoutCustomerInfo.Margin = new Padding(0);
        layoutCustomerInfo.Name = "layoutCustomerInfo";
        layoutCustomerInfo.Padding = new Padding(2, 0, 2, 0);
        layoutCustomerInfo.RowCount = 1;
        layoutCustomerInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCustomerInfo.Size = new Size(376, 46);
        layoutCustomerInfo.TabIndex = 4;
        // 
        // lblCustomerCaption
        // 
        lblCustomerCaption.Dock = DockStyle.Fill;
        lblCustomerCaption.Font = new Font("Segoe UI", 8.5F);
        lblCustomerCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblCustomerCaption.Location = new Point(2, 0);
        lblCustomerCaption.Margin = new Padding(0);
        lblCustomerCaption.Name = "lblCustomerCaption";
        lblCustomerCaption.Size = new Size(178, 46);
        lblCustomerCaption.TabIndex = 0;
        lblCustomerCaption.Text = "Thành viên";
        lblCustomerCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomerCaption.UseMnemonic = false;
        // 
        // lblCustomerValue
        // 
        lblCustomerValue.Dock = DockStyle.Fill;
        lblCustomerValue.Font = new Font("Segoe UI", 8.5F);
        lblCustomerValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblCustomerValue.Location = new Point(180, 0);
        lblCustomerValue.Margin = new Padding(0);
        lblCustomerValue.Name = "lblCustomerValue";
        lblCustomerValue.Size = new Size(194, 46);
        lblCustomerValue.TabIndex = 1;
        lblCustomerValue.Text = "Nguyễn Hoàng Nam\n0901234567";
        lblCustomerValue.TextAlign = ContentAlignment.MiddleLeft;
        lblCustomerValue.UseMnemonic = false;
        // 
        // pnlPayment
        // 
        pnlPayment.BackColor = Color.FromArgb(226, 232, 240);
        pnlPayment.Controls.Add(layoutPayment);
        pnlPayment.Dock = DockStyle.Fill;
        pnlPayment.Location = new Point(0, 208);
        pnlPayment.Margin = new Padding(0);
        pnlPayment.Name = "pnlPayment";
        pnlPayment.Padding = new Padding(1);
        pnlPayment.Size = new Size(398, 260);
        pnlPayment.TabIndex = 1;
        // 
        // layoutPayment
        // 
        layoutPayment.BackColor = Color.White;
        layoutPayment.ColumnCount = 1;
        layoutPayment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPayment.Controls.Add(lblPaymentTitle, 0, 0);
        layoutPayment.Controls.Add(layoutSubtotalInfo, 0, 1);
        layoutPayment.Controls.Add(layoutDiscountInfo, 0, 2);
        layoutPayment.Controls.Add(layoutTotalInfo, 0, 3);
        layoutPayment.Controls.Add(layoutMethodInfo, 0, 4);
        layoutPayment.Controls.Add(layoutTenderedInfo, 0, 5);
        layoutPayment.Controls.Add(layoutChangeInfo, 0, 6);
        layoutPayment.Dock = DockStyle.Fill;
        layoutPayment.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPayment.Location = new Point(1, 1);
        layoutPayment.Margin = new Padding(0);
        layoutPayment.Name = "layoutPayment";
        layoutPayment.Padding = new Padding(10, 7, 10, 7);
        layoutPayment.RowCount = 8;
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPayment.Size = new Size(396, 258);
        layoutPayment.TabIndex = 0;
        // 
        // lblPaymentTitle
        // 
        lblPaymentTitle.Dock = DockStyle.Fill;
        lblPaymentTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblPaymentTitle.Location = new Point(10, 7);
        lblPaymentTitle.Margin = new Padding(0);
        lblPaymentTitle.Name = "lblPaymentTitle";
        lblPaymentTitle.Size = new Size(376, 37);
        lblPaymentTitle.TabIndex = 0;
        lblPaymentTitle.Text = "Thanh toán";
        lblPaymentTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblPaymentTitle.UseMnemonic = false;
        // 
        // layoutSubtotalInfo
        // 
        layoutSubtotalInfo.BackColor = Color.White;
        layoutSubtotalInfo.ColumnCount = 2;
        layoutSubtotalInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutSubtotalInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutSubtotalInfo.Controls.Add(lblSubtotalCaption, 0, 0);
        layoutSubtotalInfo.Controls.Add(lblSubtotalValue, 1, 0);
        layoutSubtotalInfo.Dock = DockStyle.Fill;
        layoutSubtotalInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutSubtotalInfo.Location = new Point(10, 44);
        layoutSubtotalInfo.Margin = new Padding(0);
        layoutSubtotalInfo.Name = "layoutSubtotalInfo";
        layoutSubtotalInfo.Padding = new Padding(2, 0, 2, 0);
        layoutSubtotalInfo.RowCount = 1;
        layoutSubtotalInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSubtotalInfo.Size = new Size(376, 34);
        layoutSubtotalInfo.TabIndex = 1;
        // 
        // lblSubtotalCaption
        // 
        lblSubtotalCaption.Dock = DockStyle.Fill;
        lblSubtotalCaption.Font = new Font("Segoe UI", 8.5F);
        lblSubtotalCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtotalCaption.Location = new Point(2, 0);
        lblSubtotalCaption.Margin = new Padding(0);
        lblSubtotalCaption.Name = "lblSubtotalCaption";
        lblSubtotalCaption.Size = new Size(178, 34);
        lblSubtotalCaption.TabIndex = 0;
        lblSubtotalCaption.Text = "Tạm tính";
        lblSubtotalCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblSubtotalCaption.UseMnemonic = false;
        // 
        // lblSubtotalValue
        // 
        lblSubtotalValue.Dock = DockStyle.Fill;
        lblSubtotalValue.Font = new Font("Segoe UI", 8.5F);
        lblSubtotalValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblSubtotalValue.Location = new Point(180, 0);
        lblSubtotalValue.Margin = new Padding(0);
        lblSubtotalValue.Name = "lblSubtotalValue";
        lblSubtotalValue.Size = new Size(194, 34);
        lblSubtotalValue.TabIndex = 1;
        lblSubtotalValue.Text = "319.000 đ";
        lblSubtotalValue.TextAlign = ContentAlignment.MiddleRight;
        lblSubtotalValue.UseMnemonic = false;
        // 
        // layoutDiscountInfo
        // 
        layoutDiscountInfo.BackColor = Color.White;
        layoutDiscountInfo.ColumnCount = 2;
        layoutDiscountInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutDiscountInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutDiscountInfo.Controls.Add(lblDiscountCaption, 0, 0);
        layoutDiscountInfo.Controls.Add(lblDiscountValue, 1, 0);
        layoutDiscountInfo.Dock = DockStyle.Fill;
        layoutDiscountInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutDiscountInfo.Location = new Point(10, 78);
        layoutDiscountInfo.Margin = new Padding(0);
        layoutDiscountInfo.Name = "layoutDiscountInfo";
        layoutDiscountInfo.Padding = new Padding(2, 0, 2, 0);
        layoutDiscountInfo.RowCount = 1;
        layoutDiscountInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDiscountInfo.Size = new Size(376, 34);
        layoutDiscountInfo.TabIndex = 2;
        // 
        // lblDiscountCaption
        // 
        lblDiscountCaption.Dock = DockStyle.Fill;
        lblDiscountCaption.Font = new Font("Segoe UI", 8.5F);
        lblDiscountCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblDiscountCaption.Location = new Point(2, 0);
        lblDiscountCaption.Margin = new Padding(0);
        lblDiscountCaption.Name = "lblDiscountCaption";
        lblDiscountCaption.Size = new Size(178, 34);
        lblDiscountCaption.TabIndex = 0;
        lblDiscountCaption.Text = "Giảm giá";
        lblDiscountCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblDiscountCaption.UseMnemonic = false;
        // 
        // lblDiscountValue
        // 
        lblDiscountValue.Dock = DockStyle.Fill;
        lblDiscountValue.Font = new Font("Segoe UI", 8.5F);
        lblDiscountValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblDiscountValue.Location = new Point(180, 0);
        lblDiscountValue.Margin = new Padding(0);
        lblDiscountValue.Name = "lblDiscountValue";
        lblDiscountValue.Size = new Size(194, 34);
        lblDiscountValue.TabIndex = 1;
        lblDiscountValue.Text = "0 đ";
        lblDiscountValue.TextAlign = ContentAlignment.MiddleRight;
        lblDiscountValue.UseMnemonic = false;
        // 
        // layoutTotalInfo
        // 
        layoutTotalInfo.BackColor = Color.FromArgb(220, 252, 231);
        layoutTotalInfo.ColumnCount = 2;
        layoutTotalInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61F));
        layoutTotalInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39F));
        layoutTotalInfo.Controls.Add(lblTotalCaption, 0, 0);
        layoutTotalInfo.Controls.Add(lblTotalValue, 1, 0);
        layoutTotalInfo.Dock = DockStyle.Fill;
        layoutTotalInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTotalInfo.Location = new Point(10, 112);
        layoutTotalInfo.Margin = new Padding(0);
        layoutTotalInfo.Name = "layoutTotalInfo";
        layoutTotalInfo.Padding = new Padding(7, 0, 7, 0);
        layoutTotalInfo.RowCount = 1;
        layoutTotalInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTotalInfo.Size = new Size(376, 34);
        layoutTotalInfo.TabIndex = 3;
        // 
        // lblTotalCaption
        // 
        lblTotalCaption.Dock = DockStyle.Fill;
        lblTotalCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblTotalCaption.ForeColor = Color.FromArgb(22, 101, 52);
        lblTotalCaption.Location = new Point(7, 0);
        lblTotalCaption.Margin = new Padding(0);
        lblTotalCaption.Name = "lblTotalCaption";
        lblTotalCaption.Size = new Size(220, 34);
        lblTotalCaption.TabIndex = 0;
        lblTotalCaption.Text = "Tổng đã thanh toán";
        lblTotalCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTotalCaption.UseMnemonic = false;
        // 
        // lblTotalValue
        // 
        lblTotalValue.Dock = DockStyle.Fill;
        lblTotalValue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblTotalValue.ForeColor = Color.FromArgb(22, 101, 52);
        lblTotalValue.Location = new Point(227, 0);
        lblTotalValue.Margin = new Padding(0);
        lblTotalValue.Name = "lblTotalValue";
        lblTotalValue.Size = new Size(142, 34);
        lblTotalValue.TabIndex = 1;
        lblTotalValue.Text = "319.000 đ";
        lblTotalValue.TextAlign = ContentAlignment.MiddleRight;
        lblTotalValue.UseMnemonic = false;
        // 
        // layoutMethodInfo
        // 
        layoutMethodInfo.BackColor = Color.White;
        layoutMethodInfo.ColumnCount = 2;
        layoutMethodInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61F));
        layoutMethodInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39F));
        layoutMethodInfo.Controls.Add(lblMethodCaption, 0, 0);
        layoutMethodInfo.Controls.Add(lblMethodValue, 1, 0);
        layoutMethodInfo.Dock = DockStyle.Fill;
        layoutMethodInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutMethodInfo.Location = new Point(10, 146);
        layoutMethodInfo.Margin = new Padding(0);
        layoutMethodInfo.Name = "layoutMethodInfo";
        layoutMethodInfo.Padding = new Padding(2, 0, 2, 0);
        layoutMethodInfo.RowCount = 1;
        layoutMethodInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMethodInfo.Size = new Size(376, 34);
        layoutMethodInfo.TabIndex = 4;
        // 
        // lblMethodCaption
        // 
        lblMethodCaption.Dock = DockStyle.Fill;
        lblMethodCaption.Font = new Font("Segoe UI", 8.5F);
        lblMethodCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblMethodCaption.Location = new Point(2, 0);
        lblMethodCaption.Margin = new Padding(0);
        lblMethodCaption.Name = "lblMethodCaption";
        lblMethodCaption.Size = new Size(226, 34);
        lblMethodCaption.TabIndex = 0;
        lblMethodCaption.Text = "Phương thức thanh toán";
        lblMethodCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblMethodCaption.UseMnemonic = false;
        // 
        // lblMethodValue
        // 
        lblMethodValue.Dock = DockStyle.Fill;
        lblMethodValue.Font = new Font("Segoe UI", 8.5F);
        lblMethodValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblMethodValue.Location = new Point(228, 0);
        lblMethodValue.Margin = new Padding(0);
        lblMethodValue.Name = "lblMethodValue";
        lblMethodValue.Size = new Size(146, 34);
        lblMethodValue.TabIndex = 1;
        lblMethodValue.Text = "Tiền mặt";
        lblMethodValue.TextAlign = ContentAlignment.MiddleRight;
        lblMethodValue.UseMnemonic = false;
        // 
        // layoutTenderedInfo
        // 
        layoutTenderedInfo.BackColor = Color.White;
        layoutTenderedInfo.ColumnCount = 2;
        layoutTenderedInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutTenderedInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutTenderedInfo.Controls.Add(lblTenderedCaption, 0, 0);
        layoutTenderedInfo.Controls.Add(lblTenderedValue, 1, 0);
        layoutTenderedInfo.Dock = DockStyle.Fill;
        layoutTenderedInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutTenderedInfo.Location = new Point(10, 180);
        layoutTenderedInfo.Margin = new Padding(0);
        layoutTenderedInfo.Name = "layoutTenderedInfo";
        layoutTenderedInfo.Padding = new Padding(2, 0, 2, 0);
        layoutTenderedInfo.RowCount = 1;
        layoutTenderedInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTenderedInfo.Size = new Size(376, 34);
        layoutTenderedInfo.TabIndex = 5;
        // 
        // lblTenderedCaption
        // 
        lblTenderedCaption.Dock = DockStyle.Fill;
        lblTenderedCaption.Font = new Font("Segoe UI", 8.5F);
        lblTenderedCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblTenderedCaption.Location = new Point(2, 0);
        lblTenderedCaption.Margin = new Padding(0);
        lblTenderedCaption.Name = "lblTenderedCaption";
        lblTenderedCaption.Size = new Size(178, 34);
        lblTenderedCaption.TabIndex = 0;
        lblTenderedCaption.Text = "Tiền khách đưa";
        lblTenderedCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTenderedCaption.UseMnemonic = false;
        // 
        // lblTenderedValue
        // 
        lblTenderedValue.Dock = DockStyle.Fill;
        lblTenderedValue.Font = new Font("Segoe UI", 8.5F);
        lblTenderedValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblTenderedValue.Location = new Point(180, 0);
        lblTenderedValue.Margin = new Padding(0);
        lblTenderedValue.Name = "lblTenderedValue";
        lblTenderedValue.Size = new Size(194, 34);
        lblTenderedValue.TabIndex = 1;
        lblTenderedValue.Text = "350.000 đ";
        lblTenderedValue.TextAlign = ContentAlignment.MiddleRight;
        lblTenderedValue.UseMnemonic = false;
        // 
        // layoutChangeInfo
        // 
        layoutChangeInfo.BackColor = Color.White;
        layoutChangeInfo.ColumnCount = 2;
        layoutChangeInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutChangeInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutChangeInfo.Controls.Add(lblChangeCaption, 0, 0);
        layoutChangeInfo.Controls.Add(lblChangeValue, 1, 0);
        layoutChangeInfo.Dock = DockStyle.Fill;
        layoutChangeInfo.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutChangeInfo.Location = new Point(10, 214);
        layoutChangeInfo.Margin = new Padding(0);
        layoutChangeInfo.Name = "layoutChangeInfo";
        layoutChangeInfo.Padding = new Padding(2, 0, 2, 0);
        layoutChangeInfo.RowCount = 1;
        layoutChangeInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutChangeInfo.Size = new Size(376, 34);
        layoutChangeInfo.TabIndex = 6;
        // 
        // lblChangeCaption
        // 
        lblChangeCaption.Dock = DockStyle.Fill;
        lblChangeCaption.Font = new Font("Segoe UI", 8.5F);
        lblChangeCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblChangeCaption.Location = new Point(2, 0);
        lblChangeCaption.Margin = new Padding(0);
        lblChangeCaption.Name = "lblChangeCaption";
        lblChangeCaption.Size = new Size(178, 34);
        lblChangeCaption.TabIndex = 0;
        lblChangeCaption.Text = "Tiền thối lại";
        lblChangeCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblChangeCaption.UseMnemonic = false;
        // 
        // lblChangeValue
        // 
        lblChangeValue.Dock = DockStyle.Fill;
        lblChangeValue.Font = new Font("Segoe UI", 8.5F);
        lblChangeValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblChangeValue.Location = new Point(180, 0);
        lblChangeValue.Margin = new Padding(0);
        lblChangeValue.Name = "lblChangeValue";
        lblChangeValue.Size = new Size(194, 34);
        lblChangeValue.TabIndex = 1;
        lblChangeValue.Text = "31.000 đ";
        lblChangeValue.TextAlign = ContentAlignment.MiddleRight;
        lblChangeValue.UseMnemonic = false;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.FromArgb(226, 232, 240);
        pnlFooter.Controls.Add(layoutFooter);
        pnlFooter.Dock = DockStyle.Fill;
        pnlFooter.Location = new Point(16, 568);
        pnlFooter.Margin = new Padding(0);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(1);
        pnlFooter.Size = new Size(1104, 85);
        pnlFooter.TabIndex = 3;
        // 
        // layoutFooter
        // 
        layoutFooter.BackColor = Color.White;
        layoutFooter.ColumnCount = 4;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 253F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 326F));
        layoutFooter.Controls.Add(btnPrintTickets, 0, 0);
        layoutFooter.Controls.Add(btnPrintInvoice, 1, 0);
        layoutFooter.Controls.Add(btnRefund, 3, 0);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Location = new Point(1, 1);
        layoutFooter.Margin = new Padding(0);
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Padding = new Padding(10, 6, 10, 6);
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutFooter.Size = new Size(1102, 83);
        layoutFooter.TabIndex = 0;
        // 
        // btnPrintTickets
        // 
        btnPrintTickets.BackColor = Color.White;
        btnPrintTickets.Dock = DockStyle.Fill;
        btnPrintTickets.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnPrintTickets.FlatStyle = FlatStyle.Flat;
        btnPrintTickets.Font = new Font("Segoe UI", 9.5F);
        btnPrintTickets.ForeColor = Color.FromArgb(37, 99, 235);
        btnPrintTickets.Location = new Point(10, 6);
        btnPrintTickets.Margin = new Padding(0, 0, 9, 0);
        btnPrintTickets.Name = "btnPrintTickets";
        btnPrintTickets.Size = new Size(141, 71);
        btnPrintTickets.TabIndex = 0;
        btnPrintTickets.Text = "In lại vé xem phim";
        btnPrintTickets.UseMnemonic = false;
        btnPrintTickets.UseVisualStyleBackColor = false;
        // 
        // btnPrintInvoice
        // 
        btnPrintInvoice.BackColor = Color.White;
        btnPrintInvoice.Dock = DockStyle.Fill;
        btnPrintInvoice.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnPrintInvoice.FlatStyle = FlatStyle.Flat;
        btnPrintInvoice.Font = new Font("Segoe UI", 9.5F);
        btnPrintInvoice.ForeColor = Color.FromArgb(37, 99, 235);
        btnPrintInvoice.Location = new Point(160, 6);
        btnPrintInvoice.Margin = new Padding(0, 0, 9, 0);
        btnPrintInvoice.Name = "btnPrintInvoice";
        btnPrintInvoice.Size = new Size(244, 71);
        btnPrintInvoice.TabIndex = 1;
        btnPrintInvoice.Text = "In lại hóa đơn bán lẻ ";
        btnPrintInvoice.UseMnemonic = false;
        btnPrintInvoice.UseVisualStyleBackColor = false;
        // 
        // btnRefund
        // 
        btnRefund.BackColor = Color.FromArgb(185, 28, 28);
        btnRefund.Dock = DockStyle.Fill;
        btnRefund.FlatAppearance.BorderSize = 0;
        btnRefund.FlatStyle = FlatStyle.Flat;
        btnRefund.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnRefund.ForeColor = Color.White;
        btnRefund.Location = new Point(766, 6);
        btnRefund.Margin = new Padding(0);
        btnRefund.Name = "btnRefund";
        btnRefund.Size = new Size(326, 71);
        btnRefund.TabIndex = 2;
        btnRefund.Text = "Yêu cầu hủy vé / hoàn tiền  ›";
        btnRefund.UseMnemonic = false;
        btnRefund.UseVisualStyleBackColor = false;
        btnRefund.Click += BtnRefund_Click;
        // 
        // OrderDetailsView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "OrderDetailsView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        layoutPage.PerformLayout();
        layoutTitle.ResumeLayout(false);
        layoutTitle.PerformLayout();
        layoutBody.ResumeLayout(false);
        layoutItems.ResumeLayout(false);
        pnlTickets.ResumeLayout(false);
        layoutTickets.ResumeLayout(false);
        pnlTicketContent.ResumeLayout(false);
        pnlTicketGrid.ResumeLayout(false);
        layoutTicketGrid.ResumeLayout(false);
        layoutTicketGridState1.ResumeLayout(false);
        layoutTicketGridState2.ResumeLayout(false);
        pnlConcessions.ResumeLayout(false);
        layoutConcessions.ResumeLayout(false);
        pnlConcessionContent.ResumeLayout(false);
        pnlConcessionGrid.ResumeLayout(false);
        layoutConcessionGrid.ResumeLayout(false);
        layoutConcessionGridState1.ResumeLayout(false);
        layoutShowtimeNote.ResumeLayout(false);
        layoutSummary.ResumeLayout(false);
        pnlGeneral.ResumeLayout(false);
        layoutGeneral.ResumeLayout(false);
        layoutStaffInfo.ResumeLayout(false);
        layoutTerminalInfo.ResumeLayout(false);
        layoutCreatedInfo.ResumeLayout(false);
        layoutCustomerInfo.ResumeLayout(false);
        pnlPayment.ResumeLayout(false);
        layoutPayment.ResumeLayout(false);
        layoutSubtotalInfo.ResumeLayout(false);
        layoutDiscountInfo.ResumeLayout(false);
        layoutTotalInfo.ResumeLayout(false);
        layoutMethodInfo.ResumeLayout(false);
        layoutTenderedInfo.ResumeLayout(false);
        layoutChangeInfo.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        layoutFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private LinkLabel lnkBack;
    private TableLayoutPanel layoutTitle;
    private Label lblTitle;
    private Label lblStatus;
    private TableLayoutPanel layoutBody;
    private TableLayoutPanel layoutItems;
    private Panel pnlTickets;
    private TableLayoutPanel layoutTickets;
    private Label lblTicketsTitle;
    private Panel pnlTicketGrid;
    private TableLayoutPanel layoutTicketGrid;
    private Label lblTicketGridMovieHeader;
    private Label lblTicketGridMovie1;
    private Label lblTicketGridMovie2;
    private Label lblTicketGridRoomHeader;
    private Label lblTicketGridRoom1;
    private Label lblTicketGridRoom2;
    private Label lblTicketGridShowtimeHeader;
    private Label lblTicketGridShowtime1;
    private Label lblTicketGridShowtime2;
    private Label lblTicketGridSeatHeader;
    private Label lblTicketGridSeat1;
    private Label lblTicketGridSeat2;
    private Label lblTicketGridTypeHeader;
    private Label lblTicketGridType1;
    private Label lblTicketGridType2;
    private Label lblTicketGridPriceHeader;
    private Label lblTicketGridPrice1;
    private Label lblTicketGridPrice2;
    private Label lblTicketGridStateHeader;
    private TableLayoutPanel layoutTicketGridState1;
    private Label lblTicketGridState1;
    private TableLayoutPanel layoutTicketGridState2;
    private Label lblTicketGridState2;
    private Label lblTicketSummary;
    private Panel pnlTicketContent;
    private Panel pnlConcessions;
    private TableLayoutPanel layoutConcessions;
    private Label lblConcessionsTitle;
    private Panel pnlConcessionGrid;
    private TableLayoutPanel layoutConcessionGrid;
    private Label lblConcessionGridItemHeader;
    private Label lblConcessionGridItem1;
    private Label lblConcessionGridQtyHeader;
    private Label lblConcessionGridQty1;
    private Label lblConcessionGridPriceHeader;
    private Label lblConcessionGridPrice1;
    private Label lblConcessionGridTotalHeader;
    private Label lblConcessionGridTotal1;
    private Label lblConcessionGridStateHeader;
    private TableLayoutPanel layoutConcessionGridState1;
    private Label lblConcessionGridState1;
    private Label lblConcessionSummary;
    private Panel pnlConcessionContent;
    private TableLayoutPanel layoutShowtimeNote;
    private Label lblClockIcon;
    private Label lblShowtimeNote;
    private Label lblTimeRemaining;
    private TableLayoutPanel layoutSummary;
    private Panel pnlGeneral;
    private TableLayoutPanel layoutGeneral;
    private Label lblGeneralTitle;
    private TableLayoutPanel layoutStaffInfo;
    private Label lblStaffCaption;
    private Label lblStaffValue;
    private TableLayoutPanel layoutTerminalInfo;
    private Label lblTerminalCaption;
    private Label lblTerminalValue;
    private TableLayoutPanel layoutCreatedInfo;
    private Label lblCreatedCaption;
    private Label lblCreatedValue;
    private TableLayoutPanel layoutCustomerInfo;
    private Label lblCustomerCaption;
    private Label lblCustomerValue;
    private Panel pnlPayment;
    private TableLayoutPanel layoutPayment;
    private Label lblPaymentTitle;
    private TableLayoutPanel layoutSubtotalInfo;
    private Label lblSubtotalCaption;
    private Label lblSubtotalValue;
    private TableLayoutPanel layoutDiscountInfo;
    private Label lblDiscountCaption;
    private Label lblDiscountValue;
    private TableLayoutPanel layoutTotalInfo;
    private Label lblTotalCaption;
    private Label lblTotalValue;
    private TableLayoutPanel layoutMethodInfo;
    private Label lblMethodCaption;
    private Label lblMethodValue;
    private TableLayoutPanel layoutTenderedInfo;
    private Label lblTenderedCaption;
    private Label lblTenderedValue;
    private TableLayoutPanel layoutChangeInfo;
    private Label lblChangeCaption;
    private Label lblChangeValue;
    private Panel pnlFooter;
    private TableLayoutPanel layoutFooter;
    private Button btnPrintTickets;
    private Button btnPrintInvoice;
    private Button btnRefund;
}

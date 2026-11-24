namespace Cinema.WinForms.Features.TicketSales;

partial class ConcessionSelectionView
{
    private System.ComponentModel.IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        layoutPage = new TableLayoutPanel();
        progressBar = new Cinema.WinForms.Controls.TicketSalesProgressBar();
        layoutWorkArea = new TableLayoutPanel();
        layoutCatalog = new TableLayoutPanel();
        layoutHeading = new TableLayoutPanel();
        lblTitle = new Label();
        lblCountdown = new Label();
        flowCategories = new FlowLayoutPanel();
        btnAll = new Button();
        btnCombo = new Button();
        btnPopcorn = new Button();
        btnDrink = new Button();
        btnSnack = new Button();
        pnlProductScroll = new Panel();
        gridProducts = new TableLayoutPanel();
        lblEmptyCatalog = new Label();
        pnlSummary = new Panel();
        layoutSummary = new TableLayoutPanel();
        lblSummary = new Label();
        layoutMovie = new TableLayoutPanel();
        picMovie = new PictureBox();
        layoutMovieDetails = new TableLayoutPanel();
        lblMovie = new Label();
        lblShowtime = new Label();
        lblRoom = new Label();
        lblSeats = new Label();
        layoutTicketRow = new TableLayoutPanel();
        lblTicketCount = new Label();
        lblTicketAmount = new Label();
        pnlOrderScroll = new Panel();
        orderItems = new TableLayoutPanel();
        layoutTotal = new TableLayoutPanel();
        lblTotalCaption = new Label();
        lblTotal = new Label();
        lblNotice = new Label();
        layoutButtons = new TableLayoutPanel();
        btnBack = new Button();
        btnContinue = new Button();
        layoutPage.SuspendLayout();
        layoutWorkArea.SuspendLayout();
        layoutCatalog.SuspendLayout();
        layoutHeading.SuspendLayout();
        flowCategories.SuspendLayout();
        pnlProductScroll.SuspendLayout();
        pnlSummary.SuspendLayout();
        layoutSummary.SuspendLayout();
        layoutMovie.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picMovie).BeginInit();
        layoutMovieDetails.SuspendLayout();
        layoutTicketRow.SuspendLayout();
        pnlOrderScroll.SuspendLayout();
        layoutTotal.SuspendLayout();
        layoutButtons.SuspendLayout();
        SuspendLayout();
        // 
        // layoutPage
        // 
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.Controls.Add(progressBar, 0, 0);
        layoutPage.Controls.Add(layoutWorkArea, 0, 1);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(22, 15, 22, 20);
        layoutPage.RowCount = 2;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1400, 825);
        layoutPage.TabIndex = 0;
        // 
        // progressBar
        // 
        progressBar.ActiveStep = 3;
        progressBar.Dock = DockStyle.Fill;
        progressBar.Location = new Point(22, 15);
        progressBar.Margin = new Padding(0);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(1356, 50);
        progressBar.TabIndex = 0;
        progressBar.TabStop = false;
        // 
        // layoutWorkArea
        // 
        layoutWorkArea.ColumnCount = 2;
        layoutWorkArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutWorkArea.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 506F));
        layoutWorkArea.Controls.Add(layoutCatalog, 0, 0);
        layoutWorkArea.Controls.Add(pnlSummary, 1, 0);
        layoutWorkArea.Dock = DockStyle.Fill;
        layoutWorkArea.Location = new Point(22, 77);
        layoutWorkArea.Margin = new Padding(0, 12, 0, 0);
        layoutWorkArea.Name = "layoutWorkArea";
        layoutWorkArea.RowCount = 1;
        layoutWorkArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutWorkArea.Size = new Size(1356, 728);
        layoutWorkArea.TabIndex = 1;
        // 
        // layoutCatalog
        // 
        layoutCatalog.ColumnCount = 1;
        layoutCatalog.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutCatalog.Controls.Add(layoutHeading, 0, 0);
        layoutCatalog.Controls.Add(flowCategories, 0, 1);
        layoutCatalog.Controls.Add(pnlProductScroll, 0, 2);
        layoutCatalog.Dock = DockStyle.Fill;
        layoutCatalog.Location = new Point(0, 0);
        layoutCatalog.Margin = new Padding(0, 0, 12, 0);
        layoutCatalog.Name = "layoutCatalog";
        layoutCatalog.RowCount = 3;
        layoutCatalog.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutCatalog.RowStyles.Add(new RowStyle());
        layoutCatalog.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCatalog.Size = new Size(838, 728);
        layoutCatalog.TabIndex = 0;
        // 
        // layoutHeading
        // 
        layoutHeading.ColumnCount = 2;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblCountdown, 1, 0);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.Location = new Point(0, 0);
        layoutHeading.Margin = new Padding(0);
        layoutHeading.Name = "layoutHeading";
        layoutHeading.RowCount = 2;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
        layoutHeading.Size = new Size(838, 60);
        layoutHeading.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(757, 60);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "CHỌN BẮP NƯỚC & COMBO";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // lblCountdown
        // 
        lblCountdown.AccessibleName = "Thời gian giữ ghế";
        lblCountdown.BackColor = Color.FromArgb(219, 234, 254);
        lblCountdown.Dock = DockStyle.Fill;
        lblCountdown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblCountdown.ForeColor = Color.FromArgb(30, 64, 175);
        lblCountdown.Location = new Point(757, 11);
        lblCountdown.Margin = new Padding(0, 11, 0, 11);
        lblCountdown.Name = "lblCountdown";
        lblCountdown.Size = new Size(81, 38);
        lblCountdown.TabIndex = 1;
        lblCountdown.Text = "—";
        lblCountdown.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // flowCategories
        // 
        flowCategories.AutoSize = true;
        flowCategories.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowCategories.Controls.Add(btnAll);
        flowCategories.Controls.Add(btnCombo);
        flowCategories.Controls.Add(btnPopcorn);
        flowCategories.Controls.Add(btnDrink);
        flowCategories.Controls.Add(btnSnack);
        flowCategories.Dock = DockStyle.Top;
        flowCategories.Location = new Point(0, 60);
        flowCategories.Margin = new Padding(0, 0, 0, 10);
        flowCategories.Name = "flowCategories";
        flowCategories.Size = new Size(838, 45);
        flowCategories.TabIndex = 1;
        // 
        // btnAll
        // 
        btnAll.AutoSize = true;
        btnAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnAll.BackColor = Color.FromArgb(37, 99, 235);
        btnAll.Cursor = Cursors.Hand;
        btnAll.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
        btnAll.FlatStyle = FlatStyle.Flat;
        btnAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAll.ForeColor = Color.White;
        btnAll.Location = new Point(0, 0);
        btnAll.Margin = new Padding(0, 0, 5, 5);
        btnAll.MinimumSize = new Size(55, 40);
        btnAll.Name = "btnAll";
        btnAll.Padding = new Padding(5, 0, 5, 0);
        btnAll.Size = new Size(73, 40);
        btnAll.TabIndex = 0;
        btnAll.Text = "Tất cả";
        btnAll.UseVisualStyleBackColor = false;
        // 
        // btnCombo
        // 
        btnCombo.AutoSize = true;
        btnCombo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnCombo.BackColor = Color.White;
        btnCombo.Cursor = Cursors.Hand;
        btnCombo.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnCombo.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
        btnCombo.FlatStyle = FlatStyle.Flat;
        btnCombo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCombo.ForeColor = Color.FromArgb(15, 23, 42);
        btnCombo.Location = new Point(78, 0);
        btnCombo.Margin = new Padding(0, 0, 5, 5);
        btnCombo.MinimumSize = new Size(55, 40);
        btnCombo.Name = "btnCombo";
        btnCombo.Padding = new Padding(5, 0, 5, 0);
        btnCombo.Size = new Size(147, 40);
        btnCombo.TabIndex = 1;
        btnCombo.Text = "Combo tiết kiệm";
        btnCombo.UseVisualStyleBackColor = false;
        // 
        // btnPopcorn
        // 
        btnPopcorn.AutoSize = true;
        btnPopcorn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnPopcorn.BackColor = Color.White;
        btnPopcorn.Cursor = Cursors.Hand;
        btnPopcorn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnPopcorn.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
        btnPopcorn.FlatStyle = FlatStyle.Flat;
        btnPopcorn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnPopcorn.ForeColor = Color.FromArgb(15, 23, 42);
        btnPopcorn.Location = new Point(230, 0);
        btnPopcorn.Margin = new Padding(0, 0, 5, 5);
        btnPopcorn.MinimumSize = new Size(55, 40);
        btnPopcorn.Name = "btnPopcorn";
        btnPopcorn.Padding = new Padding(5, 0, 5, 0);
        btnPopcorn.Size = new Size(94, 40);
        btnPopcorn.TabIndex = 2;
        btnPopcorn.Text = "Bắp rang";
        btnPopcorn.UseVisualStyleBackColor = false;
        // 
        // btnDrink
        // 
        btnDrink.AutoSize = true;
        btnDrink.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDrink.BackColor = Color.White;
        btnDrink.Cursor = Cursors.Hand;
        btnDrink.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnDrink.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
        btnDrink.FlatStyle = FlatStyle.Flat;
        btnDrink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDrink.ForeColor = Color.FromArgb(15, 23, 42);
        btnDrink.Location = new Point(329, 0);
        btnDrink.Margin = new Padding(0, 0, 5, 5);
        btnDrink.MinimumSize = new Size(55, 40);
        btnDrink.Name = "btnDrink";
        btnDrink.Padding = new Padding(5, 0, 5, 0);
        btnDrink.Size = new Size(106, 40);
        btnDrink.TabIndex = 3;
        btnDrink.Text = "Nước ngọt";
        btnDrink.UseVisualStyleBackColor = false;
        // 
        // btnSnack
        // 
        btnSnack.AutoSize = true;
        btnSnack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSnack.BackColor = Color.White;
        btnSnack.Cursor = Cursors.Hand;
        btnSnack.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnSnack.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
        btnSnack.FlatStyle = FlatStyle.Flat;
        btnSnack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSnack.ForeColor = Color.FromArgb(15, 23, 42);
        btnSnack.Location = new Point(440, 0);
        btnSnack.Margin = new Padding(0, 0, 5, 5);
        btnSnack.MinimumSize = new Size(55, 40);
        btnSnack.Name = "btnSnack";
        btnSnack.Padding = new Padding(5, 0, 5, 0);
        btnSnack.Size = new Size(102, 40);
        btnSnack.TabIndex = 4;
        btnSnack.Text = "Đồ ăn nhẹ";
        btnSnack.UseVisualStyleBackColor = false;
        // 
        // pnlProductScroll
        // 
        pnlProductScroll.AutoScroll = true;
        pnlProductScroll.Controls.Add(gridProducts);
        pnlProductScroll.Controls.Add(lblEmptyCatalog);
        pnlProductScroll.Dock = DockStyle.Fill;
        pnlProductScroll.Location = new Point(0, 115);
        pnlProductScroll.Margin = new Padding(0);
        pnlProductScroll.Name = "pnlProductScroll";
        pnlProductScroll.Size = new Size(838, 613);
        pnlProductScroll.TabIndex = 2;
        // 
        // gridProducts
        // 
        gridProducts.ColumnCount = 3;
        gridProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        gridProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        gridProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        gridProducts.Dock = DockStyle.Top;
        gridProducts.Location = new Point(0, 0);
        gridProducts.Margin = new Padding(0);
        gridProducts.Name = "gridProducts";
        gridProducts.RowCount = 2;
        gridProducts.RowStyles.Add(new RowStyle(SizeType.Absolute, 218F));
        gridProducts.RowStyles.Add(new RowStyle(SizeType.Absolute, 218F));
        gridProducts.Size = new Size(838, 435);
        gridProducts.TabIndex = 0;
        gridProducts.Visible = false;
        // 
        // lblEmptyCatalog
        // 
        lblEmptyCatalog.Dock = DockStyle.Top;
        lblEmptyCatalog.Font = new Font("Segoe UI", 11F);
        lblEmptyCatalog.ForeColor = Color.FromArgb(100, 116, 139);
        lblEmptyCatalog.Name = "lblEmptyCatalog";
        lblEmptyCatalog.Size = new Size(838, 120);
        lblEmptyCatalog.TabIndex = 1;
        lblEmptyCatalog.Text = "Chưa có bắp nước và combo";
        lblEmptyCatalog.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlSummary
        // 
        pnlSummary.BackColor = Color.FromArgb(226, 232, 240);
        pnlSummary.Controls.Add(layoutSummary);
        pnlSummary.Dock = DockStyle.Fill;
        pnlSummary.Location = new Point(850, 0);
        pnlSummary.Margin = new Padding(0);
        pnlSummary.Name = "pnlSummary";
        pnlSummary.Padding = new Padding(1);
        pnlSummary.Size = new Size(506, 728);
        pnlSummary.TabIndex = 1;
        // 
        // layoutSummary
        // 
        layoutSummary.BackColor = Color.White;
        layoutSummary.ColumnCount = 1;
        layoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutSummary.Controls.Add(lblSummary, 0, 0);
        layoutSummary.Controls.Add(layoutMovie, 0, 1);
        layoutSummary.Controls.Add(layoutTicketRow, 0, 2);
        layoutSummary.Controls.Add(pnlOrderScroll, 0, 3);
        layoutSummary.Controls.Add(layoutTotal, 0, 4);
        layoutSummary.Controls.Add(lblNotice, 0, 6);
        layoutSummary.Controls.Add(layoutButtons, 0, 7);
        layoutSummary.Dock = DockStyle.Fill;
        layoutSummary.Location = new Point(1, 1);
        layoutSummary.Margin = new Padding(0);
        layoutSummary.Name = "layoutSummary";
        layoutSummary.Padding = new Padding(14, 14, 14, 14);
        layoutSummary.RowCount = 9;
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 125F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutSummary.RowStyles.Add(new RowStyle());
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        layoutSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        layoutSummary.Size = new Size(504, 726);
        layoutSummary.TabIndex = 0;
        // 
        // lblSummary
        // 
        lblSummary.Dock = DockStyle.Fill;
        lblSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblSummary.Location = new Point(14, 14);
        lblSummary.Margin = new Padding(0);
        lblSummary.Name = "lblSummary";
        lblSummary.Size = new Size(476, 42);
        lblSummary.TabIndex = 0;
        lblSummary.Text = "TÓM TẮT ĐƠN HÀNG";
        lblSummary.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // layoutMovie
        // 
        layoutMovie.BackColor = Color.FromArgb(248, 250, 252);
        layoutMovie.ColumnCount = 2;
        layoutMovie.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layoutMovie.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMovie.Controls.Add(picMovie, 0, 0);
        layoutMovie.Controls.Add(layoutMovieDetails, 1, 0);
        layoutMovie.Dock = DockStyle.Fill;
        layoutMovie.Location = new Point(14, 56);
        layoutMovie.Margin = new Padding(0, 0, 0, 6);
        layoutMovie.Name = "layoutMovie";
        layoutMovie.Padding = new Padding(9, 9, 9, 9);
        layoutMovie.RowCount = 1;
        layoutMovie.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMovie.Size = new Size(476, 119);
        layoutMovie.TabIndex = 1;
        // 
        // picMovie
        // 
        picMovie.BackColor = Color.FromArgb(241, 245, 249);
        picMovie.Dock = DockStyle.Fill;
        picMovie.Location = new Point(9, 9);
        picMovie.Margin = new Padding(0, 0, 9, 0);
        picMovie.Name = "picMovie";
        picMovie.Size = new Size(71, 101);
        picMovie.SizeMode = PictureBoxSizeMode.Zoom;
        picMovie.TabIndex = 0;
        picMovie.TabStop = false;
        // 
        // layoutMovieDetails
        // 
        layoutMovieDetails.ColumnCount = 1;
        layoutMovieDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMovieDetails.Controls.Add(lblMovie, 0, 0);
        layoutMovieDetails.Controls.Add(lblShowtime, 0, 1);
        layoutMovieDetails.Controls.Add(lblRoom, 0, 2);
        layoutMovieDetails.Controls.Add(lblSeats, 0, 3);
        layoutMovieDetails.Dock = DockStyle.Fill;
        layoutMovieDetails.Location = new Point(89, 9);
        layoutMovieDetails.Margin = new Padding(0);
        layoutMovieDetails.Name = "layoutMovieDetails";
        layoutMovieDetails.RowCount = 4;
        layoutMovieDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
        layoutMovieDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layoutMovieDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layoutMovieDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMovieDetails.Size = new Size(378, 101);
        layoutMovieDetails.TabIndex = 1;
        // 
        // lblMovie
        // 
        lblMovie.AutoEllipsis = true;
        lblMovie.Dock = DockStyle.Fill;
        lblMovie.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMovie.Location = new Point(0, 0);
        lblMovie.Margin = new Padding(0);
        lblMovie.Name = "lblMovie";
        lblMovie.Size = new Size(378, 29);
        lblMovie.TabIndex = 0;
        lblMovie.TextAlign = ContentAlignment.MiddleLeft;
        lblMovie.UseMnemonic = false;
        // 
        // lblShowtime
        // 
        lblShowtime.AutoEllipsis = true;
        lblShowtime.Dock = DockStyle.Fill;
        lblShowtime.ForeColor = Color.FromArgb(71, 85, 105);
        lblShowtime.Location = new Point(0, 29);
        lblShowtime.Margin = new Padding(0);
        lblShowtime.Name = "lblShowtime";
        lblShowtime.Size = new Size(378, 24);
        lblShowtime.TabIndex = 1;
        lblShowtime.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblRoom
        // 
        lblRoom.AutoEllipsis = true;
        lblRoom.Dock = DockStyle.Fill;
        lblRoom.ForeColor = Color.FromArgb(71, 85, 105);
        lblRoom.Location = new Point(0, 53);
        lblRoom.Margin = new Padding(0);
        lblRoom.Name = "lblRoom";
        lblRoom.Size = new Size(378, 24);
        lblRoom.TabIndex = 2;
        lblRoom.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblSeats
        // 
        lblSeats.AutoEllipsis = true;
        lblSeats.Dock = DockStyle.Fill;
        lblSeats.ForeColor = Color.FromArgb(71, 85, 105);
        lblSeats.Location = new Point(0, 77);
        lblSeats.Margin = new Padding(0);
        lblSeats.Name = "lblSeats";
        lblSeats.Size = new Size(378, 24);
        lblSeats.TabIndex = 3;
        // 
        // layoutTicketRow
        // 
        layoutTicketRow.BackColor = Color.FromArgb(248, 250, 252);
        layoutTicketRow.ColumnCount = 2;
        layoutTicketRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56F));
        layoutTicketRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
        layoutTicketRow.Controls.Add(lblTicketCount, 0, 0);
        layoutTicketRow.Controls.Add(lblTicketAmount, 1, 0);
        layoutTicketRow.Dock = DockStyle.Fill;
        layoutTicketRow.Location = new Point(14, 181);
        layoutTicketRow.Margin = new Padding(0, 0, 0, 5);
        layoutTicketRow.Name = "layoutTicketRow";
        layoutTicketRow.Padding = new Padding(9, 0, 9, 0);
        layoutTicketRow.RowCount = 1;
        layoutTicketRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTicketRow.Size = new Size(476, 43);
        layoutTicketRow.TabIndex = 2;
        // 
        // lblTicketCount
        // 
        lblTicketCount.Dock = DockStyle.Fill;
        lblTicketCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTicketCount.Location = new Point(9, 0);
        lblTicketCount.Margin = new Padding(0);
        lblTicketCount.Name = "lblTicketCount";
        lblTicketCount.Size = new Size(256, 43);
        lblTicketCount.TabIndex = 0;
        lblTicketCount.Text = "Vé";
        lblTicketCount.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTicketAmount
        // 
        lblTicketAmount.Dock = DockStyle.Fill;
        lblTicketAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTicketAmount.Location = new Point(265, 0);
        lblTicketAmount.Margin = new Padding(0);
        lblTicketAmount.Name = "lblTicketAmount";
        lblTicketAmount.Size = new Size(202, 43);
        lblTicketAmount.TabIndex = 1;
        lblTicketAmount.Text = "0 đ";
        lblTicketAmount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlOrderScroll
        // 
        pnlOrderScroll.AccessibleName = "Danh sách món đã chọn";
        pnlOrderScroll.AutoScroll = true;
        pnlOrderScroll.Controls.Add(orderItems);
        pnlOrderScroll.Dock = DockStyle.Fill;
        pnlOrderScroll.Location = new Point(14, 229);
        pnlOrderScroll.Margin = new Padding(0);
        pnlOrderScroll.Name = "pnlOrderScroll";
        pnlOrderScroll.Size = new Size(476, 1);
        pnlOrderScroll.TabIndex = 3;
        // 
        // orderItems
        // 
        orderItems.AutoSize = true;
        orderItems.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        orderItems.ColumnCount = 2;
        orderItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
        orderItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
        orderItems.Dock = DockStyle.Top;
        orderItems.Location = new Point(0, 0);
        orderItems.Margin = new Padding(0);
        orderItems.Name = "orderItems";
        orderItems.Padding = new Padding(9, 0, 9, 0);
        orderItems.Size = new Size(476, 0);
        orderItems.TabIndex = 0;
        // 
        // layoutTotal
        // 
        layoutTotal.BackColor = Color.FromArgb(241, 245, 249);
        layoutTotal.ColumnCount = 2;
        layoutTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54F));
        layoutTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46F));
        layoutTotal.Controls.Add(lblTotalCaption, 0, 0);
        layoutTotal.Controls.Add(lblTotal, 1, 0);
        layoutTotal.Dock = DockStyle.Fill;
        layoutTotal.Location = new Point(14, 229);
        layoutTotal.Margin = new Padding(0, 0, 0, 8);
        layoutTotal.Name = "layoutTotal";
        layoutTotal.Padding = new Padding(9, 0, 9, 0);
        layoutTotal.RowCount = 1;
        layoutTotal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTotal.Size = new Size(476, 52);
        layoutTotal.TabIndex = 4;
        // 
        // lblTotalCaption
        // 
        lblTotalCaption.Dock = DockStyle.Fill;
        lblTotalCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblTotalCaption.Location = new Point(9, 0);
        lblTotalCaption.Margin = new Padding(0);
        lblTotalCaption.Name = "lblTotalCaption";
        lblTotalCaption.Size = new Size(247, 52);
        lblTotalCaption.TabIndex = 0;
        lblTotalCaption.Text = "Tổng tạm tính";
        lblTotalCaption.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTotal
        // 
        lblTotal.Dock = DockStyle.Fill;
        lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(37, 99, 235);
        lblTotal.Location = new Point(256, 0);
        lblTotal.Margin = new Padding(0);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(211, 52);
        lblTotal.TabIndex = 1;
        lblTotal.Text = "0 đ";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblNotice
        // 
        lblNotice.AutoSize = true;
        lblNotice.BackColor = Color.FromArgb(254, 243, 199);
        lblNotice.Dock = DockStyle.Fill;
        lblNotice.ForeColor = Color.FromArgb(146, 64, 14);
        lblNotice.Location = new Point(14, 585);
        lblNotice.Margin = new Padding(0, 0, 0, 6);
        lblNotice.Name = "lblNotice";
        lblNotice.Padding = new Padding(8, 5, 8, 5);
        lblNotice.Size = new Size(476, 30);
        lblNotice.TabIndex = 5;
        lblNotice.TextAlign = ContentAlignment.MiddleLeft;
        lblNotice.Text = "Chưa có vé được chọn";
        // 
        // layoutButtons
        // 
        layoutButtons.ColumnCount = 2;
        layoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        layoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        layoutButtons.Controls.Add(btnBack, 0, 0);
        layoutButtons.Controls.Add(btnContinue, 1, 0);
        layoutButtons.Dock = DockStyle.Fill;
        layoutButtons.Location = new Point(14, 621);
        layoutButtons.Margin = new Padding(0);
        layoutButtons.Name = "layoutButtons";
        layoutButtons.RowCount = 2;
        layoutButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        layoutButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 0F));
        layoutButtons.Size = new Size(476, 52);
        layoutButtons.TabIndex = 6;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.White;
        btnBack.Cursor = Cursors.Hand;
        btnBack.Dock = DockStyle.Fill;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.ForeColor = Color.FromArgb(15, 23, 42);
        btnBack.Location = new Point(0, 0);
        btnBack.Margin = new Padding(0, 0, 8, 0);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(196, 52);
        btnBack.TabIndex = 0;
        btnBack.Text = "‹ Quay lại chọn ghế";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += BtnBack_Click;
        // 
        // btnContinue
        // 
        btnContinue.BackColor = Color.FromArgb(37, 99, 235);
        btnContinue.Cursor = Cursors.Hand;
        btnContinue.Enabled = false;
        btnContinue.Dock = DockStyle.Fill;
        btnContinue.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnContinue.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
        btnContinue.FlatStyle = FlatStyle.Flat;
        btnContinue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnContinue.ForeColor = Color.White;
        btnContinue.Location = new Point(204, 0);
        btnContinue.Margin = new Padding(0);
        btnContinue.Name = "btnContinue";
        btnContinue.Size = new Size(272, 52);
        btnContinue.TabIndex = 1;
        btnContinue.Text = "TIẾP TỤC THANH TOÁN →";
        btnContinue.UseVisualStyleBackColor = false;
        btnContinue.Click += BtnContinue_Click;
        // 
        // ConcessionSelectionView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(layoutPage);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Margin = new Padding(4, 4, 4, 4);
        Name = "ConcessionSelectionView";
        Size = new Size(1400, 825);
        layoutPage.ResumeLayout(false);
        layoutWorkArea.ResumeLayout(false);
        layoutCatalog.ResumeLayout(false);
        layoutCatalog.PerformLayout();
        layoutHeading.ResumeLayout(false);
        flowCategories.ResumeLayout(false);
        flowCategories.PerformLayout();
        pnlProductScroll.ResumeLayout(false);
        pnlSummary.ResumeLayout(false);
        layoutSummary.ResumeLayout(false);
        layoutSummary.PerformLayout();
        layoutMovie.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picMovie).EndInit();
        layoutMovieDetails.ResumeLayout(false);
        layoutTicketRow.ResumeLayout(false);
        pnlOrderScroll.ResumeLayout(false);
        pnlOrderScroll.PerformLayout();
        layoutTotal.ResumeLayout(false);
        layoutButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutPage;
    private Cinema.WinForms.Controls.TicketSalesProgressBar progressBar;
    private TableLayoutPanel layoutWorkArea;
    private TableLayoutPanel layoutCatalog;
    private TableLayoutPanel layoutHeading;
    private Label lblTitle;
    private Label lblCountdown;
    private FlowLayoutPanel flowCategories;
    private Button btnAll;
    private Button btnCombo;
    private Button btnPopcorn;
    private Button btnDrink;
    private Button btnSnack;
    private Panel pnlProductScroll;
    private TableLayoutPanel gridProducts;
    private Label lblEmptyCatalog;
    private Panel pnlSummary;
    private TableLayoutPanel layoutSummary;
    private Label lblSummary;
    private TableLayoutPanel layoutMovie;
    private PictureBox picMovie;
    private TableLayoutPanel layoutMovieDetails;
    private Label lblMovie;
    private Label lblShowtime;
    private Label lblRoom;
    private Label lblSeats;
    private TableLayoutPanel layoutTicketRow;
    private Label lblTicketCount;
    private Label lblTicketAmount;
    private Panel pnlOrderScroll;
    private TableLayoutPanel orderItems;
    private TableLayoutPanel layoutTotal;
    private Label lblTotalCaption;
    private Label lblTotal;
    private Label lblNotice;
    private TableLayoutPanel layoutButtons;
    private Button btnBack;
    private Button btnContinue;
}

namespace Cinema.WinForms.Features.TicketSales;

partial class ShowtimeSelectionView
{
    private void InitializeComponent()
    {
        layoutContent = new TableLayoutPanel();
        layoutSteps = new Cinema.WinForms.Controls.TicketSalesProgressBar();
        lblTitle = new Label();
        flowFilters = new FlowLayoutPanel();
        btnToday = new Button();
        btnTomorrow = new Button();
        dateShowtime = new DateTimePicker();
        txtSearch = new TextBox();
        cboFormat = new ComboBox();
        cboRoom = new ComboBox();
        layoutStatus = new TableLayoutPanel();
        lblInstruction = new Label();
        lblSelected = new Label();
        pnlMovieScroll = new Panel();
        gridMovies = new TableLayoutPanel();
        lblEmpty = new Label();
        layoutContent.SuspendLayout();
        flowFilters.SuspendLayout();
        layoutStatus.SuspendLayout();
        pnlMovieScroll.SuspendLayout();
        SuspendLayout();
        // 
        // layoutContent
        // 
        layoutContent.ColumnCount = 1;
        layoutContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutContent.Controls.Add(layoutSteps, 0, 0);
        layoutContent.Controls.Add(lblTitle, 0, 1);
        layoutContent.Controls.Add(flowFilters, 0, 2);
        layoutContent.Controls.Add(layoutStatus, 0, 3);
        layoutContent.Controls.Add(pnlMovieScroll, 0, 4);
        layoutContent.Dock = DockStyle.Fill;
        layoutContent.Location = new Point(0, 0);
        layoutContent.Name = "layoutContent";
        layoutContent.Padding = new Padding(20, 16, 20, 12);
        layoutContent.RowCount = 5;
        layoutContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutContent.Size = new Size(1150, 780);
        layoutContent.TabIndex = 0;
        // 
        // layoutSteps
        //
        layoutSteps.ActiveStep = 1;
        layoutSteps.Dock = DockStyle.Fill;
        layoutSteps.Margin = Padding.Empty;
        layoutSteps.Name = "layoutSteps";
        //
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitle.Location = new Point(20, 58);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1110, 60);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "CHỌN PHIM & SUẤT CHIẾU";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // flowFilters
        // 
        flowFilters.BackColor = Color.White;
        flowFilters.Controls.Add(btnToday);
        flowFilters.Controls.Add(btnTomorrow);
        flowFilters.Controls.Add(dateShowtime);
        flowFilters.Controls.Add(txtSearch);
        flowFilters.Controls.Add(cboFormat);
        flowFilters.Controls.Add(cboRoom);
        flowFilters.Dock = DockStyle.Fill;
        flowFilters.Location = new Point(20, 118);
        flowFilters.Margin = new Padding(0);
        flowFilters.Name = "flowFilters";
        flowFilters.Padding = new Padding(10, 9, 4, 4);
        flowFilters.Size = new Size(1110, 60);
        flowFilters.TabIndex = 0;
        // 
        // btnToday
        // 
        btnToday.BackColor = Color.FromArgb(239, 246, 255);
        btnToday.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnToday.FlatStyle = FlatStyle.Flat;
        btnToday.ForeColor = Color.FromArgb(37, 99, 235);
        btnToday.Location = new Point(10, 11);
        btnToday.Margin = new Padding(0, 2, 8, 8);
        btnToday.Name = "btnToday";
        btnToday.Size = new Size(96, 34);
        btnToday.TabIndex = 0;
        btnToday.Text = "Hôm nay";
        btnToday.UseVisualStyleBackColor = false;
        btnToday.Click += BtnToday_Click;
        // 
        // btnTomorrow
        // 
        btnTomorrow.BackColor = Color.White;
        btnTomorrow.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnTomorrow.FlatStyle = FlatStyle.Flat;
        btnTomorrow.Location = new Point(114, 11);
        btnTomorrow.Margin = new Padding(0, 2, 8, 8);
        btnTomorrow.Name = "btnTomorrow";
        btnTomorrow.Size = new Size(96, 34);
        btnTomorrow.TabIndex = 1;
        btnTomorrow.Text = "Ngày mai";
        btnTomorrow.UseVisualStyleBackColor = false;
        btnTomorrow.Click += BtnTomorrow_Click;
        // 
        // dateShowtime
        // 
        dateShowtime.AccessibleName = "Ngày chiếu";
        dateShowtime.CustomFormat = "dd/MM/yyyy";
        dateShowtime.Format = DateTimePickerFormat.Custom;
        dateShowtime.Location = new Point(218, 15);
        dateShowtime.Margin = new Padding(0, 6, 8, 8);
        dateShowtime.Name = "dateShowtime";
        dateShowtime.Size = new Size(128, 30);
        dateShowtime.TabIndex = 2;
        dateShowtime.ValueChanged += Filters_Changed;
        // 
        // txtSearch
        // 
        txtSearch.AccessibleName = "Tìm tên phim";
        txtSearch.Location = new Point(354, 15);
        txtSearch.Margin = new Padding(0, 6, 8, 8);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Tìm tên phim...";
        txtSearch.Size = new Size(200, 30);
        txtSearch.TabIndex = 3;
        txtSearch.TextChanged += Filters_Changed;
        // 
        // cboFormat
        // 
        cboFormat.AccessibleName = "Định dạng";
        cboFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFormat.FormattingEnabled = true;
        cboFormat.Items.Add("Tất cả định dạng");
        cboFormat.Location = new Point(562, 15);
        cboFormat.Margin = new Padding(0, 6, 8, 8);
        cboFormat.Name = "cboFormat";
        cboFormat.Size = new Size(148, 31);
        cboFormat.TabIndex = 4;
        cboFormat.SelectedIndexChanged += Filters_Changed;
        // 
        // cboRoom
        // 
        cboRoom.AccessibleName = "Phòng chiếu";
        cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRoom.FormattingEnabled = true;
        cboRoom.Items.Add("Tất cả phòng");
        cboRoom.Location = new Point(718, 15);
        cboRoom.Margin = new Padding(0, 6, 8, 8);
        cboRoom.Name = "cboRoom";
        cboRoom.Size = new Size(146, 31);
        cboRoom.TabIndex = 5;
        cboRoom.SelectedIndexChanged += Filters_Changed;
        // 
        // layoutStatus
        // 
        layoutStatus.ColumnCount = 2;
        layoutStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53F));
        layoutStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47F));
        layoutStatus.Controls.Add(lblInstruction, 0, 0);
        layoutStatus.Controls.Add(lblSelected, 1, 0);
        layoutStatus.Dock = DockStyle.Fill;
        layoutStatus.Location = new Point(20, 178);
        layoutStatus.Margin = new Padding(0);
        layoutStatus.Name = "layoutStatus";
        layoutStatus.RowCount = 1;
        layoutStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutStatus.Size = new Size(1110, 42);
        layoutStatus.TabIndex = 2;
        // 
        // lblInstruction
        // 
        lblInstruction.Dock = DockStyle.Fill;
        lblInstruction.ForeColor = Color.FromArgb(71, 85, 105);
        lblInstruction.Location = new Point(0, 0);
        lblInstruction.Margin = new Padding(0);
        lblInstruction.Name = "lblInstruction";
        lblInstruction.Size = new Size(588, 42);
        lblInstruction.TabIndex = 0;
        lblInstruction.Text = "Chọn một suất chiếu để tiếp tục";
        lblInstruction.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblSelected
        // 
        lblSelected.Dock = DockStyle.Fill;
        lblSelected.ForeColor = Color.FromArgb(37, 99, 235);
        lblSelected.Location = new Point(588, 0);
        lblSelected.Margin = new Padding(0);
        lblSelected.Name = "lblSelected";
        lblSelected.Size = new Size(522, 42);
        lblSelected.TabIndex = 1;
        lblSelected.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlMovieScroll
        // 
        pnlMovieScroll.AutoScroll = true;
        pnlMovieScroll.Controls.Add(gridMovies);
        pnlMovieScroll.Controls.Add(lblEmpty);
        pnlMovieScroll.Dock = DockStyle.Fill;
        pnlMovieScroll.Location = new Point(20, 220);
        pnlMovieScroll.Margin = new Padding(0);
        pnlMovieScroll.Name = "pnlMovieScroll";
        pnlMovieScroll.Size = new Size(1110, 548);
        pnlMovieScroll.TabIndex = 1;
        // 
        // gridMovies
        // 
        gridMovies.AutoSize = true;
        gridMovies.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        gridMovies.ColumnCount = 2;
        gridMovies.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        gridMovies.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        gridMovies.Dock = DockStyle.Top;
        gridMovies.Location = new Point(0, 120);
        gridMovies.Margin = new Padding(0);
        gridMovies.Name = "gridMovies";
        gridMovies.RowCount = 1;
        gridMovies.RowStyles.Add(new RowStyle());
        gridMovies.Size = new Size(1110, 0);
        gridMovies.TabIndex = 0;
        // 
        // lblEmpty
        // 
        lblEmpty.Dock = DockStyle.Top;
        lblEmpty.Font = new Font("Segoe UI", 11F);
        lblEmpty.ForeColor = Color.FromArgb(100, 116, 139);
        lblEmpty.Location = new Point(0, 0);
        lblEmpty.Name = "lblEmpty";
        lblEmpty.Size = new Size(1110, 120);
        lblEmpty.TabIndex = 1;
        lblEmpty.Text = "Không tìm thấy suất chiếu phù hợp";
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
        lblEmpty.Visible = false;
        // 
        // ShowtimeSelectionView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(layoutContent);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "ShowtimeSelectionView";
        Size = new Size(1150, 780);
        layoutContent.ResumeLayout(false);
        flowFilters.ResumeLayout(false);
        flowFilters.PerformLayout();
        layoutStatus.ResumeLayout(false);
        pnlMovieScroll.ResumeLayout(false);
        pnlMovieScroll.PerformLayout();
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutContent;
    private Cinema.WinForms.Controls.TicketSalesProgressBar layoutSteps;
    private Label lblTitle;
    private FlowLayoutPanel flowFilters;
    private Button btnToday;
    private Button btnTomorrow;
    private DateTimePicker dateShowtime;
    private TextBox txtSearch;
    private ComboBox cboFormat;
    private ComboBox cboRoom;
    private TableLayoutPanel layoutStatus;
    private Label lblInstruction;
    private Label lblSelected;
    private Panel pnlMovieScroll;
    private TableLayoutPanel gridMovies;
    private Label lblEmpty;
}

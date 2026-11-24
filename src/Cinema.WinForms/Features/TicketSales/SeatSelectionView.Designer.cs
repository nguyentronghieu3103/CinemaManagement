namespace Cinema.WinForms.Features.TicketSales;

partial class SeatSelectionView
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        layoutPage = new TableLayoutPanel();
        layoutProgress = new Cinema.WinForms.Controls.TicketSalesProgressBar();
        lblTitle = new Label();
        layoutShowtime = new TableLayoutPanel();
        lblShowtime = new Label();
        lblShowtimeDate = new Label();
        btnBack = new Button();
        lblNotice = new Label();
        layoutWorkArea = new TableLayoutPanel();
        pnlSeatMap = new Panel();
        seatMap = new Cinema.WinForms.Controls.SeatMapControl();
        pnlSelectedTickets = new Panel();
        layoutTickets = new TableLayoutPanel();
        lblTickets = new Label();
        layoutHold = new TableLayoutPanel();
        lblHold = new Label();
        lblCountdown = new Label();
        gridSelectedSeats = new DataGridView();
        colSeat = new DataGridViewTextBoxColumn();
        colType = new DataGridViewTextBoxColumn();
        colPrice = new DataGridViewTextBoxColumn();
        colRemove = new DataGridViewButtonColumn();
        ticketsBindingSource = new BindingSource(components);
        layoutCount = new TableLayoutPanel();
        lblCountCaption = new Label();
        lblSeatCount = new Label();
        layoutTotal = new TableLayoutPanel();
        lblTotalCaption = new Label();
        lblSubtotal = new Label();
        btnContinue = new Button();
        layoutPage.SuspendLayout();
        layoutShowtime.SuspendLayout();
        layoutWorkArea.SuspendLayout();
        pnlSeatMap.SuspendLayout();
        pnlSelectedTickets.SuspendLayout();
        layoutTickets.SuspendLayout();
        layoutHold.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridSelectedSeats).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ticketsBindingSource).BeginInit();
        layoutCount.SuspendLayout();
        layoutTotal.SuspendLayout();
        SuspendLayout();
        // 
        // layoutPage
        // 
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.Controls.Add(layoutProgress, 0, 0);
        layoutPage.Controls.Add(lblTitle, 0, 1);
        layoutPage.Controls.Add(layoutShowtime, 0, 2);
        layoutPage.Controls.Add(lblNotice, 0, 3);
        layoutPage.Controls.Add(layoutWorkArea, 0, 4);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(4);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(22, 15, 22, 20);
        layoutPage.RowCount = 5;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        layoutPage.RowStyles.Add(new RowStyle());
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1400, 825);
        layoutPage.TabIndex = 0;
        // 
        // layoutProgress
        // 
        layoutProgress.ActiveStep = 2;
        layoutProgress.Dock = DockStyle.Fill;
        layoutProgress.Location = new Point(22, 15);
        layoutProgress.Margin = new Padding(0);
        layoutProgress.Name = "layoutProgress";
        layoutProgress.Size = new Size(1356, 50);
        layoutProgress.TabIndex = 0;
        layoutProgress.TabStop = false;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblTitle.Location = new Point(22, 65);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1356, 60);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "CHỌN GHẾ NGỒI";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // layoutShowtime
        // 
        layoutShowtime.BackColor = Color.White;
        layoutShowtime.ColumnCount = 3;
        layoutShowtime.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutShowtime.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 222F));
        layoutShowtime.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
        layoutShowtime.Controls.Add(lblShowtime, 0, 0);
        layoutShowtime.Controls.Add(lblShowtimeDate, 1, 0);
        layoutShowtime.Controls.Add(btnBack, 2, 0);
        layoutShowtime.Dock = DockStyle.Fill;
        layoutShowtime.Location = new Point(22, 125);
        layoutShowtime.Margin = new Padding(0, 0, 0, 8);
        layoutShowtime.Name = "layoutShowtime";
        layoutShowtime.Padding = new Padding(15, 0, 10, 0);
        layoutShowtime.RowCount = 1;
        layoutShowtime.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutShowtime.Size = new Size(1356, 50);
        layoutShowtime.TabIndex = 2;
        // 
        // lblShowtime
        // 
        lblShowtime.AutoEllipsis = true;
        lblShowtime.Dock = DockStyle.Fill;
        lblShowtime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblShowtime.Location = new Point(15, 0);
        lblShowtime.Margin = new Padding(0);
        lblShowtime.Name = "lblShowtime";
        lblShowtime.Size = new Size(909, 50);
        lblShowtime.TabIndex = 0;
        lblShowtime.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblShowtimeDate
        // 
        lblShowtimeDate.Dock = DockStyle.Fill;
        lblShowtimeDate.ForeColor = Color.FromArgb(71, 85, 105);
        lblShowtimeDate.Location = new Point(934, 0);
        lblShowtimeDate.Margin = new Padding(10, 0, 10, 0);
        lblShowtimeDate.Name = "lblShowtimeDate";
        lblShowtimeDate.Size = new Size(202, 50);
        lblShowtimeDate.TabIndex = 1;
        lblShowtimeDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.White;
        btnBack.Cursor = Cursors.Hand;
        btnBack.Dock = DockStyle.Fill;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Location = new Point(1146, 6);
        btnBack.Margin = new Padding(0, 6, 0, 6);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(200, 38);
        btnBack.TabIndex = 0;
        btnBack.Text = "‹  Quay lại chọn suất";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += BtnBack_Click;
        // 
        // lblNotice
        // 
        lblNotice.AutoSize = true;
        lblNotice.BackColor = Color.FromArgb(254, 243, 199);
        lblNotice.Dock = DockStyle.Fill;
        lblNotice.ForeColor = Color.FromArgb(146, 64, 14);
        lblNotice.Location = new Point(22, 188);
        lblNotice.Margin = new Padding(0, 5, 0, 5);
        lblNotice.Name = "lblNotice";
        lblNotice.Padding = new Padding(11, 6, 11, 6);
        lblNotice.Size = new Size(1356, 32);
        lblNotice.TabIndex = 3;
        lblNotice.Visible = false;
        // 
        // layoutWorkArea
        // 
        layoutWorkArea.ColumnCount = 2;
        layoutWorkArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutWorkArea.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 430F));
        layoutWorkArea.Controls.Add(pnlSeatMap, 0, 0);
        layoutWorkArea.Controls.Add(pnlSelectedTickets, 1, 0);
        layoutWorkArea.Dock = DockStyle.Fill;
        layoutWorkArea.Location = new Point(22, 225);
        layoutWorkArea.Margin = new Padding(0);
        layoutWorkArea.Name = "layoutWorkArea";
        layoutWorkArea.RowCount = 1;
        layoutWorkArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutWorkArea.Size = new Size(1356, 580);
        layoutWorkArea.TabIndex = 1;
        // 
        // pnlSeatMap
        // 
        pnlSeatMap.BackColor = Color.FromArgb(203, 213, 225);
        pnlSeatMap.Controls.Add(seatMap);
        pnlSeatMap.Dock = DockStyle.Fill;
        pnlSeatMap.Location = new Point(0, 0);
        pnlSeatMap.Margin = new Padding(0);
        pnlSeatMap.Name = "pnlSeatMap";
        pnlSeatMap.Padding = new Padding(1);
        pnlSeatMap.Size = new Size(926, 580);
        pnlSeatMap.TabIndex = 0;
        // 
        // seatMap
        // 
        seatMap.BackColor = Color.White;
        seatMap.Dock = DockStyle.Fill;
        seatMap.Font = new Font("Segoe UI", 9F);
        seatMap.ForeColor = Color.FromArgb(15, 23, 42);
        seatMap.Location = new Point(1, 1);
        seatMap.Margin = new Padding(4);
        seatMap.Name = "seatMap";
        seatMap.Size = new Size(924, 578);
        seatMap.TabIndex = 0;
        // 
        // pnlSelectedTickets
        // 
        pnlSelectedTickets.BackColor = Color.FromArgb(226, 232, 240);
        pnlSelectedTickets.Controls.Add(layoutTickets);
        pnlSelectedTickets.Dock = DockStyle.Fill;
        pnlSelectedTickets.Location = new Point(938, 0);
        pnlSelectedTickets.Margin = new Padding(12, 0, 0, 0);
        pnlSelectedTickets.Name = "pnlSelectedTickets";
        pnlSelectedTickets.Padding = new Padding(1);
        pnlSelectedTickets.Size = new Size(418, 580);
        pnlSelectedTickets.TabIndex = 1;
        // 
        // layoutTickets
        // 
        layoutTickets.BackColor = Color.White;
        layoutTickets.ColumnCount = 1;
        layoutTickets.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTickets.Controls.Add(lblTickets, 0, 0);
        layoutTickets.Controls.Add(layoutHold, 0, 1);
        layoutTickets.Controls.Add(gridSelectedSeats, 0, 2);
        layoutTickets.Controls.Add(layoutCount, 0, 3);
        layoutTickets.Controls.Add(layoutTotal, 0, 4);
        layoutTickets.Controls.Add(btnContinue, 0, 5);
        layoutTickets.Dock = DockStyle.Fill;
        layoutTickets.Location = new Point(1, 1);
        layoutTickets.Margin = new Padding(4);
        layoutTickets.Name = "layoutTickets";
        layoutTickets.Padding = new Padding(12);
        layoutTickets.RowCount = 6;
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        layoutTickets.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        layoutTickets.Size = new Size(416, 578);
        layoutTickets.TabIndex = 0;
        // 
        // lblTickets
        // 
        lblTickets.Dock = DockStyle.Fill;
        lblTickets.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTickets.Location = new Point(12, 12);
        lblTickets.Margin = new Padding(0);
        lblTickets.Name = "lblTickets";
        lblTickets.Size = new Size(392, 45);
        lblTickets.TabIndex = 0;
        lblTickets.Text = "VÉ ĐÃ CHỌN";
        lblTickets.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // layoutHold
        // 
        layoutHold.BackColor = Color.FromArgb(219, 234, 254);
        layoutHold.ColumnCount = 2;
        layoutHold.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHold.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
        layoutHold.Controls.Add(lblHold, 0, 0);
        layoutHold.Controls.Add(lblCountdown, 1, 0);
        layoutHold.Dock = DockStyle.Fill;
        layoutHold.ForeColor = Color.FromArgb(30, 64, 175);
        layoutHold.Location = new Point(12, 57);
        layoutHold.Margin = new Padding(0, 0, 0, 10);
        layoutHold.Name = "layoutHold";
        layoutHold.Padding = new Padding(10, 0, 10, 0);
        layoutHold.RowCount = 1;
        layoutHold.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHold.Size = new Size(392, 40);
        layoutHold.TabIndex = 1;
        // 
        // lblHold
        // 
        lblHold.Dock = DockStyle.Fill;
        lblHold.Location = new Point(10, 0);
        lblHold.Margin = new Padding(0);
        lblHold.Name = "lblHold";
        lblHold.Size = new Size(290, 40);
        lblHold.TabIndex = 0;
        lblHold.Text = "Thời gian giữ ghế";
        lblHold.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCountdown
        // 
        lblCountdown.Dock = DockStyle.Fill;
        lblCountdown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblCountdown.Location = new Point(300, 0);
        lblCountdown.Margin = new Padding(0);
        lblCountdown.Name = "lblCountdown";
        lblCountdown.Size = new Size(82, 40);
        lblCountdown.TabIndex = 1;
        lblCountdown.Text = "—";
        lblCountdown.TextAlign = ContentAlignment.MiddleRight;
        // 
        // gridSelectedSeats
        // 
        gridSelectedSeats.AccessibleName = "Danh sách ghế đã chọn";
        gridSelectedSeats.AllowUserToAddRows = false;
        gridSelectedSeats.AllowUserToDeleteRows = false;
        gridSelectedSeats.AllowUserToResizeColumns = false;
        gridSelectedSeats.AllowUserToResizeRows = false;
        gridSelectedSeats.AutoGenerateColumns = false;
        gridSelectedSeats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        gridSelectedSeats.BackgroundColor = Color.White;
        gridSelectedSeats.BorderStyle = BorderStyle.None;
        gridSelectedSeats.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridSelectedSeats.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        gridSelectedSeats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        gridSelectedSeats.ColumnHeadersHeight = 30;
        gridSelectedSeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridSelectedSeats.Columns.AddRange(new DataGridViewColumn[] { colSeat, colType, colPrice, colRemove });
        gridSelectedSeats.DataSource = ticketsBindingSource;
        gridSelectedSeats.Dock = DockStyle.Fill;
        gridSelectedSeats.EnableHeadersVisualStyles = false;
        gridSelectedSeats.GridColor = Color.FromArgb(226, 232, 240);
        gridSelectedSeats.Location = new Point(12, 107);
        gridSelectedSeats.Margin = new Padding(0);
        gridSelectedSeats.MultiSelect = false;
        gridSelectedSeats.Name = "gridSelectedSeats";
        gridSelectedSeats.ReadOnly = true;
        gridSelectedSeats.RowHeadersVisible = false;
        gridSelectedSeats.RowHeadersWidth = 51;
        gridSelectedSeats.RowTemplate.Height = 32;
        gridSelectedSeats.ScrollBars = ScrollBars.Vertical;
        gridSelectedSeats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridSelectedSeats.Size = new Size(392, 290);
        gridSelectedSeats.TabIndex = 0;
        gridSelectedSeats.CellContentClick += GridSelectedSeats_CellContentClick;
        //
        // colSeat
        //
        colSeat.DataPropertyName = "Code";
        colSeat.FillWeight = 58F;
        colSeat.HeaderText = "Ghế";
        colSeat.MinimumWidth = 44;
        colSeat.Name = "colSeat";
        colSeat.ReadOnly = true;
        colSeat.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colType
        //
        colType.DataPropertyName = "TypeName";
        colType.FillWeight = 96F;
        colType.HeaderText = "Loại ghế";
        colType.MinimumWidth = 72;
        colType.Name = "colType";
        colType.ReadOnly = true;
        colType.SortMode = DataGridViewColumnSortMode.NotSortable;
        //
        // colPrice
        //
        colPrice.DataPropertyName = "Price";
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle2.Format = "#,0' đ'";
        colPrice.DefaultCellStyle = dataGridViewCellStyle2;
        colPrice.FillWeight = 110F;
        colPrice.HeaderText = "Đơn giá";
        colPrice.MinimumWidth = 81;
        colPrice.Name = "colPrice";
        colPrice.ReadOnly = true;
        colPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // colRemove
        // 
        colRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        colRemove.FlatStyle = FlatStyle.Flat;
        colRemove.HeaderText = "";
        colRemove.MinimumWidth = 31;
        colRemove.Name = "colRemove";
        colRemove.ReadOnly = true;
        colRemove.Text = "×";
        colRemove.ToolTipText = "Bỏ chọn ghế";
        colRemove.UseColumnTextForButtonValue = true;
        colRemove.Width = 36;
        // 
        // layoutCount
        // 
        layoutCount.ColumnCount = 2;
        layoutCount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutCount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutCount.Controls.Add(lblCountCaption, 0, 0);
        layoutCount.Controls.Add(lblSeatCount, 1, 0);
        layoutCount.Dock = DockStyle.Fill;
        layoutCount.Location = new Point(12, 397);
        layoutCount.Margin = new Padding(0);
        layoutCount.Name = "layoutCount";
        layoutCount.RowCount = 1;
        layoutCount.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCount.Size = new Size(392, 45);
        layoutCount.TabIndex = 2;
        // 
        // lblCountCaption
        // 
        lblCountCaption.Dock = DockStyle.Fill;
        lblCountCaption.ForeColor = Color.FromArgb(71, 85, 105);
        lblCountCaption.Location = new Point(0, 0);
        lblCountCaption.Margin = new Padding(0);
        lblCountCaption.Name = "lblCountCaption";
        lblCountCaption.Size = new Size(196, 45);
        lblCountCaption.TabIndex = 0;
        lblCountCaption.Text = "Số chỗ";
        lblCountCaption.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblSeatCount
        // 
        lblSeatCount.Dock = DockStyle.Fill;
        lblSeatCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblSeatCount.Location = new Point(196, 0);
        lblSeatCount.Margin = new Padding(0);
        lblSeatCount.Name = "lblSeatCount";
        lblSeatCount.Size = new Size(196, 45);
        lblSeatCount.TabIndex = 1;
        lblSeatCount.Text = "0";
        lblSeatCount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // layoutTotal
        // 
        layoutTotal.BackColor = Color.FromArgb(241, 245, 249);
        layoutTotal.ColumnCount = 2;
        layoutTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        layoutTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        layoutTotal.Controls.Add(lblTotalCaption, 0, 0);
        layoutTotal.Controls.Add(lblSubtotal, 1, 0);
        layoutTotal.Dock = DockStyle.Fill;
        layoutTotal.Location = new Point(12, 442);
        layoutTotal.Margin = new Padding(0, 0, 0, 5);
        layoutTotal.Name = "layoutTotal";
        layoutTotal.Padding = new Padding(10, 0, 10, 0);
        layoutTotal.RowCount = 1;
        layoutTotal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTotal.Size = new Size(392, 57);
        layoutTotal.TabIndex = 3;
        // 
        // lblTotalCaption
        // 
        lblTotalCaption.Dock = DockStyle.Fill;
        lblTotalCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblTotalCaption.Location = new Point(10, 0);
        lblTotalCaption.Margin = new Padding(0);
        lblTotalCaption.Name = "lblTotalCaption";
        lblTotalCaption.Size = new Size(148, 57);
        lblTotalCaption.TabIndex = 0;
        lblTotalCaption.Text = "Tạm tính";
        lblTotalCaption.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblSubtotal
        // 
        lblSubtotal.Dock = DockStyle.Fill;
        lblSubtotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSubtotal.Location = new Point(158, 0);
        lblSubtotal.Margin = new Padding(0);
        lblSubtotal.Name = "lblSubtotal";
        lblSubtotal.Size = new Size(224, 57);
        lblSubtotal.TabIndex = 1;
        lblSubtotal.Text = "0 đ";
        lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnContinue
        // 
        btnContinue.BackColor = Color.FromArgb(37, 99, 235);
        btnContinue.Cursor = Cursors.Hand;
        btnContinue.Dock = DockStyle.Fill;
        btnContinue.FlatAppearance.BorderSize = 0;
        btnContinue.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
        btnContinue.FlatStyle = FlatStyle.Flat;
        btnContinue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnContinue.ForeColor = Color.White;
        btnContinue.Location = new Point(12, 512);
        btnContinue.Margin = new Padding(0, 8, 0, 0);
        btnContinue.Name = "btnContinue";
        btnContinue.Size = new Size(392, 54);
        btnContinue.TabIndex = 1;
        btnContinue.Text = "TIẾP TỤC CHỌN BẮP NƯỚC ";
        btnContinue.UseVisualStyleBackColor = false;
        btnContinue.Click += BtnContinue_Click;
        // 
        // SeatSelectionView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(layoutPage);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Margin = new Padding(4);
        Name = "SeatSelectionView";
        Size = new Size(1400, 825);
        layoutPage.ResumeLayout(false);
        layoutPage.PerformLayout();
        layoutShowtime.ResumeLayout(false);
        layoutWorkArea.ResumeLayout(false);
        pnlSeatMap.ResumeLayout(false);
        pnlSelectedTickets.ResumeLayout(false);
        layoutTickets.ResumeLayout(false);
        layoutHold.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridSelectedSeats).EndInit();
        ((System.ComponentModel.ISupportInitialize)ticketsBindingSource).EndInit();
        layoutCount.ResumeLayout(false);
        layoutTotal.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutPage;
    private Cinema.WinForms.Controls.TicketSalesProgressBar layoutProgress;
    private Label lblTitle;
    private TableLayoutPanel layoutShowtime;
    private Label lblShowtime;
    private Label lblShowtimeDate;
    private Button btnBack;
    private Label lblNotice;
    private TableLayoutPanel layoutWorkArea;
    private Panel pnlSeatMap;
    private Cinema.WinForms.Controls.SeatMapControl seatMap;
    private Panel pnlSelectedTickets;
    private TableLayoutPanel layoutTickets;
    private Label lblTickets;
    private TableLayoutPanel layoutHold;
    private Label lblHold;
    private Label lblCountdown;
    private DataGridView gridSelectedSeats;
    private DataGridViewTextBoxColumn colSeat;
    private DataGridViewTextBoxColumn colType;
    private DataGridViewTextBoxColumn colPrice;
    private DataGridViewButtonColumn colRemove;
    private BindingSource ticketsBindingSource;
    private TableLayoutPanel layoutCount;
    private Label lblCountCaption;
    private Label lblSeatCount;
    private TableLayoutPanel layoutTotal;
    private Label lblTotalCaption;
    private Label lblSubtotal;
    private Button btnContinue;
}

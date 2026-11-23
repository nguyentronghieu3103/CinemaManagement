namespace Cinema.WinForms.Features.TicketCheckIn;

partial class CheckInScreenHeader
{
    private void InitializeComponent()
    {
        layoutHeader = new TableLayoutPanel();
        layoutHeaderTop = new TableLayoutPanel();
        lblTitle = new Label();
        btnChangeSession = new Button();
        lblAttendance = new Label();
        btnHistory = new Button();
        lblSession = new Label();
        layoutHeader.SuspendLayout();
        layoutHeaderTop.SuspendLayout();
        SuspendLayout();
        // 
        // layoutHeader
        // 
        layoutHeader.ColumnCount = 1;
        layoutHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeader.Controls.Add(layoutHeaderTop, 0, 0);
        layoutHeader.Controls.Add(lblSession, 0, 1);
        layoutHeader.Dock = DockStyle.Fill;
        layoutHeader.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeader.Location = new Point(0, 0);
        layoutHeader.Margin = new Padding(0);
        layoutHeader.Name = "layoutHeader";
        layoutHeader.RowCount = 3;
        layoutHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layoutHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        layoutHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeader.Size = new Size(1104, 90);
        layoutHeader.TabIndex = 0;
        // 
        // layoutHeaderTop
        // 
        layoutHeaderTop.ColumnCount = 5;
        layoutHeaderTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
        layoutHeaderTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 174F));
        layoutHeaderTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeaderTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 147F));
        layoutHeaderTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 164F));
        layoutHeaderTop.Controls.Add(lblTitle, 0, 0);
        layoutHeaderTop.Controls.Add(btnChangeSession, 1, 0);
        layoutHeaderTop.Controls.Add(lblAttendance, 3, 0);
        layoutHeaderTop.Controls.Add(btnHistory, 4, 0);
        layoutHeaderTop.Dock = DockStyle.Fill;
        layoutHeaderTop.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeaderTop.Location = new Point(0, 0);
        layoutHeaderTop.Margin = new Padding(0);
        layoutHeaderTop.Name = "layoutHeaderTop";
        layoutHeaderTop.RowCount = 1;
        layoutHeaderTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeaderTop.Size = new Size(1104, 50);
        layoutHeaderTop.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(160, 50);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Soát vé";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // btnChangeSession
        // 
        btnChangeSession.BackColor = Color.White;
        btnChangeSession.Dock = DockStyle.Fill;
        btnChangeSession.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnChangeSession.FlatStyle = FlatStyle.Flat;
        btnChangeSession.Font = new Font("Segoe UI", 10F);
        btnChangeSession.ForeColor = Color.FromArgb(37, 99, 235);
        btnChangeSession.Location = new Point(160, 5);
        btnChangeSession.Margin = new Padding(0, 5, 12, 5);
        btnChangeSession.Name = "btnChangeSession";
        btnChangeSession.Size = new Size(162, 40);
        btnChangeSession.TabIndex = 1;
        btnChangeSession.Text = "‹  Đổi suất chiếu";
        btnChangeSession.UseMnemonic = false;
        btnChangeSession.UseVisualStyleBackColor = false;
        btnChangeSession.Click += BtnChangeSession_Click;
        // 
        // lblAttendance
        // 
        lblAttendance.BackColor = Color.FromArgb(226, 232, 240);
        lblAttendance.Dock = DockStyle.Fill;
        lblAttendance.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblAttendance.ForeColor = Color.FromArgb(51, 65, 85);
        lblAttendance.Location = new Point(793, 7);
        lblAttendance.Margin = new Padding(0, 7, 12, 7);
        lblAttendance.Name = "lblAttendance";
        lblAttendance.Size = new Size(135, 36);
        lblAttendance.TabIndex = 2;
        lblAttendance.Text = "Đã vào: —";
        lblAttendance.TextAlign = ContentAlignment.MiddleCenter;
        lblAttendance.UseMnemonic = false;
        // 
        // btnHistory
        // 
        btnHistory.BackColor = Color.White;
        btnHistory.Dock = DockStyle.Fill;
        btnHistory.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnHistory.FlatStyle = FlatStyle.Flat;
        btnHistory.Font = new Font("Segoe UI", 10F);
        btnHistory.ForeColor = Color.FromArgb(37, 99, 235);
        btnHistory.Location = new Point(940, 5);
        btnHistory.Margin = new Padding(0, 5, 0, 5);
        btnHistory.Name = "btnHistory";
        btnHistory.Size = new Size(164, 40);
        btnHistory.TabIndex = 3;
        btnHistory.Text = "Lịch sử quét ";
        btnHistory.UseMnemonic = false;
        btnHistory.UseVisualStyleBackColor = false;
        btnHistory.Click += BtnHistory_Click;
        // 
        // lblSession
        // 
        lblSession.Dock = DockStyle.Fill;
        lblSession.Font = new Font("Segoe UI", 10.5F);
        lblSession.ForeColor = Color.FromArgb(100, 116, 139);
        lblSession.Location = new Point(0, 50);
        lblSession.Margin = new Padding(0);
        lblSession.Name = "lblSession";
        lblSession.Size = new Size(1104, 32);
        lblSession.TabIndex = 1;
        lblSession.Text = "Phòng — · Suất —";
        lblSession.TextAlign = ContentAlignment.MiddleLeft;
        lblSession.UseMnemonic = false;
        // 
        // CheckInScreenHeader
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(layoutHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "CheckInScreenHeader";
        Size = new Size(1104, 90);
        layoutHeader.ResumeLayout(false);
        layoutHeaderTop.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutHeader;
    private TableLayoutPanel layoutHeaderTop;
    private Label lblTitle;
    private Button btnChangeSession;
    private Label lblAttendance;
    private Button btnHistory;
    private Label lblSession;
}

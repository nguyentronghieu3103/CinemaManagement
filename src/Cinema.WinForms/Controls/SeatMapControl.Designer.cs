namespace Cinema.WinForms.Controls;

partial class SeatMapControl
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
        pnlViewport = new Panel();
        layoutMap = new TableLayoutPanel();
        pnlScreen = new Panel();
        lblScreen = new Label();
        seatGrid = new TableLayoutPanel();
        flowLegend = new FlowLayoutPanel();
        lblLegend = new Label();
        lblSold = new Label();
        lblHeld = new Label();
        lblSelected = new Label();
        lblCouple = new Label();
        lblVip = new Label();
        lblStandard = new Label();
        seatToolTip = new ToolTip(components);
        pnlViewport.SuspendLayout();
        layoutMap.SuspendLayout();
        pnlScreen.SuspendLayout();
        flowLegend.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.Controls.Add(layoutMap);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.Location = new Point(0, 0);
        pnlViewport.Margin = new Padding(4);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Size = new Size(890, 599);
        pnlViewport.TabIndex = 0;
        pnlViewport.Resize += PnlViewport_Resize;
        // 
        // layoutMap
        // 
        layoutMap.ColumnCount = 1;
        layoutMap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMap.Controls.Add(pnlScreen, 0, 0);
        layoutMap.Controls.Add(seatGrid, 0, 1);
        layoutMap.Controls.Add(flowLegend, 0, 2);
        layoutMap.Location = new Point(0, 0);
        layoutMap.Margin = new Padding(0);
        layoutMap.Name = "layoutMap";
        layoutMap.RowCount = 3;
        layoutMap.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
        layoutMap.RowStyles.Add(new RowStyle(SizeType.Absolute, 442F));
        layoutMap.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
        layoutMap.Size = new Size(775, 578);
        layoutMap.TabIndex = 0;
        // 
        // pnlScreen
        // 
        pnlScreen.Controls.Add(lblScreen);
        pnlScreen.Dock = DockStyle.Fill;
        pnlScreen.Location = new Point(0, 9);
        pnlScreen.Margin = new Padding(0, 9, 0, 0);
        pnlScreen.Name = "pnlScreen";
        pnlScreen.Size = new Size(775, 62);
        pnlScreen.TabIndex = 0;
        pnlScreen.Paint += PnlScreen_Paint;
        // 
        // lblScreen
        // 
        lblScreen.BackColor = Color.Transparent;
        lblScreen.Dock = DockStyle.Top;
        lblScreen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblScreen.ForeColor = Color.FromArgb(71, 85, 105);
        lblScreen.Location = new Point(0, 0);
        lblScreen.Margin = new Padding(4, 0, 4, 0);
        lblScreen.Name = "lblScreen";
        lblScreen.Size = new Size(775, 32);
        lblScreen.TabIndex = 0;
        lblScreen.Text = "MÀN HÌNH CHIẾU";
        lblScreen.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // seatGrid
        // 
        seatGrid.AccessibleName = "Sơ đồ ghế";
        seatGrid.ColumnCount = 15;
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        seatGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 36F));
        seatGrid.Dock = DockStyle.Fill;
        seatGrid.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        seatGrid.Location = new Point(10, 71);
        seatGrid.Margin = new Padding(10, 0, 10, 0);
        seatGrid.Name = "seatGrid";
        seatGrid.RowCount = 12;
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        seatGrid.Size = new Size(755, 442);
        seatGrid.TabIndex = 1;
        // 
        // flowLegend
        // 
        flowLegend.Controls.Add(lblLegend);
        flowLegend.Controls.Add(lblSold);
        flowLegend.Controls.Add(lblHeld);
        flowLegend.Controls.Add(lblSelected);
        flowLegend.Controls.Add(lblCouple);
        flowLegend.Controls.Add(lblVip);
        flowLegend.Controls.Add(lblStandard);
        flowLegend.Dock = DockStyle.Fill;
        flowLegend.Location = new Point(0, 519);
        flowLegend.Margin = new Padding(0, 6, 0, 0);
        flowLegend.Name = "flowLegend";
        flowLegend.Padding = new Padding(12, 0, 0, 0);
        flowLegend.Size = new Size(775, 59);
        flowLegend.TabIndex = 2;
        flowLegend.WrapContents = false;
        // 
        // lblLegend
        // 
        lblLegend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblLegend.Location = new Point(16, 0);
        lblLegend.Margin = new Padding(4, 0, 4, 0);
        lblLegend.Name = "lblLegend";
        lblLegend.Size = new Size(86, 30);
        lblLegend.TabIndex = 0;
        lblLegend.Text = "Chú thích";
        lblLegend.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblSold
        // 
        lblSold.BackColor = Color.FromArgb(148, 163, 184);
        lblSold.Location = new Point(110, 0);
        lblSold.Margin = new Padding(4, 0, 4, 0);
        lblSold.Name = "lblSold";
        lblSold.Size = new Size(79, 30);
        lblSold.TabIndex = 5;
        lblSold.Text = "×  Đã bán";
        lblSold.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHeld
        // 
        lblHeld.BackColor = Color.FromArgb(254, 243, 199);
        lblHeld.ForeColor = Color.FromArgb(146, 64, 14);
        lblHeld.Location = new Point(197, 0);
        lblHeld.Margin = new Padding(4, 0, 4, 0);
        lblHeld.Name = "lblHeld";
        lblHeld.Size = new Size(94, 30);
        lblHeld.TabIndex = 6;
        lblHeld.Text = "◷  Đang giữ";
        lblHeld.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSelected
        // 
        lblSelected.BackColor = Color.FromArgb(37, 99, 235);
        lblSelected.ForeColor = Color.White;
        lblSelected.Location = new Point(299, 0);
        lblSelected.Margin = new Padding(4, 0, 4, 0);
        lblSelected.Name = "lblSelected";
        lblSelected.Size = new Size(106, 30);
        lblSelected.TabIndex = 4;
        lblSelected.Text = "✓  Đang chọn";
        lblSelected.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCouple
        // 
        lblCouple.BackColor = Color.FromArgb(252, 231, 243);
        lblCouple.ForeColor = Color.FromArgb(157, 23, 77);
        lblCouple.Location = new Point(413, 0);
        lblCouple.Margin = new Padding(4, 0, 4, 0);
        lblCouple.Name = "lblCouple";
        lblCouple.Size = new Size(59, 30);
        lblCouple.TabIndex = 3;
        lblCouple.Text = "2  Đôi";
        lblCouple.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblVip
        // 
        lblVip.BackColor = Color.FromArgb(237, 233, 254);
        lblVip.ForeColor = Color.FromArgb(91, 33, 182);
        lblVip.Location = new Point(480, 0);
        lblVip.Margin = new Padding(4, 0, 4, 0);
        lblVip.Name = "lblVip";
        lblVip.Size = new Size(60, 30);
        lblVip.TabIndex = 2;
        lblVip.Text = "V  VIP";
        lblVip.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStandard
        // 
        lblStandard.BackColor = Color.FromArgb(226, 232, 240);
        lblStandard.Location = new Point(548, 0);
        lblStandard.Margin = new Padding(4, 0, 4, 0);
        lblStandard.Name = "lblStandard";
        lblStandard.Size = new Size(72, 30);
        lblStandard.TabIndex = 1;
        lblStandard.Text = "Thường";
        lblStandard.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // SeatMapControl
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Margin = new Padding(4);
        Name = "SeatMapControl";
        Size = new Size(890, 599);
        pnlViewport.ResumeLayout(false);
        layoutMap.ResumeLayout(false);
        pnlScreen.ResumeLayout(false);
        flowLegend.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutMap;
    private Panel pnlScreen;
    private Label lblScreen;
    private TableLayoutPanel seatGrid;
    private FlowLayoutPanel flowLegend;
    private Label lblLegend;
    private Label lblStandard;
    private Label lblVip;
    private Label lblCouple;
    private Label lblSelected;
    private Label lblSold;
    private Label lblHeld;
    private ToolTip seatToolTip;
}

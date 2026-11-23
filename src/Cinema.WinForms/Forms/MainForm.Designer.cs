using Cinema.WinForms.Features.Members;
using Cinema.WinForms.Features.ShiftManagement;
using Cinema.WinForms.Features.TicketSales;

namespace Cinema.WinForms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            picBrand?.Image?.Dispose();
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        layoutMain = new TableLayoutPanel();
        pnlNavigation = new Panel();
        pnlMenu = new Panel();
        menuNavigation = new ToolStrip();
        navTicketSales = new ToolStripButton();
        navTicketCheck = new ToolStripButton();
        navMembers = new ToolStripButton();
        navInvoices = new ToolStripButton();
        navShifts = new ToolStripButton();
        pnlRail = new Panel();
        pnlNavStripe = new Panel();
        pnlBrand = new Panel();
        picBrand = new PictureBox();
        lblBrand = new Label();
        layoutHeader = new TableLayoutPanel();
        lblOperator = new Label();
        lblClock = new Label();
        pnlHeaderDivider = new Panel();
        btnLogout = new Button();
        pnlWorkspace = new Panel();
        pnlTicketSales = new Panel();
        showtimeSelectionView = new ShowtimeSelectionView();
        seatSelectionView = new SeatSelectionView();
        concessionSelectionView = new ConcessionSelectionView();
        paymentView = new PaymentView();
        saleCompletionView = new SaleCompletionView();
        shiftManagementView = new ShiftManagementView();
        shiftHandoverView = new ShiftHandoverView();
        memberListView = new MemberListView();
        memberDetailsView = new MemberDetailsView();
        memberEditView = new MemberEditView();
        memberRegistrationView = new MemberRegistrationView();
        clockTimer = new System.Windows.Forms.Timer(components);
        layoutMain.SuspendLayout();
        pnlNavigation.SuspendLayout();
        pnlMenu.SuspendLayout();
        menuNavigation.SuspendLayout();
        pnlRail.SuspendLayout();
        pnlBrand.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picBrand).BeginInit();
        layoutHeader.SuspendLayout();
        pnlWorkspace.SuspendLayout();
        pnlTicketSales.SuspendLayout();
        SuspendLayout();
        // 
        // layoutMain
        // 
        layoutMain.ColumnCount = 2;
        layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 212F));
        layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMain.Controls.Add(pnlNavigation, 0, 0);
        layoutMain.Controls.Add(layoutHeader, 1, 0);
        layoutMain.Controls.Add(pnlWorkspace, 1, 1);
        layoutMain.Dock = DockStyle.Fill;
        layoutMain.Location = new Point(0, 0);
        layoutMain.Name = "layoutMain";
        layoutMain.RowCount = 2;
        layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMain.Size = new Size(1348, 782);
        layoutMain.TabIndex = 0;
        // 
        // pnlNavigation
        // 
        pnlNavigation.BackColor = Color.FromArgb(30, 41, 59);
        pnlNavigation.Controls.Add(pnlMenu);
        pnlNavigation.Controls.Add(pnlBrand);
        pnlNavigation.Dock = DockStyle.Fill;
        pnlNavigation.Location = new Point(0, 0);
        pnlNavigation.Margin = new Padding(0);
        pnlNavigation.Name = "pnlNavigation";
        layoutMain.SetRowSpan(pnlNavigation, 2);
        pnlNavigation.Size = new Size(212, 782);
        pnlNavigation.TabIndex = 0;
        // 
        // pnlMenu
        // 
        pnlMenu.Controls.Add(menuNavigation);
        pnlMenu.Controls.Add(pnlRail);
        pnlMenu.Dock = DockStyle.Top;
        pnlMenu.Location = new Point(0, 70);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new Size(212, 250);
        pnlMenu.TabIndex = 0;
        // 
        // menuNavigation
        // 
        menuNavigation.AccessibleName = "Điều hướng POS";
        menuNavigation.AutoSize = false;
        menuNavigation.BackColor = Color.FromArgb(30, 41, 59);
        menuNavigation.CanOverflow = false;
        menuNavigation.Dock = DockStyle.Fill;
        menuNavigation.Font = new Font("Segoe UI", 10F);
        menuNavigation.ForeColor = Color.FromArgb(241, 245, 249);
        menuNavigation.GripStyle = ToolStripGripStyle.Hidden;
        menuNavigation.ImageScalingSize = new Size(22, 22);
        menuNavigation.Items.AddRange(new ToolStripItem[] { navTicketSales, navTicketCheck, navMembers, navInvoices, navShifts });
        menuNavigation.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
        menuNavigation.Location = new Point(4, 0);
        menuNavigation.Name = "menuNavigation";
        menuNavigation.Padding = new Padding(0);
        menuNavigation.Size = new Size(208, 250);
        menuNavigation.TabIndex = 0;
        menuNavigation.SizeChanged += MenuNavigation_SizeChanged;
        // 
        // navTicketSales
        // 
        navTicketSales.AutoSize = false;
        navTicketSales.BackColor = Color.FromArgb(51, 65, 85);
        navTicketSales.ForeColor = Color.FromArgb(241, 245, 249);
        navTicketSales.Image = (Image)resources.GetObject("navTicketSales.Image");
        navTicketSales.ImageAlign = ContentAlignment.MiddleLeft;
        navTicketSales.Margin = new Padding(0);
        navTicketSales.Name = "navTicketSales";
        navTicketSales.Padding = new Padding(14, 0, 0, 0);
        navTicketSales.Size = new Size(208, 48);
        navTicketSales.Text = "Bán vé";
        navTicketSales.TextAlign = ContentAlignment.MiddleLeft;
        navTicketSales.Click += NavTicketSales_Click;
        // 
        // navTicketCheck
        // 
        navTicketCheck.AutoSize = false;
        navTicketCheck.Enabled = false;
        navTicketCheck.ForeColor = Color.FromArgb(241, 245, 249);
        navTicketCheck.Image = (Image)resources.GetObject("navTicketCheck.Image");
        navTicketCheck.ImageAlign = ContentAlignment.MiddleLeft;
        navTicketCheck.Margin = new Padding(0);
        navTicketCheck.Name = "navTicketCheck";
        navTicketCheck.Padding = new Padding(14, 0, 0, 0);
        navTicketCheck.Size = new Size(208, 48);
        navTicketCheck.Text = "Soát vé";
        navTicketCheck.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // navMembers
        // 
        navMembers.AutoSize = false;
        navMembers.ForeColor = Color.FromArgb(241, 245, 249);
        navMembers.Image = (Image)resources.GetObject("navMembers.Image");
        navMembers.ImageAlign = ContentAlignment.MiddleLeft;
        navMembers.Margin = new Padding(0);
        navMembers.Name = "navMembers";
        navMembers.Padding = new Padding(14, 0, 0, 0);
        navMembers.Size = new Size(208, 48);
        navMembers.Text = "Thành viên";
        navMembers.TextAlign = ContentAlignment.MiddleLeft;
        navMembers.Click += NavMembers_Click;
        // 
        // navInvoices
        // 
        navInvoices.AutoSize = false;
        navInvoices.Enabled = false;
        navInvoices.ForeColor = Color.FromArgb(241, 245, 249);
        navInvoices.Image = (Image)resources.GetObject("navInvoices.Image");
        navInvoices.ImageAlign = ContentAlignment.MiddleLeft;
        navInvoices.Margin = new Padding(0);
        navInvoices.Name = "navInvoices";
        navInvoices.Padding = new Padding(14, 0, 0, 0);
        navInvoices.Size = new Size(208, 48);
        navInvoices.Text = "Hóa đơn && Hủy vé";
        navInvoices.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // navShifts
        // 
        navShifts.AutoSize = false;
        navShifts.ForeColor = Color.FromArgb(241, 245, 249);
        navShifts.Image = (Image)resources.GetObject("navShifts.Image");
        navShifts.ImageAlign = ContentAlignment.MiddleLeft;
        navShifts.Margin = new Padding(0);
        navShifts.Name = "navShifts";
        navShifts.Padding = new Padding(14, 0, 0, 0);
        navShifts.Size = new Size(208, 48);
        navShifts.Text = "Quản lý ca";
        navShifts.TextAlign = ContentAlignment.MiddleLeft;
        navShifts.Click += NavShifts_Click;
        // 
        // pnlRail
        // 
        pnlRail.Controls.Add(pnlNavStripe);
        pnlRail.Dock = DockStyle.Left;
        pnlRail.Location = new Point(0, 0);
        pnlRail.Name = "pnlRail";
        pnlRail.Size = new Size(4, 250);
        pnlRail.TabIndex = 1;
        // 
        // pnlNavStripe
        // 
        pnlNavStripe.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        pnlNavStripe.BackColor = Color.FromArgb(59, 130, 246);
        pnlNavStripe.Location = new Point(0, 0);
        pnlNavStripe.Name = "pnlNavStripe";
        pnlNavStripe.Size = new Size(4, 48);
        pnlNavStripe.TabIndex = 0;
        // 
        // pnlBrand
        // 
        pnlBrand.Controls.Add(lblBrand);
        pnlBrand.Controls.Add(picBrand);
        pnlBrand.Dock = DockStyle.Top;
        pnlBrand.Location = new Point(0, 0);
        pnlBrand.Name = "pnlBrand";
        pnlBrand.Size = new Size(212, 70);
        pnlBrand.TabIndex = 1;
        // 
        // picBrand
        // 
        picBrand.AccessibleName = "Logo STORYLINE";
        picBrand.Image = (Image)resources.GetObject("picBrand.Image");
        picBrand.Location = new Point(14, 12);
        picBrand.Name = "picBrand";
        picBrand.Size = new Size(46, 46);
        picBrand.SizeMode = PictureBoxSizeMode.Zoom;
        picBrand.TabIndex = 0;
        picBrand.TabStop = false;
        //
        // lblBrand
        //
        lblBrand.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        lblBrand.ForeColor = Color.FromArgb(241, 245, 249);
        lblBrand.Location = new Point(62, 12);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(144, 46);
        lblBrand.TabIndex = 1;
        lblBrand.Text = "STORYLINE";
        lblBrand.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // layoutHeader
        // 
        layoutHeader.BackColor = Color.White;
        layoutHeader.ColumnCount = 4;
        layoutHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        layoutHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
        layoutHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
        layoutHeader.Controls.Add(lblOperator, 0, 0);
        layoutHeader.Controls.Add(lblClock, 1, 0);
        layoutHeader.Controls.Add(pnlHeaderDivider, 2, 0);
        layoutHeader.Controls.Add(btnLogout, 3, 0);
        layoutHeader.Dock = DockStyle.Fill;
        layoutHeader.Location = new Point(212, 0);
        layoutHeader.Margin = new Padding(0);
        layoutHeader.Name = "layoutHeader";
        layoutHeader.Padding = new Padding(20, 0, 20, 0);
        layoutHeader.RowCount = 1;
        layoutHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeader.Size = new Size(1136, 52);
        layoutHeader.TabIndex = 0;
        // 
        // lblOperator
        // 
        lblOperator.Dock = DockStyle.Fill;
        lblOperator.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblOperator.Location = new Point(20, 0);
        lblOperator.Margin = new Padding(0);
        lblOperator.Name = "lblOperator";
        lblOperator.Size = new Size(898, 52);
        lblOperator.TabIndex = 0;
        lblOperator.TextAlign = ContentAlignment.MiddleLeft;
        lblOperator.Click += lblOperator_Click;
        // 
        // lblClock
        // 
        lblClock.AccessibleName = "Giờ địa phương";
        lblClock.Dock = DockStyle.Fill;
        lblClock.ForeColor = Color.FromArgb(51, 65, 85);
        lblClock.Location = new Point(918, 0);
        lblClock.Margin = new Padding(0);
        lblClock.Name = "lblClock";
        lblClock.Size = new Size(92, 52);
        lblClock.TabIndex = 1;
        lblClock.TextAlign = ContentAlignment.MiddleCenter;
        //
        // pnlHeaderDivider
        //
        pnlHeaderDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlHeaderDivider.Dock = DockStyle.Fill;
        pnlHeaderDivider.Location = new Point(1010, 15);
        pnlHeaderDivider.Margin = new Padding(0, 15, 0, 15);
        pnlHeaderDivider.Name = "pnlHeaderDivider";
        pnlHeaderDivider.Size = new Size(1, 22);
        pnlHeaderDivider.TabIndex = 2;
        // 
        // btnLogout
        // 
        btnLogout.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnLogout.BackColor = Color.White;
        btnLogout.Enabled = false;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.Location = new Point(1011, 9);
        btnLogout.Margin = new Padding(0);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(105, 34);
        btnLogout.TabIndex = 3;
        btnLogout.Text = "Đăng xuất";
        btnLogout.UseVisualStyleBackColor = false;
        // 
        // pnlWorkspace
        //
        pnlWorkspace.Controls.Add(pnlTicketSales);
        pnlWorkspace.Controls.Add(shiftManagementView);
        pnlWorkspace.Controls.Add(shiftHandoverView);
        pnlWorkspace.Controls.Add(memberListView);
        pnlWorkspace.Controls.Add(memberDetailsView);
        pnlWorkspace.Controls.Add(memberEditView);
        pnlWorkspace.Controls.Add(memberRegistrationView);
        pnlWorkspace.Dock = DockStyle.Fill;
        pnlWorkspace.Location = new Point(212, 52);
        pnlWorkspace.Margin = Padding.Empty;
        pnlWorkspace.Name = "pnlWorkspace";
        pnlWorkspace.Size = new Size(1136, 730);
        pnlWorkspace.TabIndex = 1;
        //
        // pnlTicketSales
        // 
        pnlTicketSales.Controls.Add(showtimeSelectionView);
        pnlTicketSales.Controls.Add(seatSelectionView);
        pnlTicketSales.Controls.Add(concessionSelectionView);
        pnlTicketSales.Controls.Add(paymentView);
        pnlTicketSales.Controls.Add(saleCompletionView);
        pnlTicketSales.Dock = DockStyle.Fill;
        pnlTicketSales.Location = Point.Empty;
        pnlTicketSales.Margin = Padding.Empty;
        pnlTicketSales.Name = "pnlTicketSales";
        pnlTicketSales.Size = new Size(1136, 730);
        pnlTicketSales.TabIndex = 1;
        // 
        // showtimeSelectionView
        // 
        showtimeSelectionView.BackColor = Color.FromArgb(241, 245, 249);
        showtimeSelectionView.Dock = DockStyle.Fill;
        showtimeSelectionView.Font = new Font("Segoe UI", 10F);
        showtimeSelectionView.ForeColor = Color.FromArgb(15, 23, 42);
        showtimeSelectionView.Location = Point.Empty;
        showtimeSelectionView.Margin = new Padding(0);
        showtimeSelectionView.Name = "showtimeSelectionView";
        showtimeSelectionView.Size = new Size(1136, 730);
        showtimeSelectionView.TabIndex = 1;
        // 
        // seatSelectionView
        // 
        seatSelectionView.Dock = DockStyle.Fill;
        seatSelectionView.Location = Point.Empty;
        seatSelectionView.Margin = Padding.Empty;
        seatSelectionView.Name = "seatSelectionView";
        seatSelectionView.Size = new Size(1136, 730);
        seatSelectionView.TabIndex = 2;
        seatSelectionView.Visible = false;
        //
        // concessionSelectionView
        //
        concessionSelectionView.Dock = DockStyle.Fill;
        concessionSelectionView.Location = Point.Empty;
        concessionSelectionView.Margin = Padding.Empty;
        concessionSelectionView.Name = "concessionSelectionView";
        concessionSelectionView.Size = new Size(1136, 730);
        concessionSelectionView.TabIndex = 3;
        concessionSelectionView.Visible = false;
        //
        // paymentView
        //
        paymentView.Dock = DockStyle.Fill;
        paymentView.Location = Point.Empty;
        paymentView.Margin = Padding.Empty;
        paymentView.Name = "paymentView";
        paymentView.Size = new Size(1136, 730);
        paymentView.TabIndex = 4;
        paymentView.Visible = false;
        // 
        // saleCompletionView
        // 
        saleCompletionView.Dock = DockStyle.Fill;
        saleCompletionView.Location = Point.Empty;
        saleCompletionView.Margin = Padding.Empty;
        saleCompletionView.Name = "saleCompletionView";
        saleCompletionView.Size = new Size(1136, 730);
        saleCompletionView.TabIndex = 5;
        saleCompletionView.Visible = false;
        //
        // shiftManagementView
        //
        shiftManagementView.Dock = DockStyle.Fill;
        shiftManagementView.Location = Point.Empty;
        shiftManagementView.Margin = Padding.Empty;
        shiftManagementView.Name = "shiftManagementView";
        shiftManagementView.Size = new Size(1136, 730);
        shiftManagementView.TabIndex = 1;
        shiftManagementView.Visible = false;
        //
        // shiftHandoverView
        //
        shiftHandoverView.Dock = DockStyle.Fill;
        shiftHandoverView.Location = Point.Empty;
        shiftHandoverView.Margin = Padding.Empty;
        shiftHandoverView.Name = "shiftHandoverView";
        shiftHandoverView.Size = new Size(1136, 730);
        shiftHandoverView.TabIndex = 2;
        shiftHandoverView.Visible = false;
        //
        // memberListView
        //
        memberListView.Dock = DockStyle.Fill;
        memberListView.Location = Point.Empty;
        memberListView.Margin = Padding.Empty;
        memberListView.Name = "memberListView";
        memberListView.Size = new Size(1136, 730);
        memberListView.TabIndex = 3;
        memberListView.Visible = false;
        //
        // memberDetailsView
        //
        memberDetailsView.Dock = DockStyle.Fill;
        memberDetailsView.Location = Point.Empty;
        memberDetailsView.Margin = Padding.Empty;
        memberDetailsView.Name = "memberDetailsView";
        memberDetailsView.Size = new Size(1136, 730);
        memberDetailsView.TabIndex = 4;
        memberDetailsView.Visible = false;
        //
        // memberEditView
        //
        memberEditView.Dock = DockStyle.Fill;
        memberEditView.Location = Point.Empty;
        memberEditView.Margin = Padding.Empty;
        memberEditView.Name = "memberEditView";
        memberEditView.Size = new Size(1136, 730);
        memberEditView.TabIndex = 5;
        memberEditView.Visible = false;
        //
        // memberRegistrationView
        //
        memberRegistrationView.Dock = DockStyle.Fill;
        memberRegistrationView.Location = Point.Empty;
        memberRegistrationView.Margin = Padding.Empty;
        memberRegistrationView.Name = "memberRegistrationView";
        memberRegistrationView.Size = new Size(1136, 730);
        memberRegistrationView.TabIndex = 6;
        memberRegistrationView.Visible = false;
        // 
        // clockTimer
        // 
        clockTimer.Interval = 1000;
        clockTimer.Tick += ClockTimer_Tick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        ClientSize = new Size(1348, 782);
        Controls.Add(layoutMain);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        MinimumSize = new Size(850, 620);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "STORYLINE · Cinema POS";
        layoutMain.ResumeLayout(false);
        pnlNavigation.ResumeLayout(false);
        pnlMenu.ResumeLayout(false);
        menuNavigation.ResumeLayout(false);
        menuNavigation.PerformLayout();
        pnlRail.ResumeLayout(false);
        pnlBrand.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picBrand).EndInit();
        layoutHeader.ResumeLayout(false);
        pnlTicketSales.ResumeLayout(false);
        pnlWorkspace.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutMain;
    private Panel pnlNavigation;
    private Panel pnlBrand;
    private PictureBox picBrand;
    private Label lblBrand;
    private Panel pnlMenu;
    private Panel pnlRail;
    private Panel pnlNavStripe;
    private ToolStrip menuNavigation;
    private ToolStripButton navTicketSales;
    private ToolStripButton navTicketCheck;
    private ToolStripButton navMembers;
    private ToolStripButton navInvoices;
    private ToolStripButton navShifts;
    private TableLayoutPanel layoutHeader;
    private Label lblOperator;
    private Label lblClock;
    private Panel pnlHeaderDivider;
    private Button btnLogout;
    private Panel pnlWorkspace;
    private Panel pnlTicketSales;
    private ShowtimeSelectionView showtimeSelectionView;
    private SeatSelectionView seatSelectionView;
    private ConcessionSelectionView concessionSelectionView;
    private PaymentView paymentView;
    private SaleCompletionView saleCompletionView;
    private ShiftManagementView shiftManagementView;
    private ShiftHandoverView shiftHandoverView;
    private MemberListView memberListView;
    private MemberDetailsView memberDetailsView;
    private MemberEditView memberEditView;
    private MemberRegistrationView memberRegistrationView;
    private System.Windows.Forms.Timer clockTimer;
}

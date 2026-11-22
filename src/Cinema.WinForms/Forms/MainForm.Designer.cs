namespace Cinema.WinForms.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel brand;
        private System.Windows.Forms.Label logo;
        private System.Windows.Forms.Label roleTop;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnMenu1;
        private System.Windows.Forms.Button btnMenu2;
        private System.Windows.Forms.Button btnMenu3;
        private System.Windows.Forms.Button btnMenu4;
        private System.Windows.Forms.Button btnMenu5;
        private System.Windows.Forms.Button btnMenu6;
        private System.Windows.Forms.Panel bottomBox;
        private System.Windows.Forms.Label lblBottomTitle;
        private System.Windows.Forms.Label lblBottomStatus;
        private System.Windows.Forms.Panel activeIndicator;
        private System.Windows.Forms.Panel topbar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBell;
        private System.Windows.Forms.Label lblBadge;
        // btnEmergency removed - integrated into bell click (issue 2)
        private System.Windows.Forms.Panel contentHost;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusLeft;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.sidebar = new System.Windows.Forms.Panel();
            this.brand = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.Label();
            this.roleTop = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnMenu1 = new System.Windows.Forms.Button();
            this.btnMenu2 = new System.Windows.Forms.Button();
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.btnMenu5 = new System.Windows.Forms.Button();
            this.btnMenu6 = new System.Windows.Forms.Button();
            this.bottomBox = new System.Windows.Forms.Panel();
            this.lblBottomTitle = new System.Windows.Forms.Label();
            this.lblBottomStatus = new System.Windows.Forms.Label();
            this.activeIndicator = new System.Windows.Forms.Panel();
            this.topbar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBell = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            // btnEmergency removed
            this.contentHost = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.sidebar.SuspendLayout();
            this.brand.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.bottomBox.SuspendLayout();
            this.topbar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.sidebar.Controls.Add(this.activeIndicator);
            this.sidebar.Controls.Add(this.menuPanel);
            this.sidebar.Controls.Add(this.bottomBox);
            this.sidebar.Controls.Add(this.brand);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(250, 820);
            this.sidebar.TabIndex = 2;
            // 
            // brand
            // 
            this.brand.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.brand.Controls.Add(this.roleTop);
            this.brand.Controls.Add(this.logo);
            this.brand.Dock = System.Windows.Forms.DockStyle.Top;
            this.brand.Location = new System.Drawing.Point(0, 0);
            this.brand.Name = "brand";
            this.brand.Size = new System.Drawing.Size(250, 86);
            this.brand.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.logo.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(250, 50);
            this.logo.TabIndex = 0;
            this.logo.Text = "🎬  CINEMA MANAGER";
            this.logo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // roleTop
            // 
            this.roleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.roleTop.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.roleTop.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.roleTop.Location = new System.Drawing.Point(0, 50);
            this.roleTop.Name = "roleTop";
            this.roleTop.Size = new System.Drawing.Size(250, 24);
            this.roleTop.TabIndex = 1;
            this.roleTop.Text = "Hệ thống quản lý nội bộ";
            this.roleTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.btnMenu6);
            this.menuPanel.Controls.Add(this.btnMenu5);
            this.menuPanel.Controls.Add(this.btnMenu4);
            this.menuPanel.Controls.Add(this.btnMenu3);
            this.menuPanel.Controls.Add(this.btnMenu2);
            this.menuPanel.Controls.Add(this.btnMenu1);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 86);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuPanel.Size = new System.Drawing.Size(250, 660);
            this.menuPanel.TabIndex = 1;
            // 
            // btnMenu1
            // 
            this.btnMenu1.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnMenu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu1.FlatAppearance.BorderSize = 0;
            this.btnMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 53, 73);
            this.btnMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu1.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnMenu1.Location = new System.Drawing.Point(0, 8);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenu1.Size = new System.Drawing.Size(250, 46);
            this.btnMenu1.TabIndex = 0;
            this.btnMenu1.Text = "  1. B\u00E1o c\u00E1o && Dashboard";
            this.btnMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu1.UseVisualStyleBackColor = false;
            // 
            // btnMenu2
            // 
            this.btnMenu2.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnMenu2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu2.FlatAppearance.BorderSize = 0;
            this.btnMenu2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 53, 73);
            this.btnMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu2.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnMenu2.Location = new System.Drawing.Point(0, 56);
            this.btnMenu2.Name = "btnMenu2";
            this.btnMenu2.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenu2.Size = new System.Drawing.Size(250, 46);
            this.btnMenu2.TabIndex = 1;
            this.btnMenu2.Text = "  2. Phim && Ph\u00F2ng chi\u1EBFu";
            this.btnMenu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu2.UseVisualStyleBackColor = false;
            // 
            // btnMenu3
            // 
            this.btnMenu3.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnMenu3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu3.FlatAppearance.BorderSize = 0;
            this.btnMenu3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 53, 73);
            this.btnMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu3.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnMenu3.Location = new System.Drawing.Point(0, 104);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenu3.Size = new System.Drawing.Size(250, 46);
            this.btnMenu3.TabIndex = 2;
            this.btnMenu3.Text = "  3. L\u1ECBch chi\u1EBFu && Gi\u00E1 v\u00E9";
            this.btnMenu3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu3.UseVisualStyleBackColor = false;
            // 
            // btnMenu4
            // 
            this.btnMenu4.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnMenu4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu4.FlatAppearance.BorderSize = 0;
            this.btnMenu4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 53, 73);
            this.btnMenu4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu4.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnMenu4.Location = new System.Drawing.Point(0, 152);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenu4.Size = new System.Drawing.Size(250, 46);
            this.btnMenu4.TabIndex = 3;
            this.btnMenu4.Text = "  4. B\u1EAFp n\u01B0\u1EDBc && Kho (F&&B)";
            this.btnMenu4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu4.UseVisualStyleBackColor = false;
            // 
            // btnMenu5
            // 
            this.btnMenu5.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnMenu5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu5.FlatAppearance.BorderSize = 0;
            this.btnMenu5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 53, 73);
            this.btnMenu5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu5.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnMenu5.Location = new System.Drawing.Point(0, 200);
            this.btnMenu5.Name = "btnMenu5";
            this.btnMenu5.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenu5.Size = new System.Drawing.Size(250, 46);
            this.btnMenu5.TabIndex = 4;
            this.btnMenu5.Text = "  5. Đối soát ca làm";
            this.btnMenu5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu5.UseVisualStyleBackColor = false;
            // 
            // btnMenu6
            // 
            this.btnMenu6.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnMenu6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu6.FlatAppearance.BorderSize = 0;
            this.btnMenu6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 53, 73);
            this.btnMenu6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu6.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnMenu6.Location = new System.Drawing.Point(0, 248);
            this.btnMenu6.Name = "btnMenu6";
            this.btnMenu6.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenu6.Size = new System.Drawing.Size(250, 46);
            this.btnMenu6.TabIndex = 5;
            this.btnMenu6.Text = "  6. Th\u00E0nh vi\u00EAn && Kh\u00E1ch";
            this.btnMenu6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu6.UseVisualStyleBackColor = false;
            // 
            // bottomBox
            // 
            this.bottomBox.BackColor = System.Drawing.Color.FromArgb(22, 32, 51);
            this.bottomBox.Controls.Add(this.lblBottomStatus);
            this.bottomBox.Controls.Add(this.lblBottomTitle);
            this.bottomBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBox.Location = new System.Drawing.Point(0, 746);
            this.bottomBox.Name = "bottomBox";
            this.bottomBox.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.bottomBox.Size = new System.Drawing.Size(250, 74);
            this.bottomBox.TabIndex = 2;
            // 
            // lblBottomTitle
            // 
            this.lblBottomTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBottomTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBottomTitle.ForeColor = System.Drawing.Color.White;
            this.lblBottomTitle.Location = new System.Drawing.Point(14, 10);
            this.lblBottomTitle.Name = "lblBottomTitle";
            this.lblBottomTitle.Size = new System.Drawing.Size(222, 24);
            this.lblBottomTitle.TabIndex = 0;
            this.lblBottomTitle.Text = "Quản Lý Rạp";
            // 
            // lblBottomStatus
            // 
            this.lblBottomStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBottomStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBottomStatus.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBottomStatus.Location = new System.Drawing.Point(14, 34);
            this.lblBottomStatus.Name = "lblBottomStatus";
            this.lblBottomStatus.Size = new System.Drawing.Size(222, 20);
            this.lblBottomStatus.TabIndex = 1;
            this.lblBottomStatus.Text = "● Đang trực ca";
            // 
            // activeIndicator
            // 
            this.activeIndicator.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.activeIndicator.Location = new System.Drawing.Point(0, 94);
            this.activeIndicator.Name = "activeIndicator";
            this.activeIndicator.Size = new System.Drawing.Size(4, 46);
            this.activeIndicator.TabIndex = 3;
            this.activeIndicator.Visible = false;
            // 
            // topbar
            // 
            this.topbar.BackColor = System.Drawing.Color.White;
            this.topbar.Controls.Add(this.lblBadge);
            this.topbar.Controls.Add(this.lblBell);
            this.topbar.Controls.Add(this.lblTitle);
            this.topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topbar.Location = new System.Drawing.Point(250, 0);
            this.topbar.Name = "topbar";
            this.topbar.Size = new System.Drawing.Size(1150, 58);
            this.topbar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(381, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hệ thống Quản lý Rạp Chiếu Phim Nội bộ";
            // 
            // lblBell
            // 
            this.lblBell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBell.AutoSize = true;
            this.lblBell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBell.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblBell.Location = new System.Drawing.Point(1080, 14);
            this.lblBell.Name = "lblBell";
            this.lblBell.Size = new System.Drawing.Size(32, 25);
            this.lblBell.TabIndex = 1;
            this.lblBell.Text = "🔔";
            // 
            // lblBadge
            // 
            this.lblBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblBadge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.Location = new System.Drawing.Point(1102, 8);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(20, 20);
            this.lblBadge.TabIndex = 2;
            this.lblBadge.Text = "3";
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentHost
            // 
            this.contentHost.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.contentHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentHost.Location = new System.Drawing.Point(250, 58);
            this.contentHost.Name = "contentHost";
            this.contentHost.Padding = new System.Windows.Forms.Padding(24);
            this.contentHost.Size = new System.Drawing.Size(1150, 740);
            this.contentHost.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusLeft,
            this.lblStatusTime});
            this.statusStrip.Location = new System.Drawing.Point(250, 798);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1150, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Text = "Tr\u1EA1ng th\u00E1i: S\u1EB5n s\u00E0ng (UI Preview Mode)  |  T\u00E0i kho\u1EA3n: Qu\u1EA3n L\u00FD R\u1EA1p";
            // 
            // lblStatusTime
            // 
            this.lblStatusTime.Name = "lblStatusTime";
            this.lblStatusTime.Spring = true;
            this.lblStatusTime.Text = "";
            this.lblStatusTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1400, 820);
            this.Controls.Add(this.contentHost);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.topbar);
            this.Controls.Add(this.sidebar);
            // WinForms docking: higher index docks first, index 0 docks last (Fill).
            this.Controls.SetChildIndex(this.sidebar, 3);
            this.Controls.SetChildIndex(this.topbar, 2);
            this.Controls.SetChildIndex(this.statusStrip, 1);
            this.Controls.SetChildIndex(this.contentHost, 0);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1400, 820);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Rạp Chiếu Phim Nội bộ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.sidebar.ResumeLayout(false);
            this.brand.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.bottomBox.ResumeLayout(false);
            this.topbar.ResumeLayout(false);
            this.topbar.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
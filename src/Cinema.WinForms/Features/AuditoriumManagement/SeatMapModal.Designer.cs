namespace Cinema.WinForms.Features.AuditoriumManagement
{
    partial class SeatMapModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel screenAccent;
        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Panel toolbar;
        private System.Windows.Forms.Label lblTool;
        private System.Windows.Forms.Button btnToolNormal;
        private System.Windows.Forms.Button btnToolVip;
        private System.Windows.Forms.Button btnToolCouple;
        private System.Windows.Forms.Button btnToolLock;
        private System.Windows.Forms.Panel seatPanel;
        private System.Windows.Forms.Panel legendPanel;
        private System.Windows.Forms.Panel l1c; private System.Windows.Forms.Label l1t;
        private System.Windows.Forms.Panel l2c; private System.Windows.Forms.Label l2t;
        private System.Windows.Forms.Panel l3c; private System.Windows.Forms.Label l3t;
        private System.Windows.Forms.Panel l4c; private System.Windows.Forms.Label l4t;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.screenAccent = new System.Windows.Forms.Panel();
            this.screen = new System.Windows.Forms.Panel();
            this.lblScreen = new System.Windows.Forms.Label();
            this.toolbar = new System.Windows.Forms.Panel();
            this.lblTool = new System.Windows.Forms.Label();
            this.btnToolNormal = new System.Windows.Forms.Button();
            this.btnToolVip = new System.Windows.Forms.Button();
            this.btnToolCouple = new System.Windows.Forms.Button();
            this.btnToolLock = new System.Windows.Forms.Button();
            this.seatPanel = new System.Windows.Forms.Panel();
            this.legendPanel = new System.Windows.Forms.Panel();
            this.l1c = new System.Windows.Forms.Panel(); this.l1t = new System.Windows.Forms.Label();
            this.l2c = new System.Windows.Forms.Panel(); this.l2t = new System.Windows.Forms.Label();
            this.l3c = new System.Windows.Forms.Panel(); this.l3t = new System.Windows.Forms.Label();
            this.l4c = new System.Windows.Forms.Panel(); this.l4t = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.screen.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.legendPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeatMapModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(984, 600);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.legendPanel);
            this.Controls.Add(this.seatPanel);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.screenAccent);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeatMapModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S\u01A1 \u0111\u1ED3 gh\u1EBF";
            // 
            // screenAccent
            // 
            this.screenAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.screenAccent.Location = new System.Drawing.Point(180, 16);
            this.screenAccent.Name = "screenAccent";
            this.screenAccent.Size = new System.Drawing.Size(620, 4);
            this.screenAccent.TabIndex = 10;
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.screen.Controls.Add(this.lblScreen);
            this.screen.Location = new System.Drawing.Point(180, 20);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(620, 34);
            this.screen.TabIndex = 0;
            // 
            // lblScreen
            // 
            this.lblScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScreen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScreen.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblScreen.Location = new System.Drawing.Point(0, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(620, 34);
            this.lblScreen.TabIndex = 0;
            this.lblScreen.Text = "M\u00C0N H\u00CCNH CHI\u1EBEU";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.White;
            this.toolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolbar.Controls.Add(this.btnToolLock);
            this.toolbar.Controls.Add(this.btnToolCouple);
            this.toolbar.Controls.Add(this.btnToolVip);
            this.toolbar.Controls.Add(this.btnToolNormal);
            this.toolbar.Controls.Add(this.lblTool);
            this.toolbar.Location = new System.Drawing.Point(20, 62);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(944, 52);
            this.toolbar.TabIndex = 1;
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTool.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTool.Location = new System.Drawing.Point(12, 16);
            this.lblTool.Name = "lblTool";
            this.lblTool.Text = "C\u1ECD lo\u1EA1i gh\u1EBF:";
            // 
            // btnToolNormal
            // 
            this.btnToolNormal.BackColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.btnToolNormal.FlatAppearance.BorderSize = 0;
            this.btnToolNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolNormal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToolNormal.ForeColor = System.Drawing.Color.White;
            this.btnToolNormal.Location = new System.Drawing.Point(110, 10);
            this.btnToolNormal.Name = "btnToolNormal";
            this.btnToolNormal.Size = new System.Drawing.Size(150, 32);
            this.btnToolNormal.TabIndex = 1;
            this.btnToolNormal.Text = "Gh\u1EBF Th\u01B0\u1EDDng - X\u00E1m";
            this.btnToolNormal.UseVisualStyleBackColor = false;
            // 
            // btnToolVip
            // 
            this.btnToolVip.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnToolVip.FlatAppearance.BorderSize = 0;
            this.btnToolVip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolVip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToolVip.ForeColor = System.Drawing.Color.White;
            this.btnToolVip.Location = new System.Drawing.Point(270, 10);
            this.btnToolVip.Name = "btnToolVip";
            this.btnToolVip.Size = new System.Drawing.Size(150, 32);
            this.btnToolVip.TabIndex = 2;
            this.btnToolVip.Text = "Gh\u1EBF VIP - Cam";
            this.btnToolVip.UseVisualStyleBackColor = false;
            // 
            // btnToolCouple
            // 
            this.btnToolCouple.BackColor = System.Drawing.Color.FromArgb(236, 72, 153);
            this.btnToolCouple.FlatAppearance.BorderSize = 0;
            this.btnToolCouple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolCouple.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToolCouple.ForeColor = System.Drawing.Color.White;
            this.btnToolCouple.Location = new System.Drawing.Point(430, 10);
            this.btnToolCouple.Name = "btnToolCouple";
            this.btnToolCouple.Size = new System.Drawing.Size(150, 32);
            this.btnToolCouple.TabIndex = 3;
            this.btnToolCouple.Text = "Gh\u1EBF \u0110\u00F4i - H\u1ED3ng";
            this.btnToolCouple.UseVisualStyleBackColor = false;
            // 
            // btnToolLock
            // 
            this.btnToolLock.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.btnToolLock.FlatAppearance.BorderSize = 0;
            this.btnToolLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToolLock.ForeColor = System.Drawing.Color.White;
            this.btnToolLock.Location = new System.Drawing.Point(590, 10);
            this.btnToolLock.Name = "btnToolLock";
            this.btnToolLock.Size = new System.Drawing.Size(180, 32);
            this.btnToolLock.TabIndex = 4;
            this.btnToolLock.Text = "Gh\u1EBF Kh\u00F3a/B\u1EA3o Tr\u00EC - \u0110en";
            this.btnToolLock.UseVisualStyleBackColor = false;
            // 
            // seatPanel
            // 
            this.seatPanel.BackColor = System.Drawing.Color.White;
            this.seatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seatPanel.Location = new System.Drawing.Point(20, 124);
            this.seatPanel.Name = "seatPanel";
            this.seatPanel.Size = new System.Drawing.Size(944, 400);
            this.seatPanel.TabIndex = 2;
            // 
            // legendPanel
            // 
            this.legendPanel.Controls.Add(this.l4t); this.legendPanel.Controls.Add(this.l4c);
            this.legendPanel.Controls.Add(this.l3t); this.legendPanel.Controls.Add(this.l3c);
            this.legendPanel.Controls.Add(this.l2t); this.legendPanel.Controls.Add(this.l2c);
            this.legendPanel.Controls.Add(this.l1t); this.legendPanel.Controls.Add(this.l1c);
            this.legendPanel.Location = new System.Drawing.Point(20, 532);
            this.legendPanel.Name = "legendPanel";
            this.legendPanel.Size = new System.Drawing.Size(700, 30);
            this.legendPanel.TabIndex = 3;
            this.l1c.BackColor = System.Drawing.Color.FromArgb(156, 163, 175); this.l1c.Location = new System.Drawing.Point(0, 6); this.l1c.Size = new System.Drawing.Size(16, 16);
            this.l1t.AutoSize = true; this.l1t.Location = new System.Drawing.Point(22, 5); this.l1t.Text = "Gh\u1EBF Th\u01B0\u1EDDng"; this.l1t.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.l2c.BackColor = System.Drawing.Color.FromArgb(217, 119, 6); this.l2c.Location = new System.Drawing.Point(140, 6); this.l2c.Size = new System.Drawing.Size(16, 16);
            this.l2t.AutoSize = true; this.l2t.Location = new System.Drawing.Point(162, 5); this.l2t.Text = "VIP"; this.l2t.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.l3c.BackColor = System.Drawing.Color.FromArgb(236, 72, 153); this.l3c.Location = new System.Drawing.Point(220, 6); this.l3c.Size = new System.Drawing.Size(16, 16);
            this.l3t.AutoSize = true; this.l3t.Location = new System.Drawing.Point(242, 5); this.l3t.Text = "Gh\u1EBF \u0110\u00F4i"; this.l3t.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.l4c.BackColor = System.Drawing.Color.FromArgb(17, 24, 39); this.l4c.Location = new System.Drawing.Point(330, 6); this.l4c.Size = new System.Drawing.Size(16, 16);
            this.l4t.AutoSize = true; this.l4t.Location = new System.Drawing.Point(352, 5); this.l4t.Text = "Kh\u00F3a/B\u1EA3o tr\u00EC"; this.l4t.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(834, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "L\u01B0u S\u01A1 \u0110\u1ED3";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            this.screen.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.legendPanel.ResumeLayout(false);
            this.legendPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

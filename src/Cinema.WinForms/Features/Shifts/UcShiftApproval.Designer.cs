namespace Cinema.WinForms.Features.Shifts
{
    partial class UcShiftApproval
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Panel leftCard;
        private System.Windows.Forms.Label lblLeftTitle;
        private System.Windows.Forms.DataGridView gridShifts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel rightCard;
        private System.Windows.Forms.Label lblRightTitle;
        private System.Windows.Forms.Panel info1; private System.Windows.Forms.Label info1Lbl; private System.Windows.Forms.Label info1Val;
        private System.Windows.Forms.Panel info2; private System.Windows.Forms.Label info2Lbl; private System.Windows.Forms.Label info2Val;
        private System.Windows.Forms.Panel info3; private System.Windows.Forms.Label info3Lbl; private System.Windows.Forms.Label info3Val;
        private System.Windows.Forms.Panel info4; private System.Windows.Forms.Label info4Lbl; private System.Windows.Forms.Label info4Val;
        private System.Windows.Forms.Panel line1; private System.Windows.Forms.Label line1Lbl; private System.Windows.Forms.Label line1Val;
        private System.Windows.Forms.Panel line2; private System.Windows.Forms.Label line2Lbl; private System.Windows.Forms.Label line2Val;
        private System.Windows.Forms.Panel line3; private System.Windows.Forms.Label line3Lbl; private System.Windows.Forms.Label line3Val;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.split = new System.Windows.Forms.SplitContainer();
            this.leftCard = new System.Windows.Forms.Panel();
            this.lblLeftTitle = new System.Windows.Forms.Label();
            this.gridShifts = new System.Windows.Forms.DataGridView();
            this.colCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightCard = new System.Windows.Forms.Panel();
            this.lblRightTitle = new System.Windows.Forms.Label();
            this.info1 = new System.Windows.Forms.Panel(); this.info1Lbl = new System.Windows.Forms.Label(); this.info1Val = new System.Windows.Forms.Label();
            this.info2 = new System.Windows.Forms.Panel(); this.info2Lbl = new System.Windows.Forms.Label(); this.info2Val = new System.Windows.Forms.Label();
            this.info3 = new System.Windows.Forms.Panel(); this.info3Lbl = new System.Windows.Forms.Label(); this.info3Val = new System.Windows.Forms.Label();
            this.info4 = new System.Windows.Forms.Panel(); this.info4Lbl = new System.Windows.Forms.Label(); this.info4Val = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Panel(); this.line1Lbl = new System.Windows.Forms.Label(); this.line1Val = new System.Windows.Forms.Label();
            this.line2 = new System.Windows.Forms.Panel(); this.line2Lbl = new System.Windows.Forms.Label(); this.line2Val = new System.Windows.Forms.Label();
            this.line3 = new System.Windows.Forms.Panel(); this.line3Lbl = new System.Windows.Forms.Label(); this.line3Val = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.leftCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShifts)).BeginInit();
            this.rightCard.SuspendLayout();
            this.info1.SuspendLayout(); this.info2.SuspendLayout(); this.info3.SuspendLayout(); this.info4.SuspendLayout();
            this.line1.SuspendLayout(); this.line2.SuspendLayout(); this.line3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UcShiftApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.split);
            this.Controls.Add(this.pnlHeader);
            // Higher index docks first; Fill (split) must be index 0 (dock last)
            this.Controls.SetChildIndex(this.pnlHeader, 1);
            this.Controls.SetChildIndex(this.split, 0);
            this.Name = "UcShiftApproval";
            this.Size = new System.Drawing.Size(1100, 760);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "\u0110\u1ED1i so\u00E1t ca l\u00E0m";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(2, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Ki\u1EC3m tra ch\u00EAnh l\u1EC7ch ti\u1EC1n m\u1EB7t v\u00E0 duy\u1EC7t ch\u1ED1t ca thu ng\u00E2n.";
            // 
            // split
            // 
            this.split.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 64);
            this.split.Name = "split";
            this.split.Panel1.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.split.Panel1.Controls.Add(this.leftCard);
            this.split.Panel1.Padding = new System.Windows.Forms.Padding(12);
            this.split.Panel2.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.split.Panel2.Controls.Add(this.rightCard);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(12);
            this.split.Size = new System.Drawing.Size(1100, 696);
            this.split.SplitterDistance = 430;
            this.split.TabIndex = 1;
            // 
            // leftCard
            // 
            this.leftCard.BackColor = System.Drawing.Color.White;
            this.leftCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftCard.Controls.Add(this.gridShifts);
            this.leftCard.Controls.Add(this.lblLeftTitle);
            // Higher index docks first; Fill (gridShifts) must be index 0 (dock last)
            this.leftCard.Controls.SetChildIndex(this.lblLeftTitle, 1);
            this.leftCard.Controls.SetChildIndex(this.gridShifts, 0);
            this.leftCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftCard.Location = new System.Drawing.Point(0, 0);
            this.leftCard.Name = "leftCard";
            this.leftCard.Size = new System.Drawing.Size(422, 696);
            this.leftCard.TabIndex = 0;
            // 
            // lblLeftTitle
            // 
            this.lblLeftTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLeftTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblLeftTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLeftTitle.Name = "lblLeftTitle";
            this.lblLeftTitle.Padding = new System.Windows.Forms.Padding(12, 10, 12, 0);
            this.lblLeftTitle.Size = new System.Drawing.Size(420, 42);
            this.lblLeftTitle.TabIndex = 0;
            this.lblLeftTitle.Text = "H\u00E0ng \u0111\u1EE3i ch\u1ED1t ca";
            // 
            // gridShifts
            // 
            this.gridShifts.AllowUserToAddRows = false;
            this.gridShifts.AllowUserToResizeRows = false;
            this.gridShifts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridShifts.BackgroundColor = System.Drawing.Color.White;
            this.gridShifts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridShifts.ColumnHeadersHeight = 38;
            this.gridShifts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colCashier, this.colShift, this.colTime, this.colStatus });
            this.gridShifts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridShifts.EnableHeadersVisualStyles = false;
            this.gridShifts.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.gridShifts.Location = new System.Drawing.Point(0, 42);
            this.gridShifts.MultiSelect = false;
            this.gridShifts.Name = "gridShifts";
            this.gridShifts.ReadOnly = true;
            this.gridShifts.RowHeadersVisible = false;
            this.gridShifts.RowTemplate.Height = 34;
            this.gridShifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShifts.Size = new System.Drawing.Size(420, 652);
            this.gridShifts.TabIndex = 1;
            this.colCashier.HeaderText = "Thu Ng\u00E2n"; this.colCashier.Name = "colCashier"; this.colCashier.ReadOnly = true;
            this.colShift.HeaderText = "Ca Tr\u1EF1c"; this.colShift.Name = "colShift"; this.colShift.ReadOnly = true;
            this.colTime.HeaderText = "Gi\u1EDD G\u1EEDi"; this.colTime.Name = "colTime"; this.colTime.ReadOnly = true;
            this.colStatus.HeaderText = "Tr\u1EA1ng Th\u00E1i"; this.colStatus.Name = "colStatus"; this.colStatus.ReadOnly = true;
            // 
            // rightCard
            // 
            this.rightCard.BackColor = System.Drawing.Color.White;
            this.rightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightCard.Controls.Add(this.btnReject);
            this.rightCard.Controls.Add(this.btnApprove);
            this.rightCard.Controls.Add(this.lblNote);
            this.rightCard.Controls.Add(this.line3);
            this.rightCard.Controls.Add(this.line2);
            this.rightCard.Controls.Add(this.line1);
            this.rightCard.Controls.Add(this.info4);
            this.rightCard.Controls.Add(this.info3);
            this.rightCard.Controls.Add(this.info2);
            this.rightCard.Controls.Add(this.info1);
            this.rightCard.Controls.Add(this.lblRightTitle);
            this.rightCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightCard.Location = new System.Drawing.Point(12, 12);
            this.rightCard.Name = "rightCard";
            this.rightCard.Size = new System.Drawing.Size(638, 672);
            this.rightCard.TabIndex = 0;
            // 
            // lblRightTitle
            // 
            this.lblRightTitle.AutoSize = true;
            this.lblRightTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRightTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRightTitle.Location = new System.Drawing.Point(12, 10);
            this.lblRightTitle.Name = "lblRightTitle";
            this.lblRightTitle.Text = "H\u1ED3 s\u01A1 \u0111\u1ED1i so\u00E1t - NV-012 / Ca s\u00E1ng";
            this.SetupInfo(this.info1, this.info1Lbl, this.info1Val, 12, 55, "1. Ti\u1EC1n \u0111\u1EA7u ca", "500.000 \u0111", System.Drawing.Color.FromArgb(15, 23, 42));
            this.SetupInfo(this.info2, this.info2Lbl, this.info2Val, 162, 55, "2. Ti\u1EC1n m\u1EB7t v\u00E9 (+)", "4.250.000 \u0111", System.Drawing.Color.FromArgb(22, 163, 74));
            this.SetupInfo(this.info3, this.info3Lbl, this.info3Val, 312, 55, "3. Ti\u1EC1n m\u1EB7t F&&B (+)", "1.840.000 \u0111", System.Drawing.Color.FromArgb(22, 163, 74));
            this.SetupInfo(this.info4, this.info4Lbl, this.info4Val, 462, 55, "4. Ho\u00E0n tr\u1EA3 (-)", "120.000 \u0111", System.Drawing.Color.FromArgb(220, 38, 38));
            this.SetupLine(this.line1, this.line1Lbl, this.line1Val, 12, 160, "T\u1ED5ng ti\u1EC1n m\u1EB7t l\u00FD thuy\u1EBFt h\u1EC7 th\u1ED1ng:", "6.470.000 \u0111", System.Drawing.Color.FromArgb(15, 23, 42));
            this.SetupLine(this.line2, this.line2Lbl, this.line2Val, 12, 200, "Ti\u1EC1n m\u1EB7t th\u1EF1c t\u1EBF thu ng\u00E2n \u0111\u1EBFm:", "6.470.000 \u0111", System.Drawing.Color.FromArgb(15, 23, 42));
            this.SetupLine(this.line3, this.line3Lbl, this.line3Val, 12, 240, "Ch\u00EAnh l\u1EC7ch (Th\u1EF1c \u0111\u1EBFm - L\u00FD thuy\u1EBFt):", "0 \u0111 (Kh\u1EDBp k\u00E9t ho\u00E0n to\u00E0n)", System.Drawing.Color.FromArgb(22, 163, 74));
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNote.Location = new System.Drawing.Point(12, 292);
            this.lblNote.Name = "lblNote";
            this.lblNote.TabIndex = 11;
            this.lblNote.Text = "Ghi ch\u00FA thu ng\u00E2n: K\u00E9t ti\u1EC1n ki\u1EC3m \u0111\u1EBFm tr\u00F9ng kh\u1EDBp ho\u00E0n to\u00E0n.";
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(300, 324);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(150, 36);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Duy\u1EC7t Ch\u1ED1t Ca";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.Color.White;
            this.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnReject.FlatAppearance.BorderSize = 1;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnReject.Location = new System.Drawing.Point(460, 324);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(150, 36);
            this.btnReject.TabIndex = 10;
            this.btnReject.Text = "Y\u00EAu C\u1EA7u \u0110\u1EBFm L\u1EA1i";
            this.btnReject.UseVisualStyleBackColor = false;
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.leftCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridShifts)).EndInit();
            this.rightCard.ResumeLayout(false);
            this.rightCard.PerformLayout();
            this.info1.ResumeLayout(false); this.info2.ResumeLayout(false); this.info3.ResumeLayout(false); this.info4.ResumeLayout(false);
            this.line1.ResumeLayout(false); this.line1.PerformLayout(); this.line2.ResumeLayout(false); this.line2.PerformLayout(); this.line3.ResumeLayout(false); this.line3.PerformLayout();
            this.ResumeLayout(false);
        }

        private void SetupInfo(System.Windows.Forms.Panel p, System.Windows.Forms.Label lbl, System.Windows.Forms.Label val, int x, int y, string label, string value, System.Drawing.Color color)
        {
            p.BackColor = System.Drawing.Color.White;
            p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            p.Location = new System.Drawing.Point(x, y);
            p.Name = "info" + x;
            p.Size = new System.Drawing.Size(140, 80);
            lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lbl.Location = new System.Drawing.Point(8, 8);
            lbl.Size = new System.Drawing.Size(124, 30);
            lbl.Text = label;
            val.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            val.ForeColor = color;
            val.Location = new System.Drawing.Point(8, 42);
            val.Size = new System.Drawing.Size(124, 28);
            val.Text = value;
            p.Controls.Add(val);
            p.Controls.Add(lbl);
        }

        private void SetupLine(System.Windows.Forms.Panel p, System.Windows.Forms.Label lbl, System.Windows.Forms.Label val, int x, int y, string label, string value, System.Drawing.Color valueColor)
        {
            p.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            p.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            p.Location = new System.Drawing.Point(x, y);
            p.Name = "line" + y;
            p.Size = new System.Drawing.Size(600, 34);
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lbl.Location = new System.Drawing.Point(10, 7);
            lbl.Text = label;
            val.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            val.AutoSize = false;
            val.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            val.ForeColor = valueColor;
            val.Location = new System.Drawing.Point(340, 7);
            val.Size = new System.Drawing.Size(250, 20);
            val.Text = value;
            val.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            p.Controls.Add(val);
            p.Controls.Add(lbl);
        }
    }
}

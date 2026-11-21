namespace Cinema.WinForms.Manager
{
    partial class UcFnBConcession
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Button btnAddImport;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMenu;
        private System.Windows.Forms.TabPage tabHist;
        private System.Windows.Forms.DataGridView gridMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMPromo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMStock;
        private System.Windows.Forms.DataGridViewButtonColumn colMEdit;
        private System.Windows.Forms.DataGridView gridHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHBy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.btnAddImport = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMenu = new System.Windows.Forms.TabPage();
            this.tabHist = new System.Windows.Forms.TabPage();
            this.gridMenu = new System.Windows.Forms.DataGridView();
            this.colMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMPromo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gridHist = new System.Windows.Forms.DataGridView();
            this.colHCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabHist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHist)).BeginInit();
            this.SuspendLayout();
            // 
            // UcFnBConcession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnAddImport);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcFnBConcession";
            this.Size = new System.Drawing.Size(1100, 760);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Qu\u1EA3n l\u00FD B\u1EAFp n\u01B0\u1EDBc && T\u1ED3n kho (F&&B)";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(2, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Danh m\u1EE5c t\u00E1ch bi\u1EC7t theo 3 nh\u00E0 cung c\u1EA5p c\u1ED1 \u0111\u1ECBnh. \u0110i\u1EC1u ch\u1EC9nh gi\u00E1 b\u00E1n POS v\u00E0 t\u1EA1o phi\u1EBFu nh\u1EADp h\u00E0ng.";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSupplier.Location = new System.Drawing.Point(0, 62);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Text = "Nh\u00E0 cung c\u1EA5p:";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSupplier.Location = new System.Drawing.Point(110, 58);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(300, 25);
            this.cboSupplier.TabIndex = 1;
            // 
            // btnAddImport
            // 
            this.btnAddImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddImport.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnAddImport.FlatAppearance.BorderSize = 0;
            this.btnAddImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddImport.ForeColor = System.Drawing.Color.White;
            this.btnAddImport.Location = new System.Drawing.Point(900, 52);
            this.btnAddImport.Name = "btnAddImport";
            this.btnAddImport.Size = new System.Drawing.Size(180, 36);
            this.btnAddImport.TabIndex = 2;
            this.btnAddImport.Text = "+ T\u1EA1o Phi\u1EBFu Nh\u1EADp H\u00E0ng";
            this.btnAddImport.UseVisualStyleBackColor = false;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabMenu);
            this.tabs.Controls.Add(this.tabHist);
            this.tabs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabs.Location = new System.Drawing.Point(0, 96);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(14, 7);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1080, 540);
            this.tabs.TabIndex = 3;
            // 
            // tabMenu
            // 
            this.tabMenu.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tabMenu.Controls.Add(this.gridMenu);
            this.tabMenu.Location = new System.Drawing.Point(4, 34);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabMenu.Size = new System.Drawing.Size(1072, 502);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.Text = "Th\u1EF1c \u0110\u01A1n && Gi\u00E1 B\u00E1n";
            // 
            // tabHist
            // 
            this.tabHist.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tabHist.Controls.Add(this.gridHist);
            this.tabHist.Location = new System.Drawing.Point(4, 34);
            this.tabHist.Name = "tabHist";
            this.tabHist.Padding = new System.Windows.Forms.Padding(3);
            this.tabHist.Size = new System.Drawing.Size(1072, 502);
            this.tabHist.TabIndex = 1;
            this.tabHist.Text = "L\u1ECBch S\u1EED Nh\u1EADp H\u00E0ng";
            // 
            // gridMenu
            // 
            this.gridMenu.AllowUserToAddRows = false;
            this.gridMenu.AllowUserToResizeRows = false;
            this.gridMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMenu.BackgroundColor = System.Drawing.Color.White;
            this.gridMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMenu.ColumnHeadersHeight = 38;
            this.gridMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colMCode, this.colMName, this.colMSupplier, this.colMCat, this.colMList, this.colMPromo, this.colMPos, this.colMStock, this.colMEdit });
            this.gridMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMenu.EnableHeadersVisualStyles = false;
            this.gridMenu.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.gridMenu.MultiSelect = false;
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.ReadOnly = true;
            this.gridMenu.RowHeadersVisible = false;
            this.gridMenu.RowTemplate.Height = 36;
            this.gridMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMenu.TabIndex = 0;
            this.colMCode.HeaderText = "M\u00E3"; this.colMCode.Name = "colMCode"; this.colMCode.ReadOnly = true; this.colMCode.FillWeight = 45;
            this.colMName.HeaderText = "T\u00EAn M\u00F3n"; this.colMName.Name = "colMName"; this.colMName.ReadOnly = true; this.colMName.FillWeight = 140;
            this.colMSupplier.HeaderText = "Nh\u00E0 Cung C\u1EA5p"; this.colMSupplier.Name = "colMSupplier"; this.colMSupplier.ReadOnly = true; this.colMSupplier.FillWeight = 120;
            this.colMCat.HeaderText = "Ph\u00E2n Lo\u1EA1i"; this.colMCat.Name = "colMCat"; this.colMCat.ReadOnly = true; this.colMCat.FillWeight = 70;
            this.colMList.HeaderText = "Gi\u00E1 Ni\u00EAm Y\u1EBFt"; this.colMList.Name = "colMList"; this.colMList.ReadOnly = true; this.colMList.FillWeight = 80;
            this.colMPromo.HeaderText = "Khuy\u1EBFn M\u00E3i"; this.colMPromo.Name = "colMPromo"; this.colMPromo.ReadOnly = true; this.colMPromo.FillWeight = 70;
            this.colMPos.HeaderText = "Gi\u00E1 Thu POS"; this.colMPos.Name = "colMPos"; this.colMPos.ReadOnly = true; this.colMPos.FillWeight = 80;
            this.colMStock.HeaderText = "T\u1ED3n Kho"; this.colMStock.Name = "colMStock"; this.colMStock.ReadOnly = true; this.colMStock.FillWeight = 55;
            this.colMEdit.HeaderText = "Thao T\u00E1c"; this.colMEdit.Name = "colMEdit"; this.colMEdit.ReadOnly = true; this.colMEdit.Text = "S\u1EEDa Gi\u00E1"; this.colMEdit.UseColumnTextForButtonValue = true; this.colMEdit.FillWeight = 65;
            // 
            // gridHist
            // 
            this.gridHist.AllowUserToAddRows = false;
            this.gridHist.AllowUserToResizeRows = false;
            this.gridHist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHist.BackgroundColor = System.Drawing.Color.White;
            this.gridHist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHist.ColumnHeadersHeight = 38;
            this.gridHist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colHCode, this.colHTime, this.colHSupplier, this.colHItem, this.colHQty, this.colHTotal, this.colHBy });
            this.gridHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHist.EnableHeadersVisualStyles = false;
            this.gridHist.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.gridHist.MultiSelect = false;
            this.gridHist.Name = "gridHist";
            this.gridHist.ReadOnly = true;
            this.gridHist.RowHeadersVisible = false;
            this.gridHist.RowTemplate.Height = 36;
            this.gridHist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHist.TabIndex = 0;
            this.colHCode.HeaderText = "M\u00E3 Phi\u1EBFu"; this.colHCode.Name = "colHCode"; this.colHCode.ReadOnly = true;
            this.colHTime.HeaderText = "Th\u1EDDi Gian"; this.colHTime.Name = "colHTime"; this.colHTime.ReadOnly = true;
            this.colHSupplier.HeaderText = "Nh\u00E0 Cung C\u1EA5p"; this.colHSupplier.Name = "colHSupplier"; this.colHSupplier.ReadOnly = true;
            this.colHItem.HeaderText = "M\u1EB7t H\u00E0ng"; this.colHItem.Name = "colHItem"; this.colHItem.ReadOnly = true;
            this.colHQty.HeaderText = "S\u1ED1 L\u01B0\u1EE3ng"; this.colHQty.Name = "colHQty"; this.colHQty.ReadOnly = true;
            this.colHTotal.HeaderText = "T\u1ED5ng Ti\u1EC1n"; this.colHTotal.Name = "colHTotal"; this.colHTotal.ReadOnly = true;
            this.colHBy.HeaderText = "Ng\u01B0\u1EDDi T\u1EA1o"; this.colHBy.Name = "colHBy"; this.colHBy.ReadOnly = true;
            this.tabs.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.tabHist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

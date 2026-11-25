using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Members
{
    partial class UcCustomerLoyalty
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP3;
        private System.Windows.Forms.DataGridViewButtonColumn colView;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // UcCustomerLoyalty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UiTheme.MainBg;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlHeader);
            // Higher index docks first; Fill (grid) must be index 0 (dock last)
            this.Controls.SetChildIndex(this.pnlHeader, 1);
            this.Controls.SetChildIndex(this.grid, 0);
            this.Name = "UcCustomerLoyalty";
            this.Size = new System.Drawing.Size(1100, 760);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnAdd);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 96);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = UiTheme.TextMain;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Qu\u1EA3n l\u00FD Th\u00E0nh vi\u00EAn && Kh\u00E1ch h\u00E0ng";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = UiTheme.TextMuted;
            this.lblSubtitle.Location = new System.Drawing.Point(2, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "X\u00E9t n\u00E2ng h\u1EA1ng t\u1EF1 \u0111\u1ED9ng theo t\u1ED5ng chi ti\u00EAu. \u0110\u1ED5i v\u00E9 xem phim b\u1EB1ng \u0111i\u1EC3m c\u00F2n l\u1EA1i.";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(0, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "T\u00ECm theo S\u0110T ho\u1EB7c h\u1ECD t\u00EAn...";
            this.txtSearch.Size = new System.Drawing.Size(280, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = UiTheme.Primary;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = UiTheme.CardBg;
            this.btnAdd.Location = new System.Drawing.Point(920, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+ \u0110\u0103ng K\u00FD Kh\u00E1ch M\u1EDBi";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = UiTheme.CardBg;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeight = 42;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode, this.colName, this.colPhone, this.colTier, this.colSpend, this.colP1, this.colP2, this.colP3, this.colView});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = UiTheme.Border;
            this.grid.Location = new System.Drawing.Point(0, 96);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 34;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.TabIndex = 1;
            // 
            // columns
            // 
            this.colCode.HeaderText = "M\u00E3 KH"; this.colCode.Name = "colCode"; this.colCode.ReadOnly = true;
            this.colName.HeaderText = "H\u1ECD T\u00EAn"; this.colName.Name = "colName"; this.colName.ReadOnly = true;
            this.colPhone.HeaderText = "S\u0110T"; this.colPhone.Name = "colPhone"; this.colPhone.ReadOnly = true;
            this.colTier.HeaderText = "H\u1EA1ng Th\u1EBB"; this.colTier.Name = "colTier"; this.colTier.ReadOnly = true;
            this.colSpend.HeaderText = "T\u1ED5ng Chi Ti\u00EAu"; this.colSpend.Name = "colSpend"; this.colSpend.ReadOnly = true;
            this.colP1.HeaderText = "1. T\u1ED5ng \u0110i\u1EC3m T\u00EDch L\u0169y"; this.colP1.Name = "colP1"; this.colP1.ReadOnly = true;
            this.colP2.HeaderText = "2. \u0110i\u1EC3m \u0110\u00E3 \u0110\u1ED5i"; this.colP2.Name = "colP2"; this.colP2.ReadOnly = true;
            this.colP3.HeaderText = "3. \u0110i\u1EC3m C\u00F2n L\u1EA1i"; this.colP3.Name = "colP3"; this.colP3.ReadOnly = true;
            this.colView.HeaderText = "Thao T\u00E1c"; this.colView.Name = "colView"; this.colView.ReadOnly = true; this.colView.Text = "Xem L\u1ECBch S\u1EED"; this.colView.UseColumnTextForButtonValue = true;
            // 
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

namespace Cinema.WinForms.Features.Inventory
{
    partial class ImportFnBModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.RadioButton rbExisting;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.ComboBox cboNewCategory;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.rbExisting = new System.Windows.Forms.RadioButton();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.lblItem = new System.Windows.Forms.Label();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.cboNewCategory = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // ImportFnBModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.cboNewCategory);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.rbNew);
            this.Controls.Add(this.rbExisting);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportFnBModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "T\u1EA1o Phi\u1EBFu Nh\u1EADp H\u00E0ng";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSupplier.Location = new System.Drawing.Point(20, 18);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Text = "Nh\u00E0 cung c\u1EA5p";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.Location = new System.Drawing.Point(20, 40);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(440, 25);
            this.cboSupplier.TabIndex = 1;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblMode.Location = new System.Drawing.Point(20, 76);
            this.lblMode.Name = "lblMode";
            this.lblMode.Text = "Ch\u1EBF \u0111\u1ED9 nh\u1EADp";
            // 
            // rbExisting
            // 
            this.rbExisting.AutoSize = true;
            this.rbExisting.Checked = true;
            this.rbExisting.Location = new System.Drawing.Point(20, 100);
            this.rbExisting.Name = "rbExisting";
            this.rbExisting.TabIndex = 3;
            this.rbExisting.TabStop = true;
            this.rbExisting.Text = "Ch\u1ECDn m\u00F3n trong danh m\u1EE5c c\u1EE7a NCC \u0111\u00E3 ch\u1ECDn";
            this.rbExisting.UseVisualStyleBackColor = true;
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Location = new System.Drawing.Point(20, 126);
            this.rbNew.Name = "rbNew";
            this.rbNew.TabIndex = 4;
            this.rbNew.Text = "Nh\u1EADp m\u00F3n m\u1EDBi ho\u00E0n to\u00E0n (nh\u1EADp T\u00EAn m\u00F3n + Ph\u00E2n lo\u1EA1i)";
            this.rbNew.UseVisualStyleBackColor = true;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblItem.Location = new System.Drawing.Point(20, 154);
            this.lblItem.Name = "lblItem";
            this.lblItem.Text = "Ch\u1ECDn s\u1EA3n ph\u1EA9m:";
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.Location = new System.Drawing.Point(20, 174);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(440, 25);
            this.cboItem.TabIndex = 5;
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(20, 174);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.PlaceholderText = "T\u00EAn m\u00F3n m\u1EDBi";
            this.txtNewName.Size = new System.Drawing.Size(260, 25);
            this.txtNewName.TabIndex = 6;
            this.txtNewName.Visible = false;
            // 
            // cboNewCategory
            // 
            this.cboNewCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewCategory.Location = new System.Drawing.Point(290, 174);
            this.cboNewCategory.Name = "cboNewCategory";
            this.cboNewCategory.Size = new System.Drawing.Size(170, 25);
            this.cboNewCategory.TabIndex = 7;
            this.cboNewCategory.Visible = false;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQty.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblQty.Location = new System.Drawing.Point(20, 214);
            this.lblQty.Name = "lblQty";
            this.lblQty.Text = "S\u1ED1 l\u01B0\u1EE3ng nh\u1EADp";
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(20, 236);
            this.numQty.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(200, 25);
            this.numQty.TabIndex = 9;
            this.numQty.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPrice.Location = new System.Drawing.Point(260, 214);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "\u0110\u01A1n gi\u00E1 nh\u1EADp s\u1EC9 (VN\u0110)";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(260, 236);
            this.numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(200, 25);
            this.numPrice.TabIndex = 11;
            this.numPrice.ThousandsSeparator = true;
            this.numPrice.Value = new decimal(new int[] { 15000, 0, 0, 0 });
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblTotal.Location = new System.Drawing.Point(20, 280);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "T\u1ED5ng ti\u1EC1n phi\u1EBFu = S\u1ED1 l\u01B0\u1EE3ng x \u0110\u01A1n gi\u00E1 nh\u1EADp: 150.000 \u0111";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnCancel.Location = new System.Drawing.Point(250, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "H\u1EE7y B\u1ECF";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(360, 350);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 36);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "X\u00E1c Nh\u1EADn";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

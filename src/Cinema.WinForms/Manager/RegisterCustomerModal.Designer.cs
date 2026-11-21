namespace Cinema.WinForms.Manager
{
    partial class RegisterCustomerModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton rbMember;
        private System.Windows.Forms.RadioButton rbGuest;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTier;
        private System.Windows.Forms.ComboBox cboTier;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rbMember = new System.Windows.Forms.RadioButton();
            this.rbGuest = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTier = new System.Windows.Forms.Label();
            this.cboTier = new System.Windows.Forms.ComboBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.numPoints = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterCustomerModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 481);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numPoints);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.cboTier);
            this.Controls.Add(this.lblTier);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.rbGuest);
            this.Controls.Add(this.rbMember);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterCustomerModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "\u0110\u0103ng k\u00FD kh\u00E1ch m\u1EDBi";
            // 
            // rbMember
            // 
            this.rbMember.AutoSize = true;
            this.rbMember.Checked = true;
            this.rbMember.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbMember.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.rbMember.Location = new System.Drawing.Point(24, 20);
            this.rbMember.Name = "rbMember";
            this.rbMember.Size = new System.Drawing.Size(165, 23);
            this.rbMember.TabIndex = 0;
            this.rbMember.TabStop = true;
            this.rbMember.Text = "Th\u00E0nh vi\u00EAn t\u00EDch \u0111i\u1EC3m";
            this.rbMember.UseVisualStyleBackColor = true;
            // 
            // rbGuest
            // 
            this.rbGuest.AutoSize = true;
            this.rbGuest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbGuest.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.rbGuest.Location = new System.Drawing.Point(230, 20);
            this.rbGuest.Name = "rbGuest";
            this.rbGuest.Size = new System.Drawing.Size(108, 23);
            this.rbGuest.TabIndex = 1;
            this.rbGuest.Text = "Kh\u00E1ch th\u01B0\u1EDDng";
            this.rbGuest.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblName.Location = new System.Drawing.Point(24, 60);
            this.lblName.Name = "lblName";
            this.lblName.Text = "H\u1ECD t\u00EAn";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(24, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(380, 25);
            this.txtName.TabIndex = 2;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPhone.Location = new System.Drawing.Point(24, 120);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "S\u1ED1 \u0111i\u1EC7n tho\u1EA1i";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(24, 142);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(380, 25);
            this.txtPhone.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEmail.Location = new System.Drawing.Point(24, 180);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(24, 202);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(380, 25);
            this.txtEmail.TabIndex = 4;
            // 
            // lblTier
            // 
            this.lblTier.AutoSize = true;
            this.lblTier.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTier.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTier.Location = new System.Drawing.Point(24, 240);
            this.lblTier.Name = "lblTier";
            this.lblTier.Text = "H\u1EA1ng th\u1EBB ban \u0111\u1EA7u";
            // 
            // cboTier
            // 
            this.cboTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTier.FormattingEnabled = true;
            this.cboTier.Items.AddRange(new object[] { "Chu\u1EA9n", "B\u1EA1c", "V\u00E0ng" });
            this.cboTier.Location = new System.Drawing.Point(24, 262);
            this.cboTier.Name = "cboTier";
            this.cboTier.Size = new System.Drawing.Size(380, 25);
            this.cboTier.TabIndex = 5;
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPoints.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPoints.Location = new System.Drawing.Point(24, 300);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Text = "\u0110i\u1EC3m th\u01B0\u1EDFng ch\u00E0o m\u1EEBng";
            // 
            // numPoints
            // 
            this.numPoints.Location = new System.Drawing.Point(24, 322);
            this.numPoints.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numPoints.Name = "numPoints";
            this.numPoints.Size = new System.Drawing.Size(380, 25);
            this.numPoints.TabIndex = 6;
            this.numPoints.ThousandsSeparator = true;
            this.numPoints.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(274, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "L\u01B0u h\u1ED3 s\u01A1";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

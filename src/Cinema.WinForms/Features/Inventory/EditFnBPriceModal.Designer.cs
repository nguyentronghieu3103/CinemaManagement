using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Inventory
{
    partial class EditFnBPriceModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.CheckBox chkPos;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBasePrice = new Label();
            numBasePrice = new NumericUpDown();
            lblDiscount = new Label();
            numDiscount = new NumericUpDown();
            lblPreview = new Label();
            chkPos = new CheckBox();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numBasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBasePrice.ForeColor = UiTheme.TextMain;
            lblBasePrice.Location = new Point(24, 24);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(124, 23);
            lblBasePrice.TabIndex = 11;
            lblBasePrice.Text = "Giá gốc (VNĐ)";
            // 
            // numBasePrice
            // 
            numBasePrice.Location = new Point(24, 46);
            numBasePrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numBasePrice.Name = "numBasePrice";
            numBasePrice.Size = new Size(390, 29);
            numBasePrice.TabIndex = 1;
            numBasePrice.ThousandsSeparator = true;
            numBasePrice.Value = new decimal(new int[] { 89000, 0, 0, 0 });
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiscount.ForeColor = UiTheme.TextMain;
            lblDiscount.Location = new Point(24, 86);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(248, 23);
            lblDiscount.TabIndex = 10;
            lblDiscount.Text = "Giảm giá / Khuyến mãi (VNĐ)";
            // 
            // numDiscount
            // 
            numDiscount.Location = new Point(24, 108);
            numDiscount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(390, 29);
            numDiscount.TabIndex = 3;
            numDiscount.ThousandsSeparator = true;
            numDiscount.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            numDiscount.ValueChanged += numDiscount_ValueChanged;
            // 
            // lblPreview
            // 
            lblPreview.AutoSize = true;
            lblPreview.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPreview.ForeColor = UiTheme.Primary;
            lblPreview.Location = new Point(24, 150);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(301, 25);
            lblPreview.TabIndex = 9;
            lblPreview.Text = "Xem trước giá thu POS: 79.000 đ";
            // 
            // chkPos
            // 
            chkPos.AutoSize = true;
            chkPos.Checked = true;
            chkPos.CheckState = CheckState.Checked;
            chkPos.ForeColor = UiTheme.TextMain;
            chkPos.Location = new Point(24, 185);
            chkPos.Name = "chkPos";
            chkPos.Size = new Size(141, 25);
            chkPos.TabIndex = 8;
            chkPos.Text = "Mở bán tại POS";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = UiTheme.CardBg;
            btnCancel.FlatAppearance.BorderColor = UiTheme.Border;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = UiTheme.TextMuted;
            btnCancel.Location = new Point(228, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 36);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy Bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = UiTheme.Primary;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = UiTheme.CardBg;
            btnSave.Location = new Point(324, 240);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 36);
            btnSave.TabIndex = 7;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // EditFnBPriceModal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = UiTheme.CardBg;
            ClientSize = new Size(444, 301);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(chkPos);
            Controls.Add(lblPreview);
            Controls.Add(numDiscount);
            Controls.Add(lblDiscount);
            Controls.Add(numBasePrice);
            Controls.Add(lblBasePrice);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditFnBPriceModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "S\u1EEDa Gi\u00E1 F&&B";
            ((System.ComponentModel.ISupportInitialize)numBasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

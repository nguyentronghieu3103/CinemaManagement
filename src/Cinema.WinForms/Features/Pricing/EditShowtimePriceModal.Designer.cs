using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Pricing
{
    partial class EditShowtimePriceModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblStd;
        private System.Windows.Forms.NumericUpDown numStd;
        private System.Windows.Forms.Label lblVip;
        private System.Windows.Forms.NumericUpDown numVip;
        private System.Windows.Forms.Label lblCouple;
        private System.Windows.Forms.NumericUpDown numCouple;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.NumericUpDown numExtra;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStd = new System.Windows.Forms.Label();
            this.numStd = new System.Windows.Forms.NumericUpDown();
            this.lblVip = new System.Windows.Forms.Label();
            this.numVip = new System.Windows.Forms.NumericUpDown();
            this.lblCouple = new System.Windows.Forms.Label();
            this.numCouple = new System.Windows.Forms.NumericUpDown();
            this.lblExtra = new System.Windows.Forms.Label();
            this.numExtra = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCouple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // EditShowtimePriceModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UiTheme.CardBg;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numExtra);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.numCouple);
            this.Controls.Add(this.lblCouple);
            this.Controls.Add(this.numVip);
            this.Controls.Add(this.lblVip);
            this.Controls.Add(this.numStd);
            this.Controls.Add(this.lblStd);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditShowtimePriceModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S\u1EEDa Gi\u00E1 Su\u1EA5t";
            // 
            // lblStd
            // 
            this.lblStd.AutoSize = true;
            this.lblStd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStd.ForeColor = UiTheme.TextMain;
            this.lblStd.Location = new System.Drawing.Point(24, 20);
            this.lblStd.Name = "lblStd";
            this.lblStd.Text = "1. Gi\u00E1 Gh\u1EBF Th\u01B0\u1EDDng (Standard)";
            // 
            // numStd
            // 
            this.numStd.Location = new System.Drawing.Point(24, 44);
            this.numStd.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numStd.Name = "numStd";
            this.numStd.Size = new System.Drawing.Size(380, 25);
            this.numStd.TabIndex = 1;
            this.numStd.ThousandsSeparator = true;
            this.numStd.Value = new decimal(new int[] { 70000, 0, 0, 0 });
            // 
            // lblVip
            // 
            this.lblVip.AutoSize = true;
            this.lblVip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVip.ForeColor = UiTheme.TextMain;
            this.lblVip.Location = new System.Drawing.Point(24, 80);
            this.lblVip.Name = "lblVip";
            this.lblVip.Text = "2. Gi\u00E1 Gh\u1EBF VIP";
            // 
            // numVip
            // 
            this.numVip.Location = new System.Drawing.Point(24, 104);
            this.numVip.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numVip.Name = "numVip";
            this.numVip.Size = new System.Drawing.Size(380, 25);
            this.numVip.TabIndex = 3;
            this.numVip.ThousandsSeparator = true;
            this.numVip.Value = new decimal(new int[] { 85000, 0, 0, 0 });
            // 
            // lblCouple
            // 
            this.lblCouple.AutoSize = true;
            this.lblCouple.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCouple.ForeColor = UiTheme.TextMain;
            this.lblCouple.Location = new System.Drawing.Point(24, 140);
            this.lblCouple.Name = "lblCouple";
            this.lblCouple.Text = "3. Gi\u00E1 Gh\u1EBF \u0110\u00F4i Sweetbox";
            // 
            // numCouple
            // 
            this.numCouple.Location = new System.Drawing.Point(24, 164);
            this.numCouple.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numCouple.Name = "numCouple";
            this.numCouple.Size = new System.Drawing.Size(380, 25);
            this.numCouple.TabIndex = 5;
            this.numCouple.ThousandsSeparator = true;
            this.numCouple.Value = new decimal(new int[] { 160000, 0, 0, 0 });
            // 
            // lblExtra
            // 
            this.lblExtra.AutoSize = true;
            this.lblExtra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExtra.ForeColor = UiTheme.TextMain;
            this.lblExtra.Location = new System.Drawing.Point(24, 200);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Text = "4. Ti\u1EC1n Ph\u1EE5 Thu Su\u1EA5t Chi\u1EBFu";
            // 
            // numExtra
            // 
            this.numExtra.Location = new System.Drawing.Point(24, 224);
            this.numExtra.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numExtra.Name = "numExtra";
            this.numExtra.Size = new System.Drawing.Size(380, 25);
            this.numExtra.TabIndex = 7;
            this.numExtra.ThousandsSeparator = true;
            this.numExtra.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // btnSave
            // 
            this.btnSave.BackColor = UiTheme.Primary;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = UiTheme.CardBg;
            this.btnSave.Location = new System.Drawing.Point(274, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "L\u01B0u Bi\u1EC3u Gi\u00E1";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            ((System.ComponentModel.ISupportInitialize)(this.numStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCouple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

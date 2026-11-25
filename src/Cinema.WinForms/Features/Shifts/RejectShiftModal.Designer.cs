using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Shifts
{
    partial class RejectShiftModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RejectShiftModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UiTheme.CardBg;
            this.ClientSize = new System.Drawing.Size(444, 221);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RejectShiftModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yêu cầu đếm lại / Từ chối";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReason.ForeColor = UiTheme.TextMain;
            this.lblReason.Location = new System.Drawing.Point(20, 20);
            this.lblReason.Name = "lblReason";
            this.lblReason.Text = "Lý do gửi về máy thu ngân";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(20, 44);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(400, 90);
            this.txtReason.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = UiTheme.CardBg;
            this.btnSend.FlatAppearance.BorderColor = UiTheme.Danger;
            this.btnSend.FlatAppearance.BorderSize = 1;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = UiTheme.Danger;
            this.btnSend.Location = new System.Drawing.Point(300, 160);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 36);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Gửi Yêu Cầu";
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Members
{
    partial class CustomerDetailModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel cardPoint1;
        private System.Windows.Forms.Label lblPoint1Title;
        private System.Windows.Forms.Label lblPoint1Value;
        private System.Windows.Forms.Label lblPoint1Sub;
        private System.Windows.Forms.Panel cardPoint2;
        private System.Windows.Forms.Label lblPoint2Title;
        private System.Windows.Forms.Label lblPoint2Value;
        private System.Windows.Forms.Label lblPoint2Sub;
        private System.Windows.Forms.Panel cardPoint3;
        private System.Windows.Forms.Label lblPoint3Title;
        private System.Windows.Forms.Label lblPoint3Value;
        private System.Windows.Forms.Label lblPoint3Sub;
        private System.Windows.Forms.Button btnRedeem;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.cardPoint1 = new System.Windows.Forms.Panel();
            this.lblPoint1Title = new System.Windows.Forms.Label();
            this.lblPoint1Value = new System.Windows.Forms.Label();
            this.lblPoint1Sub = new System.Windows.Forms.Label();
            this.cardPoint2 = new System.Windows.Forms.Panel();
            this.lblPoint2Title = new System.Windows.Forms.Label();
            this.lblPoint2Value = new System.Windows.Forms.Label();
            this.lblPoint2Sub = new System.Windows.Forms.Label();
            this.cardPoint3 = new System.Windows.Forms.Panel();
            this.lblPoint3Title = new System.Windows.Forms.Label();
            this.lblPoint3Value = new System.Windows.Forms.Label();
            this.lblPoint3Sub = new System.Windows.Forms.Label();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardPoint1.SuspendLayout();
            this.cardPoint2.SuspendLayout();
            this.cardPoint3.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerDetailModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = UiTheme.MainBg;
            this.ClientSize = new System.Drawing.Size(860, 500);
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.btnRedeem);
            this.Controls.Add(this.cardPoint3);
            this.Controls.Add(this.cardPoint2);
            this.Controls.Add(this.cardPoint1);
            this.Controls.Add(this.lblInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDetailModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi ti\u1EBFt kh\u00E1ch h\u00E0ng";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = UiTheme.TextMuted;
            this.lblInfo.Location = new System.Drawing.Point(24, 12);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Text = "S\u0110T: - | H\u1EA1ng th\u1EBB: - | T\u1ED5ng chi ti\u00EAu: -";
            // 
            // cardPoint1
            // 
            this.cardPoint1.BackColor = UiTheme.CardBg;
            this.cardPoint1.Paint += UiTheme.DrawCardBorder;
            this.cardPoint1.Controls.Add(this.lblPoint1Sub);
            this.cardPoint1.Controls.Add(this.lblPoint1Value);
            this.cardPoint1.Controls.Add(this.lblPoint1Title);
            this.cardPoint1.Location = new System.Drawing.Point(24, 40);
            this.cardPoint1.Name = "cardPoint1";
            this.cardPoint1.Size = new System.Drawing.Size(250, 105);
            this.cardPoint1.TabIndex = 0;
            this.lblPoint1Title.AutoSize = true; this.lblPoint1Title.Font = new System.Drawing.Font("Segoe UI", 9F); this.lblPoint1Title.ForeColor = UiTheme.TextMuted; this.lblPoint1Title.Location = new System.Drawing.Point(14, 10); this.lblPoint1Title.Text = "\u0110i\u1EC3m hi\u1EC7n c\u00F3";
            this.lblPoint1Value.AutoSize = true; this.lblPoint1Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold); this.lblPoint1Value.ForeColor = UiTheme.Primary; this.lblPoint1Value.Location = new System.Drawing.Point(12, 34); this.lblPoint1Value.Text = "0";
            this.lblPoint1Sub.AutoSize = true; this.lblPoint1Sub.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.lblPoint1Sub.ForeColor = UiTheme.TextMuted; this.lblPoint1Sub.Location = new System.Drawing.Point(14, 76); this.lblPoint1Sub.Text = "D\u00F9ng x\u00E9t n\u00E2ng h\u1EA1ng";
            // 
            // cardPoint2
            // 
            this.cardPoint2.BackColor = UiTheme.CardBg;
            this.cardPoint2.Paint += UiTheme.DrawCardBorder;
            this.cardPoint2.Controls.Add(this.lblPoint2Sub);
            this.cardPoint2.Controls.Add(this.lblPoint2Value);
            this.cardPoint2.Controls.Add(this.lblPoint2Title);
            this.cardPoint2.Location = new System.Drawing.Point(305, 40);
            this.cardPoint2.Name = "cardPoint2";
            this.cardPoint2.Size = new System.Drawing.Size(250, 105);
            this.cardPoint2.TabIndex = 1;
            this.lblPoint2Title.AutoSize = true; this.lblPoint2Title.Font = new System.Drawing.Font("Segoe UI", 9F); this.lblPoint2Title.ForeColor = UiTheme.TextMuted; this.lblPoint2Title.Location = new System.Drawing.Point(14, 10); this.lblPoint2Title.Text = "\u0110i\u1EC3m \u0111\u00E3 d\u00F9ng";
            this.lblPoint2Value.AutoSize = true; this.lblPoint2Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold); this.lblPoint2Value.ForeColor = UiTheme.Amber; this.lblPoint2Value.Location = new System.Drawing.Point(12, 34); this.lblPoint2Value.Text = "0";
            this.lblPoint2Sub.AutoSize = true; this.lblPoint2Sub.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.lblPoint2Sub.ForeColor = UiTheme.TextMuted; this.lblPoint2Sub.Location = new System.Drawing.Point(14, 76); this.lblPoint2Sub.Text = "\u0110\u00E3 \u0111\u1ED5i v\u00E9/qu\u00E0";
            // 
            // cardPoint3
            // 
            this.cardPoint3.BackColor = UiTheme.CardBg;
            this.cardPoint3.Paint += UiTheme.DrawCardBorder;
            this.cardPoint3.Controls.Add(this.lblPoint3Sub);
            this.cardPoint3.Controls.Add(this.lblPoint3Value);
            this.cardPoint3.Controls.Add(this.lblPoint3Title);
            this.cardPoint3.Location = new System.Drawing.Point(586, 40);
            this.cardPoint3.Name = "cardPoint3";
            this.cardPoint3.Size = new System.Drawing.Size(250, 105);
            this.cardPoint3.TabIndex = 2;
            this.lblPoint3Title.AutoSize = true; this.lblPoint3Title.Font = new System.Drawing.Font("Segoe UI", 9F); this.lblPoint3Title.ForeColor = UiTheme.TextMuted; this.lblPoint3Title.Location = new System.Drawing.Point(14, 10); this.lblPoint3Title.Text = "\u0110i\u1EC3m c\u00F2n l\u1EA1i";
            this.lblPoint3Value.AutoSize = true; this.lblPoint3Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold); this.lblPoint3Value.ForeColor = UiTheme.Success; this.lblPoint3Value.Location = new System.Drawing.Point(12, 34); this.lblPoint3Value.Text = "0";
            this.lblPoint3Sub.AutoSize = true; this.lblPoint3Sub.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.lblPoint3Sub.ForeColor = UiTheme.TextMuted; this.lblPoint3Sub.Location = new System.Drawing.Point(14, 76); this.lblPoint3Sub.Text = "C\u00F3 th\u1EC3 \u0111\u1ED5i v\u00E9 ngay";
            // 
            // btnRedeem
            // 
            this.btnRedeem.BackColor = UiTheme.Primary;
            this.btnRedeem.FlatAppearance.BorderSize = 0;
            this.btnRedeem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedeem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRedeem.ForeColor = UiTheme.CardBg;
            this.btnRedeem.Location = new System.Drawing.Point(606, 156);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(230, 36);
            this.btnRedeem.TabIndex = 3;
            this.btnRedeem.Text = "\uD83C\uDF9F\uFE0F \u0110\u1ED5i V\u00E9 Xem Phim B\u1EB1ng \u0110i\u1EC3m";
            this.btnRedeem.UseVisualStyleBackColor = false;
            // 
            // pnlHistory
            // 
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.BackColor = UiTheme.CardBg;
            this.pnlHistory.Paint += UiTheme.DrawCardBorder;
            this.pnlHistory.Controls.Add(this.gridHistory);
            this.pnlHistory.Location = new System.Drawing.Point(24, 204);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(812, 272);
            this.pnlHistory.TabIndex = 4;
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToResizeRows = false;
            this.gridHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHistory.BackgroundColor = UiTheme.CardBg;
            this.gridHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHistory.ColumnHeadersHeight = 38;
            this.gridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCode, this.colMovie, this.colSeat, this.colTotal, this.colDate, this.colPoint
            });
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.EnableHeadersVisualStyles = false;
            this.gridHistory.GridColor = UiTheme.Border;
            this.gridHistory.Location = new System.Drawing.Point(0, 0);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.ReadOnly = true;
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.RowTemplate.Height = 34;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.TabIndex = 0;
            this.colCode.HeaderText = "M\u00E3 v\u00E9"; this.colCode.Name = "colCode"; this.colCode.ReadOnly = true;
            this.colMovie.HeaderText = "Phim"; this.colMovie.Name = "colMovie"; this.colMovie.ReadOnly = true;
            this.colSeat.HeaderText = "Gh\u1EBF"; this.colSeat.Name = "colSeat"; this.colSeat.ReadOnly = true;
            this.colTotal.HeaderText = "T\u1ED5ng ti\u1EC1n"; this.colTotal.Name = "colTotal"; this.colTotal.ReadOnly = true;
            this.colDate.HeaderText = "Ng\u00E0y mua"; this.colDate.Name = "colDate"; this.colDate.ReadOnly = true;
            this.colPoint.HeaderText = "\u0110i\u1EC3m +/-"; this.colPoint.Name = "colPoint"; this.colPoint.ReadOnly = true;
            // 
            this.cardPoint1.ResumeLayout(false); this.cardPoint1.PerformLayout();
            this.cardPoint2.ResumeLayout(false); this.cardPoint2.PerformLayout();
            this.cardPoint3.ResumeLayout(false); this.cardPoint3.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

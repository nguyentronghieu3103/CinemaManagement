namespace Cinema.WinForms.Manager
{
    partial class FrmApprovalQueue
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel card;
        private System.Windows.Forms.DataGridView gridQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.card = new System.Windows.Forms.Panel();
            this.gridQueue = new System.Windows.Forms.DataGridView();
            this.colTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // FrmApprovalQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(980, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.card);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmApprovalQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh s\u00E1ch duy\u1EC7t h\u1EE7y v\u00E9";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "H\u00E0ng \u0111\u1EE3i duy\u1EC7t h\u1EE7y v\u00E9 kh\u1EA9n c\u1EA5p";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(26, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Ki\u1EC3m tra l\u00FD do h\u1EE7y v\u00E0 x\u1eed l\u00FD ho\u00E0n ti\u1EC1n cho kh\u00E1ch h\u00E0ng.";
            // 
            // card
            // 
            this.card.BackColor = System.Drawing.Color.White;
            this.card.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card.Controls.Add(this.gridQueue);
            this.card.Location = new System.Drawing.Point(24, 84);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(932, 360);
            this.card.TabIndex = 2;
            // 
            // gridQueue
            // 
            this.gridQueue.AllowUserToAddRows = false;
            this.gridQueue.AllowUserToResizeRows = false;
            this.gridQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridQueue.BackgroundColor = System.Drawing.Color.White;
            this.gridQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridQueue.ColumnHeadersHeight = 40;
            this.gridQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTicket, this.colMovie, this.colSeat, this.colRefund, this.colReason
            });
            this.gridQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQueue.EnableHeadersVisualStyles = false;
            this.gridQueue.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.gridQueue.Location = new System.Drawing.Point(0, 0);
            this.gridQueue.MultiSelect = false;
            this.gridQueue.Name = "gridQueue";
            this.gridQueue.ReadOnly = true;
            this.gridQueue.RowHeadersVisible = false;
            this.gridQueue.RowTemplate.Height = 36;
            this.gridQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridQueue.TabIndex = 0;
            // 
            // columns
            // 
            this.colTicket.HeaderText = "M\u00E3 v\u00E9";
            this.colTicket.Name = "colTicket";
            this.colTicket.ReadOnly = true;
            this.colTicket.FillWeight = 14F;
            this.colMovie.HeaderText = "T\u00EAn phim";
            this.colMovie.Name = "colMovie";
            this.colMovie.ReadOnly = true;
            this.colMovie.FillWeight = 28F;
            this.colSeat.HeaderText = "Gh\u1EBF";
            this.colSeat.Name = "colSeat";
            this.colSeat.ReadOnly = true;
            this.colSeat.FillWeight = 10F;
            this.colRefund.HeaderText = "S\u1ED1 ti\u1EC1n ho\u00E0n";
            this.colRefund.Name = "colRefund";
            this.colRefund.ReadOnly = true;
            this.colRefund.FillWeight = 16F;
            this.colReason.HeaderText = "L\u00FD do h\u1EE7y";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            this.colReason.FillWeight = 32F;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(534, 462);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(190, 36);
            this.btnApprove.TabIndex = 3;
            this.btnApprove.Text = "\u2714 Ch\u1EA5p Thu\u1EADn Ho\u00E0n Ti\u1EC1n";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.White;
            this.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnReject.Location = new System.Drawing.Point(732, 462);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 36);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "\u2716 T\u1EEB Ch\u1ED1i";
            this.btnReject.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClose.Location = new System.Drawing.Point(860, 462);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "\u0110\u00F3ng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            this.card.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

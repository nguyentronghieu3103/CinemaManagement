namespace Cinema.WinForms.Manager
{
    partial class RedeemTicketModal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.ComboBox cboMovie;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.ComboBox cboSeat;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnOk;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMovie = new System.Windows.Forms.Label();
            this.cboMovie = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.cboSeat = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RedeemTicketModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 321);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cboSeat);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.cboRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cboMovie);
            this.Controls.Add(this.lblMovie);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RedeemTicketModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi Vé Bằng Điểm";
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMovie.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblMovie.Location = new System.Drawing.Point(20, 20);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Text = "Chọn Phim";
            // 
            // cboMovie
            // 
            this.cboMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMovie.Location = new System.Drawing.Point(20, 42);
            this.cboMovie.Name = "cboMovie";
            this.cboMovie.Size = new System.Drawing.Size(400, 25);
            this.cboMovie.TabIndex = 1;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRoom.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRoom.Location = new System.Drawing.Point(20, 82);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Text = "Chọn Phòng";
            // 
            // cboRoom
            // 
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoom.Location = new System.Drawing.Point(20, 104);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(400, 25);
            this.cboRoom.TabIndex = 3;
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeat.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSeat.Location = new System.Drawing.Point(20, 144);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Text = "Loại ghế";
            // 
            // cboSeat
            // 
            this.cboSeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeat.Location = new System.Drawing.Point(20, 166);
            this.cboSeat.Name = "cboSeat";
            this.cboSeat.Size = new System.Drawing.Size(400, 25);
            this.cboSeat.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblPrice.Location = new System.Drawing.Point(20, 215);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Giá thanh toán: 0 VNĐ";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(290, 255);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 36);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Xác Nhận Đổi Vé";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
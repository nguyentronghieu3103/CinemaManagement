namespace CinemaManagement.UI.Forms.Staff.CheckIn
{
    partial class CheckInResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlRoot = new Panel();
            tblInfo = new TableLayoutPanel();
            lblMovieCaption = new Label();
            lblBanner = new Label();
            lblTicketCode = new Label();
            lblTitle = new Label();
            lblRoomCaption = new Label();
            lblShowtimeCaption = new Label();
            lblSeatCaption = new Label();
            lblMovie = new Label();
            lblRoom = new Label();
            lblShowtime = new Label();
            lblSeat = new Label();
            lblSameInvoice = new Label();
            btnConfirm = new Button();
            btnClose = new Button();
            pnlRoot.SuspendLayout();
            tblInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoot
            // 
            pnlRoot.BackColor = Color.White;
            pnlRoot.BorderStyle = BorderStyle.FixedSingle;
            pnlRoot.Controls.Add(btnClose);
            pnlRoot.Controls.Add(btnConfirm);
            pnlRoot.Controls.Add(lblSameInvoice);
            pnlRoot.Controls.Add(tblInfo);
            pnlRoot.Controls.Add(lblBanner);
            pnlRoot.Controls.Add(lblTicketCode);
            pnlRoot.Controls.Add(lblTitle);
            pnlRoot.Dock = DockStyle.Fill;
            pnlRoot.Location = new Point(0, 0);
            pnlRoot.Name = "pnlRoot";
            pnlRoot.Size = new Size(460, 470);
            pnlRoot.TabIndex = 0;
            // 
            // tblInfo
            // 
            tblInfo.ColumnCount = 2;
            tblInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.6829262F));
            tblInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.31707F));
            tblInfo.Controls.Add(lblMovieCaption, 0, 0);
            tblInfo.Controls.Add(lblRoomCaption, 0, 1);
            tblInfo.Controls.Add(lblShowtimeCaption, 0, 2);
            tblInfo.Controls.Add(lblSeatCaption, 0, 3);
            tblInfo.Controls.Add(lblMovie, 1, 0);
            tblInfo.Controls.Add(lblRoom, 1, 1);
            tblInfo.Controls.Add(lblShowtime, 1, 2);
            tblInfo.Controls.Add(lblSeat, 1, 3);
            tblInfo.Location = new Point(25, 130);
            tblInfo.Name = "tblInfo";
            tblInfo.RowCount = 4;
            tblInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 52.38095F));
            tblInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 47.61905F));
            tblInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tblInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblInfo.Size = new Size(410, 170);
            tblInfo.TabIndex = 3;
            // 
            // lblMovieCaption
            // 
            lblMovieCaption.AutoSize = true;
            lblMovieCaption.Dock = DockStyle.Fill;
            lblMovieCaption.Font = new Font("Segoe UI", 8F);
            lblMovieCaption.ForeColor = Color.FromArgb(141, 110, 99);
            lblMovieCaption.Location = new Point(3, 0);
            lblMovieCaption.Name = "lblMovieCaption";
            lblMovieCaption.Size = new Size(128, 44);
            lblMovieCaption.TabIndex = 0;
            lblMovieCaption.Text = "PHIM";
            lblMovieCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBanner
            // 
            lblBanner.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBanner.Location = new Point(24, 60);
            lblBanner.Name = "lblBanner";
            lblBanner.Size = new Size(410, 56);
            lblBanner.TabIndex = 2;
            lblBanner.Text = "label1";
            lblBanner.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTicketCode
            // 
            lblTicketCode.ForeColor = Color.FromArgb(141, 110, 99);
            lblTicketCode.Location = new Point(290, 24);
            lblTicketCode.Name = "lblTicketCode";
            lblTicketCode.Size = new Size(145, 22);
            lblTicketCode.TabIndex = 1;
            lblTicketCode.Text = "label1";
            lblTicketCode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(169, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN VÉ";
            // 
            // lblRoomCaption
            // 
            lblRoomCaption.AutoSize = true;
            lblRoomCaption.Dock = DockStyle.Fill;
            lblRoomCaption.Font = new Font("Segoe UI", 8F);
            lblRoomCaption.ForeColor = Color.FromArgb(141, 110, 99);
            lblRoomCaption.Location = new Point(3, 44);
            lblRoomCaption.Name = "lblRoomCaption";
            lblRoomCaption.Size = new Size(128, 40);
            lblRoomCaption.TabIndex = 1;
            lblRoomCaption.Text = "PHÒNG";
            lblRoomCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShowtimeCaption
            // 
            lblShowtimeCaption.AutoSize = true;
            lblShowtimeCaption.Dock = DockStyle.Fill;
            lblShowtimeCaption.Font = new Font("Segoe UI", 8F);
            lblShowtimeCaption.ForeColor = Color.FromArgb(141, 110, 99);
            lblShowtimeCaption.Location = new Point(3, 84);
            lblShowtimeCaption.Name = "lblShowtimeCaption";
            lblShowtimeCaption.Size = new Size(128, 46);
            lblShowtimeCaption.TabIndex = 2;
            lblShowtimeCaption.Text = "SUẤT CHIẾU";
            lblShowtimeCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSeatCaption
            // 
            lblSeatCaption.AutoSize = true;
            lblSeatCaption.Dock = DockStyle.Fill;
            lblSeatCaption.Font = new Font("Segoe UI", 8F);
            lblSeatCaption.ForeColor = Color.FromArgb(141, 110, 99);
            lblSeatCaption.Location = new Point(3, 130);
            lblSeatCaption.Name = "lblSeatCaption";
            lblSeatCaption.Size = new Size(128, 40);
            lblSeatCaption.TabIndex = 3;
            lblSeatCaption.Text = "GHẾ";
            lblSeatCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMovie
            // 
            lblMovie.AutoSize = true;
            lblMovie.Dock = DockStyle.Fill;
            lblMovie.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMovie.Location = new Point(137, 0);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(270, 44);
            lblMovie.TabIndex = 4;
            lblMovie.Text = "label1";
            lblMovie.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Dock = DockStyle.Fill;
            lblRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRoom.Location = new Point(137, 44);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(270, 40);
            lblRoom.TabIndex = 5;
            lblRoom.Text = "label1";
            lblRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShowtime
            // 
            lblShowtime.AutoSize = true;
            lblShowtime.Dock = DockStyle.Fill;
            lblShowtime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblShowtime.Location = new Point(137, 84);
            lblShowtime.Name = "lblShowtime";
            lblShowtime.Size = new Size(270, 46);
            lblShowtime.TabIndex = 6;
            lblShowtime.Text = "label1";
            lblShowtime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSeat
            // 
            lblSeat.AutoSize = true;
            lblSeat.Dock = DockStyle.Fill;
            lblSeat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSeat.Location = new Point(137, 130);
            lblSeat.Name = "lblSeat";
            lblSeat.Size = new Size(270, 40);
            lblSeat.TabIndex = 7;
            lblSeat.Text = "label1";
            lblSeat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSameInvoice
            // 
            lblSameInvoice.ForeColor = Color.FromArgb(141, 110, 99);
            lblSameInvoice.Location = new Point(25, 320);
            lblSameInvoice.Name = "lblSameInvoice";
            lblSameInvoice.Size = new Size(410, 22);
            lblSameInvoice.TabIndex = 4;
            lblSameInvoice.Text = "label1";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(24, 350);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(410, 38);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "XÁC NHẬN CHECK-IN";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(24, 406);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(410, 36);
            btnClose.TabIndex = 6;
            btnClose.Text = "ĐÓNG";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // CheckInResultForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 470);
            Controls.Add(pnlRoot);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CheckInResultForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CheckInResultForm";
            pnlRoot.ResumeLayout(false);
            pnlRoot.PerformLayout();
            tblInfo.ResumeLayout(false);
            tblInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoot;
        private Label lblBanner;
        private Label lblTicketCode;
        private Label lblTitle;
        private TableLayoutPanel tblInfo;
        private Label lblMovieCaption;
        private Label lblRoomCaption;
        private Label lblShowtimeCaption;
        private Label lblSameInvoice;
        private Label lblSeatCaption;
        private Label lblMovie;
        private Label lblRoom;
        private Label lblShowtime;
        private Label lblSeat;
        private Button btnConfirm;
        private Button btnClose;
    }
}
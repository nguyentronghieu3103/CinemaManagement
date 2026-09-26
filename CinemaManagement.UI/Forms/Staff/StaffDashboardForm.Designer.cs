namespace CinemaManagement.UI.Forms.Staff
{
    partial class StaffDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffDashboardForm));
            pnlHeader = new Panel();
            pictureBox1 = new PictureBox();
            btnUserMenu = new Button();
            btnNavLookup = new Button();
            btnNavCheckIn = new Button();
            btnNavBooking = new Button();
            lblLogo = new Label();
            btnNavHome = new Button();
            pnlTitle = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            label5 = new Label();
            label6 = new Label();
            lblDateTime = new Label();
            lblWelcome = new Label();
            lblPageTitle = new Label();
            pnlStats = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            panel6 = new Panel();
            cardDoanhThu = new Panel();
            lblDoanhThuValue = new Label();
            lblCaptionDoanhThu = new Label();
            cardCheckIn = new Panel();
            lblCheckInValue = new Label();
            lblCaptionCheckIn = new Label();
            cardSuatHomNay = new Panel();
            lblSuatHomNayValue = new Label();
            lblCaptionSuatHomNay = new Label();
            panel1 = new Panel();
            cardVeDaBan = new Panel();
            lblVeDaBanValue = new Label();
            lblCaptionVeDaBan = new Label();
            lblTableTitle = new Label();
            dgvUpcoming = new DataGridView();
            panel3 = new Panel();
            btnTraCuu = new Button();
            btnCheckIn = new Button();
            btnBanVe = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlTitle.SuspendLayout();
            panel4.SuspendLayout();
            pnlStats.SuspendLayout();
            cardDoanhThu.SuspendLayout();
            cardCheckIn.SuspendLayout();
            cardSuatHomNay.SuspendLayout();
            cardVeDaBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpcoming).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(107, 44, 44);
            pnlHeader.Controls.Add(pictureBox1);
            pnlHeader.Controls.Add(btnUserMenu);
            pnlHeader.Controls.Add(btnNavLookup);
            pnlHeader.Controls.Add(btnNavCheckIn);
            pnlHeader.Controls.Add(btnNavBooking);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(btnNavHome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1262, 60);
            pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnUserMenu
            // 
            btnUserMenu.Dock = DockStyle.Right;
            btnUserMenu.FlatAppearance.BorderSize = 0;
            btnUserMenu.FlatStyle = FlatStyle.Flat;
            btnUserMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUserMenu.Location = new Point(1101, 0);
            btnUserMenu.Margin = new Padding(4);
            btnUserMenu.Name = "btnUserMenu";
            btnUserMenu.Size = new Size(161, 60);
            btnUserMenu.TabIndex = 6;
            btnUserMenu.Text = "NV A ▾";
            btnUserMenu.UseVisualStyleBackColor = true;
            // 
            // btnNavLookup
            // 
            btnNavLookup.FlatAppearance.BorderSize = 0;
            btnNavLookup.FlatStyle = FlatStyle.Flat;
            btnNavLookup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNavLookup.Location = new Point(631, 7);
            btnNavLookup.Margin = new Padding(4);
            btnNavLookup.Name = "btnNavLookup";
            btnNavLookup.Size = new Size(161, 64);
            btnNavLookup.TabIndex = 5;
            btnNavLookup.Text = "Tra cứu vé";
            btnNavLookup.UseVisualStyleBackColor = true;
            // 
            // btnNavCheckIn
            // 
            btnNavCheckIn.FlatAppearance.BorderSize = 0;
            btnNavCheckIn.FlatStyle = FlatStyle.Flat;
            btnNavCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNavCheckIn.Location = new Point(524, 7);
            btnNavCheckIn.Margin = new Padding(4);
            btnNavCheckIn.Name = "btnNavCheckIn";
            btnNavCheckIn.Size = new Size(136, 64);
            btnNavCheckIn.TabIndex = 4;
            btnNavCheckIn.Text = "Check-in";
            btnNavCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnNavBooking
            // 
            btnNavBooking.FlatAppearance.BorderSize = 0;
            btnNavBooking.FlatStyle = FlatStyle.Flat;
            btnNavBooking.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNavBooking.Location = new Point(423, 7);
            btnNavBooking.Margin = new Padding(4);
            btnNavBooking.Name = "btnNavBooking";
            btnNavBooking.Size = new Size(136, 64);
            btnNavBooking.TabIndex = 3;
            btnNavBooking.Text = "Bán vé";
            btnNavBooking.UseVisualStyleBackColor = true;
            btnNavBooking.Click += btnNavBooking_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblLogo.Location = new Point(59, 20);
            lblLogo.Margin = new Padding(4, 0, 4, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(253, 35);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "STORYLINE CINEMA";
            // 
            // btnNavHome
            // 
            btnNavHome.FlatAppearance.BorderSize = 0;
            btnNavHome.FlatStyle = FlatStyle.Flat;
            btnNavHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNavHome.Location = new Point(306, 7);
            btnNavHome.Margin = new Padding(4);
            btnNavHome.Name = "btnNavHome";
            btnNavHome.Size = new Size(140, 64);
            btnNavHome.TabIndex = 2;
            btnNavHome.Text = "Trang chủ";
            btnNavHome.UseVisualStyleBackColor = true;
            btnNavHome.Click += btnNavHome_Click;
            // 
            // pnlTitle
            // 
            pnlTitle.Controls.Add(panel2);
            pnlTitle.Controls.Add(panel4);
            pnlTitle.Controls.Add(lblDateTime);
            pnlTitle.Controls.Add(lblWelcome);
            pnlTitle.Controls.Add(lblPageTitle);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 60);
            pnlTitle.Margin = new Padding(4);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(1262, 84);
            pnlTitle.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(232, 137, 47);
            panel2.Location = new Point(997, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 10);
            panel2.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(601, 84);
            panel4.Name = "panel4";
            panel4.Size = new Size(251, 110);
            panel4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(22, 41);
            label5.Name = "label5";
            label5.Size = new Size(46, 54);
            label5.TabIndex = 5;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(20, 13);
            label6.Name = "label6";
            label6.Size = new Size(110, 28);
            label6.TabIndex = 4;
            label6.Text = "VÉ ĐÃ BÁN";
            // 
            // lblDateTime
            // 
            lblDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateTime.AutoSize = true;
            lblDateTime.Location = new Point(1101, 30);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(65, 28);
            lblDateTime.TabIndex = 4;
            lblDateTime.Text = "label1";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.ForeColor = Color.LightCoral;
            lblWelcome.Location = new Point(26, 45);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(108, 28);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Xin chào, ...";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.Black;
            lblPageTitle.Location = new Point(15, 4);
            lblPageTitle.Margin = new Padding(4, 0, 4, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(194, 41);
            lblPageTitle.TabIndex = 2;
            lblPageTitle.Text = "TRANG CHỦ";
            // 
            // pnlStats
            // 
            pnlStats.Controls.Add(panel9);
            pnlStats.Controls.Add(panel8);
            pnlStats.Controls.Add(panel6);
            pnlStats.Controls.Add(cardDoanhThu);
            pnlStats.Controls.Add(cardCheckIn);
            pnlStats.Controls.Add(cardSuatHomNay);
            pnlStats.Controls.Add(panel1);
            pnlStats.Controls.Add(cardVeDaBan);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(0, 144);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(1262, 110);
            pnlStats.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(232, 137, 47);
            panel9.Location = new Point(1000, 1);
            panel9.Name = "panel9";
            panel9.Size = new Size(262, 10);
            panel9.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(232, 137, 47);
            panel8.Location = new Point(667, 1);
            panel8.Name = "panel8";
            panel8.Size = new Size(262, 10);
            panel8.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(232, 137, 47);
            panel6.Location = new Point(332, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(262, 10);
            panel6.TabIndex = 4;
            // 
            // cardDoanhThu
            // 
            cardDoanhThu.BackColor = Color.White;
            cardDoanhThu.BorderStyle = BorderStyle.FixedSingle;
            cardDoanhThu.Controls.Add(lblDoanhThuValue);
            cardDoanhThu.Controls.Add(lblCaptionDoanhThu);
            cardDoanhThu.Location = new Point(999, 3);
            cardDoanhThu.Name = "cardDoanhThu";
            cardDoanhThu.Size = new Size(263, 107);
            cardDoanhThu.TabIndex = 7;
            // 
            // lblDoanhThuValue
            // 
            lblDoanhThuValue.AutoSize = true;
            lblDoanhThuValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblDoanhThuValue.ForeColor = Color.FromArgb(232, 137, 47);
            lblDoanhThuValue.Location = new Point(20, 41);
            lblDoanhThuValue.Name = "lblDoanhThuValue";
            lblDoanhThuValue.Size = new Size(46, 54);
            lblDoanhThuValue.TabIndex = 5;
            lblDoanhThuValue.Text = "0";
            // 
            // lblCaptionDoanhThu
            // 
            lblCaptionDoanhThu.AutoSize = true;
            lblCaptionDoanhThu.ForeColor = Color.DimGray;
            lblCaptionDoanhThu.Location = new Point(20, 13);
            lblCaptionDoanhThu.Name = "lblCaptionDoanhThu";
            lblCaptionDoanhThu.Size = new Size(226, 28);
            lblCaptionDoanhThu.TabIndex = 4;
            lblCaptionDoanhThu.Text = "DOANH THU HOM NAY ";
            // 
            // cardCheckIn
            // 
            cardCheckIn.BackColor = Color.White;
            cardCheckIn.BorderStyle = BorderStyle.FixedSingle;
            cardCheckIn.Controls.Add(lblCheckInValue);
            cardCheckIn.Controls.Add(lblCaptionCheckIn);
            cardCheckIn.Location = new Point(667, 7);
            cardCheckIn.Name = "cardCheckIn";
            cardCheckIn.Size = new Size(262, 103);
            cardCheckIn.TabIndex = 7;
            // 
            // lblCheckInValue
            // 
            lblCheckInValue.AutoSize = true;
            lblCheckInValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblCheckInValue.ForeColor = Color.Black;
            lblCheckInValue.Location = new Point(22, 41);
            lblCheckInValue.Name = "lblCheckInValue";
            lblCheckInValue.Size = new Size(46, 54);
            lblCheckInValue.TabIndex = 5;
            lblCheckInValue.Text = "0";
            // 
            // lblCaptionCheckIn
            // 
            lblCaptionCheckIn.AutoSize = true;
            lblCaptionCheckIn.ForeColor = Color.DimGray;
            lblCaptionCheckIn.Location = new Point(20, 13);
            lblCaptionCheckIn.Name = "lblCaptionCheckIn";
            lblCaptionCheckIn.Size = new Size(100, 28);
            lblCaptionCheckIn.TabIndex = 4;
            lblCaptionCheckIn.Text = "CHECK-IN";
            // 
            // cardSuatHomNay
            // 
            cardSuatHomNay.BackColor = Color.White;
            cardSuatHomNay.BorderStyle = BorderStyle.FixedSingle;
            cardSuatHomNay.Controls.Add(lblSuatHomNayValue);
            cardSuatHomNay.Controls.Add(lblCaptionSuatHomNay);
            cardSuatHomNay.Location = new Point(332, 3);
            cardSuatHomNay.Name = "cardSuatHomNay";
            cardSuatHomNay.Size = new Size(263, 107);
            cardSuatHomNay.TabIndex = 7;
            // 
            // lblSuatHomNayValue
            // 
            lblSuatHomNayValue.AutoSize = true;
            lblSuatHomNayValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblSuatHomNayValue.ForeColor = Color.Black;
            lblSuatHomNayValue.Location = new Point(22, 41);
            lblSuatHomNayValue.Name = "lblSuatHomNayValue";
            lblSuatHomNayValue.Size = new Size(46, 54);
            lblSuatHomNayValue.TabIndex = 5;
            lblSuatHomNayValue.Text = "0";
            // 
            // lblCaptionSuatHomNay
            // 
            lblCaptionSuatHomNay.AutoSize = true;
            lblCaptionSuatHomNay.ForeColor = Color.DimGray;
            lblCaptionSuatHomNay.Location = new Point(20, 13);
            lblCaptionSuatHomNay.Name = "lblCaptionSuatHomNay";
            lblCaptionSuatHomNay.Size = new Size(159, 28);
            lblCaptionSuatHomNay.TabIndex = 4;
            lblCaptionSuatHomNay.Text = "SUÁT HÔM NAY ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(232, 137, 47);
            panel1.Location = new Point(4, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 12);
            panel1.TabIndex = 3;
            // 
            // cardVeDaBan
            // 
            cardVeDaBan.BackColor = Color.White;
            cardVeDaBan.BorderStyle = BorderStyle.FixedSingle;
            cardVeDaBan.Controls.Add(lblVeDaBanValue);
            cardVeDaBan.Controls.Add(lblCaptionVeDaBan);
            cardVeDaBan.Location = new Point(3, 0);
            cardVeDaBan.Name = "cardVeDaBan";
            cardVeDaBan.Size = new Size(251, 110);
            cardVeDaBan.TabIndex = 0;
            // 
            // lblVeDaBanValue
            // 
            lblVeDaBanValue.AutoSize = true;
            lblVeDaBanValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVeDaBanValue.ForeColor = Color.Black;
            lblVeDaBanValue.Location = new Point(22, 41);
            lblVeDaBanValue.Name = "lblVeDaBanValue";
            lblVeDaBanValue.Size = new Size(46, 54);
            lblVeDaBanValue.TabIndex = 5;
            lblVeDaBanValue.Text = "0";
            lblVeDaBanValue.Click += lblVeDaBanValue_Click;
            // 
            // lblCaptionVeDaBan
            // 
            lblCaptionVeDaBan.AutoSize = true;
            lblCaptionVeDaBan.ForeColor = Color.DimGray;
            lblCaptionVeDaBan.Location = new Point(20, 13);
            lblCaptionVeDaBan.Name = "lblCaptionVeDaBan";
            lblCaptionVeDaBan.Size = new Size(110, 28);
            lblCaptionVeDaBan.TabIndex = 4;
            lblCaptionVeDaBan.Text = "VÉ ĐÃ BÁN";
            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.Dock = DockStyle.Top;
            lblTableTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTableTitle.ForeColor = Color.Black;
            lblTableTitle.Location = new Point(0, 254);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Padding = new Padding(10);
            lblTableTitle.Size = new Size(330, 52);
            lblTableTitle.TabIndex = 3;
            lblTableTitle.Text = "SUẤT CHIẾU SẮP DIỄN RA";
            // 
            // dgvUpcoming
            // 
            dgvUpcoming.AllowUserToAddRows = false;
            dgvUpcoming.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpcoming.Dock = DockStyle.Top;
            dgvUpcoming.Location = new Point(0, 306);
            dgvUpcoming.Name = "dgvUpcoming";
            dgvUpcoming.ReadOnly = true;
            dgvUpcoming.RowHeadersWidth = 51;
            dgvUpcoming.Size = new Size(1262, 350);
            dgvUpcoming.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnTraCuu);
            panel3.Controls.Add(btnCheckIn);
            panel3.Controls.Add(btnBanVe);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 656);
            panel3.Margin = new Padding(10);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(1262, 100);
            panel3.TabIndex = 5;
            // 
            // btnTraCuu
            // 
            btnTraCuu.BackColor = Color.FromArgb(251, 233, 231);
            btnTraCuu.FlatAppearance.BorderSize = 0;
            btnTraCuu.FlatStyle = FlatStyle.Flat;
            btnTraCuu.Location = new Point(862, 25);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(400, 75);
            btnTraCuu.TabIndex = 7;
            btnTraCuu.Text = "🔍 TRA CỨU VÉ";
            btnTraCuu.UseVisualStyleBackColor = false;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.FromArgb(107, 44, 44);
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckIn.Location = new Point(423, 25);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(400, 75);
            btnCheckIn.TabIndex = 6;
            btnCheckIn.Text = "🎬 CHECK-IN";
            btnCheckIn.UseVisualStyleBackColor = false;
            // 
            // btnBanVe
            // 
            btnBanVe.BackColor = Color.FromArgb(232, 137, 47);
            btnBanVe.FlatAppearance.BorderSize = 0;
            btnBanVe.FlatStyle = FlatStyle.Flat;
            btnBanVe.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBanVe.Location = new Point(0, 25);
            btnBanVe.Name = "btnBanVe";
            btnBanVe.Size = new Size(400, 75);
            btnBanVe.TabIndex = 0;
            btnBanVe.Text = "🎫 BÁN VÉ";
            btnBanVe.UseVisualStyleBackColor = false;
            // 
            // StaffDashboardForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 246, 240);
            ClientSize = new Size(1262, 998);
            Controls.Add(panel3);
            Controls.Add(dgvUpcoming);
            Controls.Add(lblTableTitle);
            Controls.Add(pnlStats);
            Controls.Add(pnlTitle);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 12F);
            ForeColor = Color.Black;
            Margin = new Padding(4);
            Name = "StaffDashboardForm";
            Text = "StaffDashboardForm";
            Load += StaffDashboardForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pnlStats.ResumeLayout(false);
            cardDoanhThu.ResumeLayout(false);
            cardDoanhThu.PerformLayout();
            cardCheckIn.ResumeLayout(false);
            cardCheckIn.PerformLayout();
            cardSuatHomNay.ResumeLayout(false);
            cardSuatHomNay.PerformLayout();
            cardVeDaBan.ResumeLayout(false);
            cardVeDaBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpcoming).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblLogo;
        private Button button1;
        private Button btnNavHome;
        private Button btnNavLookup;
        private Button btnNavCheckIn;
        private Button btnNavBooking;
        private Button btnUserMenu;
        private Panel pnlTitle;
        private Label lblPageTitle;
        private Label lblWelcome;
        private Panel pnlStats;
        private Panel panel1;
        private Panel cardVeDaBan;
        private Label lblVeDaBanValue;
        private Label lblCaptionVeDaBan;
        private Panel panel2;
        private Panel panel4;
        private Label label5;
        private Label label6;
        private Panel panel9;
        private Panel panel8;
        private Panel panel6;
        private Panel cardDoanhThu;
        private Label lblDoanhThuValue;
        private Label lblCaptionDoanhThu;
        private Panel cardCheckIn;
        private Label lblCheckInValue;
        private Label lblCaptionCheckIn;
        private Panel cardSuatHomNay;
        private Label lblSuatHomNayValue;
        private Label lblCaptionSuatHomNay;
        private Label lblTableTitle;
        private DataGridView dgvUpcoming;
        private Panel panel3;
        private Button btnBanVe;
        private Button btnTraCuu;
        private Button btnCheckIn;
        private Label lblDateTime;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button4;
    }
}
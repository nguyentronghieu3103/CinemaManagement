namespace CinemaManagement.UI.Forms.Staff.CheckIn
{
    partial class CheckInForm
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
            pnlCenter = new Panel();
            pnlLast = new CinemaManagement.UI.Theme.CardPanel { ShowShadow = false, Radius = 12 };
            lblLast = new Label();
            pnlCard = new CinemaManagement.UI.Theme.CardPanel();
            lblMessage = new Label();
            btnLookup = new CinemaManagement.UI.Theme.PillButton();
            txtCode = new TextBox();
            lblManualCaption = new Label();
            pnlScanZone = new Panel();
            lblScanHint = new Label();
            lblPageSubtitle = new Label();
            lblPageTitle = new Label();
            pnlCenter.SuspendLayout();
            pnlLast.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlScanZone.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCenter
            // 
            pnlCenter.Controls.Add(pnlLast);
            pnlCenter.Controls.Add(pnlCard);
            pnlCenter.Controls.Add(lblPageSubtitle);
            pnlCenter.Controls.Add(lblPageTitle);
            pnlCenter.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            pnlCenter.BackColor = Color.Transparent;
            pnlCenter.ForeColor = CinemaManagement.UI.Theme.AppColors.TextPrimary;
            pnlCenter.Location = new Point(218, 57);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(520, 560);
            pnlCenter.TabIndex = 0;
            // 
            // pnlLast
            // 
            pnlLast.BackColor = CinemaManagement.UI.Theme.AppColors.CardBackground;
            pnlLast.Controls.Add(lblLast);
            pnlLast.Location = new Point(0, 495);
            pnlLast.Name = "pnlLast";
            pnlLast.Size = new Size(520, 44);
            pnlLast.TabIndex = 3;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Dock = DockStyle.Fill;
            lblLast.Font = new Font("Segoe UI", 12F);
            lblLast.ForeColor = CinemaManagement.UI.Theme.AppColors.TextMuted;
            lblLast.Location = new Point(0, 0);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(274, 28);
            lblLast.TabIndex = 0;
            lblLast.Text = "Chưa có vé nào được check-in";
            lblLast.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = CinemaManagement.UI.Theme.AppColors.CardBackground;
            pnlCard.AccentColor = CinemaManagement.UI.Theme.AppColors.Primary;
            pnlCard.Controls.Add(lblMessage);
            pnlCard.Controls.Add(btnLookup);
            pnlCard.Controls.Add(txtCode);
            pnlCard.Controls.Add(lblManualCaption);
            pnlCard.Controls.Add(pnlScanZone);
            pnlCard.Font = new Font("Segoe UI", 12F);
            pnlCard.Location = new Point(0, 74);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(520, 400);
            pnlCard.TabIndex = 2;
            // 
            // lblMessage
            // 
            lblMessage.ForeColor = CinemaManagement.UI.Theme.AppColors.StatusRed;
            lblMessage.Location = new Point(40, 335);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(440, 44);
            lblMessage.TabIndex = 4;
            // 
            // btnLookup
            // 
            btnLookup.BackColor = CinemaManagement.UI.Theme.AppColors.Primary;
            btnLookup.FlatAppearance.BorderSize = 0;
            btnLookup.FlatStyle = FlatStyle.Flat;
            btnLookup.ForeColor = Color.White;
            btnLookup.Location = new Point(350, 284);
            btnLookup.Name = "btnLookup";
            btnLookup.Size = new Size(130, 36);
            btnLookup.TabIndex = 3;
            btnLookup.Text = "TRA CỨU";
            btnLookup.UseVisualStyleBackColor = false;
            // 
            // txtCode
            // 
            txtCode.BackColor = CinemaManagement.UI.Theme.AppColors.InputBackground;
            txtCode.ForeColor = CinemaManagement.UI.Theme.AppColors.TextPrimary;
            txtCode.CharacterCasing = CharacterCasing.Upper;
            txtCode.Location = new Point(40, 286);
            txtCode.MaxLength = 40;
            txtCode.Name = "txtCode";
            txtCode.PlaceholderText = "VD: VE000325";
            txtCode.Size = new Size(300, 34);
            txtCode.TabIndex = 2;
            // 
            // lblManualCaption
            // 
            lblManualCaption.AutoSize = true;
            lblManualCaption.Font = new Font("Segoe UI", 10F);
            lblManualCaption.ForeColor = CinemaManagement.UI.Theme.AppColors.TextMuted;
            lblManualCaption.Location = new Point(40, 262);
            lblManualCaption.Name = "lblManualCaption";
            lblManualCaption.Size = new Size(164, 23);
            lblManualCaption.TabIndex = 1;
            lblManualCaption.Text = "HOẶC NHẬP MÃ VÉ";
            // 
            // pnlScanZone
            // 
            pnlScanZone.BackColor = CinemaManagement.UI.Theme.AppColors.InputBackground;
            pnlScanZone.Controls.Add(lblScanHint);
            pnlScanZone.Location = new Point(40, 30);
            pnlScanZone.Name = "pnlScanZone";
            pnlScanZone.Size = new Size(440, 210);
            pnlScanZone.TabIndex = 0;
            // 
            // lblScanHint
            // 
            lblScanHint.BackColor = Color.Transparent;
            lblScanHint.ForeColor = CinemaManagement.UI.Theme.AppColors.TextSecondary;
            lblScanHint.Dock = DockStyle.Fill;
            lblScanHint.Location = new Point(0, 0);
            lblScanHint.Name = "lblScanHint";
            lblScanHint.Size = new Size(440, 210);
            lblScanHint.TabIndex = 0;
            lblScanHint.Text = "Đưa mã QR vào máy quét";
            lblScanHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPageSubtitle
            // 
            lblPageSubtitle.Font = new Font("Segoe UI", 12F);
            lblPageSubtitle.ForeColor = CinemaManagement.UI.Theme.AppColors.TextSecondary;
            lblPageSubtitle.Location = new Point(0, 40);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(520, 31);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Quét mã QR hoặc nhập mã vé";
            lblPageSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPageTitle
            // 
            lblPageTitle.Location = new Point(0, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(520, 40);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "CHECK-IN VÉ";
            lblPageTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CheckInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 696);
            Controls.Add(pnlCenter);
            Name = "CheckInForm";
            Text = "Check-in vé";
            WindowState = FormWindowState.Maximized;
            pnlCenter.ResumeLayout(false);
            pnlLast.ResumeLayout(false);
            pnlLast.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlScanZone.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCenter;
        private Label lblPageTitle;
        private Label lblPageSubtitle;
        private CinemaManagement.UI.Theme.CardPanel pnlCard;
        private Panel pnlScanZone;
        private Label lblScanHint;
        private Label lblManualCaption;
        private TextBox txtCode;
        private Label lblMessage;
        private CinemaManagement.UI.Theme.PillButton btnLookup;
        private CinemaManagement.UI.Theme.CardPanel pnlLast;
        private Label lblLast;
    }
}
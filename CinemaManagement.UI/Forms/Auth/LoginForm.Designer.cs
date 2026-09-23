namespace CinemaManagement.UI.Forms.Auth
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            lblBadgeText = new Label();
            panel1 = new Panel();
            lblStatus = new Label();
            lnkForgotPassword = new LinkLabel();
            btnLogin = new Button();
            btnTogglePassword = new Button();
            txtPassword = new TextBox();
            txtEmail = new MaskedTextBox();
            lblPasswordCaption = new Label();
            lblEmailCaption = new Label();
            lblTitle = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo2;
            pictureBox1.Location = new Point(118, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblBadgeText
            // 
            lblBadgeText.AutoSize = true;
            lblBadgeText.BackColor = Color.FromArgb(255, 192, 128);
            lblBadgeText.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBadgeText.ForeColor = Color.SaddleBrown;
            lblBadgeText.Location = new Point(56, 168);
            lblBadgeText.Name = "lblBadgeText";
            lblBadgeText.Size = new Size(343, 46);
            lblBadgeText.TabIndex = 1;
            lblBadgeText.Text = "STORYLINE CINEMA";
            lblBadgeText.TextAlign = ContentAlignment.MiddleCenter;
            lblBadgeText.Click += lblBadgeText_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lnkForgotPassword);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnTogglePassword);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblPasswordCaption);
            panel1.Controls.Add(lblEmailCaption);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(44, 231);
            panel1.Name = "panel1";
            panel1.Size = new Size(324, 334);
            panel1.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.White;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(20, 209);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(26, 20);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "lỗi";
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 10F);
            lnkForgotPassword.LinkColor = Color.FromArgb(255, 224, 192);
            lnkForgotPassword.Location = new Point(93, 291);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(137, 23);
            lnkForgotPassword.TabIndex = 7;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Quên mật khẩu?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 128, 0);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(22, 237);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(252, 37);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.PapayaWhip;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI", 5F);
            btnTogglePassword.ForeColor = Color.DimGray;
            btnTogglePassword.Location = new Point(238, 188);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(36, 14);
            btnTogglePassword.TabIndex = 5;
            btnTogglePassword.Text = "Hiện";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.PapayaWhip;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(22, 181);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(252, 27);
            txtPassword.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.PapayaWhip;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(22, 106);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(252, 27);
            txtEmail.TabIndex = 3;
            txtEmail.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            // 
            // lblPasswordCaption
            // 
            lblPasswordCaption.AutoSize = true;
            lblPasswordCaption.ForeColor = Color.Black;
            lblPasswordCaption.Location = new Point(22, 148);
            lblPasswordCaption.Name = "lblPasswordCaption";
            lblPasswordCaption.Size = new Size(91, 20);
            lblPasswordCaption.TabIndex = 2;
            lblPasswordCaption.Text = "MẬT KHẨU: ";
            // 
            // lblEmailCaption
            // 
            lblEmailCaption.AutoSize = true;
            lblEmailCaption.ForeColor = Color.Black;
            lblEmailCaption.Location = new Point(22, 72);
            lblEmailCaption.Name = "lblEmailCaption";
            lblEmailCaption.Size = new Size(93, 20);
            lblEmailCaption.TabIndex = 1;
            lblEmailCaption.Text = "TÀI KHOẢN: ";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(22, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(278, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng nhập hệ thống";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(426, 624);
            Controls.Add(panel1);
            Controls.Add(lblBadgeText);
            Controls.Add(pictureBox1);
            ForeColor = Color.FromArgb(255, 192, 128);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblBadgeText;
        private Panel panel1;
        private Label lblPasswordCaption;
        private Label lblEmailCaption;
        private Label lblTitle;
        private TextBox txtPassword;
        private MaskedTextBox txtEmail;
        private Button btnTogglePassword;
        private Button btnLogin;
        private LinkLabel lnkForgotPassword;
        private Label lblStatus;
        private ErrorProvider errorProvider1;
    }
}
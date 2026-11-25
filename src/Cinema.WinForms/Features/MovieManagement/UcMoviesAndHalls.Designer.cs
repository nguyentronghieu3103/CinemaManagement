using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.MovieManagement
{
    partial class UcMoviesAndHalls
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Panel movieCard;
        private System.Windows.Forms.Label lblMovieCardTitle;
        private System.Windows.Forms.DataGridView gridMovies;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDur;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label lblHalls;
        private System.Windows.Forms.TableLayoutPanel tlpHalls;
        private System.Windows.Forms.Panel hallCard1;
        private System.Windows.Forms.Label lblHall1Name;
        private System.Windows.Forms.Label lblHall1Type;
        private System.Windows.Forms.Label lblHall1Seats;
        private System.Windows.Forms.Label lblHall1Status;
        private System.Windows.Forms.Button btnHall1;
        private System.Windows.Forms.Panel hallCard2;
        private System.Windows.Forms.Label lblHall2Name;
        private System.Windows.Forms.Label lblHall2Type;
        private System.Windows.Forms.Label lblHall2Seats;
        private System.Windows.Forms.Label lblHall2Status;
        private System.Windows.Forms.Button btnHall2;
        private System.Windows.Forms.Panel hallCard3;
        private System.Windows.Forms.Label lblHall3Name;
        private System.Windows.Forms.Label lblHall3Type;
        private System.Windows.Forms.Label lblHall3Seats;
        private System.Windows.Forms.Label lblHall3Status;
        private System.Windows.Forms.Button btnHall3;
        private System.Windows.Forms.Panel hallCard4;
        private System.Windows.Forms.Label lblHall4Name;
        private System.Windows.Forms.Label lblHall4Type;
        private System.Windows.Forms.Label lblHall4Seats;
        private System.Windows.Forms.Label lblHall4Status;
        private System.Windows.Forms.Button btnHall4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.movieCard = new System.Windows.Forms.Panel();
            this.lblMovieCardTitle = new System.Windows.Forms.Label();
            this.gridMovies = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHalls = new System.Windows.Forms.Label();
            this.tlpHalls = new System.Windows.Forms.TableLayoutPanel();
            this.hallCard1 = new System.Windows.Forms.Panel();
            this.lblHall1Name = new System.Windows.Forms.Label();
            this.lblHall1Type = new System.Windows.Forms.Label();
            this.lblHall1Seats = new System.Windows.Forms.Label();
            this.lblHall1Status = new System.Windows.Forms.Label();
            this.btnHall1 = new System.Windows.Forms.Button();
            this.hallCard2 = new System.Windows.Forms.Panel();
            this.lblHall2Name = new System.Windows.Forms.Label();
            this.lblHall2Type = new System.Windows.Forms.Label();
            this.lblHall2Seats = new System.Windows.Forms.Label();
            this.lblHall2Status = new System.Windows.Forms.Label();
            this.btnHall2 = new System.Windows.Forms.Button();
            this.hallCard3 = new System.Windows.Forms.Panel();
            this.lblHall3Name = new System.Windows.Forms.Label();
            this.lblHall3Type = new System.Windows.Forms.Label();
            this.lblHall3Seats = new System.Windows.Forms.Label();
            this.lblHall3Status = new System.Windows.Forms.Label();
            this.btnHall3 = new System.Windows.Forms.Button();
            this.hallCard4 = new System.Windows.Forms.Panel();
            this.lblHall4Name = new System.Windows.Forms.Label();
            this.lblHall4Type = new System.Windows.Forms.Label();
            this.lblHall4Seats = new System.Windows.Forms.Label();
            this.lblHall4Status = new System.Windows.Forms.Label();
            this.btnHall4 = new System.Windows.Forms.Button();
            this.movieCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovies)).BeginInit();
            this.tlpHalls.SuspendLayout();
            this.hallCard1.SuspendLayout();
            this.hallCard2.SuspendLayout();
            this.hallCard3.SuspendLayout();
            this.hallCard4.SuspendLayout();
            this.SuspendLayout();
            // 
            // UcMoviesAndHalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = UiTheme.MainBg;
            this.Controls.Add(this.tlpHalls);
            this.Controls.Add(this.lblHalls);
            this.Controls.Add(this.movieCard);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcMoviesAndHalls";
            this.Size = new System.Drawing.Size(1100, 760);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = UiTheme.TextMain;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh m\u1EE5c Phim && Ph\u00F2ng chi\u1EBFu";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = UiTheme.TextMuted;
            this.lblSubtitle.Location = new System.Drawing.Point(2, 34);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(480, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "D\u1EEF li\u1EC7u master do Admin h\u1EC7 th\u1ED1ng b\u00E0n giao. Qu\u1EA3n l\u00FD theo d\u00F5i \u0111\u1EC3 \u0111i\u1EC1u ph\u1ED1i su\u1EA5t chi\u1EBFu.";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = UiTheme.TextMain;
            this.lblDate.Location = new System.Drawing.Point(760, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(96, 15);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Ng\u00E0y h\u1EA1ch to\u00E1n:";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(862, 6);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // movieCard
            // 
            this.movieCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieCard.BackColor = UiTheme.CardBg;
            this.movieCard.Paint += UiTheme.DrawCardBorder;
            this.movieCard.Controls.Add(this.gridMovies);
            this.movieCard.Controls.Add(this.lblMovieCardTitle);
            this.movieCard.Location = new System.Drawing.Point(0, 68);
            this.movieCard.Name = "movieCard";
            this.movieCard.Size = new System.Drawing.Size(1080, 250);
            this.movieCard.TabIndex = 4;
            // 
            // lblMovieCardTitle
            // 
            this.lblMovieCardTitle.AutoSize = true;
            this.lblMovieCardTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMovieCardTitle.ForeColor = UiTheme.TextMain;
            this.lblMovieCardTitle.Location = new System.Drawing.Point(12, 10);
            this.lblMovieCardTitle.Name = "lblMovieCardTitle";
            this.lblMovieCardTitle.Size = new System.Drawing.Size(230, 25);
            this.lblMovieCardTitle.TabIndex = 0;
            this.lblMovieCardTitle.Text = "Danh m\u1EE5c phim (Admin c\u1EA5p)";
            // 
            // gridMovies
            // 
            this.gridMovies.AllowUserToAddRows = false;
            this.gridMovies.AllowUserToResizeRows = false;
            this.gridMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMovies.BackgroundColor = UiTheme.CardBg;
            this.gridMovies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMovies.ColumnHeadersHeight = 38;
            this.gridMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colName,
            this.colDur,
            this.colGenre,
            this.colAge,
            this.colRange,
            this.colStatus});
            this.gridMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMovies.EnableHeadersVisualStyles = false;
            this.gridMovies.GridColor = UiTheme.Border;
            this.gridMovies.Location = new System.Drawing.Point(12, 42);
            this.gridMovies.MultiSelect = false;
            this.gridMovies.Name = "gridMovies";
            this.gridMovies.ReadOnly = true;
            this.gridMovies.RowHeadersVisible = false;
            this.gridMovies.RowTemplate.Height = 34;
            this.gridMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMovies.Size = new System.Drawing.Size(1052, 190);
            this.gridMovies.TabIndex = 1;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "M\u00E3";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.FillWeight = 55F;
            // 
            // colName
            // 
            this.colName.HeaderText = "T\u00EAn Phim";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.FillWeight = 160F;
            // 
            // colDur
            // 
            this.colDur.HeaderText = "Th\u1EDDi L\u01B0\u1EE3ng";
            this.colDur.Name = "colDur";
            this.colDur.ReadOnly = true;
            this.colDur.FillWeight = 80F;
            // 
            // colGenre
            // 
            this.colGenre.HeaderText = "Th\u1EC3 Lo\u1EA1i";
            this.colGenre.Name = "colGenre";
            this.colGenre.ReadOnly = true;
            this.colGenre.FillWeight = 120F;
            // 
            // colAge
            // 
            this.colAge.HeaderText = "\u0110\u1ED9 Tu\u1ED5i";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            this.colAge.FillWeight = 70F;
            // 
            // colRange
            // 
            this.colRange.HeaderText = "Th\u1EDDi Gian Chi\u1EBFu H\u1EE3p L\u1EC7";
            this.colRange.Name = "colRange";
            this.colRange.ReadOnly = true;
            this.colRange.FillWeight = 150F;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Tr\u1EA1ng Th\u00E1i";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.FillWeight = 90F;
            // 
            // lblHalls
            // 
            this.lblHalls.AutoSize = true;
            this.lblHalls.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHalls.ForeColor = UiTheme.TextMain;
            this.lblHalls.Location = new System.Drawing.Point(0, 335);
            this.lblHalls.Name = "lblHalls";
            this.lblHalls.Size = new System.Drawing.Size(290, 25);
            this.lblHalls.TabIndex = 5;
            this.lblHalls.Text = "Danh s\u00E1ch ph\u00F2ng v\u1EADt l\u00FD && S\u01A1 \u0111\u1ED3 gh\u1EBF";
            // 
            // tlpHalls
            // 
            this.tlpHalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHalls.ColumnCount = 4;
            this.tlpHalls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpHalls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpHalls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpHalls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpHalls.Controls.Add(this.hallCard1, 0, 0);
            this.tlpHalls.Controls.Add(this.hallCard2, 1, 0);
            this.tlpHalls.Controls.Add(this.hallCard3, 2, 0);
            this.tlpHalls.Controls.Add(this.hallCard4, 3, 0);
            this.tlpHalls.Location = new System.Drawing.Point(0, 370);
            this.tlpHalls.Name = "tlpHalls";
            this.tlpHalls.RowCount = 1;
            this.tlpHalls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHalls.Size = new System.Drawing.Size(1080, 170);
            this.tlpHalls.TabIndex = 6;
            // 
            // hallCard1
            // 
            this.hallCard1.BackColor = UiTheme.CardBg;
            this.hallCard1.Paint += UiTheme.DrawCardBorder;
            this.hallCard1.Controls.Add(this.btnHall1);
            this.hallCard1.Controls.Add(this.lblHall1Status);
            this.hallCard1.Controls.Add(this.lblHall1Seats);
            this.hallCard1.Controls.Add(this.lblHall1Type);
            this.hallCard1.Controls.Add(this.lblHall1Name);
            this.hallCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hallCard1.Location = new System.Drawing.Point(0, 0);
            this.hallCard1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.hallCard1.Name = "hallCard1";
            this.hallCard1.Size = new System.Drawing.Size(258, 170);
            this.hallCard1.TabIndex = 0;
            // 
            // lblHall1Name
            // 
            this.lblHall1Name.AutoSize = true;
            this.lblHall1Name.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHall1Name.ForeColor = UiTheme.TextMain;
            this.lblHall1Name.Location = new System.Drawing.Point(12, 12);
            this.lblHall1Name.Name = "lblHall1Name";
            this.lblHall1Name.Size = new System.Drawing.Size(84, 25);
            this.lblHall1Name.TabIndex = 0;
            this.lblHall1Name.Text = "Ph\u00F2ng 01";
            // 
            // lblHall1Type
            // 
            this.lblHall1Type.AutoSize = true;
            this.lblHall1Type.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall1Type.ForeColor = UiTheme.TextMuted;
            this.lblHall1Type.Location = new System.Drawing.Point(12, 44);
            this.lblHall1Type.Name = "lblHall1Type";
            this.lblHall1Type.Size = new System.Drawing.Size(123, 17);
            this.lblHall1Type.TabIndex = 1;
            this.lblHall1Type.Text = "M\u00E0n h\u00ECnh: 2D Digital";
            // 
            // lblHall1Seats
            // 
            this.lblHall1Seats.AutoSize = true;
            this.lblHall1Seats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall1Seats.ForeColor = UiTheme.TextMuted;
            this.lblHall1Seats.Location = new System.Drawing.Point(12, 64);
            this.lblHall1Seats.Name = "lblHall1Seats";
            this.lblHall1Seats.Size = new System.Drawing.Size(104, 17);
            this.lblHall1Seats.TabIndex = 2;
            this.lblHall1Seats.Text = "S\u1EE9c ch\u1EE9a: 120 gh\u1EBF";
            // 
            // lblHall1Status
            // 
            this.lblHall1Status.AutoSize = true;
            this.lblHall1Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHall1Status.ForeColor = UiTheme.Success;
            this.lblHall1Status.Location = new System.Drawing.Point(12, 88);
            this.lblHall1Status.Name = "lblHall1Status";
            this.lblHall1Status.Size = new System.Drawing.Size(93, 15);
            this.lblHall1Status.TabIndex = 3;
            this.lblHall1Status.Text = "\u0110ang ho\u1EA1t \u0111\u1ED9ng";
            // 
            // btnHall1
            // 
            this.btnHall1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHall1.BackColor = UiTheme.CardBg;
            this.btnHall1.FlatAppearance.BorderColor = UiTheme.Border;
            this.btnHall1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHall1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHall1.ForeColor = UiTheme.TextMain;
            this.btnHall1.Location = new System.Drawing.Point(12, 118);
            this.btnHall1.Name = "btnHall1";
            this.btnHall1.Size = new System.Drawing.Size(228, 36);
            this.btnHall1.TabIndex = 4;
            this.btnHall1.Text = "M\u1EDF S\u01A1 \u0110\u1ED3 Ma Tr\u1EADn Gh\u1EBF";
            this.btnHall1.UseVisualStyleBackColor = false;
            // 
            // hallCard2
            // 
            this.hallCard2.BackColor = UiTheme.CardBg;
            this.hallCard2.Paint += UiTheme.DrawCardBorder;
            this.hallCard2.Controls.Add(this.btnHall2);
            this.hallCard2.Controls.Add(this.lblHall2Status);
            this.hallCard2.Controls.Add(this.lblHall2Seats);
            this.hallCard2.Controls.Add(this.lblHall2Type);
            this.hallCard2.Controls.Add(this.lblHall2Name);
            this.hallCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hallCard2.Location = new System.Drawing.Point(270, 0);
            this.hallCard2.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.hallCard2.Name = "hallCard2";
            this.hallCard2.Size = new System.Drawing.Size(258, 170);
            this.hallCard2.TabIndex = 1;
            // 
            // lblHall2Name
            // 
            this.lblHall2Name.AutoSize = true;
            this.lblHall2Name.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHall2Name.ForeColor = UiTheme.TextMain;
            this.lblHall2Name.Location = new System.Drawing.Point(12, 12);
            this.lblHall2Name.Name = "lblHall2Name";
            this.lblHall2Name.Size = new System.Drawing.Size(84, 25);
            this.lblHall2Name.TabIndex = 0;
            this.lblHall2Name.Text = "Ph\u00F2ng 02";
            // 
            // lblHall2Type
            // 
            this.lblHall2Type.AutoSize = true;
            this.lblHall2Type.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall2Type.ForeColor = UiTheme.TextMuted;
            this.lblHall2Type.Location = new System.Drawing.Point(12, 44);
            this.lblHall2Type.Name = "lblHall2Type";
            this.lblHall2Type.Size = new System.Drawing.Size(123, 17);
            this.lblHall2Type.TabIndex = 1;
            this.lblHall2Type.Text = "M\u00E0n h\u00ECnh: 3D Digital";
            // 
            // lblHall2Seats
            // 
            this.lblHall2Seats.AutoSize = true;
            this.lblHall2Seats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall2Seats.ForeColor = UiTheme.TextMuted;
            this.lblHall2Seats.Location = new System.Drawing.Point(12, 64);
            this.lblHall2Seats.Name = "lblHall2Seats";
            this.lblHall2Seats.Size = new System.Drawing.Size(97, 17);
            this.lblHall2Seats.TabIndex = 2;
            this.lblHall2Seats.Text = "S\u1EE9c ch\u1EE9a: 96 gh\u1EBF";
            // 
            // lblHall2Status
            // 
            this.lblHall2Status.AutoSize = true;
            this.lblHall2Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHall2Status.ForeColor = UiTheme.Success;
            this.lblHall2Status.Location = new System.Drawing.Point(12, 88);
            this.lblHall2Status.Name = "lblHall2Status";
            this.lblHall2Status.Size = new System.Drawing.Size(93, 15);
            this.lblHall2Status.TabIndex = 3;
            this.lblHall2Status.Text = "\u0110ang ho\u1EA1t \u0111\u1ED9ng";
            // 
            // btnHall2
            // 
            this.btnHall2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHall2.BackColor = UiTheme.CardBg;
            this.btnHall2.FlatAppearance.BorderColor = UiTheme.Border;
            this.btnHall2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHall2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHall2.ForeColor = UiTheme.TextMain;
            this.btnHall2.Location = new System.Drawing.Point(12, 118);
            this.btnHall2.Name = "btnHall2";
            this.btnHall2.Size = new System.Drawing.Size(228, 36);
            this.btnHall2.TabIndex = 4;
            this.btnHall2.Text = "M\u1EDF S\u01A1 \u0110\u1ED3 Ma Tr\u1EADn Gh\u1EBF";
            this.btnHall2.UseVisualStyleBackColor = false;
            // 
            // hallCard3
            // 
            this.hallCard3.BackColor = UiTheme.CardBg;
            this.hallCard3.Paint += UiTheme.DrawCardBorder;
            this.hallCard3.Controls.Add(this.btnHall3);
            this.hallCard3.Controls.Add(this.lblHall3Status);
            this.hallCard3.Controls.Add(this.lblHall3Seats);
            this.hallCard3.Controls.Add(this.lblHall3Type);
            this.hallCard3.Controls.Add(this.lblHall3Name);
            this.hallCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hallCard3.Location = new System.Drawing.Point(540, 0);
            this.hallCard3.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.hallCard3.Name = "hallCard3";
            this.hallCard3.Size = new System.Drawing.Size(258, 170);
            this.hallCard3.TabIndex = 2;
            // 
            // lblHall3Name
            // 
            this.lblHall3Name.AutoSize = true;
            this.lblHall3Name.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHall3Name.ForeColor = UiTheme.TextMain;
            this.lblHall3Name.Location = new System.Drawing.Point(12, 12);
            this.lblHall3Name.Name = "lblHall3Name";
            this.lblHall3Name.Size = new System.Drawing.Size(84, 25);
            this.lblHall3Name.TabIndex = 0;
            this.lblHall3Name.Text = "Ph\u00F2ng 03";
            // 
            // lblHall3Type
            // 
            this.lblHall3Type.AutoSize = true;
            this.lblHall3Type.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall3Type.ForeColor = UiTheme.TextMuted;
            this.lblHall3Type.Location = new System.Drawing.Point(12, 44);
            this.lblHall3Type.Name = "lblHall3Type";
            this.lblHall3Type.Size = new System.Drawing.Size(123, 17);
            this.lblHall3Type.TabIndex = 1;
            this.lblHall3Type.Text = "M\u00E0n h\u00ECnh: 2D Digital";
            // 
            // lblHall3Seats
            // 
            this.lblHall3Seats.AutoSize = true;
            this.lblHall3Seats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall3Seats.ForeColor = UiTheme.TextMuted;
            this.lblHall3Seats.Location = new System.Drawing.Point(12, 64);
            this.lblHall3Seats.Name = "lblHall3Seats";
            this.lblHall3Seats.Size = new System.Drawing.Size(104, 17);
            this.lblHall3Seats.TabIndex = 2;
            this.lblHall3Seats.Text = "S\u1EE9c ch\u1EE9a: 150 gh\u1EBF";
            // 
            // lblHall3Status
            // 
            this.lblHall3Status.AutoSize = true;
            this.lblHall3Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHall3Status.ForeColor = UiTheme.Amber;
            this.lblHall3Status.Location = new System.Drawing.Point(12, 88);
            this.lblHall3Status.Name = "lblHall3Status";
            this.lblHall3Status.Size = new System.Drawing.Size(102, 15);
            this.lblHall3Status.TabIndex = 3;
            this.lblHall3Status.Text = "B\u1EA3o tr\u00EC m\u00E1y chi\u1EBFu";
            // 
            // btnHall3
            // 
            this.btnHall3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHall3.BackColor = UiTheme.CardBg;
            this.btnHall3.FlatAppearance.BorderColor = UiTheme.Border;
            this.btnHall3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHall3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHall3.ForeColor = UiTheme.TextMain;
            this.btnHall3.Location = new System.Drawing.Point(12, 118);
            this.btnHall3.Name = "btnHall3";
            this.btnHall3.Size = new System.Drawing.Size(228, 36);
            this.btnHall3.TabIndex = 4;
            this.btnHall3.Text = "M\u1EDF S\u01A1 \u0110\u1ED3 Ma Tr\u1EADn Gh\u1EBF";
            this.btnHall3.UseVisualStyleBackColor = false;
            // 
            // hallCard4
            // 
            this.hallCard4.BackColor = UiTheme.CardBg;
            this.hallCard4.Paint += UiTheme.DrawCardBorder;
            this.hallCard4.Controls.Add(this.btnHall4);
            this.hallCard4.Controls.Add(this.lblHall4Status);
            this.hallCard4.Controls.Add(this.lblHall4Seats);
            this.hallCard4.Controls.Add(this.lblHall4Type);
            this.hallCard4.Controls.Add(this.lblHall4Name);
            this.hallCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hallCard4.Location = new System.Drawing.Point(810, 0);
            this.hallCard4.Margin = new System.Windows.Forms.Padding(0);
            this.hallCard4.Name = "hallCard4";
            this.hallCard4.Size = new System.Drawing.Size(270, 170);
            this.hallCard4.TabIndex = 3;
            // 
            // lblHall4Name
            // 
            this.lblHall4Name.AutoSize = true;
            this.lblHall4Name.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHall4Name.ForeColor = UiTheme.TextMain;
            this.lblHall4Name.Location = new System.Drawing.Point(12, 12);
            this.lblHall4Name.Name = "lblHall4Name";
            this.lblHall4Name.Size = new System.Drawing.Size(84, 25);
            this.lblHall4Name.TabIndex = 0;
            this.lblHall4Name.Text = "Ph\u00F2ng 04";
            // 
            // lblHall4Type
            // 
            this.lblHall4Type.AutoSize = true;
            this.lblHall4Type.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall4Type.ForeColor = UiTheme.TextMuted;
            this.lblHall4Type.Location = new System.Drawing.Point(12, 44);
            this.lblHall4Type.Name = "lblHall4Type";
            this.lblHall4Type.Size = new System.Drawing.Size(123, 17);
            this.lblHall4Type.TabIndex = 1;
            this.lblHall4Type.Text = "M\u00E0n h\u00ECnh: 2D Digital";
            // 
            // lblHall4Seats
            // 
            this.lblHall4Seats.AutoSize = true;
            this.lblHall4Seats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHall4Seats.ForeColor = UiTheme.TextMuted;
            this.lblHall4Seats.Location = new System.Drawing.Point(12, 64);
            this.lblHall4Seats.Name = "lblHall4Seats";
            this.lblHall4Seats.Size = new System.Drawing.Size(104, 17);
            this.lblHall4Seats.TabIndex = 2;
            this.lblHall4Seats.Text = "S\u1EE9c ch\u1EE9a: 120 gh\u1EBF";
            // 
            // lblHall4Status
            // 
            this.lblHall4Status.AutoSize = true;
            this.lblHall4Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHall4Status.ForeColor = UiTheme.Success;
            this.lblHall4Status.Location = new System.Drawing.Point(12, 88);
            this.lblHall4Status.Name = "lblHall4Status";
            this.lblHall4Status.Size = new System.Drawing.Size(93, 15);
            this.lblHall4Status.TabIndex = 3;
            this.lblHall4Status.Text = "\u0110ang ho\u1EA1t \u0111\u1ED9ng";
            // 
            // btnHall4
            // 
            this.btnHall4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHall4.BackColor = UiTheme.CardBg;
            this.btnHall4.FlatAppearance.BorderColor = UiTheme.Border;
            this.btnHall4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHall4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHall4.ForeColor = UiTheme.TextMain;
            this.btnHall4.Location = new System.Drawing.Point(12, 118);
            this.btnHall4.Name = "btnHall4";
            this.btnHall4.Size = new System.Drawing.Size(228, 36);
            this.btnHall4.TabIndex = 4;
            this.btnHall4.Text = "M\u1EDF S\u01A1 \u0110\u1ED3 Ma Tr\u1EADn Gh\u1EBF";
            this.btnHall4.UseVisualStyleBackColor = false;
            // 
            this.movieCard.ResumeLayout(false);
            this.movieCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovies)).EndInit();
            this.hallCard1.ResumeLayout(false);
            this.hallCard1.PerformLayout();
            this.hallCard2.ResumeLayout(false);
            this.hallCard2.PerformLayout();
            this.hallCard3.ResumeLayout(false);
            this.hallCard3.PerformLayout();
            this.hallCard4.ResumeLayout(false);
            this.hallCard4.PerformLayout();
            this.tlpHalls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

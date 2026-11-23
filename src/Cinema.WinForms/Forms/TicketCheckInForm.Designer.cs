namespace Cinema.WinForms.Forms
{
    partial class TicketCheckInForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlStaffInfo = new System.Windows.Forms.Panel();
            this.lblStaffRole = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.picStaffAvatar = new System.Windows.Forms.PictureBox();
            this.pnlNavReport = new System.Windows.Forms.Panel();
            this.lblNavReport = new System.Windows.Forms.Label();
            this.pnlNavRooms = new System.Windows.Forms.Panel();
            this.lblNavRooms = new System.Windows.Forms.Label();
            this.pnlNavSchedule = new System.Windows.Forms.Panel();
            this.lblNavSchedule = new System.Windows.Forms.Label();
            this.pnlNavCheckIn = new System.Windows.Forms.Panel();
            this.pnlActiveIndicator = new System.Windows.Forms.Panel();
            this.lblNavCheckIn = new System.Windows.Forms.Label();
            this.pnlNavPos = new System.Windows.Forms.Panel();
            this.lblNavPos = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblCinemaSubtitle = new System.Windows.Forms.Label();
            this.lblCinemaBrand = new System.Windows.Forms.Label();
            this.picLogoBadge = new System.Windows.Forms.PictureBox();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderControls = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.cboShowtime = new System.Windows.Forms.ComboBox();
            this.lblShowtimeFilter = new System.Windows.Forms.Label();
            this.cboAuditorium = new System.Windows.Forms.ComboBox();
            this.lblAuditoriumFilter = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlRightColumn = new System.Windows.Forms.Panel();
            this.pnlCardHistory = new System.Windows.Forms.Panel();
            this.dgvCheckInLogs = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHistoryHeader = new System.Windows.Forms.Panel();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.txtSearchLog = new System.Windows.Forms.TextBox();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlKpiRow = new System.Windows.Forms.Panel();
            this.pnlKpiRate = new System.Windows.Forms.Panel();
            this.lblKpiRateVal = new System.Windows.Forms.Label();
            this.lblKpiRateTitle = new System.Windows.Forms.Label();
            this.pnlKpiRemaining = new System.Windows.Forms.Panel();
            this.lblKpiRemainingVal = new System.Windows.Forms.Label();
            this.lblKpiRemainingTitle = new System.Windows.Forms.Label();
            this.pnlKpiScanned = new System.Windows.Forms.Panel();
            this.lblKpiScannedVal = new System.Windows.Forms.Label();
            this.lblKpiScannedTitle = new System.Windows.Forms.Label();
            this.pnlKpiTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalVal = new System.Windows.Forms.Label();
            this.lblKpiTotalTitle = new System.Windows.Forms.Label();
            this.pnlLeftColumn = new System.Windows.Forms.Panel();
            this.pnlCardResult = new System.Windows.Forms.Panel();
            this.pnlResultBody = new System.Windows.Forms.Panel();
            this.lblValScanTime = new System.Windows.Forms.Label();
            this.lblTitleScanTime = new System.Windows.Forms.Label();
            this.lblValPrice = new System.Windows.Forms.Label();
            this.lblTitlePrice = new System.Windows.Forms.Label();
            this.lblValCustomer = new System.Windows.Forms.Label();
            this.lblTitleCustomer = new System.Windows.Forms.Label();
            this.pnlSeatBadge = new System.Windows.Forms.Panel();
            this.lblSeatType = new System.Windows.Forms.Label();
            this.lblSeatCode = new System.Windows.Forms.Label();
            this.lblValShowtimeRoom = new System.Windows.Forms.Label();
            this.lblTitleShowtimeRoom = new System.Windows.Forms.Label();
            this.lblValMovie = new System.Windows.Forms.Label();
            this.lblTitleMovie = new System.Windows.Forms.Label();
            this.pnlStatusBanner = new System.Windows.Forms.Panel();
            this.lblStatusDesc = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.pnlCardScanner = new System.Windows.Forms.Panel();
            this.pnlMockButtons = new System.Windows.Forms.Panel();
            this.btnMockNotFound = new System.Windows.Forms.Button();
            this.btnMockWrongRoom = new System.Windows.Forms.Button();
            this.btnMockUsed = new System.Windows.Forms.Button();
            this.btnMockValid = new System.Windows.Forms.Button();
            this.lblMockNote = new System.Windows.Forms.Label();
            this.pnlScanLaserTarget = new System.Windows.Forms.Panel();
            this.lblLaserHint = new System.Windows.Forms.Label();
            this.pnlLaserBeam = new System.Windows.Forms.Panel();
            this.pnlInputGroup = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblScannerTitle = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.pnlSidebar.SuspendLayout();
            this.pnlStaffInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaffAvatar)).BeginInit();
            this.pnlNavReport.SuspendLayout();
            this.pnlNavRooms.SuspendLayout();
            this.pnlNavSchedule.SuspendLayout();
            this.pnlNavCheckIn.SuspendLayout();
            this.pnlNavPos.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoBadge)).BeginInit();
            this.pnlTopHeader.SuspendLayout();
            this.pnlHeaderControls.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlRightColumn.SuspendLayout();
            this.pnlCardHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInLogs)).BeginInit();
            this.pnlHistoryHeader.SuspendLayout();
            this.pnlKpiRow.SuspendLayout();
            this.pnlKpiRate.SuspendLayout();
            this.pnlKpiRemaining.SuspendLayout();
            this.pnlKpiScanned.SuspendLayout();
            this.pnlKpiTotal.SuspendLayout();
            this.pnlLeftColumn.SuspendLayout();
            this.pnlCardResult.SuspendLayout();
            this.pnlResultBody.SuspendLayout();
            this.pnlSeatBadge.SuspendLayout();
            this.pnlStatusBanner.SuspendLayout();
            this.pnlCardScanner.SuspendLayout();
            this.pnlMockButtons.SuspendLayout();
            this.pnlScanLaserTarget.SuspendLayout();
            this.pnlInputGroup.SuspendLayout();
            this.SuspendLayout();

            // =========================================================================
            // pnlSidebar (Nền xanh navy: #1E293B)
            // =========================================================================
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.pnlStaffInfo);
            this.pnlSidebar.Controls.Add(this.pnlNavReport);
            this.pnlSidebar.Controls.Add(this.pnlNavRooms);
            this.pnlSidebar.Controls.Add(this.pnlNavSchedule);
            this.pnlSidebar.Controls.Add(this.pnlNavCheckIn);
            this.pnlSidebar.Controls.Add(this.pnlNavPos);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(235, 760);
            this.pnlSidebar.TabIndex = 0;

            // pnlLogo
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlLogo.Controls.Add(this.lblCinemaSubtitle);
            this.pnlLogo.Controls.Add(this.lblCinemaBrand);
            this.pnlLogo.Controls.Add(this.picLogoBadge);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(235, 75);
            this.pnlLogo.TabIndex = 0;

            // picLogoBadge (Huy hiệu Monogram tròn)
            this.picLogoBadge.BackColor = System.Drawing.Color.Transparent;
            this.picLogoBadge.Location = new System.Drawing.Point(14, 15);
            this.picLogoBadge.Name = "picLogoBadge";
            this.picLogoBadge.Size = new System.Drawing.Size(46, 46);
            this.picLogoBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogoBadge.TabIndex = 0;
            this.picLogoBadge.TabStop = false;
            this.picLogoBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogoBadge_Paint);

            // lblCinemaBrand (Màu chữ sáng + nhấn điện ảnh #D97706)
            this.lblCinemaBrand.AutoSize = true;
            this.lblCinemaBrand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCinemaBrand.ForeColor = System.Drawing.Color.White;
            this.lblCinemaBrand.Location = new System.Drawing.Point(67, 18);
            this.lblCinemaBrand.Name = "lblCinemaBrand";
            this.lblCinemaBrand.Size = new System.Drawing.Size(149, 21);
            this.lblCinemaBrand.TabIndex = 1;
            this.lblCinemaBrand.Text = "STORYLINE CINEMA";

            // lblCinemaSubtitle (Chữ phụ: #64748B)
            this.lblCinemaSubtitle.AutoSize = true;
            this.lblCinemaSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCinemaSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCinemaSubtitle.Location = new System.Drawing.Point(68, 41);
            this.lblCinemaSubtitle.Name = "lblCinemaSubtitle";
            this.lblCinemaSubtitle.Size = new System.Drawing.Size(126, 13);
            this.lblCinemaSubtitle.TabIndex = 2;
            this.lblCinemaSubtitle.Text = "Cổng Soát Vé Nhân Viên";

            // pnlNavPos
            this.pnlNavPos.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavPos.Controls.Add(this.lblNavPos);
            this.pnlNavPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavPos.Location = new System.Drawing.Point(0, 75);
            this.pnlNavPos.Name = "pnlNavPos";
            this.pnlNavPos.Size = new System.Drawing.Size(235, 48);
            this.pnlNavPos.TabIndex = 1;

            this.lblNavPos.AutoSize = true;
            this.lblNavPos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavPos.Location = new System.Drawing.Point(22, 15);
            this.lblNavPos.Name = "lblNavPos";
            this.lblNavPos.Size = new System.Drawing.Size(135, 17);
            this.lblNavPos.TabIndex = 0;
            this.lblNavPos.Text = "🎟️   Quầy Bán Vé (POS)";

            // pnlNavCheckIn (Mục đang chọn: Nền slate #334155, vạch trái #3B82F6)
            this.pnlNavCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pnlNavCheckIn.Controls.Add(this.pnlActiveIndicator);
            this.pnlNavCheckIn.Controls.Add(this.lblNavCheckIn);
            this.pnlNavCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavCheckIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavCheckIn.Location = new System.Drawing.Point(0, 123);
            this.pnlNavCheckIn.Name = "pnlNavCheckIn";
            this.pnlNavCheckIn.Size = new System.Drawing.Size(235, 48);
            this.pnlNavCheckIn.TabIndex = 2;

            // pnlActiveIndicator (Vạch trái xanh dương #3B82F6)
            this.pnlActiveIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlActiveIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlActiveIndicator.Location = new System.Drawing.Point(0, 0);
            this.pnlActiveIndicator.Name = "pnlActiveIndicator";
            this.pnlActiveIndicator.Size = new System.Drawing.Size(5, 48);
            this.pnlActiveIndicator.TabIndex = 1;

            this.lblNavCheckIn.AutoSize = true;
            this.lblNavCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavCheckIn.ForeColor = System.Drawing.Color.White;
            this.lblNavCheckIn.Location = new System.Drawing.Point(22, 14);
            this.lblNavCheckIn.Name = "lblNavCheckIn";
            this.lblNavCheckIn.Size = new System.Drawing.Size(155, 19);
            this.lblNavCheckIn.TabIndex = 0;
            this.lblNavCheckIn.Text = "🏷️   Soát Vé Cửa Rạp";

            // pnlNavSchedule
            this.pnlNavSchedule.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavSchedule.Controls.Add(this.lblNavSchedule);
            this.pnlNavSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavSchedule.Location = new System.Drawing.Point(0, 171);
            this.pnlNavSchedule.Name = "pnlNavSchedule";
            this.pnlNavSchedule.Size = new System.Drawing.Size(235, 48);
            this.pnlNavSchedule.TabIndex = 3;

            this.lblNavSchedule.AutoSize = true;
            this.lblNavSchedule.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavSchedule.Location = new System.Drawing.Point(22, 15);
            this.lblNavSchedule.Name = "lblNavSchedule";
            this.lblNavSchedule.Size = new System.Drawing.Size(129, 17);
            this.lblNavSchedule.TabIndex = 0;
            this.lblNavSchedule.Text = "📅   Lịch Chiếu Phim";

            // pnlNavRooms
            this.pnlNavRooms.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavRooms.Controls.Add(this.lblNavRooms);
            this.pnlNavRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavRooms.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavRooms.Location = new System.Drawing.Point(0, 219);
            this.pnlNavRooms.Name = "pnlNavRooms";
            this.pnlNavRooms.Size = new System.Drawing.Size(235, 48);
            this.pnlNavRooms.TabIndex = 4;

            this.lblNavRooms.AutoSize = true;
            this.lblNavRooms.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavRooms.Location = new System.Drawing.Point(22, 15);
            this.lblNavRooms.Name = "lblNavRooms";
            this.lblNavRooms.Size = new System.Drawing.Size(149, 17);
            this.lblNavRooms.TabIndex = 0;
            this.lblNavRooms.Text = "🎬   Sơ Đồ Phòng Chiếu";

            // pnlNavReport
            this.pnlNavReport.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavReport.Controls.Add(this.lblNavReport);
            this.pnlNavReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavReport.Location = new System.Drawing.Point(0, 267);
            this.pnlNavReport.Name = "pnlNavReport";
            this.pnlNavReport.Size = new System.Drawing.Size(235, 48);
            this.pnlNavReport.TabIndex = 5;

            this.lblNavReport.AutoSize = true;
            this.lblNavReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavReport.Location = new System.Drawing.Point(22, 15);
            this.lblNavReport.Name = "lblNavReport";
            this.lblNavReport.Size = new System.Drawing.Size(130, 17);
            this.lblNavReport.TabIndex = 0;
            this.lblNavReport.Text = "📊   Báo Cáo Ca Làm";

            // pnlStaffInfo (Thông tin nhân viên đang đăng nhập ở chân sidebar)
            this.pnlStaffInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlStaffInfo.Controls.Add(this.lblStaffRole);
            this.pnlStaffInfo.Controls.Add(this.lblStaffName);
            this.pnlStaffInfo.Controls.Add(this.picStaffAvatar);
            this.pnlStaffInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStaffInfo.Location = new System.Drawing.Point(0, 695);
            this.pnlStaffInfo.Name = "pnlStaffInfo";
            this.pnlStaffInfo.Size = new System.Drawing.Size(235, 65);
            this.pnlStaffInfo.TabIndex = 6;

            this.picStaffAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.picStaffAvatar.Location = new System.Drawing.Point(14, 12);
            this.picStaffAvatar.Name = "picStaffAvatar";
            this.picStaffAvatar.Size = new System.Drawing.Size(40, 40);
            this.picStaffAvatar.TabIndex = 0;
            this.picStaffAvatar.TabStop = false;
            this.picStaffAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.picStaffAvatar_Paint);

            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStaffName.ForeColor = System.Drawing.Color.White;
            this.lblStaffName.Location = new System.Drawing.Point(62, 13);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(117, 17);
            this.lblStaffName.TabIndex = 1;
            this.lblStaffName.Text = "Phạm Thị Soát Vé";

            this.lblStaffRole.AutoSize = true;
            this.lblStaffRole.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStaffRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblStaffRole.Location = new System.Drawing.Point(62, 33);
            this.lblStaffRole.Name = "lblStaffRole";
            this.lblStaffRole.Size = new System.Drawing.Size(107, 13);
            this.lblStaffRole.TabIndex = 2;
            this.lblStaffRole.Text = "● Đang trực cửa rạp";

            // =========================================================================
            // pnlTopHeader (Màu nền trắng: #FFFFFF, viền dưới #E2E8F0)
            // =========================================================================
            this.pnlTopHeader.BackColor = System.Drawing.Color.White;
            this.pnlTopHeader.Controls.Add(this.pnlHeaderControls);
            this.pnlTopHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlTopHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(235, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1045, 75);
            this.pnlTopHeader.TabIndex = 1;
            this.pnlTopHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopHeader_Paint);

            // lblHeaderTitle (Chữ chính: #0F172A)
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(341, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "CỔNG SOÁT VÉ RẠP CHIẾU (CHECK-IN)";

            // lblHeaderSubtitle (Chữ phụ: #64748B)
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(22, 43);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(377, 15);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Quét mã Barcode / QR vé xem phim trực tiếp - Tự động đối soát phòng";

            // pnlHeaderControls (Bộ lọc phòng chiếu, suất chiếu và đồng hồ thời gian thực)
            this.pnlHeaderControls.Controls.Add(this.lblClock);
            this.pnlHeaderControls.Controls.Add(this.cboShowtime);
            this.pnlHeaderControls.Controls.Add(this.lblShowtimeFilter);
            this.pnlHeaderControls.Controls.Add(this.cboAuditorium);
            this.pnlHeaderControls.Controls.Add(this.lblAuditoriumFilter);
            this.pnlHeaderControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHeaderControls.Location = new System.Drawing.Point(445, 0);
            this.pnlHeaderControls.Name = "pnlHeaderControls";
            this.pnlHeaderControls.Size = new System.Drawing.Size(600, 75);
            this.pnlHeaderControls.TabIndex = 2;

            // lblAuditoriumFilter
            this.lblAuditoriumFilter.AutoSize = true;
            this.lblAuditoriumFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAuditoriumFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAuditoriumFilter.Location = new System.Drawing.Point(10, 15);
            this.lblAuditoriumFilter.Name = "lblAuditoriumFilter";
            this.lblAuditoriumFilter.Size = new System.Drawing.Size(76, 15);
            this.lblAuditoriumFilter.TabIndex = 0;
            this.lblAuditoriumFilter.Text = "Phòng chiếu:";

            // cboAuditorium
            this.cboAuditorium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuditorium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAuditorium.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cboAuditorium.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboAuditorium.FormattingEnabled = true;
            this.cboAuditorium.Location = new System.Drawing.Point(10, 36);
            this.cboAuditorium.Name = "cboAuditorium";
            this.cboAuditorium.Size = new System.Drawing.Size(165, 23);
            this.cboAuditorium.TabIndex = 1;
            this.cboAuditorium.SelectedIndexChanged += new System.EventHandler(this.cboAuditorium_SelectedIndexChanged);

            // lblShowtimeFilter
            this.lblShowtimeFilter.AutoSize = true;
            this.lblShowtimeFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShowtimeFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblShowtimeFilter.Location = new System.Drawing.Point(185, 15);
            this.lblShowtimeFilter.Name = "lblShowtimeFilter";
            this.lblShowtimeFilter.Size = new System.Drawing.Size(68, 15);
            this.lblShowtimeFilter.TabIndex = 2;
            this.lblShowtimeFilter.Text = "Suất chiếu:";

            // cboShowtime
            this.cboShowtime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboShowtime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cboShowtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboShowtime.FormattingEnabled = true;
            this.cboShowtime.Location = new System.Drawing.Point(185, 36);
            this.cboShowtime.Name = "cboShowtime";
            this.cboShowtime.Size = new System.Drawing.Size(255, 23);
            this.cboShowtime.TabIndex = 3;
            this.cboShowtime.SelectedIndexChanged += new System.EventHandler(this.cboShowtime_SelectedIndexChanged);

            // lblClock (Huy hiệu thời gian thực)
            this.lblClock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblClock.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblClock.Location = new System.Drawing.Point(452, 23);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(135, 36);
            this.lblClock.TabIndex = 4;
            this.lblClock.Text = "20:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // =========================================================================
            // pnlMainContent (Nền chính: #F1F5F9)
            // =========================================================================
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlMainContent.Controls.Add(this.pnlRightColumn);
            this.pnlMainContent.Controls.Add(this.pnlLeftColumn);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(235, 75);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMainContent.Size = new System.Drawing.Size(1045, 685);
            this.pnlMainContent.TabIndex = 2;

            // =========================================================================
            // CỘT TRÁI: pnlLeftColumn (Width: 460)
            // =========================================================================
            this.pnlLeftColumn.Controls.Add(this.pnlCardResult);
            this.pnlLeftColumn.Controls.Add(this.pnlCardScanner);
            this.pnlLeftColumn.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftColumn.Location = new System.Drawing.Point(15, 15);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(460, 655);
            this.pnlLeftColumn.TabIndex = 0;

            // -------------------------------------------------------------------------
            // Card 1: pnlCardScanner (Nền trắng #FFFFFF, viền #E2E8F0)
            // -------------------------------------------------------------------------
            this.pnlCardScanner.BackColor = System.Drawing.Color.White;
            this.pnlCardScanner.Controls.Add(this.pnlMockButtons);
            this.pnlCardScanner.Controls.Add(this.pnlScanLaserTarget);
            this.pnlCardScanner.Controls.Add(this.pnlInputGroup);
            this.pnlCardScanner.Controls.Add(this.lblScannerTitle);
            this.pnlCardScanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardScanner.Location = new System.Drawing.Point(0, 0);
            this.pnlCardScanner.Name = "pnlCardScanner";
            this.pnlCardScanner.Padding = new System.Windows.Forms.Padding(14);
            this.pnlCardScanner.Size = new System.Drawing.Size(460, 275);
            this.pnlCardScanner.TabIndex = 0;
            this.pnlCardScanner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            // lblScannerTitle
            this.lblScannerTitle.AutoSize = true;
            this.lblScannerTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScannerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblScannerTitle.Location = new System.Drawing.Point(14, 12);
            this.lblScannerTitle.Name = "lblScannerTitle";
            this.lblScannerTitle.Size = new System.Drawing.Size(225, 19);
            this.lblScannerTitle.TabIndex = 0;
            this.lblScannerTitle.Text = "📷  QUÉT MÃ VẠCH / NHẬP MÃ VÉ";

            // pnlInputGroup (Ô nhập mã vạch & 2 nút)
            this.pnlInputGroup.Controls.Add(this.btnClear);
            this.pnlInputGroup.Controls.Add(this.btnCheckIn);
            this.pnlInputGroup.Controls.Add(this.txtBarcode);
            this.pnlInputGroup.Location = new System.Drawing.Point(14, 40);
            this.pnlInputGroup.Name = "pnlInputGroup";
            this.pnlInputGroup.Size = new System.Drawing.Size(432, 78);
            this.pnlInputGroup.TabIndex = 1;

            // txtBarcode (Ô nhập mã vạch to, đậm)
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Consolas", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtBarcode.Location = new System.Drawing.Point(0, 0);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PlaceholderText = "Quét mã vạch hoặc nhập mã vé tại đây...";
            this.txtBarcode.Size = new System.Drawing.Size(432, 29);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // btnCheckIn (Màu chủ đạo #2563EB)
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(0, 36);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(325, 36);
            this.btnCheckIn.TabIndex = 1;
            this.btnCheckIn.Text = "✓   XÁC NHẬN SOÁT VÉ (ENTER)";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);

            // btnClear (Nút Xóa / Làm mới)
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClear.Location = new System.Drawing.Point(333, 36);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 36);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "↺ Làm mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // pnlScanLaserTarget (Khung quét laser mô phỏng)
            this.pnlScanLaserTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlScanLaserTarget.Controls.Add(this.lblLaserHint);
            this.pnlScanLaserTarget.Controls.Add(this.pnlLaserBeam);
            this.pnlScanLaserTarget.Location = new System.Drawing.Point(14, 125);
            this.pnlScanLaserTarget.Name = "pnlScanLaserTarget";
            this.pnlScanLaserTarget.Size = new System.Drawing.Size(432, 65);
            this.pnlScanLaserTarget.TabIndex = 2;
            this.pnlScanLaserTarget.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlScanLaserTarget_Paint);

            // pnlLaserBeam (Tia laser đỏ)
            this.pnlLaserBeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.pnlLaserBeam.Location = new System.Drawing.Point(20, 31);
            this.pnlLaserBeam.Name = "pnlLaserBeam";
            this.pnlLaserBeam.Size = new System.Drawing.Size(392, 2);
            this.pnlLaserBeam.TabIndex = 0;

            // lblLaserHint
            this.lblLaserHint.AutoSize = true;
            this.lblLaserHint.BackColor = System.Drawing.Color.Transparent;
            this.lblLaserHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLaserHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLaserHint.Location = new System.Drawing.Point(105, 40);
            this.lblLaserHint.Name = "lblLaserHint";
            this.lblLaserHint.Size = new System.Drawing.Size(222, 13);
            this.lblLaserHint.TabIndex = 1;
            this.lblLaserHint.Text = "Sẵn sàng nhận tín hiệu máy quét Barcode / QR";

            // pnlMockButtons (Dãy nút test mẫu nhanh cho Frontend)
            this.pnlMockButtons.Controls.Add(this.btnMockNotFound);
            this.pnlMockButtons.Controls.Add(this.btnMockWrongRoom);
            this.pnlMockButtons.Controls.Add(this.btnMockUsed);
            this.pnlMockButtons.Controls.Add(this.btnMockValid);
            this.pnlMockButtons.Controls.Add(this.lblMockNote);
            this.pnlMockButtons.Location = new System.Drawing.Point(14, 198);
            this.pnlMockButtons.Name = "pnlMockButtons";
            this.pnlMockButtons.Size = new System.Drawing.Size(432, 65);
            this.pnlMockButtons.TabIndex = 3;

            this.lblMockNote.AutoSize = true;
            this.lblMockNote.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblMockNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMockNote.Location = new System.Drawing.Point(0, 5);
            this.lblMockNote.Name = "lblMockNote";
            this.lblMockNote.Size = new System.Drawing.Size(221, 12);
            this.lblMockNote.TabIndex = 0;
            this.lblMockNote.Text = "Thử nhanh các trường hợp kiểm tra (Mock Tester):";

            // btnMockValid
            this.btnMockValid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.btnMockValid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMockValid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(243)))), ((int)(((byte)(208)))));
            this.btnMockValid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMockValid.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMockValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnMockValid.Location = new System.Drawing.Point(0, 24);
            this.btnMockValid.Name = "btnMockValid";
            this.btnMockValid.Size = new System.Drawing.Size(100, 32);
            this.btnMockValid.TabIndex = 1;
            this.btnMockValid.Text = "✓ Vé Hợp Lệ";
            this.btnMockValid.UseVisualStyleBackColor = false;
            this.btnMockValid.Click += new System.EventHandler(this.btnMockValid_Click);

            // btnMockUsed
            this.btnMockUsed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.btnMockUsed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMockUsed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(138)))));
            this.btnMockUsed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMockUsed.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMockUsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnMockUsed.Location = new System.Drawing.Point(108, 24);
            this.btnMockUsed.Name = "btnMockUsed";
            this.btnMockUsed.Size = new System.Drawing.Size(100, 32);
            this.btnMockUsed.TabIndex = 2;
            this.btnMockUsed.Text = "⚠️ Đã Quét";
            this.btnMockUsed.UseVisualStyleBackColor = false;
            this.btnMockUsed.Click += new System.EventHandler(this.btnMockUsed_Click);

            // btnMockWrongRoom
            this.btnMockWrongRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.btnMockWrongRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMockWrongRoom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(170)))));
            this.btnMockWrongRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMockWrongRoom.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMockWrongRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnMockWrongRoom.Location = new System.Drawing.Point(216, 24);
            this.btnMockWrongRoom.Name = "btnMockWrongRoom";
            this.btnMockWrongRoom.Size = new System.Drawing.Size(104, 32);
            this.btnMockWrongRoom.TabIndex = 3;
            this.btnMockWrongRoom.Text = "🚫 Sai Phòng";
            this.btnMockWrongRoom.UseVisualStyleBackColor = false;
            this.btnMockWrongRoom.Click += new System.EventHandler(this.btnMockWrongRoom_Click);

            // btnMockNotFound
            this.btnMockNotFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnMockNotFound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMockNotFound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.btnMockNotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMockNotFound.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMockNotFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnMockNotFound.Location = new System.Drawing.Point(328, 24);
            this.btnMockNotFound.Name = "btnMockNotFound";
            this.btnMockNotFound.Size = new System.Drawing.Size(104, 32);
            this.btnMockNotFound.TabIndex = 4;
            this.btnMockNotFound.Text = "❌ Không Có";
            this.btnMockNotFound.UseVisualStyleBackColor = false;
            this.btnMockNotFound.Click += new System.EventHandler(this.btnMockNotFound_Click);

            // -------------------------------------------------------------------------
            // Card 2: pnlCardResult (Thẻ hiển thị kết quả xác thực vé)
            // -------------------------------------------------------------------------
            this.pnlCardResult.BackColor = System.Drawing.Color.White;
            this.pnlCardResult.Controls.Add(this.pnlResultBody);
            this.pnlCardResult.Controls.Add(this.pnlStatusBanner);
            this.pnlCardResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardResult.Location = new System.Drawing.Point(0, 275);
            this.pnlCardResult.Name = "pnlCardResult";
            this.pnlCardResult.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pnlCardResult.Size = new System.Drawing.Size(460, 380);
            this.pnlCardResult.TabIndex = 1;

            // pnlStatusBanner (Banner trạng thái động to, rõ ràng)
            this.pnlStatusBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.pnlStatusBanner.Controls.Add(this.lblStatusDesc);
            this.pnlStatusBanner.Controls.Add(this.lblStatusTitle);
            this.pnlStatusBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusBanner.Location = new System.Drawing.Point(0, 15);
            this.pnlStatusBanner.Name = "pnlStatusBanner";
            this.pnlStatusBanner.Size = new System.Drawing.Size(460, 68);
            this.pnlStatusBanner.TabIndex = 0;
            this.pnlStatusBanner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatusBanner_Paint);

            // lblStatusTitle
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(16, 11);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(306, 25);
            this.lblStatusTitle.TabIndex = 0;
            this.lblStatusTitle.Text = "✓  VÉ HỢP LỆ - MỜI VÀO PHÒNG";

            // lblStatusDesc
            this.lblStatusDesc.AutoSize = true;
            this.lblStatusDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatusDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.lblStatusDesc.Location = new System.Drawing.Point(18, 38);
            this.lblStatusDesc.Name = "lblStatusDesc";
            this.lblStatusDesc.Size = new System.Drawing.Size(342, 15);
            this.lblStatusDesc.TabIndex = 1;
            this.lblStatusDesc.Text = "Vé đúng suất chiếu, phòng chiếu và chưa từng quét qua cửa rạp.";

            // pnlResultBody (Thông tin chi tiết tấm vé)
            this.pnlResultBody.Controls.Add(this.lblValScanTime);
            this.pnlResultBody.Controls.Add(this.lblTitleScanTime);
            this.pnlResultBody.Controls.Add(this.lblValPrice);
            this.pnlResultBody.Controls.Add(this.lblTitlePrice);
            this.pnlResultBody.Controls.Add(this.lblValCustomer);
            this.pnlResultBody.Controls.Add(this.lblTitleCustomer);
            this.pnlResultBody.Controls.Add(this.pnlSeatBadge);
            this.pnlResultBody.Controls.Add(this.lblValShowtimeRoom);
            this.pnlResultBody.Controls.Add(this.lblTitleShowtimeRoom);
            this.pnlResultBody.Controls.Add(this.lblValMovie);
            this.pnlResultBody.Controls.Add(this.lblTitleMovie);
            this.pnlResultBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultBody.Location = new System.Drawing.Point(0, 83);
            this.pnlResultBody.Name = "pnlResultBody";
            this.pnlResultBody.Padding = new System.Windows.Forms.Padding(16);
            this.pnlResultBody.Size = new System.Drawing.Size(460, 297);
            this.pnlResultBody.TabIndex = 1;

            // Phim
            this.lblTitleMovie.AutoSize = true;
            this.lblTitleMovie.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleMovie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitleMovie.Location = new System.Drawing.Point(14, 12);
            this.lblTitleMovie.Name = "lblTitleMovie";
            this.lblTitleMovie.Size = new System.Drawing.Size(65, 15);
            this.lblTitleMovie.TabIndex = 0;
            this.lblTitleMovie.Text = "PHIM XEM:";

            this.lblValMovie.AutoSize = true;
            this.lblValMovie.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValMovie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblValMovie.Location = new System.Drawing.Point(14, 29);
            this.lblValMovie.Name = "lblValMovie";
            this.lblValMovie.Size = new System.Drawing.Size(252, 21);
            this.lblValMovie.TabIndex = 1;
            this.lblValMovie.Text = "Mai (T18) - Bản Chiếu Tiêu Chuẩn";

            // Phòng & Suất
            this.lblTitleShowtimeRoom.AutoSize = true;
            this.lblTitleShowtimeRoom.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleShowtimeRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitleShowtimeRoom.Location = new System.Drawing.Point(14, 60);
            this.lblTitleShowtimeRoom.Name = "lblTitleShowtimeRoom";
            this.lblTitleShowtimeRoom.Size = new System.Drawing.Size(147, 15);
            this.lblTitleShowtimeRoom.TabIndex = 2;
            this.lblTitleShowtimeRoom.Text = "PHÒNG & SUẤT CHIẾU:";

            this.lblValShowtimeRoom.AutoSize = true;
            this.lblValShowtimeRoom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValShowtimeRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblValShowtimeRoom.Location = new System.Drawing.Point(14, 77);
            this.lblValShowtimeRoom.Name = "lblValShowtimeRoom";
            this.lblValShowtimeRoom.Size = new System.Drawing.Size(264, 19);
            this.lblValShowtimeRoom.TabIndex = 3;
            this.lblValShowtimeRoom.Text = "Cinema 01 - Tiêu Chuẩn  |  18:00 - 20:11";

            // pnlSeatBadge (Huy hiệu Ghế ngồi to nổi bật)
            this.pnlSeatBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.pnlSeatBadge.Controls.Add(this.lblSeatType);
            this.pnlSeatBadge.Controls.Add(this.lblSeatCode);
            this.pnlSeatBadge.Location = new System.Drawing.Point(305, 14);
            this.pnlSeatBadge.Name = "pnlSeatBadge";
            this.pnlSeatBadge.Size = new System.Drawing.Size(135, 82);
            this.pnlSeatBadge.TabIndex = 4;
            this.pnlSeatBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSeatBadge_Paint);

            this.lblSeatCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeatCode.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeatCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblSeatCode.Location = new System.Drawing.Point(0, 0);
            this.lblSeatCode.Name = "lblSeatCode";
            this.lblSeatCode.Size = new System.Drawing.Size(135, 48);
            this.lblSeatCode.TabIndex = 0;
            this.lblSeatCode.Text = "E05";
            this.lblSeatCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSeatType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSeatType.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeatType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(18)))), ((int)(((byte)(57)))));
            this.lblSeatType.Location = new System.Drawing.Point(0, 48);
            this.lblSeatType.Name = "lblSeatType";
            this.lblSeatType.Size = new System.Drawing.Size(135, 34);
            this.lblSeatType.TabIndex = 1;
            this.lblSeatType.Text = "GHẾ VIP";
            this.lblSeatType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Khách hàng & Điểm
            this.lblTitleCustomer.AutoSize = true;
            this.lblTitleCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitleCustomer.Location = new System.Drawing.Point(14, 110);
            this.lblTitleCustomer.Name = "lblTitleCustomer";
            this.lblTitleCustomer.Size = new System.Drawing.Size(91, 15);
            this.lblTitleCustomer.TabIndex = 5;
            this.lblTitleCustomer.Text = "KHÁCH HÀNG:";

            this.lblValCustomer.AutoSize = true;
            this.lblValCustomer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblValCustomer.Location = new System.Drawing.Point(14, 128);
            this.lblValCustomer.Name = "lblValCustomer";
            this.lblValCustomer.Size = new System.Drawing.Size(265, 17);
            this.lblValCustomer.TabIndex = 6;
            this.lblValCustomer.Text = "Trần Minh Hoàng  (⭐ Thành viên Vàng)";

            // Giá vé
            this.lblTitlePrice.AutoSize = true;
            this.lblTitlePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitlePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitlePrice.Location = new System.Drawing.Point(14, 158);
            this.lblTitlePrice.Name = "lblTitlePrice";
            this.lblTitlePrice.Size = new System.Drawing.Size(53, 15);
            this.lblTitlePrice.TabIndex = 7;
            this.lblTitlePrice.Text = "GIÁ VÉ:";

            this.lblValPrice.AutoSize = true;
            this.lblValPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblValPrice.Location = new System.Drawing.Point(14, 176);
            this.lblValPrice.Name = "lblValPrice";
            this.lblValPrice.Size = new System.Drawing.Size(161, 19);
            this.lblValPrice.TabIndex = 8;
            this.lblValPrice.Text = "105,000 VND (Đã TT)";

            // Thời gian soát vé
            this.lblTitleScanTime.AutoSize = true;
            this.lblTitleScanTime.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleScanTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitleScanTime.Location = new System.Drawing.Point(14, 206);
            this.lblTitleScanTime.Name = "lblTitleScanTime";
            this.lblTitleScanTime.Size = new System.Drawing.Size(126, 15);
            this.lblTitleScanTime.TabIndex = 9;
            this.lblTitleScanTime.Text = "THỜI ĐIỂM QUÉT VÉ:";

            this.lblValScanTime.AutoSize = true;
            this.lblValScanTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblValScanTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblValScanTime.Location = new System.Drawing.Point(14, 224);
            this.lblValScanTime.Name = "lblValScanTime";
            this.lblValScanTime.Size = new System.Drawing.Size(193, 17);
            this.lblValScanTime.TabIndex = 10;
            this.lblValScanTime.Text = "Vừa xong lúc 20:01:15 hôm nay";

            // =========================================================================
            // CỘT PHẢI: pnlRightColumn (Fill)
            // =========================================================================
            this.pnlRightColumn.Controls.Add(this.pnlCardHistory);
            this.pnlRightColumn.Controls.Add(this.pnlKpiRow);
            this.pnlRightColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightColumn.Location = new System.Drawing.Point(475, 15);
            this.pnlRightColumn.Name = "pnlRightColumn";
            this.pnlRightColumn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.pnlRightColumn.Size = new System.Drawing.Size(555, 655);
            this.pnlRightColumn.TabIndex = 1;

            // -------------------------------------------------------------------------
            // Hàng 4 Thẻ KPI: pnlKpiRow (Height: 80)
            // -------------------------------------------------------------------------
            this.pnlKpiRow.Controls.Add(this.pnlKpiRate);
            this.pnlKpiRow.Controls.Add(this.pnlKpiRemaining);
            this.pnlKpiRow.Controls.Add(this.pnlKpiScanned);
            this.pnlKpiRow.Controls.Add(this.pnlKpiTotal);
            this.pnlKpiRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiRow.Location = new System.Drawing.Point(15, 0);
            this.pnlKpiRow.Name = "pnlKpiRow";
            this.pnlKpiRow.Size = new System.Drawing.Size(540, 80);
            this.pnlKpiRow.TabIndex = 0;

            // KPI 1: Tổng số vé
            this.pnlKpiTotal.BackColor = System.Drawing.Color.White;
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalVal);
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalTitle);
            this.pnlKpiTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiTotal.Name = "pnlKpiTotal";
            this.pnlKpiTotal.Padding = new System.Windows.Forms.Padding(10);
            this.pnlKpiTotal.Size = new System.Drawing.Size(125, 78);
            this.pnlKpiTotal.TabIndex = 0;
            this.pnlKpiTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.lblKpiTotalTitle.AutoSize = true;
            this.lblKpiTotalTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiTotalTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiTotalTitle.Name = "lblKpiTotalTitle";
            this.lblKpiTotalTitle.Size = new System.Drawing.Size(73, 12);
            this.lblKpiTotalTitle.TabIndex = 0;
            this.lblKpiTotalTitle.Text = "TỔNG VÉ SUẤT";

            this.lblKpiTotalVal.AutoSize = true;
            this.lblKpiTotalVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiTotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiTotalVal.Location = new System.Drawing.Point(6, 24);
            this.lblKpiTotalVal.Name = "lblKpiTotalVal";
            this.lblKpiTotalVal.Size = new System.Drawing.Size(49, 37);
            this.lblKpiTotalVal.TabIndex = 1;
            this.lblKpiTotalVal.Text = "80";

            // KPI 2: Đã vào rạp (Xanh lá)
            this.pnlKpiScanned.BackColor = System.Drawing.Color.White;
            this.pnlKpiScanned.Controls.Add(this.lblKpiScannedVal);
            this.pnlKpiScanned.Controls.Add(this.lblKpiScannedTitle);
            this.pnlKpiScanned.Location = new System.Drawing.Point(135, 0);
            this.pnlKpiScanned.Name = "pnlKpiScanned";
            this.pnlKpiScanned.Padding = new System.Windows.Forms.Padding(10);
            this.pnlKpiScanned.Size = new System.Drawing.Size(125, 78);
            this.pnlKpiScanned.TabIndex = 1;
            this.pnlKpiScanned.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.lblKpiScannedTitle.AutoSize = true;
            this.lblKpiScannedTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiScannedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblKpiScannedTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiScannedTitle.Name = "lblKpiScannedTitle";
            this.lblKpiScannedTitle.Size = new System.Drawing.Size(71, 12);
            this.lblKpiScannedTitle.TabIndex = 0;
            this.lblKpiScannedTitle.Text = "✓ ĐÃ VÀO RẠP";

            this.lblKpiScannedVal.AutoSize = true;
            this.lblKpiScannedVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiScannedVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblKpiScannedVal.Location = new System.Drawing.Point(6, 24);
            this.lblKpiScannedVal.Name = "lblKpiScannedVal";
            this.lblKpiScannedVal.Size = new System.Drawing.Size(49, 37);
            this.lblKpiScannedVal.TabIndex = 1;
            this.lblKpiScannedVal.Text = "54";

            // KPI 3: Chưa vào rạp (Xanh dương)
            this.pnlKpiRemaining.BackColor = System.Drawing.Color.White;
            this.pnlKpiRemaining.Controls.Add(this.lblKpiRemainingVal);
            this.pnlKpiRemaining.Controls.Add(this.lblKpiRemainingTitle);
            this.pnlKpiRemaining.Location = new System.Drawing.Point(270, 0);
            this.pnlKpiRemaining.Name = "pnlKpiRemaining";
            this.pnlKpiRemaining.Padding = new System.Windows.Forms.Padding(10);
            this.pnlKpiRemaining.Size = new System.Drawing.Size(125, 78);
            this.pnlKpiRemaining.TabIndex = 2;
            this.pnlKpiRemaining.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.lblKpiRemainingTitle.AutoSize = true;
            this.lblKpiRemainingTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRemainingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblKpiRemainingTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiRemainingTitle.Name = "lblKpiRemainingTitle";
            this.lblKpiRemainingTitle.Size = new System.Drawing.Size(63, 12);
            this.lblKpiRemainingTitle.TabIndex = 0;
            this.lblKpiRemainingTitle.Text = "CHƯA VÀO";

            this.lblKpiRemainingVal.AutoSize = true;
            this.lblKpiRemainingVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRemainingVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblKpiRemainingVal.Location = new System.Drawing.Point(6, 24);
            this.lblKpiRemainingVal.Name = "lblKpiRemainingVal";
            this.lblKpiRemainingVal.Size = new System.Drawing.Size(49, 37);
            this.lblKpiRemainingVal.TabIndex = 1;
            this.lblKpiRemainingVal.Text = "26";

            // KPI 4: Tỷ lệ check-in (Vàng nhấn điện ảnh #D97706)
            this.pnlKpiRate.BackColor = System.Drawing.Color.White;
            this.pnlKpiRate.Controls.Add(this.lblKpiRateVal);
            this.pnlKpiRate.Controls.Add(this.lblKpiRateTitle);
            this.pnlKpiRate.Location = new System.Drawing.Point(405, 0);
            this.pnlKpiRate.Name = "pnlKpiRate";
            this.pnlKpiRate.Padding = new System.Windows.Forms.Padding(10);
            this.pnlKpiRate.Size = new System.Drawing.Size(135, 78);
            this.pnlKpiRate.TabIndex = 3;
            this.pnlKpiRate.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.lblKpiRateTitle.AutoSize = true;
            this.lblKpiRateTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblKpiRateTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiRateTitle.Name = "lblKpiRateTitle";
            this.lblKpiRateTitle.Size = new System.Drawing.Size(89, 12);
            this.lblKpiRateTitle.TabIndex = 0;
            this.lblKpiRateTitle.Text = "TỶ LỆ CHECK-IN";

            this.lblKpiRateVal.AutoSize = true;
            this.lblKpiRateVal.Font = new System.Drawing.Font("Segoe UI", 18.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblKpiRateVal.Location = new System.Drawing.Point(6, 25);
            this.lblKpiRateVal.Name = "lblKpiRateVal";
            this.lblKpiRateVal.Size = new System.Drawing.Size(88, 35);
            this.lblKpiRateVal.TabIndex = 1;
            this.lblKpiRateVal.Text = "67.5%";

            // -------------------------------------------------------------------------
            // Card Bảng Lịch Sử: pnlCardHistory (Fill)
            // -------------------------------------------------------------------------
            this.pnlCardHistory.BackColor = System.Drawing.Color.White;
            this.pnlCardHistory.Controls.Add(this.dgvCheckInLogs);
            this.pnlCardHistory.Controls.Add(this.pnlHistoryHeader);
            this.pnlCardHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardHistory.Location = new System.Drawing.Point(15, 80);
            this.pnlCardHistory.Name = "pnlCardHistory";
            this.pnlCardHistory.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pnlCardHistory.Size = new System.Drawing.Size(540, 575);
            this.pnlCardHistory.TabIndex = 1;

            // pnlHistoryHeader
            this.pnlHistoryHeader.BackColor = System.Drawing.Color.White;
            this.pnlHistoryHeader.Controls.Add(this.btnExportLog);
            this.pnlHistoryHeader.Controls.Add(this.txtSearchLog);
            this.pnlHistoryHeader.Controls.Add(this.lblHistoryTitle);
            this.pnlHistoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistoryHeader.Location = new System.Drawing.Point(0, 15);
            this.pnlHistoryHeader.Name = "pnlHistoryHeader";
            this.pnlHistoryHeader.Size = new System.Drawing.Size(540, 48);
            this.pnlHistoryHeader.TabIndex = 0;
            this.pnlHistoryHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            // lblHistoryTitle
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(12, 14);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(189, 19);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "📋  NHẬT KÝ SOÁT VÉ GẦN ĐÂY";

            // txtSearchLog
            this.txtSearchLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtSearchLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchLog.Location = new System.Drawing.Point(230, 12);
            this.txtSearchLog.Name = "txtSearchLog";
            this.txtSearchLog.PlaceholderText = "🔍 Tìm mã vé, ghế...";
            this.txtSearchLog.Size = new System.Drawing.Size(190, 23);
            this.txtSearchLog.TabIndex = 1;
            this.txtSearchLog.TextChanged += new System.EventHandler(this.txtSearchLog_TextChanged);

            // btnExportLog
            this.btnExportLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnExportLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnExportLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLog.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnExportLog.Location = new System.Drawing.Point(428, 12);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(100, 24);
            this.btnExportLog.TabIndex = 2;
            this.btnExportLog.Text = "Xuất Excel";
            this.btnExportLog.UseVisualStyleBackColor = false;
            this.btnExportLog.Click += new System.EventHandler(this.btnExportLog_Click);

            // dgvCheckInLogs (Bảng nhật ký phẳng, màu hiện đại)
            this.dgvCheckInLogs.AllowUserToAddRows = false;
            this.dgvCheckInLogs.AllowUserToDeleteRows = false;
            this.dgvCheckInLogs.AllowUserToResizeRows = false;
            this.dgvCheckInLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckInLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCheckInLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCheckInLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheckInLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCheckInLogs.ColumnHeadersHeight = 36;
            this.dgvCheckInLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCheckInLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colBarcode,
            this.colMovie,
            this.colRoom,
            this.colSeat,
            this.colCustomer,
            this.colStatus,
            this.colNote});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCheckInLogs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCheckInLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckInLogs.EnableHeadersVisualStyles = false;
            this.dgvCheckInLogs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvCheckInLogs.Location = new System.Drawing.Point(0, 63);
            this.dgvCheckInLogs.MultiSelect = false;
            this.dgvCheckInLogs.Name = "dgvCheckInLogs";
            this.dgvCheckInLogs.ReadOnly = true;
            this.dgvCheckInLogs.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvCheckInLogs.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCheckInLogs.RowTemplate.Height = 34;
            this.dgvCheckInLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckInLogs.Size = new System.Drawing.Size(540, 512);
            this.dgvCheckInLogs.TabIndex = 1;
            this.dgvCheckInLogs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCheckInLogs_CellFormatting);

            // colTime
            this.colTime.HeaderText = "Giờ";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 65;

            // colBarcode
            this.colBarcode.HeaderText = "Mã Vé";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Width = 110;

            // colMovie
            this.colMovie.HeaderText = "Phim";
            this.colMovie.Name = "colMovie";
            this.colMovie.ReadOnly = true;
            this.colMovie.Width = 115;

            // colRoom
            this.colRoom.HeaderText = "Phòng";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            this.colRoom.Width = 75;

            // colSeat
            this.colSeat.HeaderText = "Ghế";
            this.colSeat.Name = "colSeat";
            this.colSeat.ReadOnly = true;
            this.colSeat.Width = 60;

            // colCustomer
            this.colCustomer.HeaderText = "Khách Hàng";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 110;

            // colStatus
            this.colStatus.HeaderText = "Kết Quả";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 90;

            // colNote
            this.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote.HeaderText = "Ghi Chú";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;

            // timerClock
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // =========================================================================
            // TicketCheckInForm
            // =========================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "TicketCheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STORYLINE CINEMA - CỔNG SOÁT VÉ CỬA RẠP";
            this.Load += new System.EventHandler(this.TicketCheckInForm_Load);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlStaffInfo.ResumeLayout(false);
            this.pnlStaffInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaffAvatar)).EndInit();
            this.pnlNavReport.ResumeLayout(false);
            this.pnlNavReport.PerformLayout();
            this.pnlNavRooms.ResumeLayout(false);
            this.pnlNavRooms.PerformLayout();
            this.pnlNavSchedule.ResumeLayout(false);
            this.pnlNavSchedule.PerformLayout();
            this.pnlNavCheckIn.ResumeLayout(false);
            this.pnlNavCheckIn.PerformLayout();
            this.pnlNavPos.ResumeLayout(false);
            this.pnlNavPos.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoBadge)).EndInit();
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlHeaderControls.ResumeLayout(false);
            this.pnlHeaderControls.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlRightColumn.ResumeLayout(false);
            this.pnlCardHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInLogs)).EndInit();
            this.pnlHistoryHeader.ResumeLayout(false);
            this.pnlHistoryHeader.PerformLayout();
            this.pnlKpiRow.ResumeLayout(false);
            this.pnlKpiRate.ResumeLayout(false);
            this.pnlKpiRate.PerformLayout();
            this.pnlKpiRemaining.ResumeLayout(false);
            this.pnlKpiRemaining.PerformLayout();
            this.pnlKpiScanned.ResumeLayout(false);
            this.pnlKpiScanned.PerformLayout();
            this.pnlKpiTotal.ResumeLayout(false);
            this.pnlKpiTotal.PerformLayout();
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlCardResult.ResumeLayout(false);
            this.pnlResultBody.ResumeLayout(false);
            this.pnlResultBody.PerformLayout();
            this.pnlSeatBadge.ResumeLayout(false);
            this.pnlStatusBanner.ResumeLayout(false);
            this.pnlStatusBanner.PerformLayout();
            this.pnlCardScanner.ResumeLayout(false);
            this.pnlCardScanner.PerformLayout();
            this.pnlMockButtons.ResumeLayout(false);
            this.pnlMockButtons.PerformLayout();
            this.pnlScanLaserTarget.ResumeLayout(false);
            this.pnlScanLaserTarget.PerformLayout();
            this.pnlInputGroup.ResumeLayout(false);
            this.pnlInputGroup.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox picLogoBadge;
        private System.Windows.Forms.Label lblCinemaBrand;
        private System.Windows.Forms.Label lblCinemaSubtitle;
        private System.Windows.Forms.Panel pnlNavPos;
        private System.Windows.Forms.Label lblNavPos;
        private System.Windows.Forms.Panel pnlNavCheckIn;
        private System.Windows.Forms.Panel pnlActiveIndicator;
        private System.Windows.Forms.Label lblNavCheckIn;
        private System.Windows.Forms.Panel pnlNavSchedule;
        private System.Windows.Forms.Label lblNavSchedule;
        private System.Windows.Forms.Panel pnlNavRooms;
        private System.Windows.Forms.Label lblNavRooms;
        private System.Windows.Forms.Panel pnlNavReport;
        private System.Windows.Forms.Label lblNavReport;
        private System.Windows.Forms.Panel pnlStaffInfo;
        private System.Windows.Forms.PictureBox picStaffAvatar;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblStaffRole;
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Panel pnlHeaderControls;
        private System.Windows.Forms.Label lblAuditoriumFilter;
        private System.Windows.Forms.ComboBox cboAuditorium;
        private System.Windows.Forms.Label lblShowtimeFilter;
        private System.Windows.Forms.ComboBox cboShowtime;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlLeftColumn;
        private System.Windows.Forms.Panel pnlCardScanner;
        private System.Windows.Forms.Label lblScannerTitle;
        private System.Windows.Forms.Panel pnlInputGroup;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlScanLaserTarget;
        private System.Windows.Forms.Panel pnlLaserBeam;
        private System.Windows.Forms.Label lblLaserHint;
        private System.Windows.Forms.Panel pnlMockButtons;
        private System.Windows.Forms.Label lblMockNote;
        private System.Windows.Forms.Button btnMockValid;
        private System.Windows.Forms.Button btnMockUsed;
        private System.Windows.Forms.Button btnMockWrongRoom;
        private System.Windows.Forms.Button btnMockNotFound;
        private System.Windows.Forms.Panel pnlCardResult;
        private System.Windows.Forms.Panel pnlStatusBanner;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatusDesc;
        private System.Windows.Forms.Panel pnlResultBody;
        private System.Windows.Forms.Label lblTitleMovie;
        private System.Windows.Forms.Label lblValMovie;
        private System.Windows.Forms.Label lblTitleShowtimeRoom;
        private System.Windows.Forms.Label lblValShowtimeRoom;
        private System.Windows.Forms.Panel pnlSeatBadge;
        private System.Windows.Forms.Label lblSeatCode;
        private System.Windows.Forms.Label lblSeatType;
        private System.Windows.Forms.Label lblTitleCustomer;
        private System.Windows.Forms.Label lblValCustomer;
        private System.Windows.Forms.Label lblTitlePrice;
        private System.Windows.Forms.Label lblValPrice;
        private System.Windows.Forms.Label lblTitleScanTime;
        private System.Windows.Forms.Label lblValScanTime;
        private System.Windows.Forms.Panel pnlRightColumn;
        private System.Windows.Forms.Panel pnlKpiRow;
        private System.Windows.Forms.Panel pnlKpiTotal;
        private System.Windows.Forms.Label lblKpiTotalTitle;
        private System.Windows.Forms.Label lblKpiTotalVal;
        private System.Windows.Forms.Panel pnlKpiScanned;
        private System.Windows.Forms.Label lblKpiScannedTitle;
        private System.Windows.Forms.Label lblKpiScannedVal;
        private System.Windows.Forms.Panel pnlKpiRemaining;
        private System.Windows.Forms.Label lblKpiRemainingTitle;
        private System.Windows.Forms.Label lblKpiRemainingVal;
        private System.Windows.Forms.Panel pnlKpiRate;
        private System.Windows.Forms.Label lblKpiRateTitle;
        private System.Windows.Forms.Label lblKpiRateVal;
        private System.Windows.Forms.Panel pnlCardHistory;
        private System.Windows.Forms.Panel pnlHistoryHeader;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.TextBox txtSearchLog;
        private System.Windows.Forms.Button btnExportLog;
        private System.Windows.Forms.DataGridView dgvCheckInLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.Timer timerClock;
    }
}

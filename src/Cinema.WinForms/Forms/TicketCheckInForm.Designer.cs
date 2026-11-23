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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            // Root Layout
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoBrand = new System.Windows.Forms.Label();
            this.lblLogoSub = new System.Windows.Forms.Label();
            this.picLogoIcon = new System.Windows.Forms.PictureBox();
            this.pnlNavPos = new System.Windows.Forms.Panel();
            this.lblNavPos = new System.Windows.Forms.Label();
            this.pnlNavCheckIn = new System.Windows.Forms.Panel();
            this.pnlActiveIndicator = new System.Windows.Forms.Panel();
            this.lblNavCheckIn = new System.Windows.Forms.Label();
            this.pnlNavMember = new System.Windows.Forms.Panel();
            this.lblNavMember = new System.Windows.Forms.Label();
            this.pnlNavInvoice = new System.Windows.Forms.Panel();
            this.lblNavInvoice = new System.Windows.Forms.Label();
            this.pnlNavShift = new System.Windows.Forms.Panel();
            this.lblNavShift = new System.Windows.Forms.Label();
            this.pnlStaffInfo = new System.Windows.Forms.Panel();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblStaffPos = new System.Windows.Forms.Label();
            this.picStaffAvatar = new System.Windows.Forms.PictureBox();

            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblUserHeader = new System.Windows.Forms.Label();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterText = new System.Windows.Forms.Label();

            this.pnlContentHolder = new System.Windows.Forms.Panel();

            // =================================================================
            // VIEW 1: CHỌN SUẤT CHIẾU ĐỂ MỞ CỔNG SOÁT VÉ (pnlViewSelectShowtime)
            // =================================================================
            this.pnlViewSelectShowtime = new System.Windows.Forms.Panel();
            this.flowShowtimes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSelectFilterBar = new System.Windows.Forms.Panel();
            this.btnFilterUpcoming = new System.Windows.Forms.Button();
            this.btnFilterActive = new System.Windows.Forms.Button();
            this.cboRoomFilter = new System.Windows.Forms.ComboBox();
            this.lblRoomFilter = new System.Windows.Forms.Label();
            this.lblSelectTitle = new System.Windows.Forms.Label();

            // =================================================================
            // VIEW 2: MÀN HÌNH SOÁT VÉ TRỰC TIẾP (pnlViewScanner)
            // =================================================================
            this.pnlViewScanner = new System.Windows.Forms.Panel();
            this.pnlScannerHeader = new System.Windows.Forms.Panel();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.lblActiveShowtimeTitle = new System.Windows.Forms.Label();
            this.btnChangeShowtime = new System.Windows.Forms.Button();
            this.pnlScannerBody = new System.Windows.Forms.Panel();
            this.pnlScannerLeft = new System.Windows.Forms.Panel();
            this.pnlQrScannerCard = new System.Windows.Forms.Panel();
            this.pnlManualInput = new System.Windows.Forms.Panel();
            this.btnCheckBarcode = new System.Windows.Forms.Button();
            this.txtInputBarcode = new System.Windows.Forms.TextBox();
            this.lblInputPrompt = new System.Windows.Forms.Label();
            this.pnlCameraBox = new System.Windows.Forms.Panel();
            this.lblCameraFoot = new System.Windows.Forms.Label();
            this.picPhoneMockup = new System.Windows.Forms.PictureBox();
            this.pnlLaserLine = new System.Windows.Forms.Panel();
            this.pnlCameraToolBar = new System.Windows.Forms.Panel();
            this.btnToggleCamera = new System.Windows.Forms.Button();
            this.cboCameras = new System.Windows.Forms.ComboBox();
            this.lblCameraSelect = new System.Windows.Forms.Label();
            this.pnlQrHeaderBar = new System.Windows.Forms.Panel();
            this.lblQrHeaderTitle = new System.Windows.Forms.Label();
            this.pnlScannerRight = new System.Windows.Forms.Panel();
            this.pnlResultCard = new System.Windows.Forms.Panel();
            this.btnConfirmPass = new System.Windows.Forms.Button();
            this.pnlAgeWarning = new System.Windows.Forms.Panel();
            this.lblAgeWarning = new System.Windows.Forms.Label();
            this.pnlInfoBoxes = new System.Windows.Forms.Panel();
            this.pnlBoxRoom = new System.Windows.Forms.Panel();
            this.lblBoxRoomSubtitle = new System.Windows.Forms.Label();
            this.lblBoxRoomTitle = new System.Windows.Forms.Label();
            this.pnlBoxSeats = new System.Windows.Forms.Panel();
            this.lblBoxSeatQty = new System.Windows.Forms.Label();
            this.lblBoxSeatCodes = new System.Windows.Forms.Label();
            this.lblBoxSeatTitle = new System.Windows.Forms.Label();
            this.pnlResultDivider = new System.Windows.Forms.Panel();
            this.lblResultSub = new System.Windows.Forms.Label();
            this.lblResultMain = new System.Windows.Forms.Label();
            this.picCheckmark = new System.Windows.Forms.PictureBox();
            this.lblCheckInCountBadge = new System.Windows.Forms.Label();
            this.pnlMockShortcuts = new System.Windows.Forms.Panel();
            this.btnMock4NotFound = new System.Windows.Forms.Button();
            this.btnMock3Wrong = new System.Windows.Forms.Button();
            this.btnMock2Used = new System.Windows.Forms.Button();
            this.btnMock1Valid = new System.Windows.Forms.Button();

            // =================================================================
            // VIEW 3: NHẬT KÝ SOÁT VÉ (pnlViewLogs)
            // =================================================================
            this.pnlViewLogs = new System.Windows.Forms.Panel();
            this.pnlLogsTableCard = new System.Windows.Forms.Panel();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.colLogTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogSeatType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogStaff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPage13 = new System.Windows.Forms.Button();
            this.lblDots = new System.Windows.Forms.Label();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblShowingCount = new System.Windows.Forms.Label();
            this.pnlLogsFilterBar = new System.Windows.Forms.Panel();
            this.btnFilterTabRejected = new System.Windows.Forms.Button();
            this.btnFilterTabSuccess = new System.Windows.Forms.Button();
            this.btnFilterTabAll = new System.Windows.Forms.Button();
            this.txtSearchLogs = new System.Windows.Forms.TextBox();
            this.pnlKpiSection = new System.Windows.Forms.Panel();
            this.pnlKpiRejected = new System.Windows.Forms.Panel();
            this.lblKpiRejectedVal = new System.Windows.Forms.Label();
            this.lblKpiRejectedTitle = new System.Windows.Forms.Label();
            this.picKpiRejected = new System.Windows.Forms.PictureBox();
            this.pnlKpiRemaining = new System.Windows.Forms.Panel();
            this.lblKpiRemainingVal = new System.Windows.Forms.Label();
            this.lblKpiRemainingTitle = new System.Windows.Forms.Label();
            this.picKpiRemaining = new System.Windows.Forms.PictureBox();
            this.pnlKpiScanned = new System.Windows.Forms.Panel();
            this.lblKpiScannedVal = new System.Windows.Forms.Label();
            this.lblKpiScannedTitle = new System.Windows.Forms.Label();
            this.picKpiScanned = new System.Windows.Forms.PictureBox();
            this.pnlKpiTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalVal = new System.Windows.Forms.Label();
            this.lblKpiTotalTitle = new System.Windows.Forms.Label();
            this.picKpiTotal = new System.Windows.Forms.PictureBox();
            this.pnlLogsTopHeader = new System.Windows.Forms.Panel();
            this.btnBackToScanner = new System.Windows.Forms.Button();
            this.lblLogsScreenTitle = new System.Windows.Forms.Label();

            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoIcon)).BeginInit();
            this.pnlNavPos.SuspendLayout();
            this.pnlNavCheckIn.SuspendLayout();
            this.pnlNavMember.SuspendLayout();
            this.pnlNavInvoice.SuspendLayout();
            this.pnlNavShift.SuspendLayout();
            this.pnlStaffInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaffAvatar)).BeginInit();
            this.pnlTopHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContentHolder.SuspendLayout();

            this.pnlViewSelectShowtime.SuspendLayout();
            this.pnlSelectFilterBar.SuspendLayout();

            this.pnlViewScanner.SuspendLayout();
            this.pnlScannerHeader.SuspendLayout();
            this.pnlScannerBody.SuspendLayout();
            this.pnlScannerLeft.SuspendLayout();
            this.pnlQrScannerCard.SuspendLayout();
            this.pnlManualInput.SuspendLayout();
            this.pnlCameraBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneMockup)).BeginInit();
            this.pnlCameraToolBar.SuspendLayout();
            this.pnlQrHeaderBar.SuspendLayout();
            this.pnlScannerRight.SuspendLayout();
            this.pnlResultCard.SuspendLayout();
            this.pnlAgeWarning.SuspendLayout();
            this.pnlInfoBoxes.SuspendLayout();
            this.pnlBoxRoom.SuspendLayout();
            this.pnlBoxSeats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckmark)).BeginInit();
            this.pnlMockShortcuts.SuspendLayout();

            this.pnlViewLogs.SuspendLayout();
            this.pnlLogsTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.pnlLogsFilterBar.SuspendLayout();
            this.pnlKpiSection.SuspendLayout();
            this.pnlKpiRejected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiRejected)).BeginInit();
            this.pnlKpiRemaining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiRemaining)).BeginInit();
            this.pnlKpiScanned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiScanned)).BeginInit();
            this.pnlKpiTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiTotal)).BeginInit();
            this.pnlLogsTopHeader.SuspendLayout();

            this.SuspendLayout();

            // =========================================================================
            // pnlSidebar (#1E293B)
            // =========================================================================
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.pnlStaffInfo);
            this.pnlSidebar.Controls.Add(this.pnlNavShift);
            this.pnlSidebar.Controls.Add(this.pnlNavInvoice);
            this.pnlSidebar.Controls.Add(this.pnlNavMember);
            this.pnlSidebar.Controls.Add(this.pnlNavCheckIn);
            this.pnlSidebar.Controls.Add(this.pnlNavPos);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(180, 720);
            this.pnlSidebar.TabIndex = 0;

            // Logo
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlLogo.Controls.Add(this.lblLogoSub);
            this.pnlLogo.Controls.Add(this.lblLogoBrand);
            this.pnlLogo.Controls.Add(this.picLogoIcon);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 60);
            this.pnlLogo.TabIndex = 0;

            this.picLogoIcon.Location = new System.Drawing.Point(8, 8);
            this.picLogoIcon.Name = "picLogoIcon";
            this.picLogoIcon.Size = new System.Drawing.Size(46, 44);
            this.picLogoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoIcon.TabIndex = 0;
            this.picLogoIcon.TabStop = false;
            this.picLogoIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogoIcon_Paint);

            this.lblLogoBrand.AutoSize = true;
            this.lblLogoBrand.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogoBrand.ForeColor = System.Drawing.Color.White;
            this.lblLogoBrand.Location = new System.Drawing.Point(58, 12);
            this.lblLogoBrand.Name = "lblLogoBrand";
            this.lblLogoBrand.Size = new System.Drawing.Size(89, 19);
            this.lblLogoBrand.TabIndex = 1;
            this.lblLogoBrand.Text = "STORYLINE";

            this.lblLogoSub.AutoSize = true;
            this.lblLogoSub.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogoSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblLogoSub.Location = new System.Drawing.Point(60, 33);
            this.lblLogoSub.Name = "lblLogoSub";
            this.lblLogoSub.Size = new System.Drawing.Size(53, 12);
            this.lblLogoSub.TabIndex = 2;
            this.lblLogoSub.Text = "C I N E M A";

            // Nav 1: Bán vé
            this.pnlNavPos.Controls.Add(this.lblNavPos);
            this.pnlNavPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavPos.Location = new System.Drawing.Point(0, 60);
            this.pnlNavPos.Name = "pnlNavPos";
            this.pnlNavPos.Size = new System.Drawing.Size(180, 44);
            this.pnlNavPos.TabIndex = 1;

            this.lblNavPos.AutoSize = true;
            this.lblNavPos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavPos.Location = new System.Drawing.Point(18, 13);
            this.lblNavPos.Name = "lblNavPos";
            this.lblNavPos.Size = new System.Drawing.Size(81, 17);
            this.lblNavPos.TabIndex = 0;
            this.lblNavPos.Text = "🎟️   Bán vé";

            // Nav 2: Soát vé (Active: #334155, vạch trái #3B82F6)
            this.pnlNavCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pnlNavCheckIn.Controls.Add(this.pnlActiveIndicator);
            this.pnlNavCheckIn.Controls.Add(this.lblNavCheckIn);
            this.pnlNavCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavCheckIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavCheckIn.Location = new System.Drawing.Point(0, 104);
            this.pnlNavCheckIn.Name = "pnlNavCheckIn";
            this.pnlNavCheckIn.Size = new System.Drawing.Size(180, 44);
            this.pnlNavCheckIn.TabIndex = 2;

            this.pnlActiveIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlActiveIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlActiveIndicator.Location = new System.Drawing.Point(0, 0);
            this.pnlActiveIndicator.Name = "pnlActiveIndicator";
            this.pnlActiveIndicator.Size = new System.Drawing.Size(4, 44);
            this.pnlActiveIndicator.TabIndex = 1;

            this.lblNavCheckIn.AutoSize = true;
            this.lblNavCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavCheckIn.ForeColor = System.Drawing.Color.White;
            this.lblNavCheckIn.Location = new System.Drawing.Point(18, 13);
            this.lblNavCheckIn.Name = "lblNavCheckIn";
            this.lblNavCheckIn.Size = new System.Drawing.Size(89, 17);
            this.lblNavCheckIn.TabIndex = 0;
            this.lblNavCheckIn.Text = "║▌║  Soát vé";

            // Nav 3: Thành viên
            this.pnlNavMember.Controls.Add(this.lblNavMember);
            this.pnlNavMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavMember.Location = new System.Drawing.Point(0, 148);
            this.pnlNavMember.Name = "pnlNavMember";
            this.pnlNavMember.Size = new System.Drawing.Size(180, 44);
            this.pnlNavMember.TabIndex = 3;

            this.lblNavMember.AutoSize = true;
            this.lblNavMember.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavMember.Location = new System.Drawing.Point(18, 13);
            this.lblNavMember.Name = "lblNavMember";
            this.lblNavMember.Size = new System.Drawing.Size(107, 17);
            this.lblNavMember.TabIndex = 0;
            this.lblNavMember.Text = "👥   Thành viên";

            // Nav 4: Hóa đơn & Hủy vé
            this.pnlNavInvoice.Controls.Add(this.lblNavInvoice);
            this.pnlNavInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavInvoice.Location = new System.Drawing.Point(0, 192);
            this.pnlNavInvoice.Name = "pnlNavInvoice";
            this.pnlNavInvoice.Size = new System.Drawing.Size(180, 44);
            this.pnlNavInvoice.TabIndex = 4;

            this.lblNavInvoice.AutoSize = true;
            this.lblNavInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavInvoice.Location = new System.Drawing.Point(18, 13);
            this.lblNavInvoice.Name = "lblNavInvoice";
            this.lblNavInvoice.Size = new System.Drawing.Size(139, 17);
            this.lblNavInvoice.TabIndex = 0;
            this.lblNavInvoice.Text = "🧾   Hóa đơn && Hủy";

            // Nav 5: Quản lý ca
            this.pnlNavShift.Controls.Add(this.lblNavShift);
            this.pnlNavShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavShift.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavShift.Location = new System.Drawing.Point(0, 236);
            this.pnlNavShift.Name = "pnlNavShift";
            this.pnlNavShift.Size = new System.Drawing.Size(180, 44);
            this.pnlNavShift.TabIndex = 5;

            this.lblNavShift.AutoSize = true;
            this.lblNavShift.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNavShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNavShift.Location = new System.Drawing.Point(18, 13);
            this.lblNavShift.Name = "lblNavShift";
            this.lblNavShift.Size = new System.Drawing.Size(107, 17);
            this.lblNavShift.TabIndex = 0;
            this.lblNavShift.Text = "📅   Quản lý ca";

            // pnlStaffInfo (Chân sidebar)
            this.pnlStaffInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlStaffInfo.Controls.Add(this.lblStaffPos);
            this.pnlStaffInfo.Controls.Add(this.lblStaffName);
            this.pnlStaffInfo.Controls.Add(this.picStaffAvatar);
            this.pnlStaffInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStaffInfo.Location = new System.Drawing.Point(0, 660);
            this.pnlStaffInfo.Name = "pnlStaffInfo";
            this.pnlStaffInfo.Size = new System.Drawing.Size(180, 60);
            this.pnlStaffInfo.TabIndex = 6;

            this.picStaffAvatar.Location = new System.Drawing.Point(12, 12);
            this.picStaffAvatar.Name = "picStaffAvatar";
            this.picStaffAvatar.Size = new System.Drawing.Size(36, 36);
            this.picStaffAvatar.TabIndex = 0;
            this.picStaffAvatar.TabStop = false;
            this.picStaffAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.picStaffAvatar_Paint);

            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStaffName.ForeColor = System.Drawing.Color.White;
            this.lblStaffName.Location = new System.Drawing.Point(52, 13);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(106, 15);
            this.lblStaffName.TabIndex = 1;
            this.lblStaffName.Text = "Nguyễn Minh Anh";

            this.lblStaffPos.AutoSize = true;
            this.lblStaffPos.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStaffPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblStaffPos.Location = new System.Drawing.Point(52, 31);
            this.lblStaffPos.Name = "lblStaffPos";
            this.lblStaffPos.Size = new System.Drawing.Size(55, 13);
            this.lblStaffPos.TabIndex = 2;
            this.lblStaffPos.Text = "• POS-01";

            // =========================================================================
            // pnlTopHeader (#FFFFFF, viền #E2E8F0)
            // =========================================================================
            this.pnlTopHeader.BackColor = System.Drawing.Color.White;
            this.pnlTopHeader.Controls.Add(this.btnLogout);
            this.pnlTopHeader.Controls.Add(this.lblClock);
            this.pnlTopHeader.Controls.Add(this.lblUserHeader);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(180, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1020, 50);
            this.pnlTopHeader.TabIndex = 1;
            this.pnlTopHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBorderBottom_Paint);

            this.lblUserHeader.AutoSize = true;
            this.lblUserHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUserHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblUserHeader.Location = new System.Drawing.Point(18, 16);
            this.lblUserHeader.Name = "lblUserHeader";
            this.lblUserHeader.Size = new System.Drawing.Size(186, 17);
            this.lblUserHeader.TabIndex = 0;
            this.lblUserHeader.Text = "Nguyễn Minh Anh  •  POS-01";

            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblClock.Location = new System.Drawing.Point(820, 16);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(95, 17);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "🕒  19:16:00";

            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLogout.Location = new System.Drawing.Point(925, 11);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 28);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "[→ Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;

            // =========================================================================
            // pnlFooter (#FFFFFF, viền #E2E8F0)
            // =========================================================================
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblFooterText);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(180, 692);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1020, 28);
            this.pnlFooter.TabIndex = 2;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBorderTop_Paint);

            this.lblFooterText.AutoSize = true;
            this.lblFooterText.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFooterText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFooterText.Location = new System.Drawing.Point(18, 7);
            this.lblFooterText.Name = "lblFooterText";
            this.lblFooterText.Size = new System.Drawing.Size(220, 13);
            this.lblFooterText.TabIndex = 0;
            this.lblFooterText.Text = "Ca chiếu • 14:00–22:00 | Dữ liệu minh họa";

            // =========================================================================
            // pnlContentHolder (Nền chính: #F1F5F9)
            // =========================================================================
            this.pnlContentHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlContentHolder.Controls.Add(this.pnlViewSelectShowtime);
            this.pnlContentHolder.Controls.Add(this.pnlViewLogs);
            this.pnlContentHolder.Controls.Add(this.pnlViewScanner);
            this.pnlContentHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentHolder.Location = new System.Drawing.Point(180, 50);
            this.pnlContentHolder.Name = "pnlContentHolder";
            this.pnlContentHolder.Size = new System.Drawing.Size(1020, 642);
            this.pnlContentHolder.TabIndex = 3;

            // =========================================================================
            // 1. VIEW CHỌN SUẤT CHIẾU (pnlViewSelectShowtime)
            // =========================================================================
            this.pnlViewSelectShowtime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlViewSelectShowtime.Controls.Add(this.flowShowtimes);
            this.pnlViewSelectShowtime.Controls.Add(this.pnlSelectFilterBar);
            this.pnlViewSelectShowtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewSelectShowtime.Location = new System.Drawing.Point(0, 0);
            this.pnlViewSelectShowtime.Name = "pnlViewSelectShowtime";
            this.pnlViewSelectShowtime.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlViewSelectShowtime.Size = new System.Drawing.Size(1020, 642);
            this.pnlViewSelectShowtime.TabIndex = 0;

            this.pnlSelectFilterBar.Controls.Add(this.btnFilterUpcoming);
            this.pnlSelectFilterBar.Controls.Add(this.btnFilterActive);
            this.pnlSelectFilterBar.Controls.Add(this.cboRoomFilter);
            this.pnlSelectFilterBar.Controls.Add(this.lblRoomFilter);
            this.pnlSelectFilterBar.Controls.Add(this.lblSelectTitle);
            this.pnlSelectFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectFilterBar.Location = new System.Drawing.Point(18, 14);
            this.pnlSelectFilterBar.Name = "pnlSelectFilterBar";
            this.pnlSelectFilterBar.Size = new System.Drawing.Size(984, 85);
            this.pnlSelectFilterBar.TabIndex = 0;

            this.lblSelectTitle.AutoSize = true;
            this.lblSelectTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSelectTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSelectTitle.Location = new System.Drawing.Point(0, 5);
            this.lblSelectTitle.Name = "lblSelectTitle";
            this.lblSelectTitle.Size = new System.Drawing.Size(434, 25);
            this.lblSelectTitle.TabIndex = 0;
            this.lblSelectTitle.Text = "CHỌN SUẤT CHIẾU ĐỂ MỞ CỔNG SOÁT VÉ";

            this.lblRoomFilter.AutoSize = true;
            this.lblRoomFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRoomFilter.Location = new System.Drawing.Point(0, 48);
            this.lblRoomFilter.Name = "lblRoomFilter";
            this.lblRoomFilter.Size = new System.Drawing.Size(76, 15);
            this.lblRoomFilter.TabIndex = 1;
            this.lblRoomFilter.Text = "Phòng chiếu:";

            this.cboRoomFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRoomFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cboRoomFilter.FormattingEnabled = true;
            this.cboRoomFilter.Location = new System.Drawing.Point(82, 45);
            this.cboRoomFilter.Name = "cboRoomFilter";
            this.cboRoomFilter.Size = new System.Drawing.Size(160, 23);
            this.cboRoomFilter.TabIndex = 2;
            this.cboRoomFilter.SelectedIndexChanged += new System.EventHandler(this.cboRoomFilter_SelectedIndexChanged);

            this.btnFilterActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnFilterActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterActive.FlatAppearance.BorderSize = 0;
            this.btnFilterActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilterActive.ForeColor = System.Drawing.Color.White;
            this.btnFilterActive.Location = new System.Drawing.Point(260, 42);
            this.btnFilterActive.Name = "btnFilterActive";
            this.btnFilterActive.Size = new System.Drawing.Size(180, 29);
            this.btnFilterActive.TabIndex = 3;
            this.btnFilterActive.Text = "Đang mở cửa đón khách";
            this.btnFilterActive.UseVisualStyleBackColor = false;
            this.btnFilterActive.Click += new System.EventHandler(this.btnFilterActive_Click);

            this.btnFilterUpcoming.BackColor = System.Drawing.Color.White;
            this.btnFilterUpcoming.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterUpcoming.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnFilterUpcoming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterUpcoming.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilterUpcoming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnFilterUpcoming.Location = new System.Drawing.Point(448, 42);
            this.btnFilterUpcoming.Name = "btnFilterUpcoming";
            this.btnFilterUpcoming.Size = new System.Drawing.Size(100, 29);
            this.btnFilterUpcoming.TabIndex = 4;
            this.btnFilterUpcoming.Text = "Sắp chiếu";
            this.btnFilterUpcoming.UseVisualStyleBackColor = false;
            this.btnFilterUpcoming.Click += new System.EventHandler(this.btnFilterUpcoming_Click);

            this.flowShowtimes.AutoScroll = true;
            this.flowShowtimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowShowtimes.Location = new System.Drawing.Point(18, 99);
            this.flowShowtimes.Name = "flowShowtimes";
            this.flowShowtimes.Size = new System.Drawing.Size(984, 529);
            this.flowShowtimes.TabIndex = 1;

            // =========================================================================
            // 2. VIEW QUÉT MÃ QR & KẾT QUẢ SOÁT VÉ (pnlViewScanner)
            // =========================================================================
            this.pnlViewScanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlViewScanner.Controls.Add(this.pnlScannerBody);
            this.pnlViewScanner.Controls.Add(this.pnlScannerHeader);
            this.pnlViewScanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewScanner.Location = new System.Drawing.Point(0, 0);
            this.pnlViewScanner.Name = "pnlViewScanner";
            this.pnlViewScanner.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlViewScanner.Size = new System.Drawing.Size(1020, 642);
            this.pnlViewScanner.TabIndex = 1;

            // Header Bar
            this.pnlScannerHeader.Controls.Add(this.btnViewLogs);
            this.pnlScannerHeader.Controls.Add(this.lblActiveShowtimeTitle);
            this.pnlScannerHeader.Controls.Add(this.btnChangeShowtime);
            this.pnlScannerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScannerHeader.Location = new System.Drawing.Point(18, 12);
            this.pnlScannerHeader.Name = "pnlScannerHeader";
            this.pnlScannerHeader.Size = new System.Drawing.Size(984, 46);
            this.pnlScannerHeader.TabIndex = 0;

            this.btnChangeShowtime.BackColor = System.Drawing.Color.White;
            this.btnChangeShowtime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeShowtime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnChangeShowtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeShowtime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangeShowtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnChangeShowtime.Location = new System.Drawing.Point(0, 8);
            this.btnChangeShowtime.Name = "btnChangeShowtime";
            this.btnChangeShowtime.Size = new System.Drawing.Size(130, 30);
            this.btnChangeShowtime.TabIndex = 0;
            this.btnChangeShowtime.Text = "< Đổi suất chiếu";
            this.btnChangeShowtime.UseVisualStyleBackColor = false;
            this.btnChangeShowtime.Click += new System.EventHandler(this.btnChangeShowtime_Click);

            this.lblActiveShowtimeTitle.AutoSize = true;
            this.lblActiveShowtimeTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActiveShowtimeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblActiveShowtimeTitle.Location = new System.Drawing.Point(145, 11);
            this.lblActiveShowtimeTitle.Name = "lblActiveShowtimeTitle";
            this.lblActiveShowtimeTitle.Size = new System.Drawing.Size(420, 23);
            this.lblActiveShowtimeTitle.TabIndex = 1;
            this.lblActiveShowtimeTitle.Text = "ĐANG SOÁT VÉ: PHÒNG 03 | Lật Mặt 7 (19:30)";

            this.btnViewLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLogs.BackColor = System.Drawing.Color.White;
            this.btnViewLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewLogs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnViewLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLogs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnViewLogs.Location = new System.Drawing.Point(824, 8);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(160, 30);
            this.btnViewLogs.TabIndex = 2;
            this.btnViewLogs.Text = "Xem lịch sử quét (F4)";
            this.btnViewLogs.UseVisualStyleBackColor = false;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);

            // Scanner Body (2 Cột)
            this.pnlScannerBody.Controls.Add(this.pnlScannerRight);
            this.pnlScannerBody.Controls.Add(this.pnlScannerLeft);
            this.pnlScannerBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScannerBody.Location = new System.Drawing.Point(18, 58);
            this.pnlScannerBody.Name = "pnlScannerBody";
            this.pnlScannerBody.Size = new System.Drawing.Size(984, 572);
            this.pnlScannerBody.TabIndex = 1;

            // Cột Trái (Camera + Máy quét)
            this.pnlScannerLeft.Controls.Add(this.pnlMockShortcuts);
            this.pnlScannerLeft.Controls.Add(this.pnlQrScannerCard);
            this.pnlScannerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlScannerLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlScannerLeft.Name = "pnlScannerLeft";
            this.pnlScannerLeft.Size = new System.Drawing.Size(460, 572);
            this.pnlScannerLeft.TabIndex = 0;

            this.pnlQrScannerCard.BackColor = System.Drawing.Color.White;
            this.pnlQrScannerCard.Controls.Add(this.pnlManualInput);
            this.pnlQrScannerCard.Controls.Add(this.pnlCameraBox);
            this.pnlQrScannerCard.Controls.Add(this.pnlCameraToolBar);
            this.pnlQrScannerCard.Controls.Add(this.pnlQrHeaderBar);
            this.pnlQrScannerCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQrScannerCard.Location = new System.Drawing.Point(0, 0);
            this.pnlQrScannerCard.Name = "pnlQrScannerCard";
            this.pnlQrScannerCard.Size = new System.Drawing.Size(460, 515);
            this.pnlQrScannerCard.TabIndex = 0;
            this.pnlQrScannerCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            // Banner xanh
            this.pnlQrHeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlQrHeaderBar.Controls.Add(this.lblQrHeaderTitle);
            this.pnlQrHeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQrHeaderBar.Location = new System.Drawing.Point(0, 0);
            this.pnlQrHeaderBar.Name = "pnlQrHeaderBar";
            this.pnlQrHeaderBar.Size = new System.Drawing.Size(460, 42);
            this.pnlQrHeaderBar.TabIndex = 0;

            this.lblQrHeaderTitle.AutoSize = true;
            this.lblQrHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQrHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblQrHeaderTitle.Location = new System.Drawing.Point(120, 11);
            this.lblQrHeaderTitle.Name = "lblQrHeaderTitle";
            this.lblQrHeaderTitle.Size = new System.Drawing.Size(223, 20);
            this.lblQrHeaderTitle.TabIndex = 0;
            this.lblQrHeaderTitle.Text = "QUÉT MÃ QR TRÊN VÉ KHÁCH";

            // Camera Toolbar
            this.pnlCameraToolBar.Controls.Add(this.btnToggleCamera);
            this.pnlCameraToolBar.Controls.Add(this.cboCameras);
            this.pnlCameraToolBar.Controls.Add(this.lblCameraSelect);
            this.pnlCameraToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCameraToolBar.Location = new System.Drawing.Point(0, 42);
            this.pnlCameraToolBar.Name = "pnlCameraToolBar";
            this.pnlCameraToolBar.Size = new System.Drawing.Size(460, 42);
            this.pnlCameraToolBar.TabIndex = 1;

            this.lblCameraSelect.AutoSize = true;
            this.lblCameraSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCameraSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCameraSelect.Location = new System.Drawing.Point(15, 13);
            this.lblCameraSelect.Name = "lblCameraSelect";
            this.lblCameraSelect.Size = new System.Drawing.Size(51, 15);
            this.lblCameraSelect.TabIndex = 0;
            this.lblCameraSelect.Text = "Camera:";

            this.cboCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCameras.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboCameras.FormattingEnabled = true;
            this.cboCameras.Location = new System.Drawing.Point(72, 10);
            this.cboCameras.Name = "cboCameras";
            this.cboCameras.Size = new System.Drawing.Size(180, 21);
            this.cboCameras.TabIndex = 1;

            this.btnToggleCamera.BackColor = System.Drawing.Color.White;
            this.btnToggleCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleCamera.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnToggleCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleCamera.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleCamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnToggleCamera.Location = new System.Drawing.Point(265, 8);
            this.btnToggleCamera.Name = "btnToggleCamera";
            this.btnToggleCamera.Size = new System.Drawing.Size(180, 26);
            this.btnToggleCamera.TabIndex = 2;
            this.btnToggleCamera.Text = "📷 Bật / Tắt camera";
            this.btnToggleCamera.UseVisualStyleBackColor = false;

            // Camera Box
            this.pnlCameraBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlCameraBox.Controls.Add(this.lblCameraFoot);
            this.pnlCameraBox.Controls.Add(this.picPhoneMockup);
            this.pnlCameraBox.Controls.Add(this.pnlLaserLine);
            this.pnlCameraBox.Location = new System.Drawing.Point(15, 90);
            this.pnlCameraBox.Name = "pnlCameraBox";
            this.pnlCameraBox.Size = new System.Drawing.Size(430, 320);
            this.pnlCameraBox.TabIndex = 2;
            this.pnlCameraBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCameraBox_Paint);

            this.pnlLaserLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.pnlLaserLine.Location = new System.Drawing.Point(30, 160);
            this.pnlLaserLine.Name = "pnlLaserLine";
            this.pnlLaserLine.Size = new System.Drawing.Size(370, 3);
            this.pnlLaserLine.TabIndex = 0;

            this.picPhoneMockup.BackColor = System.Drawing.Color.Transparent;
            this.picPhoneMockup.Location = new System.Drawing.Point(125, 25);
            this.picPhoneMockup.Name = "picPhoneMockup";
            this.picPhoneMockup.Size = new System.Drawing.Size(180, 260);
            this.picPhoneMockup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPhoneMockup.TabIndex = 1;
            this.picPhoneMockup.TabStop = false;
            this.picPhoneMockup.Paint += new System.Windows.Forms.PaintEventHandler(this.picPhoneMockup_Paint);

            this.lblCameraFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCameraFoot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCameraFoot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblCameraFoot.Location = new System.Drawing.Point(0, 290);
            this.lblCameraFoot.Name = "lblCameraFoot";
            this.lblCameraFoot.Size = new System.Drawing.Size(430, 30);
            this.lblCameraFoot.TabIndex = 2;
            this.lblCameraFoot.Text = "Đưa mã QR trên vé giấy hoặc điện thoại vào khung";
            this.lblCameraFoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Ô nhập mã vé
            this.pnlManualInput.Controls.Add(this.btnCheckBarcode);
            this.pnlManualInput.Controls.Add(this.txtInputBarcode);
            this.pnlManualInput.Controls.Add(this.lblInputPrompt);
            this.pnlManualInput.Location = new System.Drawing.Point(15, 420);
            this.pnlManualInput.Name = "pnlManualInput";
            this.pnlManualInput.Size = new System.Drawing.Size(430, 80);
            this.pnlManualInput.TabIndex = 3;

            this.lblInputPrompt.AutoSize = true;
            this.lblInputPrompt.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInputPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInputPrompt.Location = new System.Drawing.Point(0, 4);
            this.lblInputPrompt.Name = "lblInputPrompt";
            this.lblInputPrompt.Size = new System.Drawing.Size(161, 13);
            this.lblInputPrompt.TabIndex = 0;
            this.lblInputPrompt.Text = "Máy quét cầm tay / Nhập mã vé:";

            this.txtInputBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtInputBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputBarcode.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtInputBarcode.Location = new System.Drawing.Point(0, 26);
            this.txtInputBarcode.Name = "txtInputBarcode";
            this.txtInputBarcode.PlaceholderText = "Quét hoặc nhập mã vé...";
            this.txtInputBarcode.Size = new System.Drawing.Size(280, 26);
            this.txtInputBarcode.TabIndex = 1;
            this.txtInputBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputBarcode_KeyDown);

            this.btnCheckBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCheckBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckBarcode.FlatAppearance.BorderSize = 0;
            this.btnCheckBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckBarcode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckBarcode.ForeColor = System.Drawing.Color.White;
            this.btnCheckBarcode.Location = new System.Drawing.Point(290, 24);
            this.btnCheckBarcode.Name = "btnCheckBarcode";
            this.btnCheckBarcode.Size = new System.Drawing.Size(140, 30);
            this.btnCheckBarcode.TabIndex = 2;
            this.btnCheckBarcode.Text = "KIỂM TRA (Enter)";
            this.btnCheckBarcode.UseVisualStyleBackColor = false;
            this.btnCheckBarcode.Click += new System.EventHandler(this.btnCheckBarcode_Click);

            // Nút test nhanh frontend
            this.pnlMockShortcuts.Controls.Add(this.btnMock4NotFound);
            this.pnlMockShortcuts.Controls.Add(this.btnMock3Wrong);
            this.pnlMockShortcuts.Controls.Add(this.btnMock2Used);
            this.pnlMockShortcuts.Controls.Add(this.btnMock1Valid);
            this.pnlMockShortcuts.Location = new System.Drawing.Point(0, 520);
            this.pnlMockShortcuts.Name = "pnlMockShortcuts";
            this.pnlMockShortcuts.Size = new System.Drawing.Size(460, 45);
            this.pnlMockShortcuts.TabIndex = 1;

            this.btnMock1Valid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.btnMock1Valid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMock1Valid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(243)))), ((int)(((byte)(208)))));
            this.btnMock1Valid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMock1Valid.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMock1Valid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnMock1Valid.Location = new System.Drawing.Point(0, 8);
            this.btnMock1Valid.Name = "btnMock1Valid";
            this.btnMock1Valid.Size = new System.Drawing.Size(108, 28);
            this.btnMock1Valid.TabIndex = 0;
            this.btnMock1Valid.Text = "✓ Vé Hợp Lệ";
            this.btnMock1Valid.UseVisualStyleBackColor = false;
            this.btnMock1Valid.Click += new System.EventHandler(this.btnMock1Valid_Click);

            this.btnMock2Used.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnMock2Used.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMock2Used.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.btnMock2Used.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMock2Used.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMock2Used.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnMock2Used.Location = new System.Drawing.Point(115, 8);
            this.btnMock2Used.Name = "btnMock2Used";
            this.btnMock2Used.Size = new System.Drawing.Size(108, 28);
            this.btnMock2Used.TabIndex = 1;
            this.btnMock2Used.Text = "⚠️ Đã Sử Dụng";
            this.btnMock2Used.UseVisualStyleBackColor = false;
            this.btnMock2Used.Click += new System.EventHandler(this.btnMock2Used_Click);

            this.btnMock3Wrong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.btnMock3Wrong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMock3Wrong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(170)))));
            this.btnMock3Wrong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMock3Wrong.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMock3Wrong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnMock3Wrong.Location = new System.Drawing.Point(230, 8);
            this.btnMock3Wrong.Name = "btnMock3Wrong";
            this.btnMock3Wrong.Size = new System.Drawing.Size(108, 28);
            this.btnMock3Wrong.TabIndex = 2;
            this.btnMock3Wrong.Text = "🚫 Sai Phòng";
            this.btnMock3Wrong.UseVisualStyleBackColor = false;
            this.btnMock3Wrong.Click += new System.EventHandler(this.btnMock3Wrong_Click);

            this.btnMock4NotFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnMock4NotFound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMock4NotFound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnMock4NotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMock4NotFound.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMock4NotFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnMock4NotFound.Location = new System.Drawing.Point(345, 8);
            this.btnMock4NotFound.Name = "btnMock4NotFound";
            this.btnMock4NotFound.Size = new System.Drawing.Size(115, 28);
            this.btnMock4NotFound.TabIndex = 3;
            this.btnMock4NotFound.Text = "❌ Không Tồn Tại";
            this.btnMock4NotFound.UseVisualStyleBackColor = false;
            this.btnMock4NotFound.Click += new System.EventHandler(this.btnMock4NotFound_Click);

            // Cột Phải (Thẻ Kết Quả Soát Vé)
            this.pnlScannerRight.Controls.Add(this.pnlResultCard);
            this.pnlScannerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScannerRight.Location = new System.Drawing.Point(460, 0);
            this.pnlScannerRight.Name = "pnlScannerRight";
            this.pnlScannerRight.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.pnlScannerRight.Size = new System.Drawing.Size(524, 572);
            this.pnlScannerRight.TabIndex = 1;

            this.pnlResultCard.BackColor = System.Drawing.Color.White;
            this.pnlResultCard.Controls.Add(this.btnConfirmPass);
            this.pnlResultCard.Controls.Add(this.pnlAgeWarning);
            this.pnlResultCard.Controls.Add(this.pnlInfoBoxes);
            this.pnlResultCard.Controls.Add(this.pnlResultDivider);
            this.pnlResultCard.Controls.Add(this.lblResultSub);
            this.pnlResultCard.Controls.Add(this.lblResultMain);
            this.pnlResultCard.Controls.Add(this.picCheckmark);
            this.pnlResultCard.Controls.Add(this.lblCheckInCountBadge);
            this.pnlResultCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultCard.Location = new System.Drawing.Point(18, 0);
            this.pnlResultCard.Name = "pnlResultCard";
            this.pnlResultCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlResultCard.Size = new System.Drawing.Size(506, 572);
            this.pnlResultCard.TabIndex = 0;
            this.pnlResultCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            // Badge đếm góc trên phải
            this.lblCheckInCountBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckInCountBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblCheckInCountBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCheckInCountBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCheckInCountBadge.Location = new System.Drawing.Point(340, 16);
            this.lblCheckInCountBadge.Name = "lblCheckInCountBadge";
            this.lblCheckInCountBadge.Size = new System.Drawing.Size(150, 28);
            this.lblCheckInCountBadge.TabIndex = 0;
            this.lblCheckInCountBadge.Text = "Đã vào: 43/110 khách";
            this.lblCheckInCountBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Icon Checkmark to
            this.picCheckmark.Location = new System.Drawing.Point(215, 30);
            this.picCheckmark.Name = "picCheckmark";
            this.picCheckmark.Size = new System.Drawing.Size(76, 76);
            this.picCheckmark.TabIndex = 1;
            this.picCheckmark.TabStop = false;
            this.picCheckmark.Paint += new System.Windows.Forms.PaintEventHandler(this.picCheckmark_Paint);

            // Vé HỢP LỆ
            this.lblResultMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultMain.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResultMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblResultMain.Location = new System.Drawing.Point(20, 20);
            this.lblResultMain.Margin = new System.Windows.Forms.Padding(0, 95, 0, 0);
            this.lblResultMain.Name = "lblResultMain";
            this.lblResultMain.Padding = new System.Windows.Forms.Padding(0, 95, 0, 0);
            this.lblResultMain.Size = new System.Drawing.Size(466, 140);
            this.lblResultMain.TabIndex = 2;
            this.lblResultMain.Text = "Vé HỢP LỆ";
            this.lblResultMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // MỜI KHÁCH VÀO RẠP
            this.lblResultSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultSub.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResultSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.lblResultSub.Location = new System.Drawing.Point(20, 160);
            this.lblResultSub.Name = "lblResultSub";
            this.lblResultSub.Size = new System.Drawing.Size(466, 35);
            this.lblResultSub.TabIndex = 3;
            this.lblResultSub.Text = "MỜI KHÁCH VÀO RẠP";
            this.lblResultSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Đường kẻ ngang
            this.pnlResultDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlResultDivider.Location = new System.Drawing.Point(30, 205);
            this.pnlResultDivider.Name = "pnlResultDivider";
            this.pnlResultDivider.Size = new System.Drawing.Size(446, 1);
            this.pnlResultDivider.TabIndex = 4;

            // 2 Khung Thông Tin Ghế & Phòng
            this.pnlInfoBoxes.Controls.Add(this.pnlBoxRoom);
            this.pnlInfoBoxes.Controls.Add(this.pnlBoxSeats);
            this.pnlInfoBoxes.Location = new System.Drawing.Point(20, 220);
            this.pnlInfoBoxes.Name = "pnlInfoBoxes";
            this.pnlInfoBoxes.Size = new System.Drawing.Size(466, 120);
            this.pnlInfoBoxes.TabIndex = 5;

            // Box Ghế
            this.pnlBoxSeats.Controls.Add(this.lblBoxSeatQty);
            this.pnlBoxSeats.Controls.Add(this.lblBoxSeatCodes);
            this.pnlBoxSeats.Controls.Add(this.lblBoxSeatTitle);
            this.pnlBoxSeats.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBoxSeats.Location = new System.Drawing.Point(0, 0);
            this.pnlBoxSeats.Name = "pnlBoxSeats";
            this.pnlBoxSeats.Size = new System.Drawing.Size(225, 120);
            this.pnlBoxSeats.TabIndex = 0;
            this.pnlBoxSeats.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBorderRight_Paint);

            this.lblBoxSeatTitle.AutoSize = true;
            this.lblBoxSeatTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBoxSeatTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblBoxSeatTitle.Location = new System.Drawing.Point(15, 12);
            this.lblBoxSeatTitle.Name = "lblBoxSeatTitle";
            this.lblBoxSeatTitle.Size = new System.Drawing.Size(65, 17);
            this.lblBoxSeatTitle.TabIndex = 0;
            this.lblBoxSeatTitle.Text = "SỐ GHẾ:";

            this.lblBoxSeatCodes.AutoSize = true;
            this.lblBoxSeatCodes.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBoxSeatCodes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblBoxSeatCodes.Location = new System.Drawing.Point(10, 35);
            this.lblBoxSeatCodes.Name = "lblBoxSeatCodes";
            this.lblBoxSeatCodes.Size = new System.Drawing.Size(182, 47);
            this.lblBoxSeatCodes.TabIndex = 1;
            this.lblBoxSeatCodes.Text = "G07, G08";

            this.lblBoxSeatQty.AutoSize = true;
            this.lblBoxSeatQty.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBoxSeatQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBoxSeatQty.Location = new System.Drawing.Point(18, 88);
            this.lblBoxSeatQty.Name = "lblBoxSeatQty";
            this.lblBoxSeatQty.Size = new System.Drawing.Size(89, 15);
            this.lblBoxSeatQty.TabIndex = 2;
            this.lblBoxSeatQty.Text = "Số lượng: 02 Vé";

            // Box Phòng
            this.pnlBoxRoom.Controls.Add(this.lblBoxRoomSubtitle);
            this.pnlBoxRoom.Controls.Add(this.lblBoxRoomTitle);
            this.pnlBoxRoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBoxRoom.Location = new System.Drawing.Point(235, 0);
            this.pnlBoxRoom.Name = "pnlBoxRoom";
            this.pnlBoxRoom.Size = new System.Drawing.Size(231, 120);
            this.pnlBoxRoom.TabIndex = 1;

            this.lblBoxRoomTitle.AutoSize = true;
            this.lblBoxRoomTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBoxRoomTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblBoxRoomTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBoxRoomTitle.Name = "lblBoxRoomTitle";
            this.lblBoxRoomTitle.Size = new System.Drawing.Size(176, 41);
            this.lblBoxRoomTitle.TabIndex = 0;
            this.lblBoxRoomTitle.Text = "PHÒNG 03";

            this.lblBoxRoomSubtitle.AutoSize = true;
            this.lblBoxRoomSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBoxRoomSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBoxRoomSubtitle.Location = new System.Drawing.Point(22, 70);
            this.lblBoxRoomSubtitle.Name = "lblBoxRoomSubtitle";
            this.lblBoxRoomSubtitle.Size = new System.Drawing.Size(138, 17);
            this.lblBoxRoomSubtitle.TabIndex = 1;
            this.lblBoxRoomSubtitle.Text = "Suất: 19:30 – Hôm nay";

            // Banner cảnh báo C16
            this.pnlAgeWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlAgeWarning.Controls.Add(this.lblAgeWarning);
            this.pnlAgeWarning.Location = new System.Drawing.Point(20, 360);
            this.pnlAgeWarning.Name = "pnlAgeWarning";
            this.pnlAgeWarning.Size = new System.Drawing.Size(466, 46);
            this.pnlAgeWarning.TabIndex = 6;
            this.pnlAgeWarning.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAgeWarning_Paint);

            this.lblAgeWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAgeWarning.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAgeWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblAgeWarning.Location = new System.Drawing.Point(0, 0);
            this.lblAgeWarning.Name = "lblAgeWarning";
            this.lblAgeWarning.Size = new System.Drawing.Size(466, 46);
            this.lblAgeWarning.TabIndex = 0;
            this.lblAgeWarning.Text = "C16 – YÊU CẦU KIỂM TRA CCCD";
            this.lblAgeWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Nút Xác nhận qua cổng
            this.btnConfirmPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnConfirmPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPass.FlatAppearance.BorderSize = 0;
            this.btnConfirmPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPass.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmPass.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPass.Location = new System.Drawing.Point(20, 425);
            this.btnConfirmPass.Name = "btnConfirmPass";
            this.btnConfirmPass.Size = new System.Drawing.Size(466, 55);
            this.btnConfirmPass.TabIndex = 7;
            this.btnConfirmPass.Text = "XÁC NHẬN QUA CỔNG (Space)";
            this.btnConfirmPass.UseVisualStyleBackColor = false;
            this.btnConfirmPass.Click += new System.EventHandler(this.btnConfirmPass_Click);

            // =========================================================================
            // 3. VIEW NHẬT KÝ SOÁT VÉ (pnlViewLogs)
            // =========================================================================
            this.pnlViewLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlViewLogs.Controls.Add(this.pnlLogsTableCard);
            this.pnlViewLogs.Controls.Add(this.pnlKpiSection);
            this.pnlViewLogs.Controls.Add(this.pnlLogsTopHeader);
            this.pnlViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewLogs.Location = new System.Drawing.Point(0, 0);
            this.pnlViewLogs.Name = "pnlViewLogs";
            this.pnlViewLogs.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlViewLogs.Size = new System.Drawing.Size(1020, 642);
            this.pnlViewLogs.TabIndex = 2;

            // Header nhật ký
            this.pnlLogsTopHeader.Controls.Add(this.btnBackToScanner);
            this.pnlLogsTopHeader.Controls.Add(this.lblLogsScreenTitle);
            this.pnlLogsTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogsTopHeader.Location = new System.Drawing.Point(18, 12);
            this.pnlLogsTopHeader.Name = "pnlLogsTopHeader";
            this.pnlLogsTopHeader.Size = new System.Drawing.Size(984, 46);
            this.pnlLogsTopHeader.TabIndex = 0;

            this.lblLogsScreenTitle.AutoSize = true;
            this.lblLogsScreenTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogsScreenTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLogsScreenTitle.Location = new System.Drawing.Point(0, 8);
            this.lblLogsScreenTitle.Name = "lblLogsScreenTitle";
            this.lblLogsScreenTitle.Size = new System.Drawing.Size(430, 25);
            this.lblLogsScreenTitle.TabIndex = 0;
            this.lblLogsScreenTitle.Text = "NHẬT KÝ SOÁT VÉ – PHÒNG 03 (Suất 19:30)";

            this.btnBackToScanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToScanner.BackColor = System.Drawing.Color.White;
            this.btnBackToScanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToScanner.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnBackToScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToScanner.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBackToScanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnBackToScanner.Location = new System.Drawing.Point(784, 8);
            this.btnBackToScanner.Name = "btnBackToScanner";
            this.btnBackToScanner.Size = new System.Drawing.Size(200, 30);
            this.btnBackToScanner.TabIndex = 1;
            this.btnBackToScanner.Text = "« Quay lại màn hình quét vé";
            this.btnBackToScanner.UseVisualStyleBackColor = false;
            this.btnBackToScanner.Click += new System.EventHandler(this.btnBackToScanner_Click);

            // 4 Thẻ KPI
            this.pnlKpiSection.Controls.Add(this.pnlKpiRejected);
            this.pnlKpiSection.Controls.Add(this.pnlKpiRemaining);
            this.pnlKpiSection.Controls.Add(this.pnlKpiScanned);
            this.pnlKpiSection.Controls.Add(this.pnlKpiTotal);
            this.pnlKpiSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiSection.Location = new System.Drawing.Point(18, 58);
            this.pnlKpiSection.Name = "pnlKpiSection";
            this.pnlKpiSection.Size = new System.Drawing.Size(984, 80);
            this.pnlKpiSection.TabIndex = 1;

            // Card 1: Tổng vé
            this.pnlKpiTotal.BackColor = System.Drawing.Color.White;
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalVal);
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalTitle);
            this.pnlKpiTotal.Controls.Add(this.picKpiTotal);
            this.pnlKpiTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiTotal.Name = "pnlKpiTotal";
            this.pnlKpiTotal.Size = new System.Drawing.Size(235, 75);
            this.pnlKpiTotal.TabIndex = 0;
            this.pnlKpiTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.picKpiTotal.Location = new System.Drawing.Point(15, 18);
            this.picKpiTotal.Name = "picKpiTotal";
            this.picKpiTotal.Size = new System.Drawing.Size(40, 40);
            this.picKpiTotal.TabIndex = 0;
            this.picKpiTotal.TabStop = false;
            this.picKpiTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.picKpiTotal_Paint);

            this.lblKpiTotalTitle.AutoSize = true;
            this.lblKpiTotalTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKpiTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiTotalTitle.Location = new System.Drawing.Point(65, 14);
            this.lblKpiTotalTitle.Name = "lblKpiTotalTitle";
            this.lblKpiTotalTitle.Size = new System.Drawing.Size(94, 15);
            this.lblKpiTotalTitle.TabIndex = 1;
            this.lblKpiTotalTitle.Text = "Tổng vé đã bán";

            this.lblKpiTotalVal.AutoSize = true;
            this.lblKpiTotalVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiTotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiTotalVal.Location = new System.Drawing.Point(64, 34);
            this.lblKpiTotalVal.Name = "lblKpiTotalVal";
            this.lblKpiTotalVal.Size = new System.Drawing.Size(86, 30);
            this.lblKpiTotalVal.TabIndex = 2;
            this.lblKpiTotalVal.Text = "110 vé";

            // Card 2: Đã vào rạp
            this.pnlKpiScanned.BackColor = System.Drawing.Color.White;
            this.pnlKpiScanned.Controls.Add(this.lblKpiScannedVal);
            this.pnlKpiScanned.Controls.Add(this.lblKpiScannedTitle);
            this.pnlKpiScanned.Controls.Add(this.picKpiScanned);
            this.pnlKpiScanned.Location = new System.Drawing.Point(248, 0);
            this.pnlKpiScanned.Name = "pnlKpiScanned";
            this.pnlKpiScanned.Size = new System.Drawing.Size(235, 75);
            this.pnlKpiScanned.TabIndex = 1;
            this.pnlKpiScanned.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.picKpiScanned.Location = new System.Drawing.Point(15, 18);
            this.picKpiScanned.Name = "picKpiScanned";
            this.picKpiScanned.Size = new System.Drawing.Size(40, 40);
            this.picKpiScanned.TabIndex = 0;
            this.picKpiScanned.TabStop = false;
            this.picKpiScanned.Paint += new System.Windows.Forms.PaintEventHandler(this.picKpiScanned_Paint);

            this.lblKpiScannedTitle.AutoSize = true;
            this.lblKpiScannedTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKpiScannedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiScannedTitle.Location = new System.Drawing.Point(65, 14);
            this.lblKpiScannedTitle.Name = "lblKpiScannedTitle";
            this.lblKpiScannedTitle.Size = new System.Drawing.Size(127, 15);
            this.lblKpiScannedTitle.TabIndex = 1;
            this.lblKpiScannedTitle.Text = "Đã vào rạp (Hợp lệ)";

            this.lblKpiScannedVal.AutoSize = true;
            this.lblKpiScannedVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiScannedVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblKpiScannedVal.Location = new System.Drawing.Point(64, 34);
            this.lblKpiScannedVal.Name = "lblKpiScannedVal";
            this.lblKpiScannedVal.Size = new System.Drawing.Size(73, 30);
            this.lblKpiScannedVal.TabIndex = 2;
            this.lblKpiScannedVal.Text = "85 vé";

            // Card 3: Chưa vào rạp
            this.pnlKpiRemaining.BackColor = System.Drawing.Color.White;
            this.pnlKpiRemaining.Controls.Add(this.lblKpiRemainingVal);
            this.pnlKpiRemaining.Controls.Add(this.lblKpiRemainingTitle);
            this.pnlKpiRemaining.Controls.Add(this.picKpiRemaining);
            this.pnlKpiRemaining.Location = new System.Drawing.Point(496, 0);
            this.pnlKpiRemaining.Name = "pnlKpiRemaining";
            this.pnlKpiRemaining.Size = new System.Drawing.Size(235, 75);
            this.pnlKpiRemaining.TabIndex = 2;
            this.pnlKpiRemaining.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.picKpiRemaining.Location = new System.Drawing.Point(15, 18);
            this.picKpiRemaining.Name = "picKpiRemaining";
            this.picKpiRemaining.Size = new System.Drawing.Size(40, 40);
            this.picKpiRemaining.TabIndex = 0;
            this.picKpiRemaining.TabStop = false;
            this.picKpiRemaining.Paint += new System.Windows.Forms.PaintEventHandler(this.picKpiRemaining_Paint);

            this.lblKpiRemainingTitle.AutoSize = true;
            this.lblKpiRemainingTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRemainingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiRemainingTitle.Location = new System.Drawing.Point(65, 14);
            this.lblKpiRemainingTitle.Name = "lblKpiRemainingTitle";
            this.lblKpiRemainingTitle.Size = new System.Drawing.Size(81, 15);
            this.lblKpiRemainingTitle.TabIndex = 1;
            this.lblKpiRemainingTitle.Text = "Chưa vào rạp";

            this.lblKpiRemainingVal.AutoSize = true;
            this.lblKpiRemainingVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRemainingVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblKpiRemainingVal.Location = new System.Drawing.Point(64, 34);
            this.lblKpiRemainingVal.Name = "lblKpiRemainingVal";
            this.lblKpiRemainingVal.Size = new System.Drawing.Size(73, 30);
            this.lblKpiRemainingVal.TabIndex = 2;
            this.lblKpiRemainingVal.Text = "25 vé";

            // Card 4: Từ chối
            this.pnlKpiRejected.BackColor = System.Drawing.Color.White;
            this.pnlKpiRejected.Controls.Add(this.lblKpiRejectedVal);
            this.pnlKpiRejected.Controls.Add(this.lblKpiRejectedTitle);
            this.pnlKpiRejected.Controls.Add(this.picKpiRejected);
            this.pnlKpiRejected.Location = new System.Drawing.Point(744, 0);
            this.pnlKpiRejected.Name = "pnlKpiRejected";
            this.pnlKpiRejected.Size = new System.Drawing.Size(240, 75);
            this.pnlKpiRejected.TabIndex = 3;
            this.pnlKpiRejected.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            this.picKpiRejected.Location = new System.Drawing.Point(15, 18);
            this.picKpiRejected.Name = "picKpiRejected";
            this.picKpiRejected.Size = new System.Drawing.Size(40, 40);
            this.picKpiRejected.TabIndex = 0;
            this.picKpiRejected.TabStop = false;
            this.picKpiRejected.Paint += new System.Windows.Forms.PaintEventHandler(this.picKpiRejected_Paint);

            this.lblKpiRejectedTitle.AutoSize = true;
            this.lblKpiRejectedTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRejectedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiRejectedTitle.Location = new System.Drawing.Point(65, 14);
            this.lblKpiRejectedTitle.Name = "lblKpiRejectedTitle";
            this.lblKpiRejectedTitle.Size = new System.Drawing.Size(142, 13);
            this.lblKpiRejectedTitle.TabIndex = 1;
            this.lblKpiRejectedTitle.Text = "Lượt bị từ chối (Lỗi/Trùng)";

            this.lblKpiRejectedVal.AutoSize = true;
            this.lblKpiRejectedVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiRejectedVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblKpiRejectedVal.Location = new System.Drawing.Point(64, 34);
            this.lblKpiRejectedVal.Name = "lblKpiRejectedVal";
            this.lblKpiRejectedVal.Size = new System.Drawing.Size(73, 30);
            this.lblKpiRejectedVal.TabIndex = 2;
            this.lblKpiRejectedVal.Text = "3 lượt";

            // Bảng Nhật Ký Card
            this.pnlLogsTableCard.BackColor = System.Drawing.Color.White;
            this.pnlLogsTableCard.Controls.Add(this.dgvLogs);
            this.pnlLogsTableCard.Controls.Add(this.pnlPagination);
            this.pnlLogsTableCard.Controls.Add(this.pnlLogsFilterBar);
            this.pnlLogsTableCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogsTableCard.Location = new System.Drawing.Point(18, 138);
            this.pnlLogsTableCard.Name = "pnlLogsTableCard";
            this.pnlLogsTableCard.Padding = new System.Windows.Forms.Padding(12);
            this.pnlLogsTableCard.Size = new System.Drawing.Size(984, 492);
            this.pnlLogsTableCard.TabIndex = 2;
            this.pnlLogsTableCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBorder_Paint);

            // Filter Bar
            this.pnlLogsFilterBar.Controls.Add(this.btnFilterTabRejected);
            this.pnlLogsFilterBar.Controls.Add(this.btnFilterTabSuccess);
            this.pnlLogsFilterBar.Controls.Add(this.btnFilterTabAll);
            this.pnlLogsFilterBar.Controls.Add(this.txtSearchLogs);
            this.pnlLogsFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogsFilterBar.Location = new System.Drawing.Point(12, 12);
            this.pnlLogsFilterBar.Name = "pnlLogsFilterBar";
            this.pnlLogsFilterBar.Size = new System.Drawing.Size(960, 44);
            this.pnlLogsFilterBar.TabIndex = 0;

            this.txtSearchLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtSearchLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchLogs.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchLogs.Location = new System.Drawing.Point(0, 6);
            this.txtSearchLogs.Name = "txtSearchLogs";
            this.txtSearchLogs.PlaceholderText = "🔍 Tìm theo Mã vé hoặc Số ghế...";
            this.txtSearchLogs.Size = new System.Drawing.Size(340, 24);
            this.txtSearchLogs.TabIndex = 0;
            this.txtSearchLogs.TextChanged += new System.EventHandler(this.txtSearchLogs_TextChanged);

            this.btnFilterTabAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnFilterTabAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterTabAll.FlatAppearance.BorderSize = 0;
            this.btnFilterTabAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterTabAll.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilterTabAll.ForeColor = System.Drawing.Color.White;
            this.btnFilterTabAll.Location = new System.Drawing.Point(360, 5);
            this.btnFilterTabAll.Name = "btnFilterTabAll";
            this.btnFilterTabAll.Size = new System.Drawing.Size(130, 27);
            this.btnFilterTabAll.TabIndex = 1;
            this.btnFilterTabAll.Text = "Tất cả lượt quét";
            this.btnFilterTabAll.UseVisualStyleBackColor = false;
            this.btnFilterTabAll.Click += new System.EventHandler(this.btnFilterTabAll_Click);

            this.btnFilterTabSuccess.BackColor = System.Drawing.Color.White;
            this.btnFilterTabSuccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterTabSuccess.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnFilterTabSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterTabSuccess.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFilterTabSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnFilterTabSuccess.Location = new System.Drawing.Point(498, 5);
            this.btnFilterTabSuccess.Name = "btnFilterTabSuccess";
            this.btnFilterTabSuccess.Size = new System.Drawing.Size(130, 27);
            this.btnFilterTabSuccess.TabIndex = 2;
            this.btnFilterTabSuccess.Text = "Hợp lệ (Đã vào)";
            this.btnFilterTabSuccess.UseVisualStyleBackColor = false;
            this.btnFilterTabSuccess.Click += new System.EventHandler(this.btnFilterTabSuccess_Click);

            this.btnFilterTabRejected.BackColor = System.Drawing.Color.White;
            this.btnFilterTabRejected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterTabRejected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnFilterTabRejected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterTabRejected.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFilterTabRejected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnFilterTabRejected.Location = new System.Drawing.Point(636, 5);
            this.btnFilterTabRejected.Name = "btnFilterTabRejected";
            this.btnFilterTabRejected.Size = new System.Drawing.Size(190, 27);
            this.btnFilterTabRejected.TabIndex = 3;
            this.btnFilterTabRejected.Text = "Bị từ chối (Dùng lại / Sai suất)";
            this.btnFilterTabRejected.UseVisualStyleBackColor = false;
            this.btnFilterTabRejected.Click += new System.EventHandler(this.btnFilterTabRejected_Click);

            // DataGridView
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AllowUserToResizeRows = false;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvLogs.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvLogs.ColumnHeadersHeight = 36;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLogTime,
            this.colLogBarcode,
            this.colLogSeat,
            this.colLogSeatType,
            this.colLogStaff,
            this.colLogStatus,
            this.colLogDetail});
            dgvRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.dgvLogs.DefaultCellStyle = dgvRowStyle;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.EnableHeadersVisualStyles = false;
            this.dgvLogs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvLogs.Location = new System.Drawing.Point(12, 56);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.RowTemplate.Height = 35;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(960, 384);
            this.dgvLogs.TabIndex = 1;
            this.dgvLogs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLogs_CellFormatting);

            this.colLogTime.HeaderText = "Thời gian quét";
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.ReadOnly = true;
            this.colLogTime.Width = 110;

            this.colLogBarcode.HeaderText = "Mã vé";
            this.colLogBarcode.Name = "colLogBarcode";
            this.colLogBarcode.ReadOnly = true;
            this.colLogBarcode.Width = 110;

            this.colLogSeat.HeaderText = "Vị trí ghế";
            this.colLogSeat.Name = "colLogSeat";
            this.colLogSeat.ReadOnly = true;
            this.colLogSeat.Width = 90;

            this.colLogSeatType.HeaderText = "Loại vé";
            this.colLogSeatType.Name = "colLogSeatType";
            this.colLogSeatType.ReadOnly = true;
            this.colLogSeatType.Width = 85;

            this.colLogStaff.HeaderText = "Nhân viên soát";
            this.colLogStaff.Name = "colLogStaff";
            this.colLogStaff.ReadOnly = true;
            this.colLogStaff.Width = 140;

            this.colLogStatus.HeaderText = "Trạng thái";
            this.colLogStatus.Name = "colLogStatus";
            this.colLogStatus.ReadOnly = true;
            this.colLogStatus.Width = 140;

            this.colLogDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLogDetail.HeaderText = "Ghi chú chi tiết";
            this.colLogDetail.Name = "colLogDetail";
            this.colLogDetail.ReadOnly = true;

            // Pagination Bar
            this.pnlPagination.Controls.Add(this.btnNextPage);
            this.pnlPagination.Controls.Add(this.btnPage13);
            this.pnlPagination.Controls.Add(this.lblDots);
            this.pnlPagination.Controls.Add(this.btnPage2);
            this.pnlPagination.Controls.Add(this.btnPage1);
            this.pnlPagination.Controls.Add(this.btnPrevPage);
            this.pnlPagination.Controls.Add(this.lblShowingCount);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(12, 440);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(960, 40);
            this.pnlPagination.TabIndex = 2;

            this.lblShowingCount.AutoSize = true;
            this.lblShowingCount.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShowingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblShowingCount.Location = new System.Drawing.Point(0, 12);
            this.lblShowingCount.Name = "lblShowingCount";
            this.lblShowingCount.Size = new System.Drawing.Size(147, 15);
            this.lblShowingCount.TabIndex = 0;
            this.lblShowingCount.Text = "Hiển thị 1–7/88 lượt quét";

            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.BackColor = System.Drawing.Color.White;
            this.btnPrevPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Location = new System.Drawing.Point(750, 7);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(30, 26);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = false;

            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPage1.FlatAppearance.BorderSize = 0;
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(785, 7);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(30, 26);
            this.btnPage1.TabIndex = 2;
            this.btnPage1.Text = "1";
            this.btnPage1.UseVisualStyleBackColor = false;

            this.btnPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage2.BackColor = System.Drawing.Color.White;
            this.btnPage2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.Location = new System.Drawing.Point(820, 7);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(30, 26);
            this.btnPage2.TabIndex = 3;
            this.btnPage2.Text = "2";
            this.btnPage2.UseVisualStyleBackColor = false;

            this.lblDots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDots.AutoSize = true;
            this.lblDots.Location = new System.Drawing.Point(855, 12);
            this.lblDots.Name = "lblDots";
            this.lblDots.Size = new System.Drawing.Size(17, 15);
            this.lblDots.TabIndex = 4;
            this.lblDots.Text = "...";

            this.btnPage13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage13.BackColor = System.Drawing.Color.White;
            this.btnPage13.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnPage13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage13.Location = new System.Drawing.Point(880, 7);
            this.btnPage13.Name = "btnPage13";
            this.btnPage13.Size = new System.Drawing.Size(35, 26);
            this.btnPage13.TabIndex = 5;
            this.btnPage13.Text = "13";
            this.btnPage13.UseVisualStyleBackColor = false;

            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BackColor = System.Drawing.Color.White;
            this.btnNextPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Location = new System.Drawing.Point(920, 7);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(30, 26);
            this.btnNextPage.TabIndex = 6;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = false;

            // Timer
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // =========================================================================
            // TicketCheckInForm
            // =========================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlContentHolder);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "TicketCheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STORYLINE CINEMA - HỆ THỐNG SOÁT VÉ CỬA RẠP";
            this.Load += new System.EventHandler(this.TicketCheckInForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TicketCheckInForm_KeyDown);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoIcon)).EndInit();
            this.pnlNavPos.ResumeLayout(false);
            this.pnlNavPos.PerformLayout();
            this.pnlNavCheckIn.ResumeLayout(false);
            this.pnlNavCheckIn.PerformLayout();
            this.pnlNavMember.ResumeLayout(false);
            this.pnlNavMember.PerformLayout();
            this.pnlNavInvoice.ResumeLayout(false);
            this.pnlNavInvoice.PerformLayout();
            this.pnlNavShift.ResumeLayout(false);
            this.pnlNavShift.PerformLayout();
            this.pnlStaffInfo.ResumeLayout(false);
            this.pnlStaffInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaffAvatar)).EndInit();
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlContentHolder.ResumeLayout(false);

            this.pnlViewSelectShowtime.ResumeLayout(false);
            this.pnlSelectFilterBar.ResumeLayout(false);
            this.pnlSelectFilterBar.PerformLayout();

            this.pnlViewScanner.ResumeLayout(false);
            this.pnlScannerHeader.ResumeLayout(false);
            this.pnlScannerHeader.PerformLayout();
            this.pnlScannerBody.ResumeLayout(false);
            this.pnlScannerLeft.ResumeLayout(false);
            this.pnlQrScannerCard.ResumeLayout(false);
            this.pnlManualInput.ResumeLayout(false);
            this.pnlManualInput.PerformLayout();
            this.pnlCameraBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneMockup)).EndInit();
            this.pnlCameraToolBar.ResumeLayout(false);
            this.pnlCameraToolBar.PerformLayout();
            this.pnlQrHeaderBar.ResumeLayout(false);
            this.pnlQrHeaderBar.PerformLayout();
            this.pnlScannerRight.ResumeLayout(false);
            this.pnlResultCard.ResumeLayout(false);
            this.pnlAgeWarning.ResumeLayout(false);
            this.pnlInfoBoxes.ResumeLayout(false);
            this.pnlBoxRoom.ResumeLayout(false);
            this.pnlBoxRoom.PerformLayout();
            this.pnlBoxSeats.ResumeLayout(false);
            this.pnlBoxSeats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheckmark)).EndInit();
            this.pnlMockShortcuts.ResumeLayout(false);

            this.pnlViewLogs.ResumeLayout(false);
            this.pnlLogsTableCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.pnlLogsFilterBar.ResumeLayout(false);
            this.pnlLogsFilterBar.PerformLayout();
            this.pnlKpiSection.ResumeLayout(false);
            this.pnlKpiRejected.ResumeLayout(false);
            this.pnlKpiRejected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiRejected)).EndInit();
            this.pnlKpiRemaining.ResumeLayout(false);
            this.pnlKpiRemaining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiRemaining)).EndInit();
            this.pnlKpiScanned.ResumeLayout(false);
            this.pnlKpiScanned.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiScanned)).EndInit();
            this.pnlKpiTotal.ResumeLayout(false);
            this.pnlKpiTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiTotal)).EndInit();
            this.pnlLogsTopHeader.ResumeLayout(false);
            this.pnlLogsTopHeader.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        // Layout controls
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox picLogoIcon;
        private System.Windows.Forms.Label lblLogoBrand;
        private System.Windows.Forms.Label lblLogoSub;
        private System.Windows.Forms.Panel pnlNavPos;
        private System.Windows.Forms.Label lblNavPos;
        private System.Windows.Forms.Panel pnlNavCheckIn;
        private System.Windows.Forms.Panel pnlActiveIndicator;
        private System.Windows.Forms.Label lblNavCheckIn;
        private System.Windows.Forms.Panel pnlNavMember;
        private System.Windows.Forms.Label lblNavMember;
        private System.Windows.Forms.Panel pnlNavInvoice;
        private System.Windows.Forms.Label lblNavInvoice;
        private System.Windows.Forms.Panel pnlNavShift;
        private System.Windows.Forms.Label lblNavShift;
        private System.Windows.Forms.Panel pnlStaffInfo;
        private System.Windows.Forms.PictureBox picStaffAvatar;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblStaffPos;
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblUserHeader;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterText;
        private System.Windows.Forms.Panel pnlContentHolder;

        // View 1
        private System.Windows.Forms.Panel pnlViewSelectShowtime;
        private System.Windows.Forms.Panel pnlSelectFilterBar;
        private System.Windows.Forms.Label lblSelectTitle;
        private System.Windows.Forms.Label lblRoomFilter;
        private System.Windows.Forms.ComboBox cboRoomFilter;
        private System.Windows.Forms.Button btnFilterActive;
        private System.Windows.Forms.Button btnFilterUpcoming;
        private System.Windows.Forms.FlowLayoutPanel flowShowtimes;

        // View 2
        private System.Windows.Forms.Panel pnlViewScanner;
        private System.Windows.Forms.Panel pnlScannerHeader;
        private System.Windows.Forms.Button btnChangeShowtime;
        private System.Windows.Forms.Label lblActiveShowtimeTitle;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.Panel pnlScannerBody;
        private System.Windows.Forms.Panel pnlScannerLeft;
        private System.Windows.Forms.Panel pnlQrScannerCard;
        private System.Windows.Forms.Panel pnlQrHeaderBar;
        private System.Windows.Forms.Label lblQrHeaderTitle;
        private System.Windows.Forms.Panel pnlCameraToolBar;
        private System.Windows.Forms.Label lblCameraSelect;
        private System.Windows.Forms.ComboBox cboCameras;
        private System.Windows.Forms.Button btnToggleCamera;
        private System.Windows.Forms.Panel pnlCameraBox;
        private System.Windows.Forms.Panel pnlLaserLine;
        private System.Windows.Forms.PictureBox picPhoneMockup;
        private System.Windows.Forms.Label lblCameraFoot;
        private System.Windows.Forms.Panel pnlManualInput;
        private System.Windows.Forms.Label lblInputPrompt;
        private System.Windows.Forms.TextBox txtInputBarcode;
        private System.Windows.Forms.Button btnCheckBarcode;
        private System.Windows.Forms.Panel pnlMockShortcuts;
        private System.Windows.Forms.Button btnMock1Valid;
        private System.Windows.Forms.Button btnMock2Used;
        private System.Windows.Forms.Button btnMock3Wrong;
        private System.Windows.Forms.Button btnMock4NotFound;
        private System.Windows.Forms.Panel pnlScannerRight;
        private System.Windows.Forms.Panel pnlResultCard;
        private System.Windows.Forms.Label lblCheckInCountBadge;
        private System.Windows.Forms.PictureBox picCheckmark;
        private System.Windows.Forms.Label lblResultMain;
        private System.Windows.Forms.Label lblResultSub;
        private System.Windows.Forms.Panel pnlResultDivider;
        private System.Windows.Forms.Panel pnlInfoBoxes;
        private System.Windows.Forms.Panel pnlBoxSeats;
        private System.Windows.Forms.Label lblBoxSeatTitle;
        private System.Windows.Forms.Label lblBoxSeatCodes;
        private System.Windows.Forms.Label lblBoxSeatQty;
        private System.Windows.Forms.Panel pnlBoxRoom;
        private System.Windows.Forms.Label lblBoxRoomTitle;
        private System.Windows.Forms.Label lblBoxRoomSubtitle;
        private System.Windows.Forms.Panel pnlAgeWarning;
        private System.Windows.Forms.Label lblAgeWarning;
        private System.Windows.Forms.Button btnConfirmPass;

        // View 3
        private System.Windows.Forms.Panel pnlViewLogs;
        private System.Windows.Forms.Panel pnlLogsTopHeader;
        private System.Windows.Forms.Label lblLogsScreenTitle;
        private System.Windows.Forms.Button btnBackToScanner;
        private System.Windows.Forms.Panel pnlKpiSection;
        private System.Windows.Forms.Panel pnlKpiTotal;
        private System.Windows.Forms.PictureBox picKpiTotal;
        private System.Windows.Forms.Label lblKpiTotalTitle;
        private System.Windows.Forms.Label lblKpiTotalVal;
        private System.Windows.Forms.Panel pnlKpiScanned;
        private System.Windows.Forms.PictureBox picKpiScanned;
        private System.Windows.Forms.Label lblKpiScannedTitle;
        private System.Windows.Forms.Label lblKpiScannedVal;
        private System.Windows.Forms.Panel pnlKpiRemaining;
        private System.Windows.Forms.PictureBox picKpiRemaining;
        private System.Windows.Forms.Label lblKpiRemainingTitle;
        private System.Windows.Forms.Label lblKpiRemainingVal;
        private System.Windows.Forms.Panel pnlKpiRejected;
        private System.Windows.Forms.PictureBox picKpiRejected;
        private System.Windows.Forms.Label lblKpiRejectedTitle;
        private System.Windows.Forms.Label lblKpiRejectedVal;
        private System.Windows.Forms.Panel pnlLogsTableCard;
        private System.Windows.Forms.Panel pnlLogsFilterBar;
        private System.Windows.Forms.TextBox txtSearchLogs;
        private System.Windows.Forms.Button btnFilterTabAll;
        private System.Windows.Forms.Button btnFilterTabSuccess;
        private System.Windows.Forms.Button btnFilterTabRejected;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogSeatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogDetail;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblShowingCount;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Label lblDots;
        private System.Windows.Forms.Button btnPage13;
        private System.Windows.Forms.Button btnNextPage;

        private System.Windows.Forms.Timer timerClock;
    }
}

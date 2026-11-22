using System.ComponentModel;

namespace Cinema.WinForms.Features.TicketSales;

partial class PaymentView
{
    private IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            picQr?.Image?.Dispose();
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        layoutPage = new TableLayoutPanel();
        progressBar = new Cinema.WinForms.Controls.TicketSalesProgressBar();
        layoutHeading = new TableLayoutPanel();
        lblTitle = new Label();
        lblCountdown = new Label();
        layoutWorkArea = new TableLayoutPanel();
        layoutLeft = new TableLayoutPanel();
        pnlMember = new Panel();
        layoutMember = new TableLayoutPanel();
        lblMemberTitle = new Label();
        layoutPhone = new TableLayoutPanel();
        lblPhone = new Label();
        txtPhone = new TextBox();
        btnFindMember = new Button();
        pnlMemberMessage = new Panel();
        layoutMemberResult = new TableLayoutPanel();
        lblMemberName = new Label();
        lblMemberDetails = new Label();
        lblMemberStatus = new Label();
        pnlOrder = new Panel();
        layoutOrder = new TableLayoutPanel();
        lblOrderTitle = new Label();
        lblMovie = new Label();
        lblShowtime = new Label();
        lblSeats = new Label();
        gridOrder = new DataGridView();
        colDescription = new DataGridViewTextBoxColumn();
        colQuantity = new DataGridViewTextBoxColumn();
        colUnitPrice = new DataGridViewTextBoxColumn();
        colAmount = new DataGridViewTextBoxColumn();
        layoutTotal = new TableLayoutPanel();
        lblTotalCaption = new Label();
        lblTotal = new Label();
        pnlPayment = new Panel();
        layoutPayment = new TableLayoutPanel();
        lblMethodTitle = new Label();
        layoutMethods = new TableLayoutPanel();
        btnCash = new Button();
        btnQr = new Button();
        pnlMethodDetails = new Panel();
        layoutQr = new TableLayoutPanel();
        picQr = new PictureBox();
        lblQrBadge = new Label();
        layoutQrDetails = new TableLayoutPanel();
        lblQrAmountCaption = new Label();
        lblQrAmount = new Label();
        lblQrReferenceCaption = new Label();
        lblQrReference = new Label();
        chkQrVerified = new CheckBox();
        lblQrStatus = new Label();
        layoutCash = new TableLayoutPanel();
        lblCash = new Label();
        txtCash = new TextBox();
        lblDenominations = new Label();
        layoutDenominations = new TableLayoutPanel();
        btnCash100 = new Button();
        btnCash200 = new Button();
        btnCash500 = new Button();
        btnExactCash = new Button();
        layoutCashBalance = new TableLayoutPanel();
        lblCashStatus = new Label();
        lblCashBalance = new Label();
        lblPaymentNotice = new Label();
        layoutActions = new TableLayoutPanel();
        btnBack = new Button();
        btnConfirm = new Button();
        orderBindingSource = new BindingSource(components);
        memberErrors = new ErrorProvider(components);
        layoutPage.SuspendLayout();
        layoutHeading.SuspendLayout();
        layoutWorkArea.SuspendLayout();
        layoutLeft.SuspendLayout();
        pnlMember.SuspendLayout();
        layoutMember.SuspendLayout();
        layoutPhone.SuspendLayout();
        pnlMemberMessage.SuspendLayout();
        layoutMemberResult.SuspendLayout();
        pnlOrder.SuspendLayout();
        layoutOrder.SuspendLayout();
        ((ISupportInitialize)gridOrder).BeginInit();
        layoutTotal.SuspendLayout();
        pnlPayment.SuspendLayout();
        layoutPayment.SuspendLayout();
        layoutMethods.SuspendLayout();
        pnlMethodDetails.SuspendLayout();
        layoutQr.SuspendLayout();
        ((ISupportInitialize)picQr).BeginInit();
        layoutQrDetails.SuspendLayout();
        layoutCash.SuspendLayout();
        layoutDenominations.SuspendLayout();
        layoutCashBalance.SuspendLayout();
        layoutActions.SuspendLayout();
        ((ISupportInitialize)orderBindingSource).BeginInit();
        ((ISupportInitialize)memberErrors).BeginInit();
        SuspendLayout();
        // 
        // layoutPage
        // 
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.Controls.Add(progressBar, 0, 0);
        layoutPage.Controls.Add(layoutHeading, 0, 1);
        layoutPage.Controls.Add(layoutWorkArea, 0, 2);
        layoutPage.Controls.Add(lblPaymentNotice, 0, 3);
        layoutPage.Controls.Add(layoutActions, 0, 4);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(20, 14, 20, 14);
        layoutPage.RowCount = 5;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.RowStyles.Add(new RowStyle());
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
        layoutPage.Size = new Size(1136, 722);
        layoutPage.TabIndex = 0;
        // 
        // progressBar
        // 
        progressBar.ActiveStep = 4;
        progressBar.Dock = DockStyle.Fill;
        progressBar.Location = new Point(20, 14);
        progressBar.Margin = new Padding(0);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(1096, 46);
        progressBar.TabIndex = 0;
        progressBar.TabStop = false;
        // 
        // layoutHeading
        // 
        layoutHeading.ColumnCount = 2;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 154F));
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblCountdown, 1, 0);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.Location = new Point(20, 65);
        layoutHeading.Margin = new Padding(0, 5, 0, 6);
        layoutHeading.Name = "layoutHeading";
        layoutHeading.RowCount = 1;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeading.Size = new Size(1096, 42);
        layoutHeading.TabIndex = 1;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(942, 42);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "TÍNH TIỀN & THANH TOÁN";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // lblCountdown
        // 
        lblCountdown.BackColor = Color.FromArgb(219, 234, 254);
        lblCountdown.Dock = DockStyle.Fill;
        lblCountdown.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCountdown.ForeColor = Color.FromArgb(37, 99, 235);
        lblCountdown.Location = new Point(942, 6);
        lblCountdown.Margin = new Padding(0, 6, 0, 6);
        lblCountdown.Name = "lblCountdown";
        lblCountdown.Size = new Size(154, 30);
        lblCountdown.TabIndex = 1;
        lblCountdown.Text = "Giữ ghế  —";
        lblCountdown.TextAlign = ContentAlignment.MiddleCenter;
        lblCountdown.UseMnemonic = false;
        // 
        // layoutWorkArea
        // 
        layoutWorkArea.ColumnCount = 2;
        layoutWorkArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutWorkArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutWorkArea.Controls.Add(layoutLeft, 0, 0);
        layoutWorkArea.Controls.Add(pnlPayment, 1, 0);
        layoutWorkArea.Dock = DockStyle.Fill;
        layoutWorkArea.Location = new Point(20, 113);
        layoutWorkArea.Margin = new Padding(0);
        layoutWorkArea.Name = "layoutWorkArea";
        layoutWorkArea.RowCount = 1;
        layoutWorkArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutWorkArea.Size = new Size(1096, 504);
        layoutWorkArea.TabIndex = 2;
        // 
        // layoutLeft
        // 
        layoutLeft.ColumnCount = 1;
        layoutLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutLeft.Controls.Add(pnlMember, 0, 0);
        layoutLeft.Controls.Add(pnlOrder, 0, 1);
        layoutLeft.Dock = DockStyle.Fill;
        layoutLeft.Location = new Point(0, 0);
        layoutLeft.Margin = new Padding(0, 0, 12, 0);
        layoutLeft.Name = "layoutLeft";
        layoutLeft.RowCount = 2;
        layoutLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 145F));
        layoutLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutLeft.Size = new Size(557, 504);
        layoutLeft.TabIndex = 0;
        // 
        // pnlMember
        // 
        pnlMember.BackColor = Color.FromArgb(226, 232, 240);
        pnlMember.Controls.Add(layoutMember);
        pnlMember.Dock = DockStyle.Fill;
        pnlMember.Location = new Point(0, 0);
        pnlMember.Margin = new Padding(0, 0, 0, 10);
        pnlMember.Name = "pnlMember";
        pnlMember.Padding = new Padding(1);
        pnlMember.Size = new Size(557, 135);
        pnlMember.TabIndex = 0;
        // 
        // layoutMember
        // 
        layoutMember.BackColor = Color.White;
        layoutMember.ColumnCount = 1;
        layoutMember.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMember.Controls.Add(lblMemberTitle, 0, 0);
        layoutMember.Controls.Add(layoutPhone, 0, 1);
        layoutMember.Controls.Add(pnlMemberMessage, 0, 2);
        layoutMember.Dock = DockStyle.Fill;
        layoutMember.Location = new Point(1, 1);
        layoutMember.Margin = new Padding(0);
        layoutMember.Name = "layoutMember";
        layoutMember.Padding = new Padding(14, 8, 14, 8);
        layoutMember.RowCount = 3;
        layoutMember.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        layoutMember.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutMember.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMember.Size = new Size(555, 133);
        layoutMember.TabIndex = 0;
        // 
        // lblMemberTitle
        // 
        lblMemberTitle.Dock = DockStyle.Fill;
        lblMemberTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblMemberTitle.Location = new Point(14, 8);
        lblMemberTitle.Margin = new Padding(0);
        lblMemberTitle.Name = "lblMemberTitle";
        lblMemberTitle.Size = new Size(527, 28);
        lblMemberTitle.TabIndex = 0;
        lblMemberTitle.Text = "Thông tin thành viên";
        lblMemberTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblMemberTitle.UseMnemonic = false;
        // 
        // layoutPhone
        // 
        layoutPhone.ColumnCount = 3;
        layoutPhone.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116F));
        layoutPhone.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPhone.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
        layoutPhone.Controls.Add(lblPhone, 0, 0);
        layoutPhone.Controls.Add(txtPhone, 1, 0);
        layoutPhone.Controls.Add(btnFindMember, 2, 0);
        layoutPhone.Dock = DockStyle.Fill;
        layoutPhone.Location = new Point(14, 36);
        layoutPhone.Margin = new Padding(0);
        layoutPhone.Name = "layoutPhone";
        layoutPhone.RowCount = 1;
        layoutPhone.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPhone.Size = new Size(527, 36);
        layoutPhone.TabIndex = 1;
        // 
        // lblPhone
        // 
        lblPhone.Dock = DockStyle.Fill;
        lblPhone.Location = new Point(0, 0);
        lblPhone.Margin = new Padding(0);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(116, 36);
        lblPhone.TabIndex = 0;
        lblPhone.Text = "Số điện thoại";
        lblPhone.TextAlign = ContentAlignment.MiddleLeft;
        lblPhone.UseMnemonic = false;
        // 
        // txtPhone
        // 
        txtPhone.AccessibleName = "Số điện thoại";
        txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPhone.Font = new Font("Segoe UI", 9F);
        txtPhone.ForeColor = Color.FromArgb(15, 23, 42);
        memberErrors.SetIconPadding(txtPhone, 3);
        txtPhone.Location = new Point(116, 4);
        txtPhone.Margin = new Padding(0, 0, 24, 0);
        txtPhone.MaxLength = 20;
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(312, 27);
        txtPhone.TabIndex = 1;
        txtPhone.TextChanged += TxtPhone_TextChanged;
        txtPhone.KeyDown += TxtPhone_KeyDown;
        txtPhone.Validating += TxtPhone_Validating;
        // 
        // btnFindMember
        // 
        btnFindMember.BackColor = Color.White;
        btnFindMember.CausesValidation = false;
        btnFindMember.Dock = DockStyle.Fill;
        btnFindMember.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnFindMember.FlatStyle = FlatStyle.Flat;
        btnFindMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnFindMember.ForeColor = Color.FromArgb(15, 23, 42);
        btnFindMember.Location = new Point(452, 2);
        btnFindMember.Margin = new Padding(0, 2, 0, 2);
        btnFindMember.Name = "btnFindMember";
        btnFindMember.Size = new Size(75, 32);
        btnFindMember.TabIndex = 2;
        btnFindMember.Text = "Tìm";
        btnFindMember.UseMnemonic = false;
        btnFindMember.UseVisualStyleBackColor = false;
        btnFindMember.Click += BtnFindMember_Click;
        // 
        // pnlMemberMessage
        // 
        pnlMemberMessage.Controls.Add(layoutMemberResult);
        pnlMemberMessage.Controls.Add(lblMemberStatus);
        pnlMemberMessage.Dock = DockStyle.Fill;
        pnlMemberMessage.Location = new Point(14, 75);
        pnlMemberMessage.Margin = new Padding(0, 3, 0, 0);
        pnlMemberMessage.Name = "pnlMemberMessage";
        pnlMemberMessage.Size = new Size(527, 50);
        pnlMemberMessage.TabIndex = 2;
        // 
        // layoutMemberResult
        // 
        layoutMemberResult.BackColor = Color.FromArgb(239, 246, 255);
        layoutMemberResult.ColumnCount = 1;
        layoutMemberResult.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMemberResult.Controls.Add(lblMemberName, 0, 0);
        layoutMemberResult.Controls.Add(lblMemberDetails, 0, 1);
        layoutMemberResult.Dock = DockStyle.Fill;
        layoutMemberResult.Location = new Point(0, 0);
        layoutMemberResult.Margin = new Padding(0);
        layoutMemberResult.Name = "layoutMemberResult";
        layoutMemberResult.Padding = new Padding(10, 2, 10, 2);
        layoutMemberResult.RowCount = 2;
        layoutMemberResult.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        layoutMemberResult.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        layoutMemberResult.Size = new Size(527, 50);
        layoutMemberResult.TabIndex = 0;
        layoutMemberResult.Visible = false;
        // 
        // lblMemberName
        // 
        lblMemberName.Dock = DockStyle.Fill;
        lblMemberName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMemberName.Location = new Point(10, 2);
        lblMemberName.Margin = new Padding(0);
        lblMemberName.Name = "lblMemberName";
        lblMemberName.Size = new Size(507, 23);
        lblMemberName.TabIndex = 0;
        lblMemberName.TextAlign = ContentAlignment.MiddleLeft;
        lblMemberName.UseMnemonic = false;
        // 
        // lblMemberDetails
        // 
        lblMemberDetails.Dock = DockStyle.Fill;
        lblMemberDetails.ForeColor = Color.FromArgb(100, 116, 139);
        lblMemberDetails.Location = new Point(10, 25);
        lblMemberDetails.Margin = new Padding(0);
        lblMemberDetails.Name = "lblMemberDetails";
        lblMemberDetails.Size = new Size(507, 23);
        lblMemberDetails.TabIndex = 1;
        lblMemberDetails.TextAlign = ContentAlignment.MiddleLeft;
        lblMemberDetails.UseMnemonic = false;
        // 
        // lblMemberStatus
        // 
        lblMemberStatus.Dock = DockStyle.Fill;
        lblMemberStatus.ForeColor = Color.FromArgb(100, 116, 139);
        lblMemberStatus.Location = new Point(0, 0);
        lblMemberStatus.Margin = new Padding(0);
        lblMemberStatus.Name = "lblMemberStatus";
        lblMemberStatus.Size = new Size(527, 50);
        lblMemberStatus.TabIndex = 0;
        lblMemberStatus.Text = "Khách lẻ";
        lblMemberStatus.TextAlign = ContentAlignment.MiddleLeft;
        lblMemberStatus.UseMnemonic = false;
        // 
        // pnlOrder
        // 
        pnlOrder.BackColor = Color.FromArgb(226, 232, 240);
        pnlOrder.Controls.Add(layoutOrder);
        pnlOrder.Dock = DockStyle.Fill;
        pnlOrder.Location = new Point(0, 145);
        pnlOrder.Margin = new Padding(0);
        pnlOrder.Name = "pnlOrder";
        pnlOrder.Padding = new Padding(1);
        pnlOrder.Size = new Size(557, 359);
        pnlOrder.TabIndex = 1;
        // 
        // layoutOrder
        // 
        layoutOrder.BackColor = Color.White;
        layoutOrder.ColumnCount = 1;
        layoutOrder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutOrder.Controls.Add(lblOrderTitle, 0, 0);
        layoutOrder.Controls.Add(lblMovie, 0, 1);
        layoutOrder.Controls.Add(lblShowtime, 0, 2);
        layoutOrder.Controls.Add(lblSeats, 0, 3);
        layoutOrder.Controls.Add(gridOrder, 0, 4);
        layoutOrder.Controls.Add(layoutTotal, 0, 5);
        layoutOrder.Dock = DockStyle.Fill;
        layoutOrder.Location = new Point(1, 1);
        layoutOrder.Margin = new Padding(0);
        layoutOrder.Name = "layoutOrder";
        layoutOrder.Padding = new Padding(14, 9, 14, 11);
        layoutOrder.RowCount = 6;
        layoutOrder.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
        layoutOrder.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layoutOrder.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
        layoutOrder.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
        layoutOrder.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutOrder.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layoutOrder.Size = new Size(555, 357);
        layoutOrder.TabIndex = 0;
        // 
        // lblOrderTitle
        // 
        lblOrderTitle.Dock = DockStyle.Fill;
        lblOrderTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblOrderTitle.Location = new Point(14, 9);
        lblOrderTitle.Margin = new Padding(0);
        lblOrderTitle.Name = "lblOrderTitle";
        lblOrderTitle.Size = new Size(527, 27);
        lblOrderTitle.TabIndex = 0;
        lblOrderTitle.Text = "Chi tiết đơn hàng";
        lblOrderTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblOrderTitle.UseMnemonic = false;
        // 
        // lblMovie
        // 
        lblMovie.AutoEllipsis = true;
        lblMovie.Dock = DockStyle.Fill;
        lblMovie.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMovie.Location = new Point(14, 36);
        lblMovie.Margin = new Padding(0);
        lblMovie.Name = "lblMovie";
        lblMovie.Size = new Size(527, 24);
        lblMovie.TabIndex = 1;
        lblMovie.TextAlign = ContentAlignment.MiddleLeft;
        lblMovie.UseMnemonic = false;
        // 
        // lblShowtime
        // 
        lblShowtime.AutoEllipsis = true;
        lblShowtime.Dock = DockStyle.Fill;
        lblShowtime.ForeColor = Color.FromArgb(100, 116, 139);
        lblShowtime.Location = new Point(14, 60);
        lblShowtime.Margin = new Padding(0);
        lblShowtime.Name = "lblShowtime";
        lblShowtime.Size = new Size(527, 23);
        lblShowtime.TabIndex = 2;
        lblShowtime.TextAlign = ContentAlignment.MiddleLeft;
        lblShowtime.UseMnemonic = false;
        // 
        // lblSeats
        // 
        lblSeats.AutoEllipsis = true;
        lblSeats.Dock = DockStyle.Fill;
        lblSeats.ForeColor = Color.FromArgb(100, 116, 139);
        lblSeats.Location = new Point(14, 83);
        lblSeats.Margin = new Padding(0);
        lblSeats.Name = "lblSeats";
        lblSeats.Size = new Size(527, 23);
        lblSeats.TabIndex = 3;
        lblSeats.TextAlign = ContentAlignment.MiddleLeft;
        lblSeats.UseMnemonic = false;
        // 
        // gridOrder
        // 
        gridOrder.AccessibleName = "Chi tiết đơn hàng";
        gridOrder.AllowUserToAddRows = false;
        gridOrder.AllowUserToDeleteRows = false;
        gridOrder.AllowUserToResizeColumns = false;
        gridOrder.AllowUserToResizeRows = false;
        gridOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        gridOrder.BackgroundColor = Color.White;
        gridOrder.BorderStyle = BorderStyle.None;
        gridOrder.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridOrder.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(51, 65, 85);
        gridOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        gridOrder.ColumnHeadersHeight = 32;
        gridOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridOrder.Columns.AddRange(new DataGridViewColumn[] { colDescription, colQuantity, colUnitPrice, colAmount });
        dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle5.BackColor = SystemColors.Window;
        dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle5.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(219, 234, 254);
        dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
        gridOrder.DefaultCellStyle = dataGridViewCellStyle5;
        gridOrder.Dock = DockStyle.Fill;
        gridOrder.EnableHeadersVisualStyles = false;
        gridOrder.GridColor = Color.FromArgb(226, 232, 240);
        gridOrder.Location = new Point(14, 110);
        gridOrder.Margin = new Padding(0, 4, 0, 8);
        gridOrder.MultiSelect = false;
        gridOrder.Name = "gridOrder";
        gridOrder.ReadOnly = true;
        gridOrder.RowHeadersVisible = false;
        gridOrder.RowHeadersWidth = 51;
        gridOrder.RowTemplate.Height = 34;
        gridOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridOrder.Size = new Size(527, 174);
        gridOrder.TabIndex = 4;
        gridOrder.DataBindingComplete += GridOrder_DataBindingComplete;
        // 
        // colDescription
        // 
        colDescription.DataPropertyName = "Description";
        colDescription.FillWeight = 46F;
        colDescription.HeaderText = "Mặt hàng";
        colDescription.MinimumWidth = 6;
        colDescription.Name = "colDescription";
        colDescription.ReadOnly = true;
        // 
        // colQuantity
        // 
        colQuantity.DataPropertyName = "Quantity";
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colQuantity.DefaultCellStyle = dataGridViewCellStyle2;
        colQuantity.FillWeight = 14F;
        colQuantity.HeaderText = "Số lượng";
        colQuantity.MinimumWidth = 6;
        colQuantity.Name = "colQuantity";
        colQuantity.ReadOnly = true;
        // 
        // colUnitPrice
        // 
        colUnitPrice.DataPropertyName = "UnitPrice";
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle3.Format = "N0";
        colUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
        colUnitPrice.FillWeight = 20F;
        colUnitPrice.HeaderText = "Đơn giá";
        colUnitPrice.MinimumWidth = 6;
        colUnitPrice.Name = "colUnitPrice";
        colUnitPrice.ReadOnly = true;
        // 
        // colAmount
        // 
        colAmount.DataPropertyName = "Amount";
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle4.Format = "N0";
        colAmount.DefaultCellStyle = dataGridViewCellStyle4;
        colAmount.FillWeight = 20F;
        colAmount.HeaderText = "Thành tiền";
        colAmount.MinimumWidth = 6;
        colAmount.Name = "colAmount";
        colAmount.ReadOnly = true;
        // 
        // layoutTotal
        // 
        layoutTotal.BackColor = Color.FromArgb(241, 245, 249);
        layoutTotal.ColumnCount = 2;
        layoutTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51F));
        layoutTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49F));
        layoutTotal.Controls.Add(lblTotalCaption, 0, 0);
        layoutTotal.Controls.Add(lblTotal, 1, 0);
        layoutTotal.Dock = DockStyle.Fill;
        layoutTotal.Location = new Point(14, 292);
        layoutTotal.Margin = new Padding(0);
        layoutTotal.Name = "layoutTotal";
        layoutTotal.Padding = new Padding(10, 0, 10, 0);
        layoutTotal.RowCount = 1;
        layoutTotal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutTotal.Size = new Size(527, 54);
        layoutTotal.TabIndex = 5;
        // 
        // lblTotalCaption
        // 
        lblTotalCaption.Dock = DockStyle.Fill;
        lblTotalCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTotalCaption.Location = new Point(10, 0);
        lblTotalCaption.Margin = new Padding(0);
        lblTotalCaption.Name = "lblTotalCaption";
        lblTotalCaption.Size = new Size(258, 54);
        lblTotalCaption.TabIndex = 0;
        lblTotalCaption.Text = "TỔNG THANH TOÁN";
        lblTotalCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTotalCaption.UseMnemonic = false;
        // 
        // lblTotal
        // 
        lblTotal.Dock = DockStyle.Fill;
        lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(37, 99, 235);
        lblTotal.Location = new Point(268, 0);
        lblTotal.Margin = new Padding(0);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(249, 54);
        lblTotal.TabIndex = 1;
        lblTotal.Text = "—";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        lblTotal.UseMnemonic = false;
        // 
        // pnlPayment
        // 
        pnlPayment.BackColor = Color.FromArgb(226, 232, 240);
        pnlPayment.Controls.Add(layoutPayment);
        pnlPayment.Dock = DockStyle.Fill;
        pnlPayment.Location = new Point(569, 0);
        pnlPayment.Margin = new Padding(0);
        pnlPayment.Name = "pnlPayment";
        pnlPayment.Padding = new Padding(1);
        pnlPayment.Size = new Size(527, 504);
        pnlPayment.TabIndex = 1;
        // 
        // layoutPayment
        // 
        layoutPayment.BackColor = Color.White;
        layoutPayment.ColumnCount = 1;
        layoutPayment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPayment.Controls.Add(lblMethodTitle, 0, 0);
        layoutPayment.Controls.Add(layoutMethods, 0, 1);
        layoutPayment.Controls.Add(pnlMethodDetails, 0, 2);
        layoutPayment.Dock = DockStyle.Fill;
        layoutPayment.Location = new Point(1, 1);
        layoutPayment.Margin = new Padding(0);
        layoutPayment.Name = "layoutPayment";
        layoutPayment.Padding = new Padding(14, 9, 14, 11);
        layoutPayment.RowCount = 3;
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        layoutPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPayment.Size = new Size(525, 502);
        layoutPayment.TabIndex = 0;
        // 
        // lblMethodTitle
        // 
        lblMethodTitle.Dock = DockStyle.Fill;
        lblMethodTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblMethodTitle.Location = new Point(14, 9);
        lblMethodTitle.Margin = new Padding(0);
        lblMethodTitle.Name = "lblMethodTitle";
        lblMethodTitle.Size = new Size(497, 28);
        lblMethodTitle.TabIndex = 0;
        lblMethodTitle.Text = "Phương thức thanh toán";
        lblMethodTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblMethodTitle.UseMnemonic = false;
        // 
        // layoutMethods
        // 
        layoutMethods.ColumnCount = 2;
        layoutMethods.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutMethods.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutMethods.Controls.Add(btnCash, 0, 0);
        layoutMethods.Controls.Add(btnQr, 1, 0);
        layoutMethods.Dock = DockStyle.Fill;
        layoutMethods.Location = new Point(14, 40);
        layoutMethods.Margin = new Padding(0, 3, 0, 8);
        layoutMethods.Name = "layoutMethods";
        layoutMethods.RowCount = 1;
        layoutMethods.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutMethods.Size = new Size(497, 44);
        layoutMethods.TabIndex = 1;
        // 
        // btnCash
        // 
        btnCash.BackColor = Color.FromArgb(37, 99, 235);
        btnCash.CausesValidation = false;
        btnCash.Dock = DockStyle.Fill;
        btnCash.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        btnCash.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
        btnCash.FlatStyle = FlatStyle.Flat;
        btnCash.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCash.ForeColor = Color.White;
        btnCash.Location = new Point(0, 0);
        btnCash.Margin = new Padding(0, 0, 5, 0);
        btnCash.Name = "btnCash";
        btnCash.Size = new Size(243, 44);
        btnCash.TabIndex = 0;
        btnCash.Text = "Tiền mặt (F1)";
        btnCash.UseMnemonic = false;
        btnCash.UseVisualStyleBackColor = false;
        btnCash.Click += BtnCash_Click;
        // 
        // btnQr
        // 
        btnQr.BackColor = Color.White;
        btnQr.CausesValidation = false;
        btnQr.Dock = DockStyle.Fill;
        btnQr.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnQr.FlatStyle = FlatStyle.Flat;
        btnQr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnQr.ForeColor = Color.FromArgb(15, 23, 42);
        btnQr.Location = new Point(253, 0);
        btnQr.Margin = new Padding(5, 0, 0, 0);
        btnQr.Name = "btnQr";
        btnQr.Size = new Size(244, 44);
        btnQr.TabIndex = 1;
        btnQr.Text = "QR ngân hàng (F2)";
        btnQr.UseMnemonic = false;
        btnQr.UseVisualStyleBackColor = false;
        btnQr.Click += BtnQr_Click;
        // 
        // pnlMethodDetails
        // 
        pnlMethodDetails.Controls.Add(layoutQr);
        pnlMethodDetails.Controls.Add(layoutCash);
        pnlMethodDetails.Dock = DockStyle.Fill;
        pnlMethodDetails.Location = new Point(14, 92);
        pnlMethodDetails.Margin = new Padding(0);
        pnlMethodDetails.Name = "pnlMethodDetails";
        pnlMethodDetails.Size = new Size(497, 399);
        pnlMethodDetails.TabIndex = 2;
        // 
        // layoutQr
        // 
        layoutQr.ColumnCount = 2;
        layoutQr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
        layoutQr.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutQr.Controls.Add(picQr, 0, 0);
        layoutQr.Controls.Add(lblQrBadge, 0, 1);
        layoutQr.Controls.Add(layoutQrDetails, 1, 0);
        layoutQr.Controls.Add(chkQrVerified, 0, 2);
        layoutQr.Controls.Add(lblQrStatus, 0, 3);
        layoutQr.Dock = DockStyle.Fill;
        layoutQr.Location = new Point(0, 0);
        layoutQr.Margin = new Padding(0);
        layoutQr.Name = "layoutQr";
        layoutQr.RowCount = 5;
        layoutQr.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
        layoutQr.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layoutQr.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layoutQr.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutQr.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutQr.Size = new Size(497, 399);
        layoutQr.TabIndex = 0;
        layoutQr.Visible = false;
        // 
        // picQr
        // 
        picQr.AccessibleName = "Mã QR thanh toán";
        picQr.Dock = DockStyle.Fill;
        picQr.Location = new Point(2, 1);
        picQr.Margin = new Padding(2, 1, 2, 0);
        picQr.Name = "picQr";
        picQr.Size = new Size(124, 109);
        picQr.SizeMode = PictureBoxSizeMode.Zoom;
        picQr.TabIndex = 0;
        picQr.TabStop = false;
        // 
        // lblQrBadge
        // 
        lblQrBadge.Dock = DockStyle.Fill;
        lblQrBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblQrBadge.ForeColor = Color.FromArgb(146, 64, 14);
        lblQrBadge.Location = new Point(0, 110);
        lblQrBadge.Margin = new Padding(0);
        lblQrBadge.Name = "lblQrBadge";
        lblQrBadge.Size = new Size(128, 26);
        lblQrBadge.TabIndex = 1;
        lblQrBadge.Text = "QR thanh toán mô phỏng";
        lblQrBadge.TextAlign = ContentAlignment.MiddleCenter;
        lblQrBadge.UseMnemonic = false;
        // 
        // layoutQrDetails
        // 
        layoutQrDetails.ColumnCount = 1;
        layoutQrDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutQrDetails.Controls.Add(lblQrAmountCaption, 0, 0);
        layoutQrDetails.Controls.Add(lblQrAmount, 0, 1);
        layoutQrDetails.Controls.Add(lblQrReferenceCaption, 0, 2);
        layoutQrDetails.Controls.Add(lblQrReference, 0, 3);
        layoutQrDetails.Dock = DockStyle.Fill;
        layoutQrDetails.Location = new Point(140, 5);
        layoutQrDetails.Margin = new Padding(12, 5, 0, 0);
        layoutQrDetails.Name = "layoutQrDetails";
        layoutQrDetails.RowCount = 4;
        layoutQr.SetRowSpan(layoutQrDetails, 2);
        layoutQrDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
        layoutQrDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutQrDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layoutQrDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutQrDetails.Size = new Size(357, 131);
        layoutQrDetails.TabIndex = 2;
        // 
        // lblQrAmountCaption
        // 
        lblQrAmountCaption.Dock = DockStyle.Fill;
        lblQrAmountCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblQrAmountCaption.Location = new Point(0, 0);
        lblQrAmountCaption.Margin = new Padding(0);
        lblQrAmountCaption.Name = "lblQrAmountCaption";
        lblQrAmountCaption.Size = new Size(357, 25);
        lblQrAmountCaption.TabIndex = 0;
        lblQrAmountCaption.Text = "Số tiền chuyển khoản";
        lblQrAmountCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblQrAmountCaption.UseMnemonic = false;
        // 
        // lblQrAmount
        // 
        lblQrAmount.Dock = DockStyle.Fill;
        lblQrAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblQrAmount.ForeColor = Color.FromArgb(37, 99, 235);
        lblQrAmount.Location = new Point(0, 25);
        lblQrAmount.Margin = new Padding(0);
        lblQrAmount.Name = "lblQrAmount";
        lblQrAmount.Size = new Size(357, 36);
        lblQrAmount.TabIndex = 1;
        lblQrAmount.Text = "—";
        lblQrAmount.TextAlign = ContentAlignment.MiddleLeft;
        lblQrAmount.UseMnemonic = false;
        // 
        // lblQrReferenceCaption
        // 
        lblQrReferenceCaption.Dock = DockStyle.Fill;
        lblQrReferenceCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblQrReferenceCaption.Location = new Point(0, 61);
        lblQrReferenceCaption.Margin = new Padding(0);
        lblQrReferenceCaption.Name = "lblQrReferenceCaption";
        lblQrReferenceCaption.Size = new Size(357, 26);
        lblQrReferenceCaption.TabIndex = 2;
        lblQrReferenceCaption.Text = "Nội dung chuyển khoản";
        lblQrReferenceCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblQrReferenceCaption.UseMnemonic = false;
        // 
        // lblQrReference
        // 
        lblQrReference.Dock = DockStyle.Fill;
        lblQrReference.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblQrReference.Location = new Point(0, 87);
        lblQrReference.Margin = new Padding(0);
        lblQrReference.Name = "lblQrReference";
        lblQrReference.Size = new Size(357, 44);
        lblQrReference.TabIndex = 3;
        lblQrReference.Text = "—";
        lblQrReference.TextAlign = ContentAlignment.MiddleLeft;
        lblQrReference.UseMnemonic = false;
        // 
        // chkQrVerified
        // 
        chkQrVerified.CausesValidation = false;
        layoutQr.SetColumnSpan(chkQrVerified, 2);
        chkQrVerified.Dock = DockStyle.Fill;
        chkQrVerified.Enabled = false;
        chkQrVerified.Font = new Font("Segoe UI", 9F);
        chkQrVerified.Location = new Point(0, 140);
        chkQrVerified.Margin = new Padding(0, 4, 0, 0);
        chkQrVerified.Name = "chkQrVerified";
        chkQrVerified.Size = new Size(497, 30);
        chkQrVerified.TabIndex = 3;
        chkQrVerified.Text = "Xác nhận đã nhận chuyển khoản (demo)";
        chkQrVerified.UseMnemonic = false;
        chkQrVerified.UseVisualStyleBackColor = true;
        chkQrVerified.CheckedChanged += ChkQrVerified_CheckedChanged;
        // 
        // lblQrStatus
        // 
        layoutQr.SetColumnSpan(lblQrStatus, 2);
        lblQrStatus.Dock = DockStyle.Fill;
        lblQrStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblQrStatus.ForeColor = Color.FromArgb(146, 64, 14);
        lblQrStatus.Location = new Point(0, 170);
        lblQrStatus.Margin = new Padding(0);
        lblQrStatus.Name = "lblQrStatus";
        lblQrStatus.Size = new Size(497, 30);
        lblQrStatus.TabIndex = 4;
        lblQrStatus.Text = "Chờ nhân viên xác nhận";
        lblQrStatus.TextAlign = ContentAlignment.MiddleLeft;
        lblQrStatus.UseMnemonic = false;
        // 
        // layoutCash
        // 
        layoutCash.ColumnCount = 1;
        layoutCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutCash.Controls.Add(lblCash, 0, 0);
        layoutCash.Controls.Add(txtCash, 0, 1);
        layoutCash.Controls.Add(lblDenominations, 0, 2);
        layoutCash.Controls.Add(layoutDenominations, 0, 3);
        layoutCash.Controls.Add(layoutCashBalance, 0, 5);
        layoutCash.Dock = DockStyle.Fill;
        layoutCash.Location = new Point(0, 0);
        layoutCash.Margin = new Padding(0);
        layoutCash.Name = "layoutCash";
        layoutCash.RowCount = 7;
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
        layoutCash.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCash.Size = new Size(497, 399);
        layoutCash.TabIndex = 0;
        // 
        // lblCash
        // 
        lblCash.Dock = DockStyle.Fill;
        lblCash.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCash.Location = new Point(0, 0);
        lblCash.Margin = new Padding(0);
        lblCash.Name = "lblCash";
        lblCash.Size = new Size(497, 28);
        lblCash.TabIndex = 0;
        lblCash.Text = "Tiền khách đưa (VNĐ)";
        lblCash.TextAlign = ContentAlignment.MiddleLeft;
        lblCash.UseMnemonic = false;
        // 
        // txtCash
        // 
        txtCash.AccessibleName = "Tiền khách đưa (VNĐ)";
        txtCash.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtCash.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        txtCash.ForeColor = Color.FromArgb(15, 23, 42);
        txtCash.Location = new Point(0, 28);
        txtCash.Margin = new Padding(0);
        txtCash.MaxLength = 25;
        txtCash.Name = "txtCash";
        txtCash.PlaceholderText = "0";
        txtCash.Size = new Size(497, 52);
        txtCash.TabIndex = 1;
        txtCash.TextAlign = HorizontalAlignment.Right;
        txtCash.TextChanged += TxtCash_TextChanged;
        txtCash.Leave += TxtCash_Leave;
        // 
        // lblDenominations
        // 
        lblDenominations.Dock = DockStyle.Fill;
        lblDenominations.ForeColor = Color.FromArgb(100, 116, 139);
        lblDenominations.Location = new Point(0, 76);
        lblDenominations.Margin = new Padding(0);
        lblDenominations.Name = "lblDenominations";
        lblDenominations.Size = new Size(497, 27);
        lblDenominations.TabIndex = 2;
        lblDenominations.Text = "Chọn nhanh mệnh giá";
        lblDenominations.TextAlign = ContentAlignment.MiddleLeft;
        lblDenominations.UseMnemonic = false;
        // 
        // layoutDenominations
        // 
        layoutDenominations.ColumnCount = 4;
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDenominations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        layoutDenominations.Controls.Add(btnCash100, 0, 0);
        layoutDenominations.Controls.Add(btnCash200, 1, 0);
        layoutDenominations.Controls.Add(btnCash500, 2, 0);
        layoutDenominations.Controls.Add(btnExactCash, 3, 0);
        layoutDenominations.Dock = DockStyle.Fill;
        layoutDenominations.Location = new Point(0, 103);
        layoutDenominations.Margin = new Padding(0);
        layoutDenominations.Name = "layoutDenominations";
        layoutDenominations.RowCount = 1;
        layoutDenominations.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutDenominations.Size = new Size(497, 38);
        layoutDenominations.TabIndex = 3;
        // 
        // btnCash100
        // 
        btnCash100.BackColor = Color.White;
        btnCash100.CausesValidation = false;
        btnCash100.Dock = DockStyle.Fill;
        btnCash100.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnCash100.FlatStyle = FlatStyle.Flat;
        btnCash100.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCash100.ForeColor = Color.FromArgb(15, 23, 42);
        btnCash100.Location = new Point(0, 0);
        btnCash100.Margin = new Padding(0, 0, 5, 0);
        btnCash100.Name = "btnCash100";
        btnCash100.Size = new Size(119, 38);
        btnCash100.TabIndex = 0;
        btnCash100.Text = "100.000 đ";
        btnCash100.UseMnemonic = false;
        btnCash100.UseVisualStyleBackColor = false;
        btnCash100.Click += BtnCash100_Click;
        // 
        // btnCash200
        // 
        btnCash200.BackColor = Color.White;
        btnCash200.CausesValidation = false;
        btnCash200.Dock = DockStyle.Fill;
        btnCash200.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnCash200.FlatStyle = FlatStyle.Flat;
        btnCash200.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCash200.ForeColor = Color.FromArgb(15, 23, 42);
        btnCash200.Location = new Point(124, 0);
        btnCash200.Margin = new Padding(0, 0, 5, 0);
        btnCash200.Name = "btnCash200";
        btnCash200.Size = new Size(119, 38);
        btnCash200.TabIndex = 1;
        btnCash200.Text = "200.000 đ";
        btnCash200.UseMnemonic = false;
        btnCash200.UseVisualStyleBackColor = false;
        btnCash200.Click += BtnCash200_Click;
        // 
        // btnCash500
        // 
        btnCash500.BackColor = Color.White;
        btnCash500.CausesValidation = false;
        btnCash500.Dock = DockStyle.Fill;
        btnCash500.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnCash500.FlatStyle = FlatStyle.Flat;
        btnCash500.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCash500.ForeColor = Color.FromArgb(15, 23, 42);
        btnCash500.Location = new Point(248, 0);
        btnCash500.Margin = new Padding(0, 0, 5, 0);
        btnCash500.Name = "btnCash500";
        btnCash500.Size = new Size(119, 38);
        btnCash500.TabIndex = 2;
        btnCash500.Text = "500.000 đ";
        btnCash500.UseMnemonic = false;
        btnCash500.UseVisualStyleBackColor = false;
        btnCash500.Click += BtnCash500_Click;
        // 
        // btnExactCash
        // 
        btnExactCash.BackColor = Color.White;
        btnExactCash.CausesValidation = false;
        btnExactCash.Dock = DockStyle.Fill;
        btnExactCash.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnExactCash.FlatStyle = FlatStyle.Flat;
        btnExactCash.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnExactCash.ForeColor = Color.FromArgb(15, 23, 42);
        btnExactCash.Location = new Point(372, 0);
        btnExactCash.Margin = new Padding(0);
        btnExactCash.Name = "btnExactCash";
        btnExactCash.Size = new Size(125, 38);
        btnExactCash.TabIndex = 3;
        btnExactCash.Text = "Đưa đủ";
        btnExactCash.UseMnemonic = false;
        btnExactCash.UseVisualStyleBackColor = false;
        btnExactCash.Click += BtnExactCash_Click;
        // 
        // layoutCashBalance
        // 
        layoutCashBalance.BackColor = Color.FromArgb(255, 251, 235);
        layoutCashBalance.ColumnCount = 2;
        layoutCashBalance.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54F));
        layoutCashBalance.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46F));
        layoutCashBalance.Controls.Add(lblCashStatus, 0, 0);
        layoutCashBalance.Controls.Add(lblCashBalance, 1, 0);
        layoutCashBalance.Dock = DockStyle.Fill;
        layoutCashBalance.Location = new Point(0, 155);
        layoutCashBalance.Margin = new Padding(0);
        layoutCashBalance.Name = "layoutCashBalance";
        layoutCashBalance.Padding = new Padding(12, 5, 12, 8);
        layoutCashBalance.RowCount = 1;
        layoutCashBalance.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutCashBalance.Size = new Size(497, 78);
        layoutCashBalance.TabIndex = 4;
        // 
        // lblCashStatus
        // 
        lblCashStatus.Dock = DockStyle.Fill;
        lblCashStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCashStatus.Location = new Point(12, 5);
        lblCashStatus.Margin = new Padding(0);
        lblCashStatus.Name = "lblCashStatus";
        lblCashStatus.Size = new Size(255, 65);
        lblCashStatus.TabIndex = 0;
        lblCashStatus.Text = "Chưa có đơn hàng";
        lblCashStatus.TextAlign = ContentAlignment.MiddleLeft;
        lblCashStatus.UseMnemonic = false;
        // 
        // lblCashBalance
        // 
        lblCashBalance.Dock = DockStyle.Fill;
        lblCashBalance.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblCashBalance.ForeColor = Color.FromArgb(146, 64, 14);
        lblCashBalance.Location = new Point(267, 5);
        lblCashBalance.Margin = new Padding(0);
        lblCashBalance.Name = "lblCashBalance";
        lblCashBalance.Size = new Size(218, 65);
        lblCashBalance.TabIndex = 1;
        lblCashBalance.Text = "—";
        lblCashBalance.TextAlign = ContentAlignment.MiddleRight;
        lblCashBalance.UseMnemonic = false;
        // 
        // lblPaymentNotice
        // 
        lblPaymentNotice.AutoSize = true;
        lblPaymentNotice.BackColor = Color.FromArgb(255, 251, 235);
        lblPaymentNotice.Dock = DockStyle.Fill;
        lblPaymentNotice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPaymentNotice.ForeColor = Color.FromArgb(146, 64, 14);
        lblPaymentNotice.Location = new Point(20, 623);
        lblPaymentNotice.Margin = new Padding(0, 6, 0, 0);
        lblPaymentNotice.MinimumSize = new Size(0, 28);
        lblPaymentNotice.Name = "lblPaymentNotice";
        lblPaymentNotice.Padding = new Padding(9, 2, 9, 2);
        lblPaymentNotice.Size = new Size(1096, 28);
        lblPaymentNotice.TabIndex = 3;
        lblPaymentNotice.Text = "Giao dịch mô phỏng";
        lblPaymentNotice.TextAlign = ContentAlignment.MiddleLeft;
        lblPaymentNotice.UseMnemonic = false;
        // 
        // layoutActions
        // 
        layoutActions.ColumnCount = 2;
        layoutActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutActions.Controls.Add(btnBack, 0, 0);
        layoutActions.Controls.Add(btnConfirm, 1, 0);
        layoutActions.Dock = DockStyle.Fill;
        layoutActions.Location = new Point(20, 658);
        layoutActions.Margin = new Padding(0, 7, 0, 0);
        layoutActions.Name = "layoutActions";
        layoutActions.RowCount = 1;
        layoutActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutActions.Size = new Size(1096, 50);
        layoutActions.TabIndex = 4;
        // 
        // btnBack
        // 
        btnBack.Anchor = AnchorStyles.Left;
        btnBack.BackColor = Color.White;
        btnBack.CausesValidation = false;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnBack.ForeColor = Color.FromArgb(15, 23, 42);
        btnBack.Location = new Point(0, 3);
        btnBack.Margin = new Padding(0);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(222, 43);
        btnBack.TabIndex = 0;
        btnBack.Text = "‹ Quay lại chọn bắp nước";
        btnBack.UseMnemonic = false;
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += BtnBack_Click;
        // 
        // btnConfirm
        // 
        btnConfirm.Anchor = AnchorStyles.Right;
        btnConfirm.BackColor = Color.FromArgb(226, 232, 240);
        btnConfirm.CausesValidation = false;
        btnConfirm.Enabled = false;
        btnConfirm.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
        btnConfirm.FlatStyle = FlatStyle.Flat;
        btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnConfirm.ForeColor = Color.FromArgb(100, 116, 139);
        btnConfirm.Location = new Point(806, 3);
        btnConfirm.Margin = new Padding(0);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Size = new Size(290, 43);
        btnConfirm.TabIndex = 1;
        btnConfirm.Text = "XÁC NHẬN THANH TOÁN (F12)";
        btnConfirm.UseMnemonic = false;
        btnConfirm.UseVisualStyleBackColor = false;
        btnConfirm.Click += BtnConfirm_Click;
        // 
        // memberErrors
        // 
        memberErrors.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        memberErrors.ContainerControl = this;
        // 
        // PaymentView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoValidate = AutoValidate.Disable;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(layoutPage);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "PaymentView";
        Size = new Size(1136, 722);
        layoutPage.ResumeLayout(false);
        layoutPage.PerformLayout();
        layoutHeading.ResumeLayout(false);
        layoutWorkArea.ResumeLayout(false);
        layoutLeft.ResumeLayout(false);
        pnlMember.ResumeLayout(false);
        layoutMember.ResumeLayout(false);
        layoutPhone.ResumeLayout(false);
        layoutPhone.PerformLayout();
        pnlMemberMessage.ResumeLayout(false);
        layoutMemberResult.ResumeLayout(false);
        pnlOrder.ResumeLayout(false);
        layoutOrder.ResumeLayout(false);
        ((ISupportInitialize)gridOrder).EndInit();
        layoutTotal.ResumeLayout(false);
        pnlPayment.ResumeLayout(false);
        layoutPayment.ResumeLayout(false);
        layoutMethods.ResumeLayout(false);
        pnlMethodDetails.ResumeLayout(false);
        layoutQr.ResumeLayout(false);
        ((ISupportInitialize)picQr).EndInit();
        layoutQrDetails.ResumeLayout(false);
        layoutCash.ResumeLayout(false);
        layoutCash.PerformLayout();
        layoutDenominations.ResumeLayout(false);
        layoutCashBalance.ResumeLayout(false);
        layoutActions.ResumeLayout(false);
        ((ISupportInitialize)orderBindingSource).EndInit();
        ((ISupportInitialize)memberErrors).EndInit();
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutPage;
    private Cinema.WinForms.Controls.TicketSalesProgressBar progressBar;
    private TableLayoutPanel layoutHeading;
    private Label lblTitle;
    private Label lblCountdown;
    private TableLayoutPanel layoutWorkArea;
    private TableLayoutPanel layoutLeft;
    private Panel pnlMember;
    private TableLayoutPanel layoutMember;
    private Label lblMemberTitle;
    private TableLayoutPanel layoutPhone;
    private Label lblPhone;
    private TextBox txtPhone;
    private Button btnFindMember;
    private Panel pnlMemberMessage;
    private Label lblMemberStatus;
    private TableLayoutPanel layoutMemberResult;
    private Label lblMemberName;
    private Label lblMemberDetails;
    private Panel pnlOrder;
    private TableLayoutPanel layoutOrder;
    private Label lblOrderTitle;
    private Label lblMovie;
    private Label lblShowtime;
    private Label lblSeats;
    private DataGridView gridOrder;
    private DataGridViewTextBoxColumn colDescription;
    private DataGridViewTextBoxColumn colQuantity;
    private DataGridViewTextBoxColumn colUnitPrice;
    private DataGridViewTextBoxColumn colAmount;
    private BindingSource orderBindingSource;
    private TableLayoutPanel layoutTotal;
    private Label lblTotalCaption;
    private Label lblTotal;
    private Panel pnlPayment;
    private TableLayoutPanel layoutPayment;
    private Label lblMethodTitle;
    private TableLayoutPanel layoutMethods;
    private Button btnCash;
    private Button btnQr;
    private Panel pnlMethodDetails;
    private TableLayoutPanel layoutCash;
    private Label lblCash;
    private TextBox txtCash;
    private Label lblDenominations;
    private TableLayoutPanel layoutDenominations;
    private Button btnCash100;
    private Button btnCash200;
    private Button btnCash500;
    private Button btnExactCash;
    private TableLayoutPanel layoutCashBalance;
    private Label lblCashStatus;
    private Label lblCashBalance;
    private TableLayoutPanel layoutQr;
    private PictureBox picQr;
    private Label lblQrBadge;
    private TableLayoutPanel layoutQrDetails;
    private Label lblQrAmountCaption;
    private Label lblQrAmount;
    private Label lblQrReferenceCaption;
    private Label lblQrReference;
    private CheckBox chkQrVerified;
    private Label lblQrStatus;
    private Label lblPaymentNotice;
    private TableLayoutPanel layoutActions;
    private Button btnBack;
    private Button btnConfirm;
    private ErrorProvider memberErrors;
}

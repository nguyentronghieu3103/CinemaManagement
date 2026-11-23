namespace Cinema.WinForms.Features.Members;

partial class MemberRegistrationView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        lnkBack = new LinkLabel();
        lblTitle = new Label();
        pnlRegistrationCard = new Panel();
        layoutRegistrationCard = new TableLayoutPanel();
        layoutFields = new TableLayoutPanel();
        layoutFullName = new TableLayoutPanel();
        flowFullNameCaption = new FlowLayoutPanel();
        lblFullName = new Label();
        lblFullNameSuffix = new Label();
        pnlFullNameFrame = new Panel();
        layoutFullNameControl = new TableLayoutPanel();
        txtFullName = new TextBox();
        layoutPhone = new TableLayoutPanel();
        flowPhoneCaption = new FlowLayoutPanel();
        lblPhone = new Label();
        lblPhoneSuffix = new Label();
        pnlPhoneFrame = new Panel();
        layoutPhoneControl = new TableLayoutPanel();
        txtPhone = new TextBox();
        layoutEmail = new TableLayoutPanel();
        flowEmailCaption = new FlowLayoutPanel();
        lblEmail = new Label();
        lblEmailSuffix = new Label();
        pnlEmailFrame = new Panel();
        layoutEmailControl = new TableLayoutPanel();
        txtEmail = new TextBox();
        layoutBirthDate = new TableLayoutPanel();
        flowBirthDateCaption = new FlowLayoutPanel();
        lblBirthDate = new Label();
        lblBirthDateSuffix = new Label();
        pnlBirthDateFrame = new Panel();
        layoutBirthDateControl = new TableLayoutPanel();
        dtpBirthDate = new DateTimePicker();
        layoutGender = new TableLayoutPanel();
        flowGenderCaption = new FlowLayoutPanel();
        lblGender = new Label();
        lblGenderSuffix = new Label();
        pnlGenderFrame = new Panel();
        layoutGenderControl = new TableLayoutPanel();
        cmbGender = new ComboBox();
        layoutInitialTier = new TableLayoutPanel();
        lblInitialTier = new Label();
        lblInitialPoints = new Label();
        chkConsent = new CheckBox();
        layoutFooter = new TableLayoutPanel();
        btnCancel = new Button();
        btnSave = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        pnlRegistrationCard.SuspendLayout();
        layoutRegistrationCard.SuspendLayout();
        layoutFields.SuspendLayout();
        layoutGender.SuspendLayout();
        flowGenderCaption.SuspendLayout();
        pnlGenderFrame.SuspendLayout();
        layoutGenderControl.SuspendLayout();
        layoutFullName.SuspendLayout();
        flowFullNameCaption.SuspendLayout();
        pnlFullNameFrame.SuspendLayout();
        layoutFullNameControl.SuspendLayout();
        layoutPhone.SuspendLayout();
        flowPhoneCaption.SuspendLayout();
        pnlPhoneFrame.SuspendLayout();
        layoutPhoneControl.SuspendLayout();
        layoutEmail.SuspendLayout();
        flowEmailCaption.SuspendLayout();
        pnlEmailFrame.SuspendLayout();
        layoutEmailControl.SuspendLayout();
        layoutBirthDate.SuspendLayout();
        flowBirthDateCaption.SuspendLayout();
        pnlBirthDateFrame.SuspendLayout();
        layoutBirthDateControl.SuspendLayout();
        layoutInitialTier.SuspendLayout();
        layoutFooter.SuspendLayout();
        SuspendLayout();
        //
        // pnlViewport
        //
        pnlViewport.Margin = new Padding(0);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(850, 673);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Controls.Add(layoutPage);
        //
        // layoutPage
        //
        layoutPage.Margin = new Padding(0);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.Padding = new Padding(24, 20, 18, 18);
        layoutPage.ColumnCount = 2;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 800F));
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.RowCount = 4;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 517F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.MinimumSize = new Size(850, 673);
        layoutPage.Name = "layoutPage";
        layoutPage.Controls.Add(lnkBack, 0, 0);
        layoutPage.Controls.Add(lblTitle, 0, 1);
        layoutPage.Controls.Add(pnlRegistrationCard, 0, 2);
        //
        // lnkBack
        //
        lnkBack.Margin = new Padding(0);
        lnkBack.ForeColor = Color.FromArgb(37, 99, 235);
        lnkBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lnkBack.Anchor = AnchorStyles.Left;
        lnkBack.AutoSize = true;
        lnkBack.LinkColor = Color.FromArgb(37, 99, 235);
        lnkBack.LinkBehavior = LinkBehavior.HoverUnderline;
        lnkBack.Text = "‹  Quay lại danh sách";
        lnkBack.TabStop = true;
        lnkBack.LinkClicked += ReturnToList_Click;
        lnkBack.Name = "lnkBack";
        //
        // lblTitle
        //
        lblTitle.Margin = new Padding(0);
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Padding = new Padding(0, 0, 0, 12);
        lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitle.Text = "Đăng ký thành viên mới";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        lblTitle.Name = "lblTitle";
        //
        // pnlRegistrationCard
        //
        pnlRegistrationCard.Margin = new Padding(0);
        pnlRegistrationCard.Dock = DockStyle.Fill;
        pnlRegistrationCard.Padding = new Padding(1);
        pnlRegistrationCard.BackColor = Color.FromArgb(226, 232, 240);
        pnlRegistrationCard.Name = "pnlRegistrationCard";
        pnlRegistrationCard.Controls.Add(layoutRegistrationCard);
        //
        // layoutRegistrationCard
        //
        layoutRegistrationCard.Margin = new Padding(0);
        layoutRegistrationCard.Dock = DockStyle.Fill;
        layoutRegistrationCard.Padding = new Padding(21, 19, 21, 18);
        layoutRegistrationCard.BackColor = Color.White;
        layoutRegistrationCard.ColumnCount = 1;
        layoutRegistrationCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutRegistrationCard.RowCount = 4;
        layoutRegistrationCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 291F));
        layoutRegistrationCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutRegistrationCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
        layoutRegistrationCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRegistrationCard.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutRegistrationCard.Name = "layoutRegistrationCard";
        layoutRegistrationCard.Controls.Add(layoutFields, 0, 0);
        layoutRegistrationCard.Controls.Add(layoutInitialTier, 0, 1);
        layoutRegistrationCard.Controls.Add(chkConsent, 0, 2);
        layoutRegistrationCard.Controls.Add(layoutFooter, 0, 3);
        //
        // layoutFields
        //
        layoutFields.Margin = new Padding(0);
        layoutFields.Dock = DockStyle.Fill;
        layoutFields.ColumnCount = 3;
        layoutFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutFields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
        layoutFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutFields.RowCount = 3;
        layoutFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
        layoutFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
        layoutFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
        layoutFields.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFields.Name = "layoutFields";
        layoutFields.Controls.Add(layoutFullName, 0, 0);
        layoutFields.Controls.Add(layoutPhone, 2, 0);
        layoutFields.Controls.Add(layoutEmail, 0, 1);
        layoutFields.Controls.Add(layoutBirthDate, 2, 1);
        layoutFields.Controls.Add(layoutGender, 0, 2);
        //
        // layoutFullName
        //
        layoutFullName.Margin = new Padding(0);
        layoutFullName.Dock = DockStyle.Fill;
        layoutFullName.ColumnCount = 1;
        layoutFullName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFullName.RowCount = 3;
        layoutFullName.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutFullName.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutFullName.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFullName.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFullName.Name = "layoutFullName";
        layoutFullName.Controls.Add(flowFullNameCaption, 0, 0);
        layoutFullName.Controls.Add(pnlFullNameFrame, 0, 1);
        //
        // flowFullNameCaption
        //
        flowFullNameCaption.Margin = new Padding(0);
        flowFullNameCaption.Dock = DockStyle.Fill;
        flowFullNameCaption.Padding = new Padding(0, 5, 0, 0);
        flowFullNameCaption.WrapContents = false;
        flowFullNameCaption.Name = "flowFullNameCaption";
        flowFullNameCaption.Controls.Add(lblFullName);
        flowFullNameCaption.Controls.Add(lblFullNameSuffix);
        //
        // lblFullName
        //
        lblFullName.Margin = new Padding(0);
        lblFullName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblFullName.Text = "Họ và tên";
        lblFullName.TextAlign = ContentAlignment.MiddleLeft;
        lblFullName.UseMnemonic = false;
        lblFullName.AutoSize = true;
        lblFullName.Name = "lblFullName";
        //
        // lblFullNameSuffix
        //
        lblFullNameSuffix.Margin = new Padding(4, 0, 0, 0);
        lblFullNameSuffix.ForeColor = Color.FromArgb(185, 28, 28);
        lblFullNameSuffix.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblFullNameSuffix.Text = "*";
        lblFullNameSuffix.TextAlign = ContentAlignment.MiddleLeft;
        lblFullNameSuffix.UseMnemonic = false;
        lblFullNameSuffix.AutoSize = true;
        lblFullNameSuffix.Name = "lblFullNameSuffix";
        //
        // pnlFullNameFrame
        //
        pnlFullNameFrame.Margin = new Padding(0);
        pnlFullNameFrame.Dock = DockStyle.Fill;
        pnlFullNameFrame.Padding = new Padding(1);
        pnlFullNameFrame.BackColor = Color.FromArgb(226, 232, 240);
        pnlFullNameFrame.Name = "pnlFullNameFrame";
        pnlFullNameFrame.Controls.Add(layoutFullNameControl);
        //
        // layoutFullNameControl
        //
        layoutFullNameControl.Margin = new Padding(0);
        layoutFullNameControl.Dock = DockStyle.Fill;
        layoutFullNameControl.Padding = new Padding(11, 0, 9, 0);
        layoutFullNameControl.BackColor = Color.White;
        layoutFullNameControl.ColumnCount = 1;
        layoutFullNameControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFullNameControl.RowCount = 1;
        layoutFullNameControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFullNameControl.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFullNameControl.Name = "layoutFullNameControl";
        layoutFullNameControl.Controls.Add(txtFullName, 0, 0);
        //
        // txtFullName
        //
        txtFullName.Margin = new Padding(0);
        txtFullName.BackColor = Color.White;
        txtFullName.ForeColor = Color.FromArgb(15, 23, 42);
        txtFullName.AccessibleName = "Họ và tên, bắt buộc";
        txtFullName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtFullName.BorderStyle = BorderStyle.None;
        txtFullName.PlaceholderText = "Nhập họ và tên";
        txtFullName.Enter += TextField_Enter;
        txtFullName.Leave += TextField_Leave;
        txtFullName.Name = "txtFullName";
        //
        // layoutPhone
        //
        layoutPhone.Margin = new Padding(0);
        layoutPhone.Dock = DockStyle.Fill;
        layoutPhone.ColumnCount = 1;
        layoutPhone.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPhone.RowCount = 3;
        layoutPhone.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutPhone.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutPhone.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPhone.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPhone.Name = "layoutPhone";
        layoutPhone.Controls.Add(flowPhoneCaption, 0, 0);
        layoutPhone.Controls.Add(pnlPhoneFrame, 0, 1);
        //
        // flowPhoneCaption
        //
        flowPhoneCaption.Margin = new Padding(0);
        flowPhoneCaption.Dock = DockStyle.Fill;
        flowPhoneCaption.Padding = new Padding(0, 5, 0, 0);
        flowPhoneCaption.WrapContents = false;
        flowPhoneCaption.Name = "flowPhoneCaption";
        flowPhoneCaption.Controls.Add(lblPhone);
        flowPhoneCaption.Controls.Add(lblPhoneSuffix);
        //
        // lblPhone
        //
        lblPhone.Margin = new Padding(0);
        lblPhone.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblPhone.Text = "Số điện thoại";
        lblPhone.TextAlign = ContentAlignment.MiddleLeft;
        lblPhone.UseMnemonic = false;
        lblPhone.AutoSize = true;
        lblPhone.Name = "lblPhone";
        //
        // lblPhoneSuffix
        //
        lblPhoneSuffix.Margin = new Padding(4, 0, 0, 0);
        lblPhoneSuffix.ForeColor = Color.FromArgb(185, 28, 28);
        lblPhoneSuffix.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblPhoneSuffix.Text = "*";
        lblPhoneSuffix.TextAlign = ContentAlignment.MiddleLeft;
        lblPhoneSuffix.UseMnemonic = false;
        lblPhoneSuffix.AutoSize = true;
        lblPhoneSuffix.Name = "lblPhoneSuffix";
        //
        // pnlPhoneFrame
        //
        pnlPhoneFrame.Margin = new Padding(0);
        pnlPhoneFrame.Dock = DockStyle.Fill;
        pnlPhoneFrame.Padding = new Padding(1);
        pnlPhoneFrame.BackColor = Color.FromArgb(226, 232, 240);
        pnlPhoneFrame.Name = "pnlPhoneFrame";
        pnlPhoneFrame.Controls.Add(layoutPhoneControl);
        //
        // layoutPhoneControl
        //
        layoutPhoneControl.Margin = new Padding(0);
        layoutPhoneControl.Dock = DockStyle.Fill;
        layoutPhoneControl.Padding = new Padding(11, 0, 9, 0);
        layoutPhoneControl.BackColor = Color.White;
        layoutPhoneControl.ColumnCount = 1;
        layoutPhoneControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPhoneControl.RowCount = 1;
        layoutPhoneControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPhoneControl.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPhoneControl.Name = "layoutPhoneControl";
        layoutPhoneControl.Controls.Add(txtPhone, 0, 0);
        //
        // txtPhone
        //
        txtPhone.Margin = new Padding(0);
        txtPhone.BackColor = Color.White;
        txtPhone.ForeColor = Color.FromArgb(15, 23, 42);
        txtPhone.AccessibleName = "Số điện thoại, bắt buộc";
        txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPhone.BorderStyle = BorderStyle.None;
        txtPhone.PlaceholderText = "Nhập số điện thoại";
        txtPhone.Enter += TextField_Enter;
        txtPhone.Leave += TextField_Leave;
        txtPhone.Name = "txtPhone";
        //
        // layoutEmail
        //
        layoutEmail.Margin = new Padding(0);
        layoutEmail.Dock = DockStyle.Fill;
        layoutEmail.ColumnCount = 1;
        layoutEmail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEmail.RowCount = 3;
        layoutEmail.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutEmail.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutEmail.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutEmail.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEmail.Name = "layoutEmail";
        layoutEmail.Controls.Add(flowEmailCaption, 0, 0);
        layoutEmail.Controls.Add(pnlEmailFrame, 0, 1);
        //
        // flowEmailCaption
        //
        flowEmailCaption.Margin = new Padding(0);
        flowEmailCaption.Dock = DockStyle.Fill;
        flowEmailCaption.Padding = new Padding(0, 5, 0, 0);
        flowEmailCaption.WrapContents = false;
        flowEmailCaption.Name = "flowEmailCaption";
        flowEmailCaption.Controls.Add(lblEmail);
        flowEmailCaption.Controls.Add(lblEmailSuffix);
        //
        // lblEmail
        //
        lblEmail.Margin = new Padding(0);
        lblEmail.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblEmail.Text = "Email nhận vé";
        lblEmail.TextAlign = ContentAlignment.MiddleLeft;
        lblEmail.UseMnemonic = false;
        lblEmail.AutoSize = true;
        lblEmail.Name = "lblEmail";
        //
        // lblEmailSuffix
        //
        lblEmailSuffix.Margin = new Padding(4, 0, 0, 0);
        lblEmailSuffix.ForeColor = Color.FromArgb(100, 116, 139);
        lblEmailSuffix.Font = new Font("Segoe UI", 10.5F);
        lblEmailSuffix.Text = "(tùy chọn)";
        lblEmailSuffix.TextAlign = ContentAlignment.MiddleLeft;
        lblEmailSuffix.UseMnemonic = false;
        lblEmailSuffix.AutoSize = true;
        lblEmailSuffix.Name = "lblEmailSuffix";
        //
        // pnlEmailFrame
        //
        pnlEmailFrame.Margin = new Padding(0);
        pnlEmailFrame.Dock = DockStyle.Fill;
        pnlEmailFrame.Padding = new Padding(1);
        pnlEmailFrame.BackColor = Color.FromArgb(226, 232, 240);
        pnlEmailFrame.Name = "pnlEmailFrame";
        pnlEmailFrame.Controls.Add(layoutEmailControl);
        //
        // layoutEmailControl
        //
        layoutEmailControl.Margin = new Padding(0);
        layoutEmailControl.Dock = DockStyle.Fill;
        layoutEmailControl.Padding = new Padding(11, 0, 9, 0);
        layoutEmailControl.BackColor = Color.White;
        layoutEmailControl.ColumnCount = 1;
        layoutEmailControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEmailControl.RowCount = 1;
        layoutEmailControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutEmailControl.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEmailControl.Name = "layoutEmailControl";
        layoutEmailControl.Controls.Add(txtEmail, 0, 0);
        //
        // txtEmail
        //
        txtEmail.Margin = new Padding(0);
        txtEmail.BackColor = Color.White;
        txtEmail.ForeColor = Color.FromArgb(15, 23, 42);
        txtEmail.AccessibleName = "Email nhận vé, tùy chọn";
        txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtEmail.BorderStyle = BorderStyle.None;
        txtEmail.PlaceholderText = "Nhập email";
        txtEmail.Enter += TextField_Enter;
        txtEmail.Leave += TextField_Leave;
        txtEmail.Name = "txtEmail";
        //
        // layoutBirthDate
        //
        layoutBirthDate.Margin = new Padding(0);
        layoutBirthDate.Dock = DockStyle.Fill;
        layoutBirthDate.ColumnCount = 1;
        layoutBirthDate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBirthDate.RowCount = 3;
        layoutBirthDate.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutBirthDate.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutBirthDate.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBirthDate.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBirthDate.Name = "layoutBirthDate";
        layoutBirthDate.Controls.Add(flowBirthDateCaption, 0, 0);
        layoutBirthDate.Controls.Add(pnlBirthDateFrame, 0, 1);
        //
        // flowBirthDateCaption
        //
        flowBirthDateCaption.Margin = new Padding(0);
        flowBirthDateCaption.Dock = DockStyle.Fill;
        flowBirthDateCaption.Padding = new Padding(0, 5, 0, 0);
        flowBirthDateCaption.WrapContents = false;
        flowBirthDateCaption.Name = "flowBirthDateCaption";
        flowBirthDateCaption.Controls.Add(lblBirthDate);
        flowBirthDateCaption.Controls.Add(lblBirthDateSuffix);
        //
        // lblBirthDate
        //
        lblBirthDate.Margin = new Padding(0);
        lblBirthDate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblBirthDate.Text = "Ngày sinh";
        lblBirthDate.TextAlign = ContentAlignment.MiddleLeft;
        lblBirthDate.UseMnemonic = false;
        lblBirthDate.AutoSize = true;
        lblBirthDate.Name = "lblBirthDate";
        //
        // lblBirthDateSuffix
        //
        lblBirthDateSuffix.Margin = new Padding(4, 0, 0, 0);
        lblBirthDateSuffix.ForeColor = Color.FromArgb(100, 116, 139);
        lblBirthDateSuffix.Font = new Font("Segoe UI", 10.5F);
        lblBirthDateSuffix.Text = "(tùy chọn)";
        lblBirthDateSuffix.TextAlign = ContentAlignment.MiddleLeft;
        lblBirthDateSuffix.UseMnemonic = false;
        lblBirthDateSuffix.AutoSize = true;
        lblBirthDateSuffix.Name = "lblBirthDateSuffix";
        //
        // pnlBirthDateFrame
        //
        pnlBirthDateFrame.Margin = new Padding(0);
        pnlBirthDateFrame.Dock = DockStyle.Fill;
        pnlBirthDateFrame.Padding = new Padding(1);
        pnlBirthDateFrame.BackColor = Color.FromArgb(226, 232, 240);
        pnlBirthDateFrame.Name = "pnlBirthDateFrame";
        pnlBirthDateFrame.Controls.Add(layoutBirthDateControl);
        //
        // layoutBirthDateControl
        //
        layoutBirthDateControl.Margin = new Padding(0);
        layoutBirthDateControl.Dock = DockStyle.Fill;
        layoutBirthDateControl.Padding = new Padding(11, 0, 9, 0);
        layoutBirthDateControl.BackColor = Color.White;
        layoutBirthDateControl.ColumnCount = 1;
        layoutBirthDateControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutBirthDateControl.RowCount = 1;
        layoutBirthDateControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutBirthDateControl.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutBirthDateControl.Name = "layoutBirthDateControl";
        layoutBirthDateControl.Controls.Add(dtpBirthDate, 0, 0);
        //
        // dtpBirthDate
        //
        dtpBirthDate.Margin = new Padding(0);
        dtpBirthDate.Font = new Font("Segoe UI", 10F);
        dtpBirthDate.AccessibleName = "Ngày sinh, tùy chọn";
        dtpBirthDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        dtpBirthDate.CustomFormat = "'dd/mm/yyyy'";
        dtpBirthDate.Format = DateTimePickerFormat.Custom;
        dtpBirthDate.ShowCheckBox = true;
        dtpBirthDate.Checked = false;
        dtpBirthDate.ValueChanged += DtpBirthDate_ValueChanged;
        dtpBirthDate.Name = "dtpBirthDate";
        //
        // layoutGender
        //
        layoutGender.Margin = new Padding(0);
        layoutGender.Dock = DockStyle.Fill;
        layoutGender.ColumnCount = 1;
        layoutGender.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutGender.RowCount = 3;
        layoutGender.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutGender.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        layoutGender.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutGender.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutGender.Name = "layoutGender";
        layoutGender.Controls.Add(flowGenderCaption, 0, 0);
        layoutGender.Controls.Add(pnlGenderFrame, 0, 1);
        //
        // flowGenderCaption
        //
        flowGenderCaption.Margin = new Padding(0);
        flowGenderCaption.Dock = DockStyle.Fill;
        flowGenderCaption.Padding = new Padding(0, 5, 0, 0);
        flowGenderCaption.WrapContents = false;
        flowGenderCaption.Name = "flowGenderCaption";
        flowGenderCaption.Controls.Add(lblGender);
        flowGenderCaption.Controls.Add(lblGenderSuffix);
        //
        // lblGender
        //
        lblGender.Margin = new Padding(0);
        lblGender.AutoSize = true;
        lblGender.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblGender.Name = "lblGender";
        lblGender.Text = "Giới tính";
        //
        // lblGenderSuffix
        //
        lblGenderSuffix.Margin = new Padding(4, 0, 0, 0);
        lblGenderSuffix.AutoSize = true;
        lblGenderSuffix.ForeColor = Color.FromArgb(100, 116, 139);
        lblGenderSuffix.Name = "lblGenderSuffix";
        lblGenderSuffix.Text = "(tùy chọn)";
        //
        // pnlGenderFrame
        //
        pnlGenderFrame.Margin = new Padding(0);
        pnlGenderFrame.Dock = DockStyle.Fill;
        pnlGenderFrame.Padding = new Padding(1);
        pnlGenderFrame.BackColor = Color.FromArgb(226, 232, 240);
        pnlGenderFrame.Name = "pnlGenderFrame";
        pnlGenderFrame.Controls.Add(layoutGenderControl);
        //
        // layoutGenderControl
        //
        layoutGenderControl.Margin = new Padding(0);
        layoutGenderControl.Dock = DockStyle.Fill;
        layoutGenderControl.Padding = new Padding(7, 0, 9, 0);
        layoutGenderControl.BackColor = Color.White;
        layoutGenderControl.ColumnCount = 1;
        layoutGenderControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutGenderControl.RowCount = 1;
        layoutGenderControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutGenderControl.Name = "layoutGenderControl";
        layoutGenderControl.Controls.Add(cmbGender, 0, 0);
        //
        // cmbGender
        //
        cmbGender.Margin = new Padding(0);
        cmbGender.AccessibleName = "Giới tính, tùy chọn";
        cmbGender.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cmbGender.BackColor = Color.White;
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbGender.FlatStyle = FlatStyle.Flat;
        cmbGender.FormattingEnabled = true;
        cmbGender.Items.AddRange(new object[] { "Chưa chọn", "Nam", "Nữ", "Khác" });
        cmbGender.Name = "cmbGender";
        cmbGender.Text = "Chưa chọn";
        //
        // layoutInitialTier
        //
        layoutInitialTier.Margin = new Padding(0);
        layoutInitialTier.Dock = DockStyle.Fill;
        layoutInitialTier.Padding = new Padding(14, 0, 14, 0);
        layoutInitialTier.BackColor = Color.FromArgb(239, 246, 255);
        layoutInitialTier.ColumnCount = 2;
        layoutInitialTier.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutInitialTier.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutInitialTier.RowCount = 1;
        layoutInitialTier.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutInitialTier.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutInitialTier.Name = "layoutInitialTier";
        layoutInitialTier.Controls.Add(lblInitialTier, 0, 0);
        layoutInitialTier.Controls.Add(lblInitialPoints, 1, 0);
        //
        // lblInitialTier
        //
        lblInitialTier.Margin = new Padding(0);
        lblInitialTier.Dock = DockStyle.Fill;
        lblInitialTier.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblInitialTier.Text = "Hạng khởi tạo";
        lblInitialTier.TextAlign = ContentAlignment.MiddleLeft;
        lblInitialTier.UseMnemonic = false;
        lblInitialTier.Name = "lblInitialTier";
        //
        // lblInitialPoints
        //
        lblInitialPoints.Margin = new Padding(0);
        lblInitialPoints.Dock = DockStyle.Fill;
        lblInitialPoints.Text = "Silver · 0 điểm";
        lblInitialPoints.TextAlign = ContentAlignment.MiddleRight;
        lblInitialPoints.UseMnemonic = false;
        lblInitialPoints.Name = "lblInitialPoints";
        //
        // chkConsent
        //
        chkConsent.Margin = new Padding(0);
        chkConsent.Dock = DockStyle.Fill;
        chkConsent.Padding = new Padding(0, 3, 0, 0);
        chkConsent.Font = new Font("Segoe UI", 10.5F);
        chkConsent.Text = "Khách hàng đồng ý với điều khoản thành viên";
        chkConsent.UseVisualStyleBackColor = true;
        chkConsent.Name = "chkConsent";
        //
        // layoutFooter
        //
        layoutFooter.Margin = new Padding(0, 7, 0, 12);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.ColumnCount = 3;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 174F));
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Controls.Add(btnCancel, 1, 0);
        layoutFooter.Controls.Add(btnSave, 2, 0);
        //
        // btnCancel
        //
        btnCancel.Margin = new Padding(0, 0, 13, 0);
        btnCancel.Dock = DockStyle.Fill;
        btnCancel.BackColor = Color.White;
        btnCancel.ForeColor = Color.FromArgb(15, 23, 42);
        btnCancel.Font = new Font("Segoe UI", 10.5F);
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnCancel.FlatAppearance.BorderSize = 1;
        btnCancel.Text = "Hủy";
        btnCancel.UseMnemonic = false;
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += ReturnToList_Click;
        btnCancel.Name = "btnCancel";
        //
        // btnSave
        //
        btnSave.Margin = new Padding(0);
        btnSave.Dock = DockStyle.Fill;
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.ForeColor = Color.White;
        btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Text = "Lưu thành viên";
        btnSave.UseMnemonic = false;
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Name = "btnSave";
        //
        // MemberRegistrationView
        //
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 10.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "MemberRegistrationView";
        Size = new Size(1136, 730);
        layoutFooter.ResumeLayout(false);
        layoutInitialTier.ResumeLayout(false);
        layoutBirthDateControl.ResumeLayout(false);
        layoutBirthDateControl.PerformLayout();
        pnlBirthDateFrame.ResumeLayout(false);
        flowBirthDateCaption.ResumeLayout(false);
        flowBirthDateCaption.PerformLayout();
        layoutBirthDate.ResumeLayout(false);
        layoutEmailControl.ResumeLayout(false);
        layoutEmailControl.PerformLayout();
        pnlEmailFrame.ResumeLayout(false);
        flowEmailCaption.ResumeLayout(false);
        flowEmailCaption.PerformLayout();
        layoutEmail.ResumeLayout(false);
        layoutPhoneControl.ResumeLayout(false);
        layoutPhoneControl.PerformLayout();
        pnlPhoneFrame.ResumeLayout(false);
        flowPhoneCaption.ResumeLayout(false);
        flowPhoneCaption.PerformLayout();
        layoutPhone.ResumeLayout(false);
        layoutFullNameControl.ResumeLayout(false);
        layoutFullNameControl.PerformLayout();
        pnlFullNameFrame.ResumeLayout(false);
        flowFullNameCaption.ResumeLayout(false);
        flowFullNameCaption.PerformLayout();
        layoutFullName.ResumeLayout(false);
        layoutFields.ResumeLayout(false);
        layoutGenderControl.ResumeLayout(false);
        pnlGenderFrame.ResumeLayout(false);
        flowGenderCaption.ResumeLayout(false);
        flowGenderCaption.PerformLayout();
        layoutGender.ResumeLayout(false);
        layoutRegistrationCard.ResumeLayout(false);
        pnlRegistrationCard.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        pnlViewport.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private LinkLabel lnkBack;
    private Label lblTitle;
    private Panel pnlRegistrationCard;
    private TableLayoutPanel layoutRegistrationCard;
    private TableLayoutPanel layoutFields;
    private TableLayoutPanel layoutFullName;
    private FlowLayoutPanel flowFullNameCaption;
    private Label lblFullName;
    private Label lblFullNameSuffix;
    private Panel pnlFullNameFrame;
    private TableLayoutPanel layoutFullNameControl;
    private TextBox txtFullName;
    private TableLayoutPanel layoutPhone;
    private FlowLayoutPanel flowPhoneCaption;
    private Label lblPhone;
    private Label lblPhoneSuffix;
    private Panel pnlPhoneFrame;
    private TableLayoutPanel layoutPhoneControl;
    private TextBox txtPhone;
    private TableLayoutPanel layoutEmail;
    private FlowLayoutPanel flowEmailCaption;
    private Label lblEmail;
    private Label lblEmailSuffix;
    private Panel pnlEmailFrame;
    private TableLayoutPanel layoutEmailControl;
    private TextBox txtEmail;
    private TableLayoutPanel layoutBirthDate;
    private FlowLayoutPanel flowBirthDateCaption;
    private Label lblBirthDate;
    private Label lblBirthDateSuffix;
    private Panel pnlBirthDateFrame;
    private TableLayoutPanel layoutBirthDateControl;
    private DateTimePicker dtpBirthDate;
    private TableLayoutPanel layoutGender;
    private FlowLayoutPanel flowGenderCaption;
    private Label lblGender;
    private Label lblGenderSuffix;
    private Panel pnlGenderFrame;
    private TableLayoutPanel layoutGenderControl;
    private ComboBox cmbGender;
    private TableLayoutPanel layoutInitialTier;
    private Label lblInitialTier;
    private Label lblInitialPoints;
    private CheckBox chkConsent;
    private TableLayoutPanel layoutFooter;
    private Button btnCancel;
    private Button btnSave;
}

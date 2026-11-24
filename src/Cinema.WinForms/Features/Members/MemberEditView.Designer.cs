namespace Cinema.WinForms.Features.Members;

partial class MemberEditView
{
    private void InitializeComponent()
    {
        pnlViewport = new Panel();
        layoutPage = new TableLayoutPanel();
        layoutHeading = new TableLayoutPanel();
        lblTitle = new Label();
        lblMemberCode = new Label();
        pnlEditCard = new Panel();
        layoutEditCard = new TableLayoutPanel();
        layoutFields = new TableLayoutPanel();
        layoutName = new TableLayoutPanel();
        lblFullName = new Label();
        pnlNameFrame = new Panel();
        layoutNameField = new TableLayoutPanel();
        txtFullName = new TextBox();
        lblNameHint = new Label();
        pnlProfileDivider = new Panel();
        layoutProfile = new TableLayoutPanel();
        layoutProfileTitle = new TableLayoutPanel();
        lblLockIcon = new Label();
        lblProfileTitle = new Label();
        lblPhoneCaption = new Label();
        lblPhoneValue = new Label();
        lblEmailCaption = new Label();
        lblEmailValue = new Label();
        lblBirthDateCaption = new Label();
        lblBirthDateValue = new Label();
        lblTierCaption = new Label();
        lblTierValue = new Label();
        lblPointsCaption = new Label();
        lblPointsValue = new Label();
        pnlFooterDivider = new Panel();
        layoutFooter = new TableLayoutPanel();
        btnCancel = new Button();
        btnSave = new Button();
        pnlViewport.SuspendLayout();
        layoutPage.SuspendLayout();
        layoutHeading.SuspendLayout();
        pnlEditCard.SuspendLayout();
        layoutEditCard.SuspendLayout();
        layoutFields.SuspendLayout();
        layoutName.SuspendLayout();
        pnlNameFrame.SuspendLayout();
        layoutNameField.SuspendLayout();
        layoutProfile.SuspendLayout();
        layoutProfileTitle.SuspendLayout();
        layoutFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlViewport
        // 
        pnlViewport.AutoScroll = true;
        pnlViewport.AutoScrollMinSize = new Size(925, 540);
        pnlViewport.Controls.Add(layoutPage);
        pnlViewport.Dock = DockStyle.Fill;
        pnlViewport.Location = new Point(0, 0);
        pnlViewport.Margin = new Padding(0);
        pnlViewport.Name = "pnlViewport";
        pnlViewport.Size = new Size(1136, 730);
        pnlViewport.TabIndex = 0;
        // 
        // layoutPage
        // 
        layoutPage.ColumnCount = 1;
        layoutPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPage.Controls.Add(layoutHeading, 0, 0);
        layoutPage.Controls.Add(pnlEditCard, 0, 1);
        layoutPage.Dock = DockStyle.Fill;
        layoutPage.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutPage.Location = new Point(0, 0);
        layoutPage.Margin = new Padding(0);
        layoutPage.MinimumSize = new Size(925, 540);
        layoutPage.Name = "layoutPage";
        layoutPage.Padding = new Padding(16, 22, 16, 16);
        layoutPage.RowCount = 3;
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 382F));
        layoutPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPage.Size = new Size(1136, 730);
        layoutPage.TabIndex = 0;
        // 
        // layoutHeading
        // 
        layoutHeading.ColumnCount = 1;
        layoutHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutHeading.Controls.Add(lblTitle, 0, 0);
        layoutHeading.Controls.Add(lblMemberCode, 0, 1);
        layoutHeading.Dock = DockStyle.Fill;
        layoutHeading.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutHeading.Location = new Point(16, 22);
        layoutHeading.Margin = new Padding(0);
        layoutHeading.Name = "layoutHeading";
        layoutHeading.Padding = new Padding(4, 0, 0, 0);
        layoutHeading.RowCount = 3;
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        layoutHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutHeading.Size = new Size(1104, 98);
        layoutHeading.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitle.Location = new Point(4, 0);
        lblTitle.Margin = new Padding(0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1100, 48);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Cập nhật tên thành viên";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.UseMnemonic = false;
        // 
        // lblMemberCode
        // 
        lblMemberCode.Dock = DockStyle.Fill;
        lblMemberCode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblMemberCode.ForeColor = Color.FromArgb(100, 116, 139);
        lblMemberCode.Location = new Point(4, 48);
        lblMemberCode.Margin = new Padding(0);
        lblMemberCode.Name = "lblMemberCode";
        lblMemberCode.Size = new Size(1100, 28);
        lblMemberCode.TabIndex = 1;
        lblMemberCode.Text = "MEM-00124";
        lblMemberCode.TextAlign = ContentAlignment.MiddleLeft;
        lblMemberCode.UseMnemonic = false;
        // 
        // pnlEditCard
        // 
        pnlEditCard.BackColor = Color.FromArgb(226, 232, 240);
        pnlEditCard.Controls.Add(layoutEditCard);
        pnlEditCard.Dock = DockStyle.Fill;
        pnlEditCard.Location = new Point(16, 120);
        pnlEditCard.Margin = new Padding(0);
        pnlEditCard.Name = "pnlEditCard";
        pnlEditCard.Padding = new Padding(1);
        pnlEditCard.Size = new Size(1104, 382);
        pnlEditCard.TabIndex = 1;
        // 
        // layoutEditCard
        // 
        layoutEditCard.BackColor = Color.White;
        layoutEditCard.ColumnCount = 1;
        layoutEditCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutEditCard.Controls.Add(layoutFields, 0, 0);
        layoutEditCard.Controls.Add(pnlFooterDivider, 0, 2);
        layoutEditCard.Controls.Add(layoutFooter, 0, 3);
        layoutEditCard.Dock = DockStyle.Fill;
        layoutEditCard.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutEditCard.Location = new Point(1, 1);
        layoutEditCard.Margin = new Padding(0);
        layoutEditCard.Name = "layoutEditCard";
        layoutEditCard.Padding = new Padding(12, 15, 12, 12);
        layoutEditCard.RowCount = 4;
        layoutEditCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 267F));
        layoutEditCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
        layoutEditCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
        layoutEditCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutEditCard.Size = new Size(1102, 380);
        layoutEditCard.TabIndex = 0;
        // 
        // layoutFields
        // 
        layoutFields.ColumnCount = 3;
        layoutFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        layoutFields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
        layoutFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        layoutFields.Controls.Add(layoutName, 0, 0);
        layoutFields.Controls.Add(pnlProfileDivider, 1, 0);
        layoutFields.Controls.Add(layoutProfile, 2, 0);
        layoutFields.Dock = DockStyle.Fill;
        layoutFields.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFields.Location = new Point(12, 15);
        layoutFields.Margin = new Padding(0);
        layoutFields.Name = "layoutFields";
        layoutFields.RowCount = 1;
        layoutFields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFields.Size = new Size(1078, 267);
        layoutFields.TabIndex = 0;
        // 
        // layoutName
        // 
        layoutName.ColumnCount = 1;
        layoutName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutName.Controls.Add(lblFullName, 0, 0);
        layoutName.Controls.Add(pnlNameFrame, 0, 1);
        layoutName.Controls.Add(lblNameHint, 0, 2);
        layoutName.Dock = DockStyle.Fill;
        layoutName.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutName.Location = new Point(0, 0);
        layoutName.Margin = new Padding(0);
        layoutName.Name = "layoutName";
        layoutName.Padding = new Padding(10, 7, 27, 0);
        layoutName.RowCount = 4;
        layoutName.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutName.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layoutName.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
        layoutName.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutName.Size = new Size(560, 267);
        layoutName.TabIndex = 0;
        // 
        // lblFullName
        // 
        lblFullName.Dock = DockStyle.Fill;
        lblFullName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblFullName.Location = new Point(10, 7);
        lblFullName.Margin = new Padding(0);
        lblFullName.Name = "lblFullName";
        lblFullName.Padding = new Padding(0, 0, 0, 5);
        lblFullName.Size = new Size(523, 42);
        lblFullName.TabIndex = 0;
        lblFullName.Text = "Họ và tên";
        lblFullName.TextAlign = ContentAlignment.MiddleLeft;
        lblFullName.UseMnemonic = false;
        // 
        // pnlNameFrame
        // 
        pnlNameFrame.BackColor = Color.FromArgb(37, 99, 235);
        pnlNameFrame.Controls.Add(layoutNameField);
        pnlNameFrame.Dock = DockStyle.Fill;
        pnlNameFrame.Location = new Point(10, 49);
        pnlNameFrame.Margin = new Padding(0);
        pnlNameFrame.Name = "pnlNameFrame";
        pnlNameFrame.Padding = new Padding(2);
        pnlNameFrame.Size = new Size(523, 48);
        pnlNameFrame.TabIndex = 1;
        // 
        // layoutNameField
        // 
        layoutNameField.BackColor = Color.White;
        layoutNameField.ColumnCount = 1;
        layoutNameField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutNameField.Controls.Add(txtFullName, 0, 0);
        layoutNameField.Dock = DockStyle.Fill;
        layoutNameField.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutNameField.Location = new Point(2, 2);
        layoutNameField.Margin = new Padding(0);
        layoutNameField.Name = "layoutNameField";
        layoutNameField.Padding = new Padding(12, 0, 12, 0);
        layoutNameField.RowCount = 1;
        layoutNameField.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutNameField.Size = new Size(519, 44);
        layoutNameField.TabIndex = 0;
        // 
        // txtFullName
        // 
        txtFullName.AccessibleName = "Họ và tên";
        txtFullName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtFullName.BackColor = Color.White;
        txtFullName.BorderStyle = BorderStyle.None;
        txtFullName.Font = new Font("Segoe UI", 12F);
        txtFullName.ForeColor = Color.FromArgb(15, 23, 42);
        txtFullName.Location = new Point(12, 5);
        txtFullName.Margin = new Padding(0);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(495, 27);
        txtFullName.TabIndex = 0;
        txtFullName.Text = "Nguyễn Hoàng Nam";
        txtFullName.Enter += TxtFullName_Enter;
        txtFullName.Leave += TxtFullName_Leave;
        // 
        // lblNameHint
        // 
        lblNameHint.Dock = DockStyle.Fill;
        lblNameHint.Font = new Font("Segoe UI", 9.5F);
        lblNameHint.ForeColor = Color.FromArgb(100, 116, 139);
        lblNameHint.Location = new Point(10, 97);
        lblNameHint.Margin = new Padding(0);
        lblNameHint.Name = "lblNameHint";
        lblNameHint.Size = new Size(523, 33);
        lblNameHint.TabIndex = 2;
        lblNameHint.Text = "Chỉ sửa khi khách xác nhận.";
        lblNameHint.TextAlign = ContentAlignment.MiddleLeft;
        lblNameHint.UseMnemonic = false;
        // 
        // pnlProfileDivider
        // 
        pnlProfileDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlProfileDivider.Dock = DockStyle.Fill;
        pnlProfileDivider.Location = new Point(560, 0);
        pnlProfileDivider.Margin = new Padding(0);
        pnlProfileDivider.Name = "pnlProfileDivider";
        pnlProfileDivider.Size = new Size(1, 267);
        pnlProfileDivider.TabIndex = 1;
        // 
        // layoutProfile
        // 
        layoutProfile.ColumnCount = 2;
        layoutProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        layoutProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        layoutProfile.Controls.Add(layoutProfileTitle, 0, 0);
        layoutProfile.Controls.Add(lblPhoneCaption, 0, 1);
        layoutProfile.Controls.Add(lblPhoneValue, 1, 1);
        layoutProfile.Controls.Add(lblEmailCaption, 0, 2);
        layoutProfile.Controls.Add(lblEmailValue, 1, 2);
        layoutProfile.Controls.Add(lblBirthDateCaption, 0, 3);
        layoutProfile.Controls.Add(lblBirthDateValue, 1, 3);
        layoutProfile.Controls.Add(lblTierCaption, 0, 4);
        layoutProfile.Controls.Add(lblTierValue, 1, 4);
        layoutProfile.Controls.Add(lblPointsCaption, 0, 5);
        layoutProfile.Controls.Add(lblPointsValue, 1, 5);
        layoutProfile.Dock = DockStyle.Fill;
        layoutProfile.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutProfile.Location = new Point(561, 0);
        layoutProfile.Margin = new Padding(0);
        layoutProfile.Name = "layoutProfile";
        layoutProfile.Padding = new Padding(26, 5, 12, 5);
        layoutProfile.RowCount = 7;
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layoutProfile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutProfile.Size = new Size(517, 267);
        layoutProfile.TabIndex = 2;
        // 
        // layoutProfileTitle
        // 
        layoutProfileTitle.ColumnCount = 2;
        layoutProfile.SetColumnSpan(layoutProfileTitle, 2);
        layoutProfileTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        layoutProfileTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutProfileTitle.Controls.Add(lblLockIcon, 0, 0);
        layoutProfileTitle.Controls.Add(lblProfileTitle, 1, 0);
        layoutProfileTitle.Dock = DockStyle.Fill;
        layoutProfileTitle.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutProfileTitle.Location = new Point(26, 5);
        layoutProfileTitle.Margin = new Padding(0);
        layoutProfileTitle.Name = "layoutProfileTitle";
        layoutProfileTitle.RowCount = 1;
        layoutProfileTitle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutProfileTitle.Size = new Size(479, 43);
        layoutProfileTitle.TabIndex = 0;
        // 
        // lblLockIcon
        // 
        lblLockIcon.AccessibleRole = AccessibleRole.Graphic;
        lblLockIcon.Dock = DockStyle.Fill;
        lblLockIcon.Font = new Font("Segoe MDL2 Assets", 13F);
        lblLockIcon.ForeColor = Color.FromArgb(15, 23, 42);
        lblLockIcon.Location = new Point(0, 0);
        lblLockIcon.Margin = new Padding(0);
        lblLockIcon.Name = "lblLockIcon";
        lblLockIcon.Size = new Size(32, 43);
        lblLockIcon.TabIndex = 0;
        lblLockIcon.Text = "";
        lblLockIcon.TextAlign = ContentAlignment.MiddleLeft;
        lblLockIcon.UseMnemonic = false;
        // 
        // lblProfileTitle
        // 
        lblProfileTitle.Dock = DockStyle.Fill;
        lblProfileTitle.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
        lblProfileTitle.Location = new Point(32, 0);
        lblProfileTitle.Margin = new Padding(0);
        lblProfileTitle.Name = "lblProfileTitle";
        lblProfileTitle.Size = new Size(447, 43);
        lblProfileTitle.TabIndex = 1;
        lblProfileTitle.Text = "Hồ sơ thành viên";
        lblProfileTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblProfileTitle.UseMnemonic = false;
        // 
        // lblPhoneCaption
        // 
        lblPhoneCaption.AutoEllipsis = true;
        lblPhoneCaption.Dock = DockStyle.Fill;
        lblPhoneCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblPhoneCaption.Location = new Point(26, 48);
        lblPhoneCaption.Margin = new Padding(0);
        lblPhoneCaption.Name = "lblPhoneCaption";
        lblPhoneCaption.Size = new Size(215, 38);
        lblPhoneCaption.TabIndex = 1;
        lblPhoneCaption.Text = "Số điện thoại";
        lblPhoneCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblPhoneCaption.UseMnemonic = false;
        // 
        // lblPhoneValue
        // 
        lblPhoneValue.AutoEllipsis = true;
        lblPhoneValue.Dock = DockStyle.Fill;
        lblPhoneValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblPhoneValue.Location = new Point(241, 48);
        lblPhoneValue.Margin = new Padding(0);
        lblPhoneValue.Name = "lblPhoneValue";
        lblPhoneValue.Padding = new Padding(5, 0, 0, 0);
        lblPhoneValue.Size = new Size(264, 38);
        lblPhoneValue.TabIndex = 2;
        lblPhoneValue.Text = "0901234567";
        lblPhoneValue.TextAlign = ContentAlignment.MiddleLeft;
        lblPhoneValue.UseMnemonic = false;
        // 
        // lblEmailCaption
        // 
        lblEmailCaption.AutoEllipsis = true;
        lblEmailCaption.Dock = DockStyle.Fill;
        lblEmailCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblEmailCaption.Location = new Point(26, 86);
        lblEmailCaption.Margin = new Padding(0);
        lblEmailCaption.Name = "lblEmailCaption";
        lblEmailCaption.Size = new Size(215, 38);
        lblEmailCaption.TabIndex = 3;
        lblEmailCaption.Text = "Email tài khoản";
        lblEmailCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblEmailCaption.UseMnemonic = false;
        // 
        // lblEmailValue
        // 
        lblEmailValue.AutoEllipsis = true;
        lblEmailValue.Dock = DockStyle.Fill;
        lblEmailValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblEmailValue.Location = new Point(241, 86);
        lblEmailValue.Margin = new Padding(0);
        lblEmailValue.Name = "lblEmailValue";
        lblEmailValue.Padding = new Padding(5, 0, 0, 0);
        lblEmailValue.Size = new Size(264, 38);
        lblEmailValue.TabIndex = 4;
        lblEmailValue.Text = "nam@example.com";
        lblEmailValue.TextAlign = ContentAlignment.MiddleLeft;
        lblEmailValue.UseMnemonic = false;
        // 
        // lblBirthDateCaption
        // 
        lblBirthDateCaption.AutoEllipsis = true;
        lblBirthDateCaption.Dock = DockStyle.Fill;
        lblBirthDateCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblBirthDateCaption.Location = new Point(26, 124);
        lblBirthDateCaption.Margin = new Padding(0);
        lblBirthDateCaption.Name = "lblBirthDateCaption";
        lblBirthDateCaption.Size = new Size(215, 38);
        lblBirthDateCaption.TabIndex = 5;
        lblBirthDateCaption.Text = "Ngày sinh";
        lblBirthDateCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblBirthDateCaption.UseMnemonic = false;
        // 
        // lblBirthDateValue
        // 
        lblBirthDateValue.AutoEllipsis = true;
        lblBirthDateValue.Dock = DockStyle.Fill;
        lblBirthDateValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblBirthDateValue.Location = new Point(241, 124);
        lblBirthDateValue.Margin = new Padding(0);
        lblBirthDateValue.Name = "lblBirthDateValue";
        lblBirthDateValue.Padding = new Padding(5, 0, 0, 0);
        lblBirthDateValue.Size = new Size(264, 38);
        lblBirthDateValue.TabIndex = 6;
        lblBirthDateValue.Text = "15/08/1998";
        lblBirthDateValue.TextAlign = ContentAlignment.MiddleLeft;
        lblBirthDateValue.UseMnemonic = false;
        // 
        // lblTierCaption
        // 
        lblTierCaption.AutoEllipsis = true;
        lblTierCaption.Dock = DockStyle.Fill;
        lblTierCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblTierCaption.Location = new Point(26, 162);
        lblTierCaption.Margin = new Padding(0);
        lblTierCaption.Name = "lblTierCaption";
        lblTierCaption.Size = new Size(215, 38);
        lblTierCaption.TabIndex = 7;
        lblTierCaption.Text = "Hạng thành viên";
        lblTierCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblTierCaption.UseMnemonic = false;
        // 
        // lblTierValue
        // 
        lblTierValue.AutoEllipsis = true;
        lblTierValue.Dock = DockStyle.Fill;
        lblTierValue.ForeColor = Color.FromArgb(146, 64, 14);
        lblTierValue.Location = new Point(241, 162);
        lblTierValue.Margin = new Padding(0);
        lblTierValue.Name = "lblTierValue";
        lblTierValue.Padding = new Padding(5, 0, 0, 0);
        lblTierValue.Size = new Size(264, 38);
        lblTierValue.TabIndex = 8;
        lblTierValue.Text = "Gold";
        lblTierValue.TextAlign = ContentAlignment.MiddleLeft;
        lblTierValue.UseMnemonic = false;
        // 
        // lblPointsCaption
        // 
        lblPointsCaption.AutoEllipsis = true;
        lblPointsCaption.Dock = DockStyle.Fill;
        lblPointsCaption.ForeColor = Color.FromArgb(100, 116, 139);
        lblPointsCaption.Location = new Point(26, 200);
        lblPointsCaption.Margin = new Padding(0);
        lblPointsCaption.Name = "lblPointsCaption";
        lblPointsCaption.Size = new Size(215, 38);
        lblPointsCaption.TabIndex = 9;
        lblPointsCaption.Text = "Điểm tích lũy";
        lblPointsCaption.TextAlign = ContentAlignment.MiddleLeft;
        lblPointsCaption.UseMnemonic = false;
        // 
        // lblPointsValue
        // 
        lblPointsValue.AutoEllipsis = true;
        lblPointsValue.Dock = DockStyle.Fill;
        lblPointsValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblPointsValue.Location = new Point(241, 200);
        lblPointsValue.Margin = new Padding(0);
        lblPointsValue.Name = "lblPointsValue";
        lblPointsValue.Padding = new Padding(5, 0, 0, 0);
        lblPointsValue.Size = new Size(264, 38);
        lblPointsValue.TabIndex = 10;
        lblPointsValue.Text = "320 điểm";
        lblPointsValue.TextAlign = ContentAlignment.MiddleLeft;
        lblPointsValue.UseMnemonic = false;
        // 
        // pnlFooterDivider
        // 
        pnlFooterDivider.BackColor = Color.FromArgb(226, 232, 240);
        pnlFooterDivider.Dock = DockStyle.Fill;
        pnlFooterDivider.Location = new Point(12, 299);
        pnlFooterDivider.Margin = new Padding(0);
        pnlFooterDivider.Name = "pnlFooterDivider";
        pnlFooterDivider.Size = new Size(1078, 1);
        pnlFooterDivider.TabIndex = 1;
        // 
        // layoutFooter
        // 
        layoutFooter.ColumnCount = 3;
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
        layoutFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 169F));
        layoutFooter.Controls.Add(btnCancel, 1, 0);
        layoutFooter.Controls.Add(btnSave, 2, 0);
        layoutFooter.Dock = DockStyle.Fill;
        layoutFooter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        layoutFooter.Location = new Point(12, 300);
        layoutFooter.Margin = new Padding(0);
        layoutFooter.Name = "layoutFooter";
        layoutFooter.Padding = new Padding(0, 16, 0, 7);
        layoutFooter.RowCount = 1;
        layoutFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutFooter.Size = new Size(1078, 68);
        layoutFooter.TabIndex = 2;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.White;
        btnCancel.Dock = DockStyle.Fill;
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 11F);
        btnCancel.ForeColor = Color.FromArgb(15, 23, 42);
        btnCancel.Location = new Point(773, 16);
        btnCancel.Margin = new Padding(0, 0, 14, 0);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(122, 45);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Hủy";
        btnCancel.UseMnemonic = false;
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.Dock = DockStyle.Fill;
        btnSave.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(909, 16);
        btnSave.Margin = new Padding(0);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(169, 45);
        btnSave.TabIndex = 1;
        btnSave.Text = "Lưu thay đổi";
        btnSave.UseMnemonic = false;
        btnSave.UseVisualStyleBackColor = false;
        // 
        // MemberEditView
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(pnlViewport);
        Font = new Font("Segoe UI", 10.5F);
        ForeColor = Color.FromArgb(15, 23, 42);
        Name = "MemberEditView";
        Size = new Size(1136, 730);
        pnlViewport.ResumeLayout(false);
        layoutPage.ResumeLayout(false);
        layoutHeading.ResumeLayout(false);
        pnlEditCard.ResumeLayout(false);
        layoutEditCard.ResumeLayout(false);
        layoutFields.ResumeLayout(false);
        layoutName.ResumeLayout(false);
        pnlNameFrame.ResumeLayout(false);
        layoutNameField.ResumeLayout(false);
        layoutNameField.PerformLayout();
        layoutProfile.ResumeLayout(false);
        layoutProfileTitle.ResumeLayout(false);
        layoutFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlViewport;
    private TableLayoutPanel layoutPage;
    private TableLayoutPanel layoutHeading;
    private Label lblTitle;
    private Label lblMemberCode;
    private Panel pnlEditCard;
    private TableLayoutPanel layoutEditCard;
    private TableLayoutPanel layoutFields;
    private TableLayoutPanel layoutName;
    private Label lblFullName;
    private Panel pnlNameFrame;
    private TableLayoutPanel layoutNameField;
    private TextBox txtFullName;
    private Label lblNameHint;
    private Panel pnlProfileDivider;
    private TableLayoutPanel layoutProfile;
    private TableLayoutPanel layoutProfileTitle;
    private Label lblLockIcon;
    private Label lblProfileTitle;
    private Label lblPhoneCaption;
    private Label lblPhoneValue;
    private Label lblEmailCaption;
    private Label lblEmailValue;
    private Label lblBirthDateCaption;
    private Label lblBirthDateValue;
    private Label lblTierCaption;
    private Label lblTierValue;
    private Label lblPointsCaption;
    private Label lblPointsValue;
    private Panel pnlFooterDivider;
    private TableLayoutPanel layoutFooter;
    private Button btnCancel;
    private Button btnSave;
}

using CinemaManagement.UI.Theme;
using CinemaManagement.UI.UserControls.Common;

namespace CinemaManagement.UI.Forms.Shared
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null!;

        // Header & Layout
        private PillButton btnBackToHome = null!;
        private CinemaBackdropPanel body = null!;
        private Panel pnlTitle = null!;
        private Label lblPageTitle = null!;
        private Label lblPageSubtitle = null!;
        private TableLayoutPanel pnlProfileContent = null!;

        // Left Card - Employee Summary
        private CardPanel pnlEmployeeSummary = null!;
        private Panel pnlAvatar = null!;
        private Label lblAvatarInitial = null!;
        private Label lblEmployeeName = null!;
        private Label lblPosition = null!;
        private Label lblEmployeeCode = null!;
        private Label lblWorkStatus = null!;
        private Panel pnlSummaryDivider = null!;
        private PillButton btnChangePassword = null!;

        // Right Card - Personal Info
        private CardPanel pnlPersonalInfo = null!;
        private Label lblCardTitle = null!;
        private Label lblCardSubtitle = null!;
        private TableLayoutPanel pnlFieldsGrid = null!;

        // Form Fields
        private TextBox txtFullName = null!;
        private TextBox txtPhone = null!;
        private TextBox txtEmail = null!;
        private TextBox txtRole = null!;
        private TextBox txtPosition = null!;
        private TextBox txtStartDate = null!;
        private TextBox txtWorkStatus = null!;

        // Field Wrappers
        private CardPanel wrapFullName = null!;
        private CardPanel wrapPhone = null!;
        private CardPanel wrapEmail = null!;
        private CardPanel wrapRole = null!;
        private CardPanel wrapPosition = null!;
        private CardPanel wrapStartDate = null!;
        private CardPanel wrapWorkStatus = null!;

        // Bottom Actions
        private Panel pnlActions = null!;
        private Label lblSaveFeedback = null!;
        private PillButton btnCancel = null!;
        private PillButton btnSave = null!;

        // Error provider
        private ErrorProvider errorProviderProfile = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // Form Properties
            Text = "Storyline Cinema — Hồ sơ cá nhân";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(this.S(1024), this.S(680));
            BackColor = AppColors.PageBackground;
            Font = new Font("Segoe UI", 10F);
            AutoScaleMode = AutoScaleMode.Dpi;
            DoubleBuffered = true;

            errorProviderProfile = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            // 1. Body Container
            body = new CinemaBackdropPanel
            {
                Dock = DockStyle.Fill,
                Animate = false,
                Padding = new Padding(this.S(30), this.S(20), this.S(30), this.S(24))
            };

            // 2. Title Block & Nút Thoát ra trang chủ
            pnlTitle = new Panel
            {
                Dock = DockStyle.Top,
                Height = this.S(64),
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, this.S(16))
            };

            lblPageTitle = new Label
            {
                Text = "HỒ SƠ CÁ NHÂN",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(0, 0)
            };

            lblPageSubtitle = new Label
            {
                Text = "Quản lý thông tin cá nhân và tài khoản của bạn",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(0, this.S(34))
            };

            btnBackToHome = new PillButton
            {
                Text = "←  Thoát ra trang chủ",
                Radius = 12,
                NormalColor = ColorTranslator.FromHtml("#25202C"),
                HoverColor = UiKit.Blend(ColorTranslator.FromHtml("#25202C"), AppColors.Primary, 0.35f),
                PressedColor = AppColors.Primary,
                BorderColor = ColorTranslator.FromHtml("#44394A"),
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(195), this.S(42)),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            pnlTitle.Resize += (s, e) =>
            {
                btnBackToHome.Location = new Point(pnlTitle.Width - btnBackToHome.Width, (pnlTitle.Height - btnBackToHome.Height) / 2);
            };

            pnlTitle.Controls.Add(lblPageTitle);
            pnlTitle.Controls.Add(lblPageSubtitle);
            pnlTitle.Controls.Add(btnBackToHome);

            // 3. Main 2-Column Content Layout (32% Left, 68% Right)
            pnlProfileContent = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Padding = Padding.Empty,
                Margin = Padding.Empty
            };
            UiKit.DoubleBuffer(pnlProfileContent);

            pnlProfileContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32f));
            pnlProfileContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68f));
            pnlProfileContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            // Dựng Card Trái và Card Phải
            BuildLeftCard();
            BuildRightCard();

            pnlProfileContent.Controls.Add(pnlEmployeeSummary, 0, 0);
            pnlProfileContent.Controls.Add(pnlPersonalInfo, 1, 0);

            // Lắp ráp vào Form
            body.Controls.Add(pnlProfileContent);
            body.Controls.Add(pnlTitle);

            Controls.Add(body);
            KeyPreview = true;

            ResumeLayout(false);
        }

        private void BuildLeftCard()
        {
            pnlEmployeeSummary = new CardPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, this.S(16), 0),
                Padding = new Padding(this.S(24), this.S(28), this.S(24), this.S(24)),
                Radius = 16,
                FillColor = AppColors.CardBackground,
                BorderColor = AppColors.Border,
                ShowShadow = false
            };
            UiKit.DoubleBuffer(pnlEmployeeSummary);

            // Container xếp dọc cho thông tin nhân viên
            var flow = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 8,
                BackColor = Color.Transparent
            };
            UiKit.DoubleBuffer(flow);

            flow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(100))); // 0. Avatar
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(38)));  // 1. Tên nhân viên
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(26)));  // 2. Chức vụ
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(38)));  // 3. Mã nhân viên
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(38)));  // 4. Trạng thái làm việc
            flow.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));         // 5. Spacer dãn cách
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(18)));  // 6. Đường kẻ phân cách
            flow.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(48)));  // 7. Nút Đổi mật khẩu

            // Avatar Tròn
            int avSize = this.S(88);
            pnlAvatar = new Panel
            {
                Size = new Size(avSize, avSize),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };
            UiKit.DoubleBuffer(pnlAvatar);

            lblAvatarInitial = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pnlAvatar.Controls.Add(lblAvatarInitial);

            pnlAvatar.Paint += (s, e) =>
            {
                var g = e.Graphics;
                UiKit.HighQuality(g);
                var rect = new Rectangle(1, 1, pnlAvatar.Width - 3, pnlAvatar.Height - 3);
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, AppColors.PrimaryHover, AppColors.DarkRed, 45f))
                {
                    g.FillEllipse(brush, rect);
                }
                using (var pen = new Pen(AppColors.Primary, 2.5f))
                {
                    g.DrawEllipse(pen, rect);
                }
            };

            // Tên nhân viên
            lblEmployeeName = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = AppColors.TextPrimary,
                BackColor = Color.Transparent
            };

            // Chức vụ
            lblPosition = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = AppColors.TextSecondary,
                BackColor = Color.Transparent
            };

            // Mã nhân viên (dạng pill nhẹ nhàng)
            lblEmployeeCode = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = AppColors.Accent,
                BackColor = Color.Transparent
            };

            // Trạng thái làm việc
            lblWorkStatus = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = AppColors.Success,
                BackColor = Color.Transparent,
                Text = "● Đang làm việc"
            };

            // Đường phân cách
            pnlSummaryDivider = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            pnlSummaryDivider.Paint += (s, e) =>
            {
                using var p = new Pen(AppColors.Border);
                e.Graphics.DrawLine(p, 0, pnlSummaryDivider.Height / 2, pnlSummaryDivider.Width, pnlSummaryDivider.Height / 2);
            };

            // Nút Đổi mật khẩu
            btnChangePassword = new PillButton
            {
                Text = "🔒  ĐỔI MẬT KHẨU",
                Dock = DockStyle.Fill,
                Radius = 12,
                NormalColor = ColorTranslator.FromHtml("#22141A"),
                HoverColor = AppColors.Primary,
                BorderColor = ColorTranslator.FromHtml("#72222B"),
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            flow.Controls.Add(pnlAvatar, 0, 0);
            flow.Controls.Add(lblEmployeeName, 0, 1);
            flow.Controls.Add(lblPosition, 0, 2);
            flow.Controls.Add(lblEmployeeCode, 0, 3);
            flow.Controls.Add(lblWorkStatus, 0, 4);
            flow.Controls.Add(new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent }, 0, 5);
            flow.Controls.Add(pnlSummaryDivider, 0, 6);
            flow.Controls.Add(btnChangePassword, 0, 7);

            pnlEmployeeSummary.Controls.Add(flow);
        }

        private void BuildRightCard()
        {
            pnlPersonalInfo = new CardPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(this.S(6), 0, 0, 0),
                Padding = new Padding(this.S(30), this.S(28), this.S(30), this.S(24)),
                Radius = 16,
                FillColor = AppColors.CardBackground,
                BorderColor = AppColors.Border,
                ShowShadow = false
            };
            UiKit.DoubleBuffer(pnlPersonalInfo);

            var mainTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.Transparent
            };
            UiKit.DoubleBuffer(mainTable);

            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(64)));  // Tiêu đề card
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));         // Lưới fields
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, this.S(56)));  // Nút thao tác

            // 1. Tiêu đề Card
            var pnlCardHeader = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            lblCardTitle = new Label
            {
                Text = "THÔNG TIN CÁ NHÂN",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(0, 0)
            };

            lblCardSubtitle = new Label
            {
                Text = "Cập nhật những thông tin được phép chỉnh sửa",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextSecondary,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(0, this.S(28))
            };
            pnlCardHeader.Controls.AddRange(new Control[] { lblCardTitle, lblCardSubtitle });

            // 2. Lưới Form Fields (2 cột đối xứng)
            pnlFieldsGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                BackColor = Color.Transparent
            };
            UiKit.DoubleBuffer(pnlFieldsGrid);

            pnlFieldsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            pnlFieldsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            int fieldRowH = this.S(78);
            for (int r = 0; r < 4; r++)
                pnlFieldsGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, fieldRowH));

            // Row 0: Họ và tên (Editable) | Số điện thoại (Editable)
            txtFullName = new TextBox { PlaceholderText = "Nhập họ và tên đầy đủ" };
            var pnlFullName = MakeFieldControl("HỌ VÀ TÊN *", txtFullName, isReadOnly: false, out wrapFullName);

            txtPhone = new TextBox { PlaceholderText = "Nhập số điện thoại (10 chữ số)" };
            var pnlPhone = MakeFieldControl("SỐ ĐIỆN THOẠI *", txtPhone, isReadOnly: false, out wrapPhone);

            // Row 1: Email (Readonly) | Vai trò hệ thống (Readonly)
            txtEmail = new TextBox();
            var pnlEmail = MakeFieldControl("EMAIL ĐĂNG NHẬP", txtEmail, isReadOnly: true, out wrapEmail);

            txtRole = new TextBox();
            var pnlRole = MakeFieldControl("VAI TRÒ HỆ THỐNG", txtRole, isReadOnly: true, out wrapRole);

            // Row 2: Chức vụ (Readonly) | Ngày vào làm (Readonly)
            txtPosition = new TextBox();
            var pnlPosition = MakeFieldControl("CHỨC VỤ", txtPosition, isReadOnly: true, out wrapPosition);

            txtStartDate = new TextBox();
            var pnlStartDate = MakeFieldControl("NGÀY VÀO LÀM", txtStartDate, isReadOnly: true, out wrapStartDate);

            // Row 3: Trạng thái làm việc (Readonly)
            txtWorkStatus = new TextBox();
            var pnlWorkStatus = MakeFieldControl("TRẠNG THÁI LÀM VIỆC", txtWorkStatus, isReadOnly: true, out wrapWorkStatus);

            pnlFieldsGrid.Controls.Add(pnlFullName, 0, 0);
            pnlFieldsGrid.Controls.Add(pnlPhone, 1, 0);
            pnlFieldsGrid.Controls.Add(pnlEmail, 0, 1);
            pnlFieldsGrid.Controls.Add(pnlRole, 1, 1);
            pnlFieldsGrid.Controls.Add(pnlPosition, 0, 2);
            pnlFieldsGrid.Controls.Add(pnlStartDate, 1, 2);
            pnlFieldsGrid.Controls.Add(pnlWorkStatus, 0, 3);

            // 3. Thanh nút thao tác cuối card
            pnlActions = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            lblSaveFeedback = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.Success,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(0, this.S(14)),
                Visible = false
            };

            btnCancel = new PillButton
            {
                Text = "HỦY",
                Radius = 10,
                NormalColor = ColorTranslator.FromHtml("#25202C"),
                HoverColor = UiKit.Blend(ColorTranslator.FromHtml("#25202C"), AppColors.Border, 0.35f),
                BorderColor = ColorTranslator.FromHtml("#44394A"),
                ForeColor = ColorTranslator.FromHtml("#D5CDD3"),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(110), this.S(44)),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            btnSave = new PillButton
            {
                Text = "LƯU THAY ĐỔI",
                Radius = 10,
                NormalColor = ColorTranslator.FromHtml("#B92F3C"),
                HoverColor = ColorTranslator.FromHtml("#C33B47"),
                PressedColor = AppColors.DarkRed,
                DisabledColor = ColorTranslator.FromHtml("#4B3237"),
                BorderColor = Color.Empty,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(160), this.S(44)),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Enabled = false // Ban đầu disabled
            };

            pnlActions.Controls.Add(lblSaveFeedback);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Controls.Add(btnSave);

            pnlActions.Resize += (s, e) =>
            {
                int pad = this.S(12);
                btnSave.Location = new Point(pnlActions.Width - btnSave.Width, (pnlActions.Height - btnSave.Height) / 2);
                btnCancel.Location = new Point(btnSave.Left - btnCancel.Width - pad, (pnlActions.Height - btnCancel.Height) / 2);
                lblSaveFeedback.Location = new Point(0, (pnlActions.Height - lblSaveFeedback.Height) / 2);
            };

            mainTable.Controls.Add(pnlCardHeader, 0, 0);
            mainTable.Controls.Add(pnlFieldsGrid, 0, 1);
            mainTable.Controls.Add(pnlActions, 0, 2);

            pnlPersonalInfo.Controls.Add(mainTable);
        }

        private Panel MakeFieldControl(string caption, TextBox tb, bool isReadOnly, out CardPanel wrap)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, this.S(16), 0)
            };

            var lblCaption = new Label
            {
                Text = caption,
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = isReadOnly ? AppColors.TextMuted : AppColors.TextSecondary,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Location = new Point(0, 0)
            };

            int inputH = this.S(42);
            var cardWrap = new CardPanel
            {
                Dock = DockStyle.Bottom,
                Height = inputH,
                Radius = 10,
                ShowShadow = false,
                Padding = Padding.Empty,
                FillColor = isReadOnly ? ColorTranslator.FromHtml("#15121A") : ColorTranslator.FromHtml("#211B27"),
                BorderColor = isReadOnly ? ColorTranslator.FromHtml("#332D39") : ColorTranslator.FromHtml("#453846")
            };

            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = cardWrap.FillColor;
            tb.ForeColor = isReadOnly ? ColorTranslator.FromHtml("#9D949F") : ColorTranslator.FromHtml("#F5EFE7");
            tb.Font = new Font("Segoe UI", 10.5F);
            tb.ReadOnly = isReadOnly;
            tb.TabStop = !isReadOnly;

            int rightSpace = isReadOnly ? this.S(36) : this.S(12);
            tb.Location = new Point(this.S(14), (inputH - tb.PreferredHeight) / 2);
            tb.Width = cardWrap.Width - this.S(28) - rightSpace;
            tb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            if (isReadOnly)
            {
                var lblLock = new Label
                {
                    Text = "🔒",
                    AutoSize = false,
                    Size = new Size(this.S(28), inputH),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = ColorTranslator.FromHtml("#6E6472"),
                    Font = new Font("Segoe UI Emoji", 9.5F),
                    BackColor = Color.Transparent,
                    Dock = DockStyle.Right
                };
                cardWrap.Controls.Add(lblLock);
            }
            else
            {
                tb.Enter += (s, e) =>
                {
                    if (cardWrap.BorderColor != AppColors.StatusRed)
                    {
                        cardWrap.BorderColor = ColorTranslator.FromHtml("#B92F3C");
                        cardWrap.Invalidate();
                    }
                };
                tb.Leave += (s, e) =>
                {
                    if (cardWrap.BorderColor != AppColors.StatusRed)
                    {
                        cardWrap.BorderColor = ColorTranslator.FromHtml("#453846");
                        cardWrap.Invalidate();
                    }
                };
            }

            cardWrap.Controls.Add(tb);
            cardWrap.Click += (s, e) => { if (!isReadOnly) tb.Focus(); };

            panel.Controls.Add(lblCaption);
            panel.Controls.Add(cardWrap);

            wrap = cardWrap;
            return panel;
        }
    }
}


using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.Common.DTOs.Auth;
using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.Theme;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace CinemaManagement.UI.Forms.Shared
{
    public partial class ProfileForm : Form, IStaffPage
    {
        private string _initialFullName = string.Empty;
        private string _initialPhone = string.Empty;
        private bool _isDirty;
        private bool _isLoading = true;

        public StaffPage NextPage { get; private set; } = StaffPage.Home;
        public object? NextParam => null;

        public ProfileForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            Load += async (s, e) => await LoadProfileAsync();
            FormClosing += ProfileForm_FormClosing;

            // Sự kiện thay đổi trên các ô nhập
            txtFullName.TextChanged += (s, e) => OnInputChanged();
            txtPhone.TextChanged += (s, e) => OnInputChanged();

            // Nút thao tác
            btnCancel.Click += (s, e) => HandleCancel();
            btnSave.Click += async (s, e) => await HandleSaveAsync();
            btnChangePassword.Click += (s, e) => OpenChangePassword();

            // Nút thoát ra trang chủ & Phím tắt Esc
            btnBackToHome.Click += (s, e) => HandleExitToHome();
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    HandleExitToHome();
                    e.Handled = true;
                }
            };
        }

        // ================== NẠP DỮ LIỆU ==================
        private async Task LoadProfileAsync()
        {
            _isLoading = true;
            try
            {
                var authService = Program.Services.GetRequiredService<IAuthService>();
                var profile = await authService.GetUserProfileAsync(UserSession.UserId);

                if (profile == null)
                {
                    // Fallback thông tin cơ bản từ session
                    profile = new UserProfileDto
                    {
                        EmployeeId = UserSession.UserId,
                        HoTen = UserSession.HoTen,
                        Email = UserSession.Email,
                        RoleName = UserSession.RoleName,
                        ChucVu = UserSession.RoleName,
                        NgayVaoLam = DateTime.Now,
                        TrangThaiLamViecText = "Đang làm việc"
                    };
                }

                BindProfileData(profile);
            }
            catch (Exception)
            {
                lblSaveFeedback.ForeColor = AppColors.StatusRed;
                lblSaveFeedback.Text = "⚠ Không tải được dữ liệu hồ sơ.";
                lblSaveFeedback.Visible = true;
            }
            finally
            {
                _isLoading = false;
                _isDirty = false;
                btnSave.Enabled = false;
            }
        }

        private void BindProfileData(UserProfileDto profile)
        {
            _initialFullName = profile.HoTen;
            _initialPhone = profile.SDT;

            // Thẻ tóm tắt bên trái
            lblAvatarInitial.Text = UiKit.Initials(profile.HoTen);
            lblEmployeeName.Text = profile.HoTen;
            lblPosition.Text = profile.ChucVu;
            lblEmployeeCode.Text = profile.FormattedEmployeeCode;
            lblWorkStatus.Text = $"● {profile.TrangThaiLamViecText}";
            pnlAvatar.Invalidate();

            // Thẻ chi tiết bên phải
            txtFullName.Text = profile.HoTen;
            txtPhone.Text = profile.SDT;
            txtEmail.Text = profile.Email;
            txtRole.Text = profile.RoleName;
            txtPosition.Text = profile.ChucVu;
            txtStartDate.Text = profile.NgayVaoLam.ToString("dd/MM/yyyy");
            txtWorkStatus.Text = $"● {profile.TrangThaiLamViecText}";

            // Reset trạng thái lưu
            _isDirty = false;
            btnSave.Enabled = false;
            lblSaveFeedback.Visible = false;
            ClearValidationErrors();
        }

        // ================== VALIDATION & THAY ĐỔI ==================
        private void OnInputChanged()
        {
            if (_isLoading) return;

            string currentName = txtFullName.Text.Trim();
            string currentPhone = txtPhone.Text.Trim();

            bool nameChanged = currentName != _initialFullName;
            bool phoneChanged = currentPhone != _initialPhone;
            _isDirty = nameChanged || phoneChanged;

            bool nameValid = ValidateFullName();
            bool phoneValid = ValidatePhone();

            btnSave.Enabled = _isDirty && nameValid && phoneValid;
            lblSaveFeedback.Visible = false;
        }

        private bool ValidateFullName()
        {
            string name = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                errorProviderProfile.SetError(wrapFullName, "Họ và tên không được để trống.");
                wrapFullName.BorderColor = AppColors.StatusRed;
                wrapFullName.Invalidate();
                return false;
            }

            if (name.Length > 100)
            {
                errorProviderProfile.SetError(wrapFullName, "Họ và tên không được vượt quá 100 ký tự.");
                wrapFullName.BorderColor = AppColors.StatusRed;
                wrapFullName.Invalidate();
                return false;
            }

            errorProviderProfile.SetError(wrapFullName, string.Empty);
            wrapFullName.BorderColor = txtFullName.Focused ? ColorTranslator.FromHtml("#B92F3C") : ColorTranslator.FromHtml("#453846");
            wrapFullName.Invalidate();
            return true;
        }

        private bool ValidatePhone()
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                errorProviderProfile.SetError(wrapPhone, "Số điện thoại không được để trống.");
                wrapPhone.BorderColor = AppColors.StatusRed;
                wrapPhone.Invalidate();
                return false;
            }

            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                errorProviderProfile.SetError(wrapPhone, "Số điện thoại phải có đúng 10 chữ số và bắt đầu bằng số 0.");
                wrapPhone.BorderColor = AppColors.StatusRed;
                wrapPhone.Invalidate();
                return false;
            }

            errorProviderProfile.SetError(wrapPhone, string.Empty);
            wrapPhone.BorderColor = txtPhone.Focused ? ColorTranslator.FromHtml("#B92F3C") : ColorTranslator.FromHtml("#453846");
            wrapPhone.Invalidate();
            return true;
        }

        private void ClearValidationErrors()
        {
            errorProviderProfile.SetError(wrapFullName, string.Empty);
            errorProviderProfile.SetError(wrapPhone, string.Empty);
            wrapFullName.BorderColor = ColorTranslator.FromHtml("#453846");
            wrapPhone.BorderColor = ColorTranslator.FromHtml("#453846");
            wrapFullName.Invalidate();
            wrapPhone.Invalidate();
        }

        // ================== HỦY BỎ & LƯU ==================
        private void HandleCancel()
        {
            _isLoading = true;
            txtFullName.Text = _initialFullName;
            txtPhone.Text = _initialPhone;
            ClearValidationErrors();
            _isDirty = false;
            btnSave.Enabled = false;
            lblSaveFeedback.Visible = false;
            _isLoading = false;
        }

        private async Task HandleSaveAsync()
        {
            if (!ValidateFullName() || !ValidatePhone()) return;

            string newName = txtFullName.Text.Trim();
            string newPhone = txtPhone.Text.Trim();

            btnSave.Enabled = false;
            btnSave.Text = "ĐANG LƯU...";

            try
            {
                var authService = Program.Services.GetRequiredService<IAuthService>();
                var result = await authService.UpdateProfileAsync(UserSession.UserId, newName, newPhone);

                if (!result.IsSuccess)
                {
                    lblSaveFeedback.ForeColor = AppColors.StatusRed;
                    lblSaveFeedback.Text = $"⚠ {result.ErrorMessage}";
                    lblSaveFeedback.Visible = true;
                    btnSave.Enabled = true;
                    btnSave.Text = "LƯU THAY ĐỔI";
                    return;
                }

                // Cập nhật thành công
                _initialFullName = newName;
                _initialPhone = newPhone;
                _isDirty = false;

                // Đồng bộ UserSession để toàn hệ thống phản ánh tên mới ngay lập tức
                UserSession.UpdateProfile(newName);

                // Cập nhật thẻ tóm tắt
                lblAvatarInitial.Text = UiKit.Initials(newName);
                lblEmployeeName.Text = newName;
                pnlAvatar.Invalidate();

                lblSaveFeedback.ForeColor = AppColors.Success;
                lblSaveFeedback.Text = "✓ Cập nhật hồ sơ thành công.";
                lblSaveFeedback.Visible = true;

                btnSave.Text = "LƯU THAY ĐỔI";
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                lblSaveFeedback.ForeColor = AppColors.StatusRed;
                lblSaveFeedback.Text = "⚠ Không thể cập nhật hồ sơ. Vui lòng thử lại.";
                lblSaveFeedback.Visible = true;
                btnSave.Enabled = true;
                btnSave.Text = "LƯU THAY ĐỔI";
            }
        }

        private void OpenChangePassword()
        {
            using var pwdForm = new ChangePasswordForm();
            pwdForm.ShowDialog(this);
        }

        // ================== ĐIỀU HƯỚNG & XỬ LÝ RỜI TRANG ==================
        private void HandleExitToHome()
        {
            if (ConfirmLeaveIfDirty())
            {
                _isDirty = false;
                NextPage = StaffPage.Home;
                Close();
            }
        }

        private bool ConfirmLeaveIfDirty()
        {
            if (!_isDirty) return true;

            using var confirm = new ConfirmLeaveDialog();
            var res = confirm.ShowDialog(this);
            return res == DialogResult.OK;
        }

        private void ProfileForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!ConfirmLeaveIfDirty())
            {
                e.Cancel = true;
            }
        }
    }

    /// <summary>
    /// Hộp thoại xác nhận rời trang phong cách Dark Cinema.
    /// </summary>
    internal class ConfirmLeaveDialog : Form
    {
        public ConfirmLeaveDialog()
        {
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(this.S(420), this.S(220));
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = AppColors.PageBackground;
            Padding = new Padding(this.S(2));
            ShowInTaskbar = false;

            var card = new CardPanel
            {
                Dock = DockStyle.Fill,
                Radius = 14,
                FillColor = AppColors.CardBackground,
                BorderColor = AppColors.BorderStrong,
                Padding = new Padding(this.S(26), this.S(20), this.S(26), this.S(20))
            };

            var lblTitle = new Label
            {
                Text = "⚠  THAY ĐỔI CHƯA LƯU",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.Warning,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(this.S(24), this.S(20))
            };

            var lblMsg = new Label
            {
                Text = "Bạn có thay đổi chưa được lưu.\nBạn có muốn rời khỏi trang không?",
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(this.S(24), this.S(56))
            };

            var btnStay = new PillButton
            {
                Text = "Ở LẠI",
                Radius = 10,
                NormalColor = AppColors.Surface2,
                HoverColor = UiKit.Blend(AppColors.Surface2, AppColors.Primary, 0.3f),
                BorderColor = AppColors.Border,
                ForeColor = AppColors.TextPrimary,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(110), this.S(40)),
                Location = new Point(ClientSize.Width - this.S(24) - this.S(120) - this.S(10) - this.S(110), ClientSize.Height - this.S(20) - this.S(40)),
                DialogResult = DialogResult.Cancel
            };

            var btnLeave = new PillButton
            {
                Text = "RỜI TRANG",
                Radius = 10,
                NormalColor = AppColors.Primary,
                HoverColor = AppColors.PrimaryHover,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(this.S(120), this.S(40)),
                Location = new Point(ClientSize.Width - this.S(24) - this.S(120), ClientSize.Height - this.S(20) - this.S(40)),
                DialogResult = DialogResult.OK
            };

            card.Controls.AddRange(new Control[] { lblTitle, lblMsg, btnStay, btnLeave });
            Controls.Add(card);

            AcceptButton = btnLeave;
            CancelButton = btnStay;
            ResumeLayout(false);
        }
    }
}

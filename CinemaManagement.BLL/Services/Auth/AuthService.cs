using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Auth;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<LoginResultDto>> LoginAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);

            // Không tiết lộ "email không tồn tại" hay "sai mật khẩu" riêng biệt
            // — gộp chung 1 thông báo để tránh kẻ xấu dò được email nào có trong hệ thống
            const string genericError = "Email hoặc mật khẩu không đúng.";

            if (user is null)
            {
                await LogAuditAsync(null, AuditAction.LoginFailed, $"Đăng nhập thất bại — email không tồn tại: {email}");
                return Result<LoginResultDto>.Fail(genericError);
            }

            // Kiểm tra tài khoản có đang bị khóa không
            if (user.ThoiGianKhoaDenLuc.HasValue && user.ThoiGianKhoaDenLuc.Value > DateTime.Now)
            {
                var minutesLeft = Math.Ceiling((user.ThoiGianKhoaDenLuc.Value - DateTime.Now).TotalMinutes);
                return Result<LoginResultDto>.Fail($"Tài khoản đang bị khóa tạm thời. Vui lòng thử lại sau {minutesLeft} phút.");
            }

            if (user.TrangThaiTaiKhoan == UserStatus.Disabled)
                return Result<LoginResultDto>.Fail("Tài khoản đã bị vô hiệu hóa. Liên hệ quản trị viên.");

            bool passwordCorrect = BCrypt.Net.BCrypt.Verify(password, user.MatKhauHash);

            if (!passwordCorrect)
            {
                await HandleFailedLoginAsync(user);
                await LogAuditAsync(user.Id, AuditAction.LoginFailed, "Sai mật khẩu");
                return Result<LoginResultDto>.Fail(genericError);
            }

            // Đăng nhập thành công — reset toàn bộ bộ đếm lỗi
            user.SoLanSaiMatKhau = 0;
            user.LanSaiCuoiCung = null;
            user.ThoiGianKhoaDenLuc = null;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            await LogAuditAsync(user.Id, AuditAction.Login, "Đăng nhập thành công");

            var dto = new LoginResultDto
            {
                UserId = user.Id,
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = user.Role.TenVaiTro
            };
            return Result<LoginResultDto>.Success(dto);
        }

        // Logic "progressive lockout" nằm gọn trong 1 hàm riêng — dễ Unit Test độc lập sau này
        private async Task HandleFailedLoginAsync(User user)
        {
            var now = DateTime.Now;

            // Nếu lần sai gần nhất đã quá 15 phút, coi như bắt đầu 1 chuỗi lỗi mới — reset đếm
            bool ngoaiCuaSo = user.LanSaiCuoiCung is null
                || (now - user.LanSaiCuoiCung.Value).TotalMinutes > SecurityConstants.FailedAttemptWindowMinutes;

            if (ngoaiCuaSo)
                user.SoLanSaiMatKhau = 1;
            else
                user.SoLanSaiMatKhau += 1;

            user.LanSaiCuoiCung = now;

            if (user.SoLanSaiMatKhau >= SecurityConstants.MaxFailedAttempts)
            {
                user.SoLanBiKhoa += 1;
                int lockoutMinutes = SecurityConstants.BaseLockoutMinutes * user.SoLanBiKhoa; // 15, 30, 45...
                user.ThoiGianKhoaDenLuc = now.AddMinutes(lockoutMinutes);
                user.SoLanSaiMatKhau = 0; // reset đếm sau khi đã khóa, chuẩn bị cho chu kỳ tiếp theo

                await LogAuditAsync(user.Id, AuditAction.LoginFailed,
                    $"Tài khoản bị khóa {lockoutMinutes} phút do sai mật khẩu quá {SecurityConstants.MaxFailedAttempts} lần");
            }

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task LogoutAsync(int userId)
        {
            await LogAuditAsync(userId, AuditAction.Logout, "Đăng xuất");
        }

        private async Task LogAuditAsync(int? userId, AuditAction action, string chiTiet)
        {
            await _unitOfWork.AuditLogs.AddAsync(new AuditLog
            {
                UserId = userId,
                HanhDong = action,
                ThoiGian = DateTime.Now,
                ChiTiet = chiTiet
            });
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
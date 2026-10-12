using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Auth;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

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
            var matchedEmployees = await _unitOfWork.Employees.FindAsync(emp => emp.UserId == user.Id);
            var employee = matchedEmployees.FirstOrDefault();
            var dto = new LoginResultDto
            {
                UserId = user.Id,
                Email = user.Email,
                HoTen = employee?.HoTen ?? user.Email,
                RoleId = user.RoleId,
                RoleName = user.Role.TenVaiTro,
                Permissions = user.Role.RolePermissions.Select(rp => rp.Permission.MaQuyen).ToList()
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

        public async Task<UserProfileDto?> GetUserProfileAsync(int userId)
        {
            var user = await _unitOfWork.Users.Query()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return null;

            var employee = await _unitOfWork.Employees.Query()
                .FirstOrDefaultAsync(e => e.UserId == userId);

            return new UserProfileDto
            {
                EmployeeId = employee?.Id ?? user.Id,
                HoTen = !string.IsNullOrWhiteSpace(employee?.HoTen) ? employee.HoTen : (string.IsNullOrWhiteSpace(user.Email) ? "Nhân viên" : user.Email),
                SDT = employee?.SDT ?? string.Empty,
                Email = user.Email,
                RoleName = user.Role?.TenVaiTro ?? "Nhân viên",
                ChucVu = !string.IsNullOrWhiteSpace(employee?.ChucVu) ? employee.ChucVu : (user.Role?.TenVaiTro ?? "Nhân viên"),
                NgayVaoLam = employee?.NgayVaoLam ?? user.NgayTao,
                TrangThaiLamViec = employee?.TrangThaiLamViec ?? EmployeeStatus.DangLamViec,
                TrangThaiLamViecText = employee?.TrangThaiLamViec switch
                {
                    EmployeeStatus.DangLamViec => "Đang làm việc",
                    EmployeeStatus.DaNghiViec => "Đã nghỉ việc",
                    EmployeeStatus.TamNghi => "Tạm nghỉ",
                    _ => "Đang làm việc"
                }
            };
        }

        public async Task<Result<bool>> UpdateProfileAsync(int userId, string hoTen, string sdt)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                return Result<bool>.Fail("Họ và tên không được để trống.");

            hoTen = hoTen.Trim();
            if (hoTen.Length > 100)
                return Result<bool>.Fail("Họ và tên không được vượt quá 100 ký tự.");

            sdt = sdt?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(sdt) || !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$"))
                return Result<bool>.Fail("Số điện thoại phải có đúng 10 chữ số và bắt đầu bằng số 0.");

            var employee = await _unitOfWork.Employees.Query()
                .FirstOrDefaultAsync(e => e.UserId == userId);

            if (employee == null)
            {
                employee = new Employee
                {
                    UserId = userId,
                    HoTen = hoTen,
                    SDT = sdt,
                    ChucVu = "Nhân viên",
                    NgayVaoLam = DateTime.Now,
                    TrangThaiLamViec = EmployeeStatus.DangLamViec
                };
                await _unitOfWork.Employees.AddAsync(employee);
            }
            else
            {
                employee.HoTen = hoTen;
                employee.SDT = sdt;
                _unitOfWork.Employees.Update(employee);
            }

            await _unitOfWork.SaveChangesAsync();
            await LogAuditAsync(userId, AuditAction.Update, $"Cập nhật thông tin hồ sơ: Họ tên '{hoTen}', SĐT '{sdt}'");
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(oldPassword))
                return Result<bool>.Fail("Vui lòng nhập mật khẩu hiện tại.");

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                return Result<bool>.Fail("Mật khẩu mới phải có ít nhất 6 ký tự.");

            if (oldPassword == newPassword)
                return Result<bool>.Fail("Mật khẩu mới không được trùng mật khẩu cũ.");

            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                return Result<bool>.Fail("Người dùng không tồn tại.");

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.MatKhauHash))
                return Result<bool>.Fail("Mật khẩu hiện tại không đúng.");

            user.MatKhauHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            await LogAuditAsync(user.Id, AuditAction.Update, "Đổi mật khẩu thành công");
            return Result<bool>.Success(true);
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
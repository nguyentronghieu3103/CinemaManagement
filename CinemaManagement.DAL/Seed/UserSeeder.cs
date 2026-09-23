using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Seed
{
    public static class UserSeeder
    {
        public const string DefaultAdminEmail = "admin@cinemamanagement.local";
        public const string DefaultAdminPassword = "Admin@123";   // chỉ dùng cho môi trường dev
        private static async Task SeedDemoAccountAsync(CinemaDbContext context, string email, string password, string roleName, string hoTen)
        {
            var role = await context.VaiTros.FirstAsync(r => r.TenVaiTro == roleName);

            var user = new User
            {
                Email = email,
                MatKhauHash = BCrypt.Net.BCrypt.HashPassword(password),
                RoleId = role.Id,
                TrangThaiTaiKhoan = UserStatus.Active
            };
            await context.NguoiDungs.AddAsync(user);
            await context.SaveChangesAsync();

            await context.NhanViens.AddAsync(new Employee
            {
                UserId = user.Id,
                HoTen = hoTen,
                SDT = "0900000001",
                NgayVaoLam = DateTime.Now,
                ChucVu = roleName,
                TrangThaiLamViec = EmployeeStatus.DangLamViec
            });
            await context.SaveChangesAsync();
        }
        public static async Task SeedAsync(CinemaDbContext context)
        {
            if (await context.NguoiDungs.AnyAsync()) return;

            var adminRole = await context.VaiTros.FirstAsync(r => r.TenVaiTro == RoleSeeder.QuanTriVien);

            var admin = new User
            {
                Email = DefaultAdminEmail,
                MatKhauHash = BCrypt.Net.BCrypt.HashPassword(DefaultAdminPassword),
                RoleId = adminRole.Id,
                TrangThaiTaiKhoan = UserStatus.Active
            };
            await context.NguoiDungs.AddAsync(admin);
            await context.SaveChangesAsync();
            await SeedDemoAccountAsync(context, "manager@cinemamanagement.local", "Manager@123", RoleSeeder.QuanLy, "Quản lý Demo");
            await SeedDemoAccountAsync(context, "cashier@cinemamanagement.local", "Cashier@123", RoleSeeder.NhanVienBanVe, "Thu Ngân Demo");
            // User 1-1 Employee — admin cũng có hồ sơ nhân sự như mọi tài khoản khác
            await context.NhanViens.AddAsync(new Employee
            {
                UserId = admin.Id,
                HoTen = "Quản trị viên hệ thống",
                SDT = "0900000000",
                NgayVaoLam = DateTime.Now,
                ChucVu = "Admin",
                TrangThaiLamViec = EmployeeStatus.DangLamViec
            });
            await context.SaveChangesAsync();
        }

    }
}
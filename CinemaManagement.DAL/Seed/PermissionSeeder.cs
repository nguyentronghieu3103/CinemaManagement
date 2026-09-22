using CinemaManagement.Common.Constants;
using CinemaManagement.Common.Entities;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Seed
{
    public static class PermissionSeeder
    {
        public static async Task SeedAsync(CinemaDbContext context)
        {
            if (await context.Quyens.AnyAsync()) return;

            var permissions = new List<Permission>
            {
                new() { MaQuyen = PermissionConstants.TICKET_SELL, TenQuyen = "Bán vé" },
                new() { MaQuyen = PermissionConstants.CHECKIN, TenQuyen = "Check-in vé" },
                new() { MaQuyen = PermissionConstants.CUSTOMER_CREATE, TenQuyen = "Tạo khách hàng" },
                new() { MaQuyen = PermissionConstants.MOVIE_MANAGE, TenQuyen = "Quản lý phim" },
                new() { MaQuyen = PermissionConstants.ROOM_MANAGE, TenQuyen = "Quản lý phòng chiếu" },
                new() { MaQuyen = PermissionConstants.SHOWTIME_MANAGE, TenQuyen = "Quản lý suất chiếu" },
                new() { MaQuyen = PermissionConstants.COMBO_MANAGE, TenQuyen = "Quản lý combo" },
                new() { MaQuyen = PermissionConstants.REPORT_VIEW, TenQuyen = "Xem báo cáo doanh thu" },
                new() { MaQuyen = PermissionConstants.IMPORT_MOVIE, TenQuyen = "Import dữ liệu phim" },
                new() { MaQuyen = PermissionConstants.EMPLOYEE_VIEW_PERFORMANCE, TenQuyen = "Xem hiệu suất nhân viên" },
                new() { MaQuyen = PermissionConstants.STAFF_ACCOUNT_MANAGE, TenQuyen = "Quản lý tài khoản nhân viên bán vé" },
                new() { MaQuyen = PermissionConstants.USER_MANAGE_ALL, TenQuyen = "Quản lý mọi tài khoản" },
                new() { MaQuyen = PermissionConstants.CONFIG_MANAGE, TenQuyen = "Cấu hình hệ thống" },
                new() { MaQuyen = PermissionConstants.AUDITLOG_VIEW, TenQuyen = "Xem nhật ký hệ thống" },
            };

            await context.Quyens.AddRangeAsync(permissions);
            await context.SaveChangesAsync();

            await SeedRolePermissionsAsync(context);
        }

        // Gán quyền cho từng vai trò — đúng theo Ma trận RBAC Phần 5.2
        private static async Task SeedRolePermissionsAsync(CinemaDbContext context)
        {
            var roles = await context.VaiTros.ToListAsync();
            var perms = await context.Quyens.ToListAsync();

            int RoleId(string name) => roles.First(r => r.TenVaiTro == name).Id;
            int PermId(string code) => perms.First(p => p.MaQuyen == code).Id;

            var mappings = new List<RolePermission>();

            // Nhân viên bán vé — chỉ nghiệp vụ bán vé cơ bản
            foreach (var code in new[] { PermissionConstants.TICKET_SELL, PermissionConstants.CHECKIN, PermissionConstants.CUSTOMER_CREATE })
                mappings.Add(new RolePermission { RoleId = RoleId(RoleSeeder.NhanVienBanVe), PermissionId = PermId(code) });

            // Quản lý — kế thừa Nhân viên + quyền quản lý nghiệp vụ
            foreach (var code in new[]
            {
                PermissionConstants.TICKET_SELL, PermissionConstants.CHECKIN, PermissionConstants.CUSTOMER_CREATE,
                PermissionConstants.MOVIE_MANAGE, PermissionConstants.ROOM_MANAGE, PermissionConstants.SHOWTIME_MANAGE,
                PermissionConstants.COMBO_MANAGE, PermissionConstants.REPORT_VIEW, PermissionConstants.IMPORT_MOVIE,
                PermissionConstants.EMPLOYEE_VIEW_PERFORMANCE, PermissionConstants.STAFF_ACCOUNT_MANAGE
            })
                mappings.Add(new RolePermission { RoleId = RoleId(RoleSeeder.QuanLy), PermissionId = PermId(code) });

            // Quản trị viên — toàn quyền
            foreach (var p in perms)
                mappings.Add(new RolePermission { RoleId = RoleId(RoleSeeder.QuanTriVien), PermissionId = p.Id });

            await context.VaiTroQuyens.AddRangeAsync(mappings);
            await context.SaveChangesAsync();
        }
    }
}
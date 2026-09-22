using CinemaManagement.Common.Entities;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Seed
{
    public static class RoleSeeder
    {
        public const string NhanVienBanVe = "NhanVienBanVe";
        public const string QuanLy = "QuanLy";
        public const string QuanTriVien = "QuanTriVien";

        public static async Task SeedAsync(CinemaDbContext context)
        {
            if (await context.VaiTros.AnyAsync()) return;   

            await context.VaiTros.AddRangeAsync(
                new Role { TenVaiTro = NhanVienBanVe },
                new Role { TenVaiTro = QuanLy },
                new Role { TenVaiTro = QuanTriVien }
            );
            await context.SaveChangesAsync();
        }
    }
}
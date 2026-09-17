using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Context
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<User> NguoiDungs => Set<User>();
        public DbSet<Role> VaiTros => Set<Role>();
        public DbSet<Permission> Quyens => Set<Permission>();
        public DbSet<RolePermission> VaiTroQuyens => Set<RolePermission>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
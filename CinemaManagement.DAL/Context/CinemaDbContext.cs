using CinemaApp.Common.Entities;
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
        public DbSet<Movie> Phims => Set<Movie>();
        public DbSet<Genre> TheLoais => Set<Genre>();
        public DbSet<MovieGenre> PhimTheLoais => Set<MovieGenre>();
        public DbSet<CinemaRoom> PhongChieus => Set<CinemaRoom>();
        public DbSet<Seat> Ghes => Set<Seat>();
        public DbSet<SeatTypeSurcharge> LoaiGhePhuThus => Set<SeatTypeSurcharge>();
        public DbSet<Showtime> SuatChieus => Set<Showtime>();
        public DbSet<SeatShowtimeStatus> TrangThaiGheTheoSuats => Set<SeatShowtimeStatus>();
        public DbSet<Customer> KhachHangs => Set<Customer>();
        public DbSet<Combo> Combos => Set<Combo>();
        public DbSet<Invoice> HoaDons => Set<Invoice>();
        public DbSet<InvoiceCombo> HoaDonCombos => Set<InvoiceCombo>();
        public DbSet<Ticket> Ves => Set<Ticket>();
        public DbSet<Payment> GiaoDichThanhToans => Set<Payment>();
        public DbSet<EmailLog> LichSuGuiEmails => Set<EmailLog>();
        public DbSet<AuditLog> NhatKyHeThongs => Set<AuditLog>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
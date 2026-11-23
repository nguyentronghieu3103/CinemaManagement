using Cinema.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Data;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
    {
    }

    public DbSet<SystemConfig> SystemConfigs => Set<SystemConfig>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    public DbSet<Auditorium> Auditoriums => Set<Auditorium>();
    public DbSet<SeatType> SeatTypes => Set<SeatType>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Showtime> Showtimes => Set<Showtime>();
    public DbSet<Concession> Concessions => Set<Concession>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<OrderConcession> OrderConcessions => Set<OrderConcession>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<RefundRequest> RefundRequests => Set<RefundRequest>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. SystemConfigs
        modelBuilder.Entity<SystemConfig>(entity =>
        {
            entity.HasKey(e => e.ConfigKey);
            entity.Property(e => e.ConfigKey).HasMaxLength(50);
            entity.Property(e => e.ConfigValue).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        // 2. Roles
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId);
            entity.HasIndex(e => e.RoleName).IsUnique();
            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        // 3. Users
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.Username).IsUnique();
            entity.Property(e => e.Username).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(256).IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsUnicode(false);

            entity.HasOne(e => e.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(e => e.RoleId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 4. Memberships
        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId);
            entity.HasIndex(e => e.CardNumber).IsUnique();
            entity.HasIndex(e => e.PhoneNumber).IsUnique();
            entity.Property(e => e.CardNumber).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.TierLevel).HasMaxLength(30);
            entity.Property(e => e.TotalSpent).HasPrecision(18, 2);
        });

        // 5. Genres
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId);
            entity.HasIndex(e => e.GenreName).IsUnique();
            entity.Property(e => e.GenreName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        // 6. Movies
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.EnglishTitle).HasMaxLength(200);
            entity.Property(e => e.Director).HasMaxLength(150);
            entity.Property(e => e.Cast).HasMaxLength(500);
            entity.Property(e => e.AgeRating).HasMaxLength(10);
            entity.Property(e => e.Language).HasMaxLength(50);
            entity.Property(e => e.Subtitle).HasMaxLength(50);
            entity.Property(e => e.PosterUrl).HasMaxLength(500);
            entity.Property(e => e.TrailerUrl).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(30);
        });

        // 7. MovieGenres (Many-to-Many)
        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasKey(mg => new { mg.MovieId, mg.GenreId });

            entity.HasOne(mg => mg.Movie)
                  .WithMany(m => m.MovieGenres)
                  .HasForeignKey(mg => mg.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(mg => mg.Genre)
                  .WithMany(g => g.MovieGenres)
                  .HasForeignKey(mg => mg.GenreId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 8. Auditoriums
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.AuditoriumId);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ScreenType).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(30);
        });

        // 9. SeatTypes
        modelBuilder.Entity<SeatType>(entity =>
        {
            entity.HasKey(e => e.SeatTypeId);
            entity.HasIndex(e => e.TypeName).IsUnique();
            entity.Property(e => e.TypeName).HasMaxLength(50);
            entity.Property(e => e.ColorCode).HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.SurchargeAmount).HasPrecision(18, 2);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        // 10. Seats
        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId);
            entity.HasIndex(e => new { e.AuditoriumId, e.SeatCode }).IsUnique();
            entity.Property(e => e.SeatRow).HasMaxLength(5).IsUnicode(false);
            entity.Property(e => e.SeatCode).HasMaxLength(10).IsUnicode(false);

            entity.HasOne(e => e.Auditorium)
                  .WithMany(a => a.Seats)
                  .HasForeignKey(e => e.AuditoriumId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.SeatType)
                  .WithMany(st => st.Seats)
                  .HasForeignKey(e => e.SeatTypeId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 11. Showtimes
        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.ShowtimeId);
            entity.Property(e => e.BasePrice).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasMaxLength(30);

            entity.HasOne(e => e.Movie)
                  .WithMany(m => m.Showtimes)
                  .HasForeignKey(e => e.MovieId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Auditorium)
                  .WithMany(a => a.Showtimes)
                  .HasForeignKey(e => e.AuditoriumId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 12. Concessions
        modelBuilder.Entity<Concession>(entity =>
        {
            entity.HasKey(e => e.ConcessionId);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(30);
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            entity.Property(e => e.CostPrice).HasPrecision(18, 2);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
        });

        // 13. Orders
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.HasIndex(e => e.OrderCode).IsUnique();
            entity.Property(e => e.OrderCode).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.SubTotal).HasPrecision(18, 2);
            entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);
            entity.Property(e => e.FinalAmount).HasPrecision(18, 2);
            entity.Property(e => e.PaymentMethod).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.PaymentStatus).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(255);

            entity.HasOne(e => e.Membership)
                  .WithMany(m => m.Orders)
                  .HasForeignKey(e => e.MembershipId)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.StaffUser)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(e => e.StaffUserId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // 14. Tickets
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId);
            entity.HasIndex(e => e.Barcode).IsUnique();
            entity.Property(e => e.Barcode).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.TicketPrice).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasMaxLength(30).IsUnicode(false);

            // Double-booking prevention Filtered Index
            entity.HasIndex(e => new { e.ShowtimeId, e.SeatId })
                  .IsUnique()
                  .HasFilter("[Status] <> 'REFUNDED' AND [Status] <> 'CANCELLED'");

            entity.HasOne(e => e.Order)
                  .WithMany(o => o.Tickets)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Showtime)
                  .WithMany(s => s.Tickets)
                  .HasForeignKey(e => e.ShowtimeId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Seat)
                  .WithMany(s => s.Tickets)
                  .HasForeignKey(e => e.SeatId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 15. OrderConcessions
        modelBuilder.Entity<OrderConcession>(entity =>
        {
            entity.HasKey(e => e.OrderConcessionId);
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            entity.Property(e => e.TotalPrice).HasPrecision(18, 2);

            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderConcessions)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Concession)
                  .WithMany(c => c.OrderConcessions)
                  .HasForeignKey(e => e.ConcessionId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 16. Shifts
        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId);
            entity.Property(e => e.ShiftName).HasMaxLength(50);
            entity.Property(e => e.InitialCash).HasPrecision(18, 2);
            entity.Property(e => e.FinalCash).HasPrecision(18, 2);
            entity.Property(e => e.TotalSales).HasPrecision(18, 2);
            entity.Property(e => e.CashDifference).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(255);

            entity.HasOne(e => e.User)
                  .WithMany(u => u.Shifts)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 17. RefundRequests
        modelBuilder.Entity<RefundRequest>(entity =>
        {
            entity.HasKey(e => e.RefundId);
            entity.Property(e => e.RefundReason).HasMaxLength(255);
            entity.Property(e => e.RefundAmount).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(255);

            entity.HasOne(e => e.Order)
                  .WithMany(o => o.RefundRequests)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Ticket)
                  .WithMany(t => t.RefundRequests)
                  .HasForeignKey(e => e.TicketId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ProcessedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.ProcessedByUserId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // 18. AuditLogs
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId);
            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.TableName).HasMaxLength(50);
            entity.Property(e => e.RecordId).HasMaxLength(50);
            entity.Property(e => e.IpAddress).HasMaxLength(45).IsUnicode(false);
        });
    }
}

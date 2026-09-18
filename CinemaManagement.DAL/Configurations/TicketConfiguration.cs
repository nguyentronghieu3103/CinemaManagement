using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ve");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.GiaVe).HasColumnType("decimal(10,2)");
        builder.Property(t => t.MaQR).IsRequired();
        builder.HasIndex(t => t.MaQR).IsUnique();

        // 1 ghế trong 1 suất chiếu chỉ được bán đúng 1 lần — chặn double-booking ở tầng DB
        builder.HasIndex(t => new { t.ShowtimeId, t.SeatId }).IsUnique();

        builder.HasOne(t => t.Invoice)
               .WithMany(i => i.Tickets)
               .HasForeignKey(t => t.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Showtime)
               .WithMany()
               .HasForeignKey(t => t.ShowtimeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Seat)
               .WithMany()
               .HasForeignKey(t => t.SeatId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
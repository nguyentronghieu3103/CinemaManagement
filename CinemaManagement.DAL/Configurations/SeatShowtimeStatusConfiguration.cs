using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SeatShowtimeStatusConfiguration : IEntityTypeConfiguration<SeatShowtimeStatus>
{
    public void Configure(EntityTypeBuilder<SeatShowtimeStatus> builder)
    {
        builder.ToTable("TrangThaiGheTheoSuat");
        builder.HasKey(x => new { x.ShowtimeId, x.SeatId });   

        builder.HasOne(x => x.Showtime)
               .WithMany(s => s.SeatStatuses)
               .HasForeignKey(x => x.ShowtimeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Seat)
               .WithMany()
               .HasForeignKey(x => x.SeatId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
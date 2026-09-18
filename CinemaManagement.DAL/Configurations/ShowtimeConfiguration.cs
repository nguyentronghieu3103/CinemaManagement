using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
{
    public void Configure(EntityTypeBuilder<Showtime> builder)
    {
        builder.ToTable("SuatChieu");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.GiaVeCoSo).HasColumnType("decimal(10,2)");

        builder.HasOne(s => s.Movie)
               .WithMany(m => m.Showtimes)
               .HasForeignKey(s => s.MovieId)
               .OnDelete(DeleteBehavior.Restrict);  
        builder.HasOne(s => s.CinemaRoom)
               .WithMany(r => r.Showtimes)
               .HasForeignKey(s => s.CinemaRoomId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
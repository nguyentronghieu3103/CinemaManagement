using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CinemaRoomConfiguration : IEntityTypeConfiguration<CinemaRoom>
{
    public void Configure(EntityTypeBuilder<CinemaRoom> builder)
    {
        builder.ToTable("PhongChieu");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.TenPhong).IsRequired().HasMaxLength(100);
        builder.HasIndex(r => r.TenPhong).IsUnique();
    }
}
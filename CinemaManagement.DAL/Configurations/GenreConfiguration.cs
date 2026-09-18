using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("TheLoai");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.TenTheLoai).IsRequired().HasMaxLength(50);
        builder.HasIndex(g => g.TenTheLoai).IsUnique();
    }
}
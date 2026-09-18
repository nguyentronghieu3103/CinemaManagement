using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaManagement.DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Phim");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.TenPhim).IsRequired().HasMaxLength(200);
            builder.Property(m => m.DaoDien).HasMaxLength(150);
            builder.Property(m => m.DienVien).HasMaxLength(500);
        }
    }
}
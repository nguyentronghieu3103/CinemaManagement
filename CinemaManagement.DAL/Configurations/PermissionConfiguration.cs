using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Quyen");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.MaQuyen).IsRequired().HasMaxLength(50);
        builder.HasIndex(p => p.MaQuyen).IsUnique();
    }
}
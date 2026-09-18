using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ComboConfiguration : IEntityTypeConfiguration<Combo>
{
    public void Configure(EntityTypeBuilder<Combo> builder)
    {
        builder.ToTable("Combo");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.TenCombo).IsRequired().HasMaxLength(150);
        builder.Property(c => c.Gia).HasColumnType("decimal(10,2)");
    }
}
using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("KhachHang");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.HoTen).IsRequired().HasMaxLength(150);
        builder.Property(c => c.SDT).IsRequired().HasMaxLength(15);
        builder.HasIndex(c => c.SDT).IsUnique();       
    }
}
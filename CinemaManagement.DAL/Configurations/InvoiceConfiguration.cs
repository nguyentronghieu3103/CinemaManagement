using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("HoaDon");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.TongTien).HasColumnType("decimal(10,2)");

        builder.HasOne(i => i.User)
               .WithMany()
               .HasForeignKey(i => i.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Customer)
               .WithMany()
               .HasForeignKey(i => i.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
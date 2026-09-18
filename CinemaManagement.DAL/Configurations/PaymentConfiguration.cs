using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("GiaoDichThanhToan");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.SoTien).HasColumnType("decimal(10,2)");
        builder.Property(p => p.NoiDungIPN).HasColumnType("text");   // callback raw có thể dài

        builder.HasOne(p => p.Invoice)
               .WithMany()
               .HasForeignKey(p => p.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
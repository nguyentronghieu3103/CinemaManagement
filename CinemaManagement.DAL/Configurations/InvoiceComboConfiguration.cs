using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceComboConfiguration : IEntityTypeConfiguration<InvoiceCombo>
{
    public void Configure(EntityTypeBuilder<InvoiceCombo> builder)
    {
        builder.ToTable("HoaDonCombo");
        builder.HasKey(ic => new { ic.InvoiceId, ic.ComboId });
        builder.Property(ic => ic.DonGiaLucMua).HasColumnType("decimal(10,2)");

        builder.HasOne(ic => ic.Invoice)
               .WithMany(i => i.InvoiceCombos)
               .HasForeignKey(ic => ic.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ic => ic.Combo)
               .WithMany()
               .HasForeignKey(ic => ic.ComboId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
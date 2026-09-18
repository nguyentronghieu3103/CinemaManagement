using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
{
    public void Configure(EntityTypeBuilder<EmailLog> builder)
    {
        builder.ToTable("LichSuGuiEmail");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.DiaChiNhan).IsRequired().HasMaxLength(200);

        builder.HasOne(e => e.Invoice)
               .WithMany()
               .HasForeignKey(e => e.InvoiceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
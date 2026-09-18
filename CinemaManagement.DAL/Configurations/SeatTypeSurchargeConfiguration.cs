using CinemaApp.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SeatTypeSurchargeConfiguration : IEntityTypeConfiguration<SeatTypeSurcharge>
{
    public void Configure(EntityTypeBuilder<SeatTypeSurcharge> builder)
    {
        builder.ToTable("LoaiGhePhuThu");
        builder.HasKey(s => s.LoaiGhe);
        builder.Property(s => s.SoTienPhuThu).HasColumnType("decimal(10,2)");
    }
}
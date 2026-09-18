using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Ghe");
        builder.HasKey(s => s.Id);

        // 1 phòng không được có 2 ghế trùng vị trí Hàng+Cột
        builder.HasIndex(s => new { s.CinemaRoomId, s.Hang, s.Cot }).IsUnique();

        builder.HasOne(s => s.CinemaRoom)
               .WithMany(r => r.Seats)
               .HasForeignKey(s => s.CinemaRoomId)
               .OnDelete(DeleteBehavior.Cascade);   // xóa phòng thì xóa hết ghế trong phòng
    }
}
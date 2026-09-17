using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("NguoiDung");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.MatKhauHash).IsRequired();

        builder.HasOne(u => u.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
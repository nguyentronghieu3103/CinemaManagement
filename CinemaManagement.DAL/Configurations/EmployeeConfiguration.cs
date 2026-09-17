using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("NhanVien");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.HoTen).IsRequired().HasMaxLength(150);
            builder.Property(e => e.SDT).IsRequired().HasMaxLength(15);
            builder.Property(e => e.ChucVu).HasMaxLength(100);
            builder.HasIndex(e => e.UserId).IsUnique();
            builder.HasOne(e => e.User)
                   .WithOne()
                   .HasForeignKey<Employee>(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
using CinemaManagement.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.ToTable("Phim_TheLoai");
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });   // composite key

        builder.HasOne(mg => mg.Movie)
               .WithMany(m => m.MovieGenres)
               .HasForeignKey(mg => mg.MovieId);

        builder.HasOne(mg => mg.Genre)
               .WithMany(g => g.MovieGenres)
               .HasForeignKey(mg => mg.GenreId);
    }
}
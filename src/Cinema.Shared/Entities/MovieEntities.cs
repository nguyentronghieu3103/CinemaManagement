namespace Cinema.Shared.Entities;

public class Genre
{
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? EnglishTitle { get; set; }
    public string? Director { get; set; }
    public string? Cast { get; set; }
    public int DurationMinutes { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string AgeRating { get; set; } = "P";
    public string Language { get; set; } = "Tiếng Việt";
    public string? Subtitle { get; set; }
    public string? PosterUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = "NowShowing";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}

public class MovieGenre
{
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }

    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
}

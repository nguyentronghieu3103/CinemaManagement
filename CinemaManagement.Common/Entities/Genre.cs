namespace CinemaManagement.Common.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string TenTheLoai { get; set; } = string.Empty;

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
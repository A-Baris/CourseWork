namespace MoviePage.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int PublishedDate { get; set; }
        public string Description { get; set; }
        public string? TrailerHttp { get; set; }
        public int? DirectorId { get; set; }
        public Director Director { get; set; }
        public List<MovieAndCategory> MovieAndCategories { get; set; }
        public List<MovieAndCast> MovieAndCasts { get; set; }

    }
}

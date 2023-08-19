namespace MoviePage.Models
{
    public class MovieAndCategory
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public Movie Movie { get; set; }
        public Category Category { get; set; }
    }
}

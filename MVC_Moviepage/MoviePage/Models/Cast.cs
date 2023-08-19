namespace MoviePage.Models
{
    public class Cast
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MovieAndCast> MovieAndCasts { get; set; }
    }
}

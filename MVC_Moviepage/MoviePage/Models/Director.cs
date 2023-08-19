namespace MoviePage.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

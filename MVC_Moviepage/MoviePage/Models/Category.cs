namespace MoviePage.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<MovieAndCategory> MovieAndCategories { get; set; }
    }
}

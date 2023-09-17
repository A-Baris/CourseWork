namespace NLayer.Core.Entity
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public int Height { get; set; }
        public int Widht { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

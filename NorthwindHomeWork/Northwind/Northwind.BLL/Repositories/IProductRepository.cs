using NorthwindAPI.DTOs;

namespace Northwind.BLL.Repositories
{
    public interface IProductRepository
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        string DeleteProduct(int id);
        ProductDTO UpdateProduct(int id);
        List<ProductDTO> GetProductsByCategory(string cname);
    }
}

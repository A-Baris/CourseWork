using Northwind.BLL.DTOs;

namespace NorthwindAPI.Repositories
{
    public interface ICategoryRepository    
    {
        List<CategoryDTO> GetAllCategories();
    }
}

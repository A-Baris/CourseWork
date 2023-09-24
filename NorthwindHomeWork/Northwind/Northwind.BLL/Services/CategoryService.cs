using Northwind.BLL.DTOs;
using Northwind.DAL.Models;
using Northwind.DAL.Models.Context;
using Northwind.BLL.Repositories;
using NorthwindAPI.Repositories;

namespace NorthwindAPI.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryService(NorthwindContext context)
        {
            _context = context;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var categories =from c in _context.Categories
                                 select new CategoryDTO
                                 {
                                     CategoryId = c.CategoryId,
                                     CategoryName = c.CategoryName,
                                     Description = c.Description
        };
            return categories.ToList();
        }
    }
}

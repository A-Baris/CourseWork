using Northwind.BLL.DTOs;
using Northwind.DAL.Models;
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
            var categories = from c in _context.Categories
                             select new CategoryDTO
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 Description = c.Description
                             };
            return categories.ToList();
        }

        public IEnumerable<CategoryBestSellerDTO> GetBestSellerCategories()
        {
//            select CategoryName, Count(CategoryName) as 'Total' from Categories c
//join Products p on c.CategoryID = p.CategoryID
//join [Order Details] od on p.ProductID = od.ProductID group by CategoryName order by Total desc



            var bestSellerCategories = from c in _context.Categories
                                       join p in _context.Products on c.CategoryId equals p.CategoryId
                                       join od in _context.OrderDetails on p.ProductId equals od.ProductId
                                       group c by c.CategoryName into grouped
                                       orderby grouped.Count() descending
                                       select new CategoryBestSellerDTO
                                       {
                                           CategoryName = grouped.Key,
                                           Total = grouped.Count()
                                       };
            return bestSellerCategories.ToList();





        }
    }
}

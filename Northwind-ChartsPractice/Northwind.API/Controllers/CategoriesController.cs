using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        [Route("listcategories")]
        public IActionResult ListCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet]
        [Route("bestsellercategories")]
        public IActionResult BestSellerCategories()
        {
            var bestSellerCategories = _categoryRepository.GetBestSellerCategories();
            return Ok(bestSellerCategories);
        }

    }
}

using ECommerce.BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;


        public HomeController(ICategoryService categoryService, IProductService productService)
        {
           _categoryService = categoryService;
            _productService = productService;
           
        }

        public IProductService ProductService { get; }

        public IActionResult Index()
        {
            var category = _categoryService.GetCategories().ToList(); //tested and data comes from Database clearly.
            return View(category);
        }
    }
}

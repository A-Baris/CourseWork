using ECommerce.BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;

        public HomeController(ICategoryService categoryService, IProductService productService,ISupplierService supplierService)
        {
           _categoryService = categoryService;
            _productService = productService;
            _supplierService = supplierService;
        }

        public IProductService ProductService { get; }

        public IActionResult Index()
        {
            ViewBag.ProductList=_productService.GetProducts();
            ViewBag.SupplierList=_supplierService.GetAllSuppliers();
            var category = _categoryService.GetCategories().ToList(); //tested and data comes from Database clearly.
            return View(category);
        }
    }
}

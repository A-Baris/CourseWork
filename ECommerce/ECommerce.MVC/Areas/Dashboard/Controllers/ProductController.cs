using ECommerce.BLL.AbstractServices;
using ECommerce.Entity.Entity;
using ECommerce.MVC.Areas.Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductController(IProductService productService,ICategoryService categoryService,ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }
        public IActionResult Index()
        {
           ViewBag.OfflineProduct=_productService.GetOfflineProducts();
            ViewBag.SupplierList = _supplierService.GetAllSuppliers();
            ViewBag.CategoryList=_categoryService.GetAllCategories();
            return View(_productService.GetAllProducts());
        }
        public IActionResult Create()
        {
            ViewBag.CategoryList = _categoryService.GetAllCategories();
            ViewBag.SupplierList=_supplierService.GetAllSuppliers();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {

            
            int selectedCategoryId = productVM.CategoryId; //select options'dan gelen category ıd tutuluyor
            int selectedSupplierId = productVM.SupplierId; //select options'dan gelen supplier ıd tutuluyor

            if (ModelState.IsValid)
                {
                    Product product = new Product()
                    {
                        ProductName = productVM.ProductName,
                        Description = productVM.Description,
                        UnitPrice = productVM.UnitPrice,
                        CategoryId = selectedCategoryId, 
                        SupplierId = selectedSupplierId,
                        UnitsInStock = productVM.UnitsInStock,
                        ImagePath = productVM.ImagePath,
                    };

                    _productService.Create(product);
                TempData["result"] = "Product is created successfully!";
                return RedirectToAction("Index"); 
                }
                else
            { 
              
                return View();
            }



        }
        public IActionResult Update(int id)
        {
            ViewBag.SupplierList = _supplierService.GetAllSuppliers();
            ViewBag.CategoryList = _categoryService.GetAllCategories();
            var product = _productService.GetbyId(id);
            var updated = new ProductVM
            {
                Id = id,
                ProductName = product.ProductName,
                Description = product.Description,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                ImagePath = product.ImagePath,

            };

            return View(updated);

        }
        [HttpPost]
        public IActionResult Update(ProductVM product)
        {
            ViewBag.SupplierList = _supplierService.GetAllSuppliers();
            int selectedCategoryId = product.CategoryId; //select options'dan gelen category ıd tutuluyor
            int selectedSupplierId = product.SupplierId; //select options'dan gelen supplier ıd tutuluyor
            if (ModelState.IsValid)
            {
                var productUpdate = new Product
                {
                    Id=product.Id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    CategoryId=selectedCategoryId,
                    SupplierId = selectedSupplierId,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    ImagePath = product.ImagePath,
                };
                var result = _productService.Update(productUpdate);
                TempData["result"] = "Product is updated successfully!";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View("Index");
            }
          

        }
        public IActionResult Delete(int id) 
        {
            var result = _productService.Delete(id);
            TempData["Result"] = "Product is deleted successfully";
            return RedirectToAction("Index","Product"); 
        
        }


    }
}

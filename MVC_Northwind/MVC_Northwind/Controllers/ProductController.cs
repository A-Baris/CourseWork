using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Northwind.Models.Entity;

namespace MVC_Northwind.Controllers
{
    public class ProductController : Controller
    {
        NorthwindContext db = new NorthwindContext();
        [Authorize]
        public IActionResult Index()
        {
            var categoryList = db.Categories.ToList();
            var productList = db.Products.ToList();

            return View(productList);
            
        }
        public IActionResult Details(int id)
        {
            var productX = db.Products.Find(id);
            var category = db.Categories.ToList();
            var supplier = db.Suppliers.ToList();
            return View(productX);
        }
    }
}

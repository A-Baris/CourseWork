using ECommerce.BLL.AbstractServices;
using ECommerce.BLL.Services;
using ECommerce.Entity.Entity;
using ECommerce.MVC.Areas.Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ECommerce.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public IActionResult Index()
        {
            ViewBag.SupplierOffline=_supplierService.GetOfflineSuppliers();
            return View(_supplierService.GetAllSuppliers());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(SupplierVM supplierVM)
        {
            if(ModelState.IsValid)
            {
                Supplier supplier = new Supplier()
                {
                    CompanyName = supplierVM.CompanyName,
                    ContactName = supplierVM.ContactName,
                    ContactTitle = supplierVM.ContactTitle,
                    Adress = supplierVM.Adress,
                    Country = supplierVM.Country,
                    PhoneNumber = supplierVM.PhoneNumber,
                };
                _supplierService.Create(supplier);
                TempData["result"] = "Supplier is created successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
            
        }
        public IActionResult Update(int id)
        {
            var result = _supplierService.GetbyId(id);
            var updated = new Supplier()
            {
                Id = id,
                CompanyName = result.CompanyName,
                ContactName = result.ContactName,
                ContactTitle = result.ContactTitle,
                PhoneNumber = result.PhoneNumber,
                Adress = result.Adress,
                Country = result.Country,

            };
            return View(updated);
        }
        [HttpPost]
        public IActionResult Update(SupplierVM supplierVM)
        {
            if (ModelState.IsValid)
            {
                Supplier supplier = new Supplier()
                {
                    Id=supplierVM.Id,
                    CompanyName = supplierVM.CompanyName,
                    ContactName = supplierVM.ContactName,
                    ContactTitle = supplierVM.ContactTitle,
                    Adress = supplierVM.Adress,
                    Country = supplierVM.Country,
                    PhoneNumber = supplierVM.PhoneNumber,
                };
                _supplierService.Update(supplier);
                TempData["result"] = "Supplier is updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
          
        }
        public IActionResult Delete(int id)
        {
            var result = _supplierService.Delete(id);
            TempData["Result"] = "Supplier is deleted successfully";
            return RedirectToAction("Index", "Supplier");
           
        }
    }
}

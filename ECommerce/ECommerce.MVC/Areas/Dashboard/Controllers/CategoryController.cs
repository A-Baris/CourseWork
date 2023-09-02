using ECommerce.BLL.AbstractServices;
using ECommerce.Entity.Entity;
using ECommerce.MVC.Areas.Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }




        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM )
        {
            if (ModelState.IsValid)
            {

               
                var category = new Category
                {
                    CategoryName = categoryVM.CategoryName,
                    Description = categoryVM.Description,
                };

               var result= _categoryService.Create(category);


                //todo: result içerisinden dönen değer başarılı mı yoksa hata mı olduğunu bilemiyoruz. Bu yüzden dönen mesajlara ait bir enum oluşturulursa daha efektif olur.
                TempData["Result"] = "Category is Created successfully";


                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryVM);
            }
            
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetbyId(id);
            var updated = new CategoryUpdateVM
            {
                Id=category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description,
            };

            return View(updated);
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateVM updated)
        {
            if (ModelState.IsValid)
            {
                //todo: veri güncellenmek istenildiğinde constructor tarafında bulunan Created ile başlayan propertyler o anki tarih ve saat ile değiştiriliyor. Bu durumda veri güncellendiğinde aynı zamanda veri oluşturulmuşcasına tarihleri aynı olarak atanıyor. Bu sorun giderilecek.
                var categoryUpdate = new Category
                {
                    Id = updated.Id,
                    CategoryName = updated.CategoryName,
                    Description = updated.Description,
                };


                var result = _categoryService.Update(categoryUpdate);
                TempData["Result"] = "Category is Updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(updated);
            }
            
        }

       public IActionResult Delete(int id)
        {
            var result=_categoryService.Delete(id);

            TempData["Result"]= "Category is deleted successfully"; ;
            return RedirectToAction("Index");
        }
        


    }
}

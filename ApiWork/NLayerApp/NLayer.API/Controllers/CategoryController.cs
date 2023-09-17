using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.Core.Repositories;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
       
     public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("[action]")]
        public async Task  <IActionResult> GetsingleCategoryByIdWithProductAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetsingleCategoryByIdWithProductAsync(categoryId));
        }
    }
}

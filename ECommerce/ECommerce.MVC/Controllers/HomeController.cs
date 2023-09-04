using ECommerce.BLL.AbstractServices;
using ECommerce.Entity.Entity;
using ECommerce.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ICategoryService categoryService, IProductService productService,UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _productService = productService;
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            var products = _productService.GetAllProducts(); 
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,

                };
                var result = await _userManager.CreateAsync(user,registerDTO.Password);

                if(result.Succeeded)
                {
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(registerDTO);
                }
            }
            return View(registerDTO);
        }
    }
}

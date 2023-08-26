using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_Northwind.Models;
using MVC_Northwind.Models.DTO;
using MVC_Northwind.Models.Entity;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace MVC_Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        NorthwindContext db = new NorthwindContext();
        public HomeController(ILogger<HomeController> logger,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var categoryList = db.Categories.ToList();
            var productList = db.Products.Where(x => x.UnitsOnOrder>20).ToList();
            
            return View(productList);
        }

        public IActionResult About()
        {
            return View();
        }
       
        
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterDTO register)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = register.Username,
                    Email = register.Email,
                };
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    //Identity Create
                    TempData["Success"] = $"{user.UserName} başarılı şekilde kaydoldu.";
                    return RedirectToAction("CustomerProfile","Home");
                }
                else
                {
                    return View(register);
                }


            }
            else
            {
                return View(register);
            }

        }
        public IActionResult CustomerProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerProfile(Customer customer)
        {
            db.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task <IActionResult> Login(LoginDTO login)
        {
            if(ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(login.Email);
                if (user == null)
                {
                    TempData["Error"] = "Kullanıcı adı veya şifre hatalı";
                    return View();
                }
                else
                {
                  var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                

                    if (result.Succeeded)
                    {

                        // Get the user's roles

                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                            {
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            }
                            else
                            {
                            TempData["Success"] = $"{login.Email} giriş yaptı";
                            return RedirectToAction("Index"); // Or your default area/controller
                        }
                        


                        
                        
                    }


                    else
                    {

                        return View(login);
                    }
                }
            }
            else
            {
                return View(login);
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
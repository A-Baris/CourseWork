
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MVC_Northwind.Models;
using MVC_Northwind.Models.DTO;
using MVC_Northwind.Models.Entity;
using System.Diagnostics;


namespace MVC_Northwind.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;         
            _roleManager = roleManager;
        }
        NorthwindContext db = new NorthwindContext();
        
        public IActionResult Index()
        {
            ViewBag.Users = _userManager.Users.ToList();
            return View();
           
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (roleName != null)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleName;
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["CompletionMessage"] = "The function is completed";
                    return RedirectToAction("CreateRole");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }


        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    
                    UserName = register.Username,
                    Email =register.Email,
                };
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                  
                    TempData["Success"] = $"{user.UserName} başarılı şekilde kaydoldu.";
                    return RedirectToAction("AddUser", "Home");
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

        public async Task<IActionResult> AssignRole( AppUser user, AppRole role)
        {
            var concreteUsers = db.AspNetUsers.Tolist();
        
            _userManager.AddToRoleAsync(user, role.Name);
            return View(concreteUsers);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

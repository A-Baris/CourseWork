using Microsoft.AspNetCore.Mvc;
using MoviePage.Context;
using MoviePage.Models;
using System.Diagnostics;

namespace MoviePage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        MovieContext db = new MovieContext();

        public IActionResult Index()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            
                var movie = db.Movies.Find(id);
                var dr = db.Directors.ToList();
                var ctg = db.Categories.ToList();
                var mc = db.MoviesAndCategories.ToList();
                var cst = db.Casts.ToList();
                var mcst = db.MoviesAndCasts.ToList();


                return View(movie);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MoviePage.Context;
using MoviePage.Models;

namespace MoviePage.Controllers
{
    public class CrudController : Controller
    {
        MovieContext db = new MovieContext();
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie, Director director, Category category, Cast cast)
        {
            db.Directors.Add(director);
            db.SaveChanges();
            db.Categories.Add(category);
            db.SaveChanges();
            db.Casts.Add(cast);
            db.SaveChanges();
            movie.DirectorId = director.Id;
            db.Movies.Add(movie);
            db.SaveChanges();

            return View(movie);
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id,Movie movieUpdated,Director director)
        {
            var movie = db.Movies.Find(id);
            movie.Id = id;
            movie.MovieName = movieUpdated.MovieName;
            movie.PublishedDate = movieUpdated.PublishedDate;
            movie.TrailerHttp= movieUpdated.TrailerHttp;
            movie.Description = movieUpdated.Description;            
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

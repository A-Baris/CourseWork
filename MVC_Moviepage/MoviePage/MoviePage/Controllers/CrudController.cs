using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = db.Movies.Where(x=> x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(Movie movieUpdated,Director director)
        {

            var data = db.Movies.Where(x => x.Id == movieUpdated.Id).FirstOrDefault();
            if(data != null)
            {
                
                data.MovieName = movieUpdated.MovieName;
                data.PublishedDate = movieUpdated.PublishedDate;
                data.Description = movieUpdated.Description;
                data.TrailerHttp = movieUpdated.TrailerHttp;
            }
            return RedirectToAction("Index","Home");

         
        }
        public IActionResult Delete(int id)
        {
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieApplicationContext _db;

        public MoviesController(MovieApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Movie> objMovieList = _db.Movies.ToList();
            return View(objMovieList);
        }
    }
}

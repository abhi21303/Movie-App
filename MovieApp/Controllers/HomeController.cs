using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Diagnostics;

namespace MovieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieApplicationContext _db;

        public HomeController(MovieApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<HomeScroll> objMovieList = _db.HomeScrolls.ToList();
            return View(objMovieList);
        }

        public IActionResult VideoPlayer(String movieUrl)
        { 
            ViewBag.MovieUrl = movieUrl;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel());
        }
    }
}

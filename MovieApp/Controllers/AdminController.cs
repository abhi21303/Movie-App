using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieApplicationContext _db;

        public AdminController(MovieApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Movie> objMovieList = _db.Movies.ToList();
            return View(objMovieList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Movie obj)
        {
            if (ModelState.IsValid)
            {

                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Data Created Successfully";
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Movie moviefromDb = _db.Movies.Find(id);
            if (moviefromDb == null)
            {
                return NotFound();
            }
            return View(moviefromDb);
        }
        [HttpPost]
        public IActionResult Edit(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Data Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Read(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Movie moviefromDb = _db.Movies.Find(id);
            if (moviefromDb == null)
            {
                return NotFound();
            }
            return View(moviefromDb);
            
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Movie moviefromDb = _db.Movies.Find(id);
            if (moviefromDb == null)
            {
                return NotFound();
            }
            return View(moviefromDb);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Movie movieToDelete = _db.Movies.Find(id);

            if (movieToDelete == null)
            {
                return NotFound();
            }

            _db.Movies.Remove(movieToDelete);
            _db.SaveChanges();

            TempData["success"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}

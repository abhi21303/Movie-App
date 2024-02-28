using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieWebApp.Controllers
{

    public class SignUpController : Controller
    {
        private readonly MovieApplicationContext _db;
        public SignUpController(MovieApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login obj)
        
        {
            if (ModelState.IsValid)
            {

                _db.Logins.Add(obj);
                _db.SaveChanges();
                TempData["Message"] = "Sign Up Successfully";
                return RedirectToAction("Index", "Login");

            }
            else
            {
                TempData["Message"] = "Sign Up Failed";
                return View();
            }
            
        }
    }
}

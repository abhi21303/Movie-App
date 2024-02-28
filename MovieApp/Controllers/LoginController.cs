using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;


namespace MovieWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly MovieApplicationContext _db;
        public LoginController(MovieApplicationContext db)
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
            var user = _db.Logins.FirstOrDefault(x => x.Email == obj.Email && x.Password == obj.Password);
            if (user != null)
            {
                TempData["Message"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = "Invalid email or password.";
                return View();
            }
            
            
           
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;


namespace MovieWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        public readonly MovieApplicationContext _db;

        public SubscriptionController(MovieApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Subscription> objCategoryList = _db.Subscriptions.ToList();
            return View(objCategoryList);
        }
    }
}

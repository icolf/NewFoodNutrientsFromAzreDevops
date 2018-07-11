using Microsoft.AspNet.Identity;
using NewFoodNutrients.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace NewFoodNutrients.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var recipes = _context.Recipes
                .Include(r => r.CookApplicationUser)
                .Include(r => r.Food)
                .Include(r => r.FoodType)
                .Where(r => r.CookApplicationUserId == userId).ToList();
            return View(recipes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
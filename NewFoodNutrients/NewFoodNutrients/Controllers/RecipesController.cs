using NewFoodNutrients.Models;
using NewFoodNutrients.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace NewFoodNutrients.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();

        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new RecipeFormViewModel
            {
                Title = "",
                ContextFoodTypes = _context.FoodTypes.ToList(),
                ContextFoods = _context.Foods.ToList(),
                ContextIngredientTypes = _context.IngredientTypes.ToList(),
                ContextIngredients = _context.Ingredients.ToList(),
                RecipeIngredients = _context.RecipeIngredients.ToList(),
                ContextUnitOfMeasures =_context.UnitOfMeasures.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(RecipeFormViewModel viewModel)
        {
            var recipe = new Recipe
            {
                
            };
            return RedirectToAction("Index", "Home");
        }
    }
}
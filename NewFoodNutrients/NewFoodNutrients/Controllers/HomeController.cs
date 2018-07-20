using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using NewFoodNutrients.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NewFoodNutrients.Dtos;
using NewFoodNutrients.ViewModels;

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
            var recipesViewModel = new List<RecipeViewModel>();
            foreach (var recipe in recipes)
            {
                var recipeVM = new RecipeViewModel()
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    CookApplicationUserName = recipe.CookApplicationUser.Name,
                    FoodId = recipe.FoodId,
                    FoodName = recipe.Food.FoodName,
                    ObjectState = ObjectState.Unchanged
                };
                recipesViewModel.Add(recipeVM);
            }
            return View(recipesViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(RecipeDto dto)
        {
            var recipe = _context.Recipes
                .Include(r => r.RecipeIngredients)
                .SingleOrDefault<Recipe>(r => r.Id == dto.RecipeId);

            if (recipe == null)
            {
                return HttpNotFound("Recipe not found");
            }

            recipe.ObjectState = ObjectState.Deleted;

            foreach (var ing in recipe.RecipeIngredients)
            {
                ing.ObjectState = ObjectState.Deleted;
            }
            _context.Recipes.Attach(recipe);
            _context.ApplyStateChanges();
            _context.SaveChanges();



            var userId = User.Identity.GetUserId();
            var recipes = _context.Recipes
                .Include(r => r.CookApplicationUser)
                .Include(r => r.Food)
                .Include(r => r.FoodType)
                .Where(r => r.CookApplicationUserId == userId).ToList();

            var recipesViewModel = new List<RecipeViewModel>();
            foreach (var recipeModel in recipes)
            {
                var recipeVM = new RecipeViewModel()
                {
                    Id = recipeModel.Id,
                    Title = recipeModel.Title,
                    CookApplicationUserName = recipeModel.CookApplicationUser.Name,
                    FoodId = recipeModel.FoodId,
                    FoodName = recipeModel.Food.FoodName,
                    ObjectState = ObjectState.Unchanged
                };
                recipesViewModel.Add(recipeVM);
            }

            return Json(recipesViewModel);
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
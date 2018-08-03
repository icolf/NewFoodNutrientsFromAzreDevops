using Microsoft.AspNet.Identity;
using NewFoodNutrients.Persistence;
using System.Collections.Generic;
using System.Web.Mvc;
using NewFoodNutrients.Core;
using NewFoodNutrients.Core.Dtos;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.ViewModels;

namespace NewFoodNutrients.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var recipes = _unitOfWork.Recipes.GetRecipes(User.Identity.GetUserId());
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
            var recipe = _unitOfWork.Recipes.GetRecipe(dto.RecipeId, User.Identity.GetUserId());

            if (recipe == null)
            {
                return HttpNotFound("Recipe not found");
            }

            recipe.ObjectState = ObjectState.Deleted;

            foreach (var ing in recipe.RecipeIngredients)
            {
                ing.ObjectState = ObjectState.Deleted;
            }

            _unitOfWork.Recipes.Attach(recipe);
            _unitOfWork.ApplyStateChanges();
            _unitOfWork.Complete();



            var recipes = _unitOfWork.Recipes.GetRecipes(User.Identity.GetUserId());

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
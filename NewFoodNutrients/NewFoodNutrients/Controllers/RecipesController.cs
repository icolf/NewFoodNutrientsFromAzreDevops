using Microsoft.AspNet.Identity;
using NewFoodNutrients.Models;
using NewFoodNutrients.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                ContextUnitOfMeasures = _context.UnitOfMeasures.ToList(),
                Heading = "New Recipe",
                ObjectState = ObjectState.Added
            };
            return View("Recipe", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();
            var recipe = _context.Recipes
                .Include(r => r.FoodType)
                .Include(r => r.Food)
                .Include(r => r.RecipeIngredients)
                .Single<Recipe>(r => r.Id == Id && r.CookApplicationUserId == userId);

            if (recipe == null)
            {
                return HttpNotFound("Recipe not found");
            }

            var viewModel = new RecipeFormViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                ContextFoodTypes = _context.FoodTypes.ToList(),
                ContextFoods = _context.Foods.ToList(),
                ContextIngredientTypes = _context.IngredientTypes.ToList(),
                ContextIngredients = _context.Ingredients.ToList(),
                ContextUnitOfMeasures = _context.UnitOfMeasures.ToList(),
                FoodTypeId = recipe.FoodTypeId,
                FoodId = recipe.FoodId,
                FoodName = recipe.Food.FoodName,
                Heading = "Edit Recipe",
                ObjectState = ObjectState.Unchanged
            };

            foreach (var ing in recipe.RecipeIngredients)
            {
                var ingVM = new IngredientViewModel
                {
                    Id = ing.Id,
                    RecipeId = ing.RecipeId,
                    Amount = ing.Amount,
                    IngredientId = ing.IngredientId,
                    IngredientTypeId = ing.IngredientTypeId,
                    UnitOfMeasureId = ing.UnitOfMeasureId,
                    ObjectState = ObjectState.Unchanged
                };
                viewModel.RecipeIngredients.Add(ingVM);
            }
            return View("Recipe", viewModel);
        }



        [Authorize]
        [HttpPost]
        public ActionResult Save(RecipeFormViewModel recipeFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                recipeFormViewModel.ContextFoodTypes = _context.FoodTypes.ToList();
                recipeFormViewModel.ContextFoods = _context.Foods.ToList();
                recipeFormViewModel.ContextIngredientTypes = _context.IngredientTypes.ToList();
                recipeFormViewModel.ContextIngredients = _context.Ingredients.ToList();
                recipeFormViewModel.ContextUnitOfMeasures = _context.UnitOfMeasures.ToList();

                return View("Recipe", recipeFormViewModel);
            }
            var userId = User.Identity.GetUserId();

            Recipe recipe = new Recipe
            {
                Id = recipeFormViewModel.Id,
                CookApplicationUserId = userId,
                Title = recipeFormViewModel.Title,
                FoodTypeId = recipeFormViewModel.FoodTypeId,
                FoodId = recipeFormViewModel.FoodId,
                RecipeIngredients = new List<RecipeIngredients>(),
                ObjectState = recipeFormViewModel.ObjectState
            };

            // A negative Id value for added (New) ingredients 
            var ingredientId = -1;

            foreach (var ing in recipeFormViewModel.RecipeIngredients)
            {
                var recipeIngredient = new RecipeIngredients
                {
                    RecipeId = recipeFormViewModel.Id,
                    Id = ing.ObjectState == ObjectState.Added ? ingredientId : ing.Id,
                    IngredientTypeId = ing.IngredientTypeId,
                    IngredientId = ing.IngredientId,
                    UnitOfMeasureId = ing.UnitOfMeasureId,
                    Amount = ing.Amount,
                    ObjectState = ing.ObjectState
                };
                recipe.RecipeIngredients.Add(recipeIngredient);
                ingredientId--;
            }

            _context.Recipes.Attach(recipe);

            foreach (int riToDelete in recipeFormViewModel.RecipeIngredientsToDelete)
            {
                var recipeIngredient = _context.RecipeIngredients.Find(riToDelete);
                if (recipeIngredient != null)
                    recipeIngredient.ObjectState = ObjectState.Deleted;
            }


            _context.ApplyStateChanges();
            _context.SaveChanges();

            switch (recipeFormViewModel.ObjectState)
            {
                case ObjectState.Added:
                    //TODO: Add a message to user for added recipes
                    break;
                case ObjectState.Modified:
                    //TODO: Add a message to user for modified recipes
                    break;
            }

            // If we decide in the future to stay in Edit view, then we'll restore the viewModel to show changes in the dataBase. 
            // Like new Ids for added records and we'll also need to return ObjectState to Unchange.

            recipeFormViewModel.ObjectState = ObjectState.Unchanged;
            recipeFormViewModel.Id = recipe.Id;
            recipeFormViewModel.ContextFoodTypes = _context.FoodTypes.ToList();
            recipeFormViewModel.ContextFoods = _context.Foods.ToList();
            recipeFormViewModel.ContextIngredientTypes = _context.IngredientTypes.ToList();
            recipeFormViewModel.ContextIngredients = _context.Ingredients.ToList();
            recipeFormViewModel.ContextUnitOfMeasures = _context.UnitOfMeasures.ToList();


            recipeFormViewModel.RecipeIngredients = new List<IngredientViewModel>();
            foreach (var ing in recipe.RecipeIngredients)
            {
                var ingVM = new IngredientViewModel
                {
                    Id = ing.Id,
                    RecipeId = ing.RecipeId,
                    Amount = ing.Amount,
                    IngredientId = ing.IngredientId,
                    IngredientTypeId = ing.IngredientTypeId,
                    UnitOfMeasureId = ing.UnitOfMeasureId,
                    ObjectState = ObjectState.Unchanged
                };
                recipeFormViewModel.RecipeIngredients.Add(ingVM);
            }
            var redirectedToPage = "/Home/Index";
            return Json(new { homePage = redirectedToPage, vm = recipeFormViewModel });
        }
    }
}
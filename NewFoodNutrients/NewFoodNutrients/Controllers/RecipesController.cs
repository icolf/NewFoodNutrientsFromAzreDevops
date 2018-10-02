using Microsoft.AspNet.Identity;
using NewFoodNutrients.Core;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.ViewModels;
using NewFoodNutrients.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NewFoodNutrients.Controllers
{
    public class RecipesController : Controller
    {
        //comment
        private readonly IUnitOfWork _unitOfWork;


        public RecipesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new RecipeFormViewModel
            {
                Title = "",
                ContextFoodTypes = _unitOfWork.FoodTypes.GetFoodTypes(),
                ContextFoods = _unitOfWork.Foods.GetFoods(),
                ContextIngredientTypes = _unitOfWork.IngredientTypes.GetIngredientTypes(),
                ContextIngredients = _unitOfWork.Ingredients.GetIngredients(),
                ContextUnitOfMeasures = _unitOfWork.UnitOfMeasures.GetUnitOfMeasures(),
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
            var recipe = _unitOfWork.Recipes.GetRecipe(Id, userId);

            if (recipe == null)
            {
                return new HttpNotFoundResult("Recipe not found");
            }

            var viewModel = new RecipeFormViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                ContextFoodTypes = _unitOfWork.FoodTypes.GetFoodTypes(),
                ContextFoods = _unitOfWork.Foods.GetFoods().ToList(),
                ContextIngredientTypes = _unitOfWork.IngredientTypes.GetIngredientTypes(),
                ContextIngredients = _unitOfWork.Ingredients.GetIngredients(),
                ContextUnitOfMeasures = _unitOfWork.UnitOfMeasures.GetUnitOfMeasures(),
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
                recipeFormViewModel.ContextFoodTypes = _unitOfWork.FoodTypes.GetFoodTypes();
                recipeFormViewModel.ContextFoods = _unitOfWork.Foods.GetFoods();
                recipeFormViewModel.ContextIngredientTypes = _unitOfWork.IngredientTypes.GetIngredientTypes();
                recipeFormViewModel.ContextIngredients = _unitOfWork.Ingredients.GetIngredients();
                recipeFormViewModel.ContextUnitOfMeasures = _unitOfWork.UnitOfMeasures.GetUnitOfMeasures();

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

            _unitOfWork.Recipes.Attach(recipe);

            foreach (int riToDelete in recipeFormViewModel.RecipeIngredientsToDelete)
            {
                var recipeIngredient = _unitOfWork.RecipeIngredients.GetRecipeIngredient(riToDelete);
                if (recipeIngredient != null)
                    recipeIngredient.ObjectState = ObjectState.Deleted;
            }


            _unitOfWork.ApplyStateChanges();
            _unitOfWork.Complete();

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
            recipeFormViewModel.ContextFoodTypes = _unitOfWork.FoodTypes.GetFoodTypes();
            recipeFormViewModel.ContextFoods = _unitOfWork.Foods.GetFoods();
            recipeFormViewModel.ContextIngredientTypes = _unitOfWork.IngredientTypes.GetIngredientTypes();
            recipeFormViewModel.ContextIngredients = _unitOfWork.Ingredients.GetIngredients();
            recipeFormViewModel.ContextUnitOfMeasures = _unitOfWork.UnitOfMeasures.GetUnitOfMeasures();


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
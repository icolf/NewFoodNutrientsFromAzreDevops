using Microsoft.AspNet.Identity;
using NewFoodNutrients.Models;
using NewFoodNutrients.ViewModels;
using System;
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
                RecipeIngredients = new List<IngredientViewModel>(),
                ContextUnitOfMeasures = _context.UnitOfMeasures.ToList(),
                ObjectState = ObjectState.Added
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recipe = _context.Recipes
                .Include(r => r.FoodType)
                .Include(r => r.Food)
                .Include(r => r.RecipeIngredients)
                .SingleOrDefault<Recipe>(r => r.Id == Id);

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
                RecipeIngredients = new List<IngredientViewModel>(),
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
            //var redirectedToPage = "/Recipes/Edit";
            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recipe = _context.Recipes
                .Include(r => r.FoodType)
                .Include(r => r.Food)
                .Include(r => r.RecipeIngredients)
                .SingleOrDefault<Recipe>(r => r.Id == Id);

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
                RecipeIngredients = new List<IngredientViewModel>(),
                ObjectState = ObjectState.Deleted
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
                    ObjectState = ObjectState.Deleted
                };
                viewModel.RecipeIngredients.Add(ingVM);
            }
            _context.Recipes.Attach(recipe);
            _context.ApplyStateChanges();
            _context.SaveChanges();


            var redirectedToPage = "/Home/Index";
            return Json(new { homePage = redirectedToPage });
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

                return View("Create", recipeFormViewModel);
            }
            var userId = User.Identity.GetUserId();

            Recipe recipe = new Recipe
            {
                Id = recipeFormViewModel.Id,
                CookApplicationUserId = userId,
                Title = recipeFormViewModel.Title,
                CreationDate = DateTime.Now,
                FoodTypeId = recipeFormViewModel.FoodTypeId,
                FoodId = recipeFormViewModel.FoodId,
                RecipeIngredients = new List<RecipeIngredients>(),
                ObjectState = recipeFormViewModel.ObjectState
            };
            var ingredientId = -1;
            foreach (var ing in recipeFormViewModel.RecipeIngredients)
            {
                var ingredientType = _context.IngredientTypes.Single(it => it.Id == ing.IngredientTypeId);
                var ingredient = _context.Ingredients.Single(i => i.Id == ing.IngredientId);
                var unitOfMeasure = _context.UnitOfMeasures.Single(u => u.Id == ing.UnitOfMeasureId);
                var recipeIngredient = new RecipeIngredients
                {
                    RecipeId = recipeFormViewModel.Id,
                    Id = ing.ObjectState == ObjectState.Added ? ingredientId : ing.Id,
                    IngredientTypeId = ingredientType.Id,
                    IngredientId = ingredient.Id,
                    UnitOfMeasureId = unitOfMeasure.Id,
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

            recipeFormViewModel.ObjectState = ObjectState.Unchanged;
            recipeFormViewModel.Id = recipe.Id;

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
            return Json(new { homePage = redirectedToPage });
        }
    }
}
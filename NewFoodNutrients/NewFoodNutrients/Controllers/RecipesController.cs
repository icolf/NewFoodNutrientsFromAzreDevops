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
                ContextUnitOfMeasures = _context.UnitOfMeasures.ToList()
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
                .Include(r => r.Ingredients)
                .SingleOrDefault<Recipe>(r => r.Id == Id);

            if (recipe == null)
            {
                return HttpNotFound("Recipe not found");
            }

            var viewModel = new RecipeFormViewModel
            {
                Title = recipe.Title,
                ContextFoodTypes = _context.FoodTypes.ToList(),
                ContextFoods = _context.Foods.ToList(),
                ContextIngredientTypes = _context.IngredientTypes.ToList(),
                ContextIngredients = _context.Ingredients.ToList(),
                ContextUnitOfMeasures = _context.UnitOfMeasures.ToList(),
                FoodTypeId = recipe.FoodTypeId,
                FoodId = recipe.FoodId,
                FoodName = recipe.Food.FoodName,
                RecipeIngredients = new List<IngredientViewModel>()
            };

            foreach (var ing in recipe.Ingredients)
            {
                var ingVM = new IngredientViewModel
                {
                    Amount = ing.Amount,
                    IngredientId = ing.IngredientId,
                    IngredientTypeId = ing.IngredientTypeId,
                    UnitOfMeasureId = ing.UnitOfMeasureId
                };
                viewModel.RecipeIngredients.Add(ingVM);
            }
            //var redirectedToPage = "/Recipes/Edit";
            return View(viewModel);
        }



        [Authorize]
        [HttpPost]
        public ActionResult Save(RecipeFormViewModel recipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                recipeViewModel.ContextFoodTypes = _context.FoodTypes.ToList();
                recipeViewModel.ContextFoods = _context.Foods.ToList();
                recipeViewModel.ContextIngredientTypes = _context.IngredientTypes.ToList();
                recipeViewModel.ContextIngredients = _context.Ingredients.ToList();
                recipeViewModel.ContextUnitOfMeasures = _context.UnitOfMeasures.ToList();
                return View("Create", recipeViewModel);
            }
            var userId = User.Identity.GetUserId();

            Recipe recipe = new Recipe
            {
                CookApplicationUserId = userId,
                Title = recipeViewModel.Title,
                CreationDate = DateTime.Now,
                FoodTypeId = recipeViewModel.FoodTypeId,
                FoodId = recipeViewModel.FoodId,
                Ingredients = new List<RecipeIngredients>()
            };
            foreach (var ing in recipeViewModel.RecipeIngredients)
            {
                var ingredientType = _context.IngredientTypes.Single(it => it.Id == ing.IngredientTypeId);
                var ingredient = _context.Ingredients.Single(i => i.Id == ing.IngredientId);
                var unitOfMeasure = _context.UnitOfMeasures.Single(u => u.Id == ing.UnitOfMeasureId);
                var recipeIngredient = new RecipeIngredients
                {
                    IngredientType = ingredientType,
                    Ingredient = ingredient,
                    UnitOfMeasure = unitOfMeasure,
                    Amount = ing.Amount
                };
                recipe.Ingredients.Add(recipeIngredient);
            }

            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            var redirectedToPage = "/Home/Index";
            return Json(new { homePage = redirectedToPage });
        }
    }
}
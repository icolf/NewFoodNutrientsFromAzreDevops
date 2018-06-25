using System;
using System.Collections.Generic;
using NewFoodNutrients.Models;
using NewFoodNutrients.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
                ContextUnitOfMeasures =_context.UnitOfMeasures.ToList()
            };
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
                return View("Create", recipeViewModel);
            }
            var foodType = _context.FoodTypes.Single(f => f.Id == recipeViewModel.FoodTypeId);
            var food = _context.Foods.Single(f => f.Id == recipeViewModel.FoodId);
            var userId=User.Identity.GetUserId();
            var cook = _context.Users.Single(u=>u.Id==userId);

            Recipe recipe = new Recipe
            {
                CookApplicationUser=cook,
                Title = recipeViewModel.Title,
                CreationDate = DateTime.Now,
                FoodType = foodType,
                Food = food,
                Ingredients=new List<RecipeIngredients>()
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
            return RedirectToAction("Create", "Recipe");
        }
    }
}
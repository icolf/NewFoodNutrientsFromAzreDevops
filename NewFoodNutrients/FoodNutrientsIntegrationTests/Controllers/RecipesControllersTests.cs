using FluentAssertions;
using FoodNutrientsIntegrationTests.Extensions;
using NewFoodNutrients.Controllers;
using NewFoodNutrients.Core;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.ViewModels;
using NewFoodNutrients.Persistence;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FoodNutrientsIntegrationTests.Controllers
{
    [TestFixture]
    public class RecipesControllersTests
    {
        private RecipesController _recipesControllers;
        private ApplicationDbContext _context;

        private Food _food;
        private IngredientType _ingredientType;
        private Ingredient _ingredient;
        private UnitOfMeasure _unitOfMeasure;


        [SetUp]
        public void SetUp()
        {
            _context = new ApplicationDbContext();
            _recipesControllers = new RecipesController(new UnitOfWork(_context));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test, Isolated]
        public void Save_ValidViewModelWithObjectStateAdd_ARecipeWasAddedToDatabase()
        {
            //Arrange
            var user = _context.Users.First();

            _recipesControllers.MockControllerContext(user.Id, user.UserName);

            var recipeFormViewModel = CreateRecipeFormViewModel(ObjectState.Added, ObjectState.Added);

            //Action
            var result = _recipesControllers.Save(recipeFormViewModel);

            var recipe = _context.Recipes.Single(r => r.Title == "Test Recipe");

            //Assert
            //NUnit Assertions
            Assert.IsNotNull(recipe);
            Assert.AreEqual(1, recipe.RecipeIngredients.Count);
            Assert.IsTrue(recipe.Title == "Test Recipe");

            //Fluent Assertions
            recipe.Title.Should().Be("Test Recipe");
            recipe.RecipeIngredients.Should().HaveCount(1);


        }
        [Test, Isolated]
        public void Save_ValidViewModelWithObjectStateEdited_ARecipeWasEditedInDatabase()
        {
            //Arrange
            var user = _context.Users.First();

            _recipesControllers.MockControllerContext(user.Id, user.UserName);


            var foodType = new FoodType();
            foodType = _context.FoodTypes.FirstOrDefault();

            _food = _context.Foods.FirstOrDefault(f => f.FoodTypeId == foodType.Id);

            _ingredientType = _context.IngredientTypes.FirstOrDefault();

            _ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientTypeId == _ingredientType.Id);

            _unitOfMeasure = _context.UnitOfMeasures.FirstOrDefault();

            var recipe = AddNewRecipe(foodType, _food, _unitOfMeasure, _ingredientType, _ingredient, user);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();


            //Action
            var recipeFormViewModel = CreateRecipeFormViewModelWithRecipe(recipe, ObjectState.Unchanged, ObjectState.Unchanged);

            recipeFormViewModel.Title = "Test Recipe 2";
            recipeFormViewModel.ObjectState = ObjectState.Modified;
            recipeFormViewModel.RecipeIngredients[0].Amount = 2;
            recipeFormViewModel.RecipeIngredients[0].ObjectState = ObjectState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = EntityState.Detached;
            }
            _recipesControllers.Save(recipeFormViewModel);

            recipe = _context.Recipes.FirstOrDefault(r => r.Title == "Test Recipe 2");
            var recipe2 = _context.Recipes.FirstOrDefault(r => r.Title == "Test Recipe");


            //Assertions
            Assert.IsNotNull(recipe);
            recipe.RecipeIngredients.Should().HaveCount(1);
            recipe2.Should().BeNull();




        }

        private static RecipeFormViewModel CreateRecipeFormViewModel(ObjectState recipeObjectState, ObjectState recipeIngredientObjectState)
        {
            var recipeFormViewModel = new RecipeFormViewModel
            {
                Id = 0,
                Title = "Test Recipe",
                FoodTypeId = 2,
                FoodId = 2,
                RecipeIngredients = new List<IngredientViewModel>
                {
                    new IngredientViewModel
                    {
                        Id = -1,
                        IngredientTypeId = 1,
                        IngredientId = 2,
                        Amount = 1,
                        UnitOfMeasureId = 2,
                        RecipeId = 0,
                        ObjectState = recipeIngredientObjectState
                    }
                },
                ObjectState = recipeObjectState
            };
            return recipeFormViewModel;
        }
        private static RecipeFormViewModel CreateRecipeFormViewModelWithRecipe(Recipe recipe, ObjectState recipeObjectState, ObjectState recipeIngredientObjectState)
        {
            var recipeFormViewModel = new RecipeFormViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                FoodTypeId = recipe.FoodTypeId,
                FoodId = recipe.FoodId,
                RecipeIngredients = new List<IngredientViewModel>
                {
                    new IngredientViewModel
                    {
                        Id = recipe.RecipeIngredients[0].Id,
                        IngredientTypeId = recipe.RecipeIngredients[0].IngredientTypeId,
                        IngredientId = recipe.RecipeIngredients[0].IngredientId,
                        Amount = recipe.RecipeIngredients[0].Amount,
                        UnitOfMeasureId = recipe.RecipeIngredients[0].UnitOfMeasureId,
                        RecipeId = recipe.Id,
                        ObjectState = recipeIngredientObjectState
                    }
                },
                ObjectState = recipeObjectState
            };
            return recipeFormViewModel;
        }

        private static Recipe AddNewRecipe(FoodType foodType, Food food, UnitOfMeasure unitOfMeasure,
            IngredientType ingredientType, Ingredient ingredient, ApplicationUser aplicationUser)
        {
            var recipe = new Recipe
            {
                CookApplicationUserId = aplicationUser.Id,
                FoodTypeId = foodType.Id,
                FoodId = food.Id,
                Title = "Recipe Test",
                RecipeIngredients = new List<RecipeIngredients>
                {
                    new RecipeIngredients
                    {
                        RecipeId = 1,
                        UnitOfMeasure = unitOfMeasure,
                        IngredientType = ingredientType,
                        Ingredient = ingredient,
                        UnitOfMeasureId = unitOfMeasure.Id,
                        Amount = 1,
                        IngredientTypeId = ingredientType.Id,
                        IngredientId = ingredient.Id
                    }
                }
            };
            return recipe;
        }

        private static UnitOfMeasure AddUnitOfMeasure(ApplicationDbContext context)
        {
            var unitOfMeasure = new UnitOfMeasure { UnitofMeasure = "First Unit Of Measure" };
            context.UnitOfMeasures.Add(unitOfMeasure);
            context.SaveChanges();
            return unitOfMeasure;
        }

        private static Ingredient AddIngredient(IngredientType ingredientType, ApplicationDbContext context)
        {
            var ingredient = new Ingredient
            {
                IngredientType = ingredientType,
                IngredientTypeId = ingredientType.Id,
                Name = "First Ingredient"
            };
            context.Ingredients.Add(ingredient);
            context.SaveChanges();
            return ingredient;
        }

        private static IngredientType AddIngredientType(ApplicationDbContext context)
        {
            var ingredientType = new IngredientType { IngredientTypeName = "First Ingredient Type" };
            context.IngredientTypes.Add(ingredientType);
            context.SaveChanges();
            return ingredientType;
        }

        private static Food AddFood(FoodType foodType, ApplicationDbContext context)
        {
            var food = new Food { FoodType = foodType, FoodTypeId = foodType.Id, FoodName = "First Food" };
            context.Foods.Add(food);
            context.SaveChanges();
            return food;
        }

        private static FoodType AddFoodType(ApplicationDbContext context)
        {
            var foodType = new FoodType { FoodTypeName = "First Food Type" };
            context.FoodTypes.Add(foodType);
            context.SaveChanges();
            return foodType;
        }

    }
}

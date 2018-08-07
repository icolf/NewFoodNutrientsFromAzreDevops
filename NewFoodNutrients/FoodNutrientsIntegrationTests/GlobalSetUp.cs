using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Persistence;
using NUnit.Framework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FoodNutrientsIntegrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {
        private Food _food;
        private IngredientType _ingredientType;
        private Ingredient _ingredient;
        private UnitOfMeasure _unitOfMeasure;

        [SetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();
            Seed();
        }

        private static void MigrateDbToLatestVersion()
        {
            var configuration = new NewFoodNutrients.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            var cookApplicationUser = !context.Users.Any() ? AddUsers(context) : context.Users.FirstOrDefault();
            //Add needed data for running tests to database

            var foodType = new FoodType();
            foodType = !context.FoodTypes.Any() ? AddFoodType(context) : context.FoodTypes.FirstOrDefault();

            _food = !context.Foods.Any() ? AddFood(foodType, context) : context.Foods.FirstOrDefault(f => f.FoodTypeId == foodType.Id);

            _ingredientType = !context.IngredientTypes.Any() ? AddIngredientType(context) : context.IngredientTypes.FirstOrDefault();

            _ingredient = !context.Ingredients.Any() ? AddIngredient(_ingredientType, context)
                : context.Ingredients.FirstOrDefault(i => i.IngredientTypeId == _ingredientType.Id);

            _unitOfMeasure = !context.UnitOfMeasures.Any() ? AddUnitOfMeasure(context) : context.UnitOfMeasures.FirstOrDefault();


            //var recipe = !context.Recipes.Any()
            //    ? AddNewRecipe(foodType, _food, _unitOfMeasure, _ingredientType, _ingredient, cookApplicationUser, context)
            //    : context.Recipes.FirstOrDefault();






        }

        //private static Recipe AddNewRecipe(FoodType foodType, Food food, UnitOfMeasure unitOfMeasure,
        //    IngredientType ingredientType, Ingredient ingredient, ApplicationUser aplicationUser, ApplicationDbContext context)
        //{
        //    var recipe = new Recipe
        //    {
        //        CookApplicationUserId = aplicationUser.Id,
        //        FoodTypeId = foodType.Id,
        //        FoodId = food.Id,
        //        Title = "Recipe Test",
        //        RecipeIngredients = new List<RecipeIngredients>
        //        {
        //            new RecipeIngredients
        //            {
        //                RecipeId = 1,
        //                UnitOfMeasure = unitOfMeasure,
        //                IngredientType = ingredientType,
        //                Ingredient = ingredient,
        //                UnitOfMeasureId = unitOfMeasure.Id,
        //                Amount = 1,
        //                IngredientTypeId = ingredientType.Id,
        //                IngredientId = ingredient.Id
        //            }
        //        }
        //    };
        //    context.Recipes.Add(recipe);
        //    context.SaveChanges();

        //    return recipe;
        //}

        private static UnitOfMeasure AddUnitOfMeasure(ApplicationDbContext context)
        {
            var unitOfMeasure = new UnitOfMeasure { UnitofMeasure = "First Unit Of Measure" };
            var unitOfMeasure2 = new UnitOfMeasure { UnitofMeasure = "Second Unit Of Measure" };
            var unitOfMeasure3 = new UnitOfMeasure { UnitofMeasure = "Third Unit Of Measure" };
            var unitOfMeasure4 = new UnitOfMeasure { UnitofMeasure = "Fourth Unit Of Measure" };
            context.UnitOfMeasures.Add(unitOfMeasure);
            context.UnitOfMeasures.Add(unitOfMeasure2);
            context.UnitOfMeasures.Add(unitOfMeasure3);
            context.UnitOfMeasures.Add(unitOfMeasure4);
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
            var ingredient2 = new Ingredient
            {
                IngredientType = ingredientType,
                IngredientTypeId = ingredientType.Id,
                Name = "Second Ingredient"
            };
            var ingredient3 = new Ingredient
            {
                IngredientType = ingredientType,
                IngredientTypeId = ingredientType.Id,
                Name = "Third Ingredient"
            };
            var ingredient4 = new Ingredient
            {
                IngredientType = ingredientType,
                IngredientTypeId = ingredientType.Id,
                Name = "Fourth Ingredient"
            };
            context.Ingredients.Add(ingredient);
            context.Ingredients.Add(ingredient2);
            context.Ingredients.Add(ingredient3);
            context.Ingredients.Add(ingredient4);
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
            var food2 = new Food { FoodType = foodType, FoodTypeId = foodType.Id, FoodName = "Second Food" };
            var food3 = new Food { FoodType = foodType, FoodTypeId = foodType.Id, FoodName = "Third Food" };
            var food4 = new Food { FoodType = foodType, FoodTypeId = foodType.Id, FoodName = "Fourth Food" };
            context.Foods.Add(food);
            context.Foods.Add(food2);
            context.Foods.Add(food3);
            context.Foods.Add(food4);
            context.SaveChanges();
            return food;
        }

        private static FoodType AddFoodType(ApplicationDbContext context)
        {
            var foodType = new FoodType { FoodTypeName = "First Food Type" };
            context.FoodTypes.Add(foodType);
            context.FoodTypes.Add(
                new FoodType
                {
                    FoodTypeName = "Second Food Type"
                });
            context.FoodTypes.Add(
                new FoodType
                {
                    FoodTypeName = "Third Food Type"
                });
            context.FoodTypes.Add(
                new FoodType
                {
                    FoodTypeName = "Fourth Food Type"
                });
            context.SaveChanges();
            return foodType;
        }

        private static ApplicationUser AddUsers(ApplicationDbContext context)
        {
            context.Users.Add(new ApplicationUser { Name = "user1", UserName = "user1", Email = "-", PasswordHash = "-" });
            context.Users.Add(new ApplicationUser { Name = "user2", UserName = "user2", Email = "-", PasswordHash = "-" });
            context.SaveChanges();
            return context.Users.FirstOrDefault();
        }
    }
}

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Persistence;
using NewFoodNutrients.Persistence.Repositories;
using NewFoodNutrients.Tests.Extensions;
using System.Collections.Generic;
using System.Data.Entity;

namespace NewFoodNutrients.Tests.Persistence.Repositories
{
    [TestClass]
    public class RecipeRepositoryTests
    {
        private RecipeRepository _recipeRepository;
        private Mock<DbSet<Recipe>> _mockRecipes;
        private Mock<DbSet<Recipe>> _mockRecipes2;
        private Mock<DbSet<RecipeIngredients>> _mockRecipeIngredients;
        private Mock<DbSet<Food>> _mockFoods;
        private Mock<DbSet<FoodType>> _mockFoodTypes;
        private Mock<DbSet<IngredientType>> _mockIngredientTypes;
        private Mock<DbSet<Ingredient>> _mockIngredients;
        private Mock<DbSet<UnitOfMeasure>> _mockUnitOfMeasures;
        private Mock<DbSet<ApplicationUser>> _mockApplicationUser;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRecipes = new Mock<DbSet<Recipe>>();
            _mockRecipes2 = new Mock<DbSet<Recipe>>();
            _mockRecipeIngredients = new Mock<DbSet<RecipeIngredients>>();
            _mockFoods = new Mock<DbSet<Food>>();
            _mockFoodTypes = new Mock<DbSet<FoodType>>();
            _mockIngredientTypes = new Mock<DbSet<IngredientType>>();
            _mockIngredients = new Mock<DbSet<Ingredient>>();
            _mockUnitOfMeasures = new Mock<DbSet<UnitOfMeasure>>();
            _mockApplicationUser = new Mock<DbSet<ApplicationUser>>();

            var mockAdbc = new Mock<IApplicationDbContext>();
            mockAdbc.SetupGet(a => a.Recipes).Returns(_mockRecipes.Object);
            mockAdbc.SetupGet(a => a.RecipeIngredients).Returns(_mockRecipeIngredients.Object);
            mockAdbc.SetupGet(a => a.Foods).Returns(_mockFoods.Object);
            mockAdbc.SetupGet(a => a.FoodTypes).Returns(_mockFoodTypes.Object);
            mockAdbc.SetupGet(a => a.IngredientTypes).Returns(_mockIngredientTypes.Object);
            mockAdbc.SetupGet(a => a.Ingredients).Returns(_mockIngredients.Object);
            mockAdbc.SetupGet(a => a.UnitOfMeasures).Returns(_mockUnitOfMeasures.Object);
            mockAdbc.SetupGet(a => a.Users).Returns(_mockApplicationUser.Object);

            _recipeRepository = new RecipeRepository(mockAdbc.Object);


        }


        [TestMethod]
        public void Edit_ExistingRecipeSupplied_ResultContainsCorrectValues()
        {
            var recipe = new Recipe
            {
                Id = 1,
                CookApplicationUserId = "1",
                FoodTypeId = 1,
                FoodId = 1,
                Title = "Recipe Test",
                RecipeIngredients = new List<RecipeIngredients>
                {
                    new RecipeIngredients
                    {
                        RecipeId = 1,
                        UnitOfMeasure = new UnitOfMeasure(),
                        IngredientType = new IngredientType(),
                        Ingredient = new Ingredient(),
                        UnitOfMeasureId = 1,
                        Amount = 1,
                        IngredientTypeId = 1,
                        IngredientId = 1,
                        Id = 1
                    },
                    new RecipeIngredients
                    {
                        RecipeId = 1,
                        UnitOfMeasure = new UnitOfMeasure(),
                        IngredientType = new IngredientType(),
                        Ingredient = new Ingredient(),
                        UnitOfMeasureId = 2,
                        Amount = 2,
                        IngredientTypeId = 2,
                        IngredientId = 2,
                        Id = 2
                    }
                },
                FoodType = new FoodType
                {
                    Id = 1,
                    FoodTypeName = "First Foodtype"
                },

                Food = new Food
                {
                    FoodName = "FirstFood",
                    FoodTypeId = 1,
                    Id = 1
                },
                CookApplicationUser = new ApplicationUser { Name = "Icol" }


            };
            _mockRecipes.SetSource(new List<Recipe> { recipe });

            var result = _recipeRepository.GetRecipe(1, "1");
            result.Should().BeOfType<Recipe>();
        }

    }
}

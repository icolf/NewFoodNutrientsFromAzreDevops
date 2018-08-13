using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IApplicationDbContext _context;

        public RecipeRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public Recipe GetRecipe(int? Id, string userId)
        {
            var recipeq = _context.Recipes
                .Where(r => r.Id == Id && r.CookApplicationUserId == userId)
                .Select(r => new
                {
                    r.CookApplicationUser,
                    r.CookApplicationUserId,
                    r.Id,
                    r.Title,
                    r.FoodTypeId,
                    r.FoodType,
                    r.FoodId,
                    r.Food,
                    r.RecipeIngredients
                }).SingleOrDefault();
            return new Recipe
            {
                CookApplicationUser = recipeq?.CookApplicationUser,
                CookApplicationUserId = recipeq?.CookApplicationUserId,
                Id = recipeq.Id,
                Title = recipeq?.Title,
                FoodTypeId = recipeq.FoodTypeId,
                FoodType = recipeq.FoodType,
                FoodId = recipeq.FoodId,
                Food = recipeq.Food,
                RecipeIngredients = recipeq.RecipeIngredients

            };
        }

        public List<Recipe> GetRecipes(string userId)
        {
            return _context.Recipes
                .Include(r => r.CookApplicationUser)
                .Include(r => r.Food)
                .Include(r => r.FoodType)
                .Where(r => r.CookApplicationUserId == userId).ToList();
        }
        public List<Recipe> GetRecipes2(string userId)
        {
            var recipeList = _context.Recipes
                .Where(r => r.CookApplicationUserId == userId)
                .Select(r => new
                {
                    r.CookApplicationUser,
                    r.CookApplicationUserId,
                    r.Id,
                    r.Title,
                    r.FoodTypeId,
                    r.FoodType,
                    r.FoodId,
                    r.Food,
                    r.RecipeIngredients
                })
                .ToList();
            var list = new List<Recipe>();
            foreach (var r in recipeList)
            {
                var recipe = new Recipe
                {
                    CookApplicationUser = r?.CookApplicationUser,
                    CookApplicationUserId = r?.CookApplicationUserId,
                    Id = r.Id,
                    Title = r?.Title,
                    FoodTypeId = r.FoodTypeId,
                    FoodType = r.FoodType,
                    FoodId = r.FoodId,
                    Food = r.Food,
                    RecipeIngredients = r.RecipeIngredients
                };
                list.Add(recipe);

            }

            return list;
        }


        public void Attach(Recipe recipe)
        {   
            _context.Recipes.Attach(recipe);
        }
    }
}
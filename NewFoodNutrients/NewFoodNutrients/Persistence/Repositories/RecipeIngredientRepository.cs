using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeIngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public RecipeIngredients GetRecipeIngredient(int riToDelete)
        {
            return _context.RecipeIngredients.Find(riToDelete);
        }
    }
}
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly IApplicationDbContext _context;

        public RecipeIngredientRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public RecipeIngredients GetRecipeIngredient(int riToDelete)
        {
            return _context.RecipeIngredients.Find(riToDelete);
        }
    }
}
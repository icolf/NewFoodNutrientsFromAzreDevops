using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ingredient> GetIngredients()
        {
            return _context.Ingredients.ToList();

        }

    }
}
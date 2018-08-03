using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class IngredientTypeRepository : IIngredientTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<IngredientType> GetIngredientTypes()
        {
            return _context.IngredientTypes.ToList();

        }


    }
}
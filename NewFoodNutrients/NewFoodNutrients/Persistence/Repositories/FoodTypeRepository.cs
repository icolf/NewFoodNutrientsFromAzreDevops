using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FoodType> GetFoodTypes()
        {
            return _context.FoodTypes.ToList();

        }
    }
}
using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly IApplicationDbContext _context;

        public FoodTypeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<FoodType> GetFoodTypes()
        {
            return _context.FoodTypes.ToList();

        }
    }
}
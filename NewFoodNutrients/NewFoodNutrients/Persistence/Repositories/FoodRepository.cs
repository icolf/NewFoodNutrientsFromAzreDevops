using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IApplicationDbContext _context;

        //A comment to test push
        public FoodRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Food> GetFoods()
        {
            return _context.Foods.ToList();

        }

    }
}
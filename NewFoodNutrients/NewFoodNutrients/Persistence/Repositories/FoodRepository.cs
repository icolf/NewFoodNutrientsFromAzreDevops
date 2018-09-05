using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        //coment
        private readonly IApplicationDbContext _context;

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
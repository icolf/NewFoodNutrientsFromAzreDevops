using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitOfMeasureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UnitOfMeasure> GetUnitOfMeasures()
        {
            return _context.UnitOfMeasures.ToList();

        }

    }
}
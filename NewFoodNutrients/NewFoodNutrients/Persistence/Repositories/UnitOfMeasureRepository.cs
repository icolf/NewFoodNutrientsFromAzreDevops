using System.Collections.Generic;
using System.Linq;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Persistence.Repositories
{
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly IApplicationDbContext _context;

        public UnitOfMeasureRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<UnitOfMeasure> GetUnitOfMeasures()
        {
            return _context.UnitOfMeasures.ToList();

        }

        public void Attach(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasures.Attach(unitOfMeasure);
        }


    }
}
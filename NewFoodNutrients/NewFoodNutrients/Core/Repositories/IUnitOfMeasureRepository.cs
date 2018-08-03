using System.Collections.Generic;
using NewFoodNutrients.Core.Models;

namespace NewFoodNutrients.Core.Repositories
{
    public interface IUnitOfMeasureRepository
    {
        List<UnitOfMeasure> GetUnitOfMeasures();
    }
}
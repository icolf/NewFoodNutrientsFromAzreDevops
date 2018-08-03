using System.Collections.Generic;
using NewFoodNutrients.Core.Models;

namespace NewFoodNutrients.Core.Repositories
{
    public interface IFoodRepository
    {
        List<Food> GetFoods();
    }
}
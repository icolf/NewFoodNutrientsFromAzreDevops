using System.Collections.Generic;
using NewFoodNutrients.Core.Models;

namespace NewFoodNutrients.Core.Repositories
{
    public interface IIngredientRepository
    {
        List<Ingredient> GetIngredients();
    }
}
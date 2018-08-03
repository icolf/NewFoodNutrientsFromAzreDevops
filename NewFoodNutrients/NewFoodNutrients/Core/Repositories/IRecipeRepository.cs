using System.Collections.Generic;
using NewFoodNutrients.Core.Models;

namespace NewFoodNutrients.Core.Repositories
{
    public interface IRecipeRepository
    {
        Recipe GetRecipe(int? Id, string userId);
        List<Recipe> GetRecipes(string userId);
        void Attach(Recipe recipe);
    }
}
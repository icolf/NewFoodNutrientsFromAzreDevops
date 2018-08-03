using NewFoodNutrients.Core.Models;

namespace NewFoodNutrients.Core.Repositories
{
    public interface IRecipeIngredientRepository
    {
        RecipeIngredients GetRecipeIngredient(int riToDelete);
    }
}
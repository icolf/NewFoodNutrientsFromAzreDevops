using NewFoodNutrients.Core.Repositories;

namespace NewFoodNutrients.Core
{
    public interface IUnitOfWork
    {
        IFoodRepository Foods { get; set; }
        IFoodTypeRepository FoodTypes { get; set; }
        IIngredientRepository Ingredients { get; set; }
        IIngredientTypeRepository IngredientTypes { get; set; }
        IRecipeIngredientRepository RecipeIngredients { get; set; }
        IRecipeRepository Recipes { get; set; }
        IUnitOfMeasureRepository UnitOfMeasures { get; set; }

        void ApplyStateChanges();
        void Complete();
    }
}
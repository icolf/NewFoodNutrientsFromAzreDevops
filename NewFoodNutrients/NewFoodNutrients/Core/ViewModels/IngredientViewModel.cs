using NewFoodNutrients.Persistence;

namespace NewFoodNutrients.Core.ViewModels
{
    public class IngredientViewModel : IObjectWithState
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public int IngredientTypeId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public decimal Amount { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}   
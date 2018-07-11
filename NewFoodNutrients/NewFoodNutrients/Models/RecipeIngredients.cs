namespace NewFoodNutrients.Models
{
    public class RecipeIngredients : IObjectWithState
    {
        public int Id { get; set; }

        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }

        public Ingredient Ingredient { get; set; }

        public int IngredientId { get; set; }

        public IngredientType IngredientType { get; set; }

        public int IngredientTypeId { get; set; }

        public decimal Amount { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public int UnitOfMeasureId { get; set; }


        public ObjectState ObjectState { get; set; }
    }
}
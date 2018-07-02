namespace NewFoodNutrients.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }

        public Ingredient Ingredient { get; set; }

        public int IngredientId { get; set; }

        public IngredientType IngredientType { get; set; }

        public int IngredientTypeId { get; set; }

        public decimal Amount { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public int UnitOfMeasureId { get; set; }


    }
}
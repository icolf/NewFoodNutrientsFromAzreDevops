namespace NewFoodNutrients.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IngredientType IngredientType { get; set; }

        public decimal Ammount { get; set; }

        public int RecipeId { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }



    }
}
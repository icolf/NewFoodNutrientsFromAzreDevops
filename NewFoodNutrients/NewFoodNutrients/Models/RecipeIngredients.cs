namespace NewFoodNutrients.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }

        public Ingredient Ingredient { get; set; }

        public decimal Amount { get; set; }

        public int RecipeId { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }



    }
}
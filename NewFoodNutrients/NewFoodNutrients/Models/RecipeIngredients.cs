using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewFoodNutrients.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }

        public Ingredient Ingredient { get; set; }

        public IngredientType IngredientType { get; set; }

        public decimal Amount { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }


    }
}
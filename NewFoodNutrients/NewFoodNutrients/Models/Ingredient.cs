using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Ingredient
    {
        public int Id { get; set; }    

        [Required]
        public string Name { get; set; }

        [Required]
        public IngredientType IngredientType { get; set; }

        public decimal Amount { get; set; }

        public string UnitofMeasure { get; set; }

        [Required]
        public List<Nutrient> Nutrients { get; set; }

    }
}
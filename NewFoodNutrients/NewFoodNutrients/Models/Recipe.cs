using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public int PlateId { get; set; }

        public FoodType FoodType { get; set; }

        public ApplicationUser CookApplicationUser { get; set; }

        public List<RecipeIngredients> Ingredients { get; set; }
    }
}
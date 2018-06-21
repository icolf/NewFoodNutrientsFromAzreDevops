using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewFoodNutrients.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        [Display(Name = "Food Type")]
        public FoodType FoodType { get; set; }

        public Food Food { get; set; }

        public ApplicationUser CookApplicationUser { get; set; }

        public List<RecipeIngredients> Ingredients { get; set; }
    }
}
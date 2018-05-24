using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFoodNutrients.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public FoodType FoodType { get; set; }

        [Required]
        public ApplicationUser CookApplicationUser { get; set; }

        [Required]
        public List<Ingredient> Ingredients { get; set; }   
    }
}
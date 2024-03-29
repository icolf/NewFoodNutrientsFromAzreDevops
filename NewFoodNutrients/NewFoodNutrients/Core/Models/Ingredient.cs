﻿using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IngredientType IngredientType { get; set; }

        public int IngredientTypeId { get; set; }

    }
}
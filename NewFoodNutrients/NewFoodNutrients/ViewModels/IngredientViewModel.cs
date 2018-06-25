using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFoodNutrients.ViewModels
{
    public class IngredientViewModel
    {
        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int IngredientTypeId { get; set; }

        [Required]
        public int UnitOfMeasureId { get; set; }

        [Required]
        public decimal Amount { get; set; }

    }
}   
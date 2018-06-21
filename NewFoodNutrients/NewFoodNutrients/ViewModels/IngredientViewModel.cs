using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFoodNutrients.ViewModels
{
    public class IngredientViewModel
    {
        public int IngredientId { get; set; }

        public int IngredientTypeId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public decimal Amount { get; set; }

    }
}   
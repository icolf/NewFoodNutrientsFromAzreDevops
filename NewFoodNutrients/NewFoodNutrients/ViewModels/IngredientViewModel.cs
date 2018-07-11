using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NewFoodNutrients.Models;

namespace NewFoodNutrients.ViewModels
{
    public class IngredientViewModel : IObjectWithState
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public int IngredientTypeId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public decimal Amount { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}   
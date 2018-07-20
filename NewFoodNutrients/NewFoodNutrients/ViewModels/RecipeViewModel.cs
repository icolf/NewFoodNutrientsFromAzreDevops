using NewFoodNutrients.Models;
using System;
using System.Collections.Generic;

namespace NewFoodNutrients.ViewModels
{
    public class RecipeViewModel : IObjectWithState
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public int PlateId { get; set; }

        public int FoodTypeId { get; set; }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public ApplicationUser CookApplicationUser { get; set; }

        public List<IngredientViewModel> RecipeIngredients { get; set; }
        public string CookApplicationUserName { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}
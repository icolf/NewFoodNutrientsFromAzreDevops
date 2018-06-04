﻿using NewFoodNutrients.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace NewFoodNutrients.ViewModels
{
    public class RecipeFormViewModel
    {
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }

        public IEnumerable<FoodType> ContextFoodTypes { get; set; }

        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        public IEnumerable<SelectListItem> FoodTypes
        {
            get
            {
                var allFoodTypes = ContextFoodTypes.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.FoodTypeName
                });
                return allFoodTypes;
            }
        }


        [Display(Name = "Food")]
        public int FoodId { get; set; }
        public List<Food> ContextFoods { get; set; }

        public IEnumerable<SelectListItem> Foods
        {
            get
            {
                var allFoods = ContextFoods.Select(f => new SelectListItem
                {
                    Value = f.FoodType.Id.ToString(),
                    Text = f.FoodName
                });
                return allFoods;
            }
        }
    }
}
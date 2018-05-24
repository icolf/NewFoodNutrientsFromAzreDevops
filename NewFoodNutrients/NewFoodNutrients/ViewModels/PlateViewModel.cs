using NewFoodNutrients.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.ViewModels
{
    public class PlateViewModel
    {
        [Display(Name = "Plate Name")]
        public string PlateName { get; set; }

        public int FoodType { get; set; }
        public List<FoodType> FoodTypes { get; set; }
    }
}
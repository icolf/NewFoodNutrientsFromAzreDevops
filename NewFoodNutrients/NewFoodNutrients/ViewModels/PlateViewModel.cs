using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewFoodNutrients.Models;

namespace NewFoodNutrients.ViewModels
{
    public class PlateViewModel
    {
        public int FoodType { get; set; }
        public List<FoodType> FoodTypes { get; set; }
    }
}
﻿namespace NewFoodNutrients.Core.Models
{
    //comment
    public class Plate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MainFoodType { get; set; }

        public ApplicationUser CookApplicationUser { get; set; }

        public Daypart Daypart { get; set; }

        //public string Sample { get; set; }

        //public List<Recipe> Recipes { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Plate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ApplicationUser CookApplicationUser { get; set; }

        public Daypart Daypart { get; set; }

        public List<Recipe> Recipes { get; set; }

    }
}
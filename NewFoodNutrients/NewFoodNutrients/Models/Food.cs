using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        [Required]
        public FoodType FoodType { get; set; }

    }
}
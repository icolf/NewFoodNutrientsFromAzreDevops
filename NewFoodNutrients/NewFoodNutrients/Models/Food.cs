using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required]
        public string FoodName { get; set; }

        public FoodType FoodType { get; set; }

        public int FoodTypeId { get; set; }
    }
}
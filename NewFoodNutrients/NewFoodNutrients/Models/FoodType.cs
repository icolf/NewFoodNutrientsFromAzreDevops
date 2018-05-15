using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class FoodType
    {
        public int FoodTypeId { get; set; }
        [Required]
        public string FoodTypeName { get; set; }
    }
}
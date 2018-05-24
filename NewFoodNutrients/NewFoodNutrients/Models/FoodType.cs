using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        [Required]
        public string FoodTypeName { get; set; }
    }
}
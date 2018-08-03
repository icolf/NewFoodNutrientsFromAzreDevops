using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Core.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        [Required]
        public string FoodTypeName { get; set; }
    }
}
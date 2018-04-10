using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Nutrient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string UnitofMeasure { get; set; }

        public decimal Amount { get; set; }

    }
}
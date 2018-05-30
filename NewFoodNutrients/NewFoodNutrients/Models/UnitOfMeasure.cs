using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        [Required]
        public string UnitofMeasure { get; set; }
    }
}
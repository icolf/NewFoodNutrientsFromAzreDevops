using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Daypart
    {
        public int DaypartId { get; set; }
        [Required]
        public string DaypartName { get; set; }

    }
}
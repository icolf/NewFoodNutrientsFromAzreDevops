using System.ComponentModel.DataAnnotations;

namespace NewFoodNutrients.Models
{
    public class Daypart
    {
        public int Id { get; set; }
        [Required]
        public string DaypartName { get; set; }

    }
}
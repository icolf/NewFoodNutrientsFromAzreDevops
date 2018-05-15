using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFoodNutrients.Models
{
    public class Plate
    {
        public int PlateId { get; set; }
        [Required]
        public string Name { get; set; }
        public Daypart Daypart { get; set; }
        public List<Food> Foods { get; set; }

    }
}
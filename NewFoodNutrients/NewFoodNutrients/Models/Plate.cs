using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFoodNutrients.Models
{
    public class Plate
    {
        public int PlateId { get; set; }
        public string Name { get; set; }
        public Daypart Daypart { get; set; }
        public List<Food> Foods { get; set; }

    }
}
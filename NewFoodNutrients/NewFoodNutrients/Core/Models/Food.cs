namespace NewFoodNutrients.Core.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string FoodName { get; set; }

        public FoodType FoodType { get; set; }

        public int FoodTypeId { get; set; }
    }
}
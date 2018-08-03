using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class FoodConfiguration : EntityTypeConfiguration<Food>
    {
        public FoodConfiguration()
        {
            Property(f => f.FoodName)
                .IsRequired();
        }
    }
}
using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class FoodTypeConfiguration : EntityTypeConfiguration<FoodType>
    {
        public FoodTypeConfiguration()
        {
            Property(ft => ft.FoodTypeName)
                .IsRequired();
        }
    }
}
using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class IngredientTypeConfiguration : EntityTypeConfiguration<IngredientType>
    {
        public IngredientTypeConfiguration()
        {
            Property(it => it.IngredientTypeName)
                .IsRequired();
        }
    }
}
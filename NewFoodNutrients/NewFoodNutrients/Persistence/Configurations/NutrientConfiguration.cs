using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class NutrientConfiguration : EntityTypeConfiguration<Nutrient>
    {
        public NutrientConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
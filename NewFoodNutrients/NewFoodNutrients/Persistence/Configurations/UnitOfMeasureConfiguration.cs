using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class UnitOfMeasureConfiguration : EntityTypeConfiguration<UnitOfMeasure>
    {
        public UnitOfMeasureConfiguration()
        {
            Property(uom => uom.UnitofMeasure)
                .IsRequired();
        }
    }
}
using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class DaypartConfiguration : EntityTypeConfiguration<Daypart>
    {
        public DaypartConfiguration()
        {
            Property(d => d.DaypartName)
                .IsRequired();
        }
    }
}
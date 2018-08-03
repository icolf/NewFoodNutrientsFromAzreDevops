using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            Property(r => r.Title)
                .HasMaxLength(20)
                .IsRequired();
            Ignore(r => r.ObjectState);

        }
    }
}
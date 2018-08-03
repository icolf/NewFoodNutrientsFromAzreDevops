using NewFoodNutrients.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class RecipeIngredientConfiguration : EntityTypeConfiguration<RecipeIngredients>
    {
        public RecipeIngredientConfiguration()
        {
            Ignore(ri => ri.ObjectState);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using NewFoodNutrients.Core.Models;

namespace NewFoodNutrients.Persistence.Configurations
{
    public class IngredientConfiguration : EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {
            Property(i => i.Name)
                .IsRequired();
        }
    }
}
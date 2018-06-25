using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NewFoodNutrients.Models.Configurations
{
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            Property(r => r.Title).HasMaxLength(20).IsRequired();
            //Ignore(r => r.ObjectState);

        } 
    }
}
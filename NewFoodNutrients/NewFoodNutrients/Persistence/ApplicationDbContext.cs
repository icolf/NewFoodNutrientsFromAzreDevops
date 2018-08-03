using Microsoft.AspNet.Identity.EntityFramework;
using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Persistence.Configurations;
using System.Data.Entity;

namespace NewFoodNutrients.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Daypart> Dayparts { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RecipeConfiguration());
            modelBuilder.Configurations.Add(new IngredientConfiguration());
            modelBuilder.Configurations.Add(new NutrientConfiguration());
            modelBuilder.Configurations.Add(new FoodConfiguration());
            modelBuilder.Configurations.Add(new FoodTypeConfiguration());
            modelBuilder.Configurations.Add(new DaypartConfiguration());
            modelBuilder.Configurations.Add(new IngredientTypeConfiguration());
            modelBuilder.Configurations.Add(new UnitOfMeasureConfiguration());
            modelBuilder.Configurations.Add(new RecipeIngredientConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using NewFoodNutrients.Models.Configurations;

namespace NewFoodNutrients.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId }); modelBuilder.Configurations.Add(new RecipeConfiguration());

        //    //    modelBuilder.Configurations.Add(new RecipeConfiguration());
        //}
    }
    }

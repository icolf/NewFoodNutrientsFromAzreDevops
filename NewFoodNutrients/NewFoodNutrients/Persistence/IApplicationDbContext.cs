using NewFoodNutrients.Core.Models;
using System.Data.Entity;


namespace NewFoodNutrients.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Recipe> Recipes { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Nutrient> Nutrients { get; set; }
        DbSet<Plate> Plates { get; set; }
        DbSet<Food> Foods { get; set; }
        DbSet<FoodType> FoodTypes { get; set; }
        DbSet<Daypart> Dayparts { get; set; }
        DbSet<IngredientType> IngredientTypes { get; set; }
        DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}
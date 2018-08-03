using NewFoodNutrients.Core;
using NewFoodNutrients.Core.Repositories;
using NewFoodNutrients.Persistence.Repositories;

namespace NewFoodNutrients.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRecipeRepository Recipes { get; set; }
        public IRecipeIngredientRepository RecipeIngredients { get; set; }
        public IFoodTypeRepository FoodTypes { get; set; }
        public IFoodRepository Foods { get; set; }
        public IIngredientTypeRepository IngredientTypes { get; set; }
        public IIngredientRepository Ingredients { get; set; }
        public IUnitOfMeasureRepository UnitOfMeasures { get; set; }



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Recipes = new RecipeRepository(_context);
            RecipeIngredients = new RecipeIngredientRepository(_context);
            FoodTypes = new FoodTypeRepository(_context);
            Foods = new FoodRepository(_context);
            IngredientTypes = new IngredientTypeRepository(_context);
            Ingredients = new IngredientRepository(_context);
            UnitOfMeasures = new UnitOfMeasureRepository(_context);
        }

        public void ApplyStateChanges()
        {
            _context.ApplyStateChanges();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
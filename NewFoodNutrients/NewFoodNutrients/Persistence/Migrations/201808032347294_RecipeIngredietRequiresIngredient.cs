namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeIngredietRequiresIngredient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientId", "dbo.Ingredients");
            AddForeignKey("dbo.RecipeIngredients", "IngredientId", "dbo.Ingredients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientId", "dbo.Ingredients");
            AddForeignKey("dbo.RecipeIngredients", "IngredientId", "dbo.Ingredients", "Id", cascadeDelete: true);
        }
    }
}

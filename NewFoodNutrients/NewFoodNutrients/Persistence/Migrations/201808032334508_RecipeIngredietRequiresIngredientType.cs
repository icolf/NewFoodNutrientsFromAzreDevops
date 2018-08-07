namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeIngredietRequiresIngredientType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes");
            AddForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes");
            AddForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: true);
        }
    }
}

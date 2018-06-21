namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIngredientTypeToRecipeIngredients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeIngredients", "IngredientType_Id", c => c.Int());
            CreateIndex("dbo.RecipeIngredients", "IngredientType_Id");
            AddForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientType_Id" });
            DropColumn("dbo.RecipeIngredients", "IngredientType_Id");
        }
    }
}

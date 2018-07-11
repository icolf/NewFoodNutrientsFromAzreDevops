namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeIdToRecipeIngredients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_Id" });
            RenameColumn(table: "dbo.RecipeIngredients", name: "Recipe_Id", newName: "RecipeId");
            AlterColumn("dbo.RecipeIngredients", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeIngredients", "RecipeId");
            AddForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "RecipeId" });
            AlterColumn("dbo.RecipeIngredients", "RecipeId", c => c.Int());
            RenameColumn(table: "dbo.RecipeIngredients", name: "RecipeId", newName: "Recipe_Id");
            CreateIndex("dbo.RecipeIngredients", "Recipe_Id");
            AddForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}

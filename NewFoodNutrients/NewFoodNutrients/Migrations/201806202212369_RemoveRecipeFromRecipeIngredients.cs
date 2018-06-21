namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRecipeFromRecipeIngredients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "RecipeId" });
            RenameColumn(table: "dbo.RecipeIngredients", name: "RecipeId", newName: "Recipe_Id");
            AlterColumn("dbo.RecipeIngredients", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.RecipeIngredients", "Recipe_Id");
            AddForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_Id" });
            AlterColumn("dbo.RecipeIngredients", "Recipe_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RecipeIngredients", name: "Recipe_Id", newName: "RecipeId");
            CreateIndex("dbo.RecipeIngredients", "RecipeId");
            AddForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}

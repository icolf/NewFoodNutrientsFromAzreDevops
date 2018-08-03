namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RecipePKChangedFromRecipeIdBackToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_RecipeId", "dbo.Recipes");
            RenameColumn(table: "dbo.RecipeIngredients", name: "Recipe_RecipeId", newName: "Recipe_Id");
            RenameIndex(table: "dbo.RecipeIngredients", name: "IX_Recipe_RecipeId", newName: "IX_Recipe_Id");
            DropPrimaryKey("dbo.Recipes");
            DropColumn("dbo.Recipes", "RecipeId");
            AddColumn("dbo.Recipes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Recipes", "Id");
            AddForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes", "Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Recipes", "RecipeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            DropPrimaryKey("dbo.Recipes");
            DropColumn("dbo.Recipes", "Id");
            AddPrimaryKey("dbo.Recipes", "RecipeId");
            RenameIndex(table: "dbo.RecipeIngredients", name: "IX_Recipe_Id", newName: "IX_Recipe_RecipeId");
            RenameColumn(table: "dbo.RecipeIngredients", name: "Recipe_Id", newName: "Recipe_RecipeId");
            AddForeignKey("dbo.RecipeIngredients", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
        }
    }
}

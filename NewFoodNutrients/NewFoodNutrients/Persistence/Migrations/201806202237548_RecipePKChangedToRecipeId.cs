namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RecipePKChangedToRecipeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            RenameColumn(table: "dbo.RecipeIngredients", name: "Recipe_Id", newName: "Recipe_RecipeId");
            RenameIndex(table: "dbo.RecipeIngredients", name: "IX_Recipe_Id", newName: "IX_Recipe_RecipeId");
            DropPrimaryKey("dbo.Recipes");
            AddColumn("dbo.Recipes", "RecipeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Plates", "Name", c => c.String());
            AddPrimaryKey("dbo.Recipes", "RecipeId");
            AddForeignKey("dbo.RecipeIngredients", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
            DropColumn("dbo.Recipes", "Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Recipes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RecipeIngredients", "Recipe_RecipeId", "dbo.Recipes");
            DropPrimaryKey("dbo.Recipes");
            AlterColumn("dbo.Plates", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Recipes", "RecipeId");
            AddPrimaryKey("dbo.Recipes", "Id");
            RenameIndex(table: "dbo.RecipeIngredients", name: "IX_Recipe_RecipeId", newName: "IX_Recipe_Id");
            RenameColumn(table: "dbo.RecipeIngredients", name: "Recipe_RecipeId", newName: "Recipe_Id");
            AddForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}

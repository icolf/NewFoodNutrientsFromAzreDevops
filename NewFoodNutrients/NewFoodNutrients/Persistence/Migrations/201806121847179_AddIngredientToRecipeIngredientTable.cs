namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddIngredientToRecipeIngredientTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientType_Id" });
            DropColumn("dbo.RecipeIngredients", "IngredientType_Id");
            AddColumn("dbo.RecipeIngredients", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.RecipeIngredients", "Ingredient_Id", c => c.Int());
            CreateIndex("dbo.RecipeIngredients", "Ingredient_Id");
            AddForeignKey("dbo.RecipeIngredients", "Ingredient_Id", "dbo.Ingredients", "Id");
            DropColumn("dbo.RecipeIngredients", "Ammount");
        }

        public override void Down()
        {
            AddColumn("dbo.RecipeIngredients", "IngredientType_Id", c => c.Int());
            AddColumn("dbo.RecipeIngredients", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_Id" });
            DropColumn("dbo.RecipeIngredients", "Ingredient_Id");
            DropColumn("dbo.RecipeIngredients", "Amount");
            CreateIndex("dbo.RecipeIngredients", "IngredientType_Id");
            AddForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes", "Id");
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangingToNotRequiredIngredientsOfRecipe3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Ingredients", "RecipeId");
            //AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            //DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
        }
    }
}

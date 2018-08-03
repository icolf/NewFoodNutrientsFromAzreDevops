namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropColumn("dbo.Ingredients", "RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingredients", "RecipeId");
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}

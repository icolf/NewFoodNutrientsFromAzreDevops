namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Correct3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "CookApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Recipes", "FoodType_Id", c => c.Int(nullable: false));
            //CreateIndex("dbo.Ingredients", "RecipeId");
            CreateIndex("dbo.Recipes", "CookApplicationUser_Id");
            CreateIndex("dbo.Recipes", "FoodType_Id");
            AddForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes");
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "FoodType_Id" });
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropColumn("dbo.Recipes", "FoodType_Id");
            DropColumn("dbo.Recipes", "CookApplicationUser_Id");
        }
    }
}

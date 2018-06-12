namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes");
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            DropIndex("dbo.Recipes", new[] { "FoodType_Id" });
            DropColumn("dbo.Recipes", "CookApplicationUser_Id");
            DropColumn("dbo.Recipes", "FoodType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "FoodType_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "CookApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Recipes", "FoodType_Id");
            CreateIndex("dbo.Recipes", "CookApplicationUser_Id");
            CreateIndex("dbo.Ingredients", "RecipeId");
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

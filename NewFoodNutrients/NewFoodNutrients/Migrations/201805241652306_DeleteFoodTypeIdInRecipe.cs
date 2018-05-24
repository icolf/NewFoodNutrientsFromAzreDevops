namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFoodTypeIdInRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "FoodType_FoodTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "FoodType_FoodTypeId");
            AddForeignKey("dbo.Recipes", "FoodType_FoodTypeId", "dbo.FoodTypes", "FoodTypeId", cascadeDelete: true);
            DropColumn("dbo.Recipes", "FoodTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "FoodTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Recipes", "FoodType_FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Recipes", new[] { "FoodType_FoodTypeId" });
            DropColumn("dbo.Recipes", "FoodType_FoodTypeId");
        }
    }
}

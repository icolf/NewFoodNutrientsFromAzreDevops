namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfoodtypeidtoRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "FoodTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "FoodTypeId");
        }
    }
}

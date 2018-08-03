namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFoodsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodType_FoodTypeId" });
            AddColumn("dbo.Foods", "FoodTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Foods", "FoodType_FoodTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "FoodType_FoodTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Foods", "FoodTypeId");
            CreateIndex("dbo.Foods", "FoodType_FoodTypeId");
            AddForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes", "FoodTypeId", cascadeDelete: true);
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsToSomeModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodType_FoodTypeId" });
            AlterColumn("dbo.Dayparts", "DaypartName", c => c.String(nullable: false));
            AlterColumn("dbo.Foods", "FoodType_FoodTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.FoodTypes", "FoodTypeName", c => c.String(nullable: false));
            AlterColumn("dbo.Plates", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Foods", "FoodType_FoodTypeId");
            AddForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes", "FoodTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodType_FoodTypeId" });
            AlterColumn("dbo.Plates", "Name", c => c.String());
            AlterColumn("dbo.FoodTypes", "FoodTypeName", c => c.String());
            AlterColumn("dbo.Foods", "FoodType_FoodTypeId", c => c.Int());
            AlterColumn("dbo.Dayparts", "DaypartName", c => c.String());
            CreateIndex("dbo.Foods", "FoodType_FoodTypeId");
            AddForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes", "FoodTypeId");
        }
    }
}

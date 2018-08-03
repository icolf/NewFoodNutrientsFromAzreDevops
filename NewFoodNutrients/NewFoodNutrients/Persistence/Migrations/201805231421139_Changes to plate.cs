namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestoplate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Plate_PlateId", c => c.Int());
            CreateIndex("dbo.Recipes", "Plate_PlateId");
            AddForeignKey("dbo.Recipes", "Plate_PlateId", "dbo.Plates", "PlateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Plate_PlateId", "dbo.Plates");
            DropIndex("dbo.Recipes", new[] { "Plate_PlateId" });
            DropColumn("dbo.Recipes", "Plate_PlateId");
        }
    }
}

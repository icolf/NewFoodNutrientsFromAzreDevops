namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFoodsFromPlate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "Plate_PlateId", "dbo.Plates");
            DropIndex("dbo.Foods", new[] { "Plate_PlateId" });
            DropColumn("dbo.Foods", "Plate_PlateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Plate_PlateId", c => c.Int());
            CreateIndex("dbo.Foods", "Plate_PlateId");
            AddForeignKey("dbo.Foods", "Plate_PlateId", "dbo.Plates", "PlateId");
        }
    }
}

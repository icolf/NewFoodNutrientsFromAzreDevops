namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMoreModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dayparts",
                c => new
                    {
                        DaypartId = c.Int(nullable: false, identity: true),
                        DaypartName = c.String(),
                    })
                .PrimaryKey(t => t.DaypartId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodType_FoodTypeId = c.Int(),
                        Plate_PlateId = c.Int(),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.FoodTypes", t => t.FoodType_FoodTypeId)
                .ForeignKey("dbo.Plates", t => t.Plate_PlateId)
                .Index(t => t.FoodType_FoodTypeId)
                .Index(t => t.Plate_PlateId);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        FoodTypeId = c.Int(nullable: false, identity: true),
                        FoodTypeName = c.String(),
                    })
                .PrimaryKey(t => t.FoodTypeId);
            
            CreateTable(
                "dbo.Plates",
                c => new
                    {
                        PlateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Daypart_DaypartId = c.Int(),
                    })
                .PrimaryKey(t => t.PlateId)
                .ForeignKey("dbo.Dayparts", t => t.Daypart_DaypartId)
                .Index(t => t.Daypart_DaypartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "Plate_PlateId", "dbo.Plates");
            DropForeignKey("dbo.Plates", "Daypart_DaypartId", "dbo.Dayparts");
            DropForeignKey("dbo.Foods", "FoodType_FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Plates", new[] { "Daypart_DaypartId" });
            DropIndex("dbo.Foods", new[] { "Plate_PlateId" });
            DropIndex("dbo.Foods", new[] { "FoodType_FoodTypeId" });
            DropTable("dbo.Plates");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Foods");
            DropTable("dbo.Dayparts");
        }
    }
}

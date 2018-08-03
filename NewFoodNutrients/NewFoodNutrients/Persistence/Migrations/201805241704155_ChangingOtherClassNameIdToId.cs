namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingOtherClassNameIdToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plates", "Daypart_DaypartId", "dbo.Dayparts");
            RenameColumn(table: "dbo.Plates", name: "Daypart_DaypartId", newName: "Daypart_Id");
            RenameIndex(table: "dbo.Plates", name: "IX_Daypart_DaypartId", newName: "IX_Daypart_Id");
            DropPrimaryKey("dbo.Dayparts");
            DropColumn("dbo.Dayparts", "DaypartId");
            DropPrimaryKey("dbo.Foods");
            DropColumn("dbo.Foods", "FoodId");
            AddColumn("dbo.Dayparts", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Foods", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Foods", "FoodType_Id", c => c.Int());
            AddPrimaryKey("dbo.Dayparts", "Id");
            AddPrimaryKey("dbo.Foods", "Id");
            CreateIndex("dbo.Foods", "FoodType_Id");
            AddForeignKey("dbo.Foods", "FoodType_Id", "dbo.FoodTypes", "Id");
            AddForeignKey("dbo.Plates", "Daypart_Id", "dbo.Dayparts", "Id");
            DropColumn("dbo.Foods", "FoodTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "FoodTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "FoodId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Dayparts", "DaypartId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Plates", "Daypart_Id", "dbo.Dayparts");
            DropForeignKey("dbo.Foods", "FoodType_Id", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodType_Id" });
            DropPrimaryKey("dbo.Foods");
            DropPrimaryKey("dbo.Dayparts");
            DropColumn("dbo.Foods", "FoodType_Id");
            DropColumn("dbo.Foods", "Id");
            DropColumn("dbo.Dayparts", "Id");
            AddPrimaryKey("dbo.Foods", "FoodId");
            AddPrimaryKey("dbo.Dayparts", "DaypartId");
            RenameIndex(table: "dbo.Plates", name: "IX_Daypart_Id", newName: "IX_Daypart_DaypartId");
            RenameColumn(table: "dbo.Plates", name: "Daypart_Id", newName: "Daypart_DaypartId");
            AddForeignKey("dbo.Plates", "Daypart_DaypartId", "dbo.Dayparts", "DaypartId");
        }
    }
}

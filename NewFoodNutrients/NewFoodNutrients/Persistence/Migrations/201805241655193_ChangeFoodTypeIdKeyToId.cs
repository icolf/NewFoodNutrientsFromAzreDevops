namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFoodTypeIdKeyToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "FoodType_FoodTypeId", "dbo.FoodTypes");
            RenameColumn(table: "dbo.Recipes", name: "FoodType_FoodTypeId", newName: "FoodType_Id");
            RenameIndex(table: "dbo.Recipes", name: "IX_FoodType_FoodTypeId", newName: "IX_FoodType_Id");
            DropPrimaryKey("dbo.FoodTypes");
            DropColumn("dbo.FoodTypes", "FoodTypeId");
            AddColumn("dbo.FoodTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FoodTypes", "Id");
            AddForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodTypes", "FoodTypeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes");
            DropPrimaryKey("dbo.FoodTypes");
            DropColumn("dbo.FoodTypes", "Id");
            AddPrimaryKey("dbo.FoodTypes", "FoodTypeId");
            RenameIndex(table: "dbo.Recipes", name: "IX_FoodType_Id", newName: "IX_FoodType_FoodTypeId");
            RenameColumn(table: "dbo.Recipes", name: "FoodType_Id", newName: "FoodType_FoodTypeId");
            AddForeignKey("dbo.Recipes", "FoodType_FoodTypeId", "dbo.FoodTypes", "FoodTypeId", cascadeDelete: true);
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFoodTypeIdToFood : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodType_Id", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodType_Id" });
            RenameColumn(table: "dbo.Foods", name: "FoodType_Id", newName: "FoodTypeId");
            AlterColumn("dbo.Foods", "FoodTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "FoodTypeId");
            AddForeignKey("dbo.Foods", "FoodTypeId", "dbo.FoodTypes", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Foods", "FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodTypeId" });
            AlterColumn("dbo.Foods", "FoodTypeId", c => c.Int());
            RenameColumn(table: "dbo.Foods", name: "FoodTypeId", newName: "FoodType_Id");
            CreateIndex("dbo.Foods", "FoodType_Id");
            AddForeignKey("dbo.Foods", "FoodType_Id", "dbo.FoodTypes", "Id");
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodTypeIdAndfoodIdToRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes");
            DropIndex("dbo.Recipes", new[] { "Food_Id" });
            DropIndex("dbo.Recipes", new[] { "FoodType_Id" });
            RenameColumn(table: "dbo.Recipes", name: "Food_Id", newName: "FoodId");
            RenameColumn(table: "dbo.Recipes", name: "FoodType_Id", newName: "FoodTypeId");
            AlterColumn("dbo.Recipes", "FoodId", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "FoodTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "FoodTypeId");
            CreateIndex("dbo.Recipes", "FoodId");
            AddForeignKey("dbo.Recipes", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "FoodTypeId", "dbo.FoodTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "FoodTypeId", "dbo.FoodTypes");
            DropForeignKey("dbo.Recipes", "FoodId", "dbo.Foods");
            DropIndex("dbo.Recipes", new[] { "FoodId" });
            DropIndex("dbo.Recipes", new[] { "FoodTypeId" });
            AlterColumn("dbo.Recipes", "FoodTypeId", c => c.Int());
            AlterColumn("dbo.Recipes", "FoodId", c => c.Int());
            RenameColumn(table: "dbo.Recipes", name: "FoodTypeId", newName: "FoodType_Id");
            RenameColumn(table: "dbo.Recipes", name: "FoodId", newName: "Food_Id");
            CreateIndex("dbo.Recipes", "FoodType_Id");
            CreateIndex("dbo.Recipes", "Food_Id");
            AddForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes", "Id");
            AddForeignKey("dbo.Recipes", "Food_Id", "dbo.Foods", "Id");
        }
    }
}

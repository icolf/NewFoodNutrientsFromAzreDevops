namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalizePlateAndRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Plate_PlateId", "dbo.Plates");
            DropIndex("dbo.Recipes", new[] { "Plate_PlateId" });
            RenameColumn(table: "dbo.Recipes", name: "Plate_PlateId", newName: "PlateId");
            AlterColumn("dbo.Recipes", "PlateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "PlateId");
            AddForeignKey("dbo.Recipes", "PlateId", "dbo.Plates", "PlateId", cascadeDelete: true);
            DropColumn("dbo.Plates", "RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plates", "RecipeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Recipes", "PlateId", "dbo.Plates");
            DropIndex("dbo.Recipes", new[] { "PlateId" });
            AlterColumn("dbo.Recipes", "PlateId", c => c.Int());
            RenameColumn(table: "dbo.Recipes", name: "PlateId", newName: "Plate_PlateId");
            CreateIndex("dbo.Recipes", "Plate_PlateId");
            AddForeignKey("dbo.Recipes", "Plate_PlateId", "dbo.Plates", "PlateId");
        }
    }
}

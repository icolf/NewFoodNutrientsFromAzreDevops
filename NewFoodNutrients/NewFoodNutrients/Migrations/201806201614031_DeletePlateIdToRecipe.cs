namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePlateIdToRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "PlateId", "dbo.Plates");
            DropIndex("dbo.Recipes", new[] { "PlateId" });
            DropColumn("dbo.Recipes", "PlateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "PlateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "PlateId");
            AddForeignKey("dbo.Recipes", "PlateId", "dbo.Plates", "Id", cascadeDelete: true);
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodTypeIdAndUnitOfMeasureIdToRecipeIngredients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropForeignKey("dbo.RecipeIngredients", "UnitOfMeasure_Id", "dbo.UnitOfMeasures");
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientType_Id" });
            DropIndex("dbo.RecipeIngredients", new[] { "UnitOfMeasure_Id" });
            RenameColumn(table: "dbo.RecipeIngredients", name: "IngredientType_Id", newName: "IngredientTypeId");
            RenameColumn(table: "dbo.RecipeIngredients", name: "UnitOfMeasure_Id", newName: "UnitOfMeasureId");
            AlterColumn("dbo.RecipeIngredients", "IngredientTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeIngredients", "UnitOfMeasureId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeIngredients", "IngredientTypeId");
            CreateIndex("dbo.RecipeIngredients", "UnitOfMeasureId");
            AddForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "UnitOfMeasureId", "dbo.UnitOfMeasures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "UnitOfMeasureId", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.RecipeIngredients", new[] { "UnitOfMeasureId" });
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientTypeId" });
            AlterColumn("dbo.RecipeIngredients", "UnitOfMeasureId", c => c.Int());
            AlterColumn("dbo.RecipeIngredients", "IngredientTypeId", c => c.Int());
            RenameColumn(table: "dbo.RecipeIngredients", name: "UnitOfMeasureId", newName: "UnitOfMeasure_Id");
            RenameColumn(table: "dbo.RecipeIngredients", name: "IngredientTypeId", newName: "IngredientType_Id");
            CreateIndex("dbo.RecipeIngredients", "UnitOfMeasure_Id");
            CreateIndex("dbo.RecipeIngredients", "IngredientType_Id");
            AddForeignKey("dbo.RecipeIngredients", "UnitOfMeasure_Id", "dbo.UnitOfMeasures", "Id");
            AddForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes", "Id");
        }
    }
}

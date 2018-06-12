namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingIngredientTypeRequiredToIngredientType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            AlterColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.IngredientTypes", "IngredientTypeName", c => c.String(nullable: false));
            CreateIndex("dbo.Ingredients", "IngredientTypeId");
            AddForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            AlterColumn("dbo.IngredientTypes", "IngredientTypeName", c => c.String());
            AlterColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int());
            CreateIndex("dbo.Ingredients", "IngredientTypeId");
            AddForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes", "Id");
        }
    }
}

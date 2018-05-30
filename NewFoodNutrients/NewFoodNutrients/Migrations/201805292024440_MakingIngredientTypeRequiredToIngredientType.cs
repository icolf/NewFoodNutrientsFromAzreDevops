namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingIngredientTypeRequiredToIngredientType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientType_Id" });
            AlterColumn("dbo.Ingredients", "IngredientType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.IngredientTypes", "IngredientTypeName", c => c.String(nullable: false));
            CreateIndex("dbo.Ingredients", "IngredientType_Id");
            AddForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientType_Id" });
            AlterColumn("dbo.IngredientTypes", "IngredientTypeName", c => c.String());
            AlterColumn("dbo.Ingredients", "IngredientType_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "IngredientType_Id");
            AddForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes", "Id");
        }
    }
}

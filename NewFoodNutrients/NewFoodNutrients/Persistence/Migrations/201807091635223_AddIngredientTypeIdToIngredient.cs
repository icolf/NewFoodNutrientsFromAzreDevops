namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddIngredientTypeIdToIngredient : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes");
            //DropIndex("dbo.Ingredients", new[] { "IngredientType_Id" });
            //RenameColumn(table: "dbo.Ingredients", name: "IngredientType_Id", newName: "IngredientTypeId");
            //AlterColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Ingredients", "IngredientTypeId");
            //AddForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            //DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            //DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            //AlterColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int());
            //RenameColumn(table: "dbo.Ingredients", name: "IngredientTypeId", newName: "IngredientType_Id");
            //CreateIndex("dbo.Ingredients", "IngredientType_Id");
            //AddForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes", "Id");
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIngredientTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ingredients", "IngredientType_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "IngredientType_Id");
            AddForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientType_Id" });
            DropColumn("dbo.Ingredients", "IngredientType_Id");
            DropTable("dbo.IngredientTypes");
        }
    }
}

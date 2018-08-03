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
            
            AddColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int());
            CreateIndex("dbo.Ingredients", "IngredientTypeId");
            AddForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            DropColumn("dbo.Ingredients", "IngredientTypeId");
            DropTable("dbo.IngredientTypes");
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitofMeasure = c.String(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Nutrients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitofMeasure = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id)
                .Index(t => t.Ingredient_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CookApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CookApplicationUser_Id)
                .Index(t => t.CookApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Nutrients", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            DropIndex("dbo.Nutrients", new[] { "Ingredient_Id" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Nutrients");
            DropTable("dbo.Ingredients");
        }
    }
}

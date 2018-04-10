namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Nutrients", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Nutrients", "UnitofMeasure", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "CookApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Recipes", "CookApplicationUser_Id");
            AddForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            AlterColumn("dbo.Recipes", "CookApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Recipes", "Title", c => c.String());
            AlterColumn("dbo.Nutrients", "UnitofMeasure", c => c.String());
            AlterColumn("dbo.Nutrients", "Name", c => c.String());
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
            CreateIndex("dbo.Recipes", "CookApplicationUser_Id");
            AddForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

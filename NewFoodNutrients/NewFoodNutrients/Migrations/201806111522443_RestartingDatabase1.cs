namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestartingDatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plates", "CookApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Recipes", "PlateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Plates", "CookApplicationUser_Id");
            CreateIndex("dbo.Recipes", "PlateId");
            AddForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Recipes", "PlateId", "dbo.Plates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "PlateId", "dbo.Plates");
            DropForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "PlateId" });
            DropIndex("dbo.Plates", new[] { "CookApplicationUser_Id" });
            DropColumn("dbo.Recipes", "PlateId");
            DropColumn("dbo.Plates", "CookApplicationUser_Id");
        }
    }
}

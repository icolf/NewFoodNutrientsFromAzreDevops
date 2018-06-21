namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Food_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "Food_Id");
            AddForeignKey("dbo.Recipes", "Food_Id", "dbo.Foods", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Recipes", new[] { "Food_Id" });
            DropColumn("dbo.Recipes", "Food_Id");
        }
    }
}

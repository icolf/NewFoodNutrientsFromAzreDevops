namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DontRememberChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeIngredients", "ObjectState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeIngredients", "ObjectState");
        }
    }
}

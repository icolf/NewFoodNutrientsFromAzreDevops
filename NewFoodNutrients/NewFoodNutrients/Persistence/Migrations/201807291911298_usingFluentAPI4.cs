namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingFluentAPI4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RecipeIngredients", "ObjectState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeIngredients", "ObjectState", c => c.Int(nullable: false));
        }
    }
}

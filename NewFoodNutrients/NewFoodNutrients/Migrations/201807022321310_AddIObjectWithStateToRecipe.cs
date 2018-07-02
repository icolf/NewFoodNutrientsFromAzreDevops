namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIObjectWithStateToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ObjectState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "ObjectState");
        }
    }
}

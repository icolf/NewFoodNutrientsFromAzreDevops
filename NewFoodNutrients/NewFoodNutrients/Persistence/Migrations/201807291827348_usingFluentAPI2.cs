namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingFluentAPI2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipes", "ObjectState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "ObjectState", c => c.Int(nullable: false));
        }
    }
}

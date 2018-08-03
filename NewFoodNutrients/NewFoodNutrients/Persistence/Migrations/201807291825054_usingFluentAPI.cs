namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingFluentAPI : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Title", c => c.String());
        }
    }
}

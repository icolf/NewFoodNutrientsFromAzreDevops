namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingFluentAPI3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nutrients", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nutrients", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}

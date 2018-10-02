namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSampletoPlate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plates", "Sample", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plates", "Sample");
        }
    }
}

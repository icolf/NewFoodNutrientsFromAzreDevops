namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingSampletoPlate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plates", "Sample");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plates", "Sample", c => c.String());
        }
    }
}

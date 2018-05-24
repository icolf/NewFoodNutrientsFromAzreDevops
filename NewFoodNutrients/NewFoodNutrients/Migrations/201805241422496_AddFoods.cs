namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoods : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "FoodName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "FoodName");
        }
    }
}

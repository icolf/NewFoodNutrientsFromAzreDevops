namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeIDToPlateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plates", "RecipeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plates", "RecipeId");
        }
    }
}

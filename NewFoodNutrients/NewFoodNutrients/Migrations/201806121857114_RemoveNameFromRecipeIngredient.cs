namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameFromRecipeIngredient : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RecipeIngredients", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeIngredients", "Name", c => c.String());
        }
    }
}

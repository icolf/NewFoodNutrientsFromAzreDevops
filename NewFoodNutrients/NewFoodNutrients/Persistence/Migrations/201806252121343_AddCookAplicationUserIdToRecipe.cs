namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCookAplicationUserIdToRecipe : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Recipes", name: "CookApplicationUser_Id", newName: "CookApplicationUserId");
            RenameIndex(table: "dbo.Recipes", name: "IX_CookApplicationUser_Id", newName: "IX_CookApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Recipes", name: "IX_CookApplicationUserId", newName: "IX_CookApplicationUser_Id");
            RenameColumn(table: "dbo.Recipes", name: "CookApplicationUserId", newName: "CookApplicationUser_Id");
        }
    }
}

namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestartingDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Nutrients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "UnitofMeasure_Id", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes");
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Plate_Id", "dbo.Plates");
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            DropIndex("dbo.Ingredients", new[] { "UnitofMeasure_Id" });
            DropIndex("dbo.Nutrients", new[] { "Ingredient_Id" });
            DropIndex("dbo.Plates", new[] { "CookApplicationUser_Id" });
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            DropIndex("dbo.Recipes", new[] { "FoodType_Id" });
            DropIndex("dbo.Recipes", new[] { "Plate_Id" });
            AlterColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int());
            AlterColumn("dbo.Nutrients", "UnitofMeasure", c => c.String());
            CreateIndex("dbo.Ingredients", "IngredientTypeId");
            AddForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes", "Id");
            DropColumn("dbo.Ingredients", "RecipeId");
            DropColumn("dbo.Ingredients", "UnitofMeasure_Id");
            DropColumn("dbo.Nutrients", "Ingredient_Id");
            DropColumn("dbo.Plates", "CookApplicationUser_Id");
            DropColumn("dbo.Recipes", "CookApplicationUser_Id");
            DropColumn("dbo.Recipes", "FoodType_Id");
            DropColumn("dbo.Recipes", "Plate_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Plate_Id", c => c.Int());
            AddColumn("dbo.Recipes", "FoodType_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "CookApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Plates", "CookApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Nutrients", "Ingredient_Id", c => c.Int());
            AddColumn("dbo.Ingredients", "UnitofMeasure_Id", c => c.Int());
            AddColumn("dbo.Ingredients", "RecipeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            AlterColumn("dbo.Nutrients", "UnitofMeasure", c => c.String(nullable: false));
            AlterColumn("dbo.Ingredients", "IngredientTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "Plate_Id");
            CreateIndex("dbo.Recipes", "FoodType_Id");
            CreateIndex("dbo.Recipes", "CookApplicationUser_Id");
            CreateIndex("dbo.Plates", "CookApplicationUser_Id");
            CreateIndex("dbo.Nutrients", "Ingredient_Id");
            CreateIndex("dbo.Ingredients", "UnitofMeasure_Id");
            CreateIndex("dbo.Ingredients", "IngredientTypeId");
            CreateIndex("dbo.Ingredients", "RecipeId");
            AddForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "Plate_Id", "dbo.Plates", "Id");
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "UnitofMeasure_Id", "dbo.UnitOfMeasures", "Id");
            AddForeignKey("dbo.Nutrients", "Ingredient_Id", "dbo.Ingredients", "Id");
        }
    }
}

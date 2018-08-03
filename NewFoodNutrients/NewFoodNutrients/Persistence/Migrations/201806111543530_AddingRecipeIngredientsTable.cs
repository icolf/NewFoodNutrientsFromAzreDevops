namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingRecipeIngredientsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    RecipeId = c.Int(nullable: false),
                    IngredientType_Id = c.Int(),
                    UnitOfMeasure_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IngredientTypes", t => t.IngredientType_Id)
                .ForeignKey("dbo.UnitOfMeasures", t => t.UnitOfMeasure_Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.IngredientType_Id)
                .Index(t => t.UnitOfMeasure_Id);

            AddColumn("dbo.Recipes", "CookApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Recipes", "FoodType_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "CookApplicationUser_Id");
            CreateIndex("dbo.Recipes", "FoodType_Id");
            AddForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes", "Id");
            DropColumn("dbo.Ingredients", "Amount");
        }

        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "UnitOfMeasure_Id", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.RecipeIngredients", "IngredientType_Id", "dbo.IngredientTypes");
            DropForeignKey("dbo.Recipes", "FoodType_Id", "dbo.FoodTypes");
            DropForeignKey("dbo.Recipes", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RecipeIngredients", new[] { "UnitOfMeasure_Id" });
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientType_Id" });
            DropIndex("dbo.RecipeIngredients", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "FoodType_Id" });
            DropIndex("dbo.Recipes", new[] { "CookApplicationUser_Id" });
            DropColumn("dbo.Recipes", "FoodType_Id");
            DropColumn("dbo.Recipes", "CookApplicationUser_Id");
            DropTable("dbo.RecipeIngredients");
        }
    }
}

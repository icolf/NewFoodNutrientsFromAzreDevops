namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateIngredientTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Spices and Herbs')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Beverages')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Sweets')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Vegetables')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Soups, Sauces, and Gravies')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Cereal, Grains, and Pasta')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Legums')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Pork')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Beef')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Poultry')");
            Sql("INSERT INTO IngredientTypes (IngredientTypeName) VALUES ('Finfish and Shellfish')");
        }

        public override void Down()
        {
            Sql("DELETE FROM IngredientTypes WHERE Id BETWEEN 1 AND 12");
        }
    }
}

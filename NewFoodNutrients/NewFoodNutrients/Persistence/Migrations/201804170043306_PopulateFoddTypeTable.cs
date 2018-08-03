namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateFoddTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO FoodTypes (FoodTypeName) VALUES ('Fruits')");
            Sql("INSERT INTO FoodTypes (FoodTypeName) VALUES ('Grain foods')");
            Sql("INSERT INTO FoodTypes (FoodTypeName) VALUES ('Lean meats')");
            Sql("INSERT INTO FoodTypes (FoodTypeName) VALUES ('Milk')");
            Sql("INSERT INTO FoodTypes (FoodTypeName) VALUES ('Vegetable and legumes')");
        }

        public override void Down()
        {
            Sql("DELETE FROM FoodTypes WHERE FoodTypeId IN (1, 2, 3, 4)");
        }
    }
}

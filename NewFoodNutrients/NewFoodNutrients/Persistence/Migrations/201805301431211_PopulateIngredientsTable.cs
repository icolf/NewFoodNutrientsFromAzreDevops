namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateIngredientsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Salt',0,'',NULL,1)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Water',0,'',NULL,2)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Sugar',0,'',NULL,3)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Onion',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Pepper',0,'',NULL,1)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Green Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chilli Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Bell Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Red Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Garlic',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken Broth',0,'',NULL,5)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Rice Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Japanese Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Enriched Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chinese Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Lasagna Pasta',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Penne Pasta',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Elbow Pasta',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Rice',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Pinto Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Red Kidney Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Pink Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Sweet Peas',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Boston Butt',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Pork Loin',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Pork Loin',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Pork Tenderloin',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Bacon',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Beef Round',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Sirloin',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Rib Eye',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Beef Tenderloin',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Bistec',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken Wing',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken Tight',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken Drumstick',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken Breast',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Chicken Chicharrones',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Lobster',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Prawns',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Red Snapper',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Tuna',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientTypeId) VALUES ('Catfish',0,'',NULL,11)");

        }

        public override void Down()
        {
            Sql("DELETE FROM Ingredients WHERE Id BETWEEN 1 AND 46");
        }
    }
}

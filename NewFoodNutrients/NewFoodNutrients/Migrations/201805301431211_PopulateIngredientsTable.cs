namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateIngredientsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Salt',0,'',NULL,1)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Water',0,'',NULL,2)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Sugar',0,'',NULL,3)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Onion',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Pepper',0,'',NULL,1)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Green Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chilli Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Bell Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Red Pepper',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Garlic',0,'',NULL,4)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken Broth',0,'',NULL,5)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Rice Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Japanese Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Enriched Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chinese Noodles',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Lasagna Pasta',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Penne Pasta',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Elbow Pasta',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Rice',0,'',NULL,6)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Pinto Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Red Kidney Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Pink Beans',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Sweet Peas',0,'',NULL,7)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Boston Butt',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Pork Loin',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Pork Loin',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Pork Tenderloin',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Bacon',0,'',NULL,8)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Beef Round',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Sirloin',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Rib Eye',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Beef Tenderloin',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Bistec',0,'',NULL,9)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken Wing',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken Tight',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken Drumstick',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken Breast',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Chicken Chicharrones',0,'',NULL,10)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Lobster',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Prawns',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Red Snapper',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Tuna',0,'',NULL,11)");
            Sql("INSERT INTO Ingredients (Name, Amount, UnitofMeasure, Recipe_Id, IngredientType_Id) VALUES ('Catfish',0,'',NULL,11)");

        }

        public override void Down()
        {
            Sql("DELETE FROM Ingredients WHERE Id BETWEEN 1 AND 46");
        }
    }
}

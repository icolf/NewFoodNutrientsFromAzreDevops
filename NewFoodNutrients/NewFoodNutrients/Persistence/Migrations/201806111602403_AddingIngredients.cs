namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingIngredients : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Salt',1)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Water',2)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Sugar',3)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Onion',4)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Pepper',1)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Green Pepper',4)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chilli Pepper',4)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Bell Pepper',4)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Red Pepper',4)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Garlic',4)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken Broth',5)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Noodles',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Rice Noodles',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Japanese Noodles',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Enriched Noodles',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chinese Noodles',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Lasagna Pasta',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Penne Pasta',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Elbow Pasta',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Rice',6)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Beans',7)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Pinto Beans',7)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Red Kidney Beans',7)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Pink Beans',7)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Sweet Peas',7)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Boston Butt',8)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Pork Loin',8)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Pork Loin',8)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Pork Tenderloin',8)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Bacon',8)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Beef Round',9)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Sirloin',9)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Rib Eye',9)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Beef Tenderloin',9)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Bistec',9)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken',10)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken Wing',10)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken Tight',10)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken Drumstick',10)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken Breast',10)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Chicken Chicharrones',10)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Lobster',11)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Prawns',11)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Red Snapper',11)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Tuna',11)");
            Sql("INSERT INTO Ingredients (Name, IngredientTypeId) VALUES ('Catfish',11)");

        }

        public override void Down()
        {
            Sql("DELETE FROM Ingredients WHERE Id<49");
        }
    }
}

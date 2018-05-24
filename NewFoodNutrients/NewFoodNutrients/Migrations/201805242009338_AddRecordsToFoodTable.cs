namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordsToFoodTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Beef', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Lamb', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Veal', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Pork', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Chicken', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Turkey', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Duck', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Fish', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Prawn', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Crab', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Lobster', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Mussels', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Oyster', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Scallops', 3)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Wheat', 2)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Rice', 2)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Quinoa', 2)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Corn', 2)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Beans', 2)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Apple', 1)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Bananas', 1)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Oranges', 1)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Butter', 4)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Chesse', 4)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Yogurt', 4)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Ice Cream', 4)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Milk', 4)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Pinto Beans', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Kidney Beans', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Garbanzo Beans', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Pinto Beans', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Broccoli', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Sweet Potatoes', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Potatoes', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Carrots', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Tomatoes', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Avocado', 5)");
            Sql("INSERT INTO Foods (FoodName, FoodType_Id) VALUES ('Zucchini', 5)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Foods WHERE Id BETWEEN 1 AND 38");
        }
    }
}

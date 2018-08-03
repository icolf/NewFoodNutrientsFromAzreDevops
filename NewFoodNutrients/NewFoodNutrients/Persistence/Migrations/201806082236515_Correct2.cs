namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Correct2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Ingredients SET RecipeId=0 WHERE Id < 48 ");
        }

        public override void Down()
        {
        }
    }
}

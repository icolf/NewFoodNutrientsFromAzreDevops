namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Correct6 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Ingredients");
        }

        public override void Down()
        {
        }
    }
}

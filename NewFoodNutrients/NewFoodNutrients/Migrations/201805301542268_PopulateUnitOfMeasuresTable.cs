namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnitOfMeasuresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('tsp')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('tbsp')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('fl oz')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('cup')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('L')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('lb')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('oz')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('g')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('mm')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('m')");
            Sql("INSERT INTO UnitOfMeasures (UnitofMeasure) VALUES('inch')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM UnitOfMeasures WHERE Id Between 1 AND 12");
        }
    }
}

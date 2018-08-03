namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitOfMeasuresTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitofMeasure = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ingredients", "UnitofMeasure_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "UnitofMeasure_Id");
            AddForeignKey("dbo.Ingredients", "UnitofMeasure_Id", "dbo.UnitOfMeasures", "Id");
            DropColumn("dbo.Ingredients", "UnitofMeasure");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "UnitofMeasure", c => c.String());
            DropForeignKey("dbo.Ingredients", "UnitofMeasure_Id", "dbo.UnitOfMeasures");
            DropIndex("dbo.Ingredients", new[] { "UnitofMeasure_Id" });
            DropColumn("dbo.Ingredients", "UnitofMeasure_Id");
            DropTable("dbo.UnitOfMeasures");
        }
    }
}

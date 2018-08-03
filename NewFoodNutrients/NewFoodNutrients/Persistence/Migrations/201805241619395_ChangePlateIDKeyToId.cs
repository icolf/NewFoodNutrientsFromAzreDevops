namespace NewFoodNutrients.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangePlateIDKeyToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "PlateId", "dbo.Plates");
            DropIndex("dbo.Recipes", new[] { "PlateId" });
            RenameColumn(table: "dbo.Recipes", name: "PlateId", newName: "Plate_Id");
            AlterColumn("dbo.Recipes", "Plate_Id", c => c.Int());
            DropPrimaryKey("dbo.Plates");
            DropColumn("dbo.Plates", "PlateId");
            AddColumn("dbo.Plates", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Plates", "Id");
            AddColumn("dbo.Plates", "CookApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Plates", "CookApplicationUser_Id");
            CreateIndex("dbo.Recipes", "Plate_Id");
            AddForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "Plate_Id", "dbo.Plates", "Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Plates", "PlateId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Recipes", "Plate_Id", "dbo.Plates");
            DropForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "Plate_Id" });
            DropIndex("dbo.Plates", new[] { "CookApplicationUser_Id" });
            DropPrimaryKey("dbo.Plates");
            AlterColumn("dbo.Recipes", "Plate_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Plates", "CookApplicationUser_Id");
            DropColumn("dbo.Plates", "Id");
            AddPrimaryKey("dbo.Plates", "PlateId");
            RenameColumn(table: "dbo.Recipes", name: "Plate_Id", newName: "PlateId");
            CreateIndex("dbo.Recipes", "PlateId");
            AddForeignKey("dbo.Recipes", "PlateId", "dbo.Plates", "PlateId", cascadeDelete: true);
        }
    }
}

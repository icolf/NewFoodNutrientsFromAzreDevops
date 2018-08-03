namespace NewFoodNutrients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dayparts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DaypartName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Foods",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FoodName = c.String(nullable: false),
                    FoodTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeId, cascadeDelete: true)
                .Index(t => t.FoodTypeId);

            CreateTable(
                "dbo.FoodTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FoodTypeName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Ingredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    IngredientTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IngredientTypes", t => t.IngredientTypeId, cascadeDelete: true)
                .Index(t => t.IngredientTypeId);

            CreateTable(
                "dbo.IngredientTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IngredientTypeName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Nutrients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    UnitofMeasure = c.String(),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Plates",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    CookApplicationUser_Id = c.String(maxLength: 128),
                    Daypart_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CookApplicationUser_Id)
                .ForeignKey("dbo.Dayparts", t => t.Daypart_Id)
                .Index(t => t.CookApplicationUser_Id)
                .Index(t => t.Daypart_Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 100),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RecipeId = c.Int(nullable: false),
                    IngredientId = c.Int(nullable: false),
                    IngredientTypeId = c.Int(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitOfMeasureId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.IngredientTypes", t => t.IngredientTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfMeasures", t => t.UnitOfMeasureId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.IngredientId)
                .Index(t => t.IngredientTypeId)
                .Index(t => t.UnitOfMeasureId);

            CreateTable(
                "dbo.Recipes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 20),
                    CreationDate = c.DateTime(nullable: false),
                    FoodTypeId = c.Int(nullable: false),
                    FoodId = c.Int(nullable: false),
                    CookApplicationUserId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CookApplicationUserId)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeId, cascadeDelete: true)
                .Index(t => t.FoodTypeId)
                .Index(t => t.FoodId)
                .Index(t => t.CookApplicationUserId);

            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UnitofMeasure = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecipeIngredients", "UnitOfMeasureId", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "FoodTypeId", "dbo.FoodTypes");
            DropForeignKey("dbo.Recipes", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Recipes", "CookApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecipeIngredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropForeignKey("dbo.RecipeIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Plates", "Daypart_Id", "dbo.Dayparts");
            DropForeignKey("dbo.Plates", "CookApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropForeignKey("dbo.Foods", "FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Recipes", new[] { "CookApplicationUserId" });
            DropIndex("dbo.Recipes", new[] { "FoodId" });
            DropIndex("dbo.Recipes", new[] { "FoodTypeId" });
            DropIndex("dbo.RecipeIngredients", new[] { "UnitOfMeasureId" });
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientTypeId" });
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientId" });
            DropIndex("dbo.RecipeIngredients", new[] { "RecipeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Plates", new[] { "Daypart_Id" });
            DropIndex("dbo.Plates", new[] { "CookApplicationUser_Id" });
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            DropIndex("dbo.Foods", new[] { "FoodTypeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UnitOfMeasures");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Plates");
            DropTable("dbo.Nutrients");
            DropTable("dbo.IngredientTypes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Foods");
            DropTable("dbo.Dayparts");
        }
    }
}

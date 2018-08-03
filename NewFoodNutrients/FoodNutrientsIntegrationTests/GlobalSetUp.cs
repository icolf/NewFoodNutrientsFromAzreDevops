using NewFoodNutrients.Core.Models;
using NewFoodNutrients.Persistence;
using NUnit.Framework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FoodNutrientsIntegrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {
        [SetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();
            Seed();
        }

        private static void MigrateDbToLatestVersion()
        {
            var configuration = new NewFoodNutrients.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            if (context.Users.Any())
                return;

            context.Users.Add(new ApplicationUser { Name = "user1", UserName = "user1", Email = "-", PasswordHash = "-" });
            context.Users.Add(new ApplicationUser { Name = "user2", UserName = "user2", Email = "-", PasswordHash = "-" });
            context.SaveChanges();
        }
    }
}

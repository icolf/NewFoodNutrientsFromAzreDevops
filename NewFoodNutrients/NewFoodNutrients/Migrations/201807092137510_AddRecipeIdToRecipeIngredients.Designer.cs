// <auto-generated />
namespace NewFoodNutrients.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddRecipeIdToRecipeIngredients : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddRecipeIdToRecipeIngredients));
        
        string IMigrationMetadata.Id
        {
            get { return "201807092137510_AddRecipeIdToRecipeIngredients"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
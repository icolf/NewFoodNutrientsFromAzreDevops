using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewFoodNutrients.Startup))]
namespace NewFoodNutrients
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

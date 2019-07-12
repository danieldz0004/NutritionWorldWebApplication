using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NutritionWorld.Startup))]
namespace NutritionWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

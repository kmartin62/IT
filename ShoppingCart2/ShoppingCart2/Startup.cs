using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingCart2.Startup))]
namespace ShoppingCart2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

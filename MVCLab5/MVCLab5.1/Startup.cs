using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLab5._1.Startup))]
namespace MVCLab5._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

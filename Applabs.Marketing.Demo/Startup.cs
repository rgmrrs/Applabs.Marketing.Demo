using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Applabs.Marketing.Demo.Startup))]
namespace Applabs.Marketing.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

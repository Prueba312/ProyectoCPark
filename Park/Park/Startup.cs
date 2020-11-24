using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Park.Startup))]
namespace Park
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

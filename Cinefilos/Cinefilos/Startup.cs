using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinefilos.Startup))]
namespace Cinefilos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

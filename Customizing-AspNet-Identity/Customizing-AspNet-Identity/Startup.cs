using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Customizing_AspNet_Identity.Startup))]
namespace Customizing_AspNet_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

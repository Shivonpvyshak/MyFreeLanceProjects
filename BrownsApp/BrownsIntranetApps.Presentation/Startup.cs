using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrownsIntranetApps.Presentation.Startup))]

namespace BrownsIntranetApps.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
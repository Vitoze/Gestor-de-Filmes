using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gestor_filmesWebSite.Startup))]
namespace gestor_filmesWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

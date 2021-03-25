using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mapa.Startup))]
namespace Mapa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

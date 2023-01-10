using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oglasi.Startup))]
namespace Oglasi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

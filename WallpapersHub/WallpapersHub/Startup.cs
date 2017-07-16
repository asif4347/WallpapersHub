using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WallpapersHub.Startup))]
namespace WallpapersHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

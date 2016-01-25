using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Caching.Startup))]
namespace MVC_Caching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

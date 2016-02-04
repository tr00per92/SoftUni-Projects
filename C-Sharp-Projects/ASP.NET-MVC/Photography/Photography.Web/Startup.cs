using Microsoft.Owin;

using Photography.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace Photography.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
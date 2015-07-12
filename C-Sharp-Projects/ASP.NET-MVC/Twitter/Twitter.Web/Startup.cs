using Microsoft.Owin;
using Owin;
using Twitter.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Twitter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Battleships.WebServices.Startup))]
namespace Battleships.WebServices
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;
    using Battleships.Data;
    using Battleships.WebServices.Infrastructure;

    using Ninject;
    using Ninject.Syntax;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(IBindingRoot kernel)
        {
            kernel.Bind<DbContext>().To<BattleshipsDbContext>();
            kernel.Bind<IBattleshipsData>().To<BattleshipsData>();
            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}

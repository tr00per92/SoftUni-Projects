﻿using Events.Web;
using Microsoft.Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Events.Web
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
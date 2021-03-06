﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(RedeSocial.Api.Startup))]

namespace RedeSocial.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            ConfigureAuth(app);

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);

        }

       
    }
}
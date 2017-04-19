using Microsoft.Owin.Security.OAuth;
using Owin;
using RedeSocial.Api.Models;
using RedeSocial.Api.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocial.Api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        private void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                Provider = new ApplicationOAuthProvider(),
                TokenEndpointPath = new Microsoft.Owin.PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1)

            };

            app.UseOAuthBearerTokens(OAuthOptions);

        
        }
    }
}
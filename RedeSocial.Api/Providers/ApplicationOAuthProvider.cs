using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RedeSocial.Api.Models;

namespace RedeSocial.Api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            var user = await userManager.FindAsync(context.UserName, context.Password);

            if (user != null)
            {
                var oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, OAuthDefaults.AuthenticationType);

                AuthenticationProperties properties = CreateProperties(user);

                var ticket = new AuthenticationTicket(oAuthIdentity, properties);

                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "The userName or password is incorrect");

            }

        }

        private AuthenticationProperties CreateProperties(ApplicationUser user)
        {
            var data = new Dictionary<string, string>()
            {
                {"userName", user.UserName }
            };

            return new AuthenticationProperties(data);
        }
    }
}
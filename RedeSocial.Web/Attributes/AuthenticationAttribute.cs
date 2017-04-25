using RedeSocial.Web.Helpers;
using System.Web.Mvc;


namespace RedeSocial.Web.Attributes
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly TokenHelper _tokenHelper;

        public AuthenticationAttribute()
        {
            _tokenHelper = new TokenHelper();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (_tokenHelper.AccessToken == null)
            {
                filterContext.HttpContext.Response.RedirectToRoute("Login");
            }
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocial.Web.Helpers
{
    public class TokenHelper
    {
        private static HttpContextBase Current
        {
            get { return new HttpContextWrapper(HttpContext.Current); }

        }

        public object AccessToken
        {
            get { return Current.Session != null ? Current.Session["AccessToken"] : null; }
            set
            {
                if (Current.Session != null)
                {
                    Current.Session["AccessToken"] = value;
                }
            }
        }
    }
}
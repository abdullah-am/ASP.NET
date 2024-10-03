using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoTask.EF;

namespace DemoTask.Auth
{
    public class UserA:AuthorizeAttribute
    {
        

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user=(User)httpContext.Session["user"];
            if (user != null && user.UserType.Equals("user") ){ 
                return true;
            };
            return false;
        }
    }
}
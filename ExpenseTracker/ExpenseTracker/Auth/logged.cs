using ExpenseTracker.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Auth
{
    public class logged:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user=(User)httpContext.Session["user"];
            if(user!=null && user.Usertype.Equals("user"))
            {
                return true;
            };
            return false;
        }
        
    }
}
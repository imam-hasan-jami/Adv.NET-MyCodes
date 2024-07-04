using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.EF;
using TaskManagementSystem.DTOs;

namespace TaskManagementSystem.Auth
{
    public class Admin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)httpContext.Session["user"];
            /*if (user != null && user.Type.Equals("Admin"))*/
            {
                return true;
            }
            return false;
        }
    }
}
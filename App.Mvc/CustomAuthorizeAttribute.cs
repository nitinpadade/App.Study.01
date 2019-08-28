using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using App.Common;

namespace App.Mvc
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {        
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {           
            
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            if (!LoginUserInfo.IsAuthenticated)
            {
                return false;
            }            

            if (!Roles.Contains(LoginUserInfo.RoleId.ToString()))
            {
                return false;
            }            

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Restricted/Index");
        }

        public override void OnAuthorization(AuthorizationContext context)
        {
            base.OnAuthorization(context);

            if (!LoginUserInfo.IsAuthenticated)
            {
                context.HttpContext.Response.Clear();
                context.HttpContext.Response.Redirect("~/Home/Login");
                context.HttpContext.Response.End();
            }
        }
    }  
}

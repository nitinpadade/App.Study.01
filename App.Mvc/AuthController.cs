using App.Common;
using App.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Mvc
{
    public class AuthController : BaseController
    {
        public AuthController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
            : base(qryExecutor, cmdHandler)
        {

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!LoginUserInfo.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.Redirect(Url.Action("Login", "Home"));
                filterContext.HttpContext.Response.End();
            }
        }
       
    }
}

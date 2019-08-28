using App.Core.List;
using App.Framework;
using App.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class CategoryController : AuthController
    {
        public CategoryController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
            : base(qryExecutor, cmdHandler)
        {

        }

        [CustomAuthorize(Roles = "1")]
        public ActionResult Index(int id = 0)
        {
            return View(Dispatch<CategoryList>().Categories);
        }
    }
}

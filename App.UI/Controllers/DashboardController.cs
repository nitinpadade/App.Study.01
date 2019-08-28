using App.Core.Details;
using App.Core.List;
using App.Core.ViewModels;
using App.Framework;
using App.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class DashboardController : AuthController
    {
        public DashboardController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
            : base(qryExecutor, cmdHandler)
        {

        }

        [CustomAuthorize(Roles = "1")]
        public ActionResult Index(int id = 0)
        {
            return View(Dispatch<PostTitleList, PostTitleListParameters>(new PostTitleListParameters { CategoryId = id }).PostTitles);
        }

        public PartialViewResult Categories()
        {
            return PartialView(Dispatch<CategoryList>().Categories);
        }

        [CustomAuthorize(Roles = "1")]
        public ActionResult Post(int id)
        {
            return View(Dispatch<PostDetails, PostDetailsParameters>(new PostDetailsParameters { PostId = id }));
        }

    }
}

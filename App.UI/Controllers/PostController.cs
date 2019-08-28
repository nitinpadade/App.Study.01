using App.Common;
using App.Core.Details;
using App.Core.List;
using App.Core.Parameters;
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
    public class PostController : AuthController
    {
        public PostController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
            : base(qryExecutor, cmdHandler)
        {

        }

        [CustomAuthorize(Roles = "1")]
        public ActionResult Index()
        {
            return View(Dispatch<PostTitleList, PostTitleListParameters>(new PostTitleListParameters { CategoryId = 0 }).PostTitles);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "1")]
        public ActionResult Create()
        {
            var model = new PostCmdModel { Categories = Dispatch<CategoryList>().Categories };
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "1")]
        [ValidateInput(false)]
        public ActionResult Create(PostCmdModel model)
        {
            if (ModelState.IsValid)
            {
                model.PostedBy = LoginUserInfo.UserId;
                model.ActionId = 1;
                DispatchCommand<PostCmdModel>(model);
                return RedirectToAction("Index", "Post");
            }

            model.Categories = Dispatch<CategoryList>().Categories;
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "1")]
        public ActionResult Edit(int id)
        {
            var result = Dispatch<PostDetails, PostDetailsParameters>(new PostDetailsParameters { PostId = id });
            var model = new PostCmdModel
            {
                Categories = Dispatch<CategoryList>().Categories,
                Id = id,
                Title = result.Title,
                CategoryId = result.CategoryId,
                Details = result.Details,
                IsPublished = result.IsPublished
            };
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "1")]
        [ValidateInput(false)]
        public ActionResult Edit(PostCmdModel model)
        {
            if (ModelState.IsValid)
            {
                model.ActionId = 2;
                DispatchCommand<PostCmdModel>(model);
                return RedirectToAction("Index", "Post");
            }

            model.Categories = Dispatch<CategoryList>().Categories;
            return View(model);
        }
    }
}

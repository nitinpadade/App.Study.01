using App.Core.ViewModels;
using App.Framework;
using App.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common;
using App.Core.Parameters;
using App.Core.List;
using PagedList;

namespace App.UI.Controllers
{
    public class UserController : AuthController
    {

        public UserController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
            : base(qryExecutor, cmdHandler)
        {

        }

        //
        // GET: /User/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (string.IsNullOrEmpty(sortOrder)) { sortOrder = "Id"; }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Email" ? "Email_desc" : "Email";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var users = Dispatch<UsersList, UserListParameters>(new UserListParameters()).Result;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.ToLower().Contains(searchString.ToLower())
                                       || s.Email.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Name":
                    users = users.OrderBy(s => s.Name).ToList();
                    break;
                case "Name_desc":
                    users = users.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Email":
                    users = users.OrderBy(s => s.Email).ToList();
                    break;
                case "Email_desc":
                    users = users.OrderByDescending(s => s.Email).ToList();
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult Index()
        //{
        //    //UserListModel            
        //    var model = Dispatch<UsersList, UserListParameters>(new UserListParameters()).Result;
        //    return View(model);
        //}

        [CustomAuthorize(Roles = "1")]
        [HttpGet]
        public ActionResult Create()
        {
            UserCmdModel model = new UserCmdModel();
            return View(model);
        }

        [CustomAuthorize(Roles = "1")]
        [HttpPost]
        public ActionResult Create(UserCmdModel model)
        {
            if (ModelState.IsValid)
            {
                model.ActionId = (int)ActionEnum.Insert;
                model.RoleId = (int)RoleEnum.User;
                DispatchCommand<UserCmdModel>(model);
                return RedirectToAction("Index", "User");
            }

            return View(model);
        }

    }
}

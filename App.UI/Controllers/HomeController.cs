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
    public class HomeController : LoginBaseController
    {
        public readonly IAuthenticateService _authService;

        public HomeController(IQryExecutor qryWithParams, IAuthenticateService authService)
            : base(qryWithParams)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            ValidationParameters parameterModel = new ValidationParameters();
            return View(parameterModel);
        }

        [HttpPost]
        public ActionResult Login(ValidationParameters parameterModel)
        {
            var result = this.Dispatch<UserData, ValidationParameters>(parameterModel);
            if (result.IsAuthenticated)
            {
                _authService.SetUserData(new UserInfo
                {
                    UserId = result.UserId,
                    Name = result.Name,
                    Role = result.Role,
                    RoleId = result.RoleId,
                    IsAuthenticated = result.IsAuthenticated,
                    Email = result.Email,
                    Roles = result.Roles
                });
                return RedirectToAction("Index", "Dashboard");
            }
            return View(parameterModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _authService.ClearUserData();
            return RedirectToAction("Login", "Home");
        }
    }
}

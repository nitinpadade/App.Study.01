using App.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class LoginBaseController : Controller
    {
        private readonly IQryExecutor _qryWithParams;

        public LoginBaseController(IQryExecutor qryWithParams)
        {
            _qryWithParams = qryWithParams;
        }

        public TResult Dispatch<TResult, TParameters>(TParameters parameters)
            where TParameters : class
            where TResult : class
        {
            return _qryWithParams.Dispatch<TResult, TParameters>(parameters);
        }
    }
}
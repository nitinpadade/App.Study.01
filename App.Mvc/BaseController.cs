using App.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Mvc
{
    public class BaseController : Controller
    {
        private readonly IQryExecutor _qryExecutor;
        private readonly ICmdHandler _cmdHandler;

        public BaseController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
        {
            _qryExecutor = qryExecutor;
            _cmdHandler = cmdHandler;
        }

        public TResult Dispatch<TResult, TParameters>(TParameters parameters)
            where TParameters : class
            where TResult : class
        {
            return _qryExecutor.Dispatch<TResult, TParameters>(parameters);
        }

        public TResult Dispatch<TResult>()
            where TResult : class
        {
            return _qryExecutor.Dispatch<TResult>();
        }

        public void DispatchCommand<TParameters>(TParameters parameters) where TParameters : class
        {
            _cmdHandler.Dispatch<TParameters>(parameters);
        }
    }
}

using App.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace App.Mvc
{
    public class BaseApiController : ApiController
    {
        private readonly IQryExecutor _qryExecutor;
        private readonly ICmdHandler _cmdHandler;

        public BaseApiController(IQryExecutor qryExecutor, ICmdHandler cmdHandler)
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

        protected override void Initialize(HttpControllerContext controllerContext)
        {

        }
    }
}

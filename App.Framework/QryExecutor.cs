using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Framework
{
    public class QryExecutor : IQryExecutor
    {
        private readonly IKernel _kernel;

        public QryExecutor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public TResult Dispatch<TResult, TParameters>(TParameters parameters)
            where TResult : class
            where TParameters : class
        {
            var handler = _kernel.Resolve<IQryWithParameters<TResult, TParameters>>();
            return handler.Execute(parameters);
        }


        public TResult Dispatch<TResult>() where TResult : class
        {
            var handler = _kernel.Resolve<IQryWithoutParameters<TResult>>();
            return handler.Execute();
        }
    }
}

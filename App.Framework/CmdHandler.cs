using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Framework
{
    public class CmdHandler : ICmdHandler
    {
        private readonly IKernel _kernel;

        public CmdHandler(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Dispatch<TParameters>(TParameters parameters) where TParameters : class
        {
            var handler = _kernel.Resolve<ICmd<TParameters>>();
            handler.Execute(parameters);
        }
    }
}

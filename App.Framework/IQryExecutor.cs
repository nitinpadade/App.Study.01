using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Framework
{
    public interface IQryExecutor
    {
        TResult Dispatch<TResult, TParameters>(TParameters parameters)
            where TParameters : class
            where TResult : class;

        TResult Dispatch<TResult>()
            where TResult : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Framework
{
    public interface IQryWithoutParameters<TResult>
    {
        TResult Execute();
    }
}

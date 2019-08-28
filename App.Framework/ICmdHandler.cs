using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Framework
{
    public interface ICmdHandler
    {
        void Dispatch<TParameters>(TParameters parameters)
            where TParameters : class;
    }
}

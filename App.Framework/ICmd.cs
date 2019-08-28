using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Framework
{
    public interface ICmd<T>
    {
        void Execute(T entity);
    }
}

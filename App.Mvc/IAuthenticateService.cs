using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mvc
{
    public interface IAuthenticateService
    {
        void SetUserData(UserInfo obj);

        void ClearUserData();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mvc
{
    public class UserInfo
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string[] Roles { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}

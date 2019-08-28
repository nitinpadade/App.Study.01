using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace App.Common
{
    public static class LoginUserInfo
    {
        public static string Name
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                string name = "";
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    name = authTicket.Name.Split('|')[0];
                }

                return name; 
            }
        }

        public static int UserId
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                int UserId = 0;
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    UserId = int.Parse(authTicket.Name.Split('|')[1]);
                }

                return UserId;
            }
        }

        public static string Role
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                string name = "";
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    name = authTicket.Name.Split('|')[2];
                }

                return name;
            }
        }

        public static int RoleId
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                int RoleId = 0;
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    RoleId = int.Parse(authTicket.Name.Split('|')[3]);
                }

                return RoleId;
            }
        }

        public static string Email
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                string email = "";
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    email = authTicket.Name.Split('|')[4];
                }

                return email;
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                bool isAuth = false;
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    isAuth = authTicket.Name.Split('|')[6].ToLower().Equals("true") ? true : false;
                }

                return isAuth;
            }
        }

        public static string[] Roles
        {
            get
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                string[] roles = new string[] { };
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    roles = authTicket.Name.Split('|')[5].Split(',');
                }

                return roles;
            }
        }
    }
}

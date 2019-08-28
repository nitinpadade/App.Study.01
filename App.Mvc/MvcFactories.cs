using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mvc
{
    public static class MvcFactories
    {
        public static void Install(IWindsorContainer container)
        {
            container.Register(Component.For(typeof(IAuthenticateService)).ImplementedBy(typeof(AuthenticateService)).LifestyleTransient());
        }
    }
}

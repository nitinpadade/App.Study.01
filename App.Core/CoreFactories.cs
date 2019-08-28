using App.Data;
using App.Framework;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public static class CoreFactories
    {
        public static void Install(IWindsorContainer container)
        {
            DataFactories.Install(container);

            // Command
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(ICmd<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Component.For(typeof(ICmdHandler)).ImplementedBy(typeof(CmdHandler)).LifestyleTransient());

            // Query
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IQryWithParameters<,>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IQryWithoutParameters<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Component.For(typeof(IQryExecutor)).ImplementedBy(typeof(QryExecutor)).LifestyleTransient());
           
        }
    }
}

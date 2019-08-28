using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public static class DataFactories
    {
        public static void Install(IWindsorContainer container)
        {
            container.Register(Component.For(typeof(IUnitOfWork)).ImplementedBy(typeof(UnitOfWork<InterviewDataContext>)).LifestylePerWebRequest());
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
        }
    }
}

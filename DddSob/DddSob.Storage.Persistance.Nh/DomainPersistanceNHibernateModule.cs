using Autofac;
using DddSob.Storage.Persistance.Nh.Core;
using NHibernate.Cfg;

namespace DddSob.Storage.Persistance.Nh
{
    public class DomainPersistanceNHibernateModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces();

            builder
                .Register(context => context.Resolve<IConfigurationFactory>().Generate());

            //Add logging interceptor

            base.Load(builder);
        }
    }
}

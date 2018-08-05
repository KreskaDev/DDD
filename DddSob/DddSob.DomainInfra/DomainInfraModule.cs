using System.Reflection.Emit;
using Autofac;

namespace DddSob.DomainInfra
{
    public class DomainInfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces();
        }
    }
}

using Autofac;

namespace Hoist.Development.Storage
{
    public class DevelopmentStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
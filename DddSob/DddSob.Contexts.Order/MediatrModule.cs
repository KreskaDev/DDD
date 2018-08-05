using System.Collections.Generic;
using Autofac;
using MediatR;

namespace DddSob.Contexts.NoRelation
{
    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // uncomment to enable polymorphic dispatching of requests, but note that
            // this will conflict with generic pipeline behaviors
            // builder.RegisterSource(new ContravariantRegistrationSource());

            // mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request handlers
            builder
                .Register<SingleInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.TryResolve(t, out var o) ? o : null;
                })
                .InstancePerLifetimeScope();

            // notification handlers
            builder
                .Register<MultiInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();

            // finally register our custom code (individually, or via assembly scanning)
            // - requests & handlers as transient, i.e. InstancePerDependency()
            // - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
            // - behaviors as transient, i.e. InstancePerDependency()
            //builder.RegisterAssemblyTypes(typeof(MyType).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan
            //builder.RegisterType<MyHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces();
            //.EnableInterfaceInterceptors()
            //.InterceptedBy(typeof(LogInterceptor));


        }
    }
}

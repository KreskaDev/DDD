using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using Module = Autofac.Module;

namespace DddSob.Persistance.LocalDb.Http
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder, string dbConnectionString, IEnumerable<Module> modules, Assembly assembly)
        {
            var testWebApiResolver = new WebApiResolver(assembly);
            var config = new HttpConfiguration();

            config.Services.Replace(typeof(IAssembliesResolver), testWebApiResolver);
            config.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(testWebApiResolver.GetAssemblies().First());

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            appBuilder.UseWebApi(config);
        }
    }
}
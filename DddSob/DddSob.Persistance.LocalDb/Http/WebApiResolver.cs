using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace DddSob.Persistance.LocalDb.Http
{
    public class WebApiResolver : IAssembliesResolver
    {
        private readonly Assembly _assembly;

        public WebApiResolver(Assembly assembly)
        {
            _assembly = assembly;
        }


        public ICollection<Assembly> GetAssemblies()
        {
            var assemblyFileName = _assembly.ManifestModule.Name;
            var controllersAssembly = Assembly.LoadFrom(assemblyFileName);
            return new List<Assembly> { controllersAssembly };
        }
    }
}
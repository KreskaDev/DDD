using System;
using System.Reflection;
using DddSob.Storage.Persistance.Nh.Configurations;
using DddSob.Storage.Persistance.Nh.Extensions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace DddSob.Storage.Persistance.Nh.Core
{
    public interface IConfigurationFactory
    {
        //todo register configuration via autofac
        Configuration Generate();
    }

    public class ConfigurationFactory 
        : IConfigurationFactory
    {
        private readonly IAssemblyLoader _assemblyLoader;
        private readonly ILocalStorageSettings _localStorageSettings;

        public ConfigurationFactory(
            IAssemblyLoader assemblyLoader,
            ILocalStorageSettings localStorageSettings)
        {
            _assemblyLoader = assemblyLoader;
            _localStorageSettings = localStorageSettings;
        }

        public Configuration Generate()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var assemblies = _assemblyLoader
                .GetAppDomainAssembly(_localStorageSettings.AssemblyFilter);
            var fluentConfig = Fluently.Configure()
                .Database(_localStorageSettings.Dialect)
                .Mappings(m =>
                {
                    var autoMapping = AutoMap
                        .Assemblies(
                            new ModelAutomappingConfiguration(),
                            assemblies
                        )
                        .Conventions
                        .AddAssembly(currentAssembly)
                        .UseOverridesFromAssembly(currentAssembly);

                    foreach (var assembly in assemblies)
                    {
                        autoMapping.UseOverridesFromAssembly(assembly);
                    }

                    m.AutoMappings.Add(autoMapping);
                });

            return fluentConfig.BuildConfiguration();
        }
    }
}
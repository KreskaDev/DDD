using System;
using System.Reflection;
using FluentNHibernate.Cfg.Db;

namespace DddSob.Storage.Persistance.Nh
{
    public interface ILocalStorageSettings
    {
        string LocalStorageConnection { get; }
        string LocalStoragePath { get; }
        Func<Assembly, int, bool> AssemblyFilter { get; }
        IPersistenceConfigurer Dialect { get; }
    }

    public class LocalStorageSettings : ILocalStorageSettings
    {
        public string LocalStorageConnection => "";
        public string LocalStoragePath => AppDomain.CurrentDomain.BaseDirectory;
        public Func<Assembly, int, bool> AssemblyFilter => (assembly, no) => assembly.FullName.StartsWith("Hoist.Services.Facade.Payments.");
        public IPersistenceConfigurer Dialect => MsSqlConfiguration.MsSql2012;
    }
}
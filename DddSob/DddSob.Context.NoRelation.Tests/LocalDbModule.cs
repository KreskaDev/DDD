using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DddSob.Persistance.LocalDb.Data;
using DddSob.Storage.Persistance.Nh;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using Module = Autofac.Module;

namespace DddSob.Context.NoRelation.Tests
{
    public class LocalDbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dbServer = new DbServer();
            dbServer.Start();

            builder
                .RegisterInstance(dbServer)
                .As<IDbServer>()
                .SingleInstance();

            //this is working localDb config
            //builder
            //    .Register(context => new LocalDbStorageSettings(dbServer.ConnectionString))
            //    .As<ILocalStorageSettings>()
            //    .SingleInstance();

            //this should be an config for attach real db
            builder
                .Register(context => new LocalDbStorageSettings("data source=.;Initial Catalog=TestDatabase;Integrated Security=True;"))
                .As<ILocalStorageSettings>()
                .SingleInstance();
        }
    }


    public class LocalDbStorageSettings : ILocalStorageSettings
    {
        public string LocalStorageConnection { get; }
        public string LocalStoragePath => AppDomain.CurrentDomain.BaseDirectory;
        public Func<Assembly, int, bool> AssemblyFilter => (assembly, no) => assembly.FullName.StartsWith("DddSob.");
        public IPersistenceConfigurer Dialect { get; }

        public LocalDbStorageSettings(string connectionString)
        {
            LocalStorageConnection = connectionString;
            Dialect = MsSqlConfiguration
                .MsSql2012
                .ConnectionString(connectionString)
                .ShowSql();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using DddSob.Persistance.LocalDb.Data;
using DddSob.Persistance.LocalDb.Http;
using Microsoft.Owin.Testing;
using NHibernate;
using Module = Autofac.Module;


namespace DddSob.Persistance.LocalDb
{

    public sealed class IntegrationServer : IDisposable
    {
        private readonly IDbServer _dbServer;

        private readonly TestServer _webServer;
        /// <summary>
        ///     Creates a new database and starts an OWiN server instance.
        /// </summary>
        public IntegrationServer(IDbServer dbServer, IEnumerable<Module> modules, Assembly startupProjectAssembly)
        {
            _dbServer = dbServer;
            if (_dbServer.ConnectionString == null)
            {
                _dbServer.Start();
            }
            _webServer = TestServer.Create(app =>
            {
                var startup = new Startup();
                startup.Configuration(app, _dbServer.ConnectionString, modules, startupProjectAssembly);
            });
        }

        public void Dispose()
        {
            _webServer?.Dispose();
            _dbServer?.Dispose();
        }

        //public ISessionFactory GetSessionFactory(DbInfo dbInfo)
        //{
        //    return new Configurator().CreateConfiguration(dbInfo).BuildSessionFactory();
        //}

        public HttpClient GetClient()
        {
            return _webServer?.HttpClient;
        }
    }
}
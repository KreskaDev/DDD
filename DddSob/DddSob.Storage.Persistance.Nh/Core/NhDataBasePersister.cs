using System.Reflection;
using DddSob.Storage.Persistance.Nh.Extensions;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DddSob.Storage.Persistance.Nh.Core
{
    public interface IDataBasePersister
    {
        void RecreateDb();
        void DropDatabase();
    }

    public class NhDataBasePersister : IDataBasePersister
    {

        private readonly Configuration _configuration;

        public NhDataBasePersister(Configuration configuration)
        {
            _configuration = configuration;
            //#if DEBUG
            //            Console.SetOut(new DebugWriter());
            //#endif
        }

        public void RecreateDb()
        {
            var schemaExport = new SchemaExport(_configuration);
            schemaExport.Execute(false, true, false);
        }

        public void DropDatabase()
        {
            var schemaExport = new SchemaExport(_configuration);
            schemaExport.Drop(false, true);
        }
    }
}
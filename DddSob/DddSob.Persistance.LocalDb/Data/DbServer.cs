using System;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SQL.LocalDB.Test;

namespace DddSob.Persistance.LocalDb.Data
{
    public sealed class DbServer : IDbServer
    {
        private TempLocalDb _database;

        public void Dispose()
        {
            _database?.Dispose();
        }

        public string ConnectionString => _database?.ConnectionString;

        public string Start() => Start(Guid.NewGuid().ToString());

        public string Start(string databaseName)
        {
            _database = new TempLocalDb(databaseName);
            return _database.ConnectionString;
        }

        public void CreateSchema(Configuration configuration)
        {
            var sql = GenerateDatabaseSql(configuration);

            using (var sessionFactory = configuration.BuildSessionFactory())
            using (var session = sessionFactory.OpenStatelessSession())
            {
                session.CreateSQLQuery(sql).ExecuteUpdate();
                session.Close();
            }
        }

        public string GenerateDatabaseSql(Configuration configuration)
        {
            var sb = new StringBuilder();
            var export = new SchemaExport(configuration);
            export.Create(s => sb.Append($"{s}\n"), false);
            return sb.ToString();
        }

        public void ValidateSchema(Configuration configuration)
        {
            var val = new SchemaValidator(configuration);
            val.Validate();
        }
    }
}
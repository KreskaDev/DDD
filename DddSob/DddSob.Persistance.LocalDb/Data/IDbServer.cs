using System;
using NHibernate.Cfg;

namespace DddSob.Persistance.LocalDb.Data
{
    public interface IDbServer : IDisposable
    {
        string ConnectionString { get; }
        string Start();
        /// <summary>
        ///     Create a temporary LocalDB server instance.
        /// </summary>
        /// <param name="databaseName">DB name</param>
        /// <returns>ConnectionString</returns>
        string Start(string databaseName);

        void CreateSchema(Configuration configuration);
    }
}
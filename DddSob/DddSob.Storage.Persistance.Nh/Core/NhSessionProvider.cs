using System;
using NHibernate;
using NHibernate.Cfg;

namespace DddSob.Storage.Persistance.Nh.Core
{
    public interface INhSessionProvider
    {
        ISession OpenSession();
        IStatelessSession OpenStatelessSession();
        void WithSession(Action<ISession> operation);
    }
    public class NhSessionProvider
        : INhSessionProvider
        , IDisposable
    {
        //private readonly IDataBasePersister _dataBasePersister;

        private ISessionFactory _sessionFactory;
        private readonly object _syncRoot = new object();
        private readonly Configuration _configuration;

        public NhSessionProvider(Configuration configuration)
        {
            _configuration = configuration;
        }

        public ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                lock (_syncRoot)
                {
                    if (_sessionFactory == null)
                    {
                        _sessionFactory = _configuration.BuildSessionFactory();
                    }
                }
            }

            return _sessionFactory.OpenSession();
        }

        public IStatelessSession OpenStatelessSession()
        {
            if (_sessionFactory == null)
            {
                lock (_syncRoot)
                {
                    if (_sessionFactory == null)
                        _sessionFactory = _configuration.BuildSessionFactory();
                }
            }

            return _sessionFactory.OpenStatelessSession();
        }


        public void WithSession(Action<ISession> operation)
        {
            using (var session = OpenSession())
            {
                operation(session);
            }
        }

        public void Dispose()
        {
        }
    }
}

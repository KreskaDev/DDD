﻿using Autofac;
using DddSob.Contexts.NoRelation;
using DddSob.Contexts.NoRelation.Domain.Common.Services;
using DddSob.Contexts.NoRelation.ReadModel;
using DddSob.DomainInfra;
using DddSob.Persistance.LocalDb.Data;
using DddSob.Storage.Persistance.Nh;
using DddSob.Storage.Persistance.Nh.Core;
using MediatR;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace DddSob.Context.NoRelation.Tests
{
    public abstract class DatabaseTestBase
    {
        protected readonly IFixture Fixture;
        protected readonly IContainer Container;
        protected readonly IMediator Mediator;
        protected readonly ISystemTime SystemTime = Substitute.For<ISystemTime>();
        protected readonly IReadModelOperations ReadModelOperations;
        protected DatabaseTestBase()
        {
            Fixture = new Fixture();
            //var dbInfo = DbInfoSubstitute.CreateLocalDbInfo(dbServer.ConnectionString);

            //dbServer.CreateSchema(new SchemaMigrator(), dbInfo);

            //var dbInfo = new LocalDbInfo();
            //_provider = GetConnector(dbInfo);
            //SeedData(Connector, BucketTypeDbModel.BucketTypeDbModels);

            Container = CreateContainer();

            //var dbServer = Container.Resolve<DbServer>();
            var dbPersister = Container.Resolve<IDataBasePersister>();
            dbPersister.RecreateDb();

            //dbServer.CreateSchema(new (), dbInfo);

            //var dbInfo = new LocalDbInfo();
            //_provider = GetConnector(dbInfo);
            //SeedData(Connector, BucketTypeDbModel.BucketTypeDbModels);

            Mediator = Container.Resolve<IMediator>();
            ReadModelOperations = Container.Resolve<IReadModelOperations>();
        }

        //private INhSessionProvider GetConnector(DbInfo dbInfo)
        //{
        //    var configuratorMock = Substitute.For<IConfigurator>();

        //    //var sessionProvider = new NhSessionProvider(
        //    //    new NhDataBasePersister(
        //    //        ILocalStorageSettings
        //    //        ));


        //    var configuration = new Configurator()
        //        .CreateConfiguration(dbInfo);

        //    configuratorMock
        //        .CreateConfiguration<LocalDbInfo>()
        //        .Returns(configuration);

        //    return new LocalStorageConnector(configuratorMock);
        //}

        private IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(DatabaseTestBase).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces();

            //builder.RegisterModule<DirectorsModule>();
            //builder.RegisterModule<SimpleNLogModule>();

            builder.RegisterModule<MediatrModule>();
            builder.RegisterModule<DomainPersistanceNHibernateModule>();
            builder.RegisterModule<LocalDbModule>();
            builder.RegisterModule<DomainInfraModule>();

            builder
                .RegisterInstance(SystemTime)
                .As<ISystemTime>();
            
            return builder.Build();
        }

        //private void SeedData(ILocalStorageConnector connector, IEnumerable<object> objects)
        //{
        //    using (var sf = connector.LocalSessionFactory)
        //    using (var session = sf.OpenStatelessSession())
        //    using (var transaction = session.BeginTransaction())
        //    {
        //        foreach (var model in objects)
        //        {
        //            session.Insert(model);
        //        }

        //        transaction.Commit();
        //        session.Close();
        //    }
        //}
    }
}
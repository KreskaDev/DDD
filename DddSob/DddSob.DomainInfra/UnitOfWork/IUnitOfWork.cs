using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.Model;

namespace DddSob.DomainInfra.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<Result<TAggregateRoot>> Get<TAggregateRoot>(Guid identifier) 
            where TAggregateRoot : AggregateRootEntity;

        Task<Result<TAggregateRoot>> Add<TAggregateRoot>(TAggregateRoot root) 
            where TAggregateRoot : AggregateRootEntity;

        Result<TAggregateRoot> Attach<TAggregateRoot>(TAggregateRoot aggregate)
            where TAggregateRoot : AggregateRootEntity;

        bool TryGet(Guid id, out AggregateRootEntity aggregate);
        bool HasChanges();
        IEnumerable<AggregateRootEntity> GetDirtyAggregates();
        Task Compleate();
    }
}
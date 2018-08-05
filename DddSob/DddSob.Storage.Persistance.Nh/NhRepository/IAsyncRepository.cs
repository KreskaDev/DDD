using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Storage.Persistance.Nh.Model;

namespace DddSob.Storage.Persistance.Nh.NhRepository
{
    public interface IAsyncRepository
    {
        Task<Result<TAggregateRoot>> Get<TAggregateRoot>(Guid identifier)
        where TAggregateRoot : NhAggregateRootEntity;
        Task<Result<TAggregateRoot>> Add<TAggregateRoot>(TAggregateRoot root)
        where TAggregateRoot : NhAggregateRootEntity;

        Task<Result<TAggregateRoot>> Save<TAggregateRoot>(TAggregateRoot aggregate)
        where TAggregateRoot : NhAggregateRootEntity;
    }
}
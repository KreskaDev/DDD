using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.Model;
using DddSob.Storage.Persistance.Nh.NhRepository;
using MediatR;

namespace DddSob.DomainInfra.UnitOfWork
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly IMediator _mediator;
        private readonly IAsyncRepository _repository;


        private readonly ConcurrentDictionary<Guid, AggregateRootEntity> _aggregates;
        public UnitOfWork(IMediator mediator, IAsyncRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
            _aggregates = new ConcurrentDictionary<Guid, AggregateRootEntity>();
        }

        public async Task<Result<TAggregateRoot>> Get<TAggregateRoot>(Guid identifier)
            where TAggregateRoot : AggregateRootEntity
        => await _repository.Get<TAggregateRoot>(identifier)
            .OnSuccess(root => Attach(root));

        public async Task<Result<TAggregateRoot>> Add<TAggregateRoot>(TAggregateRoot root)
            where TAggregateRoot : AggregateRootEntity
        => await _repository.Add(root)
            .OnSuccess(x => Attach(x));

        public Result<TAggregateRoot> Attach<TAggregateRoot>(TAggregateRoot aggregate)
            where TAggregateRoot : AggregateRootEntity
        {
            if (aggregate == null)
            {
                return Result.Fail<TAggregateRoot>(new ArgumentNullException(nameof(aggregate)).ToString());
            }

            if (!_aggregates.TryAdd(aggregate.Id, aggregate))
            {
                return Result.Fail<TAggregateRoot>(new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture,
                        "Resources.ConcurrentUnitOfWork_AttachAlreadyAdded",
                        aggregate.GetType().Name, aggregate.Id)).ToString());

            }

            return Result.Ok(aggregate);
        }

        public bool TryGet(Guid id, out AggregateRootEntity aggregate)
            => _aggregates.TryGetValue(id, out aggregate);

        public bool HasChanges()
            => _aggregates.Values.Any(aggregate => aggregate.HasChanges());

        public IEnumerable<AggregateRootEntity> GetDirtyAggregates()
            => _aggregates
                .Values
                .Where(aggregate => aggregate.HasChanges());

        public async Task Compleate()
            => await Task.WhenAll(GetDirtyAggregates()
                .Select(async x => await _repository
                    .Save(x)
                    .OnSuccess(aggregate => aggregate.GetChanges())
                    .OnSuccess(async notifications =>
                    {
                        foreach (var notification in notifications)
                        {
                            await _mediator.Publish(notification);
                        }
                    })
                )
            );//clear changes
    }
}
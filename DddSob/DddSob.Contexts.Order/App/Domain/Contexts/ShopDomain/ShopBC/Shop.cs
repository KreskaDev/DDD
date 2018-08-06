using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events;
using DddSob.DomainInfra.Aggregates;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ShopBC
{
    public class Shop
        : AggregateRootEntity
    {
        public static async Task<Result<Shop>> Create(Guid id, Guid ownerId, string name)
            => Result.Ok(new Shop(new NewShopEvent(id, ownerId, name)));

        protected Shop(NewShopEvent @event)
            => ApplyChange<Shop>(@event);

        public Guid OwnerId { get; protected set; }
        public string Name { get; protected set; }
        
        protected Shop()
        {
            Register<NewShopEvent>(When);
        }

        private void When(NewShopEvent @event)
        {
            Id = @event.Id;
            OwnerId = @event.OwnerId;
            Name = @event.Name;
        }
    }
}
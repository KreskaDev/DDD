using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.Aggregates;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Sagas.ShoppingSagas
{
    public class ShoppingSagaData
        //this should not be and aggregate but for now to easy use of an repository
        : AggregateRootEntity
    {
        public static async Task<Result<ShoppingSagaData>> Create(Guid id, OrderSnaphot orderSnaphot)
            => Result.Ok(new ShoppingSagaData(new NewShopingSagaEvent(id, orderSnaphot)));

        public ShoppingSagaData(NewShopingSagaEvent @event)
            : this() 
            => ApplyChange<NewShopingSagaEvent>(@event);

        private ShoppingSagaData()
        {
            Register<NewShopingSagaEvent>(When);
        }

        private void When(NewShopingSagaEvent @event)
        {
            Id = @event.Id;
            OrderSnapshot = @event.OrderSnaphot;
        }

        public Guid Id { get; protected set; }
        public OrderSnaphot OrderSnapshot { get; protected set; }
    }

    public class OrderSnaphot
    {
        public Guid Id { get; set; }

    }

    public class NewShopingSagaEvent : INotification
    {
        public Guid Id { get; }
        public OrderSnaphot OrderSnaphot { get; }

        public NewShopingSagaEvent(Guid id, OrderSnaphot orderSnaphot)
        {
            Id = id;
            OrderSnaphot = orderSnaphot;
        }
    }
}
using System;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events;
using DddSob.DomainInfra.Aggregates;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model
{
    public class OrderLine
        : AggregateRootEntity
    {
        public static OrderLine Create(Guid orderLineId, Guid orderId, OrderLineProductSnapshot product, decimal amount)
        => new OrderLine(new NewOrderLineEvent(orderLineId, orderId, product, amount));

        private OrderLine()
        {
            Register<NewOrderLineEvent>(When);
        }

        private OrderLine(NewOrderLineEvent @event)
            : this()
            => ApplyChange<OrderLine>(@event);

        public Guid OrderId { get; protected set; }
        public OrderLineProductSnapshot Product { get; protected set; }
        public decimal Amount { get; protected set; }
        public Money TotalAmount => new Money
        (
            Product.Price.Amount * Amount,
            Product.Price.Currency
        );

        private void When(NewOrderLineEvent @event)
        {
            Id = @event.OrderLineId;
            OrderId = @event.OrderId;
            Amount = @event.Amount;
            Product = @event.Product;
        }
    }
}
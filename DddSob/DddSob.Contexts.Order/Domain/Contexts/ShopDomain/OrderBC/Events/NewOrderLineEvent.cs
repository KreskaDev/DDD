using System;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events
{
    public class NewOrderLineEvent
        : INotification
    {

        public Guid OrderLineId { get; }
        public Guid OrderId { get; }
        public OrderLineProductSnapshot Product { get; }
        public decimal Amount { get; }

        public NewOrderLineEvent(Guid orderLineId, Guid orderId, OrderLineProductSnapshot product, decimal amount)
        {
            OrderLineId = orderLineId;
            OrderId = orderId;
            Product = product;
            Amount = amount;
        }
    }
}
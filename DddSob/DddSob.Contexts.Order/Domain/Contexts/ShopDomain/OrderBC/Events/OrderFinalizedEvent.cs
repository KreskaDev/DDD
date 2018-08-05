using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events
{
    public class OrderFinalizedEvent : INotification
    {
        public Guid OrderId { get; }

        public OrderFinalizedEvent(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
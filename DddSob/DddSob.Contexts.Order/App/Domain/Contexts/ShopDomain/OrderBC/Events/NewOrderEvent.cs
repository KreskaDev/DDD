using System;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events
{
    public class NewOrderEvent 
        : INotification
    {
        public Guid OrderId { get; }
        public Customer Buyer { get; }
        public DateTime Created { get; }
        public NewOrderEvent(Guid orderId, Customer buyer, DateTime created)
        {
            OrderId = orderId;
            Buyer = buyer;
            Created = created;
        }
    }
}
using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events
{
    public class NewShopEvent : INotification
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string Name { get; }

        public NewShopEvent(Guid id, Guid ownerId, string name)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
        }
    }
}
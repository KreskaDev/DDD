using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.TenantsBC.Events
{
    public class NewTenantEvent : INotification
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string Name { get; }

        public NewTenantEvent(Guid id, Guid ownerId, string name)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
        }
    }
}
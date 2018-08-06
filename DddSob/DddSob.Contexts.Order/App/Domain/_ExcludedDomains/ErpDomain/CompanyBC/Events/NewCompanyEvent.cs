using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.ErpDomain.CompanyBC.Events
{
    public class NewCompanyEvent : INotification
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string Name { get; }

        public NewCompanyEvent(Guid id, Guid ownerId, string name)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
        }
    }
}
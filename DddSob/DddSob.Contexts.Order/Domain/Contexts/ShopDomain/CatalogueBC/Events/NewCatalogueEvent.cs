using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Events
{
    public class NewCatalogueEvent : INotification
    {
        public Guid Id { get; }
        public string Name { get; }

        public NewCatalogueEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
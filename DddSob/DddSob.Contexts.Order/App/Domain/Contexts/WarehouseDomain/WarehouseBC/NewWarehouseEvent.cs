using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.WarehouseBC
{
    public class NewWarehouseEvent : INotification
    {
        public Guid Id { get; }
        public string Name { get; }

        public NewWarehouseEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
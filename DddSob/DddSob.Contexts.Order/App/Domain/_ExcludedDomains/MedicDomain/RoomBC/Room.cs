using System;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.Model;
using DddSob.Storage.Persistance.Nh.NhRepository;
using DddSob.Storage.Persistance.Nh.Relations;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.RoomBC
{
    public class Room
        : AggregateRootEntity
    {
        public string Name { get; protected set; }
        public RoomLocation RoomLocation { get; set; }
    }

    public class RoomLocation
        : Entity<Guid>
        , IEntity
    {
        public RoomLocation(Guid id) 
            : base(id)
        {}

        public string City { get; protected set; }
        public string Street { get; set; }
        public int No { get; set; }
    }
}
using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.LocationsBC.Events;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.LocationsBC.Model
{
    public class Location
        : AggregateRootEntity
    {
        public static async Task<Result<Location>> Register(Guid id, string country,string street,string number,string zipCode)
        => Result.Ok(new Location(new LocationRegisteredEvent(id,country,street,number,zipCode)));

        public string Country { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public string ZipCode { get; protected set; }

        private Location(LocationRegisteredEvent @event) 
            : this() 
            => ApplyChange<Location>(@event);

        private Location()
        {
            Register<LocationRegisteredEvent>(When);
        }

        private void When(LocationRegisteredEvent @event)
        {
            Country = @event.Country;
            Street = @event.Street;
            Number = @event.Number;
            ZipCode = @event.ZipCode;
        }
    }
}

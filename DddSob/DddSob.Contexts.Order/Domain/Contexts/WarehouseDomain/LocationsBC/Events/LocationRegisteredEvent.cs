using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.LocationsBC.Events
{
    public class LocationRegisteredEvent : INotification
    {
        public Guid Id { get; }
        public string Country { get; }
        public string Street { get; }
        public string Number { get; }
        public string ZipCode { get; }

        public LocationRegisteredEvent(Guid id, string country, string street, string number, string zipCode)
        {
            Id = id;
            Country = country;
            Street = street;
            Number = number;
            ZipCode = zipCode;
        }
    }
}
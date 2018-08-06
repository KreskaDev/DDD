using System;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.AgentsBC;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.PatientsBC;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.RoomBC;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.VisitBC.Model
{
    public class Visit
        : AggregateRootEntity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Agent Agent { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
    }
}
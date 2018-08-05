using System;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.PatientsBC
{
    public class Patient
        : AggregateRootEntity
    {
        public static Patient Register(Guid id, string firstName, string lastName, string phone)
            => new Patient(new PatientRegisteredEvent(id, firstName, lastName, phone));

        protected Patient(PatientRegisteredEvent @event)
        {
            ApplyChange<Patient>(@event);
        }

        public string Firstname { get; protected set; }
        public string LastName { get; protected set; }
        public string Phone { get; protected set; }


        protected Patient()
        {
            Register<PatientRegisteredEvent>(When);
        }

        private void When(PatientRegisteredEvent @event)
        {
            Id = @event.Id;
            Firstname = @event.FirstName;
            LastName = @event.LastName;
            Phone = @event.Phone;
        }
    }
}
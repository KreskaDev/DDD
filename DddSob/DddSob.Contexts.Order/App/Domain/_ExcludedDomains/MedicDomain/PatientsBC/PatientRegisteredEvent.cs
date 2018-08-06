using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.PatientsBC
{
    public class PatientRegisteredEvent : INotification
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Phone { get; }

        public PatientRegisteredEvent(Guid id, string firstName, string lastName, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
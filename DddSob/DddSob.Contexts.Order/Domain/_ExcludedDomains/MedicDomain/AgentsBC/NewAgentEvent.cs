using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.AgentsBC
{
    public class NewAgentEvent : INotification
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public NewAgentEvent(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
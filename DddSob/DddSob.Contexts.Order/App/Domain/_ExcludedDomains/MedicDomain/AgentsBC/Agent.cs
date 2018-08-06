using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.AgentsBC
{
    public class Agent
        : AggregateRootEntity
    {
        public static async Task<Result<Agent>> Register(Guid id, string firstName, string lastName)
            => Result.Ok(new Agent(new NewAgentEvent(id, firstName, lastName)));

        protected Agent(NewAgentEvent message) 
            : this() 
            => ApplyChange<Agent>(message);

        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Agent()
        {
            Register<NewAgentEvent>(When);
        }

        private void When(NewAgentEvent message)
        {
            Id = message.Id;
            FirstName = message.FirstName;
            LastName = message.LastName;
        }
    }
}
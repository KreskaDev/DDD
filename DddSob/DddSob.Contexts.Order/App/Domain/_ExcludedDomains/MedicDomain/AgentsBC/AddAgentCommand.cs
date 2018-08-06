using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.AgentsBC
{
    public class AddAgentCommand : IRequest
    {
        public AddAgentCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
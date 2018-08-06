using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Events
{
    public class ContractorBlockedEvent : INotification
    {
        public string Reason { get; }

        public ContractorBlockedEvent(string reason)
        {
            this.Reason = reason;
        }
    }
}
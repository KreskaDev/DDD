using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Events
{
    public class ContractorUnblockedEvent : INotification
    {
        public string Reason { get; }

        public ContractorUnblockedEvent(string reason)
        {
            this.Reason = reason;
        }
    }
}
using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Events;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Model
{
    public class Contractor
    : AggregateRootEntity
    {
        public static async Task<Result<Contractor>> Create(Guid id, string name, string nip, string address)
            => Result.Ok(new Contractor(new NewContractorEvent(id, name, nip, address)));

        protected Contractor(NewContractorEvent @event)
            : this()
            => ApplyChange<Contractor>(@event);

        protected Contractor()
        {
            Register<ContractorBlockedEvent>(When);
            Register<NewContractorEvent>(When);
            Register<ContractorUnblockedEvent>(When);
        }

        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string Nip { get; protected set; }
        public bool IsBlocked { get; protected set; }
        public string BlockReason { get; protected set; }

        public Result<Contractor> BlockKontrachent(string reason) 
            => IsBlocked // it could be just any other validation method
                ? Result.Fail<Contractor>("Contractor already blocked") 
                : ApplyChange<Contractor>(new ContractorBlockedEvent(reason));

        public Result<Contractor> UnblockKontrachent(string reason) 
            => !IsBlocked 
                ? Result.Fail<Contractor>("Contractor already Unblocked") 
                : ApplyChange<Contractor>(new ContractorUnblockedEvent(reason));

        void When(NewContractorEvent @event)
        {
            Name = @event.Name;
            Nip = @event.Nip;
            Address = @event.Address;
        }

        void When(ContractorBlockedEvent @event)
        {
            IsBlocked = true;
            BlockReason = @event.Reason;
            //OrderSnaphot = new VideoTitleId(@event.OrderSnaphot);
            //Title = @event.Title;
        }

        void When(ContractorUnblockedEvent @event)
        {
            IsBlocked = false;
            BlockReason = @event.Reason;
        }
    }
}
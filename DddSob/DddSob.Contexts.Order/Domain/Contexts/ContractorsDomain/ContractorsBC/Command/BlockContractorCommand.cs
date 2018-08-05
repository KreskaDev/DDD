using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Command
{
    public class BlockContractorCommand:
        IRequest<Result>
    {
        public BlockContractorCommand(Guid contractorId, string reason)
        {
            ContractorId = contractorId;
            Reason = reason;
        }

        public Guid ContractorId { get; } 
        public string Reason { get; }
    }
}
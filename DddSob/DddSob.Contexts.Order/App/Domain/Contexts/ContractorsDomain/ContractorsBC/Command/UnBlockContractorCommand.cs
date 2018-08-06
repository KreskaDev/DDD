using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Command
{
    public class UnBlockContractorCommand :
        IRequest<Result>
    {
        public UnBlockContractorCommand(Guid contractorId, string reason)
        {
            ContractorId = contractorId;
            Reason = reason;
        }

        public Guid ContractorId { get; }
        public string Reason { get; }
    }
}
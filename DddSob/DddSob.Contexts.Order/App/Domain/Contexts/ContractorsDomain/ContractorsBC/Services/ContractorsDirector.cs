using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Command;
using DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Model;
using DddSob.DomainInfra.UnitOfWork;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Services
{
    public class ContractorsDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContractorsDirector(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<Contractor>> AddContractor(AddCrontractorCommand command) 
            => await Contractor.Create(Guid.NewGuid(), command.Name, command.Nip, command.Address)
            .OnSuccess(async contractor => await _unitOfWork.Add(contractor))
            .OnSuccess(async contractor => await _unitOfWork.Compleate());
        
        public async Task<Result<Contractor>> Block(BlockContractorCommand command)
            => await _unitOfWork.Get<Contractor>(command.ContractorId)
                .OnSuccess(kontrachent => kontrachent.BlockKontrachent(command.Reason))
                .OnSuccess(async contractor => await _unitOfWork.Compleate());

        public async Task<Result> Unblock(UnBlockContractorCommand command)
            => await _unitOfWork.Get<Contractor>(command.ContractorId)
                .OnSuccess(kontrachent => kontrachent.UnblockKontrachent(command.Reason))
                .OnSuccess(async contractor =>await _unitOfWork.Compleate());
    }
}
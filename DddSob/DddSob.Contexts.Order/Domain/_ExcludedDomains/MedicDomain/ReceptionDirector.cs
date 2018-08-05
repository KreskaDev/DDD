using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain.AgentsBC;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.MedicDomain
{
    public class ReceptionDirector
        : IRequestHandler<AddAgentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository _repository;

        public ReceptionDirector(
            IAsyncRepository repository, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Agent>> AddAgent(string firstName, string lastName)
            => await Agent.Register(Guid.NewGuid(), firstName, lastName)
            .OnSuccess(async agent => await _unitOfWork.Add(agent))
            .OnSuccess(async agentId => await _unitOfWork.Compleate());

        public async Task Handle(AddAgentCommand request, CancellationToken cancellationToken)
            => await Agent.Register(Guid.NewGuid(), request.FirstName, request.LastName)
            .OnSuccess(async agent => await _repository.Add(agent))
            .OnSuccess(async agentId => await _unitOfWork.Compleate());


        //public Result<Guid> AddPatient(string firstName, string lastName, string phone)
        //{

        //}

        //public Result SetWorkTimeForAgent()
        //{

        //}

        //public Result RegisterVisit()
        //{

        //}

    }
}
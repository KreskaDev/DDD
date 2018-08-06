using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.BussinesLogic;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Model;
//using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.EmployeesBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Services
{
    public class CompanyDirector
    : IRequestHandler<RegisterCompanyCommand, Result<Company>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IInvitationService _invitationService;

        public CompanyDirector(
            IUnitOfWork unitOfWork)
            //IInvitationService invitationService)
        {
            _unitOfWork = unitOfWork;
            //_invitationService = invitationService;
        }

        public Task<Result<Company>> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
            => Company.Register(Guid.NewGuid(), request.OwnerId, request.CompanyName)
            .OnSuccess(company => _unitOfWork.Add(company))
            .OnSuccess(companyId => _unitOfWork.Compleate());


        //public async Task<Result<Employee>> InviteUser(Guid companyId, string email)
        //    => await Employee.Create(Guid.NewGuid(), companyId, Guid.Empty)
        //    .OnSuccess(async employee => await _unitOfWork.Add(employee))
        //    .OnSuccess(async employee => await _unitOfWork.Compleate())
        //;
    }
}
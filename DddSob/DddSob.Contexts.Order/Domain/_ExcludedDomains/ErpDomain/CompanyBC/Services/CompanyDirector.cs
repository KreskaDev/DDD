using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.BussinesLogic;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Model;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.EmployeesBC.Model;
using DddSob.DomainInfra.UnitOfWork;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Services
{
    public class CompanyDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvitationService _invitationService;

        public CompanyDirector(
            IUnitOfWork unitOfWork, 
            IInvitationService invitationService)
        {
            _unitOfWork = unitOfWork;
            _invitationService = invitationService;
        }

        public Task<Result<Company>> RegisterCompany(Guid ownerId, string name)
            => Company.Register(Guid.NewGuid(), ownerId, name)
            .OnSuccess(company => _unitOfWork.Add(company))
            .OnSuccess(companyId => _unitOfWork.Compleate());


        public async Task<Result<Employee>> InviteUser(Guid companyId, string email)
            => await Employee.Create(Guid.NewGuid(), companyId, Guid.Empty)
            .OnSuccess(async employee => await _unitOfWork.Add(employee))
            .OnSuccess(async employee => await _unitOfWork.Compleate())
        ;
    }
}
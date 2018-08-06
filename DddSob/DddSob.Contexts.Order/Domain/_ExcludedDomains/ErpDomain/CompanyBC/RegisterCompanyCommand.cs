using System;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Model;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC
{
    public class RegisterCompanyCommand 
        : IRequest<Result<Company>>
    {
        public Guid OwnerId { get; }
        public string CompanyName { get; }

        public RegisterCompanyCommand(Guid ownerId, string companyName)
        {
            OwnerId = ownerId;
            CompanyName = companyName;
        }
    }
}
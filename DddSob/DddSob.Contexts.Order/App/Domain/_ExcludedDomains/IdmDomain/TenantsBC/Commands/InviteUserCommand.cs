using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.TenantsBC.Commands
{
    public class InviteUserCommand 
        : IRequest<Result<Guid>>
    {
        public Guid CompanyId { get; }
        public string Email { get; }

        public InviteUserCommand(Guid companyId, string email)
        {
            CompanyId = companyId;
            Email = email;
        }
    }
}
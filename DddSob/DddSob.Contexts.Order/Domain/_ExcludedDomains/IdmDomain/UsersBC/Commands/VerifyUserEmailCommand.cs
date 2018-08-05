using System;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Model;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Commands
{
    public class VerifyUserEmailCommand
        : IRequest<Result<User>>
    {
        public VerifyUserEmailCommand(Guid userId, string verificationToken)
        {
            UserId = userId;
            VerificationToken = verificationToken;
        }

        public Guid UserId { get; }
        public string VerificationToken { get; }
    }
}

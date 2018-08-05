using System;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Model;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Commands
{
    public class RegisterUserCommand
        : IRequest<Result<User>>
    {
        public RegisterUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}

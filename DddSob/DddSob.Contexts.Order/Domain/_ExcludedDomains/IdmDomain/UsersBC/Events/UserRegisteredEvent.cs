using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Events
{
    public class UserRegisteredEvent
        : INotification
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string VerificationToken { get; }

        public UserRegisteredEvent(
            Guid id, string email, string password, string verificationToken)
        {
            Id = id;
            Email = email;
            Password = password;
            VerificationToken = verificationToken;
        }
    }
}
using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Events
{
    public class UserRegistrationCompleateEvent
        : INotification
    {
        public Guid UserId { get; }

        public UserRegistrationCompleateEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
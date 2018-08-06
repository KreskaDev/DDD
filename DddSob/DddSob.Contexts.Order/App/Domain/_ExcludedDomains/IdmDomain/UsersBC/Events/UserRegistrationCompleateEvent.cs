using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Events
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
using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Events;
using DddSob.DomainInfra.Model;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Model
{
    public class User
        : AggregateRootEntity
    {
        public static async Task<Result<User>> Register(string email, string password, string verificationToken)
            => Result.Ok(new User(new UserRegisteredEvent(Guid.NewGuid(), email, password, verificationToken)));
        
        public virtual string Pass { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual Email Email { get; protected set; }

        protected User(UserRegisteredEvent userRegisteredEvent)
            : this()
            => ApplyChange<User>(userRegisteredEvent);

        public virtual Result<User> CompleateRegistration(string registrationToken) 
            => Email
            .Verify(registrationToken)
            .OnSuccess(() => ApplyChange<User>(new UserRegistrationCompleateEvent(Id)));

        protected User()
        {
            Register<UserRegisteredEvent>(When);
            Register<UserRegistrationCompleateEvent>(When);
        }
        
        private void When(UserRegisteredEvent @event)
        {
            Id = @event.Id;
            Email = new Email(@event.Email, @event.VerificationToken);
            Pass = @event.Password;

        }

        private void When(UserRegistrationCompleateEvent @event)
        {
            IsActive = true;
        }
    }
}

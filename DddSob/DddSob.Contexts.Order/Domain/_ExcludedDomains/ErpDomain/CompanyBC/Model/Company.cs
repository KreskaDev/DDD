using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Events;
using DddSob.DomainInfra.Model;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.CompanyBC.Model
{
    public class Company
    : AggregateRootEntity
    {
        public static async Task<Result<Company>> Register(Guid id, Guid ownerId, string name)
            => Result.Ok(new Company(new NewCompanyEvent(id, ownerId, name)));

        protected Company(NewCompanyEvent @event) : this()
        {
            ApplyChange<Company>(@event);
        }

        public virtual Guid OwnerId { get; protected set; }
        public virtual string Name { get; protected set; }

        protected Company()
        {
            Register<NewCompanyEvent>(When);
        }

        private void When(NewCompanyEvent @event)
        {
            Id = @event.Id;
            OwnerId = @event.OwnerId;
            Name = @event.Name;
        }
    }
}

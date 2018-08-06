using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.TenantsBC.Events;
using DddSob.DomainInfra.Model;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.TenantsBC.Model
{
    public class Tenant
        : AggregateRootEntity 
    {
        public static async Task<Result<Tenant>> Create(Guid id, Guid ownerId, string name)
            => Result.Ok(new Tenant(new NewTenantEvent(id, ownerId, name)));

        protected Tenant(NewTenantEvent msg) 
        : this()
        => ApplyChange<Tenant>(msg);

        public virtual Guid TenantOwner { get; set; }
        public virtual string Name { get; set; }


        protected Tenant()
        {
            Register<NewTenantEvent>(When);
        }

        private void When(NewTenantEvent msg)
        {
            Id = msg.Id;
            Name = msg.Name;
            TenantOwner = msg.OwnerId;
        }
    }

    //public class TenantName
    //{
    //    public string Name { get; set; }
    //}
}

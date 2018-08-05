using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Events;
using DddSob.DomainInfra.Aggregates;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Model
{
    public class Account
    : AggregateRootEntity
    {
        public static async Task<Result<Account>> Create(Guid newGuid, Guid userId)
            => Result.Ok(new Account(new NewAccountEvent(newGuid, userId)));

        public Account(NewAccountEvent @event) 
            : this()
            => ApplyChange<Account>(@event);

        //public static Account Register(Guid id, Guid userId)
        // => new Account(new NewAccountEvent(id, userId));
        //protected Account(NewAccountEvent @event) 
        //    => ApplyChange(@event);

        public Guid UserId { get; protected set; }
        public Money Amount { get; protected set; }

        public Result<Account> AddFounds(Money money)
            => money.Currency == Amount.Currency
            ? ApplyChange<Account>(new FoundsAddedEvent(Id, money))
            : Result.Fail<Account>("Multiple account with different currencies not allowed right now.");

        protected Account() 
        {
            Register<NewAccountEvent>(When);
        }

        private void When(NewAccountEvent @event)
        {
            Id = @event.Id;
            UserId = @event.UserId;
            Amount = new Money(0, Currency.Pln);
        }
    }

    public class AccountMappingOverride
        : IAutoMappingOverride<Account>
    {
        public void Override(AutoMapping<Account> mapping)
        {
            mapping.Component(x => x.Amount);
        }
    }
}

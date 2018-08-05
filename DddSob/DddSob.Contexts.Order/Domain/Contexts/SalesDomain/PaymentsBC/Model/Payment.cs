using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Events;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Model
{
    public class Payment
        : AggregateRootEntity
    {
        public static async Task<Result<Payment>> ScheadulePayment(Guid id, Guid payerId, Money amount)
            => Result.Ok(new Payment(new PaymentScheaduledEvent(id, payerId, amount)));

        //public static Payment MakePayment
        //    => new Payment(new PaymentMadedEvent());

        private Payment(PaymentScheaduledEvent @event)
            => ApplyChange<Payment>(@event);

        protected Payment()
        {
            Register<PaymentScheaduledEvent>(When);
        }

        private void When(PaymentScheaduledEvent @event)
        {
            Id = @event.Id;
            Amount = @event.Amount;
        }

        public Money Amount { get; protected set; }
    }

    public class PaymentMappingOverride
        : IAutoMappingOverride<Payment>
    {
        public void Override(AutoMapping<Payment> mapping)
        {
            mapping.Component(x => x.Amount);
        }
    }
}

using System;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Events
{
    public class PaymentScheaduledEvent
        : INotification
    {
        public Guid Id { get; }
        public Guid PayerId { get; }
        public Money Amount { get; }

        public PaymentScheaduledEvent(Guid id, Guid payerId, Money amount)
        {
            Id = id;
            PayerId = payerId;
            Amount = amount;
        }
    }
}
using System;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Events
{
    public class FoundsAddedEvent : INotification
    {
        public Guid Id { get; }
        public Money Money { get; }

        public FoundsAddedEvent(Guid id, Money money)
        {
            Id = id;
            Money = money;
        }
    }
}
using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Events
{
    public class NewAccountEvent : INotification
    {
        public Guid Id { get; }
        public Guid UserId { get; }

        public NewAccountEvent(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
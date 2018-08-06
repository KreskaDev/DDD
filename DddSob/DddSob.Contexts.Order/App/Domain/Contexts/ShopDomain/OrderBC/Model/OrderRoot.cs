using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events;
using DddSob.DomainInfra.Aggregates;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model
{
    public class OrderMappingOverride
        : IAutoMappingOverride<OrderRoot>
    {
        public void Override(AutoMapping<OrderRoot> mapping)
        {
            //mapping
            //    .Id(x => x.Id)
            //    .
            //ToDo:kreskadev
        }
    }

    public class OrderRoot
        : AggregateRootEntity
    {
        //todo do not use vo in events
        public static async Task<Result<OrderRoot>> Create(Guid orderId, Customer buyer, DateTime created)
            => Result.Ok(new OrderRoot(new NewOrderEvent(orderId, buyer, created)));

        public Customer Buyer { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public bool IsCompleate { get; protected set; }
        public Money Tax { get; protected set; }

        private OrderRoot()
        {
            Register<NewOrderEvent>(When);
            Register<OrderFinalizedEvent>(When);
        }

        private OrderRoot(NewOrderEvent @event) 
            : this() 
            => ApplyChange<OrderRoot>(@event);

        private void When(NewOrderEvent @event)
        {
            Id = @event.OrderId;
            IsCompleate = false;
            CreationDate = @event.Created;
            Buyer = @event.Buyer;
        }

        public Result<OrderRoot> FinalizeOrder() 
            => ApplyChange<OrderRoot>(new OrderFinalizedEvent(Id));

        private void When(OrderFinalizedEvent @event)
        {
            IsCompleate = true;
        }
    }


    //public class BlaBlaOrder : OrderRoot
    //{
    //    public int MinimalAmount { get; set; }
    //    public IList<OrderLine> OrderLines { get; set; }

    //    public void AddOrderLine(ProductSnapshot product, int amount)
    //    {
    //        OrderLines.Add(new OrderLine(product, amount));
    //    }
    //}
}
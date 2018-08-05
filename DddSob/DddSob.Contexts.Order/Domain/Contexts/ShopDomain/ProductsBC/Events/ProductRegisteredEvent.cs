using System;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Events
{
    public class ProductRegisteredEvent : INotification
    {
        public Guid Id { get; }
        public string Name { get; }
        public Money Price { get; }

        public ProductRegisteredEvent(Guid id, string name, Money price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
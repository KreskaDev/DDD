using System;
using DddSob.Contexts.NoRelation.Domain.Common.Models;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model
{
    public class OrderLineProductSnapshot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
    }
}
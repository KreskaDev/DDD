using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.DomainInfra.Aggregates;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.WarehouseBC
{
    public class WarehouseRoot
        : AggregateRootEntity
    {
        public static async Task<Result<WarehouseRoot>> Create(Guid id, string name)
            => Result.Ok(new WarehouseRoot(new NewWarehouseEvent(id, name)));

        protected WarehouseRoot(NewWarehouseEvent @event)
            : this()
            => ApplyChange<WarehouseRoot>(@event);
            
        protected WarehouseRoot()
        {
            Register<NewWarehouseEvent>(When);
        }

        private void When(NewWarehouseEvent @event)
        {
            Id = @event.Id;
            Name = @event.Name;
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        //this is not valid because there is an aggregate ItemStockRoot
        public IList<ItemStockRoot> ItemStocks { get; protected set; }

        public WarehouseRoot AddProductSnap(ItemStockRoot itemStock)
        {
            ItemStocks.Add(itemStock);
            return this;
        }
    }

    public class ItemStockRoot
        : AggregateRootEntity
    {
        public class WarehouseProductSnapshot
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Money Price { get; set; }
        }

        public ItemStockRoot(WarehouseProductSnapshot productSnap, decimal amount)
        {
            Product = productSnap;
            Stock = amount;
        }

        public int Id { get; protected set; }
        public int WarehouseId { get; protected set; }
        public WarehouseProductSnapshot Product { get; protected set; }
        public decimal Stock { get; protected set; }
    }
}

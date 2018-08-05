using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Events;
using DddSob.DomainInfra.Aggregates;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Model
{
    public class Product
        : AggregateRootEntity
    {
        public static async Task<Result<Product>> Register(Guid id, string name, Money price) 
            => Result.Ok(new Product(new ProductRegisteredEvent(id, name, price)));
        private Product(ProductRegisteredEvent @event) 
            => ApplyChange<Product>(@event);

        public Product()
        {
            Register<ProductRegisteredEvent>(When);
        }

        private void When(ProductRegisteredEvent @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Price = @event.Price;
        }
        
        public string Name { get; protected set; }
        public Money Price { get; protected set; }
    }
}
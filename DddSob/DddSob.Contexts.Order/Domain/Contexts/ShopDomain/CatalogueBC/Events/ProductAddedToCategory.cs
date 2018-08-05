using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Events
{
    public class ProductAddedToCategory : INotification
    {
        public ProductAddedToCategory(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
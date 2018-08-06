using System;
using System.Collections.Generic;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Events;
using DddSob.Storage.Persistance.Nh.Model;
using DddSob.Storage.Persistance.Nh.Relations;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Model
{
    public class CatalogueCategory
        : Entity<Guid>, IEntity
    {
        public static CatalogueCategory Create(string name, string image)
            => new CatalogueCategory(Guid.NewGuid(), name, image);
        protected CatalogueCategory(Guid id, string name, string image) 
            : base(id)
        {
            //Id = id;
            Name = name;
            Image = image;
        }

        //public Guid Id { get; set; }
        public string Name { get; }
        public string Image { get; }

        public IList<CatalogueCategory> SubCategories { get; } = new List<CatalogueCategory>();
        public IList<CatalogueProduct> Products { get; } = new List<CatalogueProduct>();

        public void AddSubCategory(CatalogueCategory category)
        {
            SubCategories.Add(category);
        }

        public void AddProduct(CatalogueProduct product)
        {
            Products.Add(product);
        }

        public void When(ProductAddedToCategory msg)
        {
            Products.Add(new CatalogueProduct(msg.Id));
        }
    }
}
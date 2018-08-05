using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Events;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Model;
using DddSob.DomainInfra.Aggregates;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Model
{
    public class Catalogue
        : AggregateRootEntity
    {
        public static async Task<Result<Catalogue>> Create(string name)
            => Result.Ok(new Catalogue(new NewCatalogueEvent(Guid.NewGuid(), name)));
        protected Catalogue(NewCatalogueEvent msg)
            : this()
            => ApplyChange<Catalogue>(msg);

        public string Name { get; set; }
        public IList<CatalogueCategory> Categories { get; }

        public Result<Catalogue> AddProduct(
            Guid categoryId, Product product)
        {
            //not working logic
            //if (Root.SubNodes.All(category => category.Id != categoryId))
            //{
            //    return Result.Fail<Catalogue>("category not exist");
            //}

            return ApplyChange<Catalogue>(new ProductAddedToCategory(product.Id)); // snap
        }
        protected Catalogue()
        {
            Register<NewCatalogueEvent>(When);
            Register<ProductAddedToCategory>(When);
        }

        private void When(NewCatalogueEvent msg)
        {
            Id = msg.Id;
            Name = msg.Name;
        }

        private void When(ProductAddedToCategory msg)
        {
            Categories
                .SingleOrDefault()
                .When(msg)
                ;
        }
    }

    //public class GetCategoryByIdQuery
    //{
    //    public CatalogueCategory Query(Guid id)
    //    {

    //    }
    //}
}

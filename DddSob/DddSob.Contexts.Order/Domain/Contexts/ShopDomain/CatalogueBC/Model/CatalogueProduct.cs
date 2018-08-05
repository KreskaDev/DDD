using System;
using DddSob.Storage.Persistance.Nh.Model;
using DddSob.Storage.Persistance.Nh.Relations;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Model
{
    public class CatalogueProduct
        //: Leaf
        : Entity<Guid>
        , IEntity
    {
        public CatalogueProduct(Guid id) 
            : base(id)
        { }

        public string Name { get; set; }
        public string Image { get; set; }

        //protected override IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return Name;
        //    yield return Image;
        //    yield return base.GetEqualityComponents();
        //}   
    }
}
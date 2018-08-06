using DddSob.Contexts.NoRelation.Domain.Common.Models;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model
{
    public class OrderTaxRoot
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Money Amount { get; set; }
    }
}
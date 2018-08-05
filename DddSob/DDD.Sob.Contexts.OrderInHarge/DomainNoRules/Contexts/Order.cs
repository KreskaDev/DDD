using System;

namespace DddSob.Contexts.NoRelation.DomainNoRules.Contexts
{
    public class Order
    {
        public int Id { get; set; }
        public BuyerSnapshot Buyer { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsCompleate { get; protected set; }

        public Order()
        {
            IsCompleate = false;
        }

        public void FinalizeOrder()
        {
            IsCompleate = true;
        }
    }

    //public class BlaBlaOrder : Order
    //{
    //    public int MinimalAmount { get; set; }
    //    public IList<OrderLine> OrderLines { get; set; }

    //    public void AddOrderLine(ProductSnapshot product, int amount)
    //    {
    //        OrderLines.Add(new OrderLine(product, amount));
    //    }
    //}
}
using DddSob.Contexts.NoRelation.Common;

namespace DddSob.Contexts.NoRelation.ReadModel
{
    public class Invoice
    {
        public int Id { get; set; }
        public Money TotalAmount { get; set; }
        //public BuyerSnapshot Buyer { get; set; }
    }
}

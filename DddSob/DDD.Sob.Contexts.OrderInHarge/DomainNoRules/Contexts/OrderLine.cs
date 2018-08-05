using DddSob.Contexts.NoRelation.Common;

namespace DddSob.Contexts.NoRelation.DomainNoRules.Contexts
{
    public class OrderLine
    {
        public int Id { get; set; }
        public OrderSnapshot OrderSnapshot { get; set; }
        public ProductSnapshot Product { get; set; }
        public decimal Amount { get; set; }
        public Money TotalAmount => new Money
        {
            Amount = Product.Price.Amount * Amount,
            Currency = Product.Price.Currency
        };

        public OrderLine(ProductSnapshot product, int amount)
        {
            Amount = amount;
            Product = product;
        }
    }
}
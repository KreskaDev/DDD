using DddSob.Contexts.NoRelation.Common;

namespace DddSob.Contexts.NoRelation.DomainNoRules.Contexts
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
    }
}
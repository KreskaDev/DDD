using DddSob.Contexts.NoRelation.Common;

namespace DddSob.Contexts.NoRelation.DomainNoRules
{
    public class ProductSnapshot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
    }
}
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.DomainInfra.Aggregates;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.InvoicesBC.Model
{
    public class TaxRoot
        : AggregateRootEntity
    {
        public string TaxSource { get; set; }
        public Money Amount { get; set; }
    }
}

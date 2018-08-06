using System.Collections.Generic;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.InvoicesBC.Model
{
    public class Invoice
        : AggregateRootEntity
    {
        public int Id { get; protected set; }
        public long OrderId { get; protected set; }
        public Money TotalAmount { get; protected set; }
        //public Contractor Seller { get; protected set; }
        //public Contractor Buyer { get; protected set; }
        public IList<InvoiceLine> Positions { get; protected set; }
    }

    public class InvoiceLine
    {

    }

    public class InvoiceMappingOverride
        : IAutoMappingOverride<Invoice>
    {
        public void Override(AutoMapping<Invoice> mapping)
        {
            mapping.Component(x => x.TotalAmount);
        }
    }

}

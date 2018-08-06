using DddSob.DomainInfra.Model;

namespace DddSob.Contexts.NoRelation.ShipmentCargoTraning.Domain.Model
{
    public class Port
        : AggregateRootEntity
    {
        public virtual string Name { get; protected set; }
        public virtual string Address { get; protected set; }
    }
}

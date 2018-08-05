using System;
using DddSob.Storage.Persistance.Nh.Relations;

namespace DddSob.Storage.Persistance.Nh.Model
{
    public abstract class NhAggregateRootEntity
        : IHierarchyRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual Int32 ExpectedVersion { get; protected set; }
    }
}

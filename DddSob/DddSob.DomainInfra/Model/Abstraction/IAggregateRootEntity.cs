namespace DddSob.DomainInfra.Model.Abstraction
{
    /// <summary>
    /// Aggregate root entity marker interface.
    /// </summary>
    public interface IAggregateRootEntity 
        : IAggregateInitializer
        , IAggregateChangeTracker
    {
    }
}
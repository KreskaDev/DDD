using System;

namespace DddSob.DomainInfra.EventRouter
{
    public interface IConfigureInstanceEventRouter : IInstanceEventRouter
    {
        void ConfigureRoute(Type @event, Action<object> handler);
        
        void ConfigureRoute<TEvent>(Action<TEvent> handler);
    }
}
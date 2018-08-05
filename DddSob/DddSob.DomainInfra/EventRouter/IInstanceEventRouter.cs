namespace DddSob.DomainInfra.EventRouter
{
    public interface IInstanceEventRouter
    {
        void Route(object @event);
    }
}
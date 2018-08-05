using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.EventRouter;
using DddSob.DomainInfra.Model.Abstraction;
using DddSob.Storage.Persistance.Nh.Model;
using MediatR;

namespace DddSob.DomainInfra.Model
{
    public abstract class AggregateRootEntity
        : NhAggregateRootEntity
        , IAggregateRootEntity
    {
        readonly EventRecorder _recorder;
        readonly IConfigureInstanceEventRouter _router;

        protected AggregateRootEntity()
        {
            _router = new InstanceEventRouter();
            _recorder = new EventRecorder();
        }
        
        protected void Register<TEvent>(Action<TEvent> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            _router.ConfigureRoute(handler);
        }
        
        public virtual void Initialize(IEnumerable<object> events)
        {
            if (events == null) throw new ArgumentNullException(nameof(events));
            if (HasChanges())
                throw new InvalidOperationException("Initialize cannot be called on an instance with changes.");
            foreach (var @event in events)
            {
                Play(@event);
            }
        }

        protected Result<TAggregate> ApplyChange<TAggregate>(INotification @event) 
            where TAggregate : class
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            BeforeApplyChange(@event);
            Play(@event);
            Record(@event);
            AfterApplyChange(@event);
            return Result.Ok(this as TAggregate);
        }
        
        protected virtual void BeforeApplyChange(object @event) { }
        
        protected virtual void AfterApplyChange(object @event) { }

        private void Play(object @event)
        {
            _router.Route(@event);
        }

        private void Record(INotification @event)
        {
            _recorder.Record(@event);
        }
        
        public virtual bool HasChanges()
        {
            return _recorder.Any();
        }
        
        public virtual IEnumerable<INotification> GetChanges()
        {
            return _recorder.ToArray();
        }
        
        public virtual void ClearChanges()
        {
            _recorder.Reset();
        }
    }
}

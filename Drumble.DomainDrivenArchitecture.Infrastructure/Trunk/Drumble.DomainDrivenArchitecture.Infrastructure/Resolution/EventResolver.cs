using Microsoft.Practices.Unity;
using System;
using Drumble.DomainDrivenArchitecture.Domain.Events;
using Drumble.DomainDrivenArchitecture.Events;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.Resolution
{
    public class EventResolver
    {
        protected IUnityContainer Container { get; private set; }

        public EventResolver(IUnityContainer container)
        {
            Container = container;
            DomainEvents.Container = container;
        }

        public void RegisterEvent<TEvent, TEventHandler>()
            where TEvent : IDomainEvent
            where TEventHandler : IDomainEventHandler<TEvent>
        {
            string name = String.Format("{0}_{1}", typeof(TEvent).Name, typeof(TEventHandler).Name);

            Container.RegisterType<IDomainEventHandler<TEvent>, TEventHandler>(name);
        }
    }
}
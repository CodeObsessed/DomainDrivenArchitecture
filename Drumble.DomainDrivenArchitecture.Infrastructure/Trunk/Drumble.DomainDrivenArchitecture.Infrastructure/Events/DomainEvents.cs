using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumble.DomainDrivenArchitecture.Domain.Events;

namespace Drumble.DomainDrivenArchitecture.Events
{
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        public static IUnityContainer Container { get; set; }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }

            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            if (Container != null)
            {
                foreach (var handler in Container.ResolveAll<IDomainEventHandler<T>>())
                {
                    Task.Factory.StartNew(() =>
                    {
                        handler.Handle(domainEvent);
                    })
                    .ContinueWith(t =>
                    {
                        // Logger
                    },
                    TaskContinuationOptions.OnlyOnFaulted);
                }
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(domainEvent);
                    }
                }
            }
        }
    }
}
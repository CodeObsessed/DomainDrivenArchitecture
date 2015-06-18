using System;
using Drumble.DomainDrivenArchitecture.Domain.EntityFramework;
using Drumble.DomainDrivenArchitecture.Domain.Interfaces;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework
{
    public sealed class EntityFrameworkUnitOfWork<TContext> : IUnitOfWork
        where TContext : EntityFrameworkContext
    {
        public IContext Context
        {
            get
            {
                var context = Activator.CreateInstance<TContext>();
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                return context;
            }
        }

        public EntityFrameworkUnitOfWork()
        {
        }
    }
}
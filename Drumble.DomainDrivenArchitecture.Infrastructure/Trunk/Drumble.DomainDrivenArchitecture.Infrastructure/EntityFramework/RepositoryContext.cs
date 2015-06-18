using RefactorThis.GraphDiff;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Drumble.DomainDrivenArchitecture.Domain.Interfaces;
using Drumble.DomainDrivenArchitecture.Extensions;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework
{
    public class RepositoryContext<TDataEntity> : IDisposable
            where TDataEntity : class, new()
    {
        public DbContext context;

        private List<Expression<Func<TDataEntity, object>>> queryAggregateMappings;

        private Expression<Func<IUpdateConfiguration<TDataEntity>, object>> updateAggregateMapping;

        public RepositoryContext(IUnitOfWork unitOfWork)
        {
            context = (DbContext)unitOfWork.Context;
        }

        public RepositoryContext(IUnitOfWork unitOfWork, IEnumerable<Expression<Func<TDataEntity, object>>> queryMappings)
            : this(unitOfWork)
        {
            queryAggregateMappings = queryMappings.ToList();
        }

        public RepositoryContext(IUnitOfWork unitOfWork, Expression<Func<IUpdateConfiguration<TDataEntity>, object>> updateMappings, IEnumerable<Expression<Func<TDataEntity, object>>> queryMappings)
            : this(unitOfWork, queryMappings)
        {
            updateAggregateMapping = updateMappings;
        }

        public void Add(TDataEntity entity)
        {
            context.Set<TDataEntity>().Add(entity);
        }

        public void Update(TDataEntity entity)
        {
            if (updateAggregateMapping == null)
            {
                context.UpdateGraph<TDataEntity>(entity);
            }
            else
            {
                context.UpdateGraph<TDataEntity>(entity, updateAggregateMapping);
            }
        }

        public IQueryable<TDataEntity> Query()
        {
            if (queryAggregateMappings == null)
            {
                return context.Set<TDataEntity>().AsNoTracking();
            }
            else
            {
                return context.Set<TDataEntity>().IncludeMany(queryAggregateMappings).AsNoTracking();
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
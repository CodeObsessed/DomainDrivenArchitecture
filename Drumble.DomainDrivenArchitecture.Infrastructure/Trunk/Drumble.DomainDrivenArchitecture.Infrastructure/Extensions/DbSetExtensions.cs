using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Drumble.DomainDrivenArchitecture.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> IncludeMany<T>(this DbSet<T> set, IEnumerable<Expression<Func<T, object>>> includes)
            where T : class
        {
            var queryable = set.AsQueryable<T>();

            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable;
        }
    }
}
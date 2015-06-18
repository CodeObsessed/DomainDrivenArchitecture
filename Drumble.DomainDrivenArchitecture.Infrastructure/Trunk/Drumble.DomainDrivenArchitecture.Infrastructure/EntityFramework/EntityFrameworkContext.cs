using System.Data.Entity;
using Drumble.DomainDrivenArchitecture.Domain.Interfaces;

namespace Drumble.DomainDrivenArchitecture.Domain.EntityFramework
{
    public class EntityFrameworkContext : DbContext, IContext
    {
        public EntityFrameworkContext()
            : base()
        { }

        public EntityFrameworkContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
    }
}
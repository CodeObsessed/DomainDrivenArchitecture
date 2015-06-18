using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drumble.DomainDrivenArchitecture.Domain.Repositories;

namespace TestConsole
{
    public interface IStopRepository : IRepository<Stop, Guid>, IUpdateableRepository<Stop, Guid>, IDeleteableRepository<Stop, Guid>, IAddableRepository<Stop, Guid>
    {
        IReadOnlyCollection<Stop> GetAll();
    }
}

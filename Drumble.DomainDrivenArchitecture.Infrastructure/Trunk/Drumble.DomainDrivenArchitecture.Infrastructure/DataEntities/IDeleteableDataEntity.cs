using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.DataEntities
{
    public interface IDeleteableDataEntity<TIdentity> : IDataEntity<TIdentity>
    {
        DateTime DeletedDate { get; set; }

        bool IsDeleted { get; set; }
    }
}

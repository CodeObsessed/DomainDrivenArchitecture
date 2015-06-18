using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.DataEntities
{
    public interface IAddableDataEntity<TIdentity> : IDataEntity<TIdentity>
    {
        DateTime CreatedDate { get; set; }
    }
}

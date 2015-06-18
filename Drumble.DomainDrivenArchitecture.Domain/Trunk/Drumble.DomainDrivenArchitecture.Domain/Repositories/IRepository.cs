using Drumble.DomainDrivenArchitecture.Domain.Models;

namespace Drumble.DomainDrivenArchitecture.Domain.Repositories
{
    public interface IRepository<TDomainEntity, TIdentity>
        where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
    {
        TDomainEntity Find(TIdentity id);
    }
}
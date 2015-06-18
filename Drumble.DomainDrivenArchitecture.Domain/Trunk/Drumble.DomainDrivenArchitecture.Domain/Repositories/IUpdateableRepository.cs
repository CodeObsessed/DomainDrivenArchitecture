using Drumble.DomainDrivenArchitecture.Domain.Models;

namespace Drumble.DomainDrivenArchitecture.Domain.Repositories
{
    public interface IUpdateableRepository<TDomainEntity, TIdentity> : IRepository<TDomainEntity, TIdentity>
        where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
    {
        void Update(TDomainEntity item);
    }
}
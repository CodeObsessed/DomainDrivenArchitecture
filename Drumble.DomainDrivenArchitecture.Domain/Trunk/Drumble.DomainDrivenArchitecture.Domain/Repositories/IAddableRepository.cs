using Drumble.DomainDrivenArchitecture.Domain.Models;

namespace Drumble.DomainDrivenArchitecture.Domain.Repositories
{
    public interface IAddableRepository<TDomainEntity, TIdentity> : IRepository<TDomainEntity, TIdentity>
       where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
    {
        void Add(TDomainEntity item);
    }
}
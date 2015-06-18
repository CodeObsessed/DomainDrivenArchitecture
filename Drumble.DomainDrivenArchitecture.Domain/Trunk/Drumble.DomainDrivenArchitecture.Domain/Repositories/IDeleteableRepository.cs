using Drumble.DomainDrivenArchitecture.Domain.Models;

namespace Drumble.DomainDrivenArchitecture.Domain.Repositories
{
    public interface IDeleteableRepository<TDomainEntity, TIdentity> : IRepository<TDomainEntity, TIdentity>
        where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
    {
        void Delete(TDomainEntity item);
    }
}

namespace Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework
{
    public interface IEntityMapper<TDomainEntity, TDataEntity>
    {
        TDomainEntity CreateFrom(TDataEntity dataEntity);

        TDataEntity CreateFrom(TDomainEntity domainEntity);
    }
}
namespace Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework
{
    public interface IReadOnlyEntityMapper<TDomainEntity, TDataEntity>
    {
        TDomainEntity CreateFrom(TDataEntity dataEntity);
    }
}
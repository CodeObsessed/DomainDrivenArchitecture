namespace Drumble.DomainDrivenArchitecture.Infrastructure.DataEntities
{
    public interface IDataEntity<TIdentity>
    {
        TIdentity Id { get; }


    }
}
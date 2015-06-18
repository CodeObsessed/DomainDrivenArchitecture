namespace Drumble.DomainDrivenArchitecture.Domain.Models
{
    public interface IIdentityFactory<T>
    {
        T GenerateIdentity();
    }
}
namespace Drumble.DomainDrivenArchitecture.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IContext Context { get; }
    }
}
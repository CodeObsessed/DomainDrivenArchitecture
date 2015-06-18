namespace Drumble.DomainDrivenArchitecture.Domain.Events
{
    public interface IDomainEventHandler<T>
        where T : IDomainEvent
    {
        void Handle(T args);
    }
}
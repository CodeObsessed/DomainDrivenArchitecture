using System;

namespace Drumble.DomainDrivenArchitecture.Domain.Events
{
    public interface IDomainEventLog
    {
        void LogFatal(string context, string message);

        void LogFatal(string context, string message, Exception exception);
    }
}
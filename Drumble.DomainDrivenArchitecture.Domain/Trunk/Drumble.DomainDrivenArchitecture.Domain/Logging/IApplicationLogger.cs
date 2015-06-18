using System;

namespace Drumble.DomainDrivenArchitecture.Domain.Logging
{
    public interface IApplicationLogger
    {
        void LogTrace(string context, string message);

        void LogDebug(string context, string message);

        void LogInfo(string context, string message);

        void LogWarning(string context, string message);

        void LogError(string context, string message);

        void LogError(string context, string message, Exception ex);

        void LogFatal(string context, string message);

        void LogFatal(string context, string message, Exception ex);
    }
}
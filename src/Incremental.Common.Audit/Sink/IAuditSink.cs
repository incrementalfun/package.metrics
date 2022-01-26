using Incremental.Common.Audit.Events;

namespace Incremental.Common.Audit.Sink;

public interface IAuditSink
{
    public Task SaveAsync<TAuditEvent>(TAuditEvent @event, CancellationToken cancellationToken = default)
        where TAuditEvent : AuditEvent;
}
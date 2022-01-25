namespace Incremental.Common.Audit.Events;

public interface IAuditEventFactory
{
    Task<TAuditEvent> CreateAuditEventAsync<TAuditEvent>(CancellationToken cancellationToken) where TAuditEvent : AuditEvent, new();
}
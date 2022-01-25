namespace Incremental.Common.Audit.Events;

public interface IAuditEventFactory
{
    Task<TAuditEvent> CreateAuditEventAsync<TAuditEvent>(string eventName, CancellationToken cancellationToken) where TAuditEvent : AuditEvent, new();
}